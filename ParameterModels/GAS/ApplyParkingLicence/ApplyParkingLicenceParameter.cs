using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyParkingLicence
{
	public class ParkingLicenceApplicationsMasterAllField
	{
		public string ParkingLicenceApplicationsMasterApplicantID
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterApplicantName
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterApplicationType
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterPlateNumber
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterRemarks
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterFinished
		{
			get; set;
		}
		public string ParkingLicenceApplicationsMasterIsCancel
		{
			get; set;
		}
		public int ParkingLicenceApplicationsMasterRequisitionID
		{
			get; set;
		}
	}
	public class InsertParkingLicenceApplicationsMaster : ParkingLicenceApplicationsMasterAllField
	{

	}
	public class UpdateParkingLicenceApplicationsMaster : ParkingLicenceApplicationsMasterAllField
	{

	}
	public class GetParkingLicenceApplicationsMaster : ParkingLicenceApplicationsMasterAllField
	{

	}
}
