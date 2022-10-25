using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.HealthManagement;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{

	internal class HealthManagementDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public HealthManagementDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal bool InsertHealthExaminationInfo( InsertHealthExaminationInfo InsertHealthExaminationInfoParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[HealthExaminationInfo]([Type],[Caption],[StartDate],[EndDate],[BannedDate])
							VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationInfoParameter.HealthExaminationInfoNo,
				InsertHealthExaminationInfoParameter.HealthExaminationInfoType,
				InsertHealthExaminationInfoParameter.HealthExaminationInfoCaption,
				InsertHealthExaminationInfoParameter.HealthExaminationInfoStartDate,
				InsertHealthExaminationInfoParameter.HealthExaminationInfoEndDate,
				InsertHealthExaminationInfoParameter.HealthExaminationInfoBannedDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationInfo( DeleteHealthExaminationInfo DeleteHealthExaminationInfoParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationInfo]
							where [Caption] like @Parameter2 or [No] = @Parameter0 or [Type] = @Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoNo,
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoType,
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoCaption,
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoStartDate,
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoEndDate,
				DeleteHealthExaminationInfoParameter.HealthExaminationInfoBannedDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationInfo( UpdateHealthExaminationInfo UpdateHealthExaminationInfoParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HealthExaminationInfo]
							set [Caption]=@Parameter2,[StartDate]=@Parameter3,[EndDate]=@Parameter4,[BannedDate]=@Parameter5
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoNo,
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoType,
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoCaption,
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoStartDate,
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoEndDate,
				UpdateHealthExaminationInfoParameter.HealthExaminationInfoBannedDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationInfo( GetHealthExaminationInfo GetHealthExaminationInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[HealthExaminationInfo]
							WHERE [Type] LIKE @Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationInfoParameter.HealthExaminationInfoNo,
				GetHealthExaminationInfoParameter.HealthExaminationInfoType,
				GetHealthExaminationInfoParameter.HealthExaminationInfoCaption,
				GetHealthExaminationInfoParameter.HealthExaminationInfoStartDate,
				GetHealthExaminationInfoParameter.HealthExaminationInfoEndDate,
				GetHealthExaminationInfoParameter.HealthExaminationInfoBannedDate
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


		internal bool InsertHealthExaminationProjects( InsertHealthExaminationProjects InsertHealthExaminationProjectsParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[HealthExaminationProjects]([Hospital],[Project],[Sex],[Price],[Memo])
							VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsNo,
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsHospital,
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsProject,
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsSex,
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsPrice,
				InsertHealthExaminationProjectsParameter.HealthExaminationProjectsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationProjects( DeleteHealthExaminationProjects DeleteHealthExaminationProjectsParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationProjects]
							where [No] = @Parameter0 or [Hospital] = @Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsNo,
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsHospital,
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsProject,
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsSex,
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsPrice,
				DeleteHealthExaminationProjectsParameter.HealthExaminationProjectsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationProjects( UpdateHealthExaminationProjects UpdateHealthExaminationProjectsParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HealthExaminationProjects]
							set [Project]=@Parameter2,[Sex]=@Parameter3,[Price]=@Parameter4,[Memo]=@Parameter5
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsNo,
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsHospital,
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsProject,
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsSex,
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsPrice,
				UpdateHealthExaminationProjectsParameter.HealthExaminationProjectsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationProjects( GetHealthExaminationProjects GetHealthExaminationProjectsParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[HealthExaminationProjects]
							WHERE [No] LIKE @Parameter0 or [Hospital] LIKE @Parameter1
							Order by [No] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsNo,
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsHospital,
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsProject,
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsSex,
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsPrice,
				GetHealthExaminationProjectsParameter.HealthExaminationProjectsMemo
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

		internal bool InsertHealthExaminationItems( InsertHealthExaminationItems InsertHealthExaminationItemsParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[HealthExaminationItems]([Hospital],[Item],[Price],[Memo])
							VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationItemsParameter.HealthExaminationItemsNo,
				InsertHealthExaminationItemsParameter.HealthExaminationItemsHospital,
				InsertHealthExaminationItemsParameter.HealthExaminationItemsItem,
				InsertHealthExaminationItemsParameter.HealthExaminationItemsPrice,
				InsertHealthExaminationItemsParameter.HealthExaminationItemsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationItems( DeleteHealthExaminationItems DeleteHealthExaminationItemsParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationItems]
							where [No] = @Parameter0 or [Hospital] = @Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationItemsParameter.HealthExaminationItemsNo,
				DeleteHealthExaminationItemsParameter.HealthExaminationItemsHospital,
				DeleteHealthExaminationItemsParameter.HealthExaminationItemsItem,
				DeleteHealthExaminationItemsParameter.HealthExaminationItemsPrice,
				DeleteHealthExaminationItemsParameter.HealthExaminationItemsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationItems( UpdateHealthExaminationItems UpdateHealthExaminationItemsParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HealthExaminationItems]
							set [Item]=@Parameter2,[Price]=@Parameter3,[Memo]=@Parameter4
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationItemsParameter.HealthExaminationItemsNo,
				UpdateHealthExaminationItemsParameter.HealthExaminationItemsHospital,
				UpdateHealthExaminationItemsParameter.HealthExaminationItemsItem,
				UpdateHealthExaminationItemsParameter.HealthExaminationItemsPrice,
				UpdateHealthExaminationItemsParameter.HealthExaminationItemsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationItems( GetHealthExaminationItems GetHealthExaminationItemsParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[HealthExaminationItems]
							WHERE [No] LIKE @Parameter0 or [Hospital] LIKE @Parameter1
							Order by [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationItemsParameter.HealthExaminationItemsNo,
				GetHealthExaminationItemsParameter.HealthExaminationItemsHospital,
				GetHealthExaminationItemsParameter.HealthExaminationItemsItem,
				GetHealthExaminationItemsParameter.HealthExaminationItemsPrice,
				GetHealthExaminationItemsParameter.HealthExaminationItemsMemo
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

		internal bool InsertHealthExaminationOptions( InsertHealthExaminationOptions InsertHealthExaminationOptionsParameter )
		{


			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[HealthExaminationOptions]([ProjectNo],[ItemNo],[OptionType],[OptionalNum],[Memo])
							SELECT HospitalProjects.ProjectNo,HospitalProjects.ItemNo,@Parameter3 as 'OptionType',@Parameter4 as 'OptionalNum',@Parameter5 as 'Memo'
							FROM (SELECT Projects.[No] as 'ProjectNo',Items.[No] as 'ItemNo'
									FROM [SyntecGAS].[dbo].[HealthExaminationProjects] as Projects
									inner join [SyntecGAS].[dbo].[HealthExaminationItems] as Items
									on Projects.Hospital = Items.Hospital) as HospitalProjects
									inner join (SELECT max([No]) as 'NewItemNo' FROM [SyntecGAS].[dbo].[HealthExaminationItems] where [Hospital] = @Parameter7) as NewItem
									on NewItem.NewItemNo=HospitalProjects.ItemNo";

			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsNo,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsProjectNo,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsItemNo,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsOptionType,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsOptionalNum,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsMemo,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsState,
				InsertHealthExaminationOptionsParameter.HealthExaminationOptionsHospitalNo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationOptions( DeleteHealthExaminationOptions DeleteHealthExaminationOptionsParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationOptions]
							where [No] = @Parameter0 or [ProjectNo] = @Parameter1 or [ItemNo] = @Parameter2";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsNo,
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsProjectNo,
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsItemNo,
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsOptionType,
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsOptionalNum,
				DeleteHealthExaminationOptionsParameter.HealthExaminationOptionsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationOptions( UpdateHealthExaminationOptions UpdateHealthExaminationOptionsParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HealthExaminationOptions]
							set [OptionType]=@Parameter3,[OptionalNum]=@Parameter4
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsNo,
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsProjectNo,
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsItemNo,
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsOptionType,
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsOptionalNum,
				UpdateHealthExaminationOptionsParameter.HealthExaminationOptionsMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationOptions( GetHealthExaminationOptions GetHealthExaminationOptionsParameter )
		{
			string sql = $@"SELECT Options.[No]
									,[ProjectNo]
									,Items.[No] as 'ItemNo'
									,Items.[Item] as 'ItemName'
									,[OptionType]
									,[OptionalNum]
									,Items.[Memo],Items.[Price]
							FROM [SyntecGAS].[dbo].[HealthExaminationOptions] as Options
							right join [SyntecGAS].[dbo].[HealthExaminationItems] as Items
							on Options.[ItemNo] = Items.No
							WHERE (Options.[ProjectNo] LIKE @Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsNo,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsProjectNo,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsItemNo,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsOptionType,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsOptionalNum,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsMemo,
				GetHealthExaminationOptionsParameter.HealthExaminationOptionsHospitalNo
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

		internal DataTable GetHealthExaminationEmpInfo( GetHealthExaminationEmpInfo GetHealthExaminationEmpInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[HealthExaminationEmpInfo]
							WHERE [EmpID] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoEmpID,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoJobStartDate,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoTenure,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoAge,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoIsZeroingYear,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoNecessaryYear,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoIsNecessaryYear,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoBalance,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoIsLeave,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoMemo,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoIsQualified,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoNextSubsidy,
				GetHealthExaminationEmpInfoParameter.HealthExaminationEmpInfoSkipCount
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

		internal bool InsertHealthExaminationApplicationsMaster( InsertHealthExaminationApplicationsMaster InsertHealthExaminationApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[HealthExaminationApplicationsMaster]([FillerID],[FillerName],[ApplicationDate]) VALUES (@Parameter1,@Parameter2,@Parameter3)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterRequisitionID,
				InsertHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerID,
				InsertHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerName,
				InsertHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationApplicationsMaster( DeleteHealthExaminationApplicationsMaster DeleteHealthExaminationApplicationsMasterParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationApplicationsMaster] WHERE [RequisitionID] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterRequisitionID,
				DeleteHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerID,
				DeleteHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerName,
				DeleteHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationApplicationsMaster( UpdateHealthExaminationApplicationsMaster UpdateHealthExaminationApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HealthExaminationApplicationsMaster]
							set [FillerID]=@Parameter1,[FillerName]=@Parameter2,[ApplicationDate]=@Parameter3
							where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterRequisitionID,
				UpdateHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerID,
				UpdateHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerName,
				UpdateHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationApplicationsMaster( GetHealthExaminationApplicationsMaster GetHealthExaminationApplicationsMasterParameter )
		{
			string sql = $@"SELECT TOP (1) [RequisitionID],[FillerID],[FillerName],[ApplicationDate]
							FROM [SyntecGAS].[dbo].[HealthExaminationApplicationsMaster]
							order by [RequisitionID] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterRequisitionID,
				GetHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerID,
				GetHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterFillerName,
				GetHealthExaminationApplicationsMasterParameter.HealthExaminationApplicationsMasterApplicationDate
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

		internal bool InsertHealthExaminationApplicationsDetail( InsertHealthExaminationApplicationsDetail InsertHealthExaminationApplicationsDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[HealthExaminationApplicationsDetail]([RequisitionID],[ApplicantID],[ApplicantName],[Type],[Name],[ID],[Birthday],[PhoneNumber],[Sex],[Hospital],[ProjectNo],[OptionalItems],[AdditionItems],[AppointmentDate1],[AppointmentDate2],[Total]) VALUES (@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11,@Parameter12,@Parameter13,@Parameter14,@Parameter15,@Parameter16)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailDetailID,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailRequisitionID,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantID,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantName,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailType,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailName,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailID,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailBirthday,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailPhoneNumber,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailSex,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailHospital,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailProjectNo,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailOptionalItems,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAdditionItems,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate1,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate2,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailTotal,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailIsCancel,
				InsertHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHealthExaminationApplicationsDetail( DeleteHealthExaminationApplicationsDetail DeleteHealthExaminationApplicationsDetailParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HealthExaminationApplicationsDetail] WHERE [RequisitionID]=@Parameter1 or [DetailID] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailDetailID,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailRequisitionID,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantID,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantName,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailType,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailName,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailID,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailBirthday,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailPhoneNumber,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailSex,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailHospital,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailProjectNo,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailOptionalItems,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAdditionItems,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate1,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate2,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailTotal,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailIsCancel,
				DeleteHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHealthExaminationApplicationsDetail( UpdateHealthExaminationApplicationsDetail UpdateHealthExaminationApplicationsDetailParameter )
		{
			
			string sql = $@"IF @Parameter18 = 0	
								UPDATE [{m_gas}].[dbo].[HealthExaminationApplicationsDetail]
								set [AppointmentDate1] = @Parameter14,[AppointmentDate2] = @Parameter15
								where [ID] = @Parameter6
							ELSE
								UPDATE [{m_gas}].[dbo].[HealthExaminationApplicationsDetail]
								set [IsCancel]=@Parameter17,[Finished]=@Parameter18,[CancelDateTime]=@Parameter19
								where [DetailID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailDetailID,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailRequisitionID,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantID,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantName,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailType,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailName,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailID,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailBirthday,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailPhoneNumber,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailSex,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailHospital,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailProjectNo,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailOptionalItems,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAdditionItems,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate1,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate2,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailTotal,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailIsCancel,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailFinished,
				UpdateHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailCancelDateTime,
				
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetHealthExaminationApplicationsDetail( GetHealthExaminationApplicationsDetail GetHealthExaminationApplicationsDetailParameter )
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[HealthExaminationApplicationsDetail]
							WHERE (Finished=0 AND IsCancel=0) and ([ApplicantID] = @Parameter2 or [RequisitionID]=@Parameter1 or [DetailID] = @Parameter0 or [ID] = @Parameter6)";
			List<object> SQLParameterList = new List<object>()
			{
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailDetailID,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailRequisitionID,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantID,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailApplicantName,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailType,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailName,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailID,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailBirthday,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailPhoneNumber,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailSex,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailHospital,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailProjectNo,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailOptionalItems,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAdditionItems,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate1,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailAppointmentDate2,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailTotal,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailIsCancel,
				GetHealthExaminationApplicationsDetailParameter.HealthExaminationApplicationsDetailFinished
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





	}
	#endregion Internal Methods
}

