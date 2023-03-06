using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.Stationery
{
    public class UpsertStationeryQuantity
    {
        #region Public Properties

        public int ID {
            get;set;
        }

        public string StationeryName
        {
            get; set;
        }

        public string StationerySpec
        {
            get; set;
        }

        public string StationeryUnit
        {
            get; set;
        }

        public int StationeryAmount
        {
            get; set;
        }

        #endregion Public Properties
    }
    public class DeleteStationery
    {
        #region Public Properties


        public int ID
        {
            get; set;
        }


        #endregion Public Properties
    }

	public class StationeryApplicationsMasterAllField
	{
		public int StationeryApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string StationeryApplicationsMasterFillerID
		{
			get; set;
		}
		public string StationeryApplicationsMasterFillerName
		{
			get; set;
		}
		public string StationeryApplicationsMasterApplicationDate
		{
			get; set;
		}
	}
	public class InsertStationeryApplicationsMaster : StationeryApplicationsMasterAllField
	{
	}
	public class UpdateStationeryApplicationsMaster : StationeryApplicationsMasterAllField
	{
	}
	public class DeleteStationeryApplicationsMaster : StationeryApplicationsMasterAllField
	{
	}
	public class GetStationeryApplicationsMaster : StationeryApplicationsMasterAllField
	{
	}

	public class StationeryApplicationsDetailAllField
	{
		public string StationeryApplicationsDetailRequisitionID
		{
			get; set;
		}
		public string StationeryApplicationsDetailApplicantDept
		{
			get; set;
		}
		public bool StationeryApplicationsDetailIsCancel
		{
			get; set;
		}
		public string StationeryApplicationsDetailProductName
		{
			get; set;
		}
		public string StationeryApplicationsDetailSpecification
		{
			get; set;
		}
		public string StationeryApplicationsDetailUnit
		{
			get; set;
		}
		public int StationeryApplicationsDetailQuantity
		{
			get; set;
		}
		public bool StationeryApplicationsDetailFinished
		{
			get; set;
		}
		public string StationeryApplicationsDetailFillerID
		{
			get; set;
		}
	}
	public class InsertStationeryApplicationsDetail : StationeryApplicationsDetailAllField
	{
	}
	public class UpdateStationeryApplicationsDetail : StationeryApplicationsDetailAllField
	{
	}
	public class GetStationeryApplicationsDetail : StationeryApplicationsDetailAllField
	{
	}
	public class DeleteStationeryApplicationsDetail : StationeryApplicationsDetailAllField
	{
	}

	public class GetStationeryApplicationsDept : StationeryApplicationsDetailAllField
	{
	}

}
