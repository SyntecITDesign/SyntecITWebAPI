using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.HealthManagement
{
    public class HealthExaminationInfoAllField
	{
        public int HealthExaminationInfoNo { get; set; }
        public string HealthExaminationInfoType{ get; set; }
		public string HealthExaminationInfoCaption {get; set;}
		public string HealthExaminationInfoBannedDate { get; set; }
        public string HealthExaminationInfoStartDate { get; set; }
        public string HealthExaminationInfoEndDate { get; set; }      
    }
    public class InsertHealthExaminationInfo : HealthExaminationInfoAllField
	{
    }
    public class DeleteHealthExaminationInfo : HealthExaminationInfoAllField
	{
    }
    public class UpdateHealthExaminationInfo : HealthExaminationInfoAllField
	{
    }
    public class GetHealthExaminationInfo : HealthExaminationInfoAllField
	{
    }

	public class HealthExaminationProjectsAllField
	{
		public int HealthExaminationProjectsNo
		{
			get; set;
		}
		public int HealthExaminationProjectsHospital
		{
			get; set;
		}
		public string HealthExaminationProjectsProject
		{
			get; set;
		}
		public string HealthExaminationProjectsSex
		{
			get; set;
		}
		public int HealthExaminationProjectsPrice
		{
			get; set;
		}
		public string HealthExaminationProjectsMemo
		{
			get; set;
		}

	}
	public class InsertHealthExaminationProjects : HealthExaminationProjectsAllField
	{
	}
	public class DeleteHealthExaminationProjects : HealthExaminationProjectsAllField
	{
	}
	public class UpdateHealthExaminationProjects : HealthExaminationProjectsAllField
	{
	}
	public class GetHealthExaminationProjects : HealthExaminationProjectsAllField
	{
	}


	public class HealthExaminationItemsAllField
	{
		public int HealthExaminationItemsNo
		{
			get; set;
		}
		public int HealthExaminationItemsHospital
		{
			get; set;
		}
		
		public string HealthExaminationItemsItem
		{
			get; set;
		}
		public int HealthExaminationItemsPrice
		{
			get; set;
		}
		public string HealthExaminationItemsMemo
		{
			get; set;
		}

	}
	public class InsertHealthExaminationItems : HealthExaminationItemsAllField
	{
	}
	public class DeleteHealthExaminationItems : HealthExaminationItemsAllField
	{
	}
	public class UpdateHealthExaminationItems : HealthExaminationItemsAllField
	{
	}
	public class GetHealthExaminationItems : HealthExaminationItemsAllField
	{
	}


	public class HealthExaminationOptionsAllField
	{
		public int HealthExaminationOptionsNo
		{
			get; set;
		}
		public int HealthExaminationOptionsProjectNo
		{
			get; set;
		}

		public int HealthExaminationOptionsItemNo
		{
			get; set;
		}
		public string HealthExaminationOptionsOptionType
		{
			get; set;
		}
		public int HealthExaminationOptionsOptionalNum
		{
			get; set;
		}
		public string HealthExaminationOptionsMemo
		{
			get; set;
		}
		public int HealthExaminationOptionsHospitalNo
		{
			get; set;
		}
		public int HealthExaminationOptionsState
		{
			get; set;
		}

	}
	public class InsertHealthExaminationOptions : HealthExaminationOptionsAllField
	{
	}
	public class DeleteHealthExaminationOptions : HealthExaminationOptionsAllField
	{
	}
	public class UpdateHealthExaminationOptions : HealthExaminationOptionsAllField
	{
	}
	public class GetHealthExaminationOptions : HealthExaminationOptionsAllField
	{
	}

	public class HealthExaminationEmpInfoAllField
	{
		public string HealthExaminationEmpInfoEmpID
		{
			get; set;
		}
		public string HealthExaminationEmpInfoJobLevel
		{
			get; set;
		}

		public string HealthExaminationEmpInfoJobStartDate
		{
			get; set;
		}
		public float HealthExaminationEmpInfoTenure
		{
			get; set;
		}
		public int HealthExaminationEmpInfoAge
		{
			get; set;
		}
		public bool HealthExaminationEmpInfoIsZeroingYear
		{
			get; set;
		}
		public string HealthExaminationEmpInfoNecessaryYear
		{
			get; set;
		}
		public bool HealthExaminationEmpInfoIsNecessaryYear
		{
			get; set;
		}
		public int HealthExaminationEmpInfoBalance
		{
			get; set;
		}
		public bool HealthExaminationEmpInfoIsLeave
		{
			get; set;
		}
		public string HealthExaminationEmpInfoMemo
		{
			get; set;
		}
		public bool HealthExaminationEmpInfoIsQualified
		{
			get; set;
		}		
		public int HealthExaminationEmpInfoNextSubsidy
		{
			get; set;
		}
		public int HealthExaminationEmpInfoSkipCount
		{
			get; set;
		}

	}
	public class GetHealthExaminationEmpInfo : HealthExaminationEmpInfoAllField
	{
	}

	public class HealthExaminationApplicationsMasterAllField
	{
		public int HealthExaminationApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string HealthExaminationApplicationsMasterFillerID
		{
			get; set;
		}
		public string HealthExaminationApplicationsMasterFillerName
		{
			get; set;
		}
		public string HealthExaminationApplicationsMasterApplicationDate
		{
			get; set;
		}
	}
	public class InsertHealthExaminationApplicationsMaster : HealthExaminationApplicationsMasterAllField
	{
	}
	public class UpdateHealthExaminationApplicationsMaster : HealthExaminationApplicationsMasterAllField
	{
	}
	public class DeleteHealthExaminationApplicationsMaster : HealthExaminationApplicationsMasterAllField
	{
	}
	public class GetHealthExaminationApplicationsMaster : HealthExaminationApplicationsMasterAllField
	{
	}


	public class HealthExaminationApplicationsDetailAllField
	{
		public int HealthExaminationApplicationsDetailDetailID
		{
			get; set;
		}
		public int HealthExaminationApplicationsDetailRequisitionID
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailApplicantID
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailApplicantName
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailType
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailName
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailID
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailBirthday
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailPhoneNumber
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailSex
		{
			get; set;
		}
		public int HealthExaminationApplicationsDetailHospital
		{
			get; set;
		}
		public int HealthExaminationApplicationsDetailProjectNo
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailOptionalItems
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailAdditionItems
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailAppointmentDate1
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailAppointmentDate2
		{
			get; set;
		}
		public int HealthExaminationApplicationsDetailTotal
		{
			get; set;
		}
		public bool HealthExaminationApplicationsDetailIsCancel
		{
			get; set;
		}
		public bool HealthExaminationApplicationsDetailFinished
		{
			get; set;
		}
		public string HealthExaminationApplicationsDetailCancelDateTime
		{
			get; set;
		}
		
	}
	public class InsertHealthExaminationApplicationsDetail : HealthExaminationApplicationsDetailAllField
	{
	}
	public class UpdateHealthExaminationApplicationsDetail : HealthExaminationApplicationsDetailAllField
	{
	}
	public class GetHealthExaminationApplicationsDetail : HealthExaminationApplicationsDetailAllField
	{
	}
	public class DeleteHealthExaminationApplicationsDetail : HealthExaminationApplicationsDetailAllField
	{
	}
	

}
