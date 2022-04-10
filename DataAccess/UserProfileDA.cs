using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserProfileDA : BaseDA<UserProfile>
    {
        public static UserProfile GetSingleByEmail(string Email)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            UserProfile userprofile = db.Set<UserProfile>().Where(c => c.Email == Email).FirstOrDefault();
            return userprofile;
        }

        public static void UpdateFireBaseToken(UserProfile userProfile)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            UserProfile userprofile = db.Set<UserProfile>().Where(c => c.Email == userProfile.Email).FirstOrDefault();
            userprofile.FireBaseToken = userProfile.FireBaseToken;
            db.Entry(userprofile).CurrentValues.SetValues(userprofile);
            db.SaveChanges();
        }
    }
}
