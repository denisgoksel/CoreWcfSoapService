
using System;
using System.Runtime.Serialization;

[DataContract(Namespace = "http://tempuri.org/")]
[KnownType(typeof(OrderItemDto[]))]
public class OrderDto
{
    [DataMember(Order = 1)]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public DateTime OrderDate { get; set; }

    [DataMember(Order = 3)]
    public string DeliveryPoint { get; set; }

    [DataMember(Order = 4)]
    public string ReceiverName { get; set; }

    [DataMember(Order = 5)]
    public string ContactPhone { get; set; }

    [DataMember(Order = 6)]
    public int Status { get; set; }

    [DataMember(Order = 7)]
    public OrderItemDto[] Items { get; set; }

    // Constructor - Items'ı initialize et
    public OrderDto()
    {
        Items = new OrderItemDto[0]; // Boş array
    }
}