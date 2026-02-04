using System.Text;

namespace ShotUrl.Model
{
    public static class CodeGenerate
    {
        private const long Secret = 0x5A17C9F3B2D4E6A1;
        private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static long ofusc(long id) => id ^ Secret;
        public static long Desofusc(long value) => value ^ Secret;

        public static string Encode(long value)
        {
            if (value == 0) return Chars[0].ToString();

            var result = new StringBuilder();

            while (value > 0)
            {
                result.Insert(0, Chars[(int)(value % 62)]);
                value /= 62;
            }

            return result.ToString();
        }

        public static long Decode(string text)
        {
            long result = 0;

            foreach(var c in text)
            {
                result = result * 62 + Chars.IndexOf(c);
            }

            return result;
        }
    }
}
