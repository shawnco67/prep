using code.prep.movies;

namespace code.utility.matching
{
  public class OrCriteria<Item> : IMatchAn<Item>
  {
    Criteria<Item> left;
    Criteria<Item> right;

    public OrCriteria(Criteria<Item> left, Criteria<Item> right)
    {
      this.left = left;
      this.right = right;
    }

    public bool matches(Item item)
    {
      return left(item) || right(item);
    } 
  }
}