using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyUniformDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplyUniformDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal bool InsertUniformStyle( InsertUniformStyle InsertUniformStyleParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[UniformStyleInfo] ([Style], [Price], [ApplyQuantity])
								VALUES (@Parameter1, @Parameter2, @Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformStyleParameter.UniformStyleNo,
				InsertUniformStyleParameter.UniformStyleName,
				InsertUniformStyleParameter.UniformStylePrice,
				InsertUniformStyleParameter.UniformStyleApplyQuantity
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteUniformStyle( DeleteUniformStyle DeleteUniformStyleParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[UniformStyleInfo]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteUniformStyleParameter.UniformStyleNo,
				DeleteUniformStyleParameter.UniformStyleName,
				DeleteUniformStyleParameter.UniformStylePrice,
				DeleteUniformStyleParameter.UniformStyleApplyQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateUniformStyleInfo( UpdateUniformStyleInfo UpdateUniformStyleInfoParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[UniformStyleInfo]
							set [Style]=@Parameter1, [Price]=@Parameter2, [ApplyQuantity]=@Parameter3
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateUniformStyleInfoParameter.UniformStyleNo,
				UpdateUniformStyleInfoParameter.UniformStyleName,
				UpdateUniformStyleInfoParameter.UniformStylePrice,
				UpdateUniformStyleInfoParameter.UniformStyleApplyQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetUniformStyleInfo( GetUniformStyleInfo GetUniformStyleInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[UniformStyleInfo]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformStyleInfoParameter.UniformStyleNo,
				GetUniformStyleInfoParameter.UniformStyleName,
				GetUniformStyleInfoParameter.UniformStylePrice,
				GetUniformStyleInfoParameter.UniformStyleApplyQuantity
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal DataTable GetUniformStyleInfoSZ( GetUniformStyleInfoSZ GetUniformStyleInfoSZParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[UniformStyleInfo_SZ]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformStyleInfoSZParameter.UniformStyleNo,
				GetUniformStyleInfoSZParameter.UniformStyleName,
				GetUniformStyleInfoSZParameter.UniformStylePrice,
				GetUniformStyleInfoSZParameter.UniformStyleApplyQuantity
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

		internal bool UpsertUniformQuantityInfo( UpsertUniformQuantityInfo UpsertUniformQuantityInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[UniformQuantityInfo] WHERE [Size]=@Parameter0 and [Style]=@Parameter1)
									UPDATE [{m_gas}].[dbo].[UniformQuantityInfo] SET [Size]=@Parameter0, [Style]=@Parameter1,[Quantity]=@Parameter2,[AlertQuantity]=@Parameter3
									WHERE [Size]=@Parameter0 and [Style]=@Parameter1
									ELSE
									INSERT INTO [{m_gas}].[dbo].[UniformQuantityInfo] ([Size], [Style], [Quantity], [AlertQuantity])
									VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertUniformQuantityInfoParameter.UniformStyleSize,
				UpsertUniformQuantityInfoParameter.UniformStyleNo,
				UpsertUniformQuantityInfoParameter.UniformQuantity,
				UpsertUniformQuantityInfoParameter.UniformAlertQuantity
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteUniformQuantity( DeleteUniformQuantity DeleteUniformQuantityParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[UniformQuantityInfo]
								where [Size]=@Parameter0 and [Style]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteUniformQuantityParameter.UniformStyleSize,
				DeleteUniformQuantityParameter.UniformStyleNo,
				DeleteUniformQuantityParameter.UniformQuantity,
				DeleteUniformQuantityParameter.UniformAlertQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetUniformQuantityInfo( GetUniformQuantityInfo GetUniformQuantityInfoParameter )
		{
			string sql = $@"SELECT [UniformStyleInfo].[Style] as 'StyleName',[UniformQuantityInfo].[AlertQuantity], [UniformStyleInfo].[No] as 'Style',[UniformQuantityInfo].[Size],[UniformQuantityInfo].[Quantity]
									FROM[{m_gas}].[dbo].[UniformStyleInfo]
									INNER JOIN[{m_gas}].[dbo].[UniformQuantityInfo]
									ON[UniformStyleInfo].[No] =[UniformQuantityInfo].[Style]
									WHERE[No] like @Parameter1
									ORDER BY[No],case 
	when [No]<>'2' and [No]<>'3' then
		case 
         when [Size]='XS' then 1 
         when [Size]='S' then 2 
         when [Size]='M' then 3
		 when [Size]='L' then 4 
         when [Size]='XL' then 5 
         when [Size]='2L' then 6
		 when [Size]='3L' then 7
        end
	when [No]='2' or [No]='3' then
		case 
         when [Size]='46M' then 1          
        end
	end";

			List<object> SQLParameterList = new List<object>()
			{
				GetUniformQuantityInfoParameter.UniformStyleSize,
				GetUniformQuantityInfoParameter.UniformStyleNo,
				GetUniformQuantityInfoParameter.UniformQuantity,
				GetUniformQuantityInfoParameter.UniformAlertQuantity
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
		internal DataTable GetUniformQuantityInfoSZ( GetUniformQuantityInfoSZ GetUniformQuantityInfoSZParameter )
		{
			string sql = $@"SELECT [UniformStyleInfo_SZ].[Style] as 'StyleName',[UniformQuantityInfo_SZ].[AlertQuantity], [UniformStyleInfo_SZ].[No] as 'Style',[UniformQuantityInfo_SZ].[Size],[UniformQuantityInfo_SZ].[Quantity]
									FROM[{m_gas}].[dbo].[UniformStyleInfo_SZ]
									INNER JOIN[{m_gas}].[dbo].[UniformQuantityInfo_SZ]
									ON[UniformStyleInfo_SZ].[No] =[UniformQuantityInfo_SZ].[Style]
									WHERE[No] like @Parameter1
									ORDER BY[No],case 
							when [No]<>'2' and [No]<>'3' then
								case 
								 when [Size]='XS' then 1 
								 when [Size]='S' then 2 
								 when [Size]='M' then 3
								 when [Size]='L' then 4 
								 when [Size]='XL' then 5 
								 when [Size]='2L' then 6
								 when [Size]='3L' then 7
								end
							when [No]='2' or [No]='3' then
								case 
								 when [Size]='46M' then 1          
								end
							end";

			List<object> SQLParameterList = new List<object>()
			{
				GetUniformQuantityInfoSZParameter.UniformStyleSize,
				GetUniformQuantityInfoSZParameter.UniformStyleNo,
				GetUniformQuantityInfoSZParameter.UniformQuantity,
				GetUniformQuantityInfoSZParameter.UniformAlertQuantity
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


		internal bool InsertUniformOrderListDetail( InsertUniformOrderListDetail InsertUniformOrderListDetailParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[UniformOrderListDetail] ([OrderList],[Style],[Size],[Price],[Quantity])
								VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformOrderListDetailParameter.UniformOrderListNo,
				InsertUniformOrderListDetailParameter.UniformStyleNo,
				InsertUniformOrderListDetailParameter.UniformStyleSize,
				InsertUniformOrderListDetailParameter.UniformOrderPrice,
				InsertUniformOrderListDetailParameter.UniformQuantity
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetUniformOrderList( GetUniformOrderList GetUniformOrderListParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[UniformOrderList]
						WHERE [No] LIKE @Parameter0 and [Ok]=0
						ORDER BY [OrderDate] DESC,[No] Desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformOrderListParameter.UniformOrderListNo,
				GetUniformOrderListParameter.UniformOrderDate,
				GetUniformOrderListParameter.UniformOk
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
		internal DataTable GetUniformOrderListDetail( GetUniformOrderListDetail GetUniformOrderListDetailParameter )
		{
			string sql = $@"SELECT *
							  FROM [{m_gas}].[dbo].[UniformOrderListDetail]
							  INNER JOIN (SELECT [UniformStyleInfo].[Style] as 'StyleName',[UniformQuantityInfo].[AlertQuantity], [UniformStyleInfo].[No],[UniformQuantityInfo].[Size],[UniformQuantityInfo].[Quantity] as 'QuantitySoFar'
															  FROM[{m_gas}].[dbo].[UniformStyleInfo]
															  INNER JOIN[{m_gas}].[dbo].[UniformQuantityInfo]
															  ON[UniformStyleInfo].[No] =[UniformQuantityInfo].[Style]) as UniformInfo
							  ON[UniformOrderListDetail].[Style] = UniformInfo.[No] and [UniformOrderListDetail].[Size]=UniformInfo.[Size]
ORDER BY UniformInfo.[No],case 
	when UniformInfo.[No]<>'2' and UniformInfo.[No]<>'3' then
		case 
         when [UniformOrderListDetail].[Size]='XS' then 1 
         when [UniformOrderListDetail].[Size]='S' then 2 
         when [UniformOrderListDetail].[Size]='M' then 3
		 when [UniformOrderListDetail].[Size]='L' then 4 
         when [UniformOrderListDetail].[Size]='XL' then 5 
         when [UniformOrderListDetail].[Size]='2L' then 6
		 when [UniformOrderListDetail].[Size]='3L' then 7
        end
	when UniformInfo.[No]='2' or UniformInfo.[No]='3' then
		case 
         when [UniformOrderListDetail].[Size]='46M' then 1          
        end
	end";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformOrderListDetailParameter.UniformOrderListNo,
				GetUniformOrderListDetailParameter.UniformStyleNo,
				GetUniformOrderListDetailParameter.UniformStyleSize,
				GetUniformOrderListDetailParameter.UniformOrderPrice,
				GetUniformOrderListDetailParameter.UniformQuantity
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

		internal bool InsertUniformOrder( InsertUniformOrder InsertUniformOrderParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[UniformOrderList] ([OrderDate])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformOrderParameter.UniformOrderListNo,
				InsertUniformOrderParameter.UniformOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteUniformOrder( DeleteUniformOrder DeleteUniformOrderParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[UniformOrderListDetail] WHERE [OrderList]=@Parameter0;
								   DELETE [{m_gas}].[dbo].[UniformOrderList] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteUniformOrderParameter.UniformOrderListNo,
				DeleteUniformOrderParameter.UniformOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateUniformOrder( UpdateUniformOrder UpdateUniformOrderParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[UniformOrderList]
							set [Ok]=@Parameter2
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateUniformOrderParameter.UniformOrderListNo,
				UpdateUniformOrderParameter.UniformOrderDate,
				UpdateUniformOrderParameter.UniformOk

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool InsertUniformApplicationsMaster( InsertUniformApplicationsMaster InsertUniformApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[UniformApplicationsMaster] ([FillerID],[FillerName],[ApplicationDate],[ApplicantID],[ApplicantName],[ApplicantDept],[ClothesType],[ApplyType],[ApplyQuantity],[Size],[Price],[Memo])
								VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter8, @Parameter9, @Parameter10, @Parameter11, @Parameter12, @Parameter13)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterRequisitionID,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterFillerID,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterFillerName,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplicationDate,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantID,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantName,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantDept,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterIsCancel,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterClothesType,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplyType,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterApplyQuantity,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterSize,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterPrice,
				InsertUniformApplicationsMasterParameter.UniformApplicationsMasterMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteUniformApplicationsMaster( DeleteUniformApplicationsMaster DeleteUniformApplicationsMasterParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[UniformApplicationsMaster]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterRequisitionID,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterFillerID,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterFillerName,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplicationDate,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantID,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantName,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantDept,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterIsCancel,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterClothesType,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplyType,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterApplyQuantity,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterSize,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterPrice,
				DeleteUniformApplicationsMasterParameter.UniformApplicationsMasterMemo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateUniformApplicationsMaster( UpdateUniformApplicationsMaster UpdateUniformApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[UniformApplicationsMaster]
							set [Finished]=@Parameter14,[IsCancel]=@Parameter7,[CancelDateTime]=@Parameter15,[FinishedDateTime]=@Parameter16
							where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterRequisitionID,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterFillerID,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterFillerName,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplicationDate,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantID,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantName,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantDept,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterIsCancel,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterClothesType,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplyType,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterApplyQuantity,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterSize,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterPrice,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterMemo,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterFinished,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterCancelDateTime,
				UpdateUniformApplicationsMasterParameter.UniformApplicationsMasterFinishedDateTime

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetUniformApplicationsMaster( GetUniformApplicationsMaster GetUniformApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[UniformApplicationsMaster]
						Where Convert(varchar,ApplicationDate,120) like @Parameter3 and [ApplicantID] like @Parameter4 and [ClothesType] like @Parameter8 and [ApplyType] like @Parameter9 and [Finished]=@Parameter14 and [IsCancel]=0
						ORDER BY [RequisitionID] desc";
			List<object> SQLParameterList = new List<object>()
			{

				GetUniformApplicationsMasterParameter.UniformApplicationsMasterRequisitionID,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterFillerID,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterFillerName,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplicationDate,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantID,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantName,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplicantDept,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterIsCancel,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterClothesType,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplyType,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterApplyQuantity,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterSize,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterPrice,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterMemo,
				GetUniformApplicationsMasterParameter.UniformApplicationsMasterFinished
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

		internal bool UpdateCoatApplication( UpdateCoatApplication UpdateCoatApplicationParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[CoatApplication]
							set ["+ UpdateCoatApplicationParameter.CoatApplicationYear + "]=@Parameter2 where [EmpID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCoatApplicationParameter.CoatApplicationEmpID,
				UpdateCoatApplicationParameter.CoatApplicationYear,
				UpdateCoatApplicationParameter.CoatApplicationSize
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpdateGAS_GAInfoMasterSize( UpdateGAS_GAInfoMasterSize UpdateGAS_GAInfoMasterSizeParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[GAS_GAInfoMaster]
							set [" + UpdateGAS_GAInfoMasterSizeParameter.GAS_GAInfoMasterSizeType + "]=@Parameter1 where [EmpID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateGAS_GAInfoMasterSizeParameter.GAS_GAInfoMasterEmpID,
				UpdateGAS_GAInfoMasterSizeParameter.GAS_GAInfoMasterUniformSize,
				UpdateGAS_GAInfoMasterSizeParameter.GAS_GAInfoMasterSizeType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}



	}
	#endregion Internal Methods
}
