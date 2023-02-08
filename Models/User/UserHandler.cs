using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.Common.MailRelated;
using SyntecITWebAPI.Common.MailRelated.User;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.Mail;
using SyntecITWebAPI.ParameterModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntecITWebAPI.Models
{
	internal class UserHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal ErrorCodeList ForgotPassword( string userID, string userEmail, string userLang, IUrlHelper urlHelper, string scheme )
		{
			if( !m_dbManager.IsUserEmailExist( userID, userEmail ) ) //if user,email not exist in OptionUser
			{
				//公司員工不能在這裡改喔->回傳錯誤碼
				if( m_barcodeDBManager.IsSyntecEmpExist( userID, userEmail ) )
					return ErrorCodeList.Illegal_Request;
				else
					return ErrorCodeList.Verify_Fail;
			}
			else // if user,email exist
			{
				// Generate verifyCode
				string randomString = GetRandomString( 10 );

				// Update verifyCode

				if( !m_dbManager.UpdateUserVerifyCode( userID, randomString ) )
				{
					return ErrorCodeList.Update_Error;
				}

				//get ForgotPasswordVerification api url
				var url = urlHelper.Action( "ForgotPasswordVerification", "OpenUser", new
				{
					userID = userID,
					verifyCode = randomString
				}, scheme );

				//mail setting
				MailParameter mailParameter = new MailParameter
				{
					userEmail = userEmail,
					userID = userID,
					userLang = userLang,
					mailAttachParameter = new Dictionary<string, object>
					{
						{nameof(url) , url }
					}
				};
				//mail
				ForgotPasswordMailHandler mailHandler = new ForgotPasswordMailHandler( new List<MailParameter> { mailParameter } );

				if( mailHandler.SendMail() ) // if success to mail
				{
					return ErrorCodeList.Success;
				}
				else
				{
					return ErrorCodeList.Mail_Failed;
				}
			}
		}

		internal ErrorCodeList ForgotPasswordReset( string userID, string newPassword, string verifyCode )
		{
			if( !m_dbManager.IsUserVerifyCodeExist( userID, verifyCode ) )
			{
				return ErrorCodeList.Verify_Fail;
			}
			else
			{
				string newVerifyCode = GetRandomString( 10 );
				if( EncryptUpdateOptionUserPassword( userID, newPassword ) == false || m_dbManager.UpdateUserVerifyCode( userID, newVerifyCode ) == false )
				{
					return ErrorCodeList.Update_Error;
				}
				else
				{
					return ErrorCodeList.Success;
				}
			}
		}

		// if success return Code = Success, Content = Verify Code . if fail return Code = error.
		internal ResponseHandler ForgotPasswordVerification( string userID, string verifyCode )
		{
			ResponseHandler responseHandler = new ResponseHandler();

			if( !m_dbManager.IsUserVerifyCodeExist( userID, verifyCode ) )
			{
				responseHandler.Code = ErrorCodeList.Verify_Fail;
			}
			else
			{
				string newVerifyCode = GetRandomString( 10 );

				//PWChanged = 0時卡控，必須重設密碼才能登入
				if( ( m_dbManager.UpdateUserVerifyCode( userID, newVerifyCode ) ) == false || m_dbManager.UpdateUserPWChanged( userID, 0 ) == false )
				{
					responseHandler.Code = ErrorCodeList.Update_Error;
				}
				else
				{
					responseHandler.Code = ErrorCodeList.Success;
					responseHandler.Content = newVerifyCode;
				}
			}
			return responseHandler;
		}

		internal JObject GetMachineCodeByID( string userID )
		{
			JObject result = new JObject();
			//從optionUser表找使用者的機器碼
			string machineCode = m_dbManager.GetOptionMachineCode( userID );
			if( string.IsNullOrEmpty( machineCode ) )
			{
				if( string.IsNullOrEmpty( m_barcodeDBManager.GetSyntecEmpNameByID( userID ) ) )
				{
					return null;
				}
				else //若為公司員工 機器碼則為0000
				{
					machineCode = "0000";
				}
			}

			result.Add( nameof( machineCode ), machineCode );
			return result;
		}

		internal JObject GetUserNameByID( string userID )
		{
			//From optionUser
			string userName = m_dbManager.GetOptionUserNameByID( userID );
			if( string.IsNullOrEmpty( userName ) )
				userName = m_barcodeDBManager.GetSyntecEmpNameByID( userID );

			JObject userNameJSON = new JObject();
			userNameJSON.Add( nameof( userName ), userName );
			return userNameJSON;
		}

		//urlHelper and scheme are used to generate url
		internal ResponseHandler Register( RegisterParameter registerParameter, IUrlHelper urlHelper, string scheme )
		{
			ResponseHandler responseHandler = new ResponseHandler();

			if( m_dbManager.IsOptionUserExist( registerParameter.userID ) )
			{
				responseHandler.Code = ErrorCodeList.Insert_Problem_KeyColumn_Exist;
				responseHandler.Detail = nameof( registerParameter.userID ) + " exist.";

				return responseHandler;
			}
			else
			{
				if( registerParameter.type == 1 ) //在首頁申請(機械廠母帳號)
				{
					if( m_dbManager.IsMachineCodeExist( registerParameter.machineCode ) )
					{
						responseHandler.Code = ErrorCodeList.Insert_Problem_KeyColumn_Exist;
						responseHandler.Detail = nameof( registerParameter.machineCode ) + " exist.";

						return responseHandler;
					}
					else if( m_dbManager.IsEmailExist( registerParameter.userEmail ) )
					{
						responseHandler.Code = ErrorCodeList.Insert_Problem_KeyColumn_Exist;
						responseHandler.Detail = nameof( registerParameter.userEmail ) + " exist.";

						return responseHandler;
					}

					registerParameter.status = 0;
				}
				else
				{
					registerParameter.status = 1;
				}

				// generate new verify code & set CreateDate
				registerParameter.verifyCode = GetRandomString( 10 );
				registerParameter.CreateDate = System.DateTime.Now.ToString( "yyyy/MM/dd HH:mm:ss" );

				//insert
				bool insertResult = m_dbManager.InsertUserAllData( registerParameter );
				if( insertResult == false )
				{
					responseHandler.Code = ErrorCodeList.Insert_Error;
					return responseHandler;
				}

				////get Managemail 測試先不要開
				//(List<string> manageNameList, List<string> manageEmailList) = m_barcodeDBManager.GetManagersNameEmail();

				//測試用 後續處理需換成上面的get Managemail
				List<string> manageNameList = new List<string> { "Clyde", "吳伯揚" };
				List<string> manageEmailList = new List<string> { "david850519@gmail.com", "j61i6u6@gmail.com" };

				//mail setting (Manager)
				List<MailParameter> managerMailParameters = new List<MailParameter>();
				for( int index = 0; index < manageEmailList.Count; ++index )
				{
					MailParameter mailParameter = new MailParameter
					{
						userEmail = manageEmailList[ index ],
						userName = manageNameList[ index ],
						mailAttachParameter = new Dictionary<string, object>()
						{
							{ nameof(registerParameter.userID), registerParameter.userID },
							{ nameof(registerParameter.userName) , registerParameter.userName},
							{ nameof(registerParameter.machineCode), registerParameter.machineCode },
							{ nameof(registerParameter.companyName),registerParameter.companyName },
							{ nameof(registerParameter.companyAddress),registerParameter.companyAddress },
							{ nameof(registerParameter.userEmail),registerParameter.userEmail },
							{ nameof(registerParameter.userPhone),registerParameter.userPhone }
						}
					};
					managerMailParameters.Add( mailParameter );
				}

				RegisterManagerMailHandler registerManagerMailHandler = new RegisterManagerMailHandler( managerMailParameters );

				//Send mail (Manager)
				if( !registerManagerMailHandler.SendMail() ) // if success to mail
				{
					responseHandler.Code = ErrorCodeList.Mail_Failed;
					responseHandler.Detail = "Send to Manager Fail.";

					return responseHandler;
				}

				//Mail Setting (User)
				var url = urlHelper.Action( "RegisterVerification", "User", new
				{
					userID = registerParameter.userID,
					verifyCode = registerParameter.verifyCode
				}, scheme );

				MailParameter userMailParameters = new MailParameter
				{
					userEmail = registerParameter.userEmail,
					userID = registerParameter.userID,
					userName = registerParameter.userName,
					mailAttachParameter = new Dictionary<string, object>
					{
						{nameof(registerParameter.userID) , registerParameter.userID },
						{nameof(registerParameter.userPassword) , registerParameter.userPassword },
						{nameof(registerParameter.userName) , registerParameter.userName },
						{nameof(registerParameter.machineCode) , registerParameter.machineCode },
						{nameof(registerParameter.companyName) , registerParameter.companyName },
						{nameof(registerParameter.companyAddress) , registerParameter.companyAddress },
						{nameof(registerParameter.userEmail) , registerParameter.userEmail },
						{nameof(registerParameter.userPhone) , registerParameter.userPhone },
						{nameof(url) , url }
					}
				};
				RegisterUserMailHandler registerUserMailHandler = new RegisterUserMailHandler( new List<MailParameter> { userMailParameters } );

				//Send mail (User)
				if( !registerUserMailHandler.SendMail() ) // if success to mail
				{
					responseHandler.Code = ErrorCodeList.Mail_Failed;
					responseHandler.Detail = "Send to User Fail.";

					return responseHandler;
				}

				return responseHandler;
			}
		}

		//return string => querystring in redirect url
		internal string RegisterVerification( string userID, string verifyCode )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			if( m_dbManager.GetStatusByID( userID ) == "1" ) // if Status = 1 帳號已啟用
			{
				return "Activated"; //已啟用
			}
			else
			{
				if( !m_dbManager.IsUserVerifyCodeExist( userID, verifyCode ) ) //if 驗證失效
				{
					return ErrorCodeList.Verify_Fail.ToString();
				}
				else
				{
					string newVerifyCode = GetRandomString( 10 );
					if( m_dbManager.UpdateUserStatus( userID, "1" ) == false || m_dbManager.UpdateUserVerifyCode( userID, newVerifyCode ) == false ) //Update status to 1 => activated
					{
						return ErrorCodeList.Update_Error.ToString();
					}
					else
					{
						return ErrorCodeList.Success.ToString();
					}
				}
			}
		}

		internal ErrorCodeList ResetPassword( string userID, string userOldPassword, string userNewPassword )
		{
			FlowBase flowBase = new FlowBase();
			LoginHandler loginHandler = new LoginHandler( userID, userOldPassword );
			ResponseHandler loginResult = loginHandler.Login();

			if( loginResult.Code != ErrorCodeList.Success && loginResult.Code != ErrorCodeList.Password_Need_Change ) // if login fail and fail message is not PW need change => allow success or pw need change
			{
				return loginResult.Code;
			}
			else // if login success
			{
				if( m_dbManager.IsOptionUserExist( userID ) ) //if option user exist
				{
					bool updateResult = EncryptUpdateOptionUserPassword( userID, userNewPassword );
					if( updateResult ) //success
					{
						return ErrorCodeList.Success;
					}
					else // Update error
					{
						return ErrorCodeList.Update_Error;
					}
				}
				else // if optionuser not exist => 新代內部Flow登入
				{
					// 公司員工不能在這裡改喔->回傳錯誤碼
					return ErrorCodeList.Illegal_Request;
				}
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private BarcodeDBManager m_barcodeDBManager = new BarcodeDBManager();
		private UserDBManager m_dbManager = new UserDBManager();

		#endregion Private Fields

		#region Private Methods

		private bool EncryptUpdateOptionUserPassword( string userID, string userNewPassword )
		{
			// encrypt password and update
			clsCRM clsCRM = new clsCRM();
			string encryptPassword = clsCRM.CrypUserPWD( userNewPassword );

			return m_dbManager.UpdateOptionUserPassword( encryptPassword, userID );
		}

		private string GetRandomString( int length )
		{
			string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			Random next = new Random();
			StringBuilder builder = new StringBuilder();
			for( var i = 0; i < length; ++i )
			{
				builder.Append( str[ next.Next( 0, str.Length ) ] );
			}
			return builder.ToString();
		}

		#endregion Private Methods
	}
}
