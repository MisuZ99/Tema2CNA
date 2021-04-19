using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZodiacPrinter
{
    public class SummerService : Summer.SummerBase
    {

        public override Task<SummerReply> SummerSign(SummerRequest request, ServerCallContext context)
        {

            if (request.Date != null)
            {

                Console.WriteLine("Client conected on Summer!");
            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new SummerReply
            {
                ZodiacSign = "Capricorn"
            });
        }
    }
}
