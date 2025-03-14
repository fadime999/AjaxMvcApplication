﻿namespace AjaxMvcApp.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; } 
        public int StockQuantity { get; set; } 
        public DateTime CreatedDate { get; set; } 
    }
}
