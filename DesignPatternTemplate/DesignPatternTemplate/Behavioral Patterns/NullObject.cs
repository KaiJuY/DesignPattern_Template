using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //空物件模式
    //這是一個可以減少判斷null的方法
    //經常會與Factory, singleton做結合使用
    //來代替一些default或是null的狀況
    public abstract class TV
    {
        public void ZoomIn();
        public void ZoomOut();
    }
    public class ExpensiveTV : TV
    {
        public override void ZoomIn()
        {
            Console.WriteLn("8x Display");
        }
        public override void ZoomOut()
        {
            Console.WriteLn("0.2x Display");
        }
    }
    public class CheapTV : TV
    {
        public override void ZoomIn()
        {
            Console.WriteLn("2x Display");
        }
        public override void ZoomOut()
        {
            Console.WriteLn("0.5x Display");
        }
    }
    public class NullTV : TV
    {
        public override void ZoomIn()
        {
            //do nothing 
        }
        public override void ZoomOut()
        {
            //do nothing 
        }
        //singleton
        private static TV instance = new NullTV();
        public static TV getInstance()
        {
            return instance;
        }
    }
    public static class TVFacotry
    {
        public static TV GetTV(int price)
        {
            if(price < 5000)
                return new CheapTV();
            else if (price < 10000)
                return new ExpensiveTV();
            else
                return NullTV.getInstance();
                //return null
        }
    }
    public class NullObjectDemo
    {
        public void Demo()
        {
            TV DemoTV = TVFacotry.GetTV(15000);
            //if(DemoTV != null) after using NullTV class we do not need to add this judgement.
            DemoTV.ZoomIn(); //do nothing
            DemoTV.ZoomOut(); //do nothing
        }
    }
}
