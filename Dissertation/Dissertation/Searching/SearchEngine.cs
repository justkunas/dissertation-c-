using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dissertation.Searching
{

	public class SearchEngine
	{
		public static int total = 2781399;
		readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
		public Dictionary<int,XElement[]> pages = new Dictionary<int, XElement[]>();
		public int pagesLoaded = 0;
		XElement titles;
		int closestLoc = 0;
		int length = 0;

		public void loadInPage(int offset)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var distance = (((length - closestLoc) > closestLoc) ? (length - closestLoc) : closestLoc);
			HashSet<XElement> page = new HashSet<XElement>();


            if (offset == 0)
            {
                page.Add(titles.Elements().ElementAt(closestLoc));

                for (var i = 1; i <= (offset + 3); i++)
                {
                    if ((closestLoc + i) < length)
                    {
                        page.Add(titles.Elements().ElementAt(closestLoc + i));
                    }

                    if ((closestLoc - i) > 0)
                    {
                        page.Add(titles.Elements().ElementAt(closestLoc - i));
                    }
                }

                page.Add(titles.Elements().ElementAt(closestLoc + 4));
            }
            else
            {
                for (var i = (offset); i < (offset + 4); i++)
                {
                    if ((closestLoc + i) < length)
                    {
                        page.Add(titles.Elements().ElementAt(closestLoc + i));
                    }

                    if ((closestLoc - i) > 0)
                    {
                        page.Add(titles.Elements().ElementAt(closestLoc - i));
                    }
                }
            }

			pagesLoaded++;
			pages[pagesLoaded] = page.ToArray();
        }

		public void quickSearch(string criteria)
		{
			Console.WriteLine("Parseing file please wait...");
			var doc = XElement.Load("C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\Titles.xml");
			Console.WriteLine("File parsed");
			string title;
			char startingChar = '\0';
			char firstAlphaChar = '\0';
			char secondAlphaChar = '\0';
			int alphLoc;

			for (int i = 0; i < criteria.Length; i++)
			{
				startingChar = criteria[i];
				if (alphabet.Contains(criteria[i]))
				{
					firstAlphaChar = criteria[i];

					for (int j = i + 1; j < (criteria.Length - i); j++)
					{
						if (alphabet.Contains(criteria[j]))
						{
							secondAlphaChar = criteria[j];
							break;
						}

					}
					break;
				}
			}

			for (int i = 0; i < alphabet.Length; i++)
			{
				if (alphabet[i] == secondAlphaChar)
				{
					alphLoc = i;
					break;
				}
			}

			titles = doc.Element(startingChar.ToString());

			//Check on special cases (titles that do not start with a letter)
			/*
			 * 1. start full loop
			 * 2. check if alphabet.Contains(title[0])
			 * 3. if yes break
			 * 4. else ...
			 */

			//Check regular cases

			length = titles.Elements().Count();
			var startingLocation = (int)Math.Ceiling((double)(titles.Elements().Count() / 2));
			var targetLocation = titles.Elements().Count();
			var countRemaining = titles.Elements().Count();
			var halfLocation = (int)Math.Ceiling((double)(titles.Elements().Count() / 2));

			var book = (titles.Elements().ElementAt(startingLocation));
			var loop = true;
			title = book.Element("Title").Value.ToUpper();


			while (loop)
			{
				for (int i = 0; i < title.Length; i++)
				{
					if (alphabet.Contains(title[i]))
					{
						for (int k = i + 1; k < title.Length - i; k++)
						{
							if (alphabet.Contains(title[k]))
							{
								//If the second letter comes after the second letter of the title in the alphabet
								if (secondAlphaChar == title[k])
								{
									closestLoc = halfLocation;
									goto exit;
								}

								if (secondAlphaChar > title[k])
								{
									countRemaining = (int)Math.Floor((double)(countRemaining / 2));
									startingLocation = (halfLocation + 1);
									targetLocation = (startingLocation + countRemaining) - 1;

								}
								else {
									countRemaining = (int)Math.Ceiling((double)(countRemaining / 2));
									startingLocation = (halfLocation - countRemaining);
									targetLocation = startingLocation + countRemaining;
								}

								halfLocation = (targetLocation - startingLocation) / 2;
								halfLocation += startingLocation;

								book = (titles.Elements().ElementAt(halfLocation));
								title = book.Element("Title").Value.ToUpper();

								goto loopend;
							}
						}
					}
				}
			loopend:;
			}

		exit:
			book = (titles.Elements().ElementAt(closestLoc));
			loop = false;
		}

	}
}
