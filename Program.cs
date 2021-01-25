using System;
using System.Linq;

namespace PigLatinTranslator
{
    class Program
    {
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        private static char[] punctuation = new char[] { '!', ',', '.', '?', ':', ';' };

        static void Main(string[] args)
        {
            string userInput = null;
            bool askAgain = true;

            Console.WriteLine("Welcome to the Pig Latin Translator.");

            while (askAgain)
            {
                userInput = null;
                //Above line resets user input for each run

                Console.WriteLine("Please enter the word or sentence you want to translate");
                userInput = ValidateInput(Console.ReadLine());

                if (userInput != null)
                {
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, cannot be blank");
                }


            }
            Console.WriteLine(Translate(userInput));

        }

        //Validates input and trims excess whitespace
        public static string ValidateInput(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            else
            {
                return null;
            }
        }

        //Note: not used in main, used in the Translate method
        //Checks a variety of punctuation an capitalization cases and outputs a word in the desired format
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
                    if(input.Any(char.IsLower) == false)
                    {
                        remaining = input.Substring(input.Length - 1);
                        return $"{input}WAY{punct}";
                    }
                    else
                    {
                        remaining = input.Substring(input.Length - 1);
                        return $"{input}way{punct}";
                    }
                }
                else if(input.IndexOfAny(vowels) != -1 && input.Any(char.IsLower))
                {
                    consonants = input.Substring(0, input.IndexOfAny(vowels));
                    remaining = input.Substring(input.IndexOfAny(vowels), noPunct.Length - consonants.Length);
                    return  $"{remaining}{consonants}ay{punct}";
                }
                else if(input.IndexOfAny(vowels) != -1 && input.Any(char.IsLower) == false)
                {
                    consonants = input.Substring(0, input.IndexOfAny(vowels));
                    remaining = input.Substring(input.IndexOfAny(vowels), noPunct.Length - consonants.Length);
                    return $"{remaining}{consonants}AY{punct}";
                }
                else
                {
                    return input;
                }
            }

        }

        //Main translation method, implements other methods created in program
        public static string Translate(string input)
        {
            string output;
            string[] untranslated = input.Split();
            string[] translated = new string[untranslated.Length];
            int i = 0;

            foreach (string word in untranslated)
            {
                string caseInsensitive = Translator(untranslated[i]);
                translated[i] = SaveUpper(untranslated[i], caseInsensitive);
                i++;
            }
            output = String.Join(" ", translated);
            return output;
        }

        //Checks each character in a translated string for capitalization vs the base input string
        //Implemented in Translate()
        public static string SaveUpper(string input, string translatedInput)
        {
            char[] translatedString = translatedInput.ToCharArray();

            for(int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                   translatedString[i] = char.ToUpper(translatedString[i]);
                }
                else if (char.IsLower(input[i]))
                {
                    translatedString[i] = char.ToLower(translatedString[i]);
                }
            }


            return string.Join("", translatedString);
        }

        //Checks the IsPunctuation method against my array of allowed punctuation, and if there is NO valid punctuation at the end of the string
        //Implemented in Translate()
        public static string CheckPunctuation(string input, out bool translate)
        {
            translate = true;
            int i = 0;
            char[] letters = input.ToCharArray();

            foreach(char letter in input)
            {
                if (char.IsSymbol(letter) || char.IsDigit(letter) || (char.IsPunctuation(letter) && letter != '\'' && punctuation.Contains(letter) == false))
                {
                    translate = false;
                } 
                else if (input.IndexOfAny(punctuation) != -1 && input.IndexOfAny(punctuation) != input.Length -1)
                {
                    translate = false;
                }
                i++;
            }

            if (punctuation.Contains(input[input.Length - 1]) && translate)
            {
                return input[input.Length - 1].ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
