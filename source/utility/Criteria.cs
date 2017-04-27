using System;
using code.utility.matching;

namespace code.utility
{
  public delegate bool Criteria<in Item>(Item item);

  public class Criterias
  {
    public static Criteria<Item> never_matches<Item>()
    {
      return x => false; 
    }

    public static Criteria<Item> always_matches<Item>()
    {
      return x => true; 
    }

    public static Criteria<Property> greater_than<Property>(Property value) where Property : IComparable<Property>
    {
      return x => x.CompareTo(value) > 0;
    }

    public static Criteria<Property> equal_to<Property>(Property value)
    {
      return x => x.Equals(value);
    }

    public static Criteria<Property> equal_to_any<Property>(params Property[] values)
    {
      return values.reduce(Criterias.never_matches<Property>(),
        (accumulator, value) => accumulator.or(equal_to(value)));
    }

    public static Criteria<Property> between<Property>(Property start, Property end) where Property : IComparable<Property>
    {
      return x => x.CompareTo(start) >= 0 && x.CompareTo(end) <= 0;
    }
  }

}