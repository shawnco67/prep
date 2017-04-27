using System;

namespace code.utility.matching
{
  public class ComparableMatchFactory<Item, Property> where Property : IComparable<Property>
  {
    IGetTheValueOfAProperty<Item, Property> accessor;
    MatchFactory<Item, Property> matchFactory;

    public ComparableMatchFactory(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      this.matchFactory = new MatchFactory<Item, Property>(accessor);
      this.accessor = accessor;
    }

    public Criteria<Item> greater_than(Property value)
    {
      return x => accessor(x).CompareTo(value) > 0;
    }

    public Criteria<Item> equal_to(Property value)
    {
      return matchFactory.equal_to(value);
    }

    public Criteria<Item> equal_to_any(params Property[] values)
    {
      return matchFactory.equal_to_any(values);
    }

    public Criteria<Item> not_equal_to(Property value)
    {
      return matchFactory.not_equal_to(value);
    }
  }
}