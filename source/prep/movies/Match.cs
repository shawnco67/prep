using System;

namespace code.prep.movies
{
  public delegate ProductionStudio ITakeAMovieAndGetItsProductionStudio(Movie movie);

  public class Match<Item>
  {
    public static ITakeAMovieAndGetItsProductionStudio with_attribute(ITakeAMovieAndGetItsProductionStudio accessor)
    {
      return accessor;
    }
  }
}