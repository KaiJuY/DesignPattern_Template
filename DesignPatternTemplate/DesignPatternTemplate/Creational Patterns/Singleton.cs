#define Lazy
#define DCL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //單例模式
    //此Model主要是使一個class只有一個instance並且提供他一個全局的訪問點
    //透過建構子private不能隨意創建此class
    //在提供一個GetInstance去進行判斷實例是否已存在決定是否要創建新的實例

#if Lazy
    //此為Singleton的最簡易的實現方式採用Lazy Initialization意旨推遲初始化
    //但問題也顯而易見在多線程的情境之下並不安全
#if Unsynchronized
    public class Singleton
    {
        private static Singleton instance;
        private Singleton(){ }
        public static Singleton GetInstance
        {
            get
            {
                return instance ?? new Singleton();
            }
        }
    }
    //採用lock確保線程安全的作法但不斷的上鎖解鎖的過程會造成性能很差
#elif Synchronized
    public class Singleton
    {
        private static volatile Singleton instance;
        private static object sync = new object();
        private Singleton(){ }
        public static Singleton GetInstance
        {
            get
            {
                lock(sync)
                {
                    return instance ?? new Singleton();
                }
            }
        }
    }
#elif DCL
    //採用double checked lock確保線程安全的作法
    //但不斷的上鎖解鎖的過程會造成性能很差所以在上鎖前先進行第一段檢查
    //假設已經初始化則直接回傳實例
    //如果沒有初始化的話才進行上鎖初始化
    public class Singleton
    {
        private static volatile Singleton instance;
        private static object sync = new object();
        private Singleton(){ }
        public static Singleton GetInstance
        {
            get
            {
                if(instance == null)
                {
                    lock(sync)
                    {
                        return instance ?? new Singleton();
                    }
                }
                return instance;
            }
        }
    }    
#endif
#endif

#if Eager
    //採用初始化時立即初始化物件以確保線程安全
    //但這做法可能會造成浪費內存沒有達到延後初始化
    //容易有產生垃圾物件的情況發生
    public class Singleton
    {
        private static volatile Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetSingleton
        {
            get
            {
                return instance;
            }
        }

    }
#endif
}
