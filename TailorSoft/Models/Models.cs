using System;
using System.Collections.Generic;

namespace Tailorsoft
{
    public class ResultViewModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
    }

    public class DataModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
    }

    public class OrderModel
    {

        public string Id { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
    }

    public class ItemModel
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}