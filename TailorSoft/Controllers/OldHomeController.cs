using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Tailorsoft
{
    public class OldHomeController : Controller
    {
        private IOldOrdersService service;
        static string dataUrl = "https://www.tailorsoft.co/sample.json";

        public OldHomeController()
        {
            service = new OldOrdersService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetData(dataUrl));
        }
    }

    public interface IOldOrdersService
    {
        DataModel GetData(string url);
    }

    public class OldOrdersService : IOldOrdersService
    {
        public DataModel GetData(string url)
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