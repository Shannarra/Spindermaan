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
            
            foreach (var word in content.Split(new char[] { ' ', '.', ',', '!' }, StringSplitOptions.RemoveEmptyEntries))
                    collection.Add(word);

            return collection;
        }

        static int Random()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                string s = BitConverter.ToInt32(rno, 0).ToString();
                if (s[0] != '-')
                    return int.Parse(s[0].ToString());
                return int.Parse(s[1].ToString());
            }
        }

        internal static void Run(StringCollection collection, string nameToSave)
        {
            string content = "";
            System.Text.StringBuilder builder = new System.Text.StringBuilder(content);

            for (int line = 0; line < collection.Count; line++)
            {
                string sline = "";
                uint wordIndex = 0;
                foreach (var item in GetWords(collection[line])) // get the words from the sentence
                {
                    var word = item;

                    Spindo(ref word);

                    if (word.Length == 2 && Random() > 5)
                        word = $"{word[1]}{word[0]}";
                    else
                    {
                        int chance = Random();

                        if (word.Length <= 5 && word.Length >= 3)
                        {
                            if (chance > 5)
                                word = $"{word[1]}{word[0]}" + word.Substring(1, word.Length - 1);
                        }
                        else
                        {
                            if ((word.Length - 1) - chance > 1)
                                word = $"{word.Substring(0, (word.Length - 1) - chance)}" +
                                   $"{word[word.Length - chance]}{word[(word.Length - 1) - chance]}{word.Substring((word.Length - chance) + 1)}";
                        }
                    }
                    
                    if (wordIndex == GetWords(collection[line]).Count) //end of sentence
                    {
                        sline += $"{word}";
                        break;
                    }
                    wordIndex++;
                    sline += $"{word} ";
                }
                builder.Append(sline + "\n"); // add the modified line
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(nameToSave))
                writer.WriteLine(builder.ToString());
        }

        static void Spindo(ref string word)
        {
            string newWord = "";

            foreach (char ch in word)
            {
                if (ch == 'в' && Random() < 4)
                    newWord += 'ж';
                else if (ch == 'м' && Random() > 4)
                    newWord += 'н';
                else if (ch == 'к' && Random() > 7)
                    newWord += 'г';
                else if (ch == 'е' && Random() > 6)
                    newWord += 'и';
                else if (ch == 'б' && Random() > 6)
                    newWord += 'п';
                else 
                    newWord += ch;
            }

            word = newWord;
        }
    }
}
