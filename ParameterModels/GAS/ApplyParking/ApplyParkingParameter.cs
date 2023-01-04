using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyParking
{
	public class ParkingSpaceStatusMasterAllField
	{
		public string ParkingSpaceStatusMasterParkingSpaceUseage
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterParkingSpaceNum
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterParkingSpaceStatus
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterEmpDept
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterEmpID
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterEmpName
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterCarLicence
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterSalaryYear
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterSalaryMonth
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterParameterName
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterParkingSpaceFee
		{
			get; set;
		}
		public string ParkingSpaceStatusMasterRemarks
		{
			get; set;
		}
	}
	public class InsertParkingSpaceStatusMaster : ParkingSpaceStatusMasterAllField
	{

	}
	public class DeleteParkingSpaceStatusMaster : ParkingSpaceStatusMasterAllField
	{

	}
	public class UpdateParkingSpaceStatusMaster : ParkingSpaceStatusMasterAllField
	{

	}
	public class GetParkingSpaceStatusMaster : ParkingSpaceStatusMasterAllField
	{

	}

	public class ParkingSpaceApplicationsMasterAllField
	{
		public string ParkingSpaceApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterApplicantID
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterApplicantName
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterFillerID
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterFillerName
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterParkingSpaceNum
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterReservationTime
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterApplicationType
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterFinished
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterRemarks
		{
			get; set;
		}
		public string ParkingSpaceApplicationsMasterApplicationArea
		{
			get; set;
		}
	}
	public class UpdateParkingSpaceApplicationsMaster : ParkingSpaceApplicationsMasterAllField
	{

	}
	public class GetParkingSpaceApplicationsMaster : ParkingSpaceApplicationsMasterAllField
	{

	}
	public class DeleteParkingSpaceApplicationsMaster : ParkingSpaceApplicationsMasterAllField
	{

	}
	public class InsertParkingSpaceApplicationsMaster : ParkingSpaceApplicationsMasterAllField
	{

	}
}
