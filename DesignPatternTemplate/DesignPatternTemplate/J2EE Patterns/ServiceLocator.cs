using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //服務定位器模式
    //運用場景是在你需要提供服務時
    //有可能會運用到重覆的服務
    //但每次都重新載入會較花時間
    //所以可以先將服務存在暫存區
    //透過定位器去取得服務即可

   public interface Service
   {
        public void getName();
        public void execute();
   }
   public class Service1 : Service
   {
        public override void getName()
        {
            Console.WriteLn("This is Serveice 1");
        }
        public override void execute()
        {
            Console.WriteLn("Do Service 1");
        }
   }
   public class Service2 : Service
   {
        public override void getName()
        {
            Console.WriteLn("This is Serveice 2");
        }
        public override void execute()
        {
            Console.WriteLn("Do Service 2");
        }
   }
   public class InitialContent
   {
        public Service lookup(string servicename)
        {
            if(servicename == "Service1")
                return new Service1();
            else if(servicename == "Service2")
                return new Service2();
            return null;
        }
   }
   public class ServiceCache
   {
        private List<Service>Services;
        public ServiceCache()
        {
            Services = new List<Service>();
        }
        public Service GetService(string servicename)
        {
            foreach(Service service in Services)
            {
                if(servicename == service.getName())
                    return service;
            }
            return null;
        }
        public void AddService(Service service)
        {
            foreach(Service s in Services)
            {
                if(service.getName() == s.getName())
                    return;
            }
            Services.Add(service);
            return;
        }
   }
   public class Locator
   {
        private static ServiceCache serviceCache = new ServiceCache();
        public static Service getService(string servicename)
        {
            Service service = serviceCache.GetService(service);
            if(service == null) 
            {
                Console.WriteLn("Cache not found, Initial new Content.");
                InitialContent initialContent = new InitialContent();
                service = initialContent.lookup(service);
                serviceCache.AddService(service);
            }
            return service;
        }
   }
   public class ServeiceLocatorDemo
   {
        public void Demo()
        {
            Locator.getService("Service1");
            Locator.getService("Service2");
            Locator.getService("Service1");
            Locator.getService("Service2");
            //Cache not found, Initial new Content.
            //Do Service 1
            //Cache not found, Initial new Content.
            //Do Service 2
            //Do Service 1
            //Do Service 2
        }
   }
}
