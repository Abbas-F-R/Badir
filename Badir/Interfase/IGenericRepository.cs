using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Badir.Interface;

public interface IGenericRepository <T ,  TId>
{
    Task<T?> GetById(TId id, bool deleted = false);

    Task<(List<TDto>? data, int? totalCount)> GetAll<TDto>(int pageNumber = 0, int pageSize = 10, bool deleted = false);
    
    Task<(List<TDto>? data, int? totalCount)> GetAll<TDto>(Expression<Func<T, bool>> predicate
        , int pageNumber = 0, int pageSize = 10, bool deleted = false);

    Task<(List<T>? data, int? totalCount)> GetAll(int pageNumber = 0, int pageSize = 10, bool deleted = false);

    Task<(List<T>? data, int? totalCount)> GetAll(Expression<Func<T, bool>> predicate,
        int pageNumber = 0, int pageSize = 10, bool deleted = false
    );

    Task<(List<T>? data, int? totalCount)> GetAll(
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
        int pageNumber = 0, int pageSize = 10, bool deleted = false
    );

    Task<(List<T>? data, int? totalCount)> GetAll(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
        int pageNumber = 0, int pageSize = 10,
        bool deleted = false
    );
 

    Task<T?> Add(T entity, int? userId = null);
    Task<T?> Delete(TId id, int? userId = null);
    Task<T?> SoftDelete(TId id, int? userId = null);
    Task<T?> Update(T entity, int? userId = null);

    Task<List<TDto>> UpdateAll<TDto>(List<T> entities, int? userId = null);
    Task<List<T>> UpdateAll(List<T> entities, int? userId = null);


    Task<TDto?> Get<TDto>(Expression<Func<T, bool>> predicate, bool deleted = false);
    Task<T?> Get(Expression<Func<T, bool>> predicate, bool deleted = false);

    Task<T?> Get(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool deleted = false);}