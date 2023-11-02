using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //模板模式
    //在某一個類型的行為中
    //勢必會有某些固定的流程
    //這時候可以把這些流程作為模板
    //套用到相似的流程內
    //例如生產過程會經歷 檢查=>執行=>結果
    //就可以將流程加入模板模式中
    //而在不同的生產流程就可以套入這個模板
    //僅需要實例各自的檢查、執行、結果就可以
   public abstract class Process
   {
        public abstract void PreCheck();
        public abstract void Execute();
        public abstract void Result();
        public sealed void Produce()
        {
            PreCheck();
            Execute();
            Result();
        } 
   }
   public class MilkProcess : Process
   {
        public override void PreCheck()
        {
            Console.WriteLn("PreCheck for milk item.");
        }
        public override void Execute()
        {
            Console.WriteLn("Execute for milk item.");
        }
        public override void Result()
        {
            Console.WriteLn("Result for milk item.");
        }
    }
    public class CoCoProcess : Process
   {
        public override void PreCheck()
        {
            Console.WriteLn("PreCheck for coco item.");
        }
        public override void Execute()
        {
            Console.WriteLn("Execute for coco item.");
        }
        public override void Result()
        {
            Console.WriteLn("Result for coco item.");
        }
    }
    public class TemplateDemo
    {
        public void Demo()
        {
            MilkProcess milkProcess = new MilkProcess();
            CoCoProcess coCoProcess = new CoCoProcess();   
            milkProcess.Produce();
            coCoProcess.Produce();
            //PreCheck for milk item.
            //Execute for milk item.
            //Result for milk item.
            //PreCheck for coco item.
            //Execute for coco item.
            //Result for coco item.
        }
    }

}
