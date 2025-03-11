namespace 协变逆变
{
    #region 知识点一 什么是协变逆变
    //协变:
    //和谐的变化，自然的变化
    //因为 里氏替换原则 父类可以装子类
    //所以 子类变父类
    //比如 string 变成 object
    //感受是和谐的

    //逆变:
    //逆常规的变化，不正常的变化
    //因为 里氏替换原则 父类可以装子类 但是子类不能装父类
    //所以 父类变子类
    //比如 object 变成 string
    //感受是不和谐的

    //协变和逆变是用来修饰泛型的
    //协变:out
    //逆变:in
    //用于在泛型中 修饰 泛型字母的
    //只有泛型接口和泛型委托能使用
    #endregion

    #region 知识点二 作用
    //1.返回值 和 参数
    //用 out修饰的泛型  只能作为返回值
    delegate T TestOut <out T>();
    //用 in修饰的泛型  只能作为参数
    delegate void TestIn <in T>(T t);

    //2.结合里氏替换原则理解
    class Father
    { }


    class Son : Father
    { }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点二 作用 （结合里氏替换原则理解）
            //协变  父类总是能被子类替换
            TestOut<Son> os = () =>{ return new Son(); };
            TestOut<Father> of = os;
            Father f = of();  //实际上  返回的 是os里装的函数  返回的是 Son
            
            //逆变  父类总是能被子类替换
            TestIn<Father> iF = (value) => { };
            TestIn<Son> iS = iF;
            iS(new Son());  //实际上 调用的是 iF
            #endregion
        }
    }
}