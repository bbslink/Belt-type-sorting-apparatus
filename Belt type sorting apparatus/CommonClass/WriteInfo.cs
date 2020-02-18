using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class WriteInfo
    {
        public static StreamWriter sw1;
        public static StreamWriter sw2;
        public static StreamWriter sw3;
        public static StreamWriter sw4;
        public static StreamWriter sw5;
        public static StreamWriter sw6;


        public static void WriteSB(string select,string ss)
        {

            switch (select)
            {
                case "fsxj":
                    sw1.WriteLine("fsxj" +  "," + ss);
                    sw1.Flush();
                    break;
                case "fxxj":
                    sw2.WriteLine("fxxj" + "," + ss);
                    sw2.Flush();
                    break;
                case "ftg":
                    sw3.WriteLine("ftg" + "," + ss);
                    sw3.Flush();
                    break;
                case "bsxj":
                    sw4.WriteLine("bsxj" + "," + ss);
                    sw4.Flush();
                    break;
                case "bxxj":
                    sw5.WriteLine("bxxj" + "," + ss);
                    sw5.Flush();
                    break;
                case "btg":
                    sw6.WriteLine("btg" + "," + ss);
                    sw6.Flush();
                    break;
            }

        }

        public static void CloseAllStream()
        {
            if (sw1 != null)
            {
                sw1.Close();
            }
            if (sw2 != null)
            {
                sw2.Close();
            }
            if (sw3 != null)
            {
                sw3.Close();
            }
            if (sw4 != null)
            {
                sw4.Close();
            }
            if (sw5 != null)
            {
                sw5.Close();
            }
            if (sw6 != null)
            {
                sw6.Close();
            }
            
        }

        public static void OpenAllStream()
        {
            sw1 = new StreamWriter("D://points//fsxj.txt", true);
            sw2 = new StreamWriter("D://points//fxxj.txt", true);
            sw3 = new StreamWriter("D://points//ftg.txt", true);
            sw4 = new StreamWriter("D://points//bsxj.txt", true);
            sw5 = new StreamWriter("D://points//bxxj.txt", true);
            sw6 = new StreamWriter("D://points//btg.txt", true);  
        }


    }
}
