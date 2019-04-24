using MVC_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_01.Repository
{
    public interface ILibraryRepository <TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Book book, TEntity entity);
        Task Delete(Book book);
    }
}
