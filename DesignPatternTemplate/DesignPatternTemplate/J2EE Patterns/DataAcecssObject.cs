using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //DAO模式
    //將訪問數據的較底層的部分隔離出來
    //這樣上層邏輯就不需要去操作到底層的邏輯
    //例如訪問DB需要與DB連線知道各式各樣的資訊
    //但在操作物件的人不希望知道這些細節
    public class Charactor
    {
        private int ID;
        private string name;
        private string state;
        public Charactor(int id, string name, string state)
        {
            this.ID = id;
            this.name = name;
            this.state = state;
        }
        public string getname()
        {
            return this.name;
        }
        public string getstate()
        {
            return this.state;
        }
        public int getID()
        {
            return this.ID;
        }
        public void setname(string n)
        {
            this.name = n;
        }
        public void setstate(string s)
        {
            this.state = s;
        }
        public bool compare(int id)
        {
            return this.ID == id;
        }
    }
    public interface CharactorDao
    {
        public List<Charactor> getAllCharactor();
        public Charactor GetCharactor(int id);
        public void updateCharactor(Charactor charactor);
        public void deleteCharactor(Charactor charactor);
    }
    public class CharactorDaoImp : CharactorDao
    {
        private List<Charactor> CharactorDB;
        public CharactorDaoImp()
        {
            CharactorDB = new List<Charactor>();
            Charactor charactor1 = new Charactor(1, "Terry", "idle");
            Charactor charactor2 = new Charactor(8, "Ahri", "Busy");
            CharactorDB.Add(charactor1);
            CharactorDB.Add(charactor2);
        }
        public override List<Charactor> getAllCharactor()
        {
            return CharactorDB;
        }
        public override Charactor GetCharactor(int id)
        {
            for(int i = 0; i < CharactorDB.Count; ++i)
            {
                if(CharactorDB[i].compare(id))
                    return CharactorDB[i];
            }
            return null;
        }
        public override void updateCharactor(Charactor charactor)
        {
            for(int i = 0; i < CharactorDB.Count; ++i)
            {
                if(CharactorDB[i].compare(charactor.getID()))
                {
                    CharactorDB[i] = charactor;
                    return;
                }
            }
            return;
        }
        public override Charactor deleteCharactor(Charactor charactor)
        {
            int i = 0;
            bool find = false;
            for(i = 0; i < CharactorDB.Count; ++i)
            {
                if(CharactorDB[i].compare(charactor.getID()))
                {
                    find = true;
                    break;
                }
            }
            if(find) CharactorDB.remove(i);
            return;
        }

    }
    public class DaoDemo
    {
        public void Demo()
        {
            CharactorDaoImp charactorDaoImp = new CharactorDaoImp();
            List<Charactor> ListC =  charactorDaoImp.getAllCharactor();
            foreach(Charactor c in ListC)
            {
                Console.WriteLn(c.getID(), " : Name is ",c.getname());
            }
            // 1 : Name is Terry
            // 8 : Name is Ahri
            Charactor ch = charactorDaoImp.GetCharactor(8);
            ch.setstate("Jump");
            charactorDaoImp.updateCharactor(ch);
            Console.WriteLn("Check State : ", charactorDaoImp.GetCharactor(8).getstate());
            //Check State : Jump
            ch = charactorDaoImp.GetCharactor(1);
            charactorDaoImp.deleteCharactor(ch);
            List<Charactor> ListC =  charactorDaoImp.getAllCharactor();
            foreach(Charactor c in ListC)
            {
                Console.WriteLn(c.getID(), " : Name is ",c.getname());
            }
            // 8 : Name is Ahri
        }
    }
    
}
