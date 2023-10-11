using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //代理模式
    //很常與Adaptor和Decorator搞混
    //Adaptor是較常用在舊系統新需求時創造新接口使用
    //Decorator是較常用在增加新的功能在原有的類別上
    //而Proxy是為了避免重複載入等動作浪費資源可能
    //因此會使用代理器將先前載入過的資料保存在裡頭
    //下次要重複使用時可以直接將資料傳出利用不用重新加載
    //應該可以建立實例在會重複運用到相同資料的兩個類別外就可以實現互通節省Loading的作用

    public interface image
    {
        public void display();
    }

    public class Image_loader : image
    {
        private string URL;
        public Image_loader(string url)
        {
            this.URL = url;
            load();
        }
        private void load()
        {
            Console.WriteLine("Loading image from server. URL is " + this.URL);
        }
        public override void display()
        {
            Console.WriteLine("Loading image");
        }
    }
    public class Proxy_Img_loader : image
    {
        private Image_loader image_Loader;
        private string URL;
        public Proxy_Img_loader(string url)
        {
            this.URL = url;
        }
        public override void display()
        {
            if(image_Loader == null)
            {
                image_Loader = new Image_loader(this.URL);
            }
            image_Loader.display();
        }
    }
    public class ProxyDemo
    {
        public void Demo()
        {
            image img = new Proxy_Img_loader("www.img.com/1.jpg");
            img.display();//load first time
            img.display();//no need to load second time.
        }
    }
}
