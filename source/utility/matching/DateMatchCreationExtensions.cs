using System;

namespace code.utility.matching
{
  public static class DateMatchCreationExtensions
  {
    public static Criteria<Item> greater_than<Item>(this MatchCreationExtensionPoint<Item, DateTime>
      extension_point, int year)
    {
      return extension_point.create_using(
        Match<DateTime>.with_attribute(x => x.Year)
          .greater_than(year)
        );
    }
  }
}