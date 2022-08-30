using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW4_CoffeeShop.Data;

namespace HW4_CoffeeShop.Model
{
    public class OrderItem : IOrderItem
    {
        public String ProductName { get; set; }
        public CupSize CupSize { get; set; }
        public Milk MilkAddition { get; set; }
        public int NumberOfShotsAdded { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{CupSize} {this.ProductName}, {(MilkAddition == Milk.None ? string.Empty : MilkAddition.ToString() )} " +
                $"{(NumberOfShotsAdded > 0 ? NumberOfShotsAdded: string.Empty)} : {Price:C} TL  ";
        }
    }

    public interface IOrderItem
    {
        String ProductName { get; }
        CupSize CupSize { get; }
        Milk MilkAddition { get; }
        int NumberOfShotsAdded { get; }
        double Price { get; }
        string ToString();
    }
}
