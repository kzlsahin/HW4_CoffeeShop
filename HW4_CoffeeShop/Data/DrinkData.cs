using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_CoffeeShop.Data
{
    using Model;
    using System.Xml.Serialization;

    [Serializable()]
    [XmlRoot("DrinkData")]
    public class DrinkData
    {
        [XmlArray("Drinks")]
        [XmlArrayItem("Drink", typeof(Drink))]
        public Drink[] Drinks { get; set; }
    }

    [Serializable()]
    public struct Drink
    {
        [XmlElement("Category")]
        public DrinkCategories category { get; set; }

        [XmlElement("DrinkName")]
        public String DrinkName { get; set; }

        [XmlElement("Price")]
        public float Price { get; set; }
    }
    public class DataProvider
    {
        private DrinkData _drinkData;
        public DrinkData DrinkData
        {
            get => _drinkData;
        }
        string path = "Data/DrinkData.xml";

        public Dictionary<string, float> ProductNamePrice { get; set; } = new Dictionary<string, float>();

        public DataProvider()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DrinkData));
                this._drinkData = (DrinkData)serializer.Deserialize(reader);
                reader.Close();
            }

            foreach (Drink drink in _drinkData.Drinks)
            {
                ProductNamePrice.Add(drink.DrinkName, drink.Price);
            }

        }

        public double GetPrice(OrderItem orderItem)
        {
            double price = ProductNamePrice[orderItem.ProductName];
            double multiplier = 1;
            switch (orderItem.CupSize)
            {
                case CupSize.Medium:
                    multiplier = 1.25;
                    break;
                case CupSize.Big:
                    multiplier = 1.75;
                    break;
            }

            price *= multiplier;

            price += orderItem.NumberOfShotsAdded * 0.75;

            if(orderItem.MilkAddition == Milk.Soya)
            {
                price += 0.5;
            }


            return price;
        }
        public string[] GetDrinkNames(DrinkCategories category)
        {
            List<string> names = new();
            foreach (Drink drink in _drinkData.Drinks)
            {
                if (drink.category == category)
                {
                    names.Add(drink.DrinkName);
                }
            }
            return names.ToArray();
        }
    }
}
