using System.Collections.Generic;

namespace code.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
    {
      foreach (var item in items) yield return item;
    }

    public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, Criteria<Item> criteria)
    {
      foreach (var item in items)
        if (criteria(item))
          yield return item;
    }

    public static Output reduce<Input, Output>(this IEnumerable<Input> items, Output initial_value, IReduce<Input, Output> reducer)
    {
      var current_value = initial_value;

      foreach (var item in items)
        current_value = reducer(current_value, item);

      return current_value;
    }

  }
}