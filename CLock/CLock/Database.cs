using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using System.Threading.Tasks;

namespace CLock
{
    public class Database
    {
    private readonly SQLiteAsyncConnection _database;
        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<Alarm>().Wait();
        }
        public Task<int> AddAlarm(Alarm alarm)
        {
            return _database.InsertAsync(alarm);
        }
        public Task<List<Alarm>> ReadAlarms()
        {
            return _database.Table<Alarm>().ToListAsync();
        }
        public Task<int> DeleteAlarm(Alarm alarm)
        {
            return _database.DeleteAsync(alarm);
        }
    }
}
