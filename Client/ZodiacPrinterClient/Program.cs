using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ZodiacPrinterClient
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            Console.WriteLine("date: ");
            string date = Console.ReadLine();

            CalendarDate newDate = CalendarDate.ConvertToCalendarDate(date);

            if (newDate.Month == 1 || newDate.Month == 2 || newDate.Month == 12)
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                var client = new Winter.WinterClient(channel);
                var reply = client.WinterSign(
                                  new WinterRequest { Date = date });
                Console.WriteLine(reply.ZodiacSign);
            }
            else if (newDate.Month == 3 || newDate.Month == 4 || newDate.Month == 5)
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                var client = new Spring.SpringClient(channel);
                var reply = client.SpringSign(
                                  new SpringRequest {Date=date });
                Console.WriteLine(reply.ZodiacSign);
            }
            else if (newDate.Month == 6 || newDate.Month == 7 || newDate.Month == 8)
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                var client = new Summer.SummerClient(channel);
                var reply = client.SummerSign(
                                  new SummerRequest {Date=date });
                Console.WriteLine(reply.ZodiacSign);
            }
            else
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                var client = new Autumn.AutumnClient(channel);
                var reply = client.AutumnSign(
                                  new AutumnRequest { Date = date });
                Console.WriteLine(reply.ZodiacSign);
            }

        }
    }
}
