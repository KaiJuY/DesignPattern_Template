using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //組合模式
    //我有多個物件會希望可以透過一個List訪問
    //因此我創造了一個新物件可以存放多個這個物件
    //而我又希望聚合物件可以管理所有的子物件以及聚合物件
    //因此將依賴改為接口這樣可以使這個物件可以容納其他的聚合物件
    //就能夠對使用的人更方便
    public interface IBattery
    {
        public void ShowBattery();
    }
    public class Battery : IBattery
    {
        public int Capability {get; set;}
        public int Weight {get; set;}
        public int RecycleTime {get; set;}
        public Battery(int cap, int wei, int time)
        {
            this.Capability = cap;
            this.Weight = wei;
            this.RecycleTime = time;
        }
        public void ShowBattery()
        {
            Console.WriteLn("Capability : " + this.Capability.ToString() + " Weight : " + this.Weight.ToString() +" RecycleTime : " + this.RecycleTime.ToString());
        }
    }
    public class CompositeBattery : IBattery
    {
        private List<IBattery> _BatteryList = new List<IBattery>();
        public void Add(IBattery battery)
        {
            _BatteryList.Add(battery);
        }
        public void ShowBattery()
        {
            foreach(var b in _BatteryList)
            {
                b.ShowBattery();
            }
        }
    }
   public class CompositeDemo
   {
    public void Demo()
    {
        Battery no1 = new Battery(150, 100, 300);
        Battery no2 = new Battery(120, 100, 200);
        Battery no3 = new Battery(50, 30, 100);
        Battery no4 = new Battery(10, 5, 10);
        CompositeBattery compositeBattery = new CompositeBattery();
        compositeBattery.Add(no1);
        compositeBattery.Add(no2);
        CompositeBattery compositeBattery2 = new CompositeBattery();
        compositeBattery2.Add(no3);
        compositeBattery2.Add(no4);
        compositeBattery2.Add(compositeBattery);//if didn't using interface will get wrong
        compositeBattery2.ShowBattery();
        //no3
        //no4
        //no1
        //no2
    }
   }
}
