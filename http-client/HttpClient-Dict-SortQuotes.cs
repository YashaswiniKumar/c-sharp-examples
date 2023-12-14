using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO; //to write and read from a file
namespace http-client-example
{
    class Program
    {
        //write file method
        private static void WritetoFile(string path, Dictionary<string, string> Quotes)
        {         
            //Write the quotes to a file in the format. Include the file with your submission. “<quote>” -- <author>
            File.WriteAllLines(path, Quotes.Select(quote => string.Format("\"<{0}>\"--<{1}>", quote.Value, quote.Key)));
        }

        private static void Print(Dictionary<string, string> Quotes)
        {
            foreach (var quote in Quotes)
            {
                Console.WriteLine(quote.Key + "-" + quote.Value);
            }
        }
  
        public static async Task<Dictionary<string,string>> GetQuotes()
        {
            //Hits the API and the response contains the JSON data
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://type.fit/api/quotes");

            JArray jobject = new JArray(); //To extract the JSON data
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                jobject = JArray.Parse(responseString);

            }
            else
            {
                Console.WriteLine("Error occured, the status code is: {0}", response.StatusCode);
            }

            //Create a dictionary to store the value
            Dictionary<string, string> Quotes = new Dictionary<string, string>();

            //get the first 10 quotes
            for (int i = 0; i < 10; i++)
            {
                string author = jobject[i]["author"].ToString();
                string text = jobject[i]["text"].ToString();

                //skip if the author name/key is same
                if (Quotes.ContainsKey(author))
                {
                    continue;
                }
                else
                {
                    Quotes.Add(author, text);
                }
            }

            return Quotes;
        }
        static async Task Main(string[] args)
        {

            Dictionary<string, string> Quotes = await GetQuotes();
            //print the contents in the Quotes
            Console.WriteLine("The list of quotes before sorting");
            Print(Quotes);

            //sort them to shortest to longest string based on the Length of the value
            //Sort the Value of dictionary and it gets converted to IOrderedEnumerable
            //so again converting to dictionary
            var SortedQuotes = Quotes.OrderBy(x => x.Value.Length).ToDictionary(i => i.Key, i => i.Value); ;
            Console.WriteLine("The sorted list of quotes associated information from quote shortest to longest");
            Print(SortedQuotes);

            //write the sorted quotes to a file of format .txt
            WritetoFile("F:\\SortedQuotes.txt", SortedQuotes);

        }

    }
}
