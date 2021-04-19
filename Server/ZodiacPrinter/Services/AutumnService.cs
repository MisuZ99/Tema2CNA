using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZodiacPrinter
{
    public class AutumnService : Autumn.AutumnBase
    {

        public override Task<AutumnReply> AutumnSign(AutumnRequest request, ServerCallContext context)
        {

            if (request.Date != null)
            {

                Console.WriteLine("Client connected on Autumn!");
            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new AutumnReply
            {
                ZodiacSign = "Leu"
            });
        }
    }
}
