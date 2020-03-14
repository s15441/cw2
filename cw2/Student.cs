using System;
using System.Xml.Serialization;

namespace Cw2
{
    [Serializable]
    public class Student
    {
        public Student()
        {
            
        }
        public Student(string firstName, string lastName, string index, string mail, DateTime birthDay, string moName, string faName, Study studies)
        {
            FirstName = firstName;
            LastName = lastName;
            Index = index;
            Mail = mail;
            BirthDay = birthDay;
            MoName = moName;
            FaName = faName;
            Studies = studies;
        }

        [XmlElement(ElementName = "fname")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "lname")]

        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "Indeks")]
        public string Index { get; set; }        
        [XmlElement(ElementName = "email")]

        public string Mail { get; set; }
        [XmlElement(ElementName = "birthdate")]

        public DateTime BirthDay { get; set; }
        [XmlElement(ElementName = "mothersname")]

        public string MoName { get; set; }
        [XmlElement(ElementName = "fathersname")]

        public string FaName { get; set; }
        public Study Studies { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Index + " " + Mail + " " +BirthDay.ToShortDateString()+ " " + MoName + " " + FaName + " " + Studies.ToString();
        }
    }
}