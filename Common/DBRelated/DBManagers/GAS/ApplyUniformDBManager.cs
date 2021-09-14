using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyUniformDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertUniformStyle( InsertUniformStyle InsertUniformStyleParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[UniformStyleInfo] ([Style], [Price], [ApplyQuantity])
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
			string sql = $@"DELETE [SyntecGAS].[dbo].[UniformStyleInfo]
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
			string sql = $@"UPDATE [SyntecGAS].[dbo].[UniformStyleInfo]
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
						FROM [SyntecGAS].[dbo].[UniformStyleInfo]
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

		internal bool UpsertUniformQuantityInfo( UpsertUniformQuantityInfo UpsertUniformQuantityInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[UniformQuantityInfo] WHERE [Size]=@Parameter0 and [Style]=@Parameter1)
									UPDATE [SyntecGAS].[dbo].[UniformQuantityInfo] SET [Size]=@Parameter0, [Style]=@Parameter1,[Quantity]=@Parameter2,[AlertQuantity]=@Parameter3
									WHERE [Size]=@Parameter0 and [Style]=@Parameter1
									ELSE
									INSERT INTO [SyntecGAS].[dbo].[UniformQuantityInfo] ([Size], [Style], [Quantity], [AlertQuantity])
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
			string sql = $@"DELETE [SyntecGAS].[dbo].[UniformQuantityInfo]
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
									FROM[SyntecGAS].[dbo].[UniformStyleInfo]
									INNER JOIN[SyntecGAS].[dbo].[UniformQuantityInfo]
									ON[UniformStyleInfo].[No] =[UniformQuantityInfo].[Style]
									WHERE[No] like @Parameter1
									ORDER BY[No],[Size]";

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

		internal bool InsertUniformOrder( InsertUniformOrder InsertUniformOrderParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[UniformOrderList] ([OrderDate])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformOrderParameter.UniformOrderListNo,
				InsertUniformOrderParameter.UniformOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertUniformOrderListDetail( InsertUniformOrderListDetail InsertUniformOrderListDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[UniformOrderListDetail] ([OrderList],[Style],[Size],[Price],[Quantity])
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
						FROM [SyntecGAS].[dbo].[UniformOrderList]
						WHERE [No] LIKE @Parameter0 and [Ok]=0
						ORDER BY [OrderDate] DESC";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformOrderListParameter.UniformOrderListNo,
				GetUniformOrderListParameter.UniformOrderDate,
				GetUniformOrderListParameter.UniformOk
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
		internal DataTable GetUniformOrderListDetail( GetUniformOrderListDetail GetUniformOrderListDetailParameter )
		{
			string sql = $@"SELECT *
							  FROM [SyntecGAS].[dbo].[UniformOrderListDetail]
							  INNER JOIN (SELECT [UniformStyleInfo].[Style] as 'StyleName',[UniformQuantityInfo].[AlertQuantity], [UniformStyleInfo].[No],[UniformQuantityInfo].[Size],[UniformQuantityInfo].[Quantity] as 'QuantitySoFar'
															  FROM[SyntecGAS].[dbo].[UniformStyleInfo]
															  INNER JOIN[SyntecGAS].[dbo].[UniformQuantityInfo]
															  ON[UniformStyleInfo].[No] =[UniformQuantityInfo].[Style]) as UniformInfo
							  ON[UniformOrderListDetail].[Style] = UniformInfo.[No] and [UniformOrderListDetail].[Size]=UniformInfo.[Size]";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformOrderListDetailParameter.UniformOrderListNo,
				GetUniformOrderListDetailParameter.UniformStyleNo,
				GetUniformOrderListDetailParameter.UniformStyleSize,
				GetUniformOrderListDetailParameter.UniformOrderPrice,
				GetUniformOrderListDetailParameter.UniformQuantity
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
		internal bool DeleteUniformOrder( DeleteUniformOrder DeleteUniformOrderParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[UniformOrderListDetail] WHERE [OrderList]=@Parameter0;
								   DELETE [SyntecGAS].[dbo].[UniformOrderList] WHERE [No]=@Parameter0";
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
			string sql = $@"UPDATE [SyntecGAS].[dbo].[UniformOrderList]
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

	}
	#endregion Internal Methods
}
