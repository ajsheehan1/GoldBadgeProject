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

            

            ProgramUI start = new ProgramUI();
            start.Run();

        }
    }
}
