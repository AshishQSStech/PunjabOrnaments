using NuGet.Common;
using Punjab_Ornaments.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Punjab_Ornaments.DataBase
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        //public static readonly AsyncLazy<Database> Instance = new AsyncLazy<Database>(async () =>
        //{
        //    var instance = new Database();
        //    CreateTableResult result = await DataBaseConnection.CreateTableAsync<models.MetalRate>();
        //    return instance;
        //});

        public Database()
        {
            _database = new SQLiteAsyncConnection(DataBase.Constants.DataBasePath, DataBase.Constants.Flags);
            _database.CreateTableAsync<models.MetalRate>().Wait();
        }

        public Task<List<models.MetalRate>> GetMetalRateAsync()
        {
            return _database.Table<models.MetalRate>().ToListAsync();
        }

        public Task<int> AddMetalRateAsync(models.MetalRate metalrate)
        {
            return _database.InsertAsync(metalrate);
        }
    }
}
