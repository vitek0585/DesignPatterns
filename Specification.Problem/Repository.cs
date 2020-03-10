using System;
using System.Collections.Generic;

namespace Specification.Problem
{
    public class MovieRepository
    {
        public IReadOnlyList<Movie> GetByReleaseDate(DateTime minReleaseDate)
        {
            return new List<Movie>();
        }
    }
}