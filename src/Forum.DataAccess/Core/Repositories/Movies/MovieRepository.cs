using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.DataAccess.Core.UoW;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Common.Errors;

namespace Forum.DataAccess.Core.Repositories.Movies;

internal class MovieRepository : IMovieRepository
{
    private readonly ForumDbContext _context;

    public MovieRepository(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<Deleted>> DeleteByIdAsync(Guid id, CancellationToken token)
    {
        MovieEntity? movie = await _context.Movies.SingleOrDefaultAsync(movie => movie.Id == id, token);
        if (movie is null)
            return Errors.Movies.MovieDoesNotExist;
        _context.Movies.Remove(movie);
        return Result.Deleted;
    }

    public async Task<List<MovieEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Movies.ToListAsync(cancellationToken);
    }

    public async Task<ErrorOr<MovieEntity?>> GetByIdAsync(Guid id, CancellationToken token)
    {
        MovieEntity? movie = await _context.Movies.SingleOrDefaultAsync(movie => movie.Id == id, token);
        if(movie is null)
            return Errors.Movies.MovieDoesNotExist;
        return movie;
    }

    public async Task<ErrorOr<Created>> InsertAsync(MovieEntity entity, CancellationToken token)
    {
        bool movieExists = await _context.Movies.AnyAsync(movie => movie.Id == entity.Id, token);
        if (movieExists)
            return Errors.Movies.MovieAlreadyExists;
        _context.Movies.Add(entity);
        return Result.Created;
    }

    public async Task<ErrorOr<Updated>> UpdateAsync(MovieEntity entity, CancellationToken token)
    {
        MovieEntity? movie = await _context.Movies.SingleOrDefaultAsync(movie => movie.Id == entity.Id, token);
        if (movie is null)
            return Errors.Movies.MovieDoesNotExist;
        _context.Entry(movie).CurrentValues.SetValues(entity);
        return Result.Updated;
    }
}
