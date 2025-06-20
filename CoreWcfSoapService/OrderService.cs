using System;
using System.Threading.Tasks;

public class OrderService : IOrderService
{
    public async Task<OrderDto[]> GetOrdersAsync(DateTime date)
    {
        // Gerçek uygulamada database async operasyonu olabilir
        await Task.Delay(100); // Simulate async operation

        var orders = new OrderDto[]
        {
            new OrderDto
            {
                Id = 1001,
                OrderDate = date,
                DeliveryPoint = "İstanbul - Merkez Depo",
                ReceiverName = "Mehmet Yılmaz",
                ContactPhone = "05551112233",
                Status = 0,
                Items = new OrderItemDto[]
                {
                    new OrderItemDto
                    {
                        ProductName = "Koli A",
                        Quantity = 5
                    },
                    new OrderItemDto
                    {
                        ProductName = "Koli B",
                        Quantity = 3
                    }
                }
            },
            new OrderDto
            {
                Id = 1002,
                OrderDate = date.AddHours(2),
                DeliveryPoint = "Ankara - Şube",
                ReceiverName = "Ayşe Demir",
                ContactPhone = "05559998877",
                Status = 0,
                Items = new OrderItemDto[]
                {
                    new OrderItemDto
                    {
                        ProductName = "Paket X",
                        Quantity = 2
                    },
                    new OrderItemDto
                    {
                        ProductName = "Paket Y",
                        Quantity = 7
                    }
                }
            }
        };

        return orders;
    }
}