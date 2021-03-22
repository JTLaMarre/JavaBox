using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAPI.Storage;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Repository
{
    public class Repo
    {
        protected readonly GameContext _db;
        public Repo(GameContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Gets all Entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async Task<List<T>> Get<T>() where T : class
        {
            return await Task.FromResult(_db.Set<T>().ToList());
        }

        /// <summary>
        /// Gets Entity based on ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async Task<T> Get<T>(object id) where T : class
        {
            return await Task.FromResult(_db.Set<T>().Find(id));
        }

        /// <summary>
        /// Inserts an object to a DBSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async void Insert<T>(T obj) where T : class
        {
            await Task.Run(() =>_db.Set<T>().Add(obj));
        }

        /// <summary>
        /// Updates an existing property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async void Update<T>(T obj) where T : class
        {
           await Task.Run(() => _db.Set<T>().Attach(obj));
           await Task.Run(() =>_db.Entry(obj).State = EntityState.Modified);
        }

        /// <summary>
        /// Deletes an existing Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public async void Delete<T>(object id) where T : class
        {
            T existing = await Task.Run(() => _db.Set<T>().Find(id));
            await Task.Run(()=>_db.Set<T>().Remove(existing));
        }

        /// <summary>
        /// Saves any and all Changes
        /// </summary>
        public async void Save()
        {
           await Task.Run(()=>_db.SaveChanges());
        }
    }
}