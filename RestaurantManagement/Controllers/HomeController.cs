using RestaurantManagement.Models;
using RestaurantManagement.Repositories;
using RestaurantManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities1 objRestaurantDBEntities1;
        public HomeController()
        {
            objRestaurantDBEntities1 = new RestaurantDBEntities1();
        }

        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItemRepository objitemRepository = new ItemRepository();
            PaymentRepository objpaymentRepository = new PaymentRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objcustomerRepository.GetAllCustomers(), objitemRepository.GetAllItems(), objpaymentRepository.GetAllPayments());

            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult GetItemUnitPrice(int itemId)
        {
            decimal unitPrice= objRestaurantDBEntities1.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            bool isStatus = objOrderRepository.AddOrder(objOrderViewModel);
            string SuccessMessage = String.Empty;

            if (isStatus)
            {
                SuccessMessage = "Your Order Has Been Successfully Placed.";
            }
            else
            {
                SuccessMessage = "There Is Some Issue While Placing Order.";
            }
            return Json(SuccessMessage, JsonRequestBehavior.AllowGet);
        }

        private class OrderRepository
        {
            internal bool AddOrder(OrderViewModel objOrderViewModel)
            {
                throw new NotImplementedException();
            }
        }
    }
}