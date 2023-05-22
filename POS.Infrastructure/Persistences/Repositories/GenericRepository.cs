﻿using POS.Infrastructure.Commons.Bases;
using POS.Infrastructure.Helpers;
using POS.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;
namespace POS.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO :class
        {
            IQueryable<TDTO> query = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending"): queryable.OrderBy($"{request.Sort} ascending");
            if (pagination) query = query.Paginate(request);
            return query;   
        }
    }
}
