using Newtonsoft.Json.Linq; // JObject using Linq
using System.Xml.Linq; // XElement using Linq

namespace CSharpTask
{
    class Json2XMLConverter
    {
        static void Main()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDir, @"..\..\..\..\exam.json");
            string outputFilePath = Path.Combine(currentDir, @"..\..\..\..\exam.xml");
            string jsonString = File.ReadAllText(inputFilePath);
            string xmlOutput = "";
            JObject json = JObject.Parse(jsonString);

            if(true)
            {
                // Create a new XElement for the root element of the XML
                XElement root = new XElement("Root");

                // Loop through each person in the JSON object
                foreach (JObject person in json["persons"])
                {
                    // Create a new XElement for the person
                    XElement personElement = new XElement("persons");

                    // Add the person's elements with XElement name/person, age, occupation
                    if (person["name"] is null)
                        personElement.Add(new XElement("person", (string)person["person"]));
                    else
                        personElement.Add(new XElement("name", (string)person["name"]));

                    personElement.Add(new XElement("age", (int)person["age"]));
                    personElement.Add(new XElement("occupation", (string)person["occupation"]));

                    // Add the person XElement to the root XElement
                    root.Add(personElement);
                }

                xmlOutput = root.ToString();
            }
            else
            {
                /* ----------- The easiest way using newton external package ----------- */

                // Convert JSON to XML
                JObject jsonObject = JObject.Parse(jsonString);
                XNode convertedXml = Newtonsoft.Json.JsonConvert.DeserializeXNode(jsonObject.ToString(), "Root");
                xmlOutput = convertedXml.ToString();
            }

            // Save XML output to file
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.Write(xmlOutput);
            }
        }
    }
}