using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //過濾器模式
    //透過建立標準的類別針對某個族群進行過濾
    //有點像是實現了DB的Query的方法

    public class Laptop
    {
        private string CPU;
        private int ScreenSize;
        private string OS;
        public Laptop(string cpu, int screensize, string os)
        {
            this.CPU = cpu;
            this.ScreenSize = screensize;
            this.OS = os;
        }
        public string getCPU()
        {
            return this.CPU;
        }
        public int getScreenSize()
        {
            return this.ScreenSize;
        }
        public string getOS()
        {
            return this.OS;
        }
    }
    public interface Criteria
    {
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst);
    }
    public class Criteria_OS : Criteria
    {
        string Os;
        public Criteria_OS(string os)
        {
            this.Os = os;
        }
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst)
        {
            List<Laptop>meet_Lst = new List<Laptop>();
            foreach(var laptop in laptop_lst)
            {
                if(laptop.getOS().equals(this.Os, StringComparison.OrdinalIgnoreCase))
                    meet_Lst.Add(laptop);
            }
            return meet_Lst;
        }
    }
    public class Criteria_ScreenSize : Criteria
    {
        int ScreenSize;
        public Criteria_ScreenSize(int size)
        {
            this.ScreenSize = size;
        }
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst)
        {
            List<Laptop>meet_Lst = new List<Laptop>();
            foreach(var laptop in laptop_lst)
            {
                if(laptop.getScreenSize() == this.ScreenSize)
                    meet_Lst.Add(laptop);
            }
            return meet_Lst;
        }
    }
    public class Criteria_CPU : Criteria
    {
        string CPU;
        public Criteria_CPU(string cpu)
        {
            this.CPU = cpu;
        }
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst)
        {
            List<Laptop>meet_Lst = new List<Laptop>();
            foreach(var laptop in laptop_lst)
            {
                if(laptop.getCPU().equals(this.CPU, StringComparison.OrdinalIgnoreCase))
                    meet_Lst.Add(laptop);
            }
            return meet_Lst;
        }
    }
    public class AndCriterial : Criteria
    {
        private List<Criteria> Criterial_Lst;
        public AndCriterial(List<Criteria> criterial_lst)
        {
            Criterial_Lst = new List<Criteria>(criterial_lst);
        }
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst)
        {
            List<Laptop>meet_Lst = new List<Laptop>(laptop_lst);
            foreach(var criterial in Criterial_Lst)
            {
                meet_Lst = criterial.meetCriterial(meet_Lst);
            }
            return meet_Lst;
        }
    }
    public class OrCriterial : Criteria
    {
        private List<Criteria> Criterial_Lst;
        public OrCriterial(List<Criteria> criterial_lst)
        {
            Criterial_Lst = new List<Criteria>(criterial_lst);
        }
        public List<Laptop>meetCriterial(List<Laptop> laptop_lst)
        {
            List<Laptop>meet_Lst = new List<Laptop>();
            foreach(var criterial in Criterial_Lst)
            {
                List<Laptop>current_meet_Lst = criterial.meetCriterial(laptop_lst);
                foreach(var c_m in current_meet_Lst)
                {
                    if(!meet_Lst.Contains(c_m))
                        meet_Lst.Add(c_m);
                }
            }
            return meet_Lst;
        }
    }
    public class CriteriaDemo
    {
        public void demo()
        {
            List<Laptop> Laptop_Lst = new List<Laptop>();
            Laptop_Lst.Add(new Laptop ("Intel", 17, "Windows"));
            Laptop_Lst.Add(new Laptop ("Intel", 18, "Windows"));
            Laptop_Lst.Add(new Laptop ("M4", 15, "Linux"));
            Laptop_Lst.Add(new Laptop ("ARM64", 16, "CENTOS"));
            Criteria Intel_Cri = new Criteria_CPU("Intel"); // 2 item : "Intel", 17, "Windows", "Intel", 18, "Windows"
            Criteria M4_Cri = new Criteria_CPU("M4");// 1 item : "M4", 15, "Linux"
            Criteria ARM64_Cri = new Criteria_CPU("ARM64");// 1 item : ARM64", 16, "CENTOS"
            Criteria S15_Cri = new Criteria_ScreenSize(15);// 1 item : "M4", 15, "Linux"
            Criteria S16_Cri = new Criteria_ScreenSize(16);// 1 item : "Intel", 17, "Windows"
            Criteria S17_Cri = new Criteria_ScreenSize(17);// 1 item : "ARM64", 16, "CENTOS"
            Criteria Windows_Cri = new Criteria_OS("Windows");// 1 item : "Intel", 17, "Windows"
            Criteria Linux_Cri = new Criteria_OS("Linux");// 1 item : "M4", 15, "Linux"
            Criteria CENTOS_Cri = new Criteria_OS("CENTOS");// 1 item : ARM64", 16, "CENTOS"
            AndCriterial andCriterial = new AndCriterial(new List<Criteria>(){Intel_Cri, S17_Cri});// 1 item : "Intel", 17, "Windows"
            OrCriterial orCriterial = new OrCriterial(new List<Criteria>(){S15_Cri, S16_Cri});// 2 item : "M4", 15, "Linux", "ARM64", 16, "CENTOS"
        }
    }
}
