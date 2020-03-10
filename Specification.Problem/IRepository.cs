using System;
using System.Collections.Generic;

namespace Specification.Problem
{
    public interface IMovieRepository
    {
        IReadOnlyList<Movie> GetByReleaseDate(DateTime maxReleaseDate);

        IReadOnlyList<Movie> GetByRating(double minRating);

        IReadOnlyList<Movie> GetByGenre(string genre);
        Movie GetById(in int movieId);
    }
}