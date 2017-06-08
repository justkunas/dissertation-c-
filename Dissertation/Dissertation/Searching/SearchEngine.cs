using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Dissertation.LuceneCommand;
using System.Xml;

namespace Dissertation.Searching
{

    public class SearchEngine
    {

        Query query, lastQuery;
        LuceneCommand command;
        string[] queryResults;
        HashSet<string> dataReader = new HashSet<string>();
        HashSet<string> errReader = new HashSet<string>();
        Dictionary<int, Book[]> pages;
        Process luceneSearch = new Process();

        public SearchEngine(Query query)
        {
            Query = query;
            lastQuery = new Query("",null);
            pages = new Dictionary<int, Book[]>();
        }

        public Dictionary<int, Book[]> Pages
        {
            get
            {
                return pages;
            }
        }

        private void outputReader(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.ToString() != null)
            {
                dataReader.Add(e.Data.ToString());
                Console.WriteLine("outputReader: " + e.Data.ToString());
            }
        }

        private void errorReader(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.ToString() != null)
                errReader.Add(e.Data.ToString());
        }

        public void search()
        {
            Console.WriteLine(Command);

            dataReader.Clear();
            errReader.Clear();
            pages.Clear();
            luceneSearch = new Process();

            QueryResults = null;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=Searching=-=-=-=-=-=-=-=-=-=-=-=-=");
            string jarLoc = "";
            //string jarLoc = "C:\\Users\\Justkunas\\Documents\\"

            var startInfo = new ProcessStartInfo("java", "-jar " + jarLoc + "LuceneClient.jar " + JsonConvert.SerializeObject(Command))
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };

            luceneSearch.StartInfo = startInfo;
            luceneSearch.OutputDataReceived += outputReader;
            luceneSearch.ErrorDataReceived += errorReader;
            luceneSearch.Start();
            luceneSearch.BeginOutputReadLine();
            luceneSearch.BeginErrorReadLine();

            luceneSearch.WaitForExit();
            Console.WriteLine("Exited");
            lastQuery = Query;

            luceneSearch.OutputDataReceived -= outputReader;
            luceneSearch.ErrorDataReceived -= errorReader;

            luceneSearch.CancelOutputRead();
            luceneSearch.CancelErrorRead();
            
            QueryResults = dataReader.ToArray();


            foreach(string s in errReader)
            {
                Console.Error.WriteLine(s);
            }

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("\"" + QueryResults[0] + "\"");
            Console.WriteLine("Size: " + (QueryResults[0].Length));

            JObject jsonResults = null;

            if (QueryResults.Length != 0 && QueryResults[0].Length != 0)
                jsonResults = JObject.Parse(QueryResults.ElementAt(0));

            if (QueryResults.Length == 0 || jsonResults == null)
            {
                Console.WriteLine("Loading blank dictionary.");
                pages = new Dictionary<int, Book[]>();
                pages[0] = new Book[0];
            }
            else
            {
                Console.WriteLine("Sorting results");
                JArray jArr = (JArray)jsonResults["results"];

                QueryResults = new string[jArr.Count];
                for (int i = 0; i < jArr.Count; i++)
                {
                    QueryResults[i] = jArr.ElementAt(i).ToString();
                }

                string path = "";
                int lastPage = 0;

                Console.WriteLine(QueryResults.Length);

                if (QueryResults.Length > 8)
                {
                    for (int i = 0; i < (QueryResults.Length / 8); i++)
                    {
                        Book[] entry = new Book[8];
                        for (int j = 0 + (i * 8); j < 8 + (i * 8); j++)
                        {
                            XElement ele = XElement.Load(new XmlNodeReader(JsonConvert.DeserializeXmlNode(QueryResults[i])));
                            entry[j - (i * 8)] = Book.parseXML(ele);
                            path = QueryResults[j];
                        }


                        pages[i] = entry;
                        lastPage = i;
                    }

                    Book[] lastEntry = new Book[8];
                    for (int i = 0; i < 8; i++)
                    {
                        string url = QueryResults[QueryResults.Length - (8 - i)];
                        XElement doc = XElement.Load(url);
                        lastEntry[i] = Book.parseXML(doc);
                    }
                    var keys = pages.Keys;
                }
                else
                {
                    Book[] soleEntry = new Book[QueryResults.Length];
                    for (int i = 0; i < QueryResults.Length; i++)
                    {
                        XElement ele = XElement.Load(new XmlNodeReader(JsonConvert.DeserializeXmlNode(QueryResults[i])));
                        soleEntry[i] = Book.parseXML(ele);
                    }
                    pages[0] = soleEntry;
                }
            }
            //*/
        }

        public LuceneCommand Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }

        public Query Query
        {
            get
            {
                return query;
            }

            set
            {
                query = value;
            }
        }

        public string[] QueryResults
        {
            get
            {
                return queryResults;
            }

            set
            {
                queryResults = value;
            }
        }

    }
}
