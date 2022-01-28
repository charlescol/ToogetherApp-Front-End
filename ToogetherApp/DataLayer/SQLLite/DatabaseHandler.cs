using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataLayer.Models;
using System;

namespace DataLayer.SQLLite
{
    /* Object to access to the sqlite database */
    public class DatabaseHandler
    {
        private SQLiteAsyncConnection _connection;
        public DatabaseHandler(ISQLLite db)
        {
            _connection = db.SQLiteConnection();
            // Create Tables
            _connection.CreateTableAsync<MapEvent>().Wait();
            _connection.CreateTableAsync<RestrictedEvent>().Wait();
            _connection.CreateTableAsync<RestrictedPublicUser>().Wait();
        }
        /* Add an item to database, return -1 if the item key already exists*/
        public async Task<int> AddItemAsync<Tclass, Tkey>(AbstractModel<Tkey> item)
            where Tclass : AbstractModel<Tkey>, new()
            where Tkey : IEquatable<Tkey>
        {
            if (await IsKeyExistsAsync <Tclass, Tkey>(item.Id))
            {
                return -1;
            }
            return await _connection.InsertAsync(item);
        }
        /* Add an multi items to database, return -1 if one of the item key already exists*/
        public async Task<int> AddItemsAsync<Tclass, Tkey>(IEnumerable<AbstractModel<Tkey>> items)
            where Tclass : AbstractModel<Tkey>, new()
            where Tkey : IEquatable<Tkey>
        {
            foreach(var item in items)
            {
                if (await IsKeyExistsAsync<Tclass, Tkey>(item.Id))
                {
                    return -1;
                }
            }
            return await _connection.InsertAllAsync(items);
        }
        /* Return true if the input key already store in the table specified */
        public async Task<bool> IsKeyExistsAsync<Tclass, Tkey>(Tkey pKey) 
            where Tclass : AbstractModel<Tkey>, new()
            where Tkey : IEquatable<Tkey>
        {
            return await (from s in _connection.Table<Tclass>()
                    where s.Id.Equals(pKey)
                    select s).CountAsync() > 0;
        }
        /* Get all items from the table specified */
        public async Task<List<Tclass>> GetAllItemsAsync<Tclass, Tkey>() 
            where Tclass : AbstractModel<Tkey>, new()
        {
            return await _connection.Table<Tclass>().ToListAsync();
        }
        /* Clear all items from the table specified */
        public async Task<int> ClearAsync<Tclass, Tkey>()
            where Tclass : AbstractModel<Tkey>, new()
        {
            return await _connection.DeleteAllAsync<Tclass>();
        }
    }
}
