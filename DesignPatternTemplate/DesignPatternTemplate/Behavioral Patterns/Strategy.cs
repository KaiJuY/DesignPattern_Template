using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //策略模式
    //此Model主要是注重在行為上或方法上的
    //假設有一種共同行為是所有類別都需要的
    //但是可能會根據這個類別的不同又會有不同的變化
    //跟工廠模式最大的差別是一個是注重在創立實例一個是注重在方法上
    public abstract class CalculateAmount
    {
        public abstract void SetBill(int bill);
        public abstract void doCalculate();
    }
    public class SilverMember : CalculateAmount
    {
        public SilverMember(int pay)
        {
            SetBill(pay);
        }
        private int Bill { get; set; }
        public override void SetBill(int bill)
        {
            Bill = bill;
        }
        public override void doCalculate()
        {
            Console.WriteLine("Bill : {0}", Bill);
        }
    }
    public class GoldMember : CalculateAmount
    {
        public GoldMember(int pay)
        {
            SetBill(pay);
        }
        private int Bill { get; set; }
        public override void SetBill(int bill)
        {
            Bill = bill;
        }
        public override void doCalculate()
        {
            Console.WriteLine("Bill : {0}", Bill*0.9);
        }
    }
    public class MasterMember : CalculateAmount
    {
        public MasterMember(int pay)
        {
            SetBill(pay);
        }
        private int Bill { get; set; }
        public override void SetBill(int bill)
        {
            Bill = bill;
        }
        public override void doCalculate()
        {
            Console.WriteLine("Bill : {0}", Bill * 0.7);
        }
    }

    public class CaculateManager
    {
        private CalculateAmount calculateAmount;
        public CaculateManager(CalculateAmount calculateamount)
        {
            calculateAmount = calculateamount;
        }
        public void executeCaculate()
        {
            calculateAmount.doCalculate();
        }
    }

    public class StrategyDemo
    {
        public void Demo()
        {
            CaculateManager member1 = new CaculateManager(new SilverMember(100));
            CaculateManager member2 = new CaculateManager(new GoldMember(200));
            CaculateManager member3 = new CaculateManager(new MasterMember(300));
            member1.executeCaculate(); //100
            member2.executeCaculate(); //180
            member3.executeCaculate(); //210
        }
    }
}
