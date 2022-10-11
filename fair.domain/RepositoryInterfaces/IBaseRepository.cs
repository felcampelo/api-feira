﻿using fair.domain.Entities.Base;

namespace fair.domain.RepositoryInterfaces
{
    public interface IBaseRepository<T, KeyType> where T : IBaseEntity<KeyType>
    {
        Task<T> Insert(T entity);
        Task<bool> DeleteById(KeyType id);
        Task<bool> Delete(T entity);
        Task<T?> GetSingleById(KeyType id);
    }
}
