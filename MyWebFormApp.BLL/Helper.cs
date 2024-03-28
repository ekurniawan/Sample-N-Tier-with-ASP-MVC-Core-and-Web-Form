using System;
using System.IO;
using System.Linq;

namespace MyWebFormApp.BLL
{
    public class Helper
    {
        public static string GetHash(string input)
        {
            var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var bytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = sha1.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool IsImageFile(string filePath)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string extension = Path.GetExtension(filePath);
            return imageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

    }
}
