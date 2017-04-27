using System;

namespace code.utility.matching
{
  public class Match<Item>
  {
    public static MatchFactory<Item, Property> with_attribute<Property>(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      return new MatchFactory<Item, Property>(accessor);
    }

    public static ComparableMatchFactory<Item, Property> with_comparable_attribute<Property>(IGetTheValueOfAProperty<Item, Property> accessor) where Property : IComparable<Property>
    {
      return new ComparableMatchFactory<Item, Property>(accessor);
    }
  }
}