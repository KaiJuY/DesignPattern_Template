using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //狀態模式
    //在設計一個程式中，某些東西會有特定的狀態
    //例如紅綠燈的燈號，例如遊戲角色的行為狀態
    //其中狀態的變化是有特別的邏輯
    //在一般的情況下會很直觀的認為用多個if else去限制
    //但會讓程式不符合開閉原則
    //這邊用角色的狀態切換做例子
    //邏輯是Idle->Walk->Run->Jump->Idle->....只有這種切換方式的話如下

    interface State
    {
        void Idle();
        void Walk();
        void Run();
        void Jump();
    }
    public class IdleState : State
    {
        private Charactor charactor;
        public IdleState(Charactor ch)
        {
            this.charactor = ch;
        }
        public void Idle()
        {
            Console.WriteLn("Charactor already idle.");
        }
        public void Walk()
        {
            charactor.setState(charactor.getWalkState());
            Console.WriteLn("Charactor Walk now.");
        }
        public void Run()
        {
            Console.WriteLn("Charactor cant Run.");
        }
        public void Jump()
        {
            Console.WriteLn("Charactor cant jump.");
        }
    }
    public class WalkState : State
    {
        private Charactor charactor;
        public WalkState(Charactor ch)
        {
            this.charactor = ch;
        }
        public void Idle()
        {
            Console.WriteLn("Charactor cant Idle.");
        }
        public void Walk()
        {
            Console.WriteLn("Charactor already Walk.");
        }
        public void Run()
        {
            charactor.setState(charactor.getRunState());
            Console.WriteLn("Charactor Run now.");
        }
        public void Jump()
        {
            Console.WriteLn("Charactor cant jump.");
        }
    }
    public class RunState : State
    {
        private Charactor charactor;
        public RunState(Charactor ch)
        {
            this.charactor = ch;
        }
        public void Idle()
        {
            Console.WriteLn("Charactor cant Idle.");
        }
        public void Walk()
        {
            Console.WriteLn("Charactor cant Walk.");
        }
        public void Run()
        {
            Console.WriteLn("Charactor already Run.");
        }
        public void Jump()
        {
            charactor.setState(charactor.getJumpState());
            Console.WriteLn("Charactor jump now.");
        }
    }
    public class JumpState : State
    {
        private Charactor charactor;
        public JumpState(Charactor ch)
        {
            this.charactor = ch;
        }
        public void Idle()
        {
            charactor.setState(charactor.getIdleState());
            Console.WriteLn("Charactor Idle now.");
        }
        public void Walk()
        {
            Console.WriteLn("Charactor cant Walk.");
        }
        public void Run()
        {
            Console.WriteLn("Charactor cant Run.");
        }
        public void Jump()
        {
            Console.WriteLn("Charactor already jump.");
        }
    }
    public class Charactor
    {
        private State state;
        private IdleState idleState;
        private WalkState walkState;
        private RunState runState;
        private JumpState jumpState;

        public Charactor()
        {
            idleState = new IdleState(this);
            walkState = new WalkState(this);
            runState = new RunState(this);
            jumpState = new JumpState(this);
            state = idleState;
        }
        public void idle()
        {
            this.state.Idle();
        }
        public void walk()
        {
            this.state.Walk();
        }
        public void run()
        {
            this.state.Run();
        }
        public void jump()
        {
            this.state.Jump();
        }
        public void setState(State sta)
        {
            this.state = sta;
        }
        public State getIdleState()
        {
            this.state.Idle();
        }
        public State getWalkState()
        {
            this.state.Walk();
        }
        public State getRunState()
        {
            this.state.Run();
        }
        public State getJumpState()
        {
            this.state.Jump();
        }
    }
    public class StateDemo
    {
        private void Demo()
        {
            Charactor Teddy = new Charactor();
            Teddy.run(); //Charactor cant run.
            Teddy.idle(); //Charactor already idle.
            Teddy.idle(); //Charactor already idle.
            Teddy.walk(); //Charactor walk now.
            Teddy.run(); //Charactor run now.
            Teddy.walk(); //Charactor cant walk.
            Teddy.jump(); //Charactor jump now.
        }
    }
}
