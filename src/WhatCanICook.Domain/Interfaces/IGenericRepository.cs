﻿namespace WhatCanICook.Domain.Interfaces;
public interface IGenericRepository<T> where T : class {
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteByIdAsync(int id);
    Task<bool> ExistsById(int id);
}
