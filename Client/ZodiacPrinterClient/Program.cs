using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ZodiacPrinterClient
{
    class Program
    {
        public static bool dateValid(string date)
        {
            for (int i = 0; i < date.Length; i++)
            {
                if (!Char.IsDigit(date[i]) && !date[i].Equals('/'))
                    return false;
            }
            return true;
        }
        static async Task Main(string[] args)
        {
            string date;
            do
            {
                Console.WriteLine("Enter a date: ");
                date = Console.ReadLine();
                if (dateValid(date))
                {

                    CalendarDate newDate = CalendarDate.ConvertToCalendarDate(date);

                    if (CalendarDate.Validation(newDate))
                    {

                        if (newDate.Month == 1 || newDate.Month == 2 || newDate.Month == 12)
                        {
                            using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                            var client = new Winter.WinterClient(channel);
                            var reply = client.WinterSign(
                                              new WinterRequest { Date = date });
                            Console.WriteLine("Your sign is: " + reply.ZodiacSign);
                        }
                        else if (newDate.Month == 3 || newDate.Month == 4 || newDate.Month == 5)
                        {
                            using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                            var client = new Spring.SpringClient(channel);
                            var reply = client.SpringSign(
                                              new SpringRequest { Date = date });
                            Console.WriteLine("Your sign is: " + reply.ZodiacSign);
                        }
                        else if (newDate.Month == 6 || newDate.Month == 7 || newDate.Month == 8)
                        {
                            using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                            var client = new Summer.SummerClient(channel);
                            var reply = client.SummerSign(
                                              new SummerRequest { Date = date });
                            Console.WriteLine("Your sign is: " + reply.ZodiacSign);
                        }
                        else
                        {
                            using var channel = GrpcChannel.ForAddress("https://localhost:7580");
                            var client = new Autumn.AutumnClient(channel);
                            var reply = client.AutumnSign(
                                              new AutumnRequest { Date = date });
                            Console.WriteLine("Your sign is: " + reply.ZodiacSign);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }
            } while (!dateValid(date));
        }
    }
}
