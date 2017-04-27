namespace code.utility.matching
{
  public class MatchCreationExtensionPoint<Item, Property> : IProvideAccessToMatchBuilders<Item, Property>
  {
    IGetTheValueOfAProperty<Item, Property> accessor;

    public IProvideAccessToMatchBuilders<Item, Property> not
    {
      get
      {
        return new NegatedExtensionPoint(this);
      }
    }

    class NegatedExtensionPoint : IProvideAccessToMatchBuilders<Item, Property>
    {
      IProvideAccessToMatchBuilders<Item, Property> original;

      public NegatedExtensionPoint(IProvideAccessToMatchBuilders<Item, Property> original)
      {
        this.original = original;
      }

      public Criteria<Item> create_using(Criteria<Property> property_matcher)
      {
        return original.create_using(property_matcher).not();
      }
    }

    public MatchCreationExtensionPoint(IGetTheValueOfAProperty<Item, Property> accessor)
    {
      this.accessor = accessor;
    }

    public Criteria<Item> create_using(Criteria<Property> property_matcher)
    {
      return new PropertyMatcher<Item, Property>(this.accessor,property_matcher).matches;
    }
  }
}