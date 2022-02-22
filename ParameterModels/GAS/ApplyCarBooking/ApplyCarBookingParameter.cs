using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyCarBooking
{
	public class CarBookingApplicationsMasterAllField
	{
		public string CarBookingApplicationsMasterAllFieldApplicationID
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldApplicationName
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldApplicationDate
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldFillerID
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldFillerName
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldTypeApplyCancel
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldTypePersonalBusiness
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldPreserveStartTime
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldPreserveEndTime
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldActualStartTime
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldActualEndTime
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldCarNumber
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldRemark
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldStartPlace
		{
			get; set;
		}
		public string CarBookingApplicationsMasterAllFieldEndPlace
		{
			get; set;
		}
		

	}
	public class InsertCarBookingApplicationsMaster : CarBookingApplicationsMasterAllField
	{

	}
	public class DeleteCarBookingApplicationsMaster 
	{
		public string ReuisitionID
		{
			get; set;
		}


	}
	public class GetCarBookingApplicationsMaster : CarBookingApplicationsMasterAllField
	{

	}
	
}
