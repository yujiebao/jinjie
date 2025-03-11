#define Func
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 特性
{
    #region 知识点一 特性是什么
    //特性是一种允许我们向程序的程序集添加元数据的语言结构
    //它是用于保存程序结构信息的某种特殊类型的类

    //特性提供功能强大的方法以将声明信息与 c#代码(类型、方法、属性等)相关联。
    //特性与程序实体关联后，即可在运行时使用反射查询特性信息

    //特性的目的是告诉编译器把程序结构的某组元数据嵌入程序集中
    //它可以放置在几乎所有的声明中(类、变量、函数等等申明)

    //说人话:
    //特性本质是个类
    //我们可以利用特性类为元数据添加额外信息
    //比如一个类、成员变量、成员方法等等为他们添加更多的额外信息
    //之后可以通过反射来获取这些额外信息
    #endregion

    #region 知识点二 自定义特性
    //继承特性基类Attribute、
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    class MyCustomAttribute : Attribute
    {
        //特性中的成员
        public string info;
        public MyCustomAttribute(string info)
        {
            this.info = info;
        }

        public void test()
        {
            Console.WriteLine("特性的方法");
        }
     
    }
    #endregion

    #region 知识点三 特性的使用 
    //基本语法:
    //[特性名(参数列表)]
    //本质上 就是在调用特性类的构造函数
    //写在哪里?
    //类、函数、变量上一行，表示他们具有该特性信息
    #endregion

    #region 知识点四 限制自定义特性的使用范围
    //通过为特定类 加特性 限制其使用范围
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Struct,AllowMultiple = true,Inherited =true)]
    //参数-AttributeTargets   -特性能够用在哪些地方
    //参数二:AllowMultiple     -是否允许多个特性实例用在同一个目标上
    //参数三:Inherited         -特性是否能被派生类和重写成员继承,
    public class MyCustom2Attribute : Attribute
    {

    }
    #endregion

    #region 知识点五 系统自带特性---过时特性
    //过时特性
    //[Obsolete("OldFunc已经过时了，请使用新方法",false)]
    //obsolete()   第一个参数  提示信息  第二个true---直接error，false-----警告  
    //用于提示用户 使用的方法等成员已经过时 建议使用新方法
    //一般加在函数前的特性
    #endregion

    #region 知识点六 系统自带特性-调用者信息特性
    //哪个文件调用?
    //CallerFilePath特性
    //哪一行调用?
    //CallerLineNumber特性
    //哪个函数调用?
    //CallerMemberName特性

    //需要引用命名空间 using system.Runtime.compilerservices;
    //一般作为函数参数的特性
    #endregion

    #region 知识点七 系统自带特性-条件编译特性
    //条件编译特性
    //[Conditional("DEBUG")]
    //当定义了DEBUG宏时，才执行该函数
    //一般用于调试阶段

    //需要引用命名空间using system.Diagnostics;
    //主要可以用在一些调试代码上
    //有时想执行有时不想执行的代码
    #endregion

    #region 知识点八 系统自带特性 -外部Dll包函数特性
    //DllImport

    //用来标记非.Net(c#)的函数，表明该函数在一个外部的DLL中定义。
    //一般用来调用 c或者c++的Dll包写好的方法
    //需要引用命名空间 using system.Runtime.Interopservices
    #endregion

    [MyCustom("这是一个我自己写的用于计算的类")]   //可以省略Attribute
    class Myclass
    {
        [MyCustom("这是一个成员变量")]
        public int value;

        [MyCustom("这是一个用于计算加法的函数")]
        public void TestFunc([MyCustom("函数参数")]int a, int b)
        {

        }

        [Obsolete("OldFunc已经过时了，请使用新方法",false)]
        public void OldFunc()
        {

        }

        
        public void SpeakCaller(string str , [CallerFilePath] string filePath="", [CallerLineNumber] int lineNumber=0, [CallerMemberName] string memberName="")
        {
            Console.WriteLine(str);
            Console.WriteLine(filePath);
            Console.WriteLine(lineNumber);
            Console.WriteLine(memberName);
        }

    }
    internal class Program
    {
        [DllImport("文件包名/路径名")]
        public static extern int Add(int a, int b);   // 调用外部的Dll包中的Add函数 ，执行外部包的逻辑

        [Conditional("Func")]
        static void Func()
        {
            Console.WriteLine("Func执行");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("特性");
            #region 特性的使用
            Myclass mc = new Myclass();
            Type t = mc.GetType();
            //mc.OldFunc();
            mc.SpeakCaller("hello");
           
            //判断是否使用了某个特性
            if (t.IsDefined(typeof(MyCustomAttribute), false)) //参数一： 特性的类型  参数二: 代表是否搜索继承链(属性和事件忽略此参数)
            {
                Console.WriteLine("该类使用了MyCustomAttribute特性");

                //获取Type元数据中的所有特性
                object[] array = t.GetCustomAttributes(true);
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] is MyCustomAttribute)
                    {
                        Console.WriteLine((array[i] as MyCustomAttribute).info);
                        (array[i] as MyCustomAttribute).test();
                    }
                }
                //获取特性
                /*MyCustomAttribute attr = (MyCustomAttribute)t.GetCustomAttributes(typeof(MyCustomAttribute), false)[0];
                Console.WriteLine(attr.info);*/
            }
            #endregion
            Func();
        }
    }
}