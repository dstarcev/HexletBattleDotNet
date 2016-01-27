using System.Collections.Generic;
using System.Linq;

public class SolutionClass {
	// collections represented as IList<object>
	// maps represented as IDictionary<string, object>
	// integers represented as long
	// floats represented as double
	public static object Solution(IList<object> args) {
		var keys = (ICollection<object>)args[0];
		return keys.ToDictionary(k => k, v => args[1]);
	}
}

