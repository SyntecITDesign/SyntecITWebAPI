using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.GuestGift;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class GuestGiftDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public GuestGiftDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal bool InsertGuestGiftType( InsertGuestGiftType InsertGuestGiftTypeParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[GuestGiftTypeInfo] ([Type])
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
			string sql = $@"DELETE [{m_gas}].[dbo].[GuestGiftQuantityInfo]
								where [Type]=@Parameter0
								DELETE [{m_gas}].[dbo].[GuestGiftTypeInfo]
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
			string sql = $@"UPDATE [{m_gas}].[dbo].[GuestGiftTypeInfo]
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
						FROM [{m_gas}].[dbo].[GuestGiftTypeInfo]
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
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[GuestGiftQuantityInfo] WHERE [Type]=@Parameter0 and [Items]=@Parameter1)
									UPDATE [{m_gas}].[dbo].[GuestGiftQuantityInfo] SET [Type]=@Parameter0, [Items]=@Parameter1,[Quantity]=@Parameter2,[AlertQuantity]=@Parameter3,[Unit]=@Parameter4
									WHERE [Type]=@Parameter0 and [Items]=@Parameter1 and [Unit]=@Parameter4
									ELSE
									INSERT INTO [{m_gas}].[dbo].[GuestGiftQuantityInfo] ([Type], [Items], [Quantity], [AlertQuantity], [Unit])
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
			string sql = $@"DELETE [{m_gas}].[dbo].[GuestGiftQuantityInfo]
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
									FROM [{m_gas}].[dbo].[GuestGiftQuantityInfo]
									INNER JOIN[{m_gas}].[dbo].[GuestGiftTypeInfo]
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

			if(result == null || result.Rows.Count <= 0)
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
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[GuestGiftOrderList] ([OrderDate],[Usage],[Memo],[Ok])
								VALUES (@Parameter1,@Parameter2,@Parameter3,0)";
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
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[GuestGiftOrderListDetail] ([OrderList],[Type],[Items],[Price],[Quantity],[Unit])
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
						FROM [{m_gas}].[dbo].[GuestGiftOrderList]
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
							  FROM [{m_gas}].[dbo].[GuestGiftOrderListDetail]
							  INNER JOIN (SELECT [GuestGiftTypeInfo].[Type] as 'TypeName',[GuestGiftQuantityInfo].[AlertQuantity], [GuestGiftTypeInfo].[No],[GuestGiftQuantityInfo].[Items],[GuestGiftQuantityInfo].[Quantity] as 'QuantitySoFar'
															  FROM[{m_gas}].[dbo].[GuestGiftTypeInfo]
															  INNER JOIN[{m_gas}].[dbo].[GuestGiftQuantityInfo]
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
			string sql = $@"DELETE [{m_gas}].[dbo].[GuestGiftOrderListDetail] WHERE [OrderList]=@Parameter0;
								   DELETE [{m_gas}].[dbo].[GuestGiftOrderList] WHERE [No]=@Parameter0";
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
			string sql = $@"UPDATE [{m_gas}].[dbo].[GuestGiftOrderList]
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


		internal bool InsertGuestReceptionApplicationsMaster( InsertGuestReceptionApplicationsMaster InsertGuestReceptionApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[GuestReceptionApplicationsMaster] ([FillerID] ,[FillerName] ,[ApplicationDate] ,[ApplicantID] ,[ApplicantName] ,[ApplicantDept] ,[ApplicantExt],[IntervieweeID],[IntervieweeDeptName],[Visitors],[VisitorsCompany],[VisitorsNum],[VisitStartDateTime],[VisitEndDateTime],[MeetingRoom],[NeedElectronicPoster],[NeedWater],[NeedCoffee],[NeedTea],[NeedFruit],[VeggieLunch],[MeatLunch],[ParkingCarName],[ParkingCarCounting],[NeedVideoPPT]
      ,[NeedCatalog]
      ,[SouvenirType]
      ,[SouvenirNum]
      ,[Memo])
						VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, @Parameter9, @Parameter10, @Parameter11, @Parameter12, @Parameter13, @Parameter14, @Parameter15, @Parameter16, @Parameter17, @Parameter18, @Parameter19, @Parameter20, @Parameter21, @Parameter22, @Parameter23, @Parameter24, @Parameter25, @Parameter26, @Parameter27, @Parameter28, @Parameter29, @Parameter30)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterRequisitionID,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerID,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerName,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicationDate,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantID,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantName,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantDept,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantExt,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIsCancel,
				
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeID,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeDeptName,		
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitors,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsCompany,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsNum,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitStartDateTime,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitEndDateTime,

				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeetingRoom,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedElectronicPoster,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedWater,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCoffee,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedTea,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedFruit,

				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVeggieLunch,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeatLunch,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarName,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarCounting,

				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedVideoPPT,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCatalog,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirType,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirNum,
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMemo,
				
				InsertGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		
		internal DataTable GetGuestReceptionApplicationsMaster( GetGuestReceptionApplicationsMaster GetGuestReceptionApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[GuestReceptionApplicationsMaster]
						Where [ApplicantID] like @Parameter4 and [Finished]=@Parameter30
						ORDER BY [RequisitionID] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterRequisitionID,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerID,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerName,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicationDate,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantID,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantName,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantDept,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantExt,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIsCancel,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeID,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeDeptName,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitors,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsCompany,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsNum,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitStartDateTime,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitEndDateTime,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeetingRoom,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedElectronicPoster,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedWater,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCoffee,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedTea,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedFruit,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVeggieLunch,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeatLunch,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarName,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarCounting,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedVideoPPT,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCatalog,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirType,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirNum,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMemo,
				GetGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFinished
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

		internal bool UpdateGuestReceptionApplicationsMaster( UpdateGuestReceptionApplicationsMaster UpdateGuestReceptionApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[GuestReceptionApplicationsMaster]
							set [Finished]=@Parameter30,[IsCancel]=@Parameter8
							where RequisitionID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterRequisitionID,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerID,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFillerName,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicationDate,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantID,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantName,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantDept,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterApplicantExt,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIsCancel,

				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeID,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterIntervieweeDeptName,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitors,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsCompany,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitorsNum,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitStartDateTime,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVisitEndDateTime,

				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeetingRoom,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedElectronicPoster,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedWater,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCoffee,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedTea,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedFruit,

				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterVeggieLunch,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMeatLunch,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarName,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterParkingCarCounting,

				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedVideoPPT,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterNeedCatalog,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirType,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterSouvenirNum,
				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterMemo,

				UpdateGuestReceptionApplicationsMasterParameter.GuestReceptionApplicationsMasterFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


	}
	#endregion Internal Methods
}
