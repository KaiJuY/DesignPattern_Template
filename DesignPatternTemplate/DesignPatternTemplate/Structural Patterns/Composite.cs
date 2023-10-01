using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //組合模式
    //此模式優點是初始化的類與其他的Group相同
    //這樣就可以讓所有Group的都有相同的Field
    //但有個缺點無法依賴反轉因為都是直接使用class
    
    public class CivilServant
    {
        private string Name;
        private string Position;
        private int Sarlary;
        private List<CivilServant> Subordinates;
        public CivilServant(string name, string pos, int sal)
        {
            this.Name = name;
            this.Position = pos;
            this.Sarlary = sal;
            this.Subordinates = new List<CivilServant>();
        }
        public void add(CivilServant cs)
        {
            this.Subordinates.Add(cs);
        }
        public void remove(CivilServant cs)
        {
            this.Subordinates.Remove(cs);
        }
        public List<CivilServant> GetSubordinates()
        {
            return this.Subordinates;
        }
        public void GetPersonalInfo()
        {
            Console.WriteLine( "Name : " + this.Name + " Position : " + this.Position + " Salary : " + this.Sarlary.ToString());
        }
    }

    public class CompositeDemo
    {
        public void Demo()
        {
            CivilServant President = new CivilServant("Kumi", "President", 100000);
            CivilServant VicePresident = new CivilServant("Kuma", "VicePresident", 50000);
            CivilServant Premier = new CivilServant("Kumo", "Premier", 30000);
            CivilServant VicePremier = new CivilServant("Kumas", "VicePremier", 20000);
            CivilServant Ministerwithoutortfolio_i  = new CivilServant("Kumis", "Ministerwithoutortfolio", 10000);
            CivilServant Ministerwithoutortfolio_j = new CivilServant("Kumos", "Ministerwithoutortfolio", 10000);
            President.add(VicePresident);
            VicePresident.add(Premier);
            Premier.add(VicePremier);
            VicePremier.add(Ministerwithoutortfolio_i);
            VicePremier.add(Ministerwithoutortfolio_j);

            President.GetPersonalInfo(); 
            foreach(CivilServant f in President.GetSubordinates())
            {
                f.GetPersonalInfo();
                foreach(CivilServant s in f.GetSubordinates())
                {
                    s.GetPersonalInfo();
                    foreach(CivilServant t in s.GetSubordinates())
                    {
                        t.GetPersonalInfo();
                    }
                }
            }
            //Name :  Kumi  Position : President Salary : 100000
            //Name :  Kuma  Position : VicePresident Salary : 50000
            //Name :  Kumo  Position : Premier Salary : 30000
            //Name :  Kumas  Position : VicePremier Salary : 20000
            //Name :  Kumis  Position : Ministerwithoutortfolio Salary : 10000
            //Name :  Kumos  Position : Ministerwithoutortfolio Salary : 10000
        }
    }
}
