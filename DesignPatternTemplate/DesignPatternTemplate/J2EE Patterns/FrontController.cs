using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //前端控制器模式
    //所有的請求都透過單一的處理機制進行
    //該處理機制可以進行Log紀錄授權等檢查
    //並最後將請求傳給相應的程序進行
    //以下的例子由顯示不同分頁的view進行範例

    public class Student
    {
        public void show()
        {
            Console.WriteLn("Here is Student Page.");
        }
    }
    public class Teacher
    {
        public void show()
        {
            Console.WriteLn("Here is Teacher Page.");
        }
    }
    public class Dispatcher
    {
        private Student student;
        private Teacher teacher;
        public Dispatcher()
        {
            student = new Student();
            teacher = new Teacher();
        }
        public void dispatch(string request)
        {
            if(request == "Student")
                student.show();
            else
                teacher.show();
        }
    }
    public class FrontController
    {
        private Dispatcher dispatcher;
        public FrontController()
        {
            dispatcher = new Dispatcher();
        }
        private void traceLog(string request)
        {
            Console.WriteLn("User request : ", request);
        }
        private bool isUserAuthentic()
        {
            Console.WriteLn("User verify OK.");
            return true;
        }
        public void Request(string request)
        {
            traceLog(request);
            if(isUserAuthentic())
                dispatcher.dispatch(request);
        }
    }
    public class FrontControllerDemo
    {
        public void Demo()
        {
            FrontController frontController = new FrontController();
            frontController.Request("Student");
            //User request : Student
            //User verify OK.
            //Here is Student Page.
            frontController.Request("Teacher");
            //User request : Teacher
            //User verify OK.
            //Here is Teacher Page.
        }        
    }
}
