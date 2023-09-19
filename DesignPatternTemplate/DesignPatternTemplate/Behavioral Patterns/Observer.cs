using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //觀察者模式
    //此Model主要是類似於Publish & Subscribe
    //針對觀察者與被觀察者的耦合行為
    //主要的邏輯是Subject提供添加觀察者名單、並在更新時通知所有觀察者
    //觀察者在實例創建時去呼叫Subject的添加完成註冊並同時提供接收的行為
    public class Subject
    {
        private List<Observer> Observers = new List<Observer>();
        private int State;
        public int GetState()
        {
            return State;
        }
        public void SetState(int state)
        {
            State = state;
            notifyAllObserver();
        }
        public void attach(Observer observer)
        {
            Observers.add(observer);
        }
        public void notifyAllObserver()
        {
            foreach(var observer in Observers)
            {
                observer.Update();
            }
        }
    }
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }
    public class TenObserver
    {
        public TenObserver(Subject sub)
        {
            subject = sub;
            subject.attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Original Subject State : {0}, in TenObserver become : {1}", subject.GetState(), 10*subject.GetState());
        }
    }
        public class FiveObserver
    {
        public FiveObserver(Subject sub)
        {
            subject = sub;
            subject.attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Original Subject State : {0}, in FiveObserver become : {1}", subject.GetState(), 5*subject.GetState());
        }
    }
    public class ObserverDemo
    {
        public void Demo()
        {
            Subject subject = new Subject();
            TenObserver tenObserver = new TenObserver(subject);
            FiveObserver tenObserver = new FiveObserver(subject);
            subject.SetState(15);
            //Original Subject State : 15, in TenObserver become : 150
            //Original Subject State : 15, in FiveObserver become : 75
            subject.SetState(10);
            //Original Subject State : 10, in TenObserver become : 100
            //Original Subject State : 10, in FiveObserver become : 50
        }
    }
}
