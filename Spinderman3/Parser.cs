using System;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace Spinderman3
{
    static class Parser
    {
        internal static StringCollection GetWords(string content)
        {
            StringCollection collection = new StringCollection();
            
            foreach (var word in content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    collection.Add(word);

            return collection;
        }

        static int Random()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                return BitConverter.ToInt32(rno, 0) / 10000;
            }
        }

        internal static void Run(StringCollection collection)
        {
            

            for (int line = 0; line < collection.Count; line++)
            {
                string sline = "";
                uint wordIndex = 0;
                foreach (var item in GetWords(collection[line])) // get the words from the sentence
                {
                    var word = item;

                    if (word.Length == 2)
                        word = $"{word[1]}{word[0]}";
                    else
                    {
                        if (word.Length <= 5 && word.Length >= 3)
                            if (Random() < 5)
                                word = $"{word[1]}{word[0]}" + word.Substring(1, word.Length- 1);
                    }
                    
                    if (wordIndex == GetWords(collection[line]).Count) //end of sentence
                    {
                        sline += $"{word}";
                        break;
                    }
                    wordIndex++;
                    sline += $"{word} ";
                }
                Console.WriteLine(sline); // print the modified line
            }
        }

    }
}
