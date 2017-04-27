namespace code.utility.matching
{
  public interface IProvideAccessToMatchBuilders<Item, Property>
  {
    Criteria<Item> create_using(Criteria<Property> property_matcher);
  }
}