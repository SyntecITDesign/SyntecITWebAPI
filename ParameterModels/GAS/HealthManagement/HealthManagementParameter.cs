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
		public int HealthExaminationOptionsBatchNum
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

	public class HealthExaminationReportsAllField
	{
		public int HealthExaminationReportsNo
		{
			get; set;
		}
		public string HealthExaminationReportsExaminatedDate
		{
			get; set;
		}
		public string HealthExaminationReportsEmpID
		{
			get; set;
		}
		public string HealthExaminationReportsEmpName
		{
			get; set;
		}
		public string HealthExaminationReportsDeptName
		{
			get; set;
		}
		public string HealthExaminationReportsGender
		{
			get; set;
		}
		public string HealthExaminationReportsBirthday
		{
			get; set;
		}
		public int HealthExaminationReportsWorkHourPerWeek
		{
			get; set;
		}
		public int HealthExaminationReportsEachWeekdaySleepHourAvg
		{
			get; set;
		}
		public string HealthExaminationReportsSelfPerceivedSymptoms
		{
			get; set;
		}
		public string HealthExaminationReportsMedicalHistory
		{
			get; set;
		}
		public float HealthExaminationReportsBH
		{
			get; set;
		}
		public float HealthExaminationReportsBW
		{
			get; set;
		}
		public float HealthExaminationReportsWaistline
		{
			get; set;
		}
		public float HealthExaminationReportsBMI
		{
			get; set;
		}
		public float HealthExaminationReportsSBP
		{
			get; set;
		}
		public float HealthExaminationReportsDBP
		{
			get; set;
		}
		public float HealthExaminationReportsUncorrected_L
		{
			get; set;
		}
		public float HealthExaminationReportsUncorrected_R
		{
			get; set;
		}
		public float HealthExaminationReportsCorrected_L
		{
			get; set;
		}
		public float HealthExaminationReportsCorrected_R
		{
			get; set;
		}
		public string HealthExaminationReportsColorVision
		{
			get; set;
		}
		public string HealthExaminationReportsPureToneAudiometry_L
		{
			get; set;
		}
		public string HealthExaminationReportsPureToneAudiometry_R
		{
			get; set;
		}
		public string HealthExaminationReportsHeadNeck
		{
			get; set;
		}
		public string HealthExaminationReportsRespiratory
		{
			get; set;
		}
		public string HealthExaminationReportsCardiovascular
		{
			get; set;
		}
		public string HealthExaminationReportsDigestive
		{
			get; set;
		}
		public string HealthExaminationReportsNervous
		{
			get; set;
		}
		public string HealthExaminationReportsSpineLimbs
		{
			get; set;
		}
		public string HealthExaminationReportsSkin
		{
			get; set;
		}
		public bool HealthExaminationReportsChewingBetelNuts
		{
			get; set;
		}
		public bool HealthExaminationReportsIsSmoker
		{
			get; set;
		}
		public bool HealthExaminationReportsIsAlcoholic
		{
			get; set;
		}
		public string HealthExaminationReportsAddictionNote
		{
			get; set;
		}
		public float HealthExaminationReportsWBC
		{
			get; set;
		}
		public float HealthExaminationReportsHb
		{
			get; set;
		}
		public float HealthExaminationReportsTG
		{
			get; set;
		}
		public float HealthExaminationReportsTC
		{
			get; set;
		}
		public float HealthExaminationReportsHDL
		{
			get; set;
		}
		public float HealthExaminationReportsLDL
		{
			get; set;
		}
		public float HealthExaminationReportsACSugar
		{
			get; set;
		}
		public float HealthExaminationReportsALT_GPT
		{
			get; set;
		}
		public float HealthExaminationReportsCr
		{
			get; set;
		}
		public string HealthExaminationReportsU_OB
		{
			get; set;
		}
		public string HealthExaminationReportsUrineProtein
		{
			get; set;
		}
		public string HealthExaminationReportsXRay
		{
			get; set;
		}
		public bool HealthExaminationReportsMetabolicSyndrome
		{
			get; set;
		}
		public float HealthExaminationReportsTenYearsCVDRisk
		{
			get; set;
		}
		public int HealthExaminationReportsGrading
		{
			get; set;
		}
		public string HealthExaminationReportsMemo
		{
			get; set;
		}

	}
	public class InsertHealthExaminationReports : HealthExaminationReportsAllField
	{
	}
	public class UpdateHealthExaminationReports : HealthExaminationReportsAllField
	{
	}
	public class GetHealthExaminationReports : HealthExaminationReportsAllField
	{
	}
	public class DeleteHealthExaminationReports : HealthExaminationReportsAllField
	{
	}


	public class HealthExaminationCheckListsAllField
	{
		public int HealthExaminationCheckListsNo
		{
			get; set;
		}
		public string HealthExaminationCheckListsUsage
		{
			get; set;
		}
		public string HealthExaminationCheckListsItems
		{
			get; set;
		}
		public float HealthExaminationCheckListsMIN
		{
			get; set;
		}
		public float HealthExaminationCheckListsMAX
		{
			get; set;
		}
		public float HealthExaminationCheckListsFemaleScore
		{
			get; set;
		}
		public float HealthExaminationCheckListsMaleScore
		{
			get; set;
		}
		public string HealthExaminationCheckListsMemo
		{
			get; set;
		}
	}
	
	public class GetHealthExaminationCheckLists : HealthExaminationCheckListsAllField
	{
	}

}
