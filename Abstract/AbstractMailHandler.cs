using Syntec.Notifier;
using SyntecITWebAPI.ParameterModels.Mail;
using System.Collections.Generic;

namespace SyntecITWebAPI.Abstract
{
	internal abstract class AbstractMailHandler
	{
		#region Internal Fields

		internal List<MailParameter> m_mailParameterList;

		#endregion Internal Fields

		#region Internal Constructors + Destructors

		internal AbstractMailHandler( List<MailParameter> mailParameters )
		{
			m_mailParameterList = mailParameters;
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		// may need to mail to many people
		internal virtual bool SendMail()
		{
			if( m_mailParameterList.Count <= 0 )
			{
				return false;
			}

			foreach( MailParameter mailParameter in m_mailParameterList )
			{
				m_notifier.UserName = mailParameter.userEmail;
				m_notifier.Title = GetTitle( mailParameter );
				m_notifier.Content = GetContent( mailParameter );
				if( m_notifier.Notify() == false )
				{
					return false;
				}
				else
				{
					continue;
				}
			}
			return true;
		}

		#endregion Internal Methods

		#region Protected Methods

		// need to override
		protected abstract string GetContent( MailParameter mailParameter );

		// need to override
		protected abstract string GetTitle( MailParameter mailParameter );

		#endregion Protected Methods

		#region Private Fields

		private INotifier m_notifier = new MailNotifier();

		#endregion Private Fields
	}
}
