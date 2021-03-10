using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Common
{
    public static class GenerateVoucher
    {
        public static string Generate(string start_prefix, string max_voucher, int length)
        {
            var new_g = "";
            long nextNumber = 0;
            try
            {
                nextNumber = max_voucher.Substring(start_prefix.Length).toLong();
            }
            catch (Exception)
            {
                nextNumber = 1;
            }
            new_g = getFormateString(length, nextNumber);
            return start_prefix + new_g;
        }
        private static string getFormateString(long length, long val)
        {
            long l = length - val;
            if (l <= 0) l = 0;
            string nS = "";
            while (l > 0)
            {
                nS += "0";
                l--;
            }
            return nS + "" + val;
        }
        private static long toLong(this string s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
