using code.utility.matching;

namespace code.prep.movies
{
  public class IsPublishedBy : IMatchAn<Movie>
  {
    ProductionStudio studio;

    public IsPublishedBy(ProductionStudio studio)
    {
      this.studio = studio;
    }

    public bool matches(Movie movie)
    {
      return movie.production_studio == studio;
    } 
  }
}