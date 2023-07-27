using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace xUnitTest
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private string FilePath;
        private string PropertyName;

        public JsonFileDataAttribute(string filePath, string propertyName)
        {
            FilePath = filePath;
            PropertyName = propertyName;
        }
        public override IEnumerable<object[]> GetData(MethodInfo TestMethod)
        {
            //FilePath = @"C:\Users\chinmay.routray\source\repos\Nunit Demo\xUnitTest\data.json";
            var data = File.ReadAllText(FilePath);
            if (string.IsNullOrEmpty(PropertyName))
            {
                return JsonConvert.DeserializeObject<IEnumerable<object[]>>(data);
            }
            var allData = JObject.Parse(data);
            var Data = allData[PropertyName];
            return Data.ToObject<List<object[]>>();
        }
    }

}
