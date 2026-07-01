using System.Linq.Expressions;

namespace markamed_api.QueryParameters
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy, bool isDescending)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var methodCallExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression,
                Expression.Quote(lambda));

            return query.Provider.CreateQuery<T>(methodCallExpression);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentException("Page number and page size must be greater than 0.");
            }

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                return query;
            }

            return query.Where(filter);
        }
    }
}