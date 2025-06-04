using Movies.Application.Models;

namespace Movies.Application.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = new(); // Assuming its from database.
    
    public Task<bool> CreateAsync(Movie movie)
    {
        if (movie != null)
        {
            _movies.Add(movie);
            return Task.FromResult(true);
        }
        
        return Task.FromResult(false);
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        // We should make sure that id is not null and its exists in db.
        var movie = _movies.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(movie);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = _movies.SingleOrDefault(x => x.Slug == slug);
        return Task.FromResult(movie);
        
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_movies.AsEnumerable());
    }

    // Trying to update 
    public Task<bool> UpdateAsync(Movie movie)
    {
        var movieIndex = _movies.FindIndex(x => x.Id == Guid.Empty);
        if (movieIndex == -1)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _movies.RemoveAll(x => x.Id == id);
        var movieRemoved = removedCount > 0; // This is condition 
        return Task.FromResult<bool>(movieRemoved);
    }
}