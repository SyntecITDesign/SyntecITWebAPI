using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.CarBooking;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class PublicCarBookingDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetCarInfo( )
		{
			string sql = $@"SELECT *
						  FROM [SyntecGAS].[dbo].[CarBookingInfo]
						  ";

		
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}


		internal bool UpsertCarInfo( UpsertCarInfo UpsertCarInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0 )
							UPDATE [jirareport].[dbo].[GAS_GAInfoMaster] 
							SET [ExtensionNum]=@Parameter1, [DoorCardNum]=@Parameter2,[MotorLicense]=@Parameter3,[CarLicense]=@Parameter4,[CarLicense_Syntec]=@Parameter5,[DoorCardNum2]=@Parameter6
							WHERE [EmpID]=@Parameter0 
						ELSE
						INSERT INTO [jirareport].[dbo].[GAS_GAInfoMaster] ([EmpID],[ExtensionNum],[DoorCardNum],[MotorLicense],[CarLicense],[CarLicense_Syntec],[DoorCardNum2]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6)
						
						UPDATE [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster] 
						SET CarLicence=(SELECT CarLicense FROM [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0)
						WHERE [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster].[EmpID]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarInfoParameter.CarID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarTakeInfo( )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[CarBookingRecord]
							WHERE　 (GETDATE() between  [PreserveStartTime] and [PreserveEndTime])　and [ActualStartTime] is NULL　
						 ";

			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpdateCarTakeInfo( UpdateCarTakeInfo UpdateCarTakeInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CarBookingRecord] 
							SET [ActualStartTime]=GETDATE(), [CarNumber] = @Parameter1
							WHERE [EmpID]=@Parameter0 and  [ActualStartTime] is  NULL　and  (GETDATE() between  [PreserveStartTime] and [PreserveEndTime])";

			List<object> SQLParameterList = new List<object>()
			{
				UpdateCarTakeInfoParameter.EmpID,
				UpdateCarTakeInfoParameter.CarNumber,
				UpdateCarTakeInfoParameter.AcutalStartTime
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarBackInfo( )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[CarBookingRecord]
							WHERE　 [ActualStartTime] is　not NULL　and [ActualEndTime] is NULL";

		
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql);


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpdateCarBackInfo( UpdateCarBackInfo UpdateCarBackInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CarBookingRecord] 
							SET [ActualEndTime]=GETDATE(), [StartMileage]=@Parameter2, [EndMileage]=@Parameter3, [Note]=@Parameter4
							WHERE [EmpID]=@Parameter0 and [CarNumber] = @Parameter1 and  [ActualStartTime] is　not NULL　and [ActualEndTime] is NULL";

			List<object> SQLParameterList = new List<object>()
			{
				UpdateCarBackInfoParameter.EmpID,
				UpdateCarBackInfoParameter.CarNumber,
				UpdateCarBackInfoParameter.StartMile,
				UpdateCarBackInfoParameter.EndMile,
				UpdateCarBackInfoParameter.ErrorMemo,
				UpdateCarBackInfoParameter.AcutalEndTime
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}



		internal DataTable GetBlackListInfo( )
		{
			string sql = $@"SELECT [EmpID],[Name],max(convert(varchar, [Date], 111) ) AS 'LastDate'
							FROM [SyntecGAS].[dbo].[CarBookingStatus]
							WHERE [Status] = 'blocked'
							GROUP BY [EmpID],[Name]";

		
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql);


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}


		internal bool InserBlackListInfo( InserBlackListInfo InserBlackListInfoParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CarBookingStatus]
								([Name]
								,[EmpID]
								,[Status]
								,[Date]
								,[Reason])
							VALUES
								((SELECT EmpName From [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0),@Parameter0,'blocked',GETDATE(),@Parameter1)
							";

			List<object> SQLParameterList = new List<object>()
			{
				InserBlackListInfoParameter.EmpID,
				InserBlackListInfoParameter.Reason
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


		internal bool BlacktoWhite( BlacktoWhite BlacktoWhiteParameter )
		{
			string sql = $@"
							UPDATE [SyntecGAS].[dbo].[CarBookingStatus] 
							SET [Status]='open'
							WHERE [EmpID]=@Parameter0 and [Status]='blocked'
							";

			List<object> SQLParameterList = new List<object>()
			{
				BlacktoWhiteParameter.EmpID
			
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetPreserveCar()
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[CarBookingRecord]
							WHERE　 (GETDATE() between  [PreserveStartTime] and [PreserveEndTime])　
						  ";
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}



	}
	#endregion Internal Methods
}
