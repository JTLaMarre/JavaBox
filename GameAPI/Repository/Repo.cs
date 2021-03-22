using System.Collections.Generic;
using System.Linq;
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
        public IList<T> Get<T>() where T : class
        {
            return _db.Set<T>().ToList();
        }

        /// <summary>
        /// Gets Entity based on ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T Get<T>(object id) where T : class
        {
            return _db.Set<T>().Find(id);
        }

        /// <summary>
        /// Inserts an object to a DBSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Insert<T>(T obj) where T : class
        {
            _db.Set<T>().Add(obj);
        }

        /// <summary>
        /// Updates an existing property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Update<T>(T obj) where T : class
        {
            _db.Set<T>().Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes an existing Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Delete<T>(object id) where T : class
        {
            T existing = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(existing);
        }

        /// <summary>
        /// Saves any and all Changes
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}