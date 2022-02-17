using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Stationery;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicGASDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal DataTable GetStationeryQuantity()
		{
			string sql = $@"SELECT * FROM [SyntecGAS].[dbo].[Stationery]";

			DataTable result = m_dbproxy.GetDataWithNoParaCMD(sql);
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if (result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool UpsertStationeryQuantity(UpsertStationeryQuantity UpsertStationeryParameter)
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[Stationery] WHERE [ID]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[Stationery] SET [ProductName]=@Parameter1, [Specification]=@Parameter2,[Unit]=@Parameter3,[Quantity]=@Parameter4
							WHERE [ID]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[Stationery] ([ProductName],[Specification],[Unit],[Quantity]) 
						VALUES (@Parameter1,@Parameter2,@Parameter3,@Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertStationeryParameter.ID,
				UpsertStationeryParameter.StationeryName,
				UpsertStationeryParameter.StationerySpec,
				UpsertStationeryParameter.StationeryUnit,
				UpsertStationeryParameter.StationeryAmount

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteStationery(DeleteStationery DeleteStationeryParameter)
		{
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[Stationery]
						WHERE [ID] = @Parameter0" ;

			List<object> SQLParameterList = new List<object>()
			{
				DeleteStationeryParameter.ID,
				

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetStationeryApplicationsMaster( GetStationeryApplicationsMaster GetStationeryApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[StationeryApplicationsMaster]
						Where [FillerID] like @Parameter1
						ORDER BY [RequisitionID] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetStationeryApplicationsMasterParameter.StationeryApplicationsMasterRequisitionID,
				GetStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerID,
				GetStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerName,
				GetStationeryApplicationsMasterParameter.StationeryApplicationsMasterApplicationDate
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
		internal bool InsertStationeryApplicationsMaster( InsertStationeryApplicationsMaster InsertStationeryApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[StationeryApplicationsMaster] ([FillerID],[FillerName],[ApplicationDate])
								VALUES (@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertStationeryApplicationsMasterParameter.StationeryApplicationsMasterRequisitionID,
				InsertStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerID,
				InsertStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerName,
				InsertStationeryApplicationsMasterParameter.StationeryApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateStationeryApplicationsMaster( UpdateStationeryApplicationsMaster UpdateStationeryApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[StationeryApplicationsMaster]
							set []=@Parameter1
							where []=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateStationeryApplicationsMasterParameter.StationeryApplicationsMasterRequisitionID,
				UpdateStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerID,
				UpdateStationeryApplicationsMasterParameter.StationeryApplicationsMasterFillerName,
				UpdateStationeryApplicationsMasterParameter.StationeryApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetStationeryApplicationsDetail( GetStationeryApplicationsDetail GetStationeryApplicationsDetailParameter )
		{
			string sql = $@"SELECT a.RequisitionID,a.ApplicantDept,a.ProductName,a.Specification,a.Unit,a.Quantity,a.Finished,b.FillerID,b.ApplicationDate
						  FROM [SyntecGAS].[dbo].[StationeryApplicationsDetail] as a
						  inner join [SyntecGAS].[dbo].[StationeryApplicationsMaster] as b
						  on a.RequisitionID=b.RequisitionID
						WHERE b.[FillerID] like @Parameter8 and a.[Finished]=@Parameter7";

			List<object> SQLParameterList = new List<object>()
			{
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailRequisitionID,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailApplicantDept,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailIsCancel,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailProductName,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailSpecification,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailUnit,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailQuantity,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailFinished,
				GetStationeryApplicationsDetailParameter.StationeryApplicationsDetailFillerID
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
		internal bool InsertStationeryApplicationsDetail( InsertStationeryApplicationsDetail InsertStationeryApplicationsDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[StationeryApplicationsDetail] ([RequisitionID],[ApplicantDept],[ProductName],[Specification],[Unit],[Quantity])
								VALUES (@Parameter0,@Parameter1,@Parameter3,@Parameter4,@Parameter5,@Parameter6)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailRequisitionID,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailApplicantDept,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailIsCancel,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailProductName,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailSpecification,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailUnit,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailQuantity,
				InsertStationeryApplicationsDetailParameter.StationeryApplicationsDetailFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateStationeryApplicationsDetail( UpdateStationeryApplicationsDetail UpdateStationeryApplicationsDetailParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[StationeryApplicationsDetail]
							set [Finished]=@Parameter7
							where [RequisitionID]=@Parameter0 and [ApplicantDept]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailRequisitionID,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailApplicantDept,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailIsCancel,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailProductName,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailSpecification,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailUnit,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailQuantity,
				UpdateStationeryApplicationsDetailParameter.StationeryApplicationsDetailFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteStationeryApplicationsDetail( DeleteStationeryApplicationsDetail DeleteStationeryApplicationsDetailParameter )
		{
			string sql = $@"Delete INTO [SyntecGAS].[dbo].[StationeryApplicationsDetail] ([])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailRequisitionID,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailApplicantDept,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailIsCancel,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailProductName,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailSpecification,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailUnit,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailQuantity,
				DeleteStationeryApplicationsDetailParameter.StationeryApplicationsDetailFinished
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


		internal DataTable GetStationeryApplicationsDept()
		{
			string sql = $@"SELECT Distinct [FSe7en_Org_DeptInfo].DisplayName, [FSe7en_Org_DeptStruct].[DeptID] 
FROM [BPMPro].dbo.[FSe7en_Org_DeptInfo],[BPMPro].dbo.[FSe7en_Org_DeptStruct]  
where  [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID = [BPMPro].dbo.[FSe7en_Org_DeptStruct].[DeptID] AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID Like 'TWST%' AND ([BPMPro].dbo.[FSe7en_Org_DeptStruct].[GradeNum]='60' OR [BPMPro].dbo.[FSe7en_Org_DeptStruct].[GradeNum]='70' )AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID = [BPMPro].dbo.[FSe7en_Org_DeptStruct].[DeptID] AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST111' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST113' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST130' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTISO' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTISOM' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTLEAN' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST57'
Union
SELECT Distinct [FSe7en_Org_DeptInfo].DisplayName, [FSe7en_Org_DeptStruct].[DeptID] 
FROM [BPMPro].dbo.[FSe7en_Org_DeptInfo],[BPMPro].dbo.[FSe7en_Org_DeptStruct]  
where  [FSe7en_Org_DeptInfo].DeptID = [FSe7en_Org_DeptStruct].[DeptID] AND [FSe7en_Org_DeptInfo].DeptID ='LEANTECTWLT5010'";

			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );
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

