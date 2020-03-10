using System;
using System.Collections.Generic;
using System.Linq;

namespace Specification.Problem
{
    public class MovieRepository2
    {
        public IReadOnlyList<Movie> Find(
            DateTime? maxReleaseDate = null,
            double minRating = 0,
            string genre = null)
        {
            return new List<Movie>();
        }

        public IReadOnlyList<Movie> FindMoviesForChildren()
        {
            return Enumerable.Empty<Movie>()
                .Where(x => x.MpaaRating == MpaaRating.G)
                .ToList();
        }
    }
}