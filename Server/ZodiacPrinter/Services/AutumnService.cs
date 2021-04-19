using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacPrinter.Classes;

namespace ZodiacPrinter
{
    public class AutumnService : Autumn.AutumnBase
    {

        List<ZodiacSign> autumnSigns=new List<ZodiacSign>();

        public void ReadFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Misu\Documents\CNA\Tema2CNA\Server\ZodiacPrinter\Resources\autumn.txt");
            for(int i = 0; i < lines.Length / 5; i++)
            {
                ZodiacSign sign = new ZodiacSign();
                sign.StartDay = Int32.Parse(lines[i * 5]);
                sign.StartMonth = Int32.Parse(lines[i * 5+1]);
                sign.EndDay = Int32.Parse(lines[i * 5+2]);
                sign.EndMonth = Int32.Parse(lines[i * 5+3]);
                sign.SignName = lines[i * 5 + 4];
                autumnSigns.Add(sign);
            }
        }

        public bool CheckSign(int startDay,int endDay,int startMonth,int endMonth,string date)
        {
            int i = 0;
            int day = 0;
            int month = 0;
            while (!date[i].Equals('/'))
            {
                i++;
                day = day * 10 + Convert.ToInt32(date[i]);
            }
            while (!date[i].Equals('/'))
            {
                i++;
                month = month * 10 + Convert.ToInt32(date[i]);
            }
            Console.WriteLine(day);
            Console.WriteLine(month);
            if (month == startMonth)
            {
                if (day > startDay)
                    return true;
            }
            else if(month == endMonth)
            {
                if (day < endDay)
                    return true;
            }
            return false;
        }
        public override Task<AutumnReply> AutumnSign(AutumnRequest request, ServerCallContext context)
        {
            string signResult="No sign";
            if (request.Date != null)
            {
                this.ReadFromFile();
                Console.WriteLine("Client connected on Autumn!");
                for (int i = 0; i < autumnSigns.Count; i++)
                {
                    if(CheckSign(autumnSigns[i].StartDay,autumnSigns[i].EndDay,autumnSigns[i].StartMonth,
                        autumnSigns[i].EndMonth, request.Date))
                    {
                        signResult = autumnSigns[i].SignName;
                    }
                }
                
            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new AutumnReply
            {
                ZodiacSign = signResult
            });
        }
    }
}
