using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //解釋器模式
    //此模式的運用場景較少
    //很著名的案例是用SQL語句的時候
    //SELECT VAL FROM TABLE
    //可以用空格拆解成四個KEY WORD
    //分別對4個KEY WORD去塞值或執行動作
    //同時也具備了容易擴充新指令的優點
    public interface Expression
    {
        void interept();    
    }
    public class ActionExpression : Expression
    {
        private string Action;
        public ActionExpression(string action)
        {
            this.Action = action;
        }
        public void interept()
        {
            Console.WriteLn("Do Action : " + this.Action);
        }
    }
    public class ConditionExpression : Expression
    {
        private string Condition;
        public ConditionExpression(string condition)
        {
            this.Condition = condition;
        }
        public void interept()
        {
            Console.WriteLn(this.Condition);
        }
    }
    public class CommandExpression : Expression
    {
        private string Key, Source;
        private Expression Action, Condition;
        
        public CommandExpression(Expression act, Expression con, string key, string source)
        {
            this.Action = act;
            this.Condition = con;
            this.Key = key;
            this.Source = source;
        }
        public void interept()
        {
            this.Action.interept();
            Console.WriteLn(" " + this.Key);
            this.Condition.interept();
            Console.WriteLn(" " + this.Source);
        }
    }
    public class IntereptDemo
    {
        public void Demo()
        {
            string UserCommand = "SELECT ID FROM EMPLOYEE_TABLE";
            string[] Parser_UserCommand = UserCommand.Split(' ');
            ActionExpression actionExpression = new ActionExpression(Parser_UserCommand[0]);
            ConditionExpression conditionExpression = new ConditionExpression(Parser_UserCommand[2]);
            CommandExpression commandExpression = new CommandExpression(actionExpression, commandExpression, Parser_UserCommand[1], Parser_UserCommand[3]);
            commandExpression.interept();
            //DO Action : SELECT
            // ID
            //FROM
            //EMPLOYEE_TABLE
        }
    }
}
