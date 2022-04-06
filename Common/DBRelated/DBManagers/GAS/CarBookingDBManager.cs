using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.CarBooking;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class PublicCarBookingDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicCarBookingDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal DataTable GetCarInfo( )
		{
			string sql = $@"SELECT *
						  FROM [{m_gas}].[dbo].[CarInfo]
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

		internal DataTable GetSpecificCarInfo( GetSpecificCarInfo GetSpecificCarInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarInfo]
							WHERE [CarNumber]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetSpecificCarInfoParameter.CarNumber

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

		internal bool UpdateSpecificCarMileInfo( UpdateSpecificCarMileInfo UpdateSpecificCarMileInfoParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[CarInfo]
							SET [Mile]=@Parameter1
							WHERE [CarNumber]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				UpdateSpecificCarMileInfoParameter.CarNumber,
				UpdateSpecificCarMileInfoParameter.Mile

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertCarInfo( UpsertCarInfo UpsertCarInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[CarInfo] WHERE [id]=@Parameter0 )
							UPDATE [{m_gas}].[dbo].[CarInfo]
							SET [CarNumber]=@Parameter1, [Model]=@Parameter2,[Seats]=@Parameter3,[BuyYear]=@Parameter4,[Type]=@Parameter5,[Gas]=@Parameter6,[Engine]=@Parameter7,[Belongs]=@Parameter8,[CanRent]=@Parameter9,[Mile]=@Parameter10,[NextRepairMile]=@Parameter11
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarInfo] ([CarNumber],[Model],[Seats],[BuyYear],[Type],[Gas],[Engine],[Belongs],[CanRent],[Mile],[NextRepairMile]) 
						VALUES (@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarInfoParameter.CarID,
				UpsertCarInfoParameter.CarNumber,
				UpsertCarInfoParameter.Model,
				UpsertCarInfoParameter.Seats,
				UpsertCarInfoParameter.BuyYear,
				UpsertCarInfoParameter.Type,
				UpsertCarInfoParameter.Gas,
				UpsertCarInfoParameter.Engine,
				UpsertCarInfoParameter.Belongs,
				UpsertCarInfoParameter.CanRent,
				UpsertCarInfoParameter.Mile,
				UpsertCarInfoParameter.NextRepairMile

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarInfo( DelCarInfo DelCarInfoParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarInfo]
							WHERE [id]=@Parameter0
							DELETE FROM [{m_gas}].[dbo].[CarRepairFrequency]
							WHERE [id]=@Parameter0
								";

			List<object> SQLParameterList = new List<object>()
			{
				DelCarInfoParameter.CarID
			
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarTakeInfo( )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarBookingRecord]
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
			string sql = $@"UPDATE [{m_gas}].[dbo].[CarBookingRecord] 
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
							FROM [{m_gas}].[dbo].[CarBookingRecord]
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
		internal DataTable GetCarLastBackInfo( GetCarLastBackInfo GetCarLastBackInfoParameter )
		{
			string sql = $@"SELECT MAX(CAST([EndMileage] AS INT)) AS 'LastBackMile'
									FROM [{m_gas}].[dbo].[CarBookingRecord]
									WHERE [CarNumber]=@Parameter0 AND [EndMileage] NOT like '%[^A-Za-z0-9]%'";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarLastBackInfoParameter.CarNumber

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
		internal bool UpdateCarBackInfo( UpdateCarBackInfo UpdateCarBackInfoParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[CarBookingRecord] 
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
			string sql = $@"SELECT A.EmpID, A.Name, convert(varchar, A.[LastDate], 111) AS'LastDate', B.Reason
							FROM(SELECT [EmpID],[Name],max([Date]) AS 'LastDate'
								 FROM [{m_gas}].[dbo].[CarBookingStatus]
								 WHERE [Status] = 'blocked'
								 GROUP BY [EmpID],[Name])A

							LEFT JOIN

							(SELECT [EmpID],[Name],[Reason],[Date]
							FROM [{m_gas}].[dbo].[CarBookingStatus])B

							ON A.EmpID = B.EmpID and A.LastDate = B.Date";

		
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
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[CarBookingStatus]
								([Name]
								,[EmpID]
								,[Status]
								,[Date]
								,[Reason])
							VALUES
								((SELECT TOP 1 [EmpName] From [{m_gas}].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0),@Parameter0,'blocked',GETDATE(),@Parameter1)
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
							UPDATE [{m_gas}].[dbo].[CarBookingStatus] 
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
							FROM [{m_gas}].[dbo].[CarBookingRecord]
							WHERE　 (GETDATE() between  [PreserveStartTime] and [PreserveEndTime])　and ActualEndTime IS NULL 
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

		internal DataTable GetCarRepairFrequency()
		{
			string sql = $@"SELECT *
						  FROM [{m_gas}].[dbo].[CarRepairFrequency]
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
		internal bool UpsertCarRepairFrequency( UpsertCarRepairFrequency UpsertCarRepairFrequencyParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[CarInfo]
							SET  [NextRepairMile]=@Parameter1
							WHERE [id]=@Parameter0 
						";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarRepairFrequencyParameter.CarID,
				UpsertCarRepairFrequencyParameter.NextRepairMile

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteCarRepairFrequency( DeleteCarRepairFrequency DeleteCarRepairFrequencyParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarRepairFrequency] 
						WHERE [id]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteCarRepairFrequencyParameter.id
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarRepairRecord()
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarRepairRecord]
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

		internal DataTable GetCarRepairCost()
		{
			string sql = $@"SELECT [CarNumber], format([RecordMonth], 'yyyyMM') AS 'YearMonth' ,sum([Cost]) AS 'Cost'
									FROM [{m_gas}].[dbo].[CarRepairRecord]
									GROUP BY [CarNumber], format([RecordMonth], 'yyyyMM')
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
		internal bool UpsertCarRepairRecord( UpsertCarRepairRecord UpsertCarRepairRecordParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[CarRepairRecord] WHERE [id]=@Parameter0 and [RecordMonth]=@Parameter2 and [FileName]=@Parameter4)
							UPDATE [{m_gas}].[dbo].[CarRepairRecord]
							SET  [CarNumber]=@Parameter1,[RecordMonth]=@Parameter2,[Memo]=@Parameter3,[Filename]=@Parameter4,[RecordID]=@Parameter5,[Cost]=@Parameter6,[RecordType]=@Parameter7,[NewRecordRoad]=@Parameter8
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarRepairRecord] ([id],[CarNumber],[RecordMonth],[Memo],[FileName],[RecordID],[Cost],[RecordType],[NewRecordRoad]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarRepairRecordParameter.id,
				UpsertCarRepairRecordParameter.CarNumber,
				UpsertCarRepairRecordParameter.RecordMonth,
				UpsertCarRepairRecordParameter.Memo,
				UpsertCarRepairRecordParameter.FileName,
				UpsertCarRepairRecordParameter.ReordID,
				UpsertCarRepairRecordParameter.Cost,
				UpsertCarRepairRecordParameter.RecordType,
				UpsertCarRepairRecordParameter.NewRecordRoad
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DelCarRepairRecord( DelCarRepairRecord DelCarRepairRecordParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarRepairRecord]
							WHERE [CarNumber]=@Parameter0 and [FileName]=@Parameter1";

			List<object> SQLParameterList = new List<object>()
			{
				DelCarRepairRecordParameter.CarNumber,
				DelCarRepairRecordParameter.FileName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarFavoriteLink()
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarFavoriteLink]
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
		internal bool UpsertCarFavoriteLink( UpsertCarFavoriteLink UpsertCarFavoriteLinkParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM  [{m_gas}].[dbo].[CarFavoriteLink] WHERE [WebName]=@Parameter0 )
							UPDATE  [{m_gas}].[dbo].[CarFavoriteLink]
							SET  [WebLink]=@Parameter1
							WHERE  [WebName]=@Parameter0
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarFavoriteLink] ([WebName],[WebLink]) 
						VALUES (@Parameter0,@Parameter1)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarFavoriteLinkParameter.WebName,
				UpsertCarFavoriteLinkParameter.WebLink
			
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarFavoriteLink( DelCarFavoriteLink DelCarFavoriteLinkParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarFavoriteLink]
							WHERE [id]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DelCarFavoriteLinkParameter.id
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetCarInsurance( GetCarInsurance GetCarInsuranceParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarInsurance]
							WHERE [CarID] = @Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarInsuranceParameter.CarID

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
		internal DataTable GetCarInsuranceNameLast()
		{
			string sql = $@"SELECT Max([No]) as MaxNo
							FROM [{m_gas}].[dbo].[CarInsuranceName]";

			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal DataTable GetCarInsuranceSpecificTime( GetCarInsuranceSpecificTime GetCarInsuranceSpecificTimeParameter )
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarInsurance]
							WHERE [CarID] = @Parameter0 and [InsuranceStart]<=@Parameter1 and [InsuranceStart]>@Parameter2  ";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarInsuranceSpecificTimeParameter.CarID,
				GetCarInsuranceSpecificTimeParameter.InsuranceYear,
				GetCarInsuranceSpecificTimeParameter.InsuranceNextYear
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
		internal bool UpsertCarInsurance( UpsertCarInsurance UpsertCarInsuranceParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM  [{m_gas}].[dbo].[CarInsurance] WHERE [No]=@Parameter9 )
							UPDATE  [{m_gas}].[dbo].[CarInsurance]
							SET  [CarNumber]=@Parameter1,[InsuranceStart]=@Parameter2,[InsuranceEnd]=@Parameter3,[InsuranceType]=@Parameter4,[InsuranceMoney]=@Parameter5,[SelfPay]=@Parameter6,[InsuranceCost]=@Parameter7,[InsuranceFileName]=@Parameter8,[Memo]=@Parameter10
							WHERE  [No]=@Parameter9
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarInsurance] ([CarID],[CarNumber],[InsuranceStart],[InsuranceEnd],[InsuranceType],[InsuranceMoney],[SelfPay],[InsuranceCost],[InsuranceFileName],[Memo]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter10)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarInsuranceParameter.CarID,
				UpsertCarInsuranceParameter.CarNumber,
				UpsertCarInsuranceParameter.InsuranceStart,
				UpsertCarInsuranceParameter.InsuranceEnd,
				UpsertCarInsuranceParameter.InsuranceType,
				UpsertCarInsuranceParameter.InsuranceMoney,
				UpsertCarInsuranceParameter.SelfPay,
				UpsertCarInsuranceParameter.InsuranceCost,
				UpsertCarInsuranceParameter.InsuranceFileName,
				UpsertCarInsuranceParameter.No,
				UpsertCarInsuranceParameter.Memo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarInsurance( DelCarInsurance DelCarInsuranceParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarInsurance]
							WHERE [No]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DelCarInsuranceParameter.No
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarInsuranceType()
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CarInsuranceTypeInfo]
						  ";
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );


			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpsertCarInsuranceType( UpsertCarInsuranceType UpsertCarInsuranceTypeParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM  [{m_gas}].[dbo].[CarInsuranceTypeInfo] WHERE [No]=@Parameter0 )
							UPDATE  [{m_gas}].[dbo].[CarInsuranceTypeInfo]
							SET  [InsuranceType]=@Parameter1
							WHERE  [No]=@Parameter0
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarInsuranceTypeInfo] ([InsuranceType]) 
						VALUES (@Parameter1)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarInsuranceTypeParameter.No,
				UpsertCarInsuranceTypeParameter.InsuranceType

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarInsuranceType( DelCarInsuranceType DelCarInsuranceTypeParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarInsuranceTypeInfo]
							WHERE [No]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DelCarInsuranceTypeParameter.No
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetCarInsuranceName( GetCarInsuranceName GetCarInsuranceNameParameter )
		{
			string sql = $@"SELECT [CarInsuranceName].[No],
												[CarInsuranceName].[Type] as 'TypeNo',
												[CarInsuranceName].[Items],
												[CarInsuranceTypeInfo].[InsuranceType]
									FROM [{m_gas}].[dbo].[CarInsuranceName]
									INNER JOIN [{m_gas}].[dbo].[CarInsuranceTypeInfo]
									ON [CarInsuranceName].[Type]=[CarInsuranceTypeInfo].[No]
WHERE [CarInsuranceName].[Type] = @Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarInsuranceNameParameter.Type

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
		internal bool UpsertCarInsuranceName( UpsertCarInsuranceName UpsertCarInsuranceNameParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM  [{m_gas}].[dbo].[CarInsuranceName] WHERE [No]=@Parameter0)
							UPDATE  [{m_gas}].[dbo].[CarInsuranceName]
							SET  [Items]=@Parameter1
							WHERE  [No] = @Parameter0
						ELSE
						INSERT INTO [{m_gas}].[dbo].[CarInsuranceName] ([Type],[Items]) 
						VALUES (@Parameter2,@Parameter1)";    

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarInsuranceNameParameter.No,
				UpsertCarInsuranceNameParameter.Items,
				UpsertCarInsuranceNameParameter.Type

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarInsuranceName( DelCarInsuranceName DelCarInsuranceNameParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarInsuranceName]
							WHERE [Items]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{

				DelCarInsuranceNameParameter.Items
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetBeenRentCarSpecTime( GetBeenRentCarSpecTime GetBeenRentCarSpecTimeParameter )
		{
			string sql = $@"select * from [{m_gas}].[dbo].[CarBookingRecord] 
where (([PreserveStartTime] BETWEEN CONVERT(datetime,@Parameter0,120) and CONVERT(datetime,@Parameter1,120)) AND ([PreserveStartTime]<>CONVERT(datetime,@Parameter1,120))) or (([PreserveEndTime] BETWEEN CONVERT(datetime,@Parameter0,120) and CONVERT(datetime,@Parameter1,120)) AND ([PreserveEndTime]<>CONVERT(datetime,@Parameter0,120)))";


			List<object> SQLParameterList = new List<object>()
			{
				GetBeenRentCarSpecTimeParameter.StartTime,
				GetBeenRentCarSpecTimeParameter.EndTime
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

		internal DataTable GetPersonalCarBookingRecord( GetPersonalCarBookingRecord GetPersonalCarBookingRecordParameter )
		{
			string sql = $@"SELECT *  
							FROM [{m_gas}].[dbo].[CarBookingRecord] 
							WHERE EmpID=@Parameter0 and CONVERT(datetime,PreserveStartTime,120)>=CONVERT(datetime,GETDATE(),120) 
							ORDER BY [PreserveStartTime]";

			List<object> SQLParameterList = new List<object>()
			{
				GetPersonalCarBookingRecordParameter.EmpID
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

		internal DataTable GetPrivatePriorityNumber( GetPrivatePriorityNumber GetPrivatePriorityNumberParameter )
		{
			string sql = $@"SELECT MAX([PriorityNumber]) as  MAXPriorityNumber 
							FROM ( Select * FROM [{m_gas}].[dbo].[CarBookingRecord] 
						           WHERE Type='private' and ( CONVERT(datetime,@Parameter0,120) BETWEEN CONVERT(datetime,PreserveStartTime,120)  AND CONVERT(datetime,PreserveEndTime,120) OR CONVERT(datetime,@Parameter1,120) BETWEEN CONVERT(datetime,PreserveStartTime,120)  AND CONVERT(datetime,PreserveEndTime,120) OR CONVERT(datetime,PreserveStartTime,120)  BETWEEN CONVERT(datetime,@Paramete0,120) AND CONVERT(datetime,@Parameter1,120) OR CONVERT(datetime,PreserveEndTime,120) BETWEEN CONVERT(datetime,@Parameter0,120) AND CONVERT(datetime, @Parameter1 ,120)) )AA";
		

			List<object> SQLParameterList = new List<object>()
			{
				GetPrivatePriorityNumberParameter.PreserveStartTime,
				GetPrivatePriorityNumberParameter.PreserveEndTime
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

		internal DataTable CheckInner14DaysHasPrivatDate( CheckInner14DaysHasPrivatDate CheckInner14DaysHasPrivatDateParameter )
		{
			string sql = $@"SELECT *,DateDiff(SECOND,convert(varchar, convert(varchar,getdate() , 121), 121),[PreserveEndTime]),getdate()  
							FROM [{m_gas}].[dbo].[CarBookingRecord] where EmpID=@Parameter0 and Type='private' and DateDiff(dd,convert(varchar, convert(varchar,getdate() , 111), 111),[PreserveStartTime])<=14 and DateDiff(SECOND,convert(varchar, convert(varchar,getdate() , 121), 121),[PreserveEndTime])>=0 and ActualEndTime IS NULL";
		

		List<object> SQLParameterList = new List<object>()
			{
				CheckInner14DaysHasPrivatDateParameter.EmpID
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

		internal DataTable CheckPersonalBlockStatus( CheckPersonalBlockStatus CheckPersonalBlockStatusParameter )
		{
			string sql = $@"SELECT *  
							FROM [{m_gas}].[dbo].[CarBookingStatus]  
							WHERE Status='blocked' and EmpID=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				CheckPersonalBlockStatusParameter.EmpID
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

		internal bool InsertReserveToCarBookingRecord( InsertReserveToCarBookingRecord InsertReserveToCarBookingRecordParameter )
		{
			string sql = $@"IF @Parameter1 = 'working'
							INSERT INTO  [{m_gas}].[dbo].[CarBookingRecord] 
							([Name],[EmpID],[Type],[Title],[StartLocation],[EndLocation],[CarNumber],[PreserveStartTime],[PreserveEndTime],[PriorityNumber],[ID])
							VALUES((SELECT TOP(1) [EmpName] FROM [syntecbarcode].[dbo].[TEMP_NAME] WHERE [EmpID]=@Parameter0),@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,0,(SELECT MAX(ID)+1 FROM [{m_gas}].[dbo].[CarBookingRecord]))
						ELSE
							INSERT INTO  [{m_gas}].[dbo].[CarBookingRecord] 
							([Name],[EmpID],[Type],[Title],[StartLocation],[EndLocation],[PreserveStartTime],[PreserveEndTime],[PriorityNumber],[ID])
							VALUES((SELECT TOP(1) [EmpName] FROM [syntecbarcode].[dbo].[TEMP_NAME] WHERE [EmpID]=@Parameter0),@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter6,@Parameter7,
							(SELECT MAX([PriorityNumber]) as  MAXPriorityNumber FROM ( Select * FROM [{m_gas}].[dbo].[CarBookingRecord] WHERE Type='private' 
							and ( CONVERT(datetime,@Parameter6,120) BETWEEN CONVERT(datetime,PreserveStartTime,120)  AND CONVERT(datetime,PreserveEndTime,120) 
							OR CONVERT(datetime,@Parameter7,120) BETWEEN CONVERT(datetime,PreserveStartTime,120)  AND CONVERT(datetime,PreserveEndTime,120) 
							OR CONVERT(datetime,PreserveStartTime,120)  BETWEEN CONVERT(datetime,@Parameter6,120) AND CONVERT(datetime,@Parameter7,120) 
							OR CONVERT(datetime,PreserveEndTime,120) BETWEEN CONVERT(datetime,@Parameter6,120) AND CONVERT(datetime, @Parameter7 ,120)) )AA	)+1
							,(SELECT MAX(ID)+1 FROM [{m_gas}].[dbo].[CarBookingRecord]))";

			List<object> SQLParameterList = new List<object>()
			{

				InsertReserveToCarBookingRecordParameter.EmpID,
				InsertReserveToCarBookingRecordParameter.Type,
				InsertReserveToCarBookingRecordParameter.Title,
				InsertReserveToCarBookingRecordParameter.StartLocation,
				InsertReserveToCarBookingRecordParameter.EndLocation,
				InsertReserveToCarBookingRecordParameter.CarNumber,
				InsertReserveToCarBookingRecordParameter.PreserveStartTime,
				InsertReserveToCarBookingRecordParameter.PreserveEndTime
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCarBookingRecord( DeleteCarBookingRecord DeleteCarBookingRecordParameter )
		{
			string sql = $@"DELETE FROM  [{m_gas}].[dbo].[CarBookingRecord]  
							WHERE ID=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{

				DeleteCarBookingRecordParameter.ID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarBookingRecordID( GetCarBookingRecordID GetCarBookingRecordIDParameter )
		{
			string sql = $@"IF @Parameter1 = 'private'
								SELECT *  
								FROM [{m_gas}].[dbo].[CarBookingRecord]  
								WHERE [EmpID]=@Parameter0 and [Type]=@Parameter1 and [Title]=@Parameter2 and [PreserveStartTime]=@Parameter3 and [PreserveEndTime]=@Parameter4
							ELSE
								SELECT *  
								FROM [{m_gas}].[dbo].[CarBookingRecord]  
								WHERE [EmpID]=@Parameter0 and [Type]=@Parameter1 and [Title]=@Parameter2 and [PreserveStartTime]=@Parameter3 and [PreserveEndTime]=@Parameter4 and [CarNumber]=@Parameter5";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarBookingRecordIDParameter.EmpID,
				GetCarBookingRecordIDParameter.TypePersonalBusiness,
				GetCarBookingRecordIDParameter.Remark,
				GetCarBookingRecordIDParameter.PreserveStartTime,
				GetCarBookingRecordIDParameter.PreserveEndTime,
				GetCarBookingRecordIDParameter.CarNumber
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

		internal DataTable GetCarCheckFormByFormID( GetCarCheckFormByFormID GetCarCheckFormByFormIDParameter )
		{
			string sql = $@"SELECT *  
							FROM [{m_gas}].[dbo].[CarCheckForm]  
							WHERE [CarCheckFormID]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarCheckFormByFormIDParameter.CarCheckFormID
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

		internal DataTable GetCarCheckFormByCarNumber( GetCarCheckFormByCarNumber GetCarCheckFormByCarNumberParameter )
		{
			string sql = $@"SELECT *  
							FROM [{m_gas}].[dbo].[CarCheckForm]  
							WHERE [CarNumber]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarCheckFormByCarNumberParameter.CarNumber
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

		internal bool InsertCheckForm( InsertCheckForm InsertCheckFormParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[CarCheckForm] ([FillerID],[FillerName],[FillerDate],[OilNormal],[DashboardNormal],				[FanBeltNormal],[PluginNormal],[AcceleratorNormal],[WaterNormal],[BrakeNormal],[LightNormal],[GrassNormal],					[DoorNormal],[TireNormal],[CarNumber]) 
							VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11,@Parameter12,@Parameter13,@Parameter14)";

			List<object> SQLParameterList = new List<object>()
			{

				InsertCheckFormParameter.FillerID,
				InsertCheckFormParameter.FillerName,
				InsertCheckFormParameter.FillerDate,
				InsertCheckFormParameter.OilNormal,
				InsertCheckFormParameter.DashboardNormal,
				InsertCheckFormParameter.FanBeltNormal,
				InsertCheckFormParameter.PluginNormal,
				InsertCheckFormParameter.AcceleratorNormal,
				InsertCheckFormParameter.WaterNormal,
				InsertCheckFormParameter.BrakeNormal,
				InsertCheckFormParameter.LightNormal,
				InsertCheckFormParameter.GrassNormal,
				InsertCheckFormParameter.DoorNormal,
				InsertCheckFormParameter.TireNormal,
				InsertCheckFormParameter.CarNumber
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCheckForm( DeleteCheckForm DeleteCheckFormParameter )
		{
			string sql = $@"DELETE FROM  [{m_gas}].[dbo].[CarBookingRecord]  
							WHERE CarCheckFormID=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{

				DeleteCheckFormParameter.CarCheckFormID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		

	}
	#endregion Internal Methods
}
