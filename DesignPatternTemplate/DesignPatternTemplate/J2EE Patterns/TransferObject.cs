using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //傳輸對象模式
    //透過一個簡單的Object僅有getter/setter當作傳輸對象VO
    //並在透過一個為傳輸對象進行更新或創建的BO

   public class MouseVO
   {
        private int Code;
        private string Band;
        private string Type;
        public MouseVO(int c, string b, string t)
        {
            this.Code = c;
            this.Band = b;
            this.Type = t;
        }
        public int getCode()
        {
            return this.Code;
        }
        public string getBand()
        {
            return this.Band;
        }
        public string getType()
        {
            return this.Type;
        }
        public void setCode(int C)
        {
            this.Code = C;
        }
        public void setBand(string B)
        {
            this.Band = B;
        }
        public void setType(string T)
        {
            this.Type = T;
        }
   }
   public class MouseBO
   {
        private List<MouseVO> Mouses;
        public MouseBO()
        {
            Mouses = new List<MouseVO>();
            Mouses.Add(new MouseVO(1, "Logic", "G304"));
            Mouses.Add(new MouseVO(2, "Razer", "DEATHADDER"));
        }
        public void deleteMouse(MouseVO mouse)
        {
            int i = 0;
            bool isfound = false;
            for(i = 0; i < Mouses.Count; ++i)
            {
                if(Mouses[i].getCode() == mouse.getCode())
                {
                    isfound = true;
                    break;
                }
            }
            if(isfound)
                Mouses.Remove(i);
        }
        public List<MouseVO> getAllMouse()
        {
            return Mouses;
        }
        public MouseVO GetMouse(int code)
        {
            foreach(MouseVO mouse in Mouses)
            {
                if(mouse.getCode() == code)
                    return mouse;
            }
            return null;
        }
        public void updateMouse(MouseVO m)
        {
            for(int i = 0; i < Mouses.Count; ++i)
            {
                if(Mouses[i].getCode() == m.getCode())
                {
                    Mouses[i] = m;
                    break;
                }
            }
        }
   }
   public class TransferObjectDemo
   {
    public void Demo()
    {
        MouseBO mouseBO = new MouseBO();
        List<MouseVO> mouseList = mouseBO.getAllMouse();
        foreach(MouseVO mouse in mouseList)
        {
            Console.WriteLn("Code : " + mouse.getCode() + " Band : " + mouse.getBand() + " Type : " + mouse.getType());
        }
        //Code : 1 Band : Logic Type : G304
        //Code : 2 Band : Razer Type : DEATHDDER
        MouseVO mo = mouseBO.GetMouse(1);
        mo.setType("G607");
        mouseBO.updateMouse(mo);
        mo = mouseBO.GetMouse(1);
        Console.WriteLn("Code : " + mo.getCode() + " Band : " + mo.getBand() + " Type : " + mo.getType());
        //Code : 1 Band : Logic Type : G607
    }
   }
}
