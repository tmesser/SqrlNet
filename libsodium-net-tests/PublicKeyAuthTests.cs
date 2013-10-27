using System;
using NUnit.Framework;
using System.Security.Cryptography;
using Sodium;

namespace libsodiumnettests
{
	[TestFixture]
	public class PublicKeyAuthTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Seeded_Key_Generation_Is_Deterministic()
		{
			var rng = new RNGCryptoServiceProvider();
			var seed = new byte[32];

			rng.GetBytes(seed);

			var kp1 = PublicKeyAuth.GenerateKeyPair(seed);
			var kp2 = PublicKeyAuth.GenerateKeyPair(seed);

			Assert.AreEqual(kp1.PrivateKey, kp2.PrivateKey);
			Assert.AreEqual(kp1.PublicKey, kp2.PublicKey);
		}

		[Test]
		public void UnSeeded_Key_Generation_Is_NonDeterministic()
		{
			var kp1 = PublicKeyAuth.GenerateKeyPair();
			var kp2 = PublicKeyAuth.GenerateKeyPair();

			Assert.AreNotEqual(kp1.PrivateKey, kp2.PrivateKey);
			Assert.AreNotEqual(kp1.PublicKey, kp2.PublicKey);
		}
	}
}

