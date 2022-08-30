using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_CoffeeShop.Model
{
    internal class OrderList
    {
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerPhoneNUmber { get; set; } = string.Empty;
        public string OwnerAddress { get; set; } = string.Empty;

        private List<IOrderItem> _items = new List<IOrderItem>();

        public int Count {
            get => _items.Count();
            }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem()
        {

        }
        public double GetPrice()
        {
            double price = 0;
            foreach (var item in _items)
            {
                price += item.Price;
            }
            return price;
        }

        public string[] GetStringArray()
        {
            string[] itemLines = new string[_items.Count()];
            int count = 0;
            foreach(var item in _items)
            {
                itemLines[count++] = item.ToString();
            }
            return itemLines;
        }

    }
}
