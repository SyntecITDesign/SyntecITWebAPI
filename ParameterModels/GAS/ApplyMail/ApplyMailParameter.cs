using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyMail
{
	public class MailApplicationsMasterAllField
	{
		public string ApplyTime
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}
		public string Depart
		{
			get; set;
		}
		public string Wid
		{
			get; set;
		}
		public string Memo
		{
			get; set;
		}
		public string ReceiveName
		{
			get; set;
		}
		public string Address
		{
			get; set;
		}
		public string Return
		{
			get; set;
		}
		public string Print
		{
			get; set;
		}
		public string Weight
		{
			get; set;
		}
		public string Fee
		{
			get; set;
		}
		public string Content
		{
			get; set;
		}
	}
	public class InsertMail : MailApplicationsMasterAllField
	{

	}
	
}
