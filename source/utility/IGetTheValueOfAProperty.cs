namespace code.utility
{
  public delegate Property IGetTheValueOfAProperty<in Item, out Property>(Item item);
}