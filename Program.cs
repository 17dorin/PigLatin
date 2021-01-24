using System;
using System.Linq;

namespace PigLatinTranslator
{
    class Program
    {
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        private static char[] punctuation = new char[] { '!', ',', '.', '?', ':', ';' };

        static void Main(string[] args)
        {
            string userInput = null;
            bool askAgain = true;

            Console.WriteLine("Welcome to the Pig Latin Translator.");

            while (askAgain)
            {
                //TODO add logic to clear userInput string on every fresh run when program is finished

                Console.WriteLine("Please enter the word or phrase you want to translate");
                userInput = ValidateInput(Console.ReadLine());

                if (userInput != null)
                {
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, cannot be blank");
                }
                Console.WriteLine(Translator(userInput));
            }

        }

        public static string ValidateInput(string input)
        {
            if (input.Trim() != null && input.Trim() != "")
            {
                return input.Trim();
            }
            else
            {
                return null;
            }
        }

        //Note: not used in main, used in the Translate method
        //Also need to add logic to check if word starts with a vowel or not
        public static string Translator(string input)
        {
            string consonants;
            string remaining;
            string punct;
            string noPunct;
            bool doTranslation;

            punct = CheckPunctuation(input, out doTranslation);
            noPunct = input.Trim(punctuation);
            if(doTranslation == false)
            {
                return input;
            }
            else
            {
                if(input.IndexOfAny(vowels) == 0)
                {
                    remaining = input.Substring(0, input.Length - 1);
                    return $"{remaining}way{punct}";
                }
                else if(input.IndexOfAny(vowels) != -1)
                {
                    consonants = input.Substring(0, input.IndexOfAny(vowels));
                    remaining = input.Substring(input.IndexOfAny(vowels), noPunct.Length - consonants.Length);
                    return  $"{remaining}{consonants}ay{punct}";
                }
                else
                {
                    return input;
                }
            }

        }

        public static string[] Translate(string input)
        {
            string[] untranslated = input.Split();
            string[] translated = new string[input.Length];
            return null;
        }

        public static string SaveUpper(string input, string translatedInput)
        {
            char[] inputString = input.ToCharArray();
            char[] translatedString = translatedInput.ToCharArray();

            return "";
        }

        //Checks the IsPunctuation method agains my array of allowed punctuation, and if there is NO valid punctuation at the end of the string
        //TODO add logic to allow apostrophes and ignore other symbols in the middle of strings
        public static string CheckPunctuation(string input, out bool translate)
        {
            translate = true;
            int i = 0;
            char[] letters = input.ToCharArray();

            if()
            foreach(char letter in letters)
            {

            }

            //Checks for any punctuation, symbols, or digits

            /*if(input.Any(char.IsPunctuation))
            {
                //If there's punctuation, checks for allowed punctuation at end of sentence.
                //If true, parses punctuation. If false, returns empty string and halts translation
                if (input.IndexOfAny(punctuation) == input.Length - 1)
                {
                    return input.Substring(input.IndexOfAny(punctuation));
                }
                else if (input.)
                {
                    translate = false;
                    return "";
                }
            }
            else if (input.Any())
            {
                return "";
            }*/
        }

    }
}
