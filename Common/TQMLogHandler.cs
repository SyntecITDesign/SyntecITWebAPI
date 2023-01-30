using SyntecITWebAPI.ParameterModels.DecodePW;
using TQMLibrary;

namespace SyntecITWebAPI.Common
{
	public class TQMLogHandler
	{
		#region Internal Methods

		internal bool TQMWriteToSbc( DecodeLogParameter decodeLogParameter, string passwordResult, string decryptType )
		{
			try
			{
				AbstractDecodePWParameter parameter = decodeLogParameter.decodeparameter;
				string platform = "OPT";
				m_productSN.WriteTosbcHisMaster
					(
					parameter.productSN,
					platform,
					parameter.userID,
					passwordResult,
					decodeLogParameter.logCode,
					decodeLogParameter.logDescription,
					decryptType,
					parameter.requestPerson,
					parameter.subCompany,
					parameter.customerName,
					parameter.requestContent,
					parameter.remark
					);
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private ProductSN m_productSN = new ProductSN();

		#endregion Private Fields
	}
}
