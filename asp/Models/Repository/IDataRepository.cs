using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace asp3.Models.Repository
{
    public interface  IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity LogIn(string email, string password);
        void Add(TEntity entity);
        string PostImage(IFormFile file);
        void Update(TEntity entity);
        void Delete(long id);
    }
}