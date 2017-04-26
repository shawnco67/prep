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
  }
}