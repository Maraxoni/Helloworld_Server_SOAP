using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Helloworld_Server_SOAP
{
    public class HelloWorldService : IHelloWorld
    {
        public string GetHelloWorldAsString(string name)
        {
            return $"Hello World SOAP: {name}";
        }
    }
}
