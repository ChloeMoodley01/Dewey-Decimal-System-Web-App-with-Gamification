using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10119385_ChloeMoodley.FindCallNumbers
{
    //Class made to call all data from the csv file
    //Code modified from Stack Overflow (2022)
    //Link: https://stackoverflow.com/questions/21813461/reading-a-csv-file-into-wpf-application-c
    public class CallNumbersClass
    {

        //code modified by Troelsen & Japikse (2017)
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }

        public CallNumbersClass() { }

        //code modified by Troelsen & Japikse (2017)
        //constructor demostrated below
        public CallNumbersClass(string cat1, string cat2, string cat3)
        {
            Cat1 = cat1;
            Cat2 = cat2;
            Cat3 = cat3;
        }
    }
}
