using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Synthesis;

namespace Anonymous_Chat
{
    class Program
    {
        static void Usage()
        {
            string filename = System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string Greeting =
            @"
    _                       ____ _           _
   / \   _ __   ___  _ __  / ___| |__   __ _| |_
  / _ \ | '_ \ / _ \| '_ \| |   | '_ \ / _` | __|
 / ___ \| | | | (_) | | | | |___| | | | (_| | |_
/_/   \_\_| |_|\___/|_| |_|\____|_| |_|\__,_|\__|
 ____            ____  _            _   __     ___ _    _             ____
| __ ) _   _ _  | __ )| | __ _  ___| | _\ \   / (_) | _(_)_ __   __ _|  _ \ _ __ ___
|  _ \| | | (_) |  _ \| |/ _` |/ __| |/ /\ \ / /| | |/ / | '_ \ / _` | |_) | '__/ _ \
| |_) | |_| |_  | |_) | | (_| | (__|   <  \ V / | |   <| | | | | (_| |  __/| | | (_) |
|____/ \__, (_) |____/|_|\__,_|\___|_|\_\  \_/  |_|_|\_\_|_| |_|\__, |_|   |_|  \___/
       |___/                                                    |___/
";
            string Help =
            @"
 _   _
| | | |___  __ _  __ _  ___ _
| | | / __|/ _` |/ _` |/ _ (_)
| |_| \__ \ (_| | (_| |  __/_
 \___/|___/\__,_|\__, |\___(_)
                 |___/
";
            Console.WriteLine(Greeting);
            Console.WriteLine(Help);
            Console.WriteLine("It Talks!\nSyntax: {0} [message]", filename);
        }

        static void Main(string[] args)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string synchronously.
                // synth.Speak("What is your favorite color?");
                try
                {
                    switch (args[0])
                    {
                        case "/?":
                            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                            string name = System.IO.Path.GetFileName(location);
                            Usage();
                            // Console.WriteLine("It Talks!\nSyntax: {0} [message]", name);
                            Environment.Exit(0);
                            break;
                    }
                    if (args.Length >= 0)
                    {
                        string x = "";
                        foreach (var item in args)
                        {
                            x += item.ToString() + " ";
                        }
                        synth.Speak(x);
                        Console.WriteLine(Convert.ToString(x));
                    }
                }
                catch
                {
                    string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string name = System.IO.Path.GetFileName(location);
                    Usage();
                    // Console.WriteLine("It Talks!\nSyntax: {0} [message]", name);
                }
            }
        }
    }
}
