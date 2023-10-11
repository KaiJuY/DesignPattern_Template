using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //享元模式
    //與Prototype相似都是為了減少創建類別所造成的消耗
    //但實現方法有些不同Prototype是在減少不斷IO造成的消耗
    //所以將原型存在HashTable中使要創建實例時進行參照
    //Flyweight是將不同類型的實例存在Hashtable中
    //並在有需要使用到相同實例時共用著這個物件
    //就像是我在一個公園裡要創立很多棵不同種類的樹
    //我可以先將種類當成HashMap中的Key在要創建時直接使用這個實例

    public interface ParkObj
    {
        public void Detail();
    }
   public class Tree : ParkObj
   {
    private string Type;
    private int loc_x;
    private int loc_y;
    private int height;
    public Tree(string type)
    {
        this.Type = type;
    }
    public void set(int x, int y, int h)
    {
        this.loc_x = x;
        this.loc_y = y;
        this.height = h;
    }
    public override void Detail()
    {
        Console.WriteLine("This is a " + this.Type + " tree.");
        Console.WriteLine("Location is on [" + this.loc_x + ", " + this.loc_y + "]. Height is " + this.height + " meter");
    }
   }
   public class TreeMaker
   {
    private static Dictionary<string, Tree> TreeMap = new Dictionary<string, Tree>();
    public static Tree getTree(string type)
    {
        Tree TheTree;
        if(!TreeMap.ContainsKey(type))
        {
            TreeMap.Add(ytpe, new Tree(type));
            Console.WriteLine("Insert a new type Tree in Map : " + type);
        }
        TheTree = TreeMap[type];
        return TheTree
    }
   }
   public class FlyWeightDemo
   {
    private List<string>Trees = {"Oak", "Maple", "Pine"};
    public void Demo()
    {
        Random rnd = new Random();
        for(int i = 0; i <20; ++i)
        {
            Tree CreateTree = TreeMaker.getTree(Trees[i%3]);
            CreateTree.set(rnd.Next(0,100), rnd.Next(0,100), rnd.Next(0,50));
            CreateTree.Detail();
            //"Insert a new type Tree in Map : Oak"
            //"This is a Oak tree."
            //"Location is on [random_x, random_y]. Height is random_h meter"
            //"Insert a new type Tree in Map : Maple"
            //"This is a Maple tree."
            //"Location is on [random_x, random_y]. Height is random_h meter"
            //"Insert a new type Tree in Map : Pine"
            //"This is a Pine tree."
            //"Location is on [random_x, random_y]. Height is random_h meter"
        }
    }
   }
}
