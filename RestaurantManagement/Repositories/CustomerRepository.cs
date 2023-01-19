using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities1 objRestaurantDBEntities1;
        public CustomerRepository()
        {
            objRestaurantDBEntities1 = new RestaurantDBEntities1();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in objRestaurantDBEntities1.Customers
                               select new SelectListItem()
                               {
                                   Text = obj.CustomerName,
                                   Value = obj.CustomerId.ToString(),
                                   Selected = true
                               }).ToList();

            return selectListItems;
        }
    }
}