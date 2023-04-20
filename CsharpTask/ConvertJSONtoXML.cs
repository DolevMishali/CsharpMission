using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace ReadJSONFile
{
    class Convert
    {
        static void Main()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDir, @"..\..\..\..\exam.json");
            string outputFilePath = Path.Combine(currentDir, @"..\..\..\..\exam.xml");
            StreamReader sr = new StreamReader(inputFilePath);
            string jsonString = sr.ReadToEnd();
            Dictionary<string, object> wrapperDict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

            foreach (KeyValuePair<string, object> keyValuePair in wrapperDict)
            {
                if (keyValuePair.Value != null)
                {
                    var arrayWrapper = keyValuePair.Value.ToString().Split('{');
                    Dictionary<string, int> innerDict = arrayWrapper.ToDictionary(x => x, x => x.Length);
                    for (int i = 0; i < innerDict.Count; i++)
                    {
                        Console.WriteLine();
                    }
                }
            }



            /* ----------- The easies way using newton external package ----------- */

            //// Read JSON input file
            //string jsonString = File.ReadAllText(inputFilePath);

            //// Convert JSON to XML
            //JObject jsonObject = JObject.Parse(jsonString);
            //XNode convertedXml = JsonConvert.DeserializeXNode(jsonObject.ToString(), "Root");

            //// Save XML output to file
            //using (var writer = new StreamWriter(outputFilePath))
            //{
            //    writer.Write(convertedXml.ToString());
            //}
        }
    }
}




