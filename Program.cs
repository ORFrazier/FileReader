using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
class WordCounter
{
    static void Main()
    {
        string inFileName = @"C:\TestPage\TestPage.txt";
        StreamReader sr = new(inFileName);
        string text = System.IO.File.ReadAllText(inFileName);
        Regex reg_exp = new Regex("[^a-zA-Z0-9]"); //this converts letters to numbers so the program can properly read them
        text = reg_exp.Replace(text, " ");
        string[] words = text.Split(new char[] {
            ' '
        }, StringSplitOptions.RemoveEmptyEntries);
        var word_query = (from string word in words orderby word select word).Distinct();
        string[] result = word_query.ToArray();
        int counter = 0;
        string delim = " ,."; //delimiters to seperate the words
        string[] fields = null;
        string line = null;
        while (!sr.EndOfStream)
        {
            //this part reads the line and splits the words!
            line = sr.ReadLine();
            line.Trim();
            fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            counter += fields.Length; //this adds the words  
            foreach (string word in result)
            {
                CountStringOccurrences(text, word);
            }
        }
        sr.Close();
        Console.WriteLine("The total word count is {0}", counter);
        Console.ReadLine();
    }
    //Counting the usage of each seperate word.  
    public static void CountStringOccurrences(string text, string word)
    {
        int count = 0;
        int i = 0;
        while ((i = text.IndexOf(word, i)) != -1)
        {
            i += word.Length;
            count++;
        }
        Console.WriteLine("{0} {1}", count, word);

    }




}