using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService:Customer.CustomerBase
    {
        public readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<customerModel> GetCustoemrInfo(CustomerLookupModel request, ServerCallContext context)
        {
            customerModel customerModel = new customerModel();

            if(request.UserId==1)
            {
                customerModel.FirstName = "Yogek";
                customerModel.LastName = "Garg";
                customerModel.EmailAddress = "yogekgarg17@gmail.com";
                customerModel.Age = 23;

            }
            else if(request.UserId==2)
            {
                customerModel.FirstName = "Abhinav";
                customerModel.LastName = "Chnadla";
                customerModel.EmailAddress = "abhichandla@gmail.com";
                customerModel.Age = 23;
                customerModel.IsAlive = "true";

            }
            return Task.FromResult(customerModel);
        }

        public override async Task GetCustoemrInfoStream(CustomerTestModel request, IServerStreamWriter<customerModel> responseStream, ServerCallContext context)
        {
            List<customerModel> customerlist = new List<customerModel>()
            {
                new customerModel()
                {
                      FirstName = "Yogek",
                      LastName = "Garg",
                      EmailAddress = "yogekgarg17@gmail.com",
                      Age = 23
                },
                new customerModel()
                {
                      FirstName = "Abhinav",
                      LastName = "Chandla",
                      EmailAddress = "abhichandla@gmail.com",
                      Age = 23
                }
            };

            foreach(customerModel customer in customerlist)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(customer);
            }
            
        }


    }
}
