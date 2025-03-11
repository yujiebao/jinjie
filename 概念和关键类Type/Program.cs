using System.Reflection;

namespace 概念和关键类Type
{
    #region 知识点一 什么是程序集
    //程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    //在WINDOWS系统中，它一般表现为后缀为·d11(库文件)或者是·exe(可执行文件)的格式
    //说人话:
    //程序集就是我们写的一个代码集合，我们现在写的所有代码
    //最终都会被编译器翻译为一个程序集供别人使用
    //比如一个代码库文件(d11)或者一个可执行文件(exe)
    #endregion

    #region 知识点二 元数据
    //元数据就是用来描述数据的数据
    //这个概念不仅仅用于程序上，在别的领域也有元数据
    //说人话:
    //程序中的类，类中的函数、变量等等信息就是 程序的 元数据
    //有关程序以及类型的数据被称为 元数据，它们保存在程序集中
    #endregion

    #region 知识点三 反射的概念
    //程序正在运行时，可以查看其它程序集或者自身的元数据。
    //一个运行的程序查看本身或者其它程序的元数据的行为就叫做反射
    //说人话:
    //在程序运行时，通过反射可以得到其它程序集或者自己程序集代码的各种信息
    //类，函数，变量，对象等等，实例化它们，执行它们，操作它们
    #endregion

    #region 知识点四 反射的作用
    //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性
    //1.程序运行时得到所有元数据，包括元数据的特性
    //2.程序运行时，实例化对象，操作对象
    //3.程序运行时创建新对象，用这些对象执行任务
    #endregion
   
    class test
    {
        private int i = 1;
        public int j = 0;
        public string str = "hello";

        public test()
        {
        }

        public test(int i)
        {
            this.i = i;
        }

        public test(int i, int j, string str) : this(i)
        {
            this.j = j;
            this.str = str;
        }

        public void speak()
        {
            Console.WriteLine(i);
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点五 语法相关

            #region Type
            //Type(类的信息类)
            //它是反射功能的基础!
            //它是访问元数据的主要方式
            //使用 Type 的成员获取有关类型声明的信息
            //有关类型的成员(如构造函数、方法、字段、属性和类的事件)
       

            #region 获取Type    ---结构体和类的Type
            //1.万物之父object中的GetType方法可以获取对象的Type
            int  a = 0;
            Type type = a.GetType();
            //Console.WriteLine(type);
            
            //2.通过typeof关键字  传入类名 也可以得到对象的Type
            Type type1 = typeof(int);
            //Console.WriteLine(type1);
            
            //3.通过类的名字 也可以获取类型 
            //注音  类名必须包含命名空间 不然找不到
            Type type2 = Type.GetType("System.Int32");
            //Console.WriteLine(type2);
            #endregion
             
            #region 得到类的程序集信息
            //可以通过Type得到类型所在的程序集信息
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type1.Assembly);
            Console.WriteLine(type2.Assembly);
            #endregion

            #region 获取类中的所有公共成员
            //首先得到 Type
            Type t = typeof(test);
            //然后得到所有的公共成员
            MemberInfo[] infos = t.GetMembers();
            for(int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);
            }
            #endregion

            #region 获取类的公共构造函数并调用
            Console.WriteLine();
            //1.获取所有的构造函数
            ConstructorInfo[] cis = t.GetConstructors();
            for(int i = 0; i < cis.Length; i++)
            {
                Console.WriteLine(cis[i]);
            }

            //2.获取其中一个构造函数并执行
            //得构造函数传入 Type数组 数组中内容按顺序是参数类型
            //执行构造函数传入object数组 表示按顺传入的参数

            //  2-1得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            //执行无参构造  无参构造 没有参数 传null
            test obj = info.Invoke(null) as test;
            Console.WriteLine(obj.j);

            // 2-2得到有参构造
            ConstructorInfo info2 = t.GetConstructor(new Type[]{typeof(int), typeof(int), typeof(string)});   // i  j str
            obj = info2.Invoke(new object[]{1, 2, "hello"}) as test;   // i j str 
            Console.WriteLine(obj.j+" "+obj.str);
            #endregion

            #region 获取类的公共成员变量
            Console.WriteLine();
            //1.得到所有的公共成员变量
            FieldInfo[] fieldInfos= t.GetFields();
            for(int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);
            }
 
            //2.得到指定名称的公共成员变量
            FieldInfo infoj = t.GetField("j");
            Console.WriteLine(infoj);
            
            //3.通过反射获取和设置对象的值
            test t1 = new test ();
            t1.j = 1;
            t1.str = "hello";
            //3-1通过反射 获取指定对象的某个变量的值
            Console.WriteLine(infoj.GetValue(t1));
            //3-2通过反射 设置指定对象的某个变量的值
            infoj.SetValue(t1, 2);
            Console.WriteLine(infoj.GetValue(t1));

            #endregion

            #region 获取类的公共成员方法
            //通过Type类中的 GetMethod方法 得到类中的方法
            //MethodInfo 是方法的反射信息
            Type strType = typeof(string);
            //1.如果存在方法重载 用Type数组表示参数类型
            MethodInfo[] methodInfos = strType.GetMethods();
            MethodInfo subStr = strType.GetMethod("Substring",new Type[] {typeof(int), typeof(int) });
            string tstring = "adadasdasd";
            object tmp =  subStr.Invoke(tstring, new object[] { 1, 2 });   //tstring执行   返回用超级父类object接收，使用string报错没确定是什么
            Console.WriteLine(tmp);
        #endregion
        #endregion

            #region Assembly
            //程序集类
            //主要用来加载其它程序集，加载后
            //才能用Type来使用其它程序集中的信息
            //如果想要使用不是自己程序集中的内容 需要先加载程序集
            //比如 d11文件(库文件)
            //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类


            //三种加载程序集的函数
            //一般用来加载在同一文件下的其它程序集
            //Assembly asembly2 = Assembly.Load("程序集名称");

            //一般用来加载不在同一文件下的其它程序集
            //Assembly asembly = Assembly.LoadFrom("包含程序集清单的文件的名称或路径”);
            //Assembly asembly3 = Assembly.LoadFile("要加载的文件的完全限定路径");

            //1.先加载一个指定的程序集
            Assembly asembly = Assembly.LoadFrom("F:\\unity\\TangCourse\\C#\\进阶\\CSharp进阶\\反射加载的数据\\bin\\Debug\\net7.0\\反射加载的数据.dll");
            Console.Clear();
            Type[] types = asembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }

            //2.再加载程序集中的一个类对象  之后才能使用反射
            Type typea = asembly.GetType("反射加载的数据.a");
            MemberInfo[] members = typea.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }

            //3.通过反射 实例化一个typea对象
            //首先得到枚举Type 来得到可以传入的参数
            Type E_aa = asembly.GetType("反射加载的数据.aa");
            FieldInfo aa_a = E_aa.GetField("a");
            
            //直接实例化对象
            object obja =  Activator.CreateInstance(typea,aa_a.GetValue(null),1);
            //FieldInfo对象包含关于字段的信息（如字段名称、类型等），但它不是字段的实际值。要获取字段的值，您需要调用GetValue方法，
            //并传入适当的对象实例（对于静态字段，传递null作为参数）。   传一个null就可以得到枚举的值

            //得到对象中的方法 通过反射
            MethodInfo show = typea.GetMethod("show");
            show.Invoke(obja,new object[] {aa_a.GetValue(null)});       // 执行obj对象的方法   枚举对象 放在object数组内
            #endregion

            #region Activator
            //用于快速实例化对象的类
            //用于将Type对象快捷实例化为对象
            //先得到Type
            //然后 快速实例化一个对象
            Type testType = typeof(test);
            //1.无参构造
            test testObj = Activator.CreateInstance(testType) as test;
            Console.WriteLine(testObj.str);
            //2.有参构造
            testObj = Activator.CreateInstance(testType,  1, 2, "world" ) as test;
            Console.WriteLine(testObj.str);
            #endregion
            #endregion

        }
    }
}