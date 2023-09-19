using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    //訪問者模式
    //此Model是一個滿特別的模式
    //有點雙面刃的Model雖然好用但是在架構上可能會影響一些原則
    //運用場域是在假設你有一些已經寫好的物件
    //但是現在被要求擴充一個功能是將物件序列化轉成JSON格式
    //這時候你如果對每個物件都進行修改會造成不穩定性也變得有點不適合寫在原本的物件內
    //因為原本的物件可能有他的職責但轉化成別的格式可能不是他的職責
    //而且今天可能被要求轉JSON明天可能又變成XML
    //所以透過另一個class進行visit並將物件直接傳入
    //再透過這個class去判斷是哪種物件調用不同的多載function
    
}
