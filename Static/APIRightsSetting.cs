namespace SyntecITWebAPI.Static
{
	internal class APIRightsSetting
	{
		// {controller name}_{action} = "{right1},{right2},..."

		#region Internal Fields

		internal const string DECODE_DATE = "M,";
		internal const string DECODE_HW = "V,";
		internal const string DECODE_RESET = "S,";
		internal const string DECODE_SERVO = "&,";
		internal const string LATESTNEWS_CREATENEWS = "OP_1,";
		internal const string LATESTNEWS_DELETENEWS = "OP_3,";
		internal const string LATESTNEWS_UPDATENEWS = "OP_2,";
		internal const string PWDGENERATE_V1 = "N,";
		internal const string PWDGENERATE_V2 = "O,";
		internal const string SNRESTORE = "Q,";

		#endregion Internal Fields
	}
}
