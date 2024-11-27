using System.Security.Cryptography;

namespace RapidPay.Infrastructure.Helpers
{
    public class EncryptionHelper
    {
        private static readonly byte[] Key = Convert.FromBase64String("AsISxq9OwdZag1163OJqwovXfSWG98m+sPjVwJecfe4=");

        private static readonly byte[] IV = Convert.FromBase64String("Aq0UThtJhjbuyWXtmZs1rw==");

        private byte[] EncryptStringToBytes(string profileText)
        {
            byte[] encryptedAuditTrail;

            using var msEncrypt = new MemoryStream();
            using (var newAes = Aes.Create())
            {
                newAes.Key = Key;
                newAes.IV = IV;

                var encryptor = newAes.CreateEncryptor(Key, IV);

                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using var swEncrypt = new StreamWriter(csEncrypt);
                swEncrypt.Write(profileText);

                encryptedAuditTrail = msEncrypt.ToArray();
            }
            return encryptedAuditTrail;
        }
        private string DecryptStringFromBytes(byte[] profileText)
        {
            string decryptText;

            using var msDecrypt = new MemoryStream(profileText);
            using (var newAes = Aes.Create())
            {
                newAes.Key = Key;
                newAes.IV = IV;

                var decryptor = newAes.CreateDecryptor(Key, IV);

                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                decryptText = srDecrypt.ReadToEnd();
            }
            return decryptText;
        }
    }
}
