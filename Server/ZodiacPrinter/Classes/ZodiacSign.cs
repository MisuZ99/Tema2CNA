using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacPrinter.Classes
{
    public class ZodiacSign
    {
        private int startDay;

        public int StartDay
        {
            get
            {
                return startDay;
            }

            set
            {
                startDay = value;
            }
        }

        private int endDay;

        public int EndDay
        {
            get
            {
                return endDay;
            }

            set
            {
                endDay = value;
            }
        }

        private int startMonth;

        public int StartMonth
        {
            get
            {
                return startMonth;
            }

            set
            {
                startMonth = value;
            }
        }

        private int endMonth;

        public int EndMonth
        {
            get
            {
                return endMonth;
            }

            set
            {
                endMonth = value;
            }
        }

        private string signName;

        public string SignName
        {
            get
            {
                return signName;
            }
            set
            {
                signName = value;
            }
        }
    }
}
