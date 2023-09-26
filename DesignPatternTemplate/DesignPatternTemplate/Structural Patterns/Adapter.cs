using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //適配器模式
    //這個Model主要是希望將兩個互不兼容的接口互相串聯
    //就像是筆電的插頭有3個角位而插座只有2個角位就會需要轉接頭的情況
    //以下用公分與英寸的單位轉換做一個Adapter做示範
    //注意這邊提供了雙向Adapter
    
    public interface CentimeterLength
    {
        public double getCentimeter();
    }
    public interface InchLength
    {
        public double getInch();
    }
    public class Centimeter : CentimeterLength
    {
        private double Length;
        public Centimeter(double length)
        {
            this.Length = length;
        }
        public double getCentimeter()
        {
            return this.Length;
        }
    }
    public class Inch : InchLength
    {
        private double Length;
        public Inch(double length)
        {
            this.Length = length;
        }
        public double getInch()
        {
            return this.Length;
        }
    }
    public class LengthAdapter : CentimeterLength, InchLength
    {
        private Centimeter Cm;
        private Inch Inch;
        public LengthAdapter(Centimeter cm)
        {
            this.Cm = cm;
            this.Inch = new Inch(Cm.getCentimeter() / 2.54);
        }
        public LengthAdapter(Inch inch)
        {
            this.Inch = inch;
            this.Cm = new Centimeter(Inch.getInch() * 2.54);
        }
        public double getCentimeter()
        {
            return Cm.getCentimeter();
        }
        public double getInch()
        {
            return Inch.getInch();
        }
    }
    public class AdapterDemo
    {
        public void Demo()
        {
            Centimeter cm = new Centimeter(25.4);
            LengthAdapter lengthAdapter = new LengthAdapter(cm);
            Console.WriteLine("Cm : {0} / Inch : {1}", lengthAdapter.getCentimeter(), lengthAdapter.getInch());
            //"Cm : 25.4 / Inch : 10"
        }
    }
}
