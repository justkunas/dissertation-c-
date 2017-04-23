using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Dissertation.Searching
{

    public class SearchEngine
    {

        Query query, lastQuery;
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
                dataReader.Add(e.Data.ToString());
        }

        private void errorReader(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.ToString() != null)
                errReader.Add(e.Data.ToString());
        }

        public void search()
        {
            dataReader.Clear();
            errReader.Clear();
            pages.Clear();
            luceneSearch = new Process();
            bool dontSkip = (lastQuery.query != Query.query);

            Console.WriteLine(lastQuery.query == Query.query);

            if (dontSkip)
            {
                QueryResults = null;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=Searching=-=-=-=-=-=-=-=-=-=-=-=-=");
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jarLoc = "";
                //string jarLoc = "C:\\Users\\Justkunas\\Documents\\"

                var startInfo = new ProcessStartInfo("java", "-jar " + jarLoc + "LuceneSearch.jar " + jss.Serialize(Query))
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
            }

            if (dontSkip)
                QueryResults = dataReader.ToArray();

            Console.WriteLine(Query.filters.listprice.enabled || Query.filters.numberofpages.enabled);
            if (Query.filters.listprice.enabled || Query.filters.numberofpages.enabled)
            {
                Console.WriteLine("Checking filters");
                HashSet<string> filteredResults = new HashSet<string>();
                foreach(string s in QueryResults)
                {
                    Book book = Book.parseXML(XElement.Load(s));

                    int min = Query.filters.listprice.min;
                    int max = Query.filters.listprice.max;
                    bool meetRequirements = true;

                    if (Query.filters.listprice.enabled)
                        meetRequirements &= (min <= book.ListPriceValue) && (book.ListPriceValue <= max);

                    min = Query.filters.numberofpages.min;
                    max = Query.filters.numberofpages.max;

                    if (Query.filters.numberofpages.enabled)
                        meetRequirements &= (min <= book.NumberOfPages) && (book.NumberOfPages <= max);

                    if (meetRequirements)
                        filteredResults.Add(s);
                }
                QueryResults = filteredResults.ToArray();
            } else
            {
                Console.WriteLine("skipping filters");
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
                        entry[j - (i * 8)] = Book.parseXML(XElement.Load(QueryResults[j]));
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
            }else
            {
                Book[] soleEntry = new Book[QueryResults.Length];
                for(int i = 0; i < QueryResults.Length; i++)
                {
                    XElement doc = XElement.Load(QueryResults[i]);
                    soleEntry[i] = Book.parseXML(doc);
                }
                pages[0] = soleEntry;
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
