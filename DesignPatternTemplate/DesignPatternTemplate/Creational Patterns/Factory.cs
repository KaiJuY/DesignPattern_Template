using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //工廠模式
    //這個Model主要是希望透過一個像工廠的概念
    //經由工廠可以依照不同的生產配方產生出不同的商品
    //以下會使用希望生產不同種類的麵包只需要透過麵包店即可
    //首先建立基本麵包的介面繼承這個類別創立新的麵包
    //最後創建一個麵包店並根據不同的參數可以取得不同的麵包
    //因為這個麵包是介面所以真正實現的是繼承他的這些麵包
    //因此在創立的時候會傭有他們的特性

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
    public class Bakery
    {
        public Bread GetBread(string breadtype)
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

    public class FactoryDemo
    {
        public void Demo()
        {
            Bakery bakery = new Bakery();
            Bread bread1 = bakery.GetBread("Bagel");
            Bread bread2 = bakery.GetBread("Croissant");
            Bread bread3 = bakery.GetBread("Crepe");
            bread1.Description();//I'm a Bagel.
            bread2.Description();//I'm a Croissant.
            bread3.Description();//I'm a Crepe.
        }
    }
}
