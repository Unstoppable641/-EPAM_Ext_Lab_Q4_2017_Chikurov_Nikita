using Task01.Models;

namespace Task01.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using DAL.Components;

    public class HomeController : Controller
    {
        private DAL.DAL dal = new DAL.DAL();

        //  GET: Home
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            if (page <= 0)
            {
                return HttpNotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = page,
                TotalItems = dal.GetTotalCountOrders()
            };

            var pageSize = PageInfo.PageSize;

            var orders = dal.GetOrders(((page - 1) * pageSize) + 1, page * pageSize);
            if (orders == null)
            {
                return HttpNotFound();
            }

            // var mapp = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderView>()
            // .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(OrderStatus),src.OrderState))));

            //
            //Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderView>()
            //    .ForMember(
            //    dest => dest.OrderStatus,
            //    opt => opt.MapFrom(src => Enum.GetName(
            //        typeof(OrderStatus),
            //        src.OrderState))));

            List<OrderView> OrderView = Mapper.Map<IEnumerable<Order>, List<OrderView>>(orders);
            for (var i = 0; i < orders.Count; i++)
            {
                OrderView[i].Sum = dal.GetExtendedPrice(OrderView[i].OrderID);
            }

            //var model2 = Mapper.Map<Order>(this);
            var model = new IndexOrderViewModel()
            {
                Orders = OrderView,
                Page = pageInfo
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CreateProductViewModel model = new CreateProductViewModel();
            ViewBag.OrderID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductViewModel model, string button)
        {
            ViewBag.ErrorMessage = "Incorrect data";// todo pn не понял, ещё ничего не проверил и уже некорректно?
            switch (button)
            {
                case null:
                    return View(model);
                case "Cancel":
                    return RedirectToAction("Index", "Home");
            }

            if (model == null || !ModelState.IsValid)
            {

                return View(model);
            }

            dal.AddProduct(
                model.OrderID,
                model.ProductName,
                model.UnitPrice,
                model.Discount,
                model.Quantity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DisplayDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var order = dal.GetInfoOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDetailsViewModel>()//todo pn удалить
            .ForMember(
                dest => dest.OrderStatus,
                opt => opt.MapFrom(src => Enum.GetName(typeof(OrderStatus), src.OrderState))));
            var model = Mapper.Map<Order, OrderDetailsViewModel>(order);

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderDetailsViewModel model, string button)
        {
            if (button == "Cancel")
            {
                return RedirectToAction("Index", "Home");
            }

            if (model == null || !ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Incorrect data";
                return View();
            }

            dal.AddOrder(//todo pn самому не надоело поля прописывать? передавал бы объект класса, было бы проще
				model.OrderDate,
                model.RequiredDate,
                model.ShippedDate,
                model.Freight,
                model.ShipName,
                model.ShipAddress,
                model.ShipCity,
                model.ShipRegion,
                model.ShipPostalCode,
                model.ShipCountry);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}