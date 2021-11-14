using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace NewDesignMillionAndUpTest.Utilities
{
    public class DateProcessor
    {
        private int numberDay;

        public int ClicksQuantityToSelectMonth(int month, int day)
        {
            DateTime nowDate = DateTime.Now;

            int clicks;
            int lastMonth = 12;
            int actualMonth = nowDate.Month;
            int monthToSelect = month;

            if (lastMonth == monthToSelect)
            {
                clicks = monthToSelect - actualMonth;
            }
            else if (monthToSelect < actualMonth)
            {
                clicks = lastMonth - (actualMonth - monthToSelect);

            }
            else
            {
                clicks = lastMonth - (monthToSelect - actualMonth);
            }

            return clicks;
        }

        public string MonthConverter(int intMonth)
        {
           string month=null;
           switch (intMonth)
            {
                case 1:
                   month = "ENERO";
                   break;
                case 2:
                   month = "FEBRERO";
                   break;
                case 3:
                   month = "MARZO";
                   break;
                case 4:
                   month = "ABRIL";
                   break;
                case 5:
                   month = "MAYO";
                   break;
                case 6:
                   month = "JUNIO";
                   break;
                case 7:
                   month = "JULIO";
                   break;
                case 8:
                   month = "AGOSTO";
                   break;
                case 9:
                   month = "SEPTIEMBRE";
                   break;
                case 10:
                   month = "OCTUBRE";
                   break;
                case 11:
                   month = "NOVIEMBRE";
                   break;
                case 12:
                   month = "DICIEMBRE";
                   break;
            }
            return month;

        }
    }
}

