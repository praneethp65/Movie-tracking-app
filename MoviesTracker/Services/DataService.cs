using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MoviesTracker.Models;
using Supabase;

namespace MoviesTracker.Services;

public class DataService : IDataService
{
    private readonly Client _supabaseClient;

    public DataService(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        var response = await _supabaseClient.From<Movie>().Get();
        return response.Models.OrderByDescending(b => b.CreatedAt);
    }

    public async Task CreateMovie(Movie movie)
    {
        await _supabaseClient.From<Movie>().Insert(movie);
    }

    public async Task DeleteMovie(int id)
    {
        await _supabaseClient.From<Movie>()
            .Where(b => b.Id == id).Delete();
    }

    public async Task UpdateMovie(Movie movie)
    {
        await _supabaseClient.From<Movie>().Where(b => b.Id == movie.Id)
            .Set(b => b.Title, movie.Title)
            .Set(b => b.Director, movie.Director)
            .Set(b => b.ImageUrl, movie.ImageUrl)
            .Set(b => b.ReleaseDate, movie.ReleaseDate)
            .Set(b => b.IsFinished, movie.IsFinished)
            .Update();
    }
}
