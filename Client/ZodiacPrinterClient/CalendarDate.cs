using System;
using System.Collections.Generic;
using System.Text;

namespace ZodiacPrinterClient
{
    class CalendarDate
    {
        private int month;
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }

        private int day;
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public static CalendarDate ConvertToCalendarDate(string date)
        {
            CalendarDate newDate = new CalendarDate();
            int month = 0;
            int day = 0;
            int year = 0;
            int i = 0;
            while (!date[i].Equals('/'))
            {
                month = month * 10 + (int)Char.GetNumericValue(date[i]);
                i++;
            }
            i++;
            while (!date[i].Equals('/'))
            {

                day = day * 10 + (int)Char.GetNumericValue(date[i]);
                i++;
            }
            while (i < date.Length)
            {
                year = year * 10 + (int)Char.GetNumericValue(date[i]);
                i++;
            }

            newDate.Year = year;
            newDate.Month = month;
            newDate.Day = day;
            return newDate;
        }
    }
}
