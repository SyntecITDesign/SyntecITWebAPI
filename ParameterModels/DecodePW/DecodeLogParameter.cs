using SyntecITWebAPI.Enums;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class DecodeLogParameter
	{
		#region Public Properties

		public AbstractDecodePWParameter decodeparameter
		{
			get; set;
		}

		public string decodePassword
		{
			get; set;
		}

		public string logCode
		{
			get; set;
		}

		public string logDescription
		{
			get; set;
		}

		public string logRemark
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Constructors + Destructors

		public DecodeLogParameter( AbstractDecodePWParameter decodeparameter, string decodePassword, LogCodeList code, string logDescription, string logRemark = null )
		{
			this.decodeparameter = decodeparameter;
			this.decodePassword = decodePassword;
			this.logCode = ( (int)code ).ToString();
			this.logDescription = logDescription;
			if( string.IsNullOrEmpty( logRemark ) )
				this.logRemark = decodeparameter.remark;
			else
				this.logRemark = logRemark;
		}

		#endregion Public Constructors + Destructors
	}
}
