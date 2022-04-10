using DataAccess.EF;
using DataAccess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PartyDA : BaseDA<Party>
    {
        public static List<SwipeHomeModel> GetParties(string Email)
        {
            List<SwipeHomeModel> partieslist = new List<SwipeHomeModel>();
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var innerJoinQuery =
                        from Party in db.Party
                        join UserProfile in db.UserProfile on Party.Email equals UserProfile.Email
                        where UserProfile.Email != Email
                        select new SwipeHomeModel { Sex = UserProfile.Sex, IsAlcoholic = Party.PartyAlcoholic, PartyDate = Party.PartyDate, OrganiserName = UserProfile.Name, Location = Party.PartyAddress, DateOfBirth = UserProfile.DateOfBirth, OrganiserEmail = UserProfile.Email, PartyID = Party.ID, FireBaseToken = UserProfile.FireBaseToken };
            foreach (SwipeHomeModel party in innerJoinQuery)
            {
                List<UserImage> userImages = UserImageDA.GetCustomQuery($"select * from userimage where Email='{party.OrganiserEmail}'");
                if (userImages.Count > 1)
                    party.ImageUrl = userImages.FirstOrDefault().ImageUrl;
                partieslist.Add(party);
            }

            return partieslist.Distinct().ToList();
        }


    }
}
