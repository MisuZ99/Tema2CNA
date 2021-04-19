using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZodiacPrinter
{
    public class SpringService : Spring.SpringBase
    {

        public override Task<SpringReply> SpringSign(SpringRequest request, ServerCallContext context)
        {

            if (request.Date != null)
            {

                Console.WriteLine("Client connected on Spring!");
            }
            else
            {
                Console.WriteLine(request.Date + " wrong input!");
            }

            return Task.FromResult(new SpringReply
            {
                ZodiacSign = "Leu"
            });
        }
    }
}
