using System;
using System.Xml.Serialization;

namespace Cw2
{
    [Serializable]
    public class Study
    {
        public Study()
        {
        }
        
        [XmlElement(ElementName = "name")]
        public string Department { get; set; }
        [XmlElement(ElementName = "mode")]

        public string Mode { get; set; }

        public Study(string department, string mode)
        {
            this.Department = department;
            this.Mode = mode;
        }
        


        public override string ToString()
        {
            return Mode + " " + Department;
        }
    }
}