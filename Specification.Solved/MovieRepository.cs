using System.Collections.Generic;
using System.Linq;

namespace Specification.Solved
{
    public class MovieRepository : Repository<Movie>
    {
    }


    public abstract class Repository<T>
    {
        public IReadOnlyList<T> Find(Specification<T> specification, int page = 0, int pageSize = 100)
        {
            return Enumerable.Empty<T>()
                    .Where(specification.ToExpression().Compile())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
        }
    }
}
