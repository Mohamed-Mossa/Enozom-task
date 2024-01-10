// IRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enozom_task.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
