﻿namespace AutoMarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Get(int id);
        public Task<List<T>> Select();
        Task<bool> Delete(T entity);
    }
}
