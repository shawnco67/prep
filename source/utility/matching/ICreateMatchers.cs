namespace code.utility.matching
{
  public interface ICreateMatchers<Item, Property>
  {
    Criteria<Item> equal_to(Property value);
    Criteria<Item> equal_to_any(params Property[] values);
    Criteria<Item> not_equal_to(Property value);
    Criteria<Item> create_using(Criteria<Property> property_matcher);
    Criteria<Item> create_using(IMatchAn<Property> property_matcher);
  }
}