using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Ad_Test.EF
{
    internal class Linq_Join_Into
    {
        public static void go()
        {

            int[] intAry1 = { 5, 15, 25, 30, 33, 40,0 };
            int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80,15 };
            var query1 =
            from val1 in intAry1
            join val2 in intAry2 on val1 / 5 equals val2 / 15 into val2Grp
            select new { VAL1 = val1, VAL2GRP = val2Grp };
            Console.WriteLine(JsonConvert.SerializeObject(query1));
            Console.ReadKey();
        }
    }
}
