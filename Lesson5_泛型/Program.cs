namespace Lesson5_泛型
{
    internal class Program
    {
        #region 知识点一 泛型是什么
        //泛型实现了类型参数化，达到代码重用目的
        //通过类型参数化来实现同一份代码上操作多种类型

        //泛型相当于类型占位符
        //定义类或方法时使用替代符代表变量类型
        //当真正使用类或者方法时再具体指定类型
        #endregion

        #region 知识点二 泛型分类
        //泛型类和泛型接口
        //class 类名<泛型占位字母>    interface 接口名<泛型占位字母>

        //泛型函数
        //函数名<泛型占位字母>()
        //注意：泛型占位字母可以有多个，用逗号隔开
        #endregion

        #region 泛型类和接口
         private class TestClass<T,K>
        {
            public T t;
            K k;
        }

        interface ITestInterface<T,K>
        {
             T test();
            K a { get;}
        }
        #endregion

        #region 泛型方法
        T test<T>(T t) 
        {
            
            return t;
        }

        //使用泛型类的泛型类型不是泛型方法 类型在声明类的时候就确定了
        //可以再写一个其他占位符的函数进行重载
        #endregion

        #region 泛型的作用
        //1.不同类型对象的相同逻辑处理就可以选择泛型
        //2.使用泛型可以一定程度避免装箱拆箱
        //举例:优化ArrayList
        #endregion
        static void Main(string[] args)
        {
           TestClass<int,int> test = new TestClass<int,int>();
        }
    }
}