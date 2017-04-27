using System;
using System.Collections.Generic;
using code.utility;

namespace code.prep.movies
{
  public interface IFindMoviesUsingLegacyCrappyMechanics
  {
    IEnumerable<Movie> all_movies_published_by_pixar();
    IEnumerable<Movie> all_movies_published_by_pixar_or_disney();
    IEnumerable<Movie> all_movies_not_published_by_pixar();
    IEnumerable<Movie> all_movies_published_after(int year);
    IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear);
    IEnumerable<Movie> all_kid_movies();
    IEnumerable<Movie> all_action_movies();
  }

  public class FindMoviesUsingLegacyCrappyMechanics : IFindMoviesUsingLegacyCrappyMechanics
  {
    IEnumerable<Movie> movies;

    public FindMoviesUsingLegacyCrappyMechanics(IEnumerable<Movie> movies)
    {
      this.movies = movies;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return movies.all_items_matching(x => x.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return movies.all_items_matching(m => m.production_studio == ProductionStudio.Pixar ||
                                      m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return movies.all_items_matching(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return movies.all_items_matching(m => m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return movies.all_items_matching(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return movies.all_items_matching(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
      return movies.all_items_matching(m => m.genre == Genre.action);
    }

  }

  public class MovieLibrary : IFindMoviesUsingLegacyCrappyMechanics
  {
    readonly IList<Movie> movies;
    IFindMoviesUsingLegacyCrappyMechanics finder;

    public MovieLibrary(IList<Movie> movies):this(movies, new FindMoviesUsingLegacyCrappyMechanics(movies))
    {
    }

    public MovieLibrary(IList<Movie> list_of_movies, IFindMoviesUsingLegacyCrappyMechanics finder)
    {
      this.movies = list_of_movies;
      this.finder = finder;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (movies.Contains(movie)) return;

      movies.Add(movie);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return finder.all_movies_published_by_pixar();
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return finder.all_movies_published_by_pixar_or_disney();
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return finder.all_movies_not_published_by_pixar();
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return finder.all_movies_published_after(year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return finder.all_movies_published_between_years(startingYear, endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return finder.all_kid_movies();
    }

    public IEnumerable<Movie> all_action_movies()
    {
      return finder.all_action_movies();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}