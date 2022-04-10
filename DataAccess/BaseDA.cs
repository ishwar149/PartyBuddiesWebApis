using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDA<T> where T : class
    {

        #region Insert
        public static T Add(T item)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var dbentity = db.Set(item.GetType());
            dbentity.Add(item);
            db.SaveChanges();
            return item;
        }
        #endregion

        #region Get
        public static DbSet<T> GetAll()
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var dbset = db.Set<T>();
            return dbset;
        }
        public static T GetSingle(int ID)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var dbset = db.Set<T>().Find(ID);
            return dbset;
        }
        #endregion

        #region Update
        public static void Update(int Id, T item)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var dbentity = db.Set(item.GetType());
            var entity = dbentity.Find(Id);
            if (entity == null)
            {
                return;
            }
            db.Entry(entity).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        #endregion

        #region Delete

        public static void Delete(int Id)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            var dbentity = db.Set<T>();
            var entity = dbentity.Find(Id);
            dbentity.Remove(entity);
            db.SaveChanges();
        }

        #endregion

        #region Custom Query

        public static List<T> GetCustomQuery(string Query)
        {
            EF.PartyBuddiesEntities db = new EF.PartyBuddiesEntities();
            return db.Set<T>().SqlQuery(Query).ToList();
        }

        #endregion

    }
}
