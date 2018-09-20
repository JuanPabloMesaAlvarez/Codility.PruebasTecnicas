using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Tailorsoft
{
    public class HomeController : Controller
    {
        private IOrdersService service;
        static string dataUrl = "https://www.tailorsoft.co/sample.json";

        public HomeController()
        {
            service = new OrdersService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetDataReslt(dataUrl));
        }
    }

    public interface IOrdersService
    {
        IEnumerable<ResultViewModel> GetDataReslt(string url);
    }

    public class OrdersService : IOrdersService
    {
        public IEnumerable<ResultViewModel> GetDataReslt(string url)
        {
            DataModel data = ReadDataSource(url);
            if (data == null)
            {
                return null;
            }

            List<ItemModel> items = new List<ItemModel>();
            data.Orders.ToList().ForEach(order => {
                items.AddRange(order.Items);
            });
            
            var query = from product in data.Products
                        join item in items
                           on product.Id equals item.ProductId into product_item
                        from group_product_item in product_item.GroupBy(pi => pi.ProductId).DefaultIfEmpty()
                        select new ResultViewModel
                        {
                            ProductId = product.Id,
                            Name = product.Name,
                            Total = product_item.Sum(i => i.Quantity) * product.Price
                        };

            return query;
        }

        private DataModel ReadDataSource(string url)
        {
            DataModel data = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string mdata = response.Content.ReadAsStringAsync().Result;
                data = (DataModel)JsonConvert.DeserializeObject(mdata, typeof(DataModel));
            }
            return data;
        }

    }
}