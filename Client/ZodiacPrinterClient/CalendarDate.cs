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
            i++;
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

        public static bool Validation(CalendarDate date)
        {
            if (date.Month > 12||date.Month<=0)
            {
                Console.WriteLine("There are only 12 months");
                return false;
                
            }

            if (date.Day <= 0)
            {
                Console.WriteLine("Wrong input!");
                return false;
            }

            if (date.Month == 1)
            {
                if(date.Day>31)
                {
                    Console.WriteLine("January has only 31 days");
                    return false;
                }
            }
            if (date.Month == 2)
            {
                if ((date.Year % 4 == 0&&date.Year%100!=0)||date.Year%400==0)
                {
                    if(date.Day>29)
                    {
                        Console.WriteLine("This February has only 29 days");
                        return false;
                    }
                }
                else if (date.Day > 28)
                {
                    Console.WriteLine("This February has only 28 days");
                }
            }
            if (date.Month == 3)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("March has only 31 days");
                    return false;
                }
            }
            if (date.Month == 4)
            {
                if (date.Day > 30)
                {
                    Console.WriteLine("April has only 30 days");
                    return false;
                }
            }
            if (date.Month == 5)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("May has only 31 days");
                    return false;
                }
            }
            if (date.Month == 6)
            {
                if (date.Day > 30)
                {
                    Console.WriteLine("June has only 30 days");
                    return false;
                }
            }
            if (date.Month == 7)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("July has only 31 days");
                    return false;
                }
            }
            if (date.Month == 8)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("August has only 31 days");
                    return false;
                }
            }
            if (date.Month == 9)
            {
                if (date.Day > 30)
                {
                    Console.WriteLine("September has only 30 days");
                    return false;
                }
            }
            if (date.Month == 10)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("October has only 31 days");
                    return false;
                }
            }
            if (date.Month == 11)
            {
                if (date.Day > 30)
                {
                    Console.WriteLine("November has only 30 days");
                    return false;
                }
            }
            if (date.Month == 12)
            {
                if (date.Day > 31)
                {
                    Console.WriteLine("December has only 30 days");
                    return false;
                }
            }



            return true;
        }
    }
}
