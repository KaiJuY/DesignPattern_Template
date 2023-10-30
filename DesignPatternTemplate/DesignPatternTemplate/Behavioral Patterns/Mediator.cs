using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //中介者模式
    //這個模式很適合用在多個類會互相耦合的情況
    //當類與類之間有多個關聯的關係時式互相交互是非常混亂的
    //透過一個中介者進行讓實例的類中對各個需要交互的部分進行協調
    //就如下舉例假設有多個人想要互相通知訊息聯絡
    //同時有多個人會產生網狀的交互模式
    //這時候透過一個聊天室讓類與類間不要互相交互
    //而是透過聊天室去處理通知其他人的這件事就完成解耦合
    public class ChatRoom
    {
        public static void ShowMessage(User user, string msg)
        {
            Console.WriteLn("User - " + user.getName() + " Say : " + msg);
        }
    }
    public class User
    {
        public string Name;
        public User(string name)
        {
            this.Name = name;
        }
        public void setName(string name)
        {
            this.Name = nanme;
        }
        public string getName()
        {
            return this.Name;
        }
        public void SendMsg(string msg)
        {
            ChatRoom.ShowMessage(this, msg);
        }
    }
    public class MediatorDemo
    {
        public void Demo()
        {
            User A = new User("Bob");
            User B = new User("Ray");
            A.SendMsg("Hi is anyone here?");
            B.SendMsg("Im Here.");
            //ChatRoom will show : 
            //User - Bob Say : Hi is anyone here?
            //User - Ray Say : Im Here.
        }
    }
}
