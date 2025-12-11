using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly List<Movie> _movies = new();


        public Task<bool> CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie is null)
            {
                return Task.FromResult(false);
            }
            _movies.Remove(movie);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie?> GetByIdAsync(Guid id)
        {
            var movie = _movies.SingleOrDefault(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task<bool> UpdateAsync(Movie movie)
        {
            var movieToUpdate = _movies.FindIndex(m => m.Id == movie.Id);
            if (movieToUpdate == -1)
            {
                return Task.FromResult(false);
            }
            _movies[movieToUpdate] = movie;
            return Task.FromResult(true);
        }
    }
}
