using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface IRepository<TEntity, TId>
	{
		IQueryable<TEntity> GetAll();
		TEntity GetById(TId id);
		Task<TEntity> GetByIdAsync(TId id);
		void Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Delete(TId id);
	}
}
