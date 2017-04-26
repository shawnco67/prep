namespace code.utility.matching
{
  public static class CriteriaExtensions
  {
    public static Criteria<Item> or<Item>(this Criteria<Item> left,
      Criteria<Item> right)
    {
      return x => left(x) || right(x);
    }

    public static Criteria<Item> not<Item>(this Criteria<Item> left)
    {
      return x => !left(x);
    }
  }
}