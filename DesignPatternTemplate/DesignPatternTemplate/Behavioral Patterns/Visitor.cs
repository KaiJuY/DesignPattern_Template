using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //訪問者模式
    //此Model是一個滿特別的模式
    //有點雙面刃的Model雖然好用但是在架構上可能會影響一些原則
    //運用場域是在假設你有一些已經寫好的物件
    //但是現在被要求擴充一個功能是將物件序列化轉成JSON格式
    //這時候你如果對每個物件都進行修改會造成不穩定性也變得有點不適合寫在原本的物件內
    //因為原本的物件可能有他的職責但轉化成別的格式可能不是他的職責
    //而且今天可能被要求轉JSON明天可能又變成XML
    //所以透過另一個class進行visit並將物件直接傳入
    //再透過這個class去判斷是哪種物件調用不同的overloading function
    public interface Visitor
    {
        public void access(soundbar sb);
        public void access(monitor mon);
        public void access(keyboard kb);
    }
    public class ComputerVisitor : Visitor
    {
        public void access(soundbar sb)
        {
            Console.WriteLine("This SoundBar Brand : {0}, SoundTrack : {1}, PowerAMP : {2}", sb.brand, sb.soundtrack, sb.poweramp);
        }
        public void access(monitor mon)
        {
            Console.WriteLine("This Monitor Brand : {0}, DisplaySize : {1}, Update Frequency : {2}", mon.brand, mon.displaysize, mon.update_fre);
        }
        public void access(keyboard kb)
        {
            Console.WriteLine("This KeyBoard Brand : {0}, Switch Type : {1}, Wireless : {2}", kb.brand, kb.switchtype, kb.wireless);
        }
    }
    public interface ComputerFittings
    {
        public void accept(ComputerVisitor cv);
    }
    public class soundbar : ComputerFittings
    {
        public soundbar(string b, double st, int pa)
        {
            brand = b;
            soundtrack = st;
            poweramp = pa;
        }
        public string brand {get; set;}
        public double soundtrack {get; set;}
        public int poweramp{get; set;}
        public void accept(ComputerVisitor cv)
        {
            cv.access(this);
        }

    }
    public class monitor : ComputerFittings
    {
        public monitor(string b, int ds, double uf)
        {
            brand = b;
            displaysize = ds;
            update_fre = uf;
        }
        public string brand {get; set;}
        public int displaysize {get; set;}
        public double update_fre {get; set;}
        public void accept(ComputerVisitor cv)
        {
            cv.access(this);
        }
    }
    public class keyboard : ComputerFittings
    {
        public keyboard(string b, string st, bool wl)
        {
            brand = b;
            switchtype = st;
            wireless = wl;
        }
        public string brand {get; set;}
        public string switchtype {get; set;}
        public bool wireless {get; set;}
        public void accept(ComputerVisitor cv)
        {
            cv.access(this);
        }
    }
    public class VisitorDemo
    {
        public void demo()
        {
            soundbar BOSE_Soundbar = new soundbar("BOSE", 5.1, 20);
            monitor SAMSUNG_Monitor = new monitor("SAMSUNG", 32, 120);
            keyboard RAZER_Keyboard = new keyboard("RAZER", "Green", true);
            BOSE_Soundbar.accept(new ComputerVisitor());
            //This SoundBar Brand : BOSE, SoundTrack : 5.1, PowerAMP : 20
            SAMSUNG_Monitor.accept(new ComputerVisitor());
            //This Monitor Brand : SAMSUNG, DisplaySize : 32, Update Frequency : 120
            RAZER_Keyboard.accept(new ComputerVisitor());
            //This KeyBoard Brand : RAZER, Switch Type : Green, Wireless : true
        }
    }
}
