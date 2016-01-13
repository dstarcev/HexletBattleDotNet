using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;

using NUnit.Framework;

public class Program {
	public static int Main(string[] args) {
		var cases = GetStdinLines()
			.Select(JsonConvert.DeserializeObject<ExpandoObject>);

		foreach (IDictionary<string, object> testCase in cases) {
			if (testCase.ContainsKey("check")) {
				Console.WriteLine(testCase["check"]);
				return 0;
			}

			try {
				var actual = SolutionClass.Solution((IList<object>)testCase["arguments"]);
				var actualJson = JsonConvert.SerializeObject(actual);
				var expectedJson = JsonConvert.SerializeObject(testCase["expected"]);
				Assert.AreEqual(expectedJson, actualJson);
			}
			catch (Exception ex) {
				Console.WriteLine(ex);
				break;
			}
		}

		return 1;
	}

	private static IEnumerable<string> GetStdinLines() {
		string line;
		while (!string.IsNullOrEmpty(line = Console.ReadLine())) {
			yield return line;
		}
	}
}