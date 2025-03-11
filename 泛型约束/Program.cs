using static System.Net.Mime.MediaTypeNames;

namespace 泛型约束
{
    #region 知识点一 什么是泛型约束
    //让泛型的类型有一定的限制
    //关键字:where
    //泛型约束一共有6种
    //1.值类型                               where 泛型字母:struct
    //2.引用类型                             where 泛型字母 : class
    //3.存在无参公共构造函数                  where 泛型字母:new () 
    //4.某个类本身或者其派生类                where  泛型字母:类名
    //5.某个接口的派生类型                    where 泛型字母:接口名
    //6.另一个泛型类型本身或者派生类型         where 泛型字母:另一个泛型字母
    #endregion

    #region 知识点二 各泛型约束
    #region 1.值类型
    class TestV<T> where T:struct
    {
        public T a;
        public void testFunc<K>(K a) where K:struct
        {
            Console.WriteLine(a);
        }
    }
    #endregion
    
    #region 2.引用类型
    class TestR<T> where T : class
    {
        public T a;
        public void testFunc<K>(K a) where K : class
        {
            Console.WriteLine(a);
        }
    }
    #endregion

    #region 3.公共无参构造函数
    //结构体有无参数构造函数(默认生成)   进行构造函数重载时也不会替换原有的无参构造函数  结构体中的无参数构造函数必须为public  所以满足了所有条件 
    //抽象类  即使有无参数公共构造函数也能不能使用 不能new
    class Test3<T> where T : new()
    {
        public T a;
        public void testFunc<K>(K a) where K : new()
        {
            Console.WriteLine(a);
        }
    }
    #endregion

    #region 4.类约束
    class Test4<T> where T : pp
    {
        public T a;
        public void testFunc<K>(K a) where K : pp
        {
            Console.WriteLine(a);
        }
    }
    #endregion

    #region 5.接口约束
    class Test5<T> where T : Action
    {
        public T a;
        public void testFunc<K>(K a) where K : Action
        {
            Console.WriteLine(a);
        }
    }
    #endregion

    #region 6.另一个泛型类型约束
    class Test6<T,U> where T : U  //T是U本身  T是U的派生类 T实现了U的接口
    {
        public T a;
        public void testFunc<K,V>(K a) where K : V
        {
            Console.WriteLine(a);
        }
    }
    #endregion
    #endregion

    #region 知识点三 约束的组合使用
    class Test7<T> where T:class,new()
    {

    }
    #endregion

    #region 知识点四 多个泛型约束
    class Test8<T,U> where T:class,new() where U:class,new()
    {

    }
    #endregion

    #region 类和接口等
    struct a
    {
        int c;
        int b;
        private a(int c,int b)
        {
            this.c  = c;
            this.b = b;
        }
    }
    class pp
    {

    }

    class ppSon:pp
    { }

    class qq
    {
        public qq(int a )
        {

        }
    }

    interface Action
    {

    }
    class animal:Action
    {

    }

    interface IFly : Action
    {

    }
    class Bird:IFly
    {

    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
           
           
            //值约束
            TestV<int> test= new TestV<int>();
            test.a=42;
            
            //引用类型约束
            TestR<pp> testR =  new TestR<pp>();
            
            //存在公共无参数构造函数
            //Test3<qq> test3_1 = new Test3<qq>(); 有参数构造函数，替换了无参数构造函数  
            Test3<pp> test3_2 = new Test3<pp>();   //默认的无参数构造函数    ---无参数，且公共的
            
            //类约束
            Test4<pp> test4_1 = new Test4<pp>();
            Test4<ppSon> test4_2 = new Test4<ppSon>();  //派生类
        
            //接口约束
            Test5<Action> test5_1 = new Test5<Action>();  //约束的接口
            test5_1.a = new animal();
            Test5<animal> test5_2 = new Test5<animal>();  //实现约束接口的类
            Test5<IFly> test5_3 = new Test5<IFly>();    //继承接口的接口（由接口派生出的接口）
            Test5<Bird> test5_4 = new Test5<Bird>();     //实现接口派生接口的类
             
            //另一个泛型类型约束   
            Test6<animal,Action> test6_1 = new Test6<animal, Action>();
            Test6<int,int> test6_2 = new Test6<int,int>();
        }
    }
}

        
