using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //橋接模式
    //主要概念是將抽象跟實現分離
    //假設我想要提供多種支付方式
    //那付款這個動作可以變得抽象
    //在真正要用的時候才實現
    //那添加新方法也就很容易
    public interface Payment
    {
        void ProcessPay();
    }
    public class ApplePay : Payment
    {
        public void ProcessPay()
        {
            Console.WriteLine("Using Apple Pay.");
        }
    }
    public class LinePay : Payment
    {
        public void ProcessPay()
        {
            Console.WriteLine("Using Line Pay.");
        }
    }
    public class CreditPay : Payment
    {
        public void ProcessPay()
        {
            Console.WriteLine("Using Credit Pay.");
        }
    }
    public abstract class Product
    {
        protected Payment payment;
        public Product(Payment pay)
        {
            this.Payment = pay;
        }
        public abstract void purchase();
    }
    public class Book : Product
    {
        public Book (Payment pay)
        {
            this.payment = pay;
        }
        public override void purchase()
        {
            this.payment.ProcessPay();
            Console.WriteLine("Book Purchased.");
        }
    }
    public class Phone : Product
    {
        public Phone (Payment pay)
        {
            this.payment = pay;
        }
        public override void purchase()
        {
            this.payment.ProcessPay();
            Console.WriteLine("Phone Purchased.");
        }
    }
    public class BridgeDemo
    {
        public void Demo()
        {
            Book book_A = new Book( new ApplePay());
            Book book_B = new Book( new LinePay());
            Phone phone_A = new Phone( new CreditPay());
            //如果我想新增一個支付方式直接新增即可套用在所有Product上或是新增一個Product也可以套用所有支付方式

        }
    }
}
