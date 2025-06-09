﻿namespace CinemaApp.Services.Core
{
    using CinemaApp.Data;
    using CinemaApp.Data.Models;
    using CinemaApp.Services.Core.Interfaces;
    using CinemaApp.Web.ViewModels.Movie;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using static CinemaApp.GCommon.ApplicationConstants;

    public class MovieService : IMovieService
    {
        private readonly CinemaAppDbContext dbContext;

        public MovieService(CinemaAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
        {
            IEnumerable<AllMoviesIndexViewModel> movies = await this.dbContext
                .Movies
                .AsNoTracking()
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            foreach (AllMoviesIndexViewModel movie in movies)
            {
                if (String.IsNullOrEmpty(movie.ImageUrl))
                {
                    movie.ImageUrl = $"/images/{NoImageUrl}";
                }
            }

            return movies;
        }


        public async Task AddMovieAsync(MovieFormInputModel movieInput)
        {
            Movie newMovie = new Movie()
            {
                Title = movieInput.Title,
                Genre = movieInput.Genre,
                Director = movieInput.Director,
                Description = movieInput.Description,
                Duration = movieInput.Duration,
                ImageUrl = movieInput.ImageUrl,
                ReleaseDate = DateOnly
                    .ParseExact(movieInput.ReleaseDate, AppDateFormat,
                        CultureInfo.InvariantCulture, DateTimeStyles.None),
            };

            await this.dbContext.Movies.AddAsync(newMovie);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id)
        {
            MovieDetailsViewModel? movieDetails = null;

            bool isIdValidGuid = Guid.TryParse(id, out Guid movieId);

            if (isIdValidGuid)
            {
                movieDetails = await this.dbContext
                    .Movies
                    .AsNoTracking()
                    .Where(m => m.Id == movieId)
                    .Select(m => new MovieDetailsViewModel()
                    {
                        Id = m.Id.ToString(),
                        Description = m.Description,
                        Director = m.Director,
                        Duration = m.Duration,
                        Genre = m.Genre,
                        ImageUrl = m.ImageUrl ?? $"/images/{NoImageUrl}",
                        ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                        Title = m.Title
                    })
                    .SingleOrDefaultAsync();
            }

            return movieDetails;
        }

        public async Task<MovieFormInputModel?> GetEditableMovieByIdAsync(string? id)
        {
            MovieFormInputModel? editableMovie = null;

            bool isIdValidGuid = Guid.TryParse(id, out Guid movieId);
            if (isIdValidGuid)
            {
                editableMovie = await this.dbContext
                    .Movies
                    .AsNoTracking()
                    .Where(m => m.Id == movieId)
                    .Select(m => new MovieFormInputModel()
                    {
                        Description = m.Description,
                        Director = m.Director,
                        Duration = m.Duration,
                        Genre = m.Genre,
                        ImageUrl = m.ImageUrl ?? $"/images/{NoImageUrl}",
                        ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                        Title = m.Title
                    })
                    .SingleOrDefaultAsync();
            }

            return editableMovie;
        }

        public async Task<bool> EditMovieAsync(MovieFormInputModel inputModel)
        {
            Movie? editableMovie = await this.FindMovieByStringId(inputModel.Id);

            if (editableMovie == null)
            {
                return false;
            }

            DateOnly movieReleaseDate = DateOnly
                .ParseExact(inputModel.ReleaseDate, AppDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None);

            editableMovie.Title = inputModel.Title;
            editableMovie.Description = inputModel.Description;
            editableMovie.Director = inputModel.Director;
            editableMovie.Duration = inputModel.Duration;
            editableMovie.Genre = inputModel.Genre;
            editableMovie.ImageUrl = inputModel.ImageUrl ?? $"/images/{NoImageUrl}";
            editableMovie.ReleaseDate = movieReleaseDate;

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteMovieViewModel?> GetMovieDeleteDetailsByIdAsync(string? id)
        {
            DeleteMovieViewModel? deleteMovieViewModel = null;

            Movie? movieToBeDeleted = await this.FindMovieByStringId(id);
            if (movieToBeDeleted != null)
            {
                deleteMovieViewModel = new DeleteMovieViewModel()
                {
                    Id = movieToBeDeleted.Id.ToString(),
                    Title = movieToBeDeleted.Title,
                    ImageUrl = movieToBeDeleted.ImageUrl ?? $"/images/{NoImageUrl}",
                };
            }

            return deleteMovieViewModel;
        }

        public async Task<bool> SoftDeleteMovieAsync(string? id)
        {
            Movie? movieToDelete = await this.FindMovieByStringId(id);
            if (movieToDelete == null)
            {
                return false;
            }

            // Soft Delete <=> Edit of IsDeleted property
            movieToDelete.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMovieAsync(string? id)
        {
            Movie? movieToDelete = await this.FindMovieByStringId(id);
            if (movieToDelete == null)
            {
                return false;
            }

            // TODO: To be investigated when relations to Movie entity are introduced
            this.dbContext.Movies.Remove(movieToDelete);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        // TODO: Implement as generic method in BaseService
        private async Task<Movie?> FindMovieByStringId(string? id)
        {
            Movie? movie = null;

            if (!string.IsNullOrWhiteSpace(id))
            {
                bool isGuidValid = Guid.TryParse(id, out Guid movieGuid);
                if (isGuidValid)
                {
                    movie = await this.dbContext
                        .Movies
                        .FindAsync(movieGuid);
                }
            }

            return movie;
        }
    }
}
