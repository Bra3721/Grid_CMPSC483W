using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grid483W.Models;
using Xamarin.Forms;

namespace Grid483W.Data
{
    public class KeyDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;
        
        public KeyDatabaseController()
        {
            database = DependencyService.Get<ISQLiteInterface>().GetConnection();
            database.CreateTable<KeyInfo>();
        }

        public KeyInfo GetKey(string rowcol)
        {
            lock (locker)
            {
                return database.Table<KeyInfo>().FirstOrDefault(dbKey => (dbKey.rowcol == rowcol));
            }
        }



        public int SaveKey(KeyInfo keyinfo)
        {
            lock(locker)
            {
                KeyInfo dbkey = database.Table<KeyInfo>().FirstOrDefault(dbKey => dbKey.rowcol == keyinfo.rowcol);

                if (dbkey == null)
                {
                    database.Insert(keyinfo);
                    return (0);
                }
                else
                {
                    database.Update(keyinfo);
                    return(0);
                }
            }
        }

        public int DeleteKey(int id)
        {
            lock (locker)
            {
                return database.Delete<KeyInfo>(id);
            }
        }
    }
}
