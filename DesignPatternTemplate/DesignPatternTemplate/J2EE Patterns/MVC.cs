using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //MVC模式
    //Model View Control模式
    //顧名思義就是分為三大塊
    //將某個實例帶有設定狀態或行為的功能的類
    //顯示狀態的類
    //控制兩者的類
    public class Charactor
    {
        private string name;
        private string state;
        public string getname()
        {
            return this.name;
        }
        public string getstate()
        {
            return this.state;
        }
        public void setname(string n)
        {
            this.name = n;
        }
        public void setstate(string s)
        {
            this.state = s;
        }
    }
    public class CharactorView
    {
        public void showCharactorDetail(string name, string state)
        {
            Console.WriteLn("Charactor : ");
            Console.WriteLn("Name : " + name);
            Console.WriteLn("State : " + state);
        }
    }
    public class CharactorController
    {
        private Charactor charactor;
        private CharactorView charactorView;
        public CharactorController(Charactor ch, CharactorView cv)
        {
            this.charactor = ch;
            this.charactorView = cv;
        }
        public void setName(string name)
        {
            charactor.setname(name);
        }
        public string getname()
        {
            return charactor.getname();
        }
        public void setState(string state)
        {
            charactor.getstate(state);
        }
        public string getState()
        {
            return charactor.getstate();
        }
        public void updatecharactor()
        {
            charactorView.showCharactorDetail(charactor.getname(), charactor.getstate());
        }
    }
    public class MVCDemo
    {
        public void Demo()
        {
            Charactor player = GetCharactorFromDB();
            CharactorView charactorView = new CharactorView();
            CharactorController charactorController = new CharactorController(player, charactorView);
            charactorController.updatecharactor();
            //Charactor :
            //Name : Twitch
            //State : idle
            charactorController.setState("fight");
            charactorController.updatecharactor();
            //Charactor :
            //Name : Twitch
            //State : fight
        }
        private Charactor GetCharactorFromDB()
        {
            Charactor charactor = new Charactor();
            charactor.setname("Twitch");
            charactor.setstate("idle");
            return charactor;
        }
    }
    
}
