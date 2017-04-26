using System.Collections;
using System.Collections.Generic;

namespace code.prep.movies
{
  public class ReadOnlySet<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public ReadOnlySet(IEnumerable<T> items)
    {
      this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return items.GetEnumerator();
    }
  }
}