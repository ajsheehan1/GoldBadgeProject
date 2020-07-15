using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class Program
    {
        private static Dictionary<string, object> dict;
        private static void Add(string strKey, object dataType)
        {
            if (!dict.ContainsKey(strKey))
            {
                dict.Add(strKey, dataType);
            }
            else
            {
                dict[strKey] = dataType;
            }
        }


        
        private static T GetAnyValue<T>(string strKey)
        {
            object obj;
            T returnType;

            dict.TryGetValue(strKey, out obj);

            try
            {
                returnType = (T)obj; 
            }
            catch
            {
                returnType = default(T);
            }
            return returnType;
        }
        public static void Main(string[] args)
        {

            /*Dictionary<string, List<string>> badgeDict = new Dictionary<string, List<string>>();

            List<string> badgeList = new List<string>();

            badgeList.Add("B7");
            badgeList.Add("B5");

            badgeDict.Add("1234", badgeList);
            string concat = String.Join(",", badgeList.ToArray());

            Console.WriteLine(concat);
            Console.WriteLine($"BadgeID: 1234 RoomID = {badgeDict["1234"]}");

            

          

            Console.ReadLine();*/

            ProgramUI start = new ProgramUI();
            start.Run();

        }
    }
}
