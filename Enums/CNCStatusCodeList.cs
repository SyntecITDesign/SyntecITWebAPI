namespace SyntecITWebAPI.Enums
{
	public enum CNCStatusCodeList
	{
		Unlimit_Date_Valid_Use = '0', //	正常無期限
		Limit_Date_Valid_Use = '1', //	有設使用期限, 正常使用中
		Hardware_Invalid_Motherboard = '2', //更換主板, 硬體不符 (現已取消)
		Hardware_Invalid_IOcard_CFcard = '3', // 同時更換IO卡, CF卡 , 硬體不符 (現已取消)
		Limit_Date_Invalid_Change_Date = '4', // 有設使用期限, 但修改時間, 造成系統鎖住
		V2_V3_Invalid_Update = '5', // V2/V3 降版破解, 再升版
		Fail_Read_Motherboard_Mac = '6', // 主板mac 讀取失敗 (現已取消)
		Limit_Date_Valid_Use_V3 = '7', // V3版有設使用期限, 正常使用中
		Limit_Date_Invalid_Change_Date_V3 = '8', // V3版有設使用期限, 但修改時間, 造成系統鎖住

		Unlimit_Date_V3_1 = 'A', // A : 控制器無使用期限, 加密後會設定成V3.1版格式
		Limit_Date_Valid_Use_V3_1 = 'B', // B : V3.1版有設使用期限, 正常使用中
		Limit_Date_Invalid_Change_Date_V3_1 = 'C', // C : V3.1版有設使用期限, 但修改時間, 造成系統鎖住
		Unknown_D = 'D', //未知
		Unknown_E = 'E', //未知
		Unknown_F = 'F'  //未知
	}
}
