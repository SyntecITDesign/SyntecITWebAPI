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

	}
	#endregion Internal Methods
}

