using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Dissertation.Searching
{

	public class SearchEngine
	{

        Query query;
        string[] queryResults;
        Dictionary<int, Book[]> pages;
        Process luceneSearch = new Process();

        public SearchEngine(Query query)
        {
            Query = query;
            pages = new Dictionary<int, Book[]>();
        }
        
        public Dictionary<int, Book[]> Pages
        {
            get
            {
                return pages;
            }
        }

        public void search()
        {
            Console.WriteLine("Searching");
            JavaScriptSerializer jss = new JavaScriptSerializer();
                        
            var startInfo = new ProcessStartInfo("java", "-jar C:\\Users\\Justkunas\\Documents\\LuceneSearch.jar " + jss.Serialize(Query))
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };

            luceneSearch.StartInfo = startInfo;
            luceneSearch.Start();
            
            string[] results = luceneSearch.StandardOutput.ReadToEnd().Split(new char[] { '\n' });

            QueryResults = results;
            QueryResults = QueryResults.Take(QueryResults.Length - 1).ToArray();
            
            string path = "";
            int lastPage = 0;
            
            for (int i = 0; i < (QueryResults.Length/8); i++)
            {
                Book[] entry = new Book[8];
                for(int j = 0+(i*8); j < 8+(i*8); j++)
                {
                    entry[j - (i * 8)] = Book.parseXML(XElement.Load(QueryResults[j]));
                    path = QueryResults[j];
                }


                pages[i] = entry;
                lastPage = i;
            }

            Book[] lastEntry = new Book[8];
            for(int i = 0; i < 8; i++)
            {
                string url = QueryResults[QueryResults.Length - (8 - i)];
                XElement doc = XElement.Load(url);
                lastEntry[i] = Book.parseXML(doc);
            }

            var keys = pages.Keys;

            foreach(var key in keys)
            {
                Console.WriteLine(key);
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
