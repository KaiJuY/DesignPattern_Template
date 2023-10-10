using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //外觀模式
    //與Factory有點相似但著重的點不同
    //這個是更偏向使用時可以更方便的直接使用不同類別的行為
    //並不是著重於創建的過程

    public interface Shape
    {
        public void draw()
        {

        }
    }

    public class Square : Shape
    {
        public void draw()
        {
            Console.WriteLine("Square Draw.")
        }
    }
    public class Circle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Circle Draw.")
        }
    }
    public class ShapeMaster
    {
        private Square square;
        private Circle circle;
        public ShapeMaster()
        {
            square = new Square();
            circle = new Circle();
        }
        public void DrawSquare()
        {
            square.draw();
        }
        public void DrawCircle()
        {
            circle.draw();
        }
    }
    public class FacadeDemo
    {
        public void Demo()
        {
            ShapeMaster shapeMaster = new ShapeMaster();
            shapeMaster.DrawCircle();//Circle Draw.
            shapeMaster.DrawSquare();//Square Draw.
        }
    }
}
