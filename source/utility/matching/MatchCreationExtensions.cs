using System;

namespace code.utility.matching
{
  public static class MatchCreationExtensions
  {
    public static Criteria<Item> equal_to<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,Property value)
    {
      return create_using(extension_point, Criterias.equal_to(value));
    }

    public static Criteria<Item> equal_to_any<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,params Property[] values)
    {
      return create_using(extension_point, Criterias.equal_to_any(values));
    }

    public static Criteria<Item> not_equal_to<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,Property value)
    {
      return equal_to(extension_point, value).not();
    }

    public static Criteria<Item> create_using<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,IMatchAn<Property> property_matcher)
    {
      return create_using(extension_point, property_matcher.matches);
    }

    public static Criteria<Item> create_using<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,Criteria<Property> property_matcher)
    {
      return extension_point.create_using(property_matcher);
    }

    public static Criteria<Item> greater_than<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,Property value) where Property : IComparable<Property>
    {
      return create_using(extension_point, Criterias.greater_than(value));
    }

    public static Criteria<Item> between<Item, Property>(this MatchCreationExtensionPoint<Item,Property> extension_point,Property start, Property end) where Property : IComparable<Property>
    {
      return create_using(extension_point, Criterias.between(start, end));
    }

  }
}
