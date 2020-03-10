using System;
using System.Collections.Generic;

namespace Specification.Solved
{
    class Program
    {
        static void Main(string[] args)
        {
            var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
            bool isOk = gRating.IsSatisfiedBy(new Movie("Rembo 2", new DateTime(1990, 12, 3), MpaaRating.PG13, "M", 10)); // Exercising a single movie
           
            MovieRepository repository = new MovieRepository();
            IReadOnlyList<Movie> movies = repository.Find(gRating); // Getting a list of movies

            var specification = gRating.And(new GoodMovieSpecification());
            IReadOnlyList<Movie> movies2 = repository.Find(gRating);  // Getting a list of movies
        }
    }
}
