namespace 委托
{
    delegate int MyFun1();
    internal class Program
    {
        #region 知识点一 委托是什么
        //委托是 函数(方法)的容器
        //可以理解为表示函数(方法)的变量类型
        //用来 存储、传递函数(方法)
        //委托的本质是一个类，用来定义函数(方法)的类型(返回值和参数的类型)
        //不同的 函数(方法)必须对应和各自"格式"一致的委托
        #endregion

        #region 知识点二 基本语法
        //关键字 :delegate
        //语法:访问修饰符 delegate 返回值 委托名(参数列表);

        //写在哪里?
        //可以申明在namespace和class语句块中
        //更多的写在namespace中   

        //简单记忆委托语法 就是 函数申明语法前面加一个delegate关键字
        #endregion

        #region 知识点三 定义自定义委托
        //访问修饰默认不写 为public 在别的命名空间中也能使用
        //private 其它命名空间就不能用了
        //一般使用public

        //申明了一个可以用来存储无参无返回值函数的容器      可以使用泛型
        //这里只是定义了规则 并没有使用
        delegate void MyFun();   //不存在重载 不能重名
        #endregion
       
        #region 知识点四 使用定义好的委托
        //委托变量是函数的容器

        //委托常用在：
        //1.作为类的成员
        //2.作为函数的参数

        class a
        {
            public MyFun myFun1;

            public void test(MyFun myFun)
            {
                this.myFun1 = myFun;
            }
        }

        #endregion

        #region 知识点五 委托变量可以存储多个函数（多播委托)
        MyFun myFun1;

        //"+=" 添加函数
        //"-="去除函数   多减不报错  找不到--不操作    
        #endregion

        #region 知识点六 系统定义的委托
        //Action  无参数无返回值
        
        //Func<T>  可以指定返回类型的泛型委托
        
        //Action <T1,T2,...,T16>   可以传n个参数的泛型委托   1-16个参数的委托  

        //Func<T1,T2,T3..T16>  传n个参数,一个返回值，0-15个输入参数
        #endregion

        static void hhh()
        {

        }
       
        class ppp
        {
            MyFun myFun;

            public ppp(MyFun myFun)
            {
                this.myFun += myFun;
            }
        }

        static void Main(string[] args)
        {
            #region 调用委托 知识点四

            //MyFun myFun = new MyFun(test);
            MyFun myFun = null;

            //lambda表达式
            //MyFun myFun = () => { Console.WriteLine("委托"); };
            //MyFun myFun =new MyFun(()=> { Console.WriteLine("ssad"); });
            #endregion

            //多播委托
            myFun += hhh;       //声明后直接"+="会报错   先赋函数或者null可以解决   在类中声明然后传入时默认为null，可以直接"+="
            myFun += test;
            myFun();

            //补充知识点
            MyFun1 myFun2 = null;
            myFun2 += () => { Console.WriteLine("第一次"); return 1; };
            myFun2 += () => { Console.WriteLine("第二次"); return 2; };
            myFun2 += () => { Console.WriteLine("第三次"); return 3; };
            //如果直接调用 虽然3个函数的逻辑会执行
            //但是返回值只能获取到最后一个的
            Console.WriteLine(myFun2());

            Console.WriteLine("------------------------------------");
            //通过GetInvocationList方法获取到委托列表
            //然后迭代器遍历获取到每一个函数单独执行单独获取
            foreach (MyFun1 item in myFun2.GetInvocationList())
            {
                Console.WriteLine(item());
            }

        }
        static void test()
        {

        }
    }
}