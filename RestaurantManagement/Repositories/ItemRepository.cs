using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities1 objRestaurantDBEntities1;
        public ItemRepository()
        {
            objRestaurantDBEntities1 = new RestaurantDBEntities1();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in objRestaurantDBEntities1.Items
                               select new SelectListItem()
                               {
                                   Text = obj.ItemName,
                                   Value = obj.ItemId.ToString(),
                                   Selected = true
                               }).ToList();

            return selectListItems;
        }
    }
}