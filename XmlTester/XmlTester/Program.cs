using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlTester
{
    public class Program
    {
        static string xmlDoc = @"<Users><User><Name>EHE</Name><Gender>Male</Gender><Age>35</Age></User>
                                <User><Name>EHE</Name><Gender>Male</Gender><Age>35</Age></User>
                                <User><Name>EHE</Name><Gender>Male</Gender><Age>35</Age></User></Users>";

        static void Main(string[] args)
        {
            XDocument doc = XDocument.Parse(xmlDoc);

            List<User> list = doc.Root.Elements("User")
                               .Select(element => new User{ Name=element.Element("Name").Value, 
                                   Gender=element.Element("Gender").Value, Age = Convert.ToInt32(element.Element("Age").Value) } )
                               .ToList();



        }
    }


    public class User {

        public User() { }

        

        public string Name { get; set; }


        public string Gender { get; set; }

        public int Age { get; set; }
    }
}
