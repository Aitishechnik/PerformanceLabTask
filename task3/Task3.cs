using Newtonsoft.Json;
using System.Diagnostics;

namespace PerformanceLabTask
{
    public class Task3
    {
        public void SolveTask3(string valuesPath, string testsPath, string reportPath)
        {
            string tests = ReadData(testsPath);
            string values = ReadData(valuesPath);
            var dict = SetValuesToDict(values);
            var rootTests = DeserializeTests(tests);
            FillFormWithValues(rootTests.Tests, dict);
            GenerateReport(rootTests, reportPath);
        }

        public Dictionary<int, string> SetValuesToDict(string values)
        {
            var rootObject = JsonConvert.DeserializeObject<RootValues>(values);
            var dictionary = new Dictionary<int, string>();

            foreach (var item in rootObject.Values)
            {
                dictionary[item.Id] = item.Value;
            }

            return dictionary;
        }

        private string ReadData(string path)
        {
            string result;
            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        private RootTests DeserializeTests(string tests)
        {
            var testWrapper = JsonConvert.DeserializeObject<RootTests>(tests);
            return testWrapper;
        }

        private void FillFormWithValues(List<TestJSON> tests, Dictionary<int, string> values)
        {
            foreach (var test in tests)
            {
                if (!test.isVisited)
                {
                    try { test.Value = values[test.Id]; }
                    catch (Exception ex) { Debug.WriteLine(ex.Message); }
                    finally { test.isVisited = true; }

                    if (test.Values != null)
                        FillFormWithValues(test.Values, values);
                }
                test.isVisited = false;
            }
        }

        private void GenerateReport(RootTests report, string reportPath)
        {
            var obj = JsonConvert.SerializeObject(report, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(reportPath))
            {
                sw.WriteLine(obj);
            }
        }

        public class ValueJSON
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public class RootValues
        {
            public List<ValueJSON> Values { get; set; }
        }

        public class TestJSON
        {
            public int Id { get; set; }
            public string Title { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Value { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<TestJSON> Values { get; set; }
            [JsonIgnore]
            public bool isVisited = false;
        }

        public class RootTests
        {
            public List<TestJSON> Tests { get; set; }
        }
    }
}
