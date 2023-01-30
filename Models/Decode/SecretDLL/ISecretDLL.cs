using SyntecITWebAPI.ParameterModels.DecodePW;
using System.Collections;

namespace SyntecITWebAPI.Models.Decode.SecretDLL
{
	internal interface ISecretDLL
	{
		#region Public Methods

		string DLLCalculateCncCheckNo( string productSN, string fullverifyCode );

		bool DLLCheckPassVerV3_1();

		bool DLLCheckPassVerV3_2();

		string DLLGenerateDecodeDatePW( DecodeDatePWParameter decodeDatePWParameter );

		string DLLGenerateDecodeHardWarePW( DecodeHWParameter decodeHWParameter );

		string DLLGenerateDecodeMonthPW( DecodeDatePWParameter decodeMonthPWParameter );

		string DLLGenerateDecodeServoPW( DecodeServoParameter decodeServoParameter );

		string DLLGenerateDecodeUnlimitPW( DecodeDatePWParameter decodeUnlimitPWParameter );

		string DLLGeneratePwdV1( GeneratePwdV1Parameter generatePwdV1Parameter );

		string DLLGeneratePwdV3_1( GeneratePwdV2Parameter generatePwdV2Parameter, string specificKey );

		string DLLGeneratePwdV3_2( GeneratePwdV2Parameter generatePwdV2Parameter, string specificKey );

		ArrayList DLLGetCheckNoStatus( string machineCode, string verifyCode );

		string DLLGetNewSpecificKey();

		string DLLGetOptionPassword( int[] optionArray, string productSN, string verifyCode );

		void DLLGetPassEncodeVer( bool version, string verifyCode );

		string DLLGetRestorePassword( int[] optionArray, string machineType, string productSN, string verifyCode );

		void DLLPutAxis( int axis );

		void DLLPutMachineType( string machineType );

		void DLLSetLang( string lang );

		void DLLSetPasswordType( string passwordType );

		#endregion Public Methods
	}
}
