using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Entities.Repositories
{
    public static class NewRepository
    {
        //private static MyDbContext db = new MyDbContext();
        //public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query,
        //                  (current, include) => current.Include(include));
        //    }
        //    return query;
        //}
        //public static void GiveSmth(params Expression<Func<Event, object>>[] includes)
        //{            
        //     var a = db.Events.IncludeMultiple(includes);
        //}
    }
}
