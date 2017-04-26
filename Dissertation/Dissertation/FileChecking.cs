using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Dissertation
{
    public class FileChecking
    {
        public static void checkForAllSpecifics()
        {
            string[] xmlToFind = { "blurbers" };
            string[] folders = { @"C:\Users\Justkunas\Documents\Amazon Books\xml\999" };

            HashSet<string> temp = new HashSet<string>();

            for(int i = 999; i > 499 ; i--)
            {
                string folder = @"C:\Users\Justkunas\Documents\Amazon Books\xml\" + i;
                Console.WriteLine(folder);
                temp.Add(folder);
            }

            folders = temp.ToArray();

            string[] files;
            HashSet<string> complete = new HashSet<string>();
            char[] illeagalChars = { '.' };
            XElement xEle;
            double total = 0;
            double counter = 0;

            foreach (string folder in folders)
            {
                Console.WriteLine("Counting files in " + folder);
                files = Directory.GetFiles(folder);
                total += files.Count();
            }

            DateTime start = DateTime.Now; 
            Console.WriteLine("Files to check:" + total);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            foreach (string folder in folders)
            {
                files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string[] splitFile = file.Split(illeagalChars);
                    if (splitFile[1] == "dtd")
                    {
                        //Console.WriteLine("Break");
                        break;
                    }

                    counter++;
                    //Console.WriteLine(counter + " : " + total + " : " + (counter / total));
                    Console.WriteLine("Checking file " + file + " - " + string.Format("{0:0.00}", (counter / total) * 100) + "%");
                    xEle = XElement.Load(file);
                    bool filled = true;
                    foreach (XElement element in xEle.Elements())
                    {

                        if (xmlToFind.Contains(element.Name.ToString()))
                        {
                            filled &= ((element.Value.ToString() != "")|| element.HasElements);
                        }
                        
                    }

                    if (filled)
                    {
                        complete.Add(file);
                    }
                }
            }

            Console.WriteLine("All files checked\nComplete files:");

            foreach (string file in complete)
            {
                Console.WriteLine(file);
            }

        }
        public static void checkForAll()
        {
            string[] folders = { "C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\998" };//Directory.GetDirectories("C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\999");
            string[] files;
            HashSet<string> complete = new HashSet<string>();
            char[] illeagalChars = { '.' };
            XElement xEle;
            double total = 0;
            double counter = 0;

            foreach (string folder in folders)
            {
                Console.WriteLine("Counting files in " + folder);
                files = Directory.GetFiles(folder);
                total += files.Count();
            }

            DateTime start = DateTime.Now;
            Console.WriteLine("Files to check:" + total);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            foreach(string folder in folders)
            {
                files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string[] splitFile = file.Split(illeagalChars);
                    if (splitFile[1] == "dtd")
                    {
                        //Console.WriteLine("Break");
                        break;
                    }

                    counter++;
                    //Console.WriteLine(counter + " : " + total + " : " + (counter / total));
                    Console.WriteLine("Checking file " + file + " - " + string.Format("{0:0.00}", (counter/total)*100) + "%");
                    xEle = XElement.Load(file);
                    bool filled = true;
                    foreach (XElement element in xEle.Elements())
                    {
                        if (element.HasElements)
                        {
                            //Console.WriteLine("Has elements");
                        }else
                        {
                            //Console.WriteLine("Has no elements");
                            filled &= (element.Value.ToString() != "");
                        }
                    }

                    if (filled)
                    {
                        complete.Add(file);
                    }
                }
            }

            Console.WriteLine("All files checked\nComplete files:");

            foreach(string file in complete)
            {
                Console.WriteLine(file);
            }

        }

        public static void imageCount()
        {
            char[] illeagalChars = { '.' };
            XElement doc;
            int quant = 0;
            int total = 0;

            int max = 0;
            string fileWithMost = "";

            double percent;
            
            string[] folders = Directory.GetDirectories(@"C:\Users\Justkunas\Documents\Amazon Books\xml");
            //string[] folders = new string[] { @"C:\Users\Justkunas\Documents\Amazon Books\xml\999"};
            string[] files;
            //*
            HashSet<string> temp = new HashSet<string>();

            for (int i = 999; i > 699; i--)
            {
                string folder = @"C:\Users\Justkunas\Documents\Amazon Books\xml\" + i;
                Console.WriteLine(folder);
                temp.Add(folder);
            }

            folders = temp.ToArray();
            //*/

            foreach (string folder in folders)
            {
                Console.WriteLine("Counting files in " + folder);
                files = Directory.GetFiles(folder);
                total += files.Count();
            }

            DateTime start = DateTime.Now;
            Console.WriteLine("Files to check:" + total);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


            foreach (string folder in folders)
            {
                files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string[] splitFile = file.Split(illeagalChars);

                    quant++;

                    percent = (((double)quant / (double)total) * 100);
                    Console.WriteLine("Checking file: " + file + " - " + string.Format("{0:0.00}", percent) + "%");

                    if (splitFile[1] == "dtd")
                    {
                        Console.WriteLine("Break");
                        break;
                    }

                    doc = XElement.Load(file);
                    Book book = Book.parseXML(doc);

                    if (book.Blurbers.Count > max)
                    {
                        fileWithMost = file;
                        max = book.Blurbers.Count;
                    }

                }
            }
            DateTime end = DateTime.Now;

            Console.WriteLine(fileWithMost + " contained the most images at " + max + " images." );
            
            Console.WriteLine("Time elapased " + end.Subtract(start).Minutes + "m " + end.Subtract(start).Seconds + "s.");
            if (end.Subtract(start).Minutes > 0)
            {
                Console.WriteLine("Check rate " + (total / end.Subtract(start).Minutes) + " files per minute");
            }
            else
            {
                Console.WriteLine("Check rate " + (total / end.Subtract(start).Seconds) + " files per second");
            }
        }

        public static void checkAll()
        {
            string[] xmlToCheck = { "authorid", "summary", "content" };
            char[] illeagalChars = { '.' };
            HashSet<string> filesWithInfo = new HashSet<string>();
            Dictionary<string, bool> doesContain = new Dictionary<string, bool>();
            XElement doc;
            int quant = 0;
            int total = 0;
            double percent;


            foreach (string xml in xmlToCheck)
            {
                doesContain.Add(xml, false);
            }

            //string[] folders = Directory.GetDirectories("C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml");
            //*
            HashSet<string> workFolders = new HashSet<string>();

            for(int i = 999; i > 699; i--)
            {
                workFolders.Add("C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\" + i);
            }

            string[] folders = workFolders.ToArray<string>();
            //*/
            string[] files;

            foreach (string folder in folders)
            {
                Console.WriteLine("Counting files in " + folder);
                files = Directory.GetFiles(folder);
                total += files.Count();
            }

            DateTime start = DateTime.Now;
            Console.WriteLine("Files to check:" + total);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


            foreach (string folder in folders)
            {
                files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string[] splitFile = file.Split(illeagalChars);

                    quant++;

                    percent = (((double)quant / (double)total) * 100);
                    Console.WriteLine("Checking file: " + file + " - " + string.Format("{0:0.00}", percent) + "%");

                    if (splitFile[1] == "dtd")
                    {
                        Console.WriteLine("Break");
                        break;
                    }

                    doc = XElement.Load(file);
                    IEnumerable<XElement> elements = doc.Elements();

                    foreach (XElement element in elements)
                    {
                        foreach (string xml in xmlToCheck)
                        {
                            if (element.Name.ToString() == xml)
                            {
                                if (doc.Element(xml).Value != "")
                                {
                                    doesContain[element.Name.ToString()] = true;
                                    filesWithInfo.Add(file);
                                }
                            }
                        }
                    }
                }
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("Objects in questions that contain data:");

            Console.WriteLine(filesWithInfo.Count);

            foreach (string file in filesWithInfo)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine(quant);
            Console.WriteLine("Time elapased " + end.Subtract(start).Minutes + "m " + end.Subtract(start).Seconds + "s.");
            if (end.Subtract(start).Minutes > 0)
            {
                Console.WriteLine("Check rate " + (total / end.Subtract(start).Minutes) + " files per minute");
            }else
            {
                Console.WriteLine("Check rate " + (total / end.Subtract(start).Seconds) + " files per second");
            }
        }

    }
}
