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
						  FROM [SyntecGAS].[dbo].[CarInfo]
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
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[CarInfo] WHERE [id]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[CarInfo]
							SET [CarNumber]=@Parameter1, [Model]=@Parameter2,[Seats]=@Parameter3,[BuyYear]=@Parameter4,[Type]=@Parameter5,[Gas]=@Parameter6,[Engine]=@Parameter7,[InsuranceStart]=@Parameter8,[InsuranceEnd]=@Parameter9,[Belongs]=@Parameter10,[CanRent]=@Parameter11
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarInfo] ([id],[CarNumber],[Model],[Seats],[BuyYear],[Type],[Gas],[Engine],[InsuranceStart],[InsuranceEnd],[Belongs],[CanRent]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11)
						
						IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[CarRepairFrequency] WHERE [id]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[CarRepairFrequency]
							SET [CarNumber]=@Parameter1
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarRepairFrequency] ([id],[CarNumber],[Frequency],[Memo]) 
						VALUES (@Parameter0,@Parameter1,0,'')";

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
				UpsertCarInfoParameter.InsuranceStart,
				UpsertCarInfoParameter.InsuranceEnd,
				UpsertCarInfoParameter.Belongs,
				UpsertCarInfoParameter.CanRent

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DelCarInfo( DelCarInfo DelCarInfoParameter )
		{
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarInfo]
							WHERE [id]=@Parameter0
							DELETE FROM [SyntecGAS].[dbo].[CarRepairFrequency]
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
		internal DataTable GetCarLastBackInfo( GetCarLastBackInfo GetCarLastBackInfoParameter )
		{
			string sql = $@"SELECT MAX(CAST([EndMileage] AS INT)) AS 'LastBackMile'
									FROM [SyntecGAS].[dbo].[CarBookingRecord]
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
			string sql = $@"SELECT A.EmpID, A.Name, convert(varchar, A.[LastDate], 111) AS'LastDate', B.Reason
							FROM(SELECT [EmpID],[Name],max([Date]) AS 'LastDate'
								 FROM [SyntecGAS].[dbo].[CarBookingStatus]
								 WHERE [Status] = 'blocked'
								 GROUP BY [EmpID],[Name])A

							LEFT JOIN

							(SELECT [EmpID],[Name],[Reason],[Date]
							FROM [SyntecGAS].[dbo].[CarBookingStatus])B

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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CarBookingStatus]
								([Name]
								,[EmpID]
								,[Status]
								,[Date]
								,[Reason])
							VALUES
								((SELECT TOP 1 [EmpName] From [SyntecGAS].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0),@Parameter0,'blocked',GETDATE(),@Parameter1)
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

		internal DataTable GetCarRepairFrequency()
		{
			string sql = $@"SELECT *
						  FROM [SyntecGAS].[dbo].[CarRepairFrequency]
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
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[CarRepairFrequency] WHERE [id]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[CarRepairFrequency]
							SET  [CarNumber]=@Parameter1,[Frequency]=@Parameter2,[Memo]=@Parameter3
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarRepairFrequency] ([id],[CarNumber],[Frequency],[Memo]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarRepairFrequencyParameter.id,
				UpsertCarRepairFrequencyParameter.CarNumber,
				UpsertCarRepairFrequencyParameter.Frequency,
				UpsertCarRepairFrequencyParameter.Memo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteCarRepairFrequency( DeleteCarRepairFrequency DeleteCarRepairFrequencyParameter )
		{
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarRepairFrequency] 
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
							FROM [SyntecGAS].[dbo].[CarRepairRecord]
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
									FROM [SyntecGAS].[dbo].[CarRepairRecord]
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
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[CarRepairRecord] WHERE [id]=@Parameter0 and [RecordMonth]=@Parameter2 and [FileName]=@Parameter4)
							UPDATE [SyntecGAS].[dbo].[CarRepairRecord]
							SET  [CarNumber]=@Parameter1,[RecordMonth]=@Parameter2,[Memo]=@Parameter3,[Filename]=@Parameter4,[RecordID]=@Parameter5,[Cost]=@Parameter6
							WHERE [id]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarRepairRecord] ([id],[CarNumber],[RecordMonth],[Memo],[FileName],[RecordID],[Cost]) 
						VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertCarRepairRecordParameter.id,
				UpsertCarRepairRecordParameter.CarNumber,
				UpsertCarRepairRecordParameter.RecordMonth,
				UpsertCarRepairRecordParameter.Memo,
				UpsertCarRepairRecordParameter.FileName,
				UpsertCarRepairRecordParameter.ReordID,
				UpsertCarRepairRecordParameter.Cost
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCarFavoriteLink()
		{
			string sql = $@"SELECT *
							FROM [SyntecGAS].[dbo].[CarFavoriteLink]
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
			string sql = $@"IF EXISTS (SELECT * FROM  [SyntecGAS].[dbo].[CarFavoriteLink] WHERE [WebName]=@Parameter0 )
							UPDATE  [SyntecGAS].[dbo].[CarFavoriteLink]
							SET  [WebLink]=@Parameter1
							WHERE  [WebName]=@Parameter0
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarFavoriteLink] ([WebName],[WebLink]) 
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
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarFavoriteLink]
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
							FROM [SyntecGAS].[dbo].[CarInsurance]
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
							FROM [SyntecGAS].[dbo].[CarInsuranceName]";

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
							FROM [SyntecGAS].[dbo].[CarInsurance]
							WHERE [CarID] = @Parameter0 and [InsuranceStart]=@Parameter1";

			List<object> SQLParameterList = new List<object>()
			{
				GetCarInsuranceSpecificTimeParameter.CarID,
				GetCarInsuranceSpecificTimeParameter.InsuranceStart
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
			string sql = $@"IF EXISTS (SELECT * FROM  [SyntecGAS].[dbo].[CarInsurance] WHERE [No]=@Parameter9 )
							UPDATE  [SyntecGAS].[dbo].[CarInsurance]
							SET  [CarNumber]=@Parameter1,[InsuranceStart]=@Parameter2,[InsuranceEnd]=@Parameter3,[InsuranceType]=@Parameter4,[InsuranceMoney]=@Parameter5,[SelfPay]=@Parameter6,[InsuranceCost]=@Parameter7,[InsuranceFileName]=@Parameter8,[Memo]=@Parameter10
							WHERE  [No]=@Parameter9
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarInsurance] ([CarID],[CarNumber],[InsuranceStart],[InsuranceEnd],[InsuranceType],[InsuranceMoney],[SelfPay],[InsuranceCost],[InsuranceFileName],[Memo]) 
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
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarInsurance]
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
							FROM [SyntecGAS].[dbo].[CarInsuranceTypeInfo]
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
			string sql = $@"IF EXISTS (SELECT * FROM  [SyntecGAS].[dbo].[CarInsuranceTypeInfo] WHERE [No]=@Parameter0 )
							UPDATE  [SyntecGAS].[dbo].[CarInsuranceTypeInfo]
							SET  [InsuranceType]=@Parameter1
							WHERE  [No]=@Parameter0
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarInsuranceTypeInfo] ([InsuranceType]) 
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
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarInsuranceTypeInfo]
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
									FROM [SyntecGAS].[dbo].[CarInsuranceName]
									INNER JOIN [SyntecGAS].[dbo].[CarInsuranceTypeInfo]
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
			string sql = $@"IF EXISTS (SELECT * FROM  [SyntecGAS].[dbo].[CarInsuranceName] WHERE [No]=@Parameter0)
							UPDATE  [SyntecGAS].[dbo].[CarInsuranceName]
							SET  [Items]=@Parameter1
							WHERE  [No] = @Parameter0
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[CarInsuranceName] ([Type],[Items]) 
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
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[CarInsuranceName]
							WHERE [Items]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{

				DelCarInsuranceNameParameter.Items
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}
