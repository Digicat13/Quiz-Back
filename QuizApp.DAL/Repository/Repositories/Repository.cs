﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories

{
	public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
	{
		protected QuizAppContext _dbContext { get; set; }
		public Repository(QuizAppContext context)
		{
			_dbContext = context;
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
		}

		public TEntity GetById(TId id)
		{
			return _dbContext.Set<TEntity>().Find(id);
		}

		public async Task<TEntity> GetByIdAsync(TId id)
		{
			return await _dbContext.Set<TEntity>().FindAsync(id);
		}

		public async Task<int> Add(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			return _dbContext.SaveChangesAsync().Result;
		}

		public async Task<int> Update(TEntity entity)
		{
			var result = _dbContext.Set<TEntity>().Update(entity);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> Delete(TId id)
		{
			var entity = await _dbContext.Set<TEntity>().FindAsync(id);
			_dbContext.Set<TEntity>().Remove(entity);
			return _dbContext.SaveChangesAsync().Result;
		}
	}
}
