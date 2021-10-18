﻿using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.PersonalInfo;
using System.Linq;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicPersonalInfoDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetPersonalInfo( GetPersonalInfo GetPersonalInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [syntecbarcode].[dbo].[TEMP_NAME]
						  WHERE [EmpID]=@Parameter0 OR [EmpName]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetPersonalInfoParameter.EmpID

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

		internal DataTable GetFuzzyPersonalInfo( GetFuzzyPersonalInfo GetFuzzyPersonalInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [syntecbarcode].[dbo].[TEMP_NAME]
						  WHERE ([EmpID] like @Parameter0 OR [EmpName] like @Parameter0) AND [QuitDate] is NULL  ";

			List<object> SQLParameterList = new List<object>()
			{
			  '%'+GetFuzzyPersonalInfoParameter.EmpID + '%'

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

		internal DataTable GetPersonalInfoByNameOrg( GetPersonalInfoByNameOrg GetPersonalInfoByNameOrgParameter )
		{
			string sql = $@"SELECT *
						  FROM [syntecbarcode].[dbo].[TEMP_NAME]
						  WHERE [EmpName] = @Parameter0 AND [DeptName] = @Parameter1 ";

			List<object> SQLParameterList = new List<object>()
			{
			  GetPersonalInfoByNameOrgParameter.EmpName,
			  GetPersonalInfoByNameOrgParameter.DeptName


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

		internal DataTable GetPersonalGASInfo( GetPersonalGASInfo GetPersonalGASInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster]
						  WHERE [EmpID]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetPersonalGASInfoParameter.EmpID

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

		internal bool UpsertPersonalGASInfo( UpsertPersonalGASInfo UpsertPersonalGASInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[GAS_GAInfoMaster] 
							SET [ExtensionNum]=@Parameter1, [DoorCardNum]=@Parameter2,[MotorLicense]=@Parameter3,[CarLicense]=@Parameter4,[CarLicense_Syntec]=@Parameter5,[DoorCardNum2]=@Parameter6
							WHERE [EmpID]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[GAS_GAInfoMaster] ([EmpID],[ExtensionNum],[DoorCardNum],[MotorLicense],[CarLicense],[CarLicense_Syntec],[DoorCardNum2]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6)
						
						";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertPersonalGASInfoParameter.EmpID,
				UpsertPersonalGASInfoParameter.ExtensionNum,
				UpsertPersonalGASInfoParameter.DoorCardNum,
				UpsertPersonalGASInfoParameter.MotorLicense,
				UpsertPersonalGASInfoParameter.CarLicense,
				UpsertPersonalGASInfoParameter.CarLicense_Syntec,
				UpsertPersonalGASInfoParameter.DoorCardNum2

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetProcessingInfo( GetProcessingInfo GetProcessingInfoParameter )
		{

			//string sql = $@"SELECT " + GetProcessingInfoParameter.ApplyString + ".ApplicantID, " + GetProcessingInfoParameter.ApplyString + ".DiagramID, " + GetProcessingInfoParameter.ApplyString + ".ApplicantDateTime FROM  [BPMPro_QAS].[dbo]." + GetProcessingInfoParameter.ApplyString + "  LEFT JOIN [BPMPro_QAS].[dbo].[FSe7en_Sys_Requisition] ON " + GetProcessingInfoParameter.ApplyString + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID WHERE " + GetProcessingInfoParameter.ApplyString + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";

			string sql = "";
			string[] ApplyStringList = (GetProcessingInfoParameter.ApplyString).Split( "," );


			if(ApplyStringList.Count() == 1)
			{
				sql = $@"SELECT " + ApplyStringList[0] + ".ApplicantID, " + ApplyStringList[0] + ".DiagramID, " + ApplyStringList[0] + ".ApplicantDateTime, [FSe7en_Tep_FormHeader].value   FROM ([BPMPro_QAS].[dbo]." + ApplyStringList[0] + " INNER JOIN [BPMPro_QAS].[dbo].[FSe7en_Sys_Requisition] ON " + ApplyStringList[0] + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID) INNER JOIN [BPMPro_QAS].[dbo].[FSe7en_Tep_FormHeader] ON [FSe7en_Sys_Requisition].RequisitionID=[FSe7en_Tep_FormHeader].RequisitionID WHERE " + ApplyStringList[0] + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";

			}
			else
			{
				for(int i = 0; i < ApplyStringList.Count(); i++)
				{

					string oneofsql = $@"SELECT " + ApplyStringList[i] + ".ApplicantID, " + ApplyStringList[i] + ".DiagramID, " + ApplyStringList[i] + ".ApplicantDateTime, [FSe7en_Tep_FormHeader].value   FROM [BPMPro_QAS].[dbo]." + ApplyStringList[i] + " INNER JOIN [BPMPro_QAS].[dbo].[FSe7en_Sys_Requisition] ON " + ApplyStringList[i] + ".RequisitionID = [FSe7en_Sys_Requisition].RequisitionID INNER JOIN [BPMPro_QAS].[dbo].[FSe7en_Tep_FormHeader] ON [FSe7en_Sys_Requisition].RequisitionID=[FSe7en_Tep_FormHeader].RequisitionID WHERE " + ApplyStringList[i] + ".ApplicantID=@Parameter0 AND [FSe7en_Sys_Requisition].Status='0'";
					sql = sql + oneofsql;
					if(i != ApplyStringList.Count() - 1) { sql = sql + " UNION ALL "; }

				}

			}



			List<object> SQLParameterList = new List<object>()
			{
				GetProcessingInfoParameter.ApplicantID,
				GetProcessingInfoParameter.ApplyString,
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
	}
	#endregion Internal Methods
}

