using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace Dissertation
{
    class VoiceRecognition
    {

        SpeechRecognitionEngine dict, start;
        Timer timer = new Timer();
        HashSet<string> dictWords = new HashSet<string>();
        bool ignoreNext = false;
        //SpeechRecognizer recog;

        public VoiceRecognition()
        {
            dict = new SpeechRecognitionEngine();
            start = new SpeechRecognitionEngine();

            Choices commands = new Choices();
            commands.Add(new string[] { "search", "filter" });;
            Choices keyWords = new Choices();
            keyWords.Add(new string[] { "search", "word" });

            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(commands);
            GrammarBuilder stopBuilder = new GrammarBuilder();
            stopBuilder.Append(keyWords);

            Grammar cmdGrammar = new Grammar(builder);
            Grammar stopGrammar = new Grammar(keyWords);

            start.RequestRecognizerUpdate();

            dict.LoadGrammar(new DictationGrammar());
            dict.LoadGrammar(stopGrammar);
            start.LoadGrammar(cmdGrammar);
            //stop.LoadGrammar(stopGrammar);

            start.SetInputToDefaultAudioDevice();
            dict.SetInputToDefaultAudioDevice();

            start.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(start_SpeechRecognised);
            dict.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(dict_SpeechRecognised);
        }

        public void startKeyWordRecogniser()
        {
            try
            {
                dictWords.Clear();
                Console.Clear();
                Console.WriteLine("Starting key word recognition");
                start.RecognizeAsync(RecognizeMode.Multiple);
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        
        void start_SpeechRecognised(object sender,SpeechRecognizedEventArgs e)
        {
            start.RecognizeAsyncStop();

            switch (e.Result.Text)
            {
                case "next":

                    return;
                case "previous":

                    return;
                case "search":
                    Console.WriteLine("Starting multiple voice recognition systems");
                    dict.RecognizeAsync(RecognizeMode.Multiple);
                    return;
            }
            

        }

        void dict_SpeechRecognised(object sender,SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "word")
            {
                if (ignoreNext)
                {
                    dictWords.Add(e.Result.Text);
                    ignoreNext = false;
                }
                else
                {
                    ignoreNext = true;
                    return;
                }
            }

            Console.WriteLine(e.Result.Text);

            if (e.Result.Text == "search")
            {
                if (ignoreNext)
                {
                    dictWords.Add(e.Result.Text);
                    ignoreNext = false;
                }
                else
                {
                    dict.RecognizeAsyncStop();
                    Console.WriteLine("Stopping all recognition systems");
                    Console.WriteLine(getWords());
                    return;
                }
            }
            
            dictWords.Add(e.Result.Text);
        }

        void printDictWords()
        {
            foreach(string s in dictWords)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("getWords():" + getWords());
        }
        public string getWords()
        {
            String returnValue = "";
            for(int i = 0; i < dictWords.Count; i++)
            {
                if (i == dictWords.Count-1)
                {
                    returnValue += dictWords.ElementAt(i);
                }
                else
                {
                    returnValue += dictWords.ElementAt(i) + " ";
                }
            }
            return returnValue;
        }
    }
}
