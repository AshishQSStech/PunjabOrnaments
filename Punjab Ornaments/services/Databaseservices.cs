using Punjab_Ornaments.DataBase;
using Punjab_Ornaments.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Punjab_Ornaments.services
{
    public class Databaseservices
    {
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }

        public void AddMetalRateAsync(MetalRate metalRate)
        {
            Database.AddMetalRateAsync(metalRate);
        }
    }
}
