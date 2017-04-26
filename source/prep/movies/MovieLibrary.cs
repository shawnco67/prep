using System;
using System.Collections.Generic;

namespace code.prep.movies
{
    public class MovieLibrary
    {
        readonly IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
            {
                bool found = false;
                foreach (var m in movies)
                    if (m.title.Equals(movie.title,StringComparison.CurrentCultureIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                if (!found)
                    movies.Add(movie);
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.production_studio == ProductionStudio.Pixar)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.production_studio == ProductionStudio.Pixar ||
                    m.production_studio == ProductionStudio.Disney)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.production_studio != ProductionStudio.Pixar)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.date_published.Year > year)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.date_published.Year >= startingYear && m.date_published.Year <= endingYear)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.genre == Genre.kids)
                    list.Add(m);
            return list as IEnumerable<Movie>;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            var list = new List<Movie>();
            foreach (var m in movies)
                if (m.genre == Genre.action)
                    list.Add(m);
            return list as IEnumerable<Movie>;
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
