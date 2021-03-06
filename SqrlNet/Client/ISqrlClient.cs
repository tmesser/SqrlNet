using System;

namespace SqrlNet.Client
{
	/// <summary>
	/// This provides all the SQRL functionality needed to implement a SQRL client.
	/// </summary>
	public interface ISqrlClient
	{
		/// <summary>
		/// Calculates the master key that is used with the HMAC function to generate the private key for a domain.
		/// </summary>
		/// <returns>
		/// The master key.
		/// </returns>
		/// <param name='masterIdentityKey'>
		/// The master identity key that is stored on the client.
		/// </param>
		/// <param name='password'>
		/// The password that converts the master identity key into the master key
		/// </param>
		/// <param name='salt'>
		/// A salt for adding entropy to the password hash
		/// </param>
		byte[] CalculateMasterKey(byte[] masterIdentityKey, string password, byte[] salt);

		/// <summary>
		/// Calculates the master identity key that is stored on the client.  This is needed when changing passwords.
		/// </summary>
		/// <returns>
		/// The master identity key to be stored on the client.
		/// </returns>
		/// <param name='masterKey'>
		/// The master key that is normally used as input to the HMAC function.
		/// </param>
		/// <param name='password'>
		/// The password to be used to calculate the master identity key.
		/// </param>
		/// <param name='salt'>
		/// A salt for adding entropy to the password hash
		/// </param>
		byte[] CalculateMasterIdentityKey(byte[] masterKey, string password, byte[] salt);

		/// <summary>
		/// Gets the sqrl data for login.
		/// </summary>
		/// <returns>
		/// The sqrl data for login.
		/// </returns>
		/// <param name='masterKey'>
		/// Master key.
		/// </param>
		/// <param name='url'>
		/// URL.
		/// </param>
		SqrlData GetSqrlDataForLogin(byte[] masterKey, string url);

		/// <summary>
		/// Gets the sqrl data for login.
		/// </summary>
		/// <returns>
		/// The sqrl data for login.
		/// </returns>
		/// <param name='masterIdentityKey'>
		/// Master identity key.
		/// </param>
		/// <param name='password'>
		/// Password.
		/// </param>
		/// <param name='url'>
		/// URL.
		/// </param>
		SqrlData GetSqrlDataForLogin(byte[] masterIdentityKey, string password, byte[] salt, string url);

		/// <summary>
		/// Gets the sqrl data for login.
		/// </summary>
		/// <returns>
		/// The sqrl data for login.
		/// </returns>
		/// <param name='identity'>
		/// Identity.
		/// </param>
		/// <param name='password'>
		/// Password.
		/// </param>
		/// <param name='url'>
		/// URL.
		/// </param>
		SqrlData GetSqrlDataForLogin(SqrlIdentity identity, string password, string url);

		/// <summary>
		/// Creates an identity for use with SQRL.
		/// </summary>
		/// <returns>
		/// All the data needed to define an identity.
		/// </returns>
		/// <param name='password'>
		/// Password.
		/// </param>
		/// <param name='entropy'>
		/// Random data from some non-deterministic source that allows for more secure master key generation.
		/// </param>
		SqrlIdentity CreateIdentity(string password, byte[] entropy);

		/// <summary>
		/// Changes the password.
		/// </summary>
		/// <returns>
		/// The new identity to be stored
		/// </returns>
		/// <param name='oldPassword'>
		/// Old password.
		/// </param>
		/// <param name='oldSalt'>
		/// Old salt.
		/// </param>
		/// <param name='newPassword'>
		/// New password.
		/// </param>
		/// <param name='masterIdentityKey'>
		/// Master identity key.
		/// </param>
		SqrlIdentity ChangePassword(string oldPassword, byte[] oldSalt, string newPassword, byte[] masterIdentityKey);

		/// <summary>
		/// Verifies the password.
		/// </summary>
		/// <returns>
		/// The password.
		/// </returns>
		/// <param name='password'>
		/// The password.
		/// </param>
		/// <param name='identity'>
		/// The identity to verify against.
		/// </param>
		bool VerifyPassword(string password, SqrlIdentity identity);

		/// <summary>
		/// Gets the domain from URL using the rules that SQRL uses for defining a domain (such as vertical bars).
		/// </summary>
		/// <returns>
		/// The domain from URL.
		/// </returns>
		/// <param name='url'>
		/// URL.
		/// </param>
		string GetDomainFromUrl(string url);
	}
}