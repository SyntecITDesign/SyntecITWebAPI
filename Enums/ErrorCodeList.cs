namespace SyntecITWebAPI.Enums
{
	//Return Code List document https://confluence.syntecclub.com.tw/x/hqRYAg
	public enum ErrorCodeList
	{
		Success = 0,

		//System Related
		System_Error = 10001,

		Service_Unavailable = 10002,
		Remote_Service_Error = 10003,
		IP_Limit = 10004,
		Illegal_Request = 10005,
		Token_Missing = 10006,
		Unsupport_Mediatype = 10007,
		Param_Error = 10008,
		System_Busy = 10009,
		Job_Expired = 10010,
		RPC_Error = 10011,
		Partial_Data_Error = 10012,
		Time_Out = 10013,
		Mail_Failed = 10014,
		Decode_Failed = 10015,
		WeChat_GetOpenID_Error = 10016,
		API_Internet_Error = 10018,

		//DB Related
		Insert_Problem_Type_Wrong = 20001,

		Insert_Problem_KeyColumn_Exist = 20002,
		Update_Problem_Type_Wrong = 20003,
		Update_Problem_KeyColumn_Miss = 20004,
		Select_Problem_No_Data = 20005,
		Update_Error = 20006,
		Insert_Error = 20007,
		Upsert_Error = 20008,

		//Right Related
		Password_Wrong = 30001,

		No_Right_to_Access = 30002,
		UserID_UnExist = 30003,
		Account_Quit = 30004,
		Verify_Fail = 30005,
		ID_SameAs_Password = 30006,
		Auth_Error = 30007,
		Machine_Number_Limit = 30008,
		Token_Expired = 30009,
		Password_Need_Change = 30010,
		Cookie_Error = 30011,
		WeChat_First_Login = 30012,

		//Parameters Related
		Input_Type_Wrong = 40001
	}
}
