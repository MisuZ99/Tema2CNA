using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZodiacPrinter
{
    public class WinterService : Winter.WinterBase
    {

        public override Task<WinterReply> WinterSign(WinterRequest request, ServerCallContext context)
        {

            if (request.Date != null)
            {

                Console.WriteLine("Client connected on Winter!");
            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new WinterReply
            {
                ZodiacSign = "Pesti"
            });
        }
    }
}

