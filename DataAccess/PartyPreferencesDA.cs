using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PartyPreferencesDA : BaseDA<PartyPreferences>
    {
        public static PartyPreferences GetSingleByEmail(string Email)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            PartyPreferences PartyPreferences = db.Set<PartyPreferences>().Where(c => c.Email == Email).FirstOrDefault();
            return PartyPreferences;
        }
    }
}
