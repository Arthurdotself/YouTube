using System;
using HtmlAgilityPack;
using System.Linq;
using System.Net;
using Flurl.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace proj1
{
    class Hmm
    {
        

        private double POAds = 100/40;
        public void Money(int x)
        {
            double z = 1000000 / (x * POAds);
            double Max = z * 2500;
            double Min = z * 800;
            Console.WriteLine("the Miximam is :$" + Max);
            Console.WriteLine("the Minimam is :$" + Min);
        }


    }


  
    class Program
    {

        public static string GetBetween(string strSource, string strStart, string strEnd)
        {

            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "204";
        }



        


        static async Task Main(string[] args)
        {
            
            string[] url = { "https://www.youtube.com/watch?v=vBGForNZKeM", "https://www.youtube.com/watch?v=JXtuAgD_quY","https://www.youtube.com/watch?v=H66VbvQf5PU","https://www.youtube.com/watch?v=M42iN5BMVsY", "https://www.youtube.com/watch?v=VHrMlzTcAjs", "https://www.youtube.com/watch?v=9g9j2s13I2s", "https://www.youtube.com/watch?v=CeZzoc-hs-g", "https://www.youtube.com/watch?v=m-QxD0vuABM", "https://www.youtube.com/watch?v=vtbP13dFqAo", "https://www.youtube.com/watch?v=MInhL5upw9c" };
            int[] Views = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int[] newViews = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int total =0;
            int totalPlus = 0;
            TimeSpan past = DateTime.Now.TimeOfDay;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < url.Length; i++)
                {
                    string strSource = await url[i].GetStringAsync();
                    System.Threading.Thread.Sleep(1000);
                    //get how many views
                    string strStart = "\"},{\"text\":\" • \"},{\"text\":\"";
                    string strEnd = " مشاهدة\"}]}}}}},\"overlay\":{\"tooltipRenderer";
                    string viewsText = GetBetween(strSource, strStart, strEnd);
                    Console.WriteLine("|               " + viewsText + " : views"+"               |");
                    

                    if (j == 0)
                        Views[i] = Convert.ToInt32(viewsText.Replace(@",", ""));
                    if (j == 1)
                        newViews[i] = Convert.ToInt32(viewsText.Replace(@",", ""));
                }
                Console.WriteLine     ("------------"+"at : " + DateTime.Now.TimeOfDay + "----------");
                past = DateTime.Now.TimeOfDay;
                if (j == 0)
                    Console.ReadLine();
            }
            for (int s = 0; s < url.Length; s++)

            {

                if (Views[s]  != 204 && newViews[s] != 204)
                {
                    totalPlus += newViews[s] - Views[s];
                    total += Views[s];
                }

                //if (Views[s] != 204)
                //    total += Views[s];
                //else
                //    total += newViews[s];

            }

            Console.WriteLine(totalPlus + "  new views in "+ (DateTime.Now.TimeOfDay - past));
            Hmm FV1 = new Hmm();
            FV1.Money(total);
            Console.WriteLine("the total Money (just from the Views :$" + total);
        }
    }
}




//for get url veide
//string strStart = ":{\"webCommandMetadata\":{\"url\":\"/watch?v=";
//string strEnd = "\",\"webPageType\":\"";
//string text = getBetween(strSource, strStart, strEnd);
//Console.WriteLine("\n" + text + "\n" + "\n");
//int count = 0;
//count = strSource.Where(x => x == strStart).Count();

//string SpecificWord = "/watch?";
//int count = 0;
//foreach (Match match in Regex.Matches(strSource, SpecificWord, RegexOptions.IgnoreCase))
//{
//    count++;
//}
//Console.WriteLine("{0}" + " Found " + "{1}" + " Times", SpecificWord, count);


