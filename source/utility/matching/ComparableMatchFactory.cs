using System;

namespace code.utility.matching
{
  public class ComparableMatchFactory<Item, Property> : ICreateMatchers<Item, Property>
    where Property : IComparable<Property>
  {
    ICreateMatchers<Item, Property> match_factory;

    public ComparableMatchFactory(ICreateMatchers<Item, Property> match_factory)
    {
      this.match_factory = match_factory;
    }

    public Criteria<Item> equal_to(Property value)
    {
      return match_factory.equal_to(value);
    }

    public Criteria<Item> equal_to_any(params Property[] values)
    {
      return match_factory.equal_to_any(values);
    }

    public Criteria<Item> not_equal_to(Property value)
    {
      return match_factory.not_equal_to(value);
    }

    public Criteria<Item> greater_than(Property value)
    {
      return create_using(Criterias.greater_than(value));
    }

    public Criteria<Item> between(Property start, Property end)
    {
      return create_using(Criterias.between(start, end));
    }

    public Criteria<Item> create_using(Criteria<Property> property_matcher)
    {
      return match_factory.create_using(property_matcher);
    }

    public Criteria<Item> create_using(IMatchAn<Property> property_matcher)
    {
      return match_factory.create_using(property_matcher);
    }
  }
}