namespace code.utility.matching
{
  public class MatchFactory<Item, Property> : ICreateMatchers<Item, Property>
  {
    IGetTheValueOfAProperty<Item, Property> accessor;

    public MatchFactory(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      this.accessor = accessor;
    }

    public Criteria<Item> equal_to(Property value)
    {
      return create_using(Criterias.equal_to(value));
    }

    public Criteria<Item> equal_to_any(params Property[] values)
    {
      return create_using(Criterias.equal_to_any(values));
    }

    public Criteria<Item> not_equal_to(Property value)
    {
      return equal_to(value).not();
    }

    class PropertyMatcher : IMatchAn<Item>
    {
      IGetTheValueOfAProperty<Item, Property> get_the_value;
      Criteria<Property> property_criteria;

      public PropertyMatcher(IGetTheValueOfAProperty<Item, Property> get_the_value, Criteria<Property> property_criteria)
      {
        this.get_the_value = get_the_value;
        this.property_criteria = property_criteria;
      }

      public bool matches(Item item)
      {
        var value = get_the_value(item);
        return property_criteria(value);
      }
    }

    public Criteria<Item> create_using(IMatchAn<Property> property_matcher)
    {
      return create_using(property_matcher.matches);
    }

    public Criteria<Item> create_using(Criteria<Property> property_matcher)
    {
      return new PropertyMatcher(accessor, property_matcher).matches;
    }
  }
}