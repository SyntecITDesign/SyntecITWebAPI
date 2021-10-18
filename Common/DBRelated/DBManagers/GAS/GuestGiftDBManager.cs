using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.GuestGift;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class GuestGiftDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertGuestGiftType( InsertGuestGiftType InsertGuestGiftTypeParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[GuestGiftTypeInfo] ([Type])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertGuestGiftTypeParameter.GuestGiftTypeInfoNo,
				InsertGuestGiftTypeParameter.GuestGiftTypeInfoName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteGuestGiftType( DeleteGuestGiftType DeleteGuestGiftTypeParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[GuestGiftQuantityInfo]
								where [Type]=@Parameter0
								DELETE [SyntecGAS].[dbo].[GuestGiftTypeInfo]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteGuestGiftTypeParameter.GuestGiftTypeInfoNo,
				DeleteGuestGiftTypeParameter.GuestGiftTypeInfoName

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateGuestGiftTypeInfo( UpdateGuestGiftTypeInfo UpdateGuestGiftTypeInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[GuestGiftTypeInfo]
							set [Type]=@Parameter1
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateGuestGiftTypeInfoParameter.GuestGiftTypeInfoNo,
				UpdateGuestGiftTypeInfoParameter.GuestGiftTypeInfoName

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetGuestGiftTypeInfo( GetGuestGiftTypeInfo GetGuestGiftTypeInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[GuestGiftTypeInfo]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetGuestGiftTypeInfoParameter.GuestGiftTypeInfoNo,
				GetGuestGiftTypeInfoParameter.GuestGiftTypeInfoName
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

		internal bool UpsertGuestGiftQuantityInfo( UpsertGuestGiftQuantityInfo UpsertGuestGiftQuantityInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[GuestGiftQuantityInfo] WHERE [Type]=@Parameter0 and [Items]=@Parameter1)
									UPDATE [SyntecGAS].[dbo].[GuestGiftQuantityInfo] SET [Type]=@Parameter0, [Items]=@Parameter1,[Quantity]=@Parameter2,[AlertQuantity]=@Parameter3,[Unit]=@Parameter4
									WHERE [Type]=@Parameter0 and [Items]=@Parameter1 and [Unit]=@Parameter4
									ELSE
									INSERT INTO [SyntecGAS].[dbo].[GuestGiftQuantityInfo] ([Type], [Items], [Quantity], [AlertQuantity], [Unit])
									VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertGuestGiftQuantityInfoParameter.GuestGiftTypeNo,
				UpsertGuestGiftQuantityInfoParameter.GuestGiftItems,
				UpsertGuestGiftQuantityInfoParameter.GuestGiftQuantity,
				UpsertGuestGiftQuantityInfoParameter.GuestGiftAlertQuantity,
				UpsertGuestGiftQuantityInfoParameter.GuestGiftUnit
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteGuestGiftQuantity( DeleteGuestGiftQuantity DeleteGuestGiftQuantityParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[GuestGiftQuantityInfo]
								where [Type]=@Parameter0 and [Items]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteGuestGiftQuantityParameter.GuestGiftTypeNo,
				DeleteGuestGiftQuantityParameter.GuestGiftItems,
				DeleteGuestGiftQuantityParameter.GuestGiftQuantity,
				DeleteGuestGiftQuantityParameter.GuestGiftAlertQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetGuestGiftQuantityInfo( GetGuestGiftQuantityInfo GetGuestGiftQuantityInfoParameter )
		{
			string sql = $@"SELECT [GuestGiftQuantityInfo].[Type],[GuestGiftQuantityInfo].[Items],[GuestGiftQuantityInfo].[Quantity],[GuestGiftQuantityInfo].[AlertQuantity],[GuestGiftQuantityInfo].[Unit],[GuestGiftTypeInfo].[Type] as 'TypeName'
									FROM [SyntecGAS].[dbo].[GuestGiftQuantityInfo]
									INNER JOIN[SyntecGAS].[dbo].[GuestGiftTypeInfo]
									ON[GuestGiftQuantityInfo].[Type] =[GuestGiftTypeInfo].[No]
									WHERE [GuestGiftQuantityInfo].[Type] like @Parameter0
									ORDER BY [Type],[Items]";
			List<object> SQLParameterList = new List<object>()
			{
				GetGuestGiftQuantityInfoParameter.GuestGiftTypeNo,
				GetGuestGiftQuantityInfoParameter.GuestGiftItems,
				GetGuestGiftQuantityInfoParameter.GuestGiftQuantity,
				GetGuestGiftQuantityInfoParameter.GuestGiftAlertQuantity
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

		internal bool InsertGuestGiftOrder( InsertGuestGiftOrder InsertGuestGiftOrderParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[GuestGiftOrderList] ([OrderDate],[Usage],[Memo])
								VALUES (@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertGuestGiftOrderParameter.GuestGiftOrderListNo,
				InsertGuestGiftOrderParameter.GuestGiftOrderDate,
				InsertGuestGiftOrderParameter.GuestGiftUsage,
				InsertGuestGiftOrderParameter.GuestGiftMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertGuestGiftOrderListDetail( InsertGuestGiftOrderListDetail InsertGuestGiftOrderListDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[GuestGiftOrderListDetail] ([OrderList],[Type],[Items],[Price],[Quantity],[Unit])
								VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertGuestGiftOrderListDetailParameter.GuestGiftOrderListNo,
				InsertGuestGiftOrderListDetailParameter.GuestGiftTypeNo,
				InsertGuestGiftOrderListDetailParameter.GuestGiftItems,
				InsertGuestGiftOrderListDetailParameter.GuestGiftOrderPrice,
				InsertGuestGiftOrderListDetailParameter.GuestGiftQuantity,
				InsertGuestGiftOrderListDetailParameter.GuestGiftUnit
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetGuestGiftOrderList( GetGuestGiftOrderList GetGuestGiftOrderListParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[GuestGiftOrderList]
						WHERE [No] LIKE @Parameter0 and [Ok]=0
						ORDER BY [OrderDate] DESC,[No] DESC";
			List<object> SQLParameterList = new List<object>()
			{
				GetGuestGiftOrderListParameter.GuestGiftOrderListNo,
				GetGuestGiftOrderListParameter.GuestGiftOrderDate,
				GetGuestGiftOrderListParameter.GuestGiftOk
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
		internal DataTable GetGuestGiftOrderListDetail( GetGuestGiftOrderListDetail GetGuestGiftOrderListDetailParameter )
		{
			string sql = $@"SELECT *
							  FROM [SyntecGAS].[dbo].[GuestGiftOrderListDetail]
							  INNER JOIN (SELECT [GuestGiftTypeInfo].[Type] as 'TypeName',[GuestGiftQuantityInfo].[AlertQuantity], [GuestGiftTypeInfo].[No],[GuestGiftQuantityInfo].[Items],[GuestGiftQuantityInfo].[Quantity] as 'QuantitySoFar'
															  FROM[SyntecGAS].[dbo].[GuestGiftTypeInfo]
															  INNER JOIN[SyntecGAS].[dbo].[GuestGiftQuantityInfo]
															  ON[GuestGiftTypeInfo].[No] =[GuestGiftQuantityInfo].[Type]) as GuestGiftInfo
							  ON[GuestGiftOrderListDetail].[Type] = GuestGiftInfo.[No] and [GuestGiftOrderListDetail].[Items]=GuestGiftInfo.[Items]";
			List<object> SQLParameterList = new List<object>()
			{
				GetGuestGiftOrderListDetailParameter.GuestGiftOrderListNo,
				GetGuestGiftOrderListDetailParameter.GuestGiftTypeNo,
				GetGuestGiftOrderListDetailParameter.GuestGiftItems,
				GetGuestGiftOrderListDetailParameter.GuestGiftOrderPrice,
				GetGuestGiftOrderListDetailParameter.GuestGiftQuantity
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
		internal bool DeleteGuestGiftOrder( DeleteGuestGiftOrder DeleteGuestGiftOrderParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[GuestGiftOrderListDetail] WHERE [OrderList]=@Parameter0;
								   DELETE [SyntecGAS].[dbo].[GuestGiftOrderList] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteGuestGiftOrderParameter.GuestGiftOrderListNo,
				DeleteGuestGiftOrderParameter.GuestGiftOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateGuestGiftOrder( UpdateGuestGiftOrder UpdateGuestGiftOrderParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[GuestGiftOrderList]
							set [Ok]=@Parameter2, [Memo]=@Parameter3
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateGuestGiftOrderParameter.GuestGiftOrderListNo,
				UpdateGuestGiftOrderParameter.GuestGiftOrderDate,
				UpdateGuestGiftOrderParameter.GuestGiftOk,
				UpdateGuestGiftOrderParameter.GuestGiftMemo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}
