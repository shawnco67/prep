namespace code.utility.matching
{
  public class PropertyMatcher<Item, Property> : IMatchAn<Item>
  {
    IGetTheValueOfAProperty<Item, Property> get_the_value;
    Criteria<Property> property_criteria;

    public PropertyMatcher(IGetTheValueOfAProperty<Item, Property> get_the_value, 
      Criteria<Property> property_criteria)
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
}