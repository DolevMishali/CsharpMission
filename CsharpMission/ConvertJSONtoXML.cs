using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.IO;
using System;
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
            string path = @"C:\Users\dolev\repos\Qualitest - Entrance test\01. Instructions\exam.json";
            StreamReader sr = new StreamReader(path);
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

        }
    }
}





/* ----------- The easy way using newton.json ----------- */

//string inputPath = @"C:\Users\dolev\repos\Qualitest - Entrance test\01. Instructions\exam.json";
//string outputPath = @"C:\Users\dolev\repos\Qualitest - Entrance test\01. Instructions\output.xml";

//// Read JSON input file
//string jsonString = File.ReadAllText(inputPath);

//// Convert JSON to XML
//JObject jsonObject = JObject.Parse(jsonString);
//XNode convertedXml = JsonConvert.DeserializeXNode(jsonObject.ToString(), "Root");

//// Save XML output to file
//using (var writer = new StreamWriter(outputPath))
//{
//    writer.Write(convertedXml.ToString());
//}