using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //命令模式
    //此模式主要是運用在有調用者命令接收者的情況
    //就像是玩家->技能->角色動作
    //一般來說命令會與角色緊密結合
    //而這種方式可以很有效的解耦合
    public interface SKill
    {
        void execute();
    }
    public class Mana
    {
        int MP = 100;
        public void SpendMP(int mp)
        {
            MP -= mp;
        }
    }
    public class Fireball : SKill
    {
        private Mana mana;
        public Fireball(Mana mp)
        {
            this.mana = mp;
        }
        public void execute()
        {
            if(this.mana > 20)
            {
                Console.WriteLine("Fire Ball Shot success!!!");
                this.mana.SpendMP(20);
            }
            else
                Console.WriteLine("MP didn't enough use Poison.");
        }
    }
    public class Attack : SKill
    {
         private Mana mana;
        public Attack(Mana mp)
        {
            this.mana = mp;
        }
        public void execute()
        {
            Console.WriteLine("Attack success!!!");
        }
    }
    public class Poison : SKill
    {
        private Mana mana;
        public Poison(Mana mp)
        {
            this.mana = mp;
        }
        public void execute()
        {
            if(this.mana > 15)
            {
                Console.WriteLine("Poison success!!!");
                this.mana.SpendMP(15);
            }
            else
                Console.WriteLine("MP didn't enough use Poison.");
        }
    }
    public class UserCommand
    {
        private List<SKill>SkillCombo = new List<SKill>();
        public void SetSkill(SKill sKill)
        {
            SkillCombo.Add(skill);
        }
        public void RemoveSkill(int index)
        {
            if(SkillCombo.Count > index)
            {
                SkillCombo.Remove(index);
            }
        }
        public void UsingSkill()
        {
            foreach(SKill skill in SkillCombo)
            {
                skill.execute();
            }
        }
    }
    public class CommandDemo
    {
        public void Demo()
        {
            Mana Magician_MP = new Mana();
            Fireball fireball = new Fireball(Magician_MP);
            Poison poison = new Poison(Magician_MP);
            Attack attack = new Attack(Magician_MP);
            UserCommand userCommand = new UserCommand();
            userCommand.SetSkill(fireball);
            userCommand.SetSkill(poison);
            userCommand.SetSkill(attack);
            userCommand.RemoveSkill(1);
            userCommand.SetSkill(poison);
            userCommand.UsingSkill();
            //Fire Ball Shot success!!!
            //Attack success!!!
            //Poison success!!!
        }
    }
}
