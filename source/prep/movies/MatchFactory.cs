using System;
using code.utility;

namespace code.prep.movies
{
  public class MatchFactory<Item, Property>
  {
    IGetTheValueOfAProperty<Item, Property> accessor;

    public MatchFactory(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      this.accessor = accessor;
    }

    public Criteria<Item> equal_to(Property value)
    {
      return x => accessor(x).Equals(value);
    }

    public Criteria<Item> equal_to_any(params Property[] values)
    {
      throw new NotImplementedException();
    }
  }
}