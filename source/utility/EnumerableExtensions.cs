using System.Collections.Generic;
using code.utility.matching;

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
      foreach (var m in items)
        if (criteria(m))
          yield return m;
    }

    public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, IMatchAn<Item> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }
  }
}