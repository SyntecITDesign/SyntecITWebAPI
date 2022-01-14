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
			string sql = $@"INSERT INTO [dbo].[CarBookingApplicationsMaster] 
							([ApplicationID],[ApplicationName],[ApplicationDate],[FillerID],[FillerName]
							,[TypePersonalBusiness]
							,[PreserveStartTime],[PreserveEndTime],[ActualStartTime],[ActualEndTime]
							,[CarNumber],[Remark],[StartPlace],[EndPlace])
							VAlUES('10190438',  '林展宏',  '20210114',  '10190438',  '林展宏',
							'private',  '2022-011-14 14:32:32',  '2022-011-16 14:32:32',NULL,NULL,  'AU9005',  '台中出差',
							'新竹',  '台中')";
			
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
			string sql = $@"DELETE FROM [dbo].[CarBookingApplicationsMaster]
							WHERE [CarBookingApplicationsMasterAllFieldApplicationID]=@Parameter0 and 
								  [CarBookingApplicationsMasterAllFieldApplicationDate]=@Parameter1 and
								  [CarBookingApplicationsMasterAllFieldTypePersonalBusiness]=@Parameter2 and
                                  [CarBookingApplicationsMasterAllFieldPreserveStartTime]=@Parameter3 and
								  [CarBookingApplicationsMasterAllFieldPreserveEndTime]=@Parameter4 and
								  [CarBookingApplicationsMasterAllFieldCarNumber]=@Parameter5";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationID,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationDate,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldTypePersonalBusiness,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveStartTime,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveEndTime,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldCarNumber
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}
