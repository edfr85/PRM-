using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Net;


namespace PRM_.DATA
{
  
    class CData
    {
        public static string sSetDir = Environment.CurrentDirectory + @"\SET";
        public static string sRunListPath = Environment.CurrentDirectory + @"\SET\RList.ini";
        public static string sKillListPath = Environment.CurrentDirectory + @"\SET\KList.ini";

        public static UC_Log ucLog;

        public static List<int> garOpt1 = new List<int>();

        public static string[] garOpt1_Name = { "실행시 자동 종료"               //0
        };
                                                
                        
 
    }

}
