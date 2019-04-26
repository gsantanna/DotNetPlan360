using System.Security.Cryptography;
using System.Text;

namespace Plan360.Utilities
{

    public static class Plan360Extensions
    {

        /// <summary>
        /// Representes a Glyph icon view of a bool 
        /// </summary>
        /// <param name="b">Value to be converted</param>
        /// <returns></returns>
        public static GBool ToGbool(this bool? b)
        {
            return new GBool(b);
        }

        /// <summary>
        /// Representes a Glyph icon view of a bool 
        /// </summary>
        /// <param name="b">Value to be converted</param>
        /// <returns></returns>
        public static GBool ToGbool(this bool b)
        {
            return new GBool(b);

        }

        /// <summary>
        /// Encrypt the string and return HD5 hash
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5Hash(this string str)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();


        }



    }














}
