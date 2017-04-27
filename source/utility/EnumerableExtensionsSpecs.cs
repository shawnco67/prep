using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : spec.observe
    {
    }

    public class filtering_a_set_of_items_that_match_a_specification : concern
    {
      Establish c = () =>
      {
        numbers_processed = new List<int>();
        numbers = Enumerable.Range(1, 100);
        criteria = x =>
        {
          numbers_processed.Add(x);
          return x%2 == 0;
        };

      };

      Because b = () =>
        results = EnumerableExtensions.all_items_matching(numbers, criteria);

      It uses_its_specification_to_make_the_decision_on_which_items_got_included = () =>
        numbers_processed.Count.Equals(100);
        
      It returns_the_set_of_items_that_the_specification_matches = () =>
        results.Count().ShouldEqual(50);

      static IEnumerable<int> results;
      static IEnumerable<int> numbers;
      static Criteria<int> criteria;
      static IList<int> numbers_processed;
    }
  }
}
