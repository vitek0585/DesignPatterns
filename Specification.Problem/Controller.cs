using System.Threading.Tasks;

namespace Specification.Problem
{
    public class Controller
    {
        private readonly IMovieRepository _repository;

        public Controller(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<string> ResultBuyChildTicket(int movieId)
        {
            Movie movie = _repository.GetById(movieId);

            if (movie.MpaaRating != MpaaRating.G)
                return Error("The movie is not eligible for children");

            return Ok();
        }

        private Task<string> Error(string e) =>
            Task.FromResult(e);

        private Task<string> Ok() =>
            Task.FromResult("ok");

    }
}