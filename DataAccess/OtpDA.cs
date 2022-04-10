using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OtpDA : BaseDA<Otp>
    {
        public static string GenerateOtp()
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "P", "A", "R", "T", "Y", "B", "U", "D", "I", "E", "S" };
            return GenerateRandomOTP(6, saAllowedCharacters);
        }
        private static string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }

        public static Otp GetSingleByEmail(string Email)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            Otp otp = db.Set<Otp>().Where(c => c.Email == Email).FirstOrDefault();
            return otp;
        }
    }
}
