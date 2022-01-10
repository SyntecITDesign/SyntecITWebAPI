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
							WHERE [ApplicationID]=@Parameter0 and [AcutalStartTime] is NULL";

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
							,[TypeApplyCancel],[TypePersonalBusiness]
							,[PreserveStartTime],[PreserveEndTime],[ActualStartTime],[ActutalEndTime]
							,[CarNumber],[Remark],[StartPlace],[EndPlace])
							VAUES(@Parameter0,  @Parameter1,  @Parameter2,  @Parameter3,  @Parameter4,
								  @Parameter5,  @Parameter6,  @Parameter7,  @Parameter8,  @Parameter9,
								  @Parameter10, @Parameter11, @Parameter12, @Parameter13, @Parameter14	)";
			
			List<object> SQLParameterList = new List<object>()
			{
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationID,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationName,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationDate,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerID,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerName,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldTypeApplyCancel,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldTypePersonalBusiness,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveStartTime,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldPreserveEndTime,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldActualStartTime,
				InsertCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldActualEndTime,
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
								  [CarBookingApplicationsMasterAllFieldApplicationName]=@Parameter1 and
								  [CarBookingApplicationsMasterAllFieldApplicationDate]=@Parameter2 and
								  [CarBookingApplicationsMasterAllFieldFillerID]=@Parameter3 and
								  [CarBookingApplicationsMasterAllFieldFillerName]=@Parameter4 and
								  [CarBookingApplicationsMasterAllFieldTypeApplyCancel]=@Parameter5 and
								  [CarBookingApplicationsMasterAllFieldTypePersonalBusiness]=@Parameter6 and
                                  [CarBookingApplicationsMasterAllFieldPreserveStartTime]=@Parameter7 and
								  [CarBookingApplicationsMasterAllFieldPreserveEndTime]=@Parameter8 and
								  [CarBookingApplicationsMasterAllFieldCarNumber]=@Parameter9";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationID,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationName,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldApplicationDate,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerID,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldFillerName,
				DeleteCarBookingApplicationsMasterParameter.CarBookingApplicationsMasterAllFieldTypeApplyCancel,
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
