using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyCarBooking;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyCarBookingDBManager : AbstractDBManager
	{
		#region Internal Methods
		internal DataTable GetCarBookingApplicationsMaster( GetCarBookingApplicationsMaster GetCarBookingApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[CarBookingApplicationsMaster]
							WHERE [ApplicationID]=@Parameter0 and [ActualStartTime] is NULL";

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
								INSERT INTO [SyntecGAS].[dbo].[CarBookingApplicationsMaster] 
								([ApplicationID],[ApplicationName],[ApplicationDate],[FillerID],[FillerName]
								,[TypePersonalBusiness]
								,[PreserveStartTime],[PreserveEndTime],[Remark],[StartPlace],[EndPlace])
								VAlUES(@Parameter0,  @Parameter1,  @Parameter2,  @Parameter3,  @Parameter4,
								@Parameter5,  @Parameter6,  @Parameter7,@Parameter9,
								@Parameter10,  @Parameter11)
							ELSE 
								INSERT INTO [SyntecGAS].[dbo].[CarBookingApplicationsMaster] 
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
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarBookingApplicationsMaster]
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
