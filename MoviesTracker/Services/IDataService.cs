using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MoviesTracker.Models;

namespace MoviesTracker.Services;

public interface IDataService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task CreateMovie(Movie movie);
    Task DeleteMovie(int id);
    Task UpdateMovie(Movie movie);
}
