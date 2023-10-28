using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //迭代器模式
    //在一個容器內儲存多個物件
    //將儲存或其他的功能與歷訪的功能解耦合
    //也就是說在一個聚合類內有一個內部的類專門去做歷訪
    public interface Iterator
    {
        bool hasNext();
        object NextObj();
    }
    public interface Container
    {
        Iterator GetIterator();
    }
    public class CardStorage : Container
    {
        public string[] Cards = {"N", "R", "SR", "SSR"}
        public Iterator GetIterator()
        {
            return new CardIterator();
        }
        private class CardIterator : Iterator
        {
            int index = 0;
            public bool hasNext()
            {
                return index < Cards.Count();
            }
            public object NextObj()
            {
                return hasNext() ? Cards[index++] : null;
            }
        }
    }
    public class IteratorDemo
    {
        public void Demo()
        {
            CardStorage cardStorage = new CardStorage();
            while(cardStorage.GetIterator().hasNext())
            {
                Console.WriteLn( "This Item : " + cardStorage.GetIterator().NextObj());
            }
        }
    }
}
