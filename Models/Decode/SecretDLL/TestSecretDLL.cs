using SyntecITWebAPI.ParameterModels.DecodePW;
using System.Collections;
using System.Diagnostics;

namespace SyntecITWebAPI.Models.Decode.SecretDLL
{
	internal class TestSecretDLL : ISecretDLL
	{
		#region Public Methods

		string ISecretDLL.DLLCalculateCncCheckNo( string productSN, string fullverifyCode )
		{
			return $"8";
		}

		bool ISecretDLL.DLLCheckPassVerV3_1()
		{
			return false;
		}

		bool ISecretDLL.DLLCheckPassVerV3_2()
		{
			return true;
		}

		string ISecretDLL.DLLGenerateDecodeDatePW( DecodeDatePWParameter decodeDatePWParameter )
		{
			return "test DecodeDate PW";
		}

		string ISecretDLL.DLLGenerateDecodeHardWarePW( DecodeHWParameter decodeHWParameter )
		{
			return "test DecodeHardWare PW";
		}

		string ISecretDLL.DLLGenerateDecodeMonthPW( DecodeDatePWParameter decodeMonthPWParameter )
		{
			return "test DecodeMonth PW";
		}

		string ISecretDLL.DLLGenerateDecodeServoPW( DecodeServoParameter decodeServoParameter )
		{
			return "test DecodeServo PW";
		}

		string ISecretDLL.DLLGenerateDecodeUnlimitPW( DecodeDatePWParameter decodeUnlimitPWParameter )
		{
			return "test DecodeUnlimit PW";
		}

		string ISecretDLL.DLLGeneratePwdV1( GeneratePwdV1Parameter generatePwdV1Parameter )
		{
			return $"test GeneratePwdV1 {generatePwdV1Parameter.timeType} : {generatePwdV1Parameter.dueDateDetail} ";
		}

		string ISecretDLL.DLLGeneratePwdV3_1( GeneratePwdV2Parameter generatePwdV2Parameter, string specificKey )
		{
			return $"test GeneratePwdV3_1 {generatePwdV2Parameter.timeType} : {generatePwdV2Parameter.dueDateDetail}";
		}

		string ISecretDLL.DLLGeneratePwdV3_2( GeneratePwdV2Parameter generatePwdV2Parameter, string specificKey )
		{
			return $"test GeneratePwdV3_2 {generatePwdV2Parameter.timeType} : {generatePwdV2Parameter.dueDateDetail}";
		}

		ArrayList ISecretDLL.DLLGetCheckNoStatus( string machineCode, string verifyCode )
		{
			return new ArrayList { "status1", "status2", "status3" };
		}

		string ISecretDLL.DLLGetNewSpecificKey()
		{
			return "5824";
		}

		public string DLLGetOptionPassword( int[] optionArray, string productSN, string verifyCode )
		{
			return ( $"test DLLGetOptionPassword " );
		}

		void ISecretDLL.DLLGetPassEncodeVer( bool version, string verifyCode )
		{
			Debug.Write( $"Syntec.Validity.PasswordAPI.getPassEncodeVer({version},{verifyCode})" );
		}

		public string DLLGetRestorePassword( int[] optionArray, string machineType, string productSN, string verifyCode )
		{
			return ( $"test DLLGetRestorePassword " );
		}

		public void DLLPutAxis( int axis )
		{
			Debug.Write( $"Syntec.Validity.Password.SWUT_putEnabledAxesNumber = {axis}" );
		}

		public void DLLPutMachineType( string cncType )
		{
			Debug.Write( $"Syntec.Validity.Password.SWUT_putMachineType = {cncType}" );
		}

		void ISecretDLL.DLLSetLang( string lang )
		{
			Debug.Write( $"Syntec.Validity.MultiLang.InitMultiLangResource(); \n Syntec.Validity.MultiLang.switchLang({lang});" );
		}

		void ISecretDLL.DLLSetPasswordType( string passwordType )
		{
			Debug.Write( $"Syntec.Validity.PasswordAPI.m_PasswordType = {passwordType}" );
		}

		#endregion Public Methods
	}
}
