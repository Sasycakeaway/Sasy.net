namespace Sasy.NET.AES;
using System;
using System.Security.Cryptography;
using System.Text;

public class SHA256_Calculator
{
    public string encrypt(string rawData)
    {
        using (SHA256 hash = SHA256.Create())
        {
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}