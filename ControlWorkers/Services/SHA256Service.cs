using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkers.Services
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class SHA256Service
    {
        public static String ConvertToSHA256(string value)
        {
            StringBuilder Sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
    }
}
