using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {

                string input, output, format;
                if (args.Length != 3)
                {
                    input = "data.csv";
                    output = @"/Users/MGasowski/Desktop/Cw2/cw2/cw2/result.xml";
                    format = "xml";
                }
                else
                {
                    input = args[0];
                    output = args[1];
                    format = args[2];
                }



                var path = @"/Users/MGasowski/Desktop/Cw2/cw2/cw2/dane.csv";
                var log = @"/Users/MGasowski/Desktop/Cw2/cw2/cw2/log.txt";
                var lines = File.ReadLines(path);

                var hash = new HashSet<Student>(new OwnComparer());

                using (StreamWriter file = new StreamWriter(log))
                {
                    try
                    {

                        foreach (var line in lines)
                        {
                            bool correct = true;
                            var data = line.Split(',');
                            if (data.Length != 9)
                            {
                                file.WriteLine(DateTime.Now + " Invalid data length >> " + line);
                            }
                            else
                            {
                                foreach (var value in data)
                                {
                                    if (string.IsNullOrWhiteSpace(value))
                                    {
                                        file.WriteLine(DateTime.Now + " Invalid data format >> " + line);
                                        correct = false;
                                    }
                                }

                            }

                            if (correct)
                            {
                                var studia = new Study(data[2], data[3]);
                                var student = new Student(
                                    data[0],
                                    data[1],
                                    data[4],
                                    data[6],
                                    DateTime.Parse(data[5]),
                                    data[7],
                                    data[8],
                                    studia
                                );

                                // Console.WriteLine(student.ToString());

                                if (!hash.Add(student))
                                {
                                    file.WriteLine(DateTime.Now + " Record duplicated >> " + student);
                                }
                            }
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine(DateTime.Now + "Podana ścieżka jest niepoprawna");
                        file.WriteLine(DateTime.Now + "Podana ścieżka jest niepoprawna");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine(DateTime.Now + "Plik "+ input+" nie istnieje");
                        file.WriteLine(DateTime.Now + "Plik "+ input+" nie istnieje");
                    }
                }

                var activeStudies = new Dictionary<string, int>();

                foreach (var v in hash)
                {
                    if (activeStudies.ContainsKey(v.Studies.Department))
                        activeStudies[v.Studies.Department]++;
                    else
                        activeStudies.Add(v.Studies.Department, 1);
                }
                

                FileStream writer = new FileStream(output, FileMode.Create);
                
                XmlSerializer serializer =
                    new XmlSerializer(typeof(HashSet<Student>),
                        new XmlRootAttribute("uczelnia"));
                foreach (var st in hash)
                {
                    serializer.Serialize(writer, hash);
                }



        }
    }
}
