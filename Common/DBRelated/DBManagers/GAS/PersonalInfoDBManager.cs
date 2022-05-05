using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.PersonalInfo;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicPersonalInfoDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicPersonalInfoDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal DataTable GetPersonalInfo( GetPersonalInfo GetPersonalInfoParameter )
		{
			string sql = $@"IF @Parameter1 = 'empty'	
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [DeptName] IS not null and ([EmpID]=@Parameter0 OR [EmpName]=@Parameter0)  AND ([QuitDate] is NULL OR [QuitDate] >= GETDATE())
							ELSE
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [DeptName] IS not null and ([EmpID]=@Parameter0 OR [EmpName]=@Parameter0) and [QuitDate] is not  NULL";

			List<object> SQLParameterList = new List<object>()
			{
				GetPersonalInfoParameter.EmpID,
				GetPersonalInfoParameter.QuitDate

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetFuzzyPersonalInfo( GetFuzzyPersonalInfo GetFuzzyPersonalInfoParameter )
		{
			string sql = $@"IF @Parameter1 = 'empty'
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [DeptName] IS not null and ([EmpID] like @Parameter0 OR [EmpName] like @Parameter0)  AND ([QuitDate] is NULL OR [QuitDate] >= GETDATE())
							ELSE
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [DeptName] IS not null and ([EmpID] like @Parameter0 OR [EmpName] like @Parameter0) AND [QuitDate] is not NULL";

			List<object> SQLParameterList = new List<object>()
			{
			  '%'+GetFuzzyPersonalInfoParameter.EmpID + '%',
			  GetFuzzyPersonalInfoParameter.QuitDate
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetPersonalInfoByNameOrg( GetPersonalInfoByNameOrg GetPersonalInfoByNameOrgParameter )
		{
			string sql = $@"IF @Parameter2 = 'empty'
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [EmpName] = @Parameter0 AND [DeptName] = @Parameter1 AND [QuitDate] is NULL
							ELSE
								SELECT *
								FROM [syntecbarcode].[dbo].[TEMP_NAME]
								WHERE [EmpName] = @Parameter0 AND [DeptName] = @Parameter1 AND [QuitDate] is not NULL";

			List<object> SQLParameterList = new List<object>()
			{
			  GetPersonalInfoByNameOrgParameter.EmpName,
			  GetPersonalInfoByNameOrgParameter.DeptName,
			  GetPersonalInfoByNameOrgParameter.QuitDate


			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetPersonalGASInfo( GetPersonalGASInfo GetPersonalGASInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster]
						  WHERE [EmpID] like @Parameter0
						  Order by [Avatar] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetPersonalGASInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpsertPersonalGASInfo( UpsertPersonalGASInfo UpsertPersonalGASInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[GAS_GAInfoMaster] 
							SET [ExtensionNum]=@Parameter1, [DoorCardNum]=@Parameter2,[MotorLicense]=@Parameter3,[CarLicense]=@Parameter4,[CarLicense_Syntec]=@Parameter5,[MotorLicense_Syntec]=@Parameter11,[DoorCardNum2]=@Parameter6,[UniformSize]=@Parameter7,[JacketSize]=@Parameter8,[SweatshirtSize]=@Parameter9,[UniformLongSize]=@Parameter10
							WHERE [EmpID]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[GAS_GAInfoMaster] ([EmpID],[ExtensionNum],[DoorCardNum],[MotorLicense],[CarLicense],[CarLicense_Syntec],[DoorCardNum2] ,[UniformSize],[JacketSize],[SweatshirtSize],[UniformLongSize]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10)
						
						";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertPersonalGASInfoParameter.EmpID,
				UpsertPersonalGASInfoParameter.ExtensionNum,
				UpsertPersonalGASInfoParameter.DoorCardNum,
				UpsertPersonalGASInfoParameter.MotorLicense,
				UpsertPersonalGASInfoParameter.CarLicense,
				UpsertPersonalGASInfoParameter.CarLicense_Syntec,
				UpsertPersonalGASInfoParameter.DoorCardNum2,
				UpsertPersonalGASInfoParameter.UniformSize,
				UpsertPersonalGASInfoParameter.JacketSize,
				UpsertPersonalGASInfoParameter.SweatshirtSize,
				UpsertPersonalGASInfoParameter.UniformLongSize,
				UpsertPersonalGASInfoParameter.MotorLicense_Syntec

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool InsertFreshmanGASInfo( InsertFreshmanGASInfo InsertFreshmanGASInfoParameter )
		{
			string sql = $@"
						INSERT INTO [SyntecGAS].[dbo].[GAS_GAInfoMaster] ([EmpName],[MotorLicense],[CarLicense],[UniformSize],[JacketSize],[SweatshirtSize],[Sex],[UniformLongSize],[Avatar]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertFreshmanGASInfoParameter.EmpName,
				InsertFreshmanGASInfoParameter.MotorLicense,
				InsertFreshmanGASInfoParameter.CarLicense,
				InsertFreshmanGASInfoParameter.UniformSize,
				InsertFreshmanGASInfoParameter.JacketSize,
				InsertFreshmanGASInfoParameter.SweatshirtSize,
				InsertFreshmanGASInfoParameter.Sex,
				InsertFreshmanGASInfoParameter.UniformLongSize,
				InsertFreshmanGASInfoParameter.Avatar

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetProcessingInfo( GetProcessingInfo GetProcessingInfoParameter )
		{

			//string sql = $@"SELECT " + GetProcessingInfoParameter.ApplyString + ".ApplicantID, " + GetProcessingInfoParameter.ApplyString + ".DiagramID, " + GetProcessingInfoParameter.ApplyString + ".ApplicantDateTime FROM  [{m_bpm}].[dbo]." + GetProcessingInfoParameter.ApplyString + "  LEFT JOIN [{m_bpm}].[dbo].[FSe7en_Sys_Requisition] ON " + GetProcessingInfoParameter.ApplyString + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID WHERE " + GetProcessingInfoParameter.ApplyString + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";

			string sql = "";
			string[] ApplyStringList = ( GetProcessingInfoParameter.ApplyString ).Split( "," );


			if( ApplyStringList.Count() == 1 )
			{
				sql = $@"SELECT " + ApplyStringList[ 0 ] + ".ApplicantID, " + ApplyStringList[ 0 ] + ".DiagramID, " + ApplyStringList[ 0 ] + ".ApplicantDateTime, [FSe7en_Tep_FormHeader].value   FROM ([" + m_bpm + "].[dbo]." + ApplyStringList[ 0 ] + " INNER JOIN [" + m_bpm + "].[dbo].[FSe7en_Sys_Requisition] ON " + ApplyStringList[ 0 ] + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID) INNER JOIN [" + m_bpm + "].[dbo].[FSe7en_Tep_FormHeader] ON [FSe7en_Sys_Requisition].RequisitionID=[FSe7en_Tep_FormHeader].RequisitionID WHERE " + ApplyStringList[ 0 ] + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";

			}
			else
			{
				for( int i = 0; i < ApplyStringList.Count(); i++ )
				{

					string oneofsql = $@"SELECT " + ApplyStringList[ i ] + ".ApplicantID, " + ApplyStringList[ i ] + ".DiagramID, " + ApplyStringList[ i ] + ".ApplicantDateTime, [FSe7en_Tep_FormHeader].value   FROM [" + m_bpm + "].[dbo]." + ApplyStringList[ i ] + " INNER JOIN [" + m_bpm + "].[dbo].[FSe7en_Sys_Requisition] ON " + ApplyStringList[ i ] + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID INNER JOIN [" + m_bpm + "].[dbo].[FSe7en_Tep_FormHeader] ON [FSe7en_Sys_Requisition].RequisitionID=[FSe7en_Tep_FormHeader].RequisitionID WHERE " + ApplyStringList[ i ] + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";
					sql = sql + oneofsql;
					if( i != ApplyStringList.Count() - 1 )
					{
						sql = sql + " UNION ALL ";
					}

				}

			}



			List<object> SQLParameterList = new List<object>()
			{
				GetProcessingInfoParameter.ApplicantID,
				GetProcessingInfoParameter.ApplyString,
			};


			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetParkingProcessingInfo( GetParkingProcessingInfo GetParkingProcessingInfoParameter )
		{
			string sql = $@"Select *
							FROM(SELECT ROW_NUMBER() Over ( Order by [ApplicationDate]) AS 'Row_num',[EmpID],[ApplicationDate],[ApplicationType]
							  FROM [SyntecGAS].[dbo].[ParkingSpaceApplicationsMaster]
							  WHERE [Finished]='0') AS A
							  WHERE A.EmpID = @Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetParkingProcessingInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetMeetingRoomProcessingInfo( GetMeetingRoomProcessingInfo GetMeetingRoomProcessingInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[MRBS]
							WHERE [EmpID]=@Parameter0 and  [PreserveTimeEnd] between getdate()  and   DATEADD(MONTH, 3, GETDATE())
							ORDER BY [PreserveTimeStart]";

			List<object> SQLParameterList = new List<object>()
			{
				GetMeetingRoomProcessingInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetGuestVisitProcessingInfo( GetGuestVisitProcessingInfo GetGuestVisitProcessingInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_bpm}].[dbo].[FM7T_GAS_GuestReception_M]
							WHERE ([VisitDate] + cast([VisitEndTime] as datetime))　> getdate() and [ApplicantID]=@Parameter0
							ORDER BY ([VisitDate] + cast([VisitEndTime] as datetime))";

			List<object> SQLParameterList = new List<object>()
			{
				GetGuestVisitProcessingInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetMealOrderInfo( GetMealOrderInfo GetMealOrderInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_bpm}].[dbo].[FM7T_GAS_MealOrder_M]
							WHERE [txt_ApplyDate] >=convert(varchar, getdate(), 23)  and [ApplicantID]=@Parameter0
							Order By [txt_ApplyDate]";

			List<object> SQLParameterList = new List<object>()
			{
				GetMealOrderInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetUniformApplyInfo( GetUniformApplyInfo GetUniformApplyInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[GAS_UniformApplicationsMaster]
							WHERE [isDone]=0  and [EmpID]=@Parameter0
							Order By [ApplicationDate]";

			List<object> SQLParameterList = new List<object>()
			{
				GetUniformApplyInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal DataTable GetCarBookingInfo( GetCarBookingInfo GetCarBookingInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[CarBookingRecord]
						WHERE [ActualStartTime] is NULL and (GETDATE() between [PreserveStartTime] and [PreserveEndTime] or GETDATE() < [PreserveStartTime]) and [EmpID]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarBookingInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetDormInfo( GetDormInfo GetDormInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[DormApplicationsMaster]
							WHERE [Finished]=0 and [EmpID]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetDormInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetGASLicenseInfo( GetGASLicenseInfo GetGASLicenseInfoParameter )
		{
			string sql = $@"SELECT [EmpID],[EmpName],[EmpDept],[ExtensionNum],[ManageRight],[MotorLicense],[MotorLicense_Syntec],[CarLicense],[CarLicense_Syntec],[Sex]
						  FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster]
						  WHERE [MotorLicense] like @Parameter0 or [CarLicense] like @Parameter0
						  group by [EmpID],[EmpName],[EmpDept],[ExtensionNum],[ManageRight],[MotorLicense],[MotorLicense_Syntec],[CarLicense],[CarLicense_Syntec],[Sex]";

			List<object> SQLParameterList = new List<object>()
			{
				GetGASLicenseInfoParameter.License

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if( result == null || result.Rows.Count <= 0 )
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

