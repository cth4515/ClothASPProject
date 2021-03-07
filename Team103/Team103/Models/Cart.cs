using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Team103.Models
{
    public class Cart
    {
        [JsonProperty] List<CartItem> cart = new List<CartItem>();
        const int MaxQuantity = 100;
        public void AddItem(TblProduct product)
        {
            CartItem item = cart.Where(c => c.Product.ProductPk == product.ProductPk).FirstOrDefault();
            if(item == null)
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 }); 
            }
            else
            {
                if(item.Quantity <MaxQuantity)
                    item.Quantity += 1;
            }
        }

        public void UpdateItem(TblProduct product, int quantity)
        {
            CartItem item = cart.Where(c => c.Product.ProductPk == product.ProductPk).FirstOrDefault();
            if(item != null)
            {
                item.Quantity = (quantity < MaxQuantity) ? quantity : MaxQuantity;
            }

        }

        public void RemoveItem(TblProduct product)
        {
            cart.RemoveAll(p => p.Product.ProductPk == product.ProductPk);
        }

        public void ClearCart()
        {
            cart.Clear();
        }

        public decimal ComputeOrderTotal()
        {
            return cart.Sum(c => c.Product.UnitPrice * c.Quantity);
        }

        public IEnumerable<CartItem> CartItems()
        {
            return cart;
        }

    }
}
