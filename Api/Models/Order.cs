using System;
using PetStore6.Constants.Enums;

namespace PetStore6.Api.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Boolean Complete { get; set; }

        public Order(long id, long petId, int quantity, string shipDate, OrderStatus orderStatus, bool complete)
        {
            Id = id;
            PetId = petId;
            Quantity = quantity;
            ShipDate = shipDate;
            OrderStatus = orderStatus;
            Complete = complete;
        }

        public static bool operator ==(Order left, Order right)
        {
            bool comparison = true;
            return comparison;
        }

        public static bool operator !=(Order left, Order right)
        {
            return !(left == right);
        }

        public DateTime DataTimeParse(string date)
        {
            var dateFormatString = "MM'/'dd'/'yyyy HH:mm:ss";
            DateTime oDate = DateTime.ParseExact(date, dateFormatString, null);

            return oDate;
        }
    }
}
