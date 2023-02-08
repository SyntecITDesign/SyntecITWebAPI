//using SyntecITWebAPI.ParameterModels.DecodePW;
//using System;
//using System.Collections;

//namespace SyntecITWebAPI.Models.Decode.SecretDLL
//{
//	public class FormalSecretDLL : ISecretDLL
//	{
//		#region Public Methods

// string ISecretDLL.DLLGenerateDecodeDatePW(DecodeDatePWParameter decodeDatePWParameter) { try {
// string result = null; Validity if (decodeDatePWParameter.timeType == "Before") { result =
// Syntec.Validity.Password.SWUT_getOldDayPassword(decodeDatePWParameter.verifyCode,
// decodeDatePWParameter.dueDateDetail.ToString()); } else if (decodeDatePWParameter.timeType ==
// "After") { result =
// Syntec.Validity.Password.SWUT_getV112DayPassword(decodeDatePWParameter.verifyCode,
// decodeDatePWParameter.dueDateDetail.ToString()); }

// return result; } catch { throw new Exception("lost of Validity or TQML DLL"); } }

// string ISecretDLL.DLLGenerateDecodeHardWarePW(DecodeHWParameter decodeHWParameter) { try {
// Validity string result = Syntec.Validity.Password.SWUT_getHardwarePassword(decodeHWParameter.verifyCode);

// return result; } catch { throw new Exception("lost of Validity or TQML DLL"); } }

// string ISecretDLL.DLLGenerateDecodeServoPW(DecodeServoParameter decodeServoParameter) { try {
// ushort verifyCodeushort = ushort.Parse(decodeServoParameter.verifyCode); PasswordLib string
// result = PasswordLib.PasswordCalc.PasswordGen(Convert.ToUInt32(decodeServoParameter.versionSN), verifyCodeushort).ToString();

// return result; } catch { throw new Exception("lost of Validity or TQML DLL"); } }

// string ISecretDLL.DLLGenerateDecodeUnlimitPW(DecodeDatePWParameter decodeUnlimitPWParameter) {
// try { string result = null; Validity if (decodeUnlimitPWParameter.timeType == "Before") { result
// = Syntec.Validity.Password.SWUT_getOldPassword(decodeUnlimitPWParameter.verifyCode); } else if
// (decodeUnlimitPWParameter.timeType == "After") { result =
// Syntec.Validity.Password.SWUT_getV112Password(decodeUnlimitPWParameter.verifyCode); }

// return result; } catch { throw new Exception("lost of Validity or TQML DLL"); } }

// string ISecretDLL.DLLGenerateDecodeMonthPW(DecodeDatePWParameter decodeMonthPWParameter) { try {
// string result = null; Validity if (decodeUnlimitPWParameter.timeType == "Before") { result =
// Syntec.Validity.Password.SWUT_getOldMonPassword(decodeMonthPWParameter.verifyCode,
// decodeMonthPWParameter.dueDateDetail.ToString()); } else if (decodeUnlimitPWParameter.timeType ==
// "After") { result =
// Syntec.Validity.Password.SWUT_getV112MonPassword(decodeMonthPWParameter.verifyCode,
// decodeMonthPWParameter.dueDateDetail.ToString()); }

// return result; } catch { throw new Exception("lost of Validity or TQML DLL"); } }

// void ISecretDLL.DLLGetPassEncodeVer(bool version, string verifyCode) {
// Syntec.Validity.PasswordAPI.getPassEncodeVer(version, verifyCode); }

// void ISecretDLL.DLLSetLang(string lang) { Syntec.Validity.MultiLang.InitMultiLangResource();
// Syntec.Validity.MultiLang.switchLang(lang); }

// string ISecretDLL.DLLGeneratePwdV1(GeneratePwdV1Parameter generatePwdV1Parameter) { switch
// (generatePwdV1Parameter.timeType) { case "Date": return
// Syntec.Validity.Password.SWUT_getDayPassword_V2 ( generatePwdV1Parameter.customerCode,
// generatePwdV1Parameter.verifyCode, generatePwdV1Parameter.userID,
// generatePwdV1Parameter.dueDateDetail.ToString() );

// case "Month": return Syntec.Validity.Password.SWUT_getMonPassword_V2 (
// generatePwdV1Parameter.customerCode, generatePwdV1Parameter.verifyCode,
// generatePwdV1Parameter.userID, generatePwdV1Parameter.dueDateDetail.ToString() );

// case "Unlimit": return Syntec.Validity.Password.SWUT_getMonPassword_V2 (
// generatePwdV1Parameter.customerCode, generatePwdV1Parameter.verifyCode,
// generatePwdV1Parameter.userID, 0.ToString() );

// default: return null; } } string ISecretDLL.DLLGeneratePwdV3_1(GeneratePwdV2Parameter
// generatePwdV2Parameter, string specificKey) { switch (generatePwdV2Parameter.timeType) { case
// "Date": return Syntec.Validity.Password.SWUT_getDayPassword_V3_1 (
// generatePwdV2Parameter.customerCode, generatePwdV2Parameter.verifyCode,
// generatePwdV2Parameter.dueDateDetail.ToString(), specificKey );

// case "Month": return Syntec.Validity.Password.SWUT_getMonPassword_V3_1 (
// generatePwdV2Parameter.customerCode, generatePwdV2Parameter.verifyCode,
// generatePwdV2Parameter.dueDateDetail.ToString(), specificKey );

// case "Unlimit": return Syntec.Validity.Password.SWUT_getMonPassword_V3_1 (
// generatePwdV2Parameter.customerCode, generatePwdV2Parameter.verifyCode, 0.ToString(), specificKey );

// default: return null; } }

// string ISecretDLL.DLLGeneratePwdV3_2(GeneratePwdV2Parameter generatePwdV2Parameter, string
// specificKey) { switch (generatePwdV2Parameter.timeType) { case "Date": return
// Syntec.Validity.Password.SWUT_getDayPassword_V3_2 ( generatePwdV2Parameter.productSN,
// generatePwdV2Parameter.customerCode, generatePwdV2Parameter.verifyCode,
// generatePwdV2Parameter.dueDateDetail.ToString(), specificKey );

// case "Month": return Syntec.Validity.Password.SWUT_getMonPassword_V3_2 (
// generatePwdV2Parameter.productSN, generatePwdV2Parameter.customerCode,
// generatePwdV2Parameter.verifyCode, generatePwdV2Parameter.dueDateDetail.ToString(), specificKey );

// case "Unlimit": return Syntec.Validity.Password.SWUT_getMonPassword_V3_2 (
// generatePwdV2Parameter.productSN, generatePwdV2Parameter.customerCode,
// generatePwdV2Parameter.verifyCode, 0.ToString(), specificKey );

// default: return null; } }

// ArrayList ISecretDLL.DLLGetCheckNoStatus(string machineCode, string verifyCode) { return
// Syntec.Validity.PasswordAPI.GetCheckNoStatus(machineCode, verifyCode); }

// string ISecretDLL.DLLCalculateCncCheckNo(string productSN, string fullverifyCode) { return
// Syntec.Validity.ResAPI.SWUT_CalculateCncCheckNo(productSN, fullverifyCode); }

// string ISecretDLL.DLLGetNewSpecificKey() { return
// Syntec.Validity.Password.SWUT_getNewSpecificKey(); }

// void ISecretDLL.DLLSetPasswordType(string passwordType) {
// Syntec.Validity.PasswordAPI.m_PasswordType = passwordType; }

// bool ISecretDLL.DLLCheckPassVerV3_1() { return (Syntec.Validity.PasswordAPI.m_PassVer ==
// Syntec.Validity.PasswordAPI.PassVer.V3_1); }

// bool ISecretDLL.DLLCheckPassVerV3_2() { return (Syntec.Validity.PasswordAPI.m_PassVer ==
// Syntec.Validity.PasswordAPI.PassVer.V3_2); }

// public void DLLPutMachineType(string machineType) {
// Syntec.Validity.Password.SWUT_putMachineType(machineType); }

// public void DLLPutAxis(int axis) { Syntec.Validity.Password.SWUT_putEnabledAxesNumber(axis); }

// public string DLLGetOptionPassword(int[] optionArray, string productSN, string verifyCode) {
// return Syntec.Validity.Password.SWOP_getOptionPassword(optionArray, productSN, verifyCode); }

// public string DLLGetRestorePassword(int[] optionArray, string machineType, string productSN,
// string verifyCode) { return Syntec.Validity.Password.SWOP_getRestorePassword(optionArray,
// machineType, productSN, verifyCode); }

//		#endregion Public Methods
//	}
//}
