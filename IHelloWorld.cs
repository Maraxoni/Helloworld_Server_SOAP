using CoreWCF;

namespace Helloworld_Server_SOAP
{
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string GetHelloWorldAsString(string name);
    }
}
