using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyCarBooking;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyCarBookingDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplyCarBookingDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}



		internal DataTable GetCarBookingApplicationsMaster( GetCarBookingApplicationsMaster GetCarBookingApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarBookingApplicationsMaster]
							WHERE [ApplicationID]=@Parameter0  and (GETDATE() between [PreserveStartTime] and [PreserveEndTime] or GETDATE() < [PreserveStartTime])  and [ActualStartTime] is NULL";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool InsertCarBookingApplicationsMaster( InsertCarBookingApplicationsMaster InsertCarBookingApplicationsMasterParameter )
		{
			string sql = $@"IF @Parameter5 = 'private'
								INSERT INTO [{m_gas}].[dbo].[CarBookingApplicationsMaster] 
								([ApplicationID],[ApplicationName],[ApplicationDate],[FillerID],[FillerName]
								,[TypePersonalBusiness]
								,[PreserveStartTime],[PreserveEndTime],[Remark],[StartPlace],[EndPlace])
								VAlUES(@Parameter0,  @Parameter1,  @Parameter2,  @Parameter3,  @Parameter4,
								@Parameter5,  @Parameter6,  @Parameter7,@Parameter9,
								@Parameter10,  @Parameter11)
							ELSE 
								INSERT INTO [{m_gas}].[dbo].[CarBookingApplicationsMaster] 
								([ApplicationID],[ApplicationName],[ApplicationDate],[FillerID],[FillerName]
								,[TypePersonalBusiness]
								,[PreserveStartTime],[PreserveEndTime]
								,[CarNumber],[Remark],[StartPlace],[EndPlace])
								VAlUES(@Parameter0,  @Parameter1,  @Parameter2,  @Parameter3,  @Parameter4,
								@Parameter5,  @Parameter6,  @Parameter7,@Parameter8,  @Parameter9,
								@Parameter10,  @Parameter11)";
			
			List<object> SQLParameterList = new List<object>()
			{
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationID,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationName,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationDate,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerID,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerName,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldTypePersonalBusiness,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveStartTime,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveEndTime,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldCarNumber,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldRemark,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldStartPlace,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldEndPlace
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteCarBookingApplicationsMaster( DeleteCarBookingApplicationsMaster DeleteCarBookingApplicationsMasterParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarBookingApplicationsMaster]
							WHERE  ReuisitionID=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteCarBookingApplicationsMasterParameter.ReuisitionID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}
