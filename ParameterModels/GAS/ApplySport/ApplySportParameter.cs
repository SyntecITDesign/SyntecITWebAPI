using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.ParameterModels.GAS.ApplySport
{
	public class CourtRecordAllField //讓其他class可以access
	{
		public string EmpID //DB的名稱
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}
		public string ApplyDate
		{
			get; set;
		}
		public string ReserveDate
		{
			get; set;
		}
		public string ReserveStartTime
		{
			get; set;
		}
		public string ReserveEndTime
		{
			get; set;
		}
		public string Court
		{
			get; set;
		}
	}

	//public class GetAllCourt : CourtRecordAllField
	//{
	//	public string StartTime
	//	{
	//		get; set;
	//	}
	//	public string EndTime
	//	{
	//		get; set;
	//	}
	//}
	public class InsertCourtReserve : CourtRecordAllField //和API同名
	{

	}

	public class GetUsingCourt : CourtRecordAllField
	{

	}
	public class DuplicateReserve : CourtRecordAllField
	{

	}
	public class GetSportCourtReserve : CourtRecordAllField
	{
		public string Today
		{
			get; set;
		}

	}
	public class UpdateSportCourtReserve : CourtRecordAllField
	{
		public string ID
		{
			get; set;
		}

	}
}
