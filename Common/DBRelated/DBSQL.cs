using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated
{
	public class DBSQL
	{
		#region Public Properties



		public string CHECK_CNCTYPE_MACHINEMODEL_EXIST
		{
			get
			{
				return $@"SELECT 1
						FROM [{m_barcode}].[dbo].[sbcMachineOption]
						WHERE
						EXISTS(SELECT * FROM [syntecbarcode].[dbo].[sbcMachineOption] WHERE [CNCType] = @Parameter0)
						AND EXISTS
						(SELECT * FROM [syntecbarcode].[dbo].[sbcMachineOption] WHERE [ModelType] = @Parameter1)";
			}
		}

		public string CHECK_EMAIL_EXIST
		{
			get
			{
				return $@"SELECT * FROM [{m_option}].[dbo].[OptionUser]
						WHERE EMail = @Parameter0
						";
			}
		}

		public string CHECK_FRTOKEN_EXIST
		{
			get
			{
				return $@"SELECT 1
						  FROM [{m_cloud}].[dbo].[frtoken_list]
						  WHERE [fr_token] = @Parameter0";
			}
		}

		public string CHECK_MACHINECODE_EXIST
		{
			get
			{
				return $@"SELECT * FROM [{m_option}].[dbo].[OptionUser]
						WHERE OptionMachineCode = @Parameter0
						";
			}
		}

		public string CHECK_SYNTEC_USER_EMAIL_EXIST
		{
			get
			{
				return $@"SELECT *
					  FROM [{m_barcode}].[dbo].[TEMP_NAME]
					  WHERE EmpID = @Parameter0 AND Email = @Parameter1";
			}
		}

		public string CHECK_SYNTEC_USER_EXIST
		{
			get
			{
				return $@"SELECT *
					  FROM [{m_barcode}].[dbo].[TEMP_NAME]
					  WHERE EmpID = @Parameter0 ";
			}
		}

		public string CHECK_USER_EMAIL_EXIST_BY_ID
		{
			get
			{
				return $@"SELECT * FROM [{m_option}].[dbo].[OptionUser]
						WHERE UserID = @Parameter0 AND Email = @Parameter1";
			}
		}

		public string CHECK_USER_VERIFYCODE_EXIST
		{
			get
			{
				return $@"SELECT * FROM [{m_option}].[dbo].[OptionUser]
						WHERE UserID = @Parameter0 AND VerifyCode = @Parameter1";
			}
		}

		public string DELETE_NEWS_BY_INDEX
		{
			get
			{
				return $@"DELETE FROM [{m_option}].[dbo].[latest_news]
						WHERE news_id = @Parameter0
						";
			}
		}

		public string GET_ALL_NEWS_IN_LAST_MONTH
		{
			get
			{
				return $@"SELECT * FROM [{m_option}].[dbo].[latest_news]
						WHERE [modi_date] > @parameter0
						";
			}
		}

		public string GET_FR_TOKEN_BY_ID
		{
			get
			{
				return $@"SELECT *
						FROM [{m_cloud}].[dbo].[frtoken_list]
						WHERE [customer_id] = @parameter0";
			}
		}

		public string GET_MANAGE_NAME_EMAIL
		{
			get
			{
				return $@"SELECT EmpName,Email FROM [{m_barcode}].[dbo].[TEMP_NAME]
						WHERE OptionRoles LIKE '%8,%' AND QuitDate is NULL
						AND (Email <> '' AND Email != 'nan' )";
			}
		}

		public string GET_ORGTYPE_BY_ORGID
		{
			get
			{
				return $@"SELECT *
						FROM [{m_barcode}].[dbo].[sbcOrganization]
						WHERE [OrgID] = @Parameter0";
			}
		}

		public string GET_RIGHTS_BY_ROLES
		{
			get
			{
				return $@"SELECT [Rights]
						FROM [{m_option}].[dbo].[ROLES]
						WHERE [Code]= @Parameter0";
			}
		}

		public string GET_ROLES_BY_ID
		{
			get
			{
				return $@"SELECT [Roles] FROM [{m_option}].[dbo].[OptionUser] WHERE [UserID] = @Parameter0";
			}
		}

		public string GET_STATUS_BY_ID
		{
			get
			{
				return $@"SELECT Status FROM [{m_option}].[dbo].[OptionUser]
						WHERE UserID = @Parameter0";
			}
		}

		public string GET_USER_BY_ID
		{
			get
			{
				return $@"SELECT * FROM[{m_option}].[dbo].[OptionUser]
						WHERE UserID = @Parameter0";
			}
		}

		public string GET_USERNAME_BY_ID_OPTION
		{
			get
			{
				return $@"SELECT [UserName]
						FROM [{m_option}].[dbo].[OptionUser]
						WHERE UserID = @Parameter0";
			}
		}

		public string GET_USERNAME_BY_ID_TEMPNAME
		{
			get
			{
				return $@"SELECT [EmpName]
						FROM [{m_barcode}].[dbo].[TEMP_NAME]
						WHERE EmpID = @Parameter0";
			}
		}

		public string INSERT_DECODE_HISTORY_RECORD
		{
			get
			{
				return $@"INSERT INTO [{m_option}].[dbo].[HISTORY_RECORD]
						(SN,CheckNo,PassWord,ConsUser,Code,Attr,Attr2,ConsDate)
						VALUES
						(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7)
						";
			}
		}

		public string INSERT_FR_TOKEN
		{
			get
			{
				return $@"INSERT INTO [{m_cloud}].[dbo].[frtoken_list]
						([customer_id],[customer_ip],[fr_token],[cons_date],[expire_date],[modi_date])
						VALUES
						(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5)
						";
			}
		}

		public string INSERT_LATEST_NEWS
		{
			get
			{
				return $@"INSERT INTO [{m_option}].[dbo].[latest_news]
						(title,content,cons_id,modi_id,cons_date,modi_date)
						OUTPUT Inserted.news_id
						VALUES(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5)
						";
			}
		}

		public string INSERT_USER_ALL_DATA
		{
			get
			{
				return $@"INSERT INTO [{m_option}].[dbo].[OptionUser]
						(UserID,UserName,UserPwd,OptionMachineCode,CompanyName,
						Address,Email,Cellphone,Skype,Line,
						QQ,WeChat,OrgType,VerifyCode,PWChanged,
						isMother,inUse,Status,isNotifyMother,CreateDate)
						VALUES
						(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,
						@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,
						@Parameter10,@Parameter11,@Parameter12,@Parameter13,@Parameter14,
						@Parameter15,@Parameter16,@Parameter17,@Parameter18,@Parameter19)";
			}
		}

		public string UPDATE_NEWS_BY_INDEX
		{
			get
			{
				return $@"UPDATE [{m_option}].[dbo].[latest_news]
						SET [title] = @Parameter0, [content] = @Parameter1 , [modi_id] = @Parameter2, [modi_date] = @Parameter3
						WHERE [news_id] = @Parameter4
						";
			}
		}

		public string UPDATE_REFRESHTOKEN_USAGE_TIMES
		{
			get
			{
				return $@"UPDATE [{m_cloud}].[dbo].[token_list]
						SET
							usage_time = usage_time + 1,
							modi_date = @Parameter0
						WHERE
							customer_id = @Parameter1 AND
							customer_ip = @Parameter2 AND
							refresh_token = @Parameter3;
						";
			}
		}

		public string UPDATE_USER_PWCHANGED
		{
			get
			{
				return $@"UPDATE [{m_option}].[dbo].[OptionUser]
						SET PWChanged = @Parameter0
						WHERE UserID = @Parameter1";
			}
		}

		public string UPDATE_USER_STATUS
		{
			get
			{
				return $@"UPDATE [{m_option}].[dbo].[OptionUser]
						SET Status = @Parameter0
						WHERE UserID = @Parameter1";
			}
		}

		public string UPDATE_USER_VERIFYCODE
		{
			get
			{
				return $@"UPDATE [{m_option}].[dbo].[OptionUser]
						SET VerifyCode = @Parameter0
						WHERE UserID = @Parameter1";
			}
		}

		public string UPDATE_USERPASSWORD_BY_ID
		{
			get
			{
				return $@"UPDATE [{m_option}].[dbo].[OptionUser]
						SET UserPwd = @Parameter0, PWChanged = -1
						WHERE UserID = @Parameter1";
			}
		}

		public string GetCRMOSSFileLink
		{
			get
			{
				return $@"SELECT distinct  R.[crmid],CRM.issuekey as jiraid,CRM.created,CRM.signdate,R.[url],R.[title]
						  FROM [{m_jirareport}].[dbo].[remotelink] R
						  left join [{m_jirareport}].[dbo].CRM on R.CRMID = CRM.crmid 
						  where R.[crmid] in {{CRMID_REPLACE}}  and R.title like @Parameter0  ";
			}
		}

		public string UpsertAlarm
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_Alarm WHERE serial_number=@Parameter0 and [time] = @Parameter1 
							and [alarm_id]=@Parameter2 and [alarm_info]=@Parameter3)
							UPDATE [{m_crm}].[dbo].SynService_Alarm SET [duration]=@Parameter4, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))  
							WHERE serial_number=@Parameter0 and [time] = @Parameter1 and [alarm_id]=@Parameter2 and [alarm_info]=@Parameter3
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_Alarm ([serial_number],[time],[alarm_id],[alarm_info],[duration],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}
		
		public string UpsertCNCStateLog
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_CNCStateLog WHERE serial_number=@Parameter0 and [time] = @Parameter1 and [state_type_id]=@Parameter2)
							UPDATE [{m_crm}].[dbo].SynService_CNCStateLog SET [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))  
							WHERE serial_number=@Parameter0 and [time] = @Parameter1 and [state_type_id]=@Parameter2
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_CNCStateLog ([serial_number],[time],[state_type_id],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertCRM
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_CRM WHERE serial_number=@Parameter0 and [crm_number] = @Parameter1)
							UPDATE [{m_crm}].[dbo].SynService_CRM SET [crm_start_time]=@Parameter2,[crm_end_time]=@Parameter3, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and [crm_number] = @Parameter1
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_CRM ([serial_number],[crm_number],[crm_start_time],[crm_end_time],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertExceptionLog
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_ExceptionLog WHERE serial_number=@Parameter0 and exception_type_id = @Parameter1 and [time] = @Parameter3)
							UPDATE [{m_crm}].[dbo].SynService_ExceptionLog SET [version]=@Parameter2,[exception_info]=@Parameter4,[physical_memory]=@Parameter5,[diskA_space]=@Parameter6,[diskC_space]=@Parameter7, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and exception_type_id = @Parameter1 and [time] = @Parameter3
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_ExceptionLog ([serial_number],[exception_type_id],[version],[time],[exception_info],[physical_memory],[diskA_space],[diskC_space],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertUnStableIndex
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_UnStableIndex WHERE serial_number=@Parameter0 and [time] = @Parameter1 AND  [unstable_type_id]=@Parameter2)
							UPDATE [{m_crm}].[dbo].SynService_UnStableIndex SET [detail_json]=@Parameter3, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and [time] = @Parameter1 and  [unstable_type_id]=@Parameter2
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_UnStableIndex ([serial_number],[time],[unstable_type_id],[detail_json],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3,DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertUnStableIndexV2
		{
			get {
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_UnStableIndexV2 WHERE serial_number=@Parameter0 and [time] = @Parameter1 AND  [is_bootup]=@Parameter2  
									AND  [bootup_time]=@Parameter3 AND  [cnc_version]=@Parameter4 AND  [first_driver_version]=@Parameter5 AND  [second_driver_version]=@Parameter6)
							UPDATE [{m_crm}].[dbo].SynService_UnStableIndexV2 SET [detail_json]=@Parameter7, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and [time] = @Parameter1 AND  [is_bootup]=@Parameter2  AND  [bootup_time]=@Parameter3 
									AND  [cnc_version]=@Parameter4 AND  [first_driver_version]=@Parameter5 AND  [second_driver_version]=@Parameter6
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_UnStableIndexV2 ([serial_number],[time],[is_bootup],[bootup_time],[cnc_version],[first_driver_version],[second_driver_version],[detail_json],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7,DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertEventTypeList
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_event_type_list WHERE event_type_id=@Parameter0 )
							UPDATE [{m_crm}].[dbo].SynService_event_type_list SET [event_type]=@Parameter1, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE event_type_id=@Parameter0
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_event_type_list ([event_type_id],[event_type],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertStopTypeList
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_stop_type_list WHERE stop_type_id=@Parameter0 )
							UPDATE [{m_crm}].[dbo].SynService_stop_type_list SET [stop_type]=@Parameter1, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE stop_type_id=@Parameter0
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_stop_type_list ([stop_type_id],[stop_type],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertAlarmHistory
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_alarm_history WHERE serial_number=@Parameter0 and start_time = @Parameter1 and [alarm_id]=@Parameter3 and [alarm_info]=@Parameter4 )
							UPDATE [{m_crm}].[dbo].SynService_alarm_history SET end_time = @Parameter2,[alarm_trigger]=@Parameter5, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and start_time = @Parameter1 and [alarm_id]=@Parameter3 and [alarm_info]=@Parameter4
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_alarm_history ([serial_number],[start_time],[end_time],[alarm_id],[alarm_info],[alarm_trigger],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertEventHistory
		{
			get
			{
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_event_history WHERE serial_number=@Parameter0 and start_time = @Parameter1 and  [event_type_id]=@Parameter3 )
							UPDATE [{m_crm}].[dbo].SynService_event_history SET end_time = @Parameter2,[stop_type_id]=@Parameter4, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 and start_time = @Parameter1 and  [event_type_id]=@Parameter3
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_event_history ([serial_number],[start_time],[end_time],[event_type_id],[stop_type_id],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertMachineInfo
		{
			get {
				return $@"IF EXISTS (SELECT * FROM [{m_crm}].[dbo].SynService_MachineInfo WHERE crm_number=@Parameter0 and serial_number = @Parameter1 and  [axis]=@Parameter19 )
							UPDATE [{m_crm}].[dbo].SynService_MachineInfo SET [machine_model] = @Parameter2,[machine_type]=@Parameter3, [cnc_version]=@Parameter4, [prd_version]=@Parameter5,
								[cpu_board]= @Parameter6,[fpga]=@Parameter7, [image_version]=@Parameter8,[option]=@Parameter9,[machine_id]=@Parameter10,[maker_model]=@Parameter11, 
								[maker_sn]=@Parameter12,[maker_date]=@Parameter13, [developer_sn]=@Parameter14,[phone]=@Parameter15,[use_limit]=@Parameter16,[maker_id]=@Parameter17, 
								[plc_version]=@Parameter18,[drive_model]=@Parameter20, [drive_version]=@Parameter21,[motor_model]=@Parameter22,[enc_model]=@Parameter23,[enc_version]=@Parameter24, 
								[enc_resolution]=@Parameter25,[enc2_model]=@Parameter26, [enc2_version]=@Parameter27,[enc2_resolution]=@Parameter28,[addon_model]=@Parameter29,
								[addon_version]=@Parameter30, [drive_sn]=@Parameter31,[motor_sn]=@Parameter32, [enc_sn]=@Parameter33,[enc2_sn]=@Parameter33,[addon_sn]=@Parameter34,
								[modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))  		
						WHERE crm_number=@Parameter0 and serial_number = @Parameter1 and  axis=@Parameter19
						ELSE
						INSERT INTO [{m_crm}].[dbo].SynService_MachineInfo ([crm_number],[serial_number],[machine_model],[machine_type],[cnc_version],[prd_version],[cpu_board],[fpga],
								[image_version],[option],[machine_id],[maker_model],[maker_sn],[maker_date],[developer_sn],[phone],[use_limit],[maker_id],[plc_version],[axis],[drive_model],
								[drive_version],[motor_model],[enc_model],[enc_version],[enc_resolution],[enc2_model],[enc2_version],[enc2_resolution],[addon_model],[addon_version],
								[drive_sn],[motor_sn],[enc_sn],[enc2_sn],[addon_sn],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4,@Parameter5, @Parameter6, @Parameter7,
								@Parameter8, @Parameter9,@Parameter10, @Parameter11, @Parameter12, @Parameter13, @Parameter14,@Parameter15, @Parameter16, @Parameter17,@Parameter18, @Parameter19, @Parameter20,
								@Parameter21, @Parameter22,@Parameter23, @Parameter24, @Parameter25, @Parameter26, @Parameter27,@Parameter28, @Parameter29, @Parameter30,
								@Parameter31, @Parameter32, @Parameter33, @Parameter34, @Parameter35,DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertDailyRecord
		{
			get {
				return $@"
						INSERT INTO [{m_crm}].[dbo].SynService_DailyRecord ([serial_number],[time],[detail_json],[cons_date],[modi_date],[crm_number],[drv_model],[drv_SN]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )),@Parameter3,@Parameter4,@Parameter5)"; 
			}
		}

		public string UpsertEncryption
		{
			get {
				return $@"IF EXISTS (SELECT * FROM [{m_dwh}].[dbo].SynSerivce_Encryption WHERE serial_number=@Parameter0 and (oplog_encryption_time is  null or oplog_encryption_time = '' )  )
							UPDATE [{m_dwh}].[dbo].SynSerivce_Encryption SET oplog_encryption_time = @Parameter1, [modi_date]=DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() ))
							WHERE serial_number=@Parameter0 
						IF NOT EXISTS (SELECT * FROM [dwh].[dbo].SynSerivce_Encryption WHERE serial_number=@Parameter0 )
						INSERT INTO [{m_dwh}].[dbo].SynSerivce_Encryption ([serial_number],[oplog_encryption_time],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))  ";
			}
		}

		public string UpsertHardwareInfo
		{
			get {
				return $@"
						INSERT INTO [{m_crm}].[dbo].[SALE_DM_SYNSERVICEHARDWAREINFO] ([serial_number],[boot_time],[axis_name],[drv_type],[drv_sn],[motor_sn],[first_enc_sn],[second_enc_sn],[cpu_board],[fpga],[cnc_ver],[image_ver],[drv_ver],[first_enc_ver],[second_enc_ver],[cons_date],[modi_date]) 
						VALUES (@Parameter0, @Parameter1, @Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11,@Parameter12,@Parameter13,@Parameter14, DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )), DATEDIFF_BIG(ms, '1970-01-01 00:00:00', DATEADD(HOUR, -8, GETDATE() )))";
			}
		}

		public string InsertWXMessage
		{
			get {
				return $@"INSERT INTO [{m_syntecbbs}].[dbo].[SendWX] (SendOpenid,Title,ContentBody,CreatDate,CurrentStatus,SourcePlatform,
                                                MasterID,MasterType,keyword1,keyword2,keyword3,keyword4,keyword5,URL,KeyWords,FlowStatus)
                                                VALUES
                                                (@Parameter0,@Parameter1,@Parameter2,GETDATE(),N'0',@Parameter4,
                                                @Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9,@Parameter10,@Parameter11,@Parameter12,@Parameter3,@Parameter13)";
			}
		}

		#endregion Public Properties

		#region Public Methods

		public static DBSQL GetInstance()
		{
			if( Instance == null )
			{
				lock( LockObject )
				{ //確保單一
					if( Instance == null )
					{
						Instance = new DBSQL();
					}
				}
			}
			return Instance;
		}

		#endregion Public Methods

		#region Private Fields

		private static readonly object LockObject = new object();
		private static DBSQL Instance = null;
		private string m_barcode;
		private string m_cloud;
		private string m_option;
		private string m_jirareport;
		private string m_crm;
		private string m_gas;
		private string m_syntecbbs;
		private string m_dwh;


		#endregion Private Fields

		#region Private Constructors + Destructors

		private DBSQL()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_option = configuration[ "option" ].Trim();
			m_barcode = configuration[ "barcode" ].Trim();
			m_cloud = configuration[ "cloud" ].Trim();
			m_jirareport = configuration["jirareport"].Trim();
			m_crm = configuration["crm"].Trim();
			m_gas = configuration["gas"].Trim();
			m_syntecbbs = configuration["SyntecBBS"].Trim();
			m_dwh = configuration[ "dwh" ].Trim();
		}

		#endregion Private Constructors + Destructors
	}
}
