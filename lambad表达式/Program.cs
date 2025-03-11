namespace lambad表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 什么是lambad表达式
            //可以将1ambad表达式 理解为匿名函数的简写
            //它除了写法不同外
            //使用上和匿名函数一模一样
            //都是和委托或者事件 配合使用的
            #endregion

            #region 知识点二 lambad表达式的语法 
            /*（参数列表）=>
            {
                函数体
            };*/

            #endregion

            #region 知识点三 lambad表达式的使用
            //1.无参无返回值
            Action action =() =>
            {
                Console.WriteLine("无参无返回值");
            };
            action();

            //有参数
            //Action<int> action1 = (int a) =>
            Action<int> action1 = (a) =>   //甚至参数类型都可以省略 参数类型和委托或事件容器一致
            {
                Console.WriteLine(a);
            };

            //有参数有返回值
            Func<int, int> func = (a) =>
            {
                return a;
            };
            #endregion
        }
    }
    #region 闭包
    //内层的函数可以引用包含在它外层的函数的变量
    //即使外层函数的执行已经终止
    //注意:
    //该变量提供的值并非变量创建时的值，而是在父函数范围内的最终值,

    public class test
    {
        public event Action action;
        
        public test()
        {
            int a = 0;
            //这里就形成了闭包
            //因为 当构造函数执行完毕时 其中申明的临时变量value的声明周期被改变了
            action = () =>
            {
                Console.WriteLine(a);
            };

            for(int i = 0; i < 10; i++)
            {
                //int index = i;  新变量使输出是每次的值  不然输出全是最终值
                 action+= () =>
                {
                    //Console.WriteLine(i);   
                    Console.WriteLine(i);    //一直是10（父函数的最终值,此处为i不满足条件的i值，即i = 10） 若要i是1-9需要，每次都使用新变量来传递   
                };
            }
        }
    }

    #endregion
}