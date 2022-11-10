using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.VisitorRegistration
{
	

	public class VisitorRegistrationApplicationsMasterAllField
	{
		public int VisitorRegistrationApplicationsMasterRequisitionID
		{
			get; set;
		}
		public int VisitorRegistrationApplicationsMasterFillDate
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterPreserveVisitDateTime
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterVisitorCompany
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterVisitor
		{
			get; set;
		}
		public int VisitorRegistrationApplicationsMasterVisitorNum
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterVisitorType
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterVisitorTel
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterIntervieweeName
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterParkingCarsName
		{
			get; set;
		}
		public int VisitorRegistrationApplicationsMasterParkingCarsNum
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterHealthDeclaration
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterDisseminate
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterCarryOn
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterActualVisitDateTime
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterBadgeType
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterBadgeNo
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterIntervieweeID
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterCheckCarryOn
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterActualLeaveDateTime
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterIsReturnBadge
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterIsCheckCarryOn
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterFinished
		{
			get; set;
		}
		public bool VisitorRegistrationApplicationsMasterIsCancel
		{
			get; set;
		}
		public string VisitorRegistrationApplicationsMasterMemo
		{
			get; set;
		}
				
	}
	public class InsertVisitorRegistrationApplicationsMaster : VisitorRegistrationApplicationsMasterAllField
	{

	}
	public class DeleteVisitorRegistrationApplicationsMaster : VisitorRegistrationApplicationsMasterAllField
	{

	}
	public class UpdateVisitorRegistrationApplicationsMaster : VisitorRegistrationApplicationsMasterAllField
	{

	}
	public class GetVisitorRegistrationApplicationsMaster : VisitorRegistrationApplicationsMasterAllField
	{

	}
	public class VisitorCheckIn : VisitorRegistrationApplicationsMasterAllField
	{

	}

	public class VisitorCheckOut : VisitorRegistrationApplicationsMasterAllField
	{

	}



}
