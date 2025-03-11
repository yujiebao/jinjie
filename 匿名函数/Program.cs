namespace 匿名函数
{
    #region 知识点一 什么是匿名函数
    //顾名思义，就是没有名字的函数
    //匿名函数的使用主要是配合委托和事件进行使用
    //脱离委托和事件 是不会使用匿名函数的
    #endregion

    #region 知识点二  基本语法 
    /*    delegate() 
        {
            Console.WriteLine("匿名函数");
        };
    何时使用?
    1.函数中传递委托参数时
    2.委托或事件赋值时*/
    #endregion


    class aa
    {
        public Action action;
        
        //作为参数传递
        public void Dosomething(int a , Action action)
        {
            Console.WriteLine(a);
            action();
        }


        //作为返回值
        public Action GetFunc()
        {
            return delegate () { Console.WriteLine("函数返回匿名函数"); };
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点三 使用匿名函数
            //1.无参未返回
            Action a = delegate ()
            {
                Console.WriteLine("匿名函数");
            };

            //2.有参数
            Action<int> c = delegate (int i)
            {
                Console.WriteLine("匿名函数 传入参数" + i);
            };

            //3.有返回值
            Func<int, int> d = delegate (int i)
            {
                return i * i;
            };

            //4.一般情况会作为函数参数传递  或者  作为函数返回值
            aa t = new aa();

            //参数传递
            t.Dosomething(5, delegate () { Console.WriteLine("结束"); });

           // 返回值
           /*  Action action = t.GetFunc();
              action();*/
           t.GetFunc()();


            #endregion

            #region 知识点四 匿名函数的缺点
            //添加到委托或事件容器中后 不记录 无法单独移除只能清空       ----多播委托
            #endregion
        }
    }
}