using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ZodiacPrinterClient
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            /* using var channel = GrpcChannel.ForAddress("https://localhost:7580");
             var client = new Spring.SpringClient(channel);
             var reply = client.SpringSign(
                               new SpringRequest {  });
             Console.WriteLine( reply.ZodiacSign);*/

            using var channel = GrpcChannel.ForAddress("https://localhost:7580");
            var client = new Autumn.AutumnClient(channel);
            var reply = client.AutumnSign(
                              new AutumnRequest {Date="04/09/2010" });
            Console.WriteLine(reply.ZodiacSign);

        }
    }
}
