using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacPrinter.Classes;

namespace ZodiacPrinter
{
    public class SummerService : Summer.SummerBase
    {
        List<ZodiacSign> summerSigns = new List<ZodiacSign>();

        public void ReadFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Misu\Documents\CNA\Tema2CNA\Server\ZodiacPrinter\Resources\summer.txt");
            for (int i = 0; i < lines.Length / 5; i++)
            {
                ZodiacSign sign = new ZodiacSign();
                sign.StartDay = Int32.Parse(lines[i * 5]);
                sign.StartMonth = Int32.Parse(lines[i * 5 + 1]);
                sign.EndDay = Int32.Parse(lines[i * 5 + 2]);
                sign.EndMonth = Int32.Parse(lines[i * 5 + 3]);
                sign.SignName = lines[i * 5 + 4];
                summerSigns.Add(sign);
            }
        }

        public bool CheckSign(int startDay, int endDay, int startMonth, int endMonth, string date)
        {
            int i = 0;
            int day = 0;
            int month = 0;
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


            if (month == startMonth)
            {
                if (day > startDay)
                    return true;
            }
            else if (month == endMonth)
            {
                if (day < endDay)
                    return true;
            }
            return false;
        }
        public override Task<SummerReply> SummerSign(SummerRequest request, ServerCallContext context)
        {


            string signResult = "No sign";
            if (request.Date != null)
            {
                this.ReadFromFile();
                Console.WriteLine("Client connected on Summer!");
                Console.WriteLine(request.Date);
                for (int i = 0; i < summerSigns.Count; i++)
                {
                    if (CheckSign(summerSigns[i].StartDay, summerSigns[i].EndDay, summerSigns[i].StartMonth,
                        summerSigns[i].EndMonth, request.Date))
                    {
                        signResult = summerSigns[i].SignName;
                    }
                }

            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new SummerReply
            {
                ZodiacSign = signResult
            });
        }
    }
}
