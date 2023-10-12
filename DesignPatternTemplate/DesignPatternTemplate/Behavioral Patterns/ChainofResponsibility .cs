using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //責任鏈模式
    //此Model是一個非常常用的模式
    //通常在很多時候我們會根據很多狀況
    //創立一個Handler那在Handler裡面會根據狀況
    //產生多個if else或是switch case
    //如果在未來新增一個新的情況想要加入這個Handler之中
    //勢必會需要修改這個if else那就會發生原有產品被更改的風險
    //也就是會造成擴充不易
    //因此可以使用這個責任鏈模式將所有Handler繼承一個抽象類
    //其核心需要有判斷這件事是不是自己要做的以及下一個要傳給誰
    //以最常見的Logger就是以這個方式做的
    public abstract class Logger 
    {
        static public int ERROR = 1, DEBUG = 2, INFO = 3;
        protected int Level;
        protected Logger nextLogger;
        public void SetNextLogger(Logger nex)
        {
            this.nextLogger = nex;
        }
        protected abstract void write(string text);
        public void record(int lv, string msg)
        {
            if(lv <= this.Level)
            {
                write(msg);
            }
            if(this.nextLogger != null)
            {
                this.nextLogger.record(lv, msg);
            }
        }
    }
    public class ErrorLogger : Logger
    {
        public ErrorLogger(int lv)
        {
            this.Level = lv;
        }
        protected override void write(string text)
        {
            Console.WriteLine("[ErrorLogger]" + text);
        }
    }
    public class DebugLogger : Logger
    {
        public DebugLogger(int lv)
        {
            this.Level = lv;
        }
        protected override void write(string text)
        {
            Console.WriteLine("[DebugLogger]" + text);
        }
    }
    public class InfoLogger : Logger
    {
        public InfoLogger(int lv)
        {
            this.Level = lv;
        }
        protected override void write(string text)
        {
            Console.WriteLine("[InfoLogger]" + text);
        }
    }
    public class CORDemo
    {
        private Logger GetLogger()
        {
            Logger errorlogger = new ErrorLogger(Logger.ERROR);
            Logger debuglogger = new DebugLogger(Logger.DEBUG);
            Logger infologger = new InfoLogger(Logger.INFO);
            errorlogger.SetNextLogger(debuglogger);
            debuglogger.SetNextLogger(infologger);
            return errorlogger;
        }
        public void Demo()
        {
            Logger LoggerManager = GetLogger();
            LoggerManager.record(Logger.ERROR, "Test LV 1.");
            LoggerManager.record(Logger.DEBUG, "Test LV 2.");
            LoggerManager.record(Logger.INFO, "Test LV 3.");
            //[ErrorLogger]Test LV 1.
            //[DebugLogger]Test LV 1.
            //[InfoLogger]Test LV 1.
            
            //[DebugLogger]Test LV 2.
            //[InfoLogger]Test LV 2.

            //[InfoLogger]Test LV 3.
        }
    }
}
