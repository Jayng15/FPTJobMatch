﻿using System.Linq.Expressions;

namespace FptJobMatch.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(string? includedProperty = null);
		T Get(Expression<Func<T, bool>> predicate, string? includedProperty = null);
		void Add(T entity);
		void Delete(T entity);
		void Save();
	}
}
