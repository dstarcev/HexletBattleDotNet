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
			
			var argumentsJson = ToJson(testCase["arguments"]);
			var expectedJson = ToJson(testCase["expected"]);
			var solution = SolutionClass.Solution((IList<object>)testCase["arguments"]);
			var solutionJson = ToJson(solution);

			Assert.AreEqual(expectedJson, solutionJson, $"Arguments was {argumentsJson}");
		}

		return 1;
	}

	private static string ToJson(object obj) {
		return JsonConvert.SerializeObject(obj);
	}

	private static IEnumerable<string> GetStdinLines() {
		string line;
		while (!string.IsNullOrEmpty(line = Console.ReadLine())) {
			yield return line;
		}
	}
}