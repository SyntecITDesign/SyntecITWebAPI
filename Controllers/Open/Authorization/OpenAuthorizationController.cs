using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Models;
using SyntecITWebAPI.Utility;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyntecITWebAPI.Controllers.Open.Authorization
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/Authorization" )]
	[ApiController]
	public class OpenAuthorizationController : ControllerBase
	{
		#region Public Methods

		[Route( "Login" )]
		[CheckBodyNullFilter]
		[HttpPost]
		public IActionResult Login( [FromBody] JObject body )
		{
			ResponseHandler responseHandler = new ResponseHandler();

			string userID = body[ "userID" ].ToString();
			string userPassword = body[ "userPassword" ].ToString();

			//check login if valid
			LoginHandler loginHandler = new LoginHandler( userID, userPassword );
			var optionloginResult = loginHandler.Login();

			//登入失敗 回傳錯誤碼
			if( optionloginResult.Code != ErrorCodeList.Success )
				return Ok( optionloginResult.GetResult() );

			//登入成功 => 取得身分別
			JObject identityList = optionloginResult.Content;

			var userIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
			string weChatID = loginHandler.GetWeChatID( userID );

			var allTokenObject = m_tokenHandler.CreateAllToken( userID, userIP, weChatID, identityList );

			// if create fail return error code
			if( allTokenObject == null )
			{
				//可以Login但無法生成token-> 帳號沒有option權限
				responseHandler.Code = ErrorCodeList.Auth_Error;
				responseHandler.Detail = "Create Token Fail";
			}
			else //if success
			{
				responseHandler.Content = allTokenObject;
			}

			return Ok( responseHandler.GetResult() );
		}

		[Route( "Refresh" )]
		[CheckBodyNullFilter]
		[HttpPost]
		public IActionResult Refresh( [FromHeader] string authorization, [FromBody] JObject body )
		{
			ResponseHandler responseHandler = new ResponseHandler();

			//check header & get refreshToken
			var refreshToken = authorization.GetTokenFromBearerHeader();
			if( string.IsNullOrEmpty( refreshToken ) )
			{
				responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else // if ok
			{
				string userID = body[ "userID" ].ToString();
				var userIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
				var getNewAccessResult = m_tokenHandler.GetNewAccessToken( userID, userIP, refreshToken );

				// if success return (true,<accessToken>) else return (false, ErrorCode.ToString)
				if( getNewAccessResult.success == false ) // if error return error code
				{
					Enum.TryParse( getNewAccessResult.result, out ErrorCodeList errorCodeList );
					responseHandler.Code = errorCodeList;
				}
				else if( getNewAccessResult.success == true )
				{
					responseHandler.Content = getNewAccessResult.result;
				}
			}

			return Ok( responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		private TokenHandler m_tokenHandler = new TokenHandler();

		#endregion Private Fields
	}
}
