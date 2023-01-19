using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Repositories
{
    public class PaymentRepository
    {
        private RestaurantDBEntities1 objRestaurantDBEntities1;
        public PaymentRepository()
        {
            objRestaurantDBEntities1 = new RestaurantDBEntities1();
        }

        public IEnumerable<SelectListItem> GetAllPayments()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in objRestaurantDBEntities1.Payments
                               select new SelectListItem()
                               {
                                   Text = obj.PaymentMethod,
                                   Value = obj.PaymentId.ToString(),
                                   Selected = true
                               }).ToList();

            return selectListItems;
        }
    }
}