using CoreWCF;
using System;
using System.Threading.Tasks;
 
[ServiceContract(Namespace = "http://tempuri.org/")]
public interface IOrderService
{
    [OperationContract]
    Task<OrderDto[]> GetOrdersAsync(DateTime date);
}