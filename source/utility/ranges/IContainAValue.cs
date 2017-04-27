using System;

namespace code.utility.ranges
{
  public interface IContainAValue<Item> where Item : IComparable<Item>
  {
    bool contains(Item value); 
  }

  public class RangeWithNoUpperBound<Item> : IContainAValue<Item> where Item : IComparable<Item>
  {
    Item start;

    public RangeWithNoUpperBound(Item start)
    {
      this.start = start;
    }

    public bool contains(Item value)
    {
      return value.CompareTo(start) > 0;
    }
  }
}