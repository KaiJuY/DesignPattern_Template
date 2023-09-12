using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //工廠模式
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
            bread1.Description();
            bread2.Description();
            bread3.Description();
        }
    }
}
