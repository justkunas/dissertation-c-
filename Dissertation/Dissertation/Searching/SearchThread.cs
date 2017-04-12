using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace Dissertation.Searching
{

	class SearchThread
	{
		private char[] bannedChars1 = { '\\', '.' };
		private char[] bannedChars2 = { '.' };
		private char[] bannedChars3 = { ' ' };
		private string[] assignedFolders, searchArr;
		private string searchCriteria;
		private Dictionary<string, int> results;

		public SearchThread(string[] assignedFolders, string searchCriteria)
		{
			AssignedFolders = assignedFolders;
			SearchCriteria = searchCriteria;
			searchArr = SearchCriteria.Split(bannedChars3);
			results = new Dictionary<string, int>();
		}

		public void search()
		{
			foreach (string folder in AssignedFolders)
			{
				int score = 0;
				foreach (string file in Directory.GetFiles(folder))
				{
					string[] checkFile = file.Split(bannedChars2);

					if (checkFile[1] == "dtd")
					{
						break;
					}

					Console.WriteLine("===========Searching " + file + "===========");

					XElement ele = XElement.Load(file);
					Book book = Book.parseXML(ele);
					Type t = typeof(Book);
					PropertyInfo[] props = t.GetProperties();

					foreach (PropertyInfo prop in props)
					{
						if (prop.PropertyType == typeof(string))
						{
							Console.WriteLine("Checking property " + prop.Name);
							if ((string)prop.GetValue(book) != "" && Book.Values.ContainsKey(prop.Name))
							{
								//Console.WriteLine("Getting score");
								score += (5 * Book.Values[prop.Name]) + searchString((string)prop.GetValue(book), searchArr);
							}
						}
					}

					if (score > 0)
						results.Add(file, score);
				}
				//Console.WriteLine(folder.Substring(46));
			}
		}

		public static int searchString(string source, string[] criteria)
		{
			int value = 0;

			Console.WriteLine("Checking " + source + " against " + string.Join("", criteria));

			for (int i = 0; i < criteria.Length; i++)
			{
				for (int j = 0; j < (criteria.Length - i); j++)
				{
					string check = "";
					for (int k = 0; k < (i + 1); k++)
					{
						check += criteria[j + k];
						if (k < i)
							check += " ";
					}

					//Console.WriteLine("Checking \"" + check + "\" against \"" + source + "\"");
					try
					{
						if (source.Contains(check))
						{
							Console.WriteLine("Match on: " + check);
							value++;
						}
					}
					catch (Exception err)
					{
						Console.Error.WriteLine(err.Message);
						Console.Error.WriteLine(err.Source);
						Console.Error.WriteLine(err.StackTrace);
					}
				}
			}
			return value;
		}


		public string[] AssignedFolders
		{
			get
			{
				return assignedFolders;
			}

			set
			{
				assignedFolders = value;
			}
		}

		public string SearchCriteria
		{
			get
			{
				return searchCriteria;
			}

			set
			{
				searchCriteria = value;
			}
		}

		public Dictionary<string, int> Results
		{
			get
			{
				return results;
			}

			set
			{
				results = value;
			}
		}
	}
}
