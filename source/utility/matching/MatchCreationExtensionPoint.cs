namespace code.utility.matching
{
  public class MatchCreationExtensionPoint<Item, Property>
  {
    IGetTheValueOfAProperty<Item, Property> accessor;
    bool negate; 

    public MatchCreationExtensionPoint<Item, Property> not
    {
      get
      {
        negate = true;
        return this;
      }
    }

    public MatchCreationExtensionPoint(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      this.accessor = accessor;
    }

    public Criteria<Item> create_using(Criteria<Property> property_matcher)
    {
      Criteria<Item> specification = new PropertyMatcher<Item, Property>(this.accessor,property_matcher).matches;

      return negate ? specification.not() : specification;
    }
  }
}