using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //備忘錄模式
    //這個就是一個鼎鼎大名的CTRL+Z
    //可以針對希望儲存的類或Field進行設計
    //例如遊戲存檔、瀏覽器的上一頁等等
    //首先這架構基本會有3個類 : Memento(紀錄類), Originator(可以創造Memento的類), CareTask(保存Memento的類)

    public class Memento //可以視情況做成內部類
    {
        private string State;
        public Memento(string s)
        {
            this.State = s;
        }
        public string getState()
        {
            return this.State;
        }
    }
    public class StateMachine
    {
        private string State;
        public void setState(string s)
        {
            this.State = s;
        }
        public string getState()
        {
            return this.State;
        }
        public Memento ExportStateMemento()
        {
            return new Memento(State);
        }
        public void FatchStateMemento(Memento memento)
        {
            this.State = memento.getState();
        }
    }
    public class CareTask
    {
        private List<Memento> Memento_List = new List<Memento>();
        public void Save(Memento memento)
        {
            Memento_List.Add(memento);
        }
        public Memento Get(int index)
        {
                return index <= Memento_List.Count ? Memento_List[index] : null;
        }
    }
    public class MementoDemo
    {
        public void Demo()
        {
            CareTask careTask = new CareTask();
            StateMachine stateMachine = new StateMachine();
            stateMachine.setState("State:1");
            careTask.Save(stateMachine.ExportStateMemento());
            stateMachine.setState("State:2");
            careTask.Save(stateMachine.ExportStateMemento());
            stateMachine.setState("State:3");
            careTask.Save(stateMachine.ExportStateMemento());
            stateMachine.setState("State:4");
            careTask.Save(stateMachine.ExportStateMemento());
            Console.WriteLn("CurrentState: " + stateMachine.getState()); //CurrentState: State:4
            stateMachine.FatchStateMemento(careTask.Get(0));
            Console.WriteLn("index 0 State: " + stateMachine.getState()); //index 0 State : State:1
            stateMachine.FatchStateMemento(careTask.Get(2));
            Console.WriteLn("index 2 State: " + stateMachine.getState()); //index 2 State : State:3
        }
    }
}
