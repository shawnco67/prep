namespace code.utility.matching
{
  public class Match<Item>
  {
    public static MatchCreationExtensionPoint<Item, Property>
      with_attribute<Property>(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      return new MatchCreationExtensionPoint<Item, Property>(accessor);
    }
  }
}