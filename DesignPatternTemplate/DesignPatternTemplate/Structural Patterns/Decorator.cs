using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //裝飾器模式
    //這個Pattern主要是用來動態增加原有的Class的功能
    //可以透過繼承欲裝飾類別添加一層屬性並在實現時賦予各種不同的形態
    //就像是黏土可以捏成各種東西但終究就是個黏土
    
    public interface Dough
    {
        void Description();
    }
    public class Noodle : Dough
    {
        public override void Description()
        {
            Console.WriteLine("It looks like noodle.");
        }
    }
    public class Dumpling : Dough
    {
        public override void Description()
        {
            Console.WriteLine("It looks like dumpling.");
        }
    }
    public abstract class Decorator_Dough : Dough
    {
        protected Dough dough;
        public Decorator_Dough(Dough dou)
        {
            this.dough = dou;
        }
        public override void Description()
        {
           dough.Description();
        }
    }
    public class TomatoDecorator_Dough : Decorator_Dough
    {
        public TomatoDecorator_Dough(Decorator_Dough decorator_Dough)
        {
            base(decorator_Dough);
        }
        public override void Description()
        {
           dough.Description();
           New_Favor(decorator_Dough);
        }
        public void New_Favor(Decorator_Dough decorator_Dough)
        {
            Console.WriteLine("Its Tomato Favor");
        }
    }
    public class Decorator_Demo
    {
        public void Demo()
        {
            Dough Pasta = new Noodle();
            Decorator_Dough RedSoucePasta = new TomatoDecorator_Dough(Pasta);
            Pasta.Description(); //It looks like noodle.
            RedSoucePasta.Description();//It looks like noodle.Its Tomato Favor
        }
    }
}
