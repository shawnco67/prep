using code.utility;

namespace code.prep.movies
{
  public class Match<Item>
  {
    public static MatchFactory<Item,Property> with_attribute<Property>(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      return new MatchFactory<Item,Property>(accessor);
    }
  }
}