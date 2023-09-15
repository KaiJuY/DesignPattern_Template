using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //建造者模式
    //這個Model希望解決的問題是在物件創建時
    //因為物件的屬性很多如果直接寫在建構子當參數傳入
    //很容易出錯且不容易閱讀因此會在類別中新增一個Builder
    //來協助創建時的參數傳入

    public class Meal
    {
        private Meal(MealBuilder mealBuilder)
        {
            Price = mealBuilder.Price;
            MainCourse = mealBuilder.MainCourse;
            Dessert = mealBuilder.Dessert;
            Drink = mealBuilder.Drink;
        }
        private double Price { get; set; }
        private string MainCourse { get; set; }
        private string Dessert { get; set; }
        private string Drink { get; set; }
        public double GetPrice() { return Price; }
        public string GetMainCourse() { return MainCourse; }
        public string GetDessert() { return Dessert; }
        public string GetDrink() { return Drink; }
        public class MealBuilder
        {
            public double Price { get; set; }
            public string MainCourse { get; set; }
            public string Dessert { get; set; }
            public string Drink { get; set; }
            public MealBuilder(string maincourse)
            {
                MainCourse = maincourse;
            }
            public MealBuilder SetMainCourse(string maincourse)
            {
                MainCourse = maincourse;
                return this;
            }
            public MealBuilder SetDessert(string dessert)
            {
                Dessert = dessert;
                return this;
            }
            public MealBuilder SetDrink(string drink)
            {
                Drink = drink;
                return this;
            }
            public MealBuilder SetPrice(double price)
            {
                Price = price;
                return this;
            }
            public Meal build()
            {
                return new Meal(this);
            }
        }
    }
    public class MealDemo
    {
        public void Demo()
        {
            Meal Beefmeal = new Meal.MealBuilder("Beef")
                .SetDrink("Coke")
                .SetDessert("IceCream")
                .SetPrice(99.9)
                .build();

            Console.WriteLine("Meal Detail - \n Main Course : {0}\n Drink : {1}\n Dessert : {2}\n Price : {3}\n ", 
                Beefmeal.GetMainCourse(), Beefmeal.GetDrink(), Beefmeal.GetDessert(), Beefmeal.GetPrice());
            /*
             * Meal Detail - 
             * Main Course : Beef
             * Drink : Coke
             * Dessert : IceCream
             * Price : 99.9
             */
        }
    }
}
