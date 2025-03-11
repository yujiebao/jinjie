namespace 事件
{
    #region 知识点一 事件是什么
    //事件是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件 是一种特殊的变量类型
    #endregion

    #region 知识点三 事件的使用
    //申明语法:
    //访问修饰符 event 委托类型 事件名;

    //事件的使用:
    //1.事件是作为 成员变量存在于类中
    //2.委托怎么用 事件就怎么用
    //事件相对于委托的区别:
    //1.不能在类外部 赋值
    //2.不能再类外部 调用
    //注意:
    //它只能作为成员存在于类和接口以及结构体中

    class Test
    {
        //委托成员变量
        public Action myFunc;
        //事件成员变量
        public event Action myEvent;

        public Test()
        {
            //事件的使用和委托一样
            myEvent = TestFunc;
            myEvent = null;
        }

        public void TestFunc()
        {
        }
    }
    #endregion

    #region 知识点四 为什么使用事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了一次封装 让其更加安全
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
           Test test = new Test();
            test.myFunc = null;
            //test.myEvent = null;  赋值会报错 不能外部赋值
            
            test.myEvent += TestFunc;  //可以使用+= -=去添加或者移除记录的函数

            test.myFunc();
            //test.myEvent(); 不能再外部调用  可以在类的内部封装调用  
        }

        static void TestFunc()
        {
            Console.WriteLine("TestFunc");
        }
    }
}