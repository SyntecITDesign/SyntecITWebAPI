using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Filter;
using System;

namespace SyntecITWebAPI
{
	public class Startup
	{
		#region Public Properties

		public IConfiguration Configuration
		{
			get;
		}

		#endregion Public Properties

		#region Public Constructors + Destructors

		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		#endregion Public Constructors + Destructors

		#region Public Methods

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
		{
			app.UseExceptionHandler( new ExceptionHandlerOptions()
			{
				ExceptionHandler = async context =>
				{
					IExceptionHandlerPathFeature exceptionDetails = context.Features.Get<IExceptionHandlerPathFeature>();
					Exception ex = exceptionDetails?.Error;
					string errorPath = exceptionDetails?.Path;
					context.Response.ContentType = "application/json";
					ResponseHandler returnHandler = new ResponseHandler( Enums.ErrorCodeList.System_Error );
					returnHandler.Detail = $"FROM Global, Path: {errorPath}, Error: {ex}";
					await context.Response.WriteAsync( JsonConvert.SerializeObject( returnHandler.GetResult() ) );
					return;
				}
			} );

			//cookie Setting 要注意順序
			app.UseCookiePolicy( new CookiePolicyOptions()
			{
				HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
				MinimumSameSitePolicy = SameSiteMode.Strict,
				Secure = CookieSecurePolicy.Always
			} );

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseCors();
			app.UseAuthorization();
			app.UseAuthentication();

			app.UseEndpoints( endpoints =>
			 {
				 endpoints.MapControllers();
			 } );
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			//Enable Cors
			services.AddCors( options =>
			 {
				 options.AddPolicy( name: "AllowAllPolicy",
					 builder =>
					 {
						 builder.AllowAnyOrigin()
						 .AllowAnyHeader()
						 .AllowAnyMethod();
					 } );
			 } );

			// 停止 Invalid ModelState Filter (關閉後 Model 驗證失敗會無反應) => 因要自訂錯誤訊息
			services.Configure<ApiBehaviorOptions>( options =>
			 {
				 options.SuppressModelStateInvalidFilter = true;
			 } );

			// 加入自訂 Validate Model Filter 執行 Model 驗證失敗的處置 NoCacheAttribute 避免 IE 使用Cache
			services
			  .AddMvc( options =>
			   {
				   options.Filters.Add( typeof( RequiredValidateModelFilter ) );
				   options.Filters.Add( typeof( NoCacheAttribute ) );
			   } );

			// for using json to return in Controller
			services.AddControllersWithViews().AddNewtonsoftJson();

			// for cookie
			services.AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme ).AddCookie();

			services.Configure<IISServerOptions>( options =>
			 {
				 options.AllowSynchronousIO = true;
			 } );
		}

		#endregion Public Methods
	}
}
