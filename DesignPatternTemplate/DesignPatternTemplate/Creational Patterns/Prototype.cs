using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPatternTemplate
{
    //原型模式
    //常聽到的Clone分為Shallow Clone和Deep Clone
    //其中平常看到的 A = B 這種屬於Shallow Clone屬於參照的一種
    //如果是基於物件的複雜情況下就不適用
    //因為裡面可能包含很多比較複雜的資料結構
    //這時候使用Shallow Clone會造成原本的物件被修改則影響到複製出的物件
    //因此需要透過Deep Clone產生一個完全新的物件
    //而原型模式使用場景則在可能你需要大量產生一個物件
    //資料庫中存有一些物件的原型模板讓你可以在產生物件時就帶有一些特定屬性
    //但是這個方法也會使用大量的訪問資料庫而造成資源浪費
    //比較好的做法式準備一個HashTable將常用的原型放入其中直接操作內存可以有效解決不斷IO的消耗

    public static class CloneHelper
    {
        public static T Deepclone<T>(T obj)
        {
            if (!typeof(T).IsSerializable)
                throw new AccessViolationException("Binary Format Deep Clone must be serializable.");
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
    public class NoteBook
    {
        public string Brand { get; set; }
        public int Size { get; set; }
        public List<string>Options { get; set; }
        public NoteBook(string brand, int size, List<string>options)
        {
            Brand = brand;
            Size = size;
            Options = options;
        }
        public void Show()
        {
            Console.WriteLine("Brand : {0}, Size : {1}", Brand, Size);
            for(int i = 0; i < Options.Count(); ++i)
            {
                Console.WriteLine("Option{0} : {1}", i + 1, Options[i]);
            }
        }
        public NoteBook deepclone()
        {
            return CloneHelper.Deepclone(this) as NoteBook;
        }
    }
    public class NoteBookCache
    {
        private static ConcurrentDictionary<string, Object> Store = new ConcurrentDictionary<string, object>();
        public static void LoadNoteBook()
        {
            List<string> Options = new List<string>{ "Mouse", "KeyBoard" };
            NoteBook noteBook = new NoteBook("Unknow", 0, Options);
            Store.TryAdd("NB", noteBook);
        }
        public static NoteBook GetNoteBook()
        {
            Store.TryGetValue("NB", out object NB);
            return (NB as NoteBook).deepclone();
        }
        public static void Demo()
        {
            LoadNoteBook();
            NoteBook nb = GetNoteBook();
            nb.Show();
        }
    }
}
