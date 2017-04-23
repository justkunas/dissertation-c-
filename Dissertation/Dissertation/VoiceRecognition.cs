using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Drawing;

namespace Dissertation
{
    public class VoiceRecognition
    {

        enum AllFilters { PRICE, PAGES, NONE };
        enum Changes { MINIMUM, MAXIMUM, NONE };
        enum YesNoOptions { SEARCH, SAVE, CHANGE, EXIT, NONE };
        enum Views { PRODUCTS, SEARCH, PORDUCTINFO };

        AllFilters currFilter = AllFilters.NONE;
        Changes changing = Changes.NONE;
        YesNoOptions choiceOption = YesNoOptions.NONE;
        Views currView = Views.PRODUCTS;

        SpeechRecognitionEngine dict, start, filter;
        Grammar browseGrammar, searchingGrammar, filterGrammar, filterValueGrammar, yesNoGrammar, saveGrammar, numberGrammar, infoGrammar;
        DictationGrammar dictationGrammar;
        string[] filterValueCommands, browseCommands, searchingCommands, filterCommands, yesNoCommands, saveCommands, numberCommands, infoCommands;
        EventHandler<SpeechRecognizedEventArgs> startBrowse, dictSearch, dictFilter, filterCheck, filterValueCheck, yesNoCheck, numberCheck, infoCheck;
        
        bool treatNextAsWord = false;
        IView currentView;
        Timer timer = new Timer();

        int min = -1;
        int max = -1;

        ListPrice listPrice = new ListPrice(987654321, 0);
        ListPrice workingListPrice;
        NumberOfPages numberOfPages = new NumberOfPages(123456789, 0);
        NumberOfPages workingNumberOfPages;
        Filters queryFilters;
        Query query;

        EventHandler<SpeechRecognizedEventArgs>[] events;

        Dictionary<string, long> numberRepresentation = new Dictionary<string, long>
        {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
        {"fourteen",14},{"fifteen",15},{"sixteen",16},
        {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
        {"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},
        {"seventy",70},{"eighty",80},{"ninety",90},{"hundred",100},
        {"thousand",1000}};
        //SpeechRecognizer recog;

        public VoiceRecognition()
        {
            Console.WriteLine("Voice recognition system loading");

            queryFilters = new Filters(this.listPrice, null, this.numberOfPages);

            dict = new SpeechRecognitionEngine();
            start = new SpeechRecognitionEngine();
            filter = new SpeechRecognitionEngine();

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            browseCommands = new string[] { "search", "filter", "filters", "next", "previous", "exit", "view" };
            searchingCommands = new string[] { "search", "word", "incorrect", "filter", "filters", "exit" };
            filterCommands = new string[] { "search", "price", "list price", "prices", "pages", "numebr of pages", "exit" };
            filterValueCommands = new string[] { "enable", "disable", "enabled", "min", "minimum", "max", "maximum", "exit" };
            yesNoCommands = new string[] { "yes", "no" };
            saveCommands = new string[] { "save", "exit" };
            numberCommands = new string[] { "one","two","three","four","five","six","seven","eight","exit" };
            infoCommands = new string[] { "more", "images", "more images", "reviews", "blurbers", "similar", "similar products", "creators", "exit"};

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            Choices browseChoices = new Choices();
            browseChoices.Add(browseCommands);

            Choices searchingChoices = new Choices();
            searchingChoices.Add(searchingCommands);

            Choices filtersChoices = new Choices();
            filtersChoices.Add(filterCommands);

            Choices filterValueChoices = new Choices();
            filterValueChoices.Add(filterValueCommands);

            Choices yesNoChoices = new Choices();
            yesNoChoices.Add(yesNoCommands);

            Choices saveChoices = new Choices();
            saveChoices.Add(saveCommands);

            Choices numberChoices = new Choices();
            numberChoices.Add(numberCommands);

            Choices infoChoices = new Choices();
            infoChoices.Add(infoCommands);

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            GrammarBuilder browseBuilder = new GrammarBuilder();
            browseBuilder.Append(browseChoices);

            GrammarBuilder searchingBuilder = new GrammarBuilder();
            searchingBuilder.Append(searchingChoices);

            GrammarBuilder filterBuilder = new GrammarBuilder();
            filterBuilder.Append(filtersChoices);

            GrammarBuilder filterValueBuilder = new GrammarBuilder();
            filterValueBuilder.Append(filterValueChoices);

            GrammarBuilder yesNoBuilder = new GrammarBuilder();
            yesNoBuilder.Append(yesNoChoices);

            GrammarBuilder saveBuilder = new GrammarBuilder();
            saveBuilder.Append(saveChoices);

            GrammarBuilder numberBuilder = new GrammarBuilder();
            numberBuilder.Append(numberChoices);

            GrammarBuilder infoBuilder = new GrammarBuilder();
            infoBuilder.Append(infoChoices);

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            browseGrammar = new Grammar(browseBuilder);
            searchingGrammar = new Grammar(searchingBuilder);
            filterGrammar = new Grammar(filterBuilder);
            filterValueGrammar = new Grammar(filterValueBuilder);
            yesNoGrammar = new Grammar(yesNoBuilder);
            saveGrammar = new Grammar(saveBuilder);
            numberGrammar = new Grammar(numberBuilder);
            infoGrammar = new Grammar(infoBuilder);
            dictationGrammar = new DictationGrammar();

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            browseGrammar.Name = "Browse Grammar";
            searchingGrammar.Name = "Searching Grammar";
            filterGrammar.Name = "Filter Grammar";
            filterValueGrammar.Name = "Filter Value Grammar";
            saveGrammar.Name = "Save Grammar";
            numberGrammar.Name = "Number Grammar";
            dictationGrammar.Name = "Dictation Grammar";

            //---------------------------------------------------------------------------------------------------------------------------------------------------
            
            startBrowse = new EventHandler<SpeechRecognizedEventArgs>(startBrowse_SpeechRecognised);
            dictSearch = new EventHandler<SpeechRecognizedEventArgs>(dictSearch_SpeechRecognised);
            dictFilter = new EventHandler<SpeechRecognizedEventArgs>(dictFilter_SpeechRecognised);
            filterCheck = new EventHandler<SpeechRecognizedEventArgs>(filterCheck_SpeechRecognised);
            filterValueCheck = new EventHandler<SpeechRecognizedEventArgs>(filterValueCheck_SpeechRecognised);
            yesNoCheck = new EventHandler<SpeechRecognizedEventArgs>(yesNoCheck_SpeechRecognised);
            numberCheck = new EventHandler<SpeechRecognizedEventArgs>(numberCheck_SpeechRecognised);
            infoCheck = new EventHandler<SpeechRecognizedEventArgs>(infoCheck_SpeechRecognised);
            
            events = new EventHandler<SpeechRecognizedEventArgs>[] { startBrowse, dictSearch, dictFilter, filterCheck, filterValueCheck, yesNoCheck, numberCheck, infoCheck };
            
            //---------------------------------------------------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            start.SetInputToDefaultAudioDevice();
            dict.SetInputToDefaultAudioDevice();
            filter.SetInputToDefaultAudioDevice();

            //---------------------------------------------------------------------------------------------------------------------------------------------------

            timer.Interval = 5000;
            timer.Tick += setAllNodesBackColour;


        }

        public IView CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                currentView.getSearchBox().BackColor = SystemColors.ControlLight;
                currentView.getTreeView().BackColor = SystemColors.ControlLight;
                currentView.getSaveLabel().Hide();
                CurrentView.getQuantityLabel().Hide();
                updateTree();
            }
        }

        void clearVoiceRecognitionEngine(SpeechRecognitionEngine sre)
        {
            sre.UnloadAllGrammars();
            
            foreach(EventHandler<SpeechRecognizedEventArgs> evh in events)
            {
                sre.SpeechRecognized -= evh;
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

        public void startKeyWordRecogniser()
        {
            try
            {
                start.LoadGrammar(browseGrammar);
                start.SpeechRecognized += startBrowse;
                Console.WriteLine("Starting key word recognition");
                start.RecognizeAsync(RecognizeMode.Multiple);

                foreach (Grammar g in start.Grammars)
                {
                    Console.WriteLine(g.Name);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        void infoCheck_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            //"more", "images", "more images", "reviews", "blurbers", "similar", "similar products", "creators", "exit"
            Console.WriteLine(e.Result.Text);
            switch (e.Result.Text)
            {
                case "more":
                case "images":
                case "more images":

                    return;
                case "reviews":

                    return;
                case "blurbers":

                    return;
                case "similar":
                case "similar products":

                    return;
                case "creators:":

                    return;
                case "exit":
                    CurrentView.getSaveLabel().Hide();

                    clearVoiceRecognitionEngine(start);

                    Query = new Query(getWords(), queryFilters);
                    Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.iv);
                    Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.pv);
                        return;
            }
        }

        void numberCheck_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            clearVoiceRecognitionEngine(start);

            foreach (Label l in ((ProductView)currentView).productLabels)
            {
                l.Hide();
            }

            if (e.Result.Text == "exit")
            {
                start.LoadGrammar(browseGrammar);
                start.SpeechRecognized += startBrowse;
            }else
            {
                if(currentView is ProductView)
                {
                    ProductView pv = ((ProductView)currentView);
                    Testing.Program.ms.iv.loadBook(pv.se.Pages[pv.currentPage][numberRepresentation[e.Result.Text]-1]);

                    Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.pv);
                    Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.iv);
                }
            }
        }

        void startBrowse_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "view":
                    if (currentView is ProductView)
                    {
                        Console.WriteLine("Entering view mode");
                        clearVoiceRecognitionEngine(start);

                        start.LoadGrammar(numberGrammar);
                        start.SpeechRecognized += numberCheck;

                        foreach (Label l in ((ProductView)currentView).productLabels)
                        {
                            l.Show();
                        }
                    }
                    return;
                case "exit":
                    choiceOption = YesNoOptions.EXIT;

                    start.RecognizeAsyncStop();

                    clearVoiceRecognitionEngine(start);
                    dict.SpeechRecognized += dictSearch;

                    filter.LoadGrammar(yesNoGrammar);
                    filter.SpeechRecognized += yesNoCheck;

                    currentView.getSaveLabel().Text = "Would you like to close this program?";
                    currentView.getSaveLabel().Show();

                    filter.RecognizeAsync(RecognizeMode.Multiple);
                    return;
                case "next":
                    if(currentView is ProductView)
                    {
                        ((ProductView)currentView).nextPage();
                    }
                    return;
                case "previous":
                    if (currentView is ProductView)
                    {
                        ((ProductView)currentView).previousPage();
                    }
                    return;
                case "search":
                    start.RecognizeAsyncStop();
                    Console.WriteLine("Starting search voice recognition systems");

                    clearVoiceRecognitionEngine(start);

                    dict.LoadGrammar(searchingGrammar);
                    dict.LoadGrammar(dictationGrammar);
                    dict.SpeechRecognized += dictSearch;

                    Console.WriteLine("Current View: " + currentView);
                    currentView.getTreeView().BackColor = SystemColors.ControlLight;
                    currentView.getSearchBox().BackColor = SystemColors.Window;
                    dict.RecognizeAsync(RecognizeMode.Multiple);
                    return;
                case "filter":
                    start.RecognizeAsyncStop();
                    Console.WriteLine("Loading filter voice recognition");

                    clearVoiceRecognitionEngine(start);

                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;

                    currentView.getSearchBox().BackColor = SystemColors.ControlLight;
                    currentView.getTreeView().BackColor = SystemColors.Window;
                    filter.RecognizeAsync(RecognizeMode.Multiple);
                    return;
            }


        }

        public void viewLoaded()
        {
            Console.WriteLine(currentView + " loaded");

            if(currentView is ProductView)
            {
                Console.WriteLine("vr query:" + Query);
                currentView.getItem()["query"] = Query;
            }else if(currentView is InformationView)
            {
                Console.WriteLine("Info view loaded");
                start.LoadGrammar(infoGrammar);
                start.SpeechRecognized += infoCheck;
            }

            if(Query != null)
                currentView.getSearchBox().Text += Query.query;

        }

        void addToSearchBar(String s)
        {
            Console.WriteLine("Adding \"" + s + "\" to the search bar" );

            if(currentView.getSearchBox().Text == "")
            {
                currentView.getSearchBox().Text += s;
            }else
            {
                currentView.getSearchBox().Text += " " + s;
            }
        }

        void dictSearch_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);

            if(e.Result.Text == "exit")
            {
                if (treatNextAsWord)
                {
                    addToSearchBar(e.Result.Text);
                    currentView.getSaveLabel().Hide();
                    treatNextAsWord = false;
                }
                else
                {
                    clearVoiceRecognitionEngine(dict);

                    dict.RecognizeAsyncStop();

                    currentView.getSearchBox().BackColor = SystemColors.ControlLight;

                    start.LoadGrammar(browseGrammar);
                    start.SpeechRecognized += startBrowse;
                    start.RecognizeAsync(RecognizeMode.Multiple);
                }
            }

            if (e.Result.Text == "filter" || e.Result.Text == "filters")
            {
                if (treatNextAsWord)
                {
                    addToSearchBar(e.Result.Text);
                    currentView.getSaveLabel().Hide();
                    treatNextAsWord = false;
                }
                else
                {
                    clearVoiceRecognitionEngine(dict);

                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;

                    currentView.getSearchBox().BackColor = SystemColors.ControlLight;

                    foreach (TreeNode lvl1Node in currentView.getTreeView().Nodes)
                    {
                        lvl1Node.BackColor = SystemColors.Window;
                        foreach (TreeNode lvl2Node in lvl1Node.Nodes)
                        {
                            lvl2Node.BackColor = SystemColors.Window;
                            foreach (TreeNode lvl3Node in lvl2Node.Nodes)
                            {
                                lvl3Node.BackColor = SystemColors.Window;

                            }
                        }
                    }

                    currentView.getTreeView().BackColor = SystemColors.Window;
                    dict.RecognizeAsyncStop();
                    filter.RecognizeAsync(RecognizeMode.Multiple);
                    return;
                }
            }

            if (e.Result.Text == "word")
            {
                if (treatNextAsWord)
                {

                    addToSearchBar(e.Result.Text);
                    currentView.getSaveLabel().Hide();
                    treatNextAsWord = false;
                }
                else
                {
                    currentView.getSaveLabel().Text = "Please speak your word.";
                    currentView.getSaveLabel().Show();
                    treatNextAsWord = true;
                }
            }

            if (e.Result.Text == "search")
            {
                if (treatNextAsWord)
                {

                    addToSearchBar(e.Result.Text);
                    currentView.getSaveLabel().Hide();
                    treatNextAsWord = false;
                }
                else
                {
                    //Console.WriteLine(getWords());
                    if (currentView.getSearchBox().Text == "")
                    {
                        CurrentView.getSaveLabel().Show();
                        CurrentView.getSaveLabel().Text = "Please enter a search criteria";
                    }
                    else
                    {
                        CurrentView.getSaveLabel().Show();
                        CurrentView.getSaveLabel().Text = "Would you like to search?";

                        clearVoiceRecognitionEngine(dict);
                        filter.LoadGrammar(yesNoGrammar);
                        filter.SpeechRecognized += yesNoCheck;

                        dict.RecognizeAsyncStop();
                        filter.RecognizeAsync(RecognizeMode.Multiple);
                        choiceOption = YesNoOptions.SEARCH;
                    }
                    return;
                }
            }

            if (e.Result.Text == "incorrect")
            {
                //asdasda
                if (treatNextAsWord)
                {

                    addToSearchBar(e.Result.Text);
                    currentView.getSaveLabel().Hide();
                    treatNextAsWord = false;
                }
                else
                {
                    string[] searchTerms = currentView.getSearchBox().Text.Split(new char[] { ' ' });
                    currentView.getSearchBox().Text = "";
                    
                    if (searchTerms.Length != 0)
                    {
                        Console.WriteLine("Removed \"" + searchTerms.Last() + "\"");
                        for(int i = 0; i < searchTerms.Length - 1; i++)
                        {
                            addToSearchBar(searchTerms[i]);
                        }
                    }
                }
            }

            if (!searchingCommands.Contains(e.Result.Text))
            {

                addToSearchBar(e.Result.Text);
                currentView.getSaveLabel().Hide();
                treatNextAsWord = false;
            }
        }

        private int convertText(string intput)
        {
            Console.WriteLine("In convert Text");
            try
            {
                if (numberRepresentation.Keys.Contains(intput))
                    intput = "" + numberRepresentation[intput];

                if (intput.Contains(","))
                {
                    string[] split = intput.Split(new char[] { ',' });
                    intput = "";
                    foreach (string s in split)
                    {
                        intput += s;
                    }
                }
                if (intput.Contains(' '))
                {
                    string[] split = intput.Split(new char[] { ' ' });
                    long i = 1;
                    foreach (string s in split)
                    {
                        if (numberRepresentation.Keys.Contains(s))
                        {
                            i *= numberRepresentation[s.ToLower()];
                        }
                        else
                        {
                            i *= long.Parse(s);
                        }
                    }
                    intput = "" + i;
                }

                Label quantityLabel = currentView.getQuantityLabel();
                quantityLabel.Text = "Recieved: " + intput;
                quantityLabel.Show();

                int returnValue = int.Parse(intput);

                if(returnValue < 0)
                {
                    throw new FormatException();
                }

                return returnValue;
            }
            catch (OverflowException)
            {
                currentView.getSaveLabel().Text = "Error number to large, please keep it below: " + Int32.MaxValue;
                Console.WriteLine("Error number to large, please keep it below: " + Int32.MaxValue);
                return -1;
            }catch(FormatException)
            {
                currentView.getSaveLabel().Text = "The input was not a valid number";
                return -1;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.WriteLine(err.Source);
                Console.WriteLine(err.StackTrace);
                Console.WriteLine("Something went wrong");
                return -1;
            }
        }

        void dictFilter_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            string intput = e.Result.Text.ToLower();
            Console.WriteLine("intput: " + intput);

            if (intput == "save")
            {
                currentView.getSaveLabel().Text = "Would you like to save the value?";
                Console.WriteLine(min + " : " + max);
                switch (changing)
                {
                    case Changes.MINIMUM:
                        if (min < 0)
                        {
                            currentView.getSaveLabel().Text = "No input was recieved, please try again";
                            return;
                        }
                        
                        break;

                    case Changes.MAXIMUM:
                        if (max < 0)
                        {
                            currentView.getSaveLabel().Text = "No input was recieved, please try again";
                            return;
                        }

                        break;

                }
                Console.WriteLine("Enter save mode");
                clearVoiceRecognitionEngine(dict);
                filter.LoadGrammar(yesNoGrammar);
                filter.SpeechRecognized += yesNoCheck;
                choiceOption = YesNoOptions.SAVE;
                dict.RecognizeAsyncStop();
                filter.RecognizeAsync(RecognizeMode.Multiple);

            }
            else if (intput == "exit")
            {
                filter.LoadGrammar(filterGrammar);
                filter.SpeechRecognized += filterCheck;
                clearVoiceRecognitionEngine(dict);

                dict.RecognizeAsyncStop();
                filter.RecognizeAsync();
            }
            else
            {
                switch (changing)
                {
                    case Changes.MINIMUM:

                        Console.Clear();
                        Console.WriteLine("Entering convert text()");
                        min = convertText(intput);

                        if (min != -1)
                        {
                            if (currFilter == AllFilters.PAGES)
                            {
                                workingNumberOfPages = new NumberOfPages(numberOfPages.max, min);
                            }
                            else
                            {
                                workingListPrice = new ListPrice(listPrice.max, min);
                            }
                        }
                        else
                        {
                            //ERROR
                        }

                        Console.WriteLine("Min: " + min);

                        return;

                    case Changes.MAXIMUM:


                        Console.Clear();
                        Console.WriteLine("Entering convert text()");

                        max = convertText(intput);

                        if (max != -1)
                        {
                            if (currFilter == AllFilters.PAGES)
                            {
                                workingNumberOfPages = new NumberOfPages(max, numberOfPages.min);
                                Console.WriteLine(workingNumberOfPages);
                            }
                            else
                            {
                                workingListPrice = new ListPrice(max, listPrice.min);
                            }
                        }
                        else
                        {
                            //ERROR
                        }

                        Console.WriteLine("Max: " + max);

                        return;
                }
            }
        }

        void nodePrinting(TreeNode node)
        {
            Console.WriteLine(node.Nodes.Count);
        }

        void filterCheck_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);

            switch (e.Result.Text)
            {
                case "exit":

                    clearVoiceRecognitionEngine(filter);

                    currentView.getTreeView().BackColor = SystemColors.ControlLight;

                    start.LoadGrammar(browseGrammar);
                    start.SpeechRecognized += startBrowse;
                    start.RecognizeAsync(RecognizeMode.Multiple);

                    return;
                case "prices":
                case "price":
                case "list price":
                    Console.WriteLine("Switching to filterValue mode");

                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterValueGrammar);
                    filter.SpeechRecognized += filterValueCheck;

                    currentView.getTreeView().Nodes["PriceNode"].BackColor = SystemColors.ActiveCaption;

                    currFilter = AllFilters.PRICE;
                    changing = Changes.NONE;
                    return;
                case "pages":
                case "number of pages":
                    Console.WriteLine("Switching to filterValue mode");

                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterValueGrammar);
                    filter.SpeechRecognized += filterValueCheck;

                    currentView.getTreeView().Nodes["PagesNode"].BackColor = SystemColors.ActiveCaption;

                    currFilter = AllFilters.PAGES;
                    changing = Changes.NONE;
                    return;
                case "search":

                    dict.LoadGrammar(searchingGrammar);
                    dict.LoadGrammar(dictationGrammar);
                    dict.SpeechRecognized += dictSearch;

                    clearVoiceRecognitionEngine(filter);

                    currentView.getTreeView().BackColor = SystemColors.ControlLight;

                    foreach(TreeNode lvl1Node in currentView.getTreeView().Nodes)
                    {
                        lvl1Node.BackColor = SystemColors.ControlLight;
                        foreach(TreeNode lvl2Node in lvl1Node.Nodes)
                        {
                            lvl2Node.BackColor = SystemColors.ControlLight;
                            foreach (TreeNode lvl3Node in lvl2Node.Nodes)
                            {
                                lvl3Node.BackColor = SystemColors.ControlLight;

                            }
                        }
                    }

                    currentView.getSearchBox().BackColor = SystemColors.Window;

                    filter.RecognizeAsyncStop();
                    dict.RecognizeAsync(RecognizeMode.Multiple);
                    return;
            }
        }

        void setAllNodesBackColour(Object sender, EventArgs e)
        {
            clearAllBackColours();
        }

        void clearAllBackColours()
        {
            TreeNodeCollection pageAndPrices = currentView.getTreeView().Nodes;

            TreeNodeCollection prices = pageAndPrices["PriceNode"].Nodes;
            TreeNodeCollection pages = pageAndPrices["PagesNode"].Nodes;

            pageAndPrices["PriceNode"].BackColor = SystemColors.Window;
            foreach (TreeNode node in prices)
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    subNode.BackColor = SystemColors.Window;
                }
                node.BackColor = SystemColors.Window;
            }

            pageAndPrices["PagesNode"].BackColor = SystemColors.Window;
            foreach (TreeNode node in pages)
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    subNode.BackColor = SystemColors.Window;
                }
                node.BackColor = SystemColors.Window;
            }

            timer.Stop();
        }

        void updateTree()
        {
            TreeView tree = currentView.getTreeView();
            TreeNodeCollection prices = tree.Nodes["PriceNode"].Nodes;
            TreeNodeCollection pages = tree.Nodes["PagesNode"].Nodes;

            Console.WriteLine(queryFilters);

            pages["PagesMinimumNode"].Nodes["PagesMinimumValueNode"].Text = "" + queryFilters.numberofpages.min;
            pages["PagesMaximumNode"].Nodes["PagesMaximumValueNode"].Text = "" + queryFilters.numberofpages.max;
            pages["PagesEnabledNode"].Nodes["PagesEnabledValueNode"].Text = "" + queryFilters.numberofpages.enabled;

            prices["PricesMinimumNode"].Nodes["PricesMinimumValueNode"].Text = "$" + queryFilters.listprice.min;
            prices["PricesMaximumNode"].Nodes["PricesMaximumValueNode"].Text = "$" + queryFilters.listprice.max;
            prices["PricesEnabledNode"].Nodes["PricesEnabledValueNode"].Text = "" + queryFilters.listprice.enabled;
        }

        void filterValueCheck_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(choiceOption);
            switch (e.Result.Text)
            {
                case "enable":
                    switch (currFilter)
                    {
                        case AllFilters.PAGES:
                            numberOfPages.enabled = true;
                            Console.WriteLine("enabled " + currFilter);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].Nodes["PagesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;

                            break;
                        case AllFilters.PRICE:
                            listPrice.enabled = true;
                            Console.WriteLine("enabled " + currFilter);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].Nodes["PricesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;

                            break;
                    }
                    timer.Start();
                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;
                    break;
                case "disable":
                    switch (currFilter)
                    {
                        case AllFilters.PAGES:
                            numberOfPages.enabled = false;
                            Console.WriteLine("disabled " + currFilter);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].Nodes["PagesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;
                            timer.Start();

                            break;
                        case AllFilters.PRICE:
                            listPrice.enabled = false;
                            Console.WriteLine("disabled " + currFilter);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].Nodes["PricesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;
                            timer.Start();

                            break;
                    }
                    timer.Start();
                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;
                    break;
                case "enabled":
                    switch (currFilter)
                    {
                        case AllFilters.PAGES:
                            Console.WriteLine(currFilter + ": " + numberOfPages.enabled);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesEnabledNode"].Nodes["PagesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;
                            break;
                        case AllFilters.PRICE:
                            Console.WriteLine(currFilter + ": " + listPrice.enabled);
                            changing = Changes.NONE;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].BackColor = SystemColors.ActiveCaption;
                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesEnabledNode"].Nodes["PricesEnabledValueNode"].BackColor = SystemColors.ActiveCaption;
                            break;
                    }
                    timer.Start();
                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;
                    break;
                case "minimum":
                case "min":
                    currentView.getSaveLabel().Show();
                    currentView.getSaveLabel().Text = "Would you like to change the value?";
                    Console.Write("Current minimum is: ");
                    switch (currFilter)
                    {
                        case AllFilters.PAGES:
                            Console.WriteLine(currFilter + ": " + numberOfPages.min + ". Would you like to change this?");
                            changing = Changes.MINIMUM;

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(yesNoGrammar);
                            filter.SpeechRecognized += yesNoCheck;

                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesMinimumNode"].BackColor = SystemColors.ActiveCaption;

                            choiceOption = YesNoOptions.CHANGE;

                            return;
                        case AllFilters.PRICE:
                            Console.WriteLine(currFilter + ": " + listPrice.min + ". Would you like to change this?");
                            changing = Changes.MINIMUM;

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(yesNoGrammar);
                            filter.SpeechRecognized += yesNoCheck;

                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesMinimumNode"].BackColor = SystemColors.ActiveCaption;

                            choiceOption = YesNoOptions.CHANGE;

                            return;
                    }
                    return;
                case "maximum":
                case "max":
                    currentView.getSaveLabel().Show();
                    currentView.getSaveLabel().Text = "Would you like to change the value?";
                    Console.Write("Current maximum is: ");
                    switch (currFilter)
                    {
                        case AllFilters.PAGES:
                            Console.WriteLine(currFilter + ": " + numberOfPages.max + ". Would you like to change this?");
                            changing = Changes.MAXIMUM;

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(yesNoGrammar);
                            filter.SpeechRecognized += yesNoCheck;

                            currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesMaximumNode"].BackColor = SystemColors.ActiveCaption;

                            choiceOption = YesNoOptions.CHANGE;

                            return;
                        case AllFilters.PRICE:
                            Console.WriteLine(currFilter + ": " + listPrice.max + ". Would you like to change this?");
                            changing = Changes.MAXIMUM;

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(yesNoGrammar);
                            filter.SpeechRecognized += yesNoCheck;

                            currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesMaximumNode"].BackColor = SystemColors.ActiveCaption;

                            choiceOption = YesNoOptions.CHANGE;

                            return;
                    }
                    return;
                case "exit":
                    currFilter = AllFilters.NONE;

                    CurrentView.getSaveLabel().Hide();
                    CurrentView.getQuantityLabel().Hide();
                    clearAllBackColours();

                    clearVoiceRecognitionEngine(filter);
                    filter.LoadGrammar(filterGrammar);
                    filter.SpeechRecognized += filterCheck;

                    changing = Changes.NONE;
                    return;
            }

            queryFilters.listprice = listPrice;
            queryFilters.numberofpages = numberOfPages;

            updateTree();
        }

        void yesNoCheck_SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            switch (choiceOption)
            {
                case YesNoOptions.CHANGE:
                    switch (e.Result.Text)
                    {
                        case "yes":
                            Console.WriteLine("Yes recieved");

                            min = -1;
                            max = -1;

                            currentView.getSaveLabel().Text = "Say save to save changes.";
                            currentView.getSaveLabel().Show();

                            clearVoiceRecognitionEngine(filter);

                            dict.LoadGrammar(saveGrammar);
                            dict.LoadGrammar(dictationGrammar);

                            dict.SpeechRecognized += dictFilter;

                            filter.RecognizeAsyncStop();
                            dict.RecognizeAsync(RecognizeMode.Multiple);

                            if (changing == Changes.MINIMUM)
                            {
                                if (currFilter == AllFilters.PAGES)
                                    currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesMinimumNode"].Nodes["PagesMinimumValueNode"].BackColor = SystemColors.ActiveCaption;
                                else
                                    currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesMinimumNode"].Nodes["PricesMinimumValueNode"].BackColor = SystemColors.ActiveCaption;

                            }
                            else
                            {
                                if (currFilter == AllFilters.PAGES)
                                    currentView.getTreeView().Nodes["PagesNode"].Nodes["PagesMaximumNode"].Nodes["PagesMaximumValueNode"].BackColor = SystemColors.ActiveCaption;
                                else
                                    currentView.getTreeView().Nodes["PriceNode"].Nodes["PricesMaximumNode"].Nodes["PricesMaximumValueNode"].BackColor = SystemColors.ActiveCaption;
                            }
                            break;
                        case "no":
                            Console.WriteLine("No recieved");
                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(filterGrammar);
                            filter.SpeechRecognized += filterCheck;
                            clearAllBackColours();


                            foreach(Grammar grammar in filter.Grammars)
                            {
                                Console.WriteLine(grammar.Name + ": " + grammar.Loaded);
                            }

                            CurrentView.getSaveLabel().Hide();
                            CurrentView.getQuantityLabel().Hide();
                            break;
                    }
                    return;
                case YesNoOptions.SAVE:
                    switch (e.Result.Text)
                    {
                        case "yes":
                            if (currFilter == AllFilters.PAGES)
                            {
                                numberOfPages = workingNumberOfPages;
                            }
                            else
                            {
                                listPrice = workingListPrice;
                            }

                            queryFilters.numberofpages = numberOfPages;
                            queryFilters.listprice = listPrice;

                            Console.WriteLine(queryFilters);

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(filterGrammar);
                            filter.SpeechRecognized += filterCheck;

                            currentView.getSaveLabel().Text = "Filters saved";
                            currentView.getQuantityLabel().Hide();
                            updateTree();

                            timer.Start();
                            return;
                        case "no":
                            Console.WriteLine("No recieved");

                            clearVoiceRecognitionEngine(filter);
                            filter.LoadGrammar(filterGrammar);
                            filter.SpeechRecognized += filterCheck;
                            clearAllBackColours();

                            CurrentView.getSaveLabel().Hide();
                            CurrentView.getQuantityLabel().Hide();
                            return;
                    }
                    return;

                case YesNoOptions.SEARCH:
                    switch (e.Result.Text)
                    {
                        case "yes":
                            search();
                            return;
                        case "no":
                            CurrentView.getSaveLabel().Hide();

                            clearVoiceRecognitionEngine(filter);
                            filter.RecognizeAsyncStop();

                            dict.LoadGrammar(searchingGrammar);
                            dict.LoadGrammar(dictationGrammar);
                            dict.SpeechRecognized += dictSearch;
                            
                            dict.RecognizeAsync(RecognizeMode.Multiple);
                            return;
                    }
                    return;
                case YesNoOptions.EXIT:
                    switch (e.Result.Text)
                    {
                        case "yes":
                            Application.Exit();
                            return;
                        case "no":

                            start.LoadGrammar(browseGrammar);
                            start.SpeechRecognized += startBrowse;
                            start.RecognizeAsync(RecognizeMode.Multiple);

                            clearVoiceRecognitionEngine(filter);

                            currentView.getSaveLabel().Hide();

                            return;
                    }
                    return;
            }
        }

        public string getWords()
        {       
            return currentView.getSearchBox().Text;
        }

        public void search()
        {
            if (currentView.getSearchBox().Text == "")
            {
                CurrentView.getSaveLabel().Show();
                CurrentView.getSaveLabel().Text = "Please enter a search criteria";
            }
            else
            {
                Console.WriteLine("YesNoOptions.SEARCH start: " + getWords());
                CurrentView.getSaveLabel().Hide();

                clearVoiceRecognitionEngine(start);
                clearVoiceRecognitionEngine(dict);
                clearVoiceRecognitionEngine(filter);
                filter.RecognizeAsyncStop();

                Query = new Query(getWords(), queryFilters);

                if (currentView is Search_View)
                {
                    Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.sv);
                    Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.pv);
                }
                else
                {
                    ProductView sv = (ProductView)currentView;
                    sv.querySearch();
                }
            }

        }
    }
}