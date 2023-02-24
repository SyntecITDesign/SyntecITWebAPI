namespace SyntecITWebAPI.Models.Decode.SecretDLL
{
	internal abstract class AbstractUseDLL
	{
		#region Internal Constructors + Destructors

		internal AbstractUseDLL( ISecretDLL secretDLL )
		{
			this.secretDLL = secretDLL;
		}

		#endregion Internal Constructors + Destructors

		#region Protected Fields

		private protected ISecretDLL secretDLL;

		#endregion Protected Fields
	}
}
