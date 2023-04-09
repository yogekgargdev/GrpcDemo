using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

//var input = new HelloRequest { Name = "Tim" };
//var channel = GrpcChannel.ForAddress("https://localhost:7003/");
//var client = new Greeter.GreeterClient(channel);

//var output = await client.SayHelloAsync(input);
//Console.WriteLine(output.Message);
//Console.ReadLine();

var channel = GrpcChannel.ForAddress("https://localhost:7003/");
var client = new Customer.CustomerClient(channel);

//var output = await client.GetCustoemrInfoAsync(new CustomerLookupModel() { UserId = 1 });
//Console.WriteLine(output);

using (var output = client.GetCustoemrInfoStream(new CustomerTestModel()))
{
    while (await output.ResponseStream.MoveNext())
    {
        Console.WriteLine(output.ResponseStream.Current);
    }

}

Console.ReadLine();