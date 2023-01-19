using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get { return DateTime.Now; } }
        public decimal FinalTotal { get; set; }
        public IEnumerable<OrderDetailViewModel> listOrderDetailViewModel { get; set; }
    }
}