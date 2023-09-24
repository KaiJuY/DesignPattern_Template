using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //抽象工廠模式
    //建議先了解Factory Pattern後再理解這個
    //這為工廠模式的延伸使用
    //其實概念是一樣的就是將工廠變成一個interface
    //再透過這個interface去建立工廠的類別
    //使用時再使用這個抽象工廠去根據argument得到不同的工廠
    //並可以利用這個工廠得到不同的產品

    public abstract class AbstractShop
    {
        public Bread GetBakery(string bread)
        {
            return null;
        }
        public Coffee GetCafe(string coffee)
        {
            return null;
        }
    }
    public interface Bread
    {
        void Description();
    }
    public class Bagel : Bread 
    {
        public void Description()
        {
            Console.WriteLine("I'm a Bagel.");
        }
    }
    public class Croissant : Bread
    {
        public void Description()
        {
            Console.WriteLine("I'm a Croissant.");
        }
    }
    public class Crepe : Bread
    {
        public void Description()
        {
            Console.WriteLine("I'm a Crepe.");
        }
    }
    public class Bakery : AbstractShop
    {
        public override Bread GetBread(string breadtype)
        {
            if (breadtype == null)
                return null;

            if (String.Equals(breadtype, "Bagel", StringComparison.CurrentCultureIgnoreCase))
                return new Bagel();
            else if (String.Equals(breadtype, "Croissant", StringComparison.CurrentCultureIgnoreCase))
                return new Croissant();
            else if (String.Equals(breadtype, "Crepe", StringComparison.CurrentCultureIgnoreCase))
                return new Crepe();
            else
                return null;
        }
    }
    public interface Coffee
    {
        void Description();
    }
    public class Americano : Coffee 
    {
        public void Description()
        {
            Console.WriteLine("I'm a Americano.");
        }
    }
    public class LatteCoffee : Coffee
    {
        public void Description()
        {
            Console.WriteLine("I'm a LatteCoffee.");
        }
    }
    public class Cappuccino : Coffee
    {
        public void Description()
        {
            Console.WriteLine("I'm a Cappuccino.");
        }
    }
    public class Cafe : AbstractShop
    {
        public override Coffee GetCoffee(string coffee)
        {
            if (coffee == null)
                return null;

            if (String.Equals(coffee, "Americano", StringComparison.CurrentCultureIgnoreCase))
                return new Americano();
            else if (String.Equals(coffee, "LatteCoffee", StringComparison.CurrentCultureIgnoreCase))
                return new LatteCoffee();
            else if (String.Equals(coffee, "Cappuccino", StringComparison.CurrentCultureIgnoreCase))
                return new Cappuccino();
            else
                return null;
        }
    }
    public class ShopProducer
    {
        public static AbstractShop  GetShop(string shoptype)
        {
             if (shoptype == null)
                return null;

            if (String.Equals(shoptype, "Bakery", StringComparison.CurrentCultureIgnoreCase))
                return new Bakery();
            else if (String.Equals(shoptype, "Cafe", StringComparison.CurrentCultureIgnoreCase))
                return new Cafe();
            else
                return null;
        }
    }

    public class AbstractFactoryDemo
    {
        public void Demo()
        {
            ShopProducer BakeryShop = ShopProducer.GetShop("Bakery");
            Bread bread1 = BakeryShop.GetBread("Bagel");
            Bread bread2 = BakeryShop.GetBread("Croissant");
            Bread bread3 = BakeryShop.GetBread("Crepe");
            bread1.Description();//I'm a Bagel.
            bread2.Description();//I'm a Croissant.
            bread3.Description();//I'm a Crepe.
            ShopProducer CafeShop = ShopProducer.GetShop("Cafe");
            Coffee coffee1 = CafeShop.GetCoffee("Americano");
            Coffee coffee2 = CafeShop.GetCoffee("LatteCoffee");
            Coffee coffee3 = CafeShop.GetCoffee("Cappuccino");
            coffee1.Description();//I'm a Americano.
            coffee2.Description();//I'm a LatteCoffee.
            coffee3.Description();//I'm a Cappuccino.
        }
    }
}
