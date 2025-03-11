namespace 特殊类型
{
    class People
    {
        private int money;
        public bool sex;
        public People(int money)
        {
            this.money = money;
        }
        public People() { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 var隐式类型
            //var是一种特殊的变量类型
            //它可以用来表示任意类型的变量
            //注意:
            //1.var不能作为类的成员 只能用于临时变量申明时
            // 也就是 一般写在函数语句块中
            //2.var必须初始化
            var a = 10;   //初始化为什么类型就是什么类型   可用于不确定类型的时候
            #endregion

            #region 知识点二 设置对象初始值
            //声明对象时
            //可以通过直接写大括号的形式初始化公共成员变量和属性
            People p = new People (){sex = true };  //()可以省略不写
            People p1 = new People(100) { sex = true };  // 也可以有参构造加{}
            #endregion

            #region 知识点三 设置集合的初始值
            //申明集合对象时
            //也可以通过大括号 直接初始化内部属性
            List<People> list = new List<People>() { new People(10)};
            List<int> list1 = new List<int>() { 1,2,3,4,5 };
            #endregion

            #region 知识点四 匿名类型
            //var 变量可以申明为自定义的匿名类型
            var v = new { age = 10, name = "张三" };  //只能有成员变量
            Console.WriteLine(v.name);
            #endregion

            #region 知识点五 可空类型
            //1.值类型是不能赋值为空的
            //int i = null;
            //2.申明时 在值类型后面加? 可以赋值为空
            int? i = null;
            //3.判断是否为空
            if (i.HasValue) { Console.WriteLine(i.Value); }
            //4.安全获取可空类型的值
            int? value = null;
            //4-1 如果为空 默认返回值类型的默认值
            Console.WriteLine(value.GetValueOrDefault());
            //4-2也可以指定一个默认值
            Console.WriteLine(value.GetValueOrDefault(100));   //只是打印默认值  但是并没有给value赋值

            //引用类型 ？---语法糖
            object obj = null;
            //if(obj != null)
            //{ Console.WriteLine(obj.ToString()); }
            Console.WriteLine(obj?.ToString());   //通过语法糖简化代码   也可以用于数组 委托的判断
            #endregion

            #region 知识点六 空合并操作符
            // 空合并操作符 ??
            // 左边值 ??右边值
            // 如果左边值为nu11 就返回右边值 否则返回左边值
            //只要是可以为nu11的类型都能用
            int? intV = null;   //?必须有 否知int类型是不可以为null的不能使??
            int intI;
            //intI = intV == null? 0 : intV.Value;
            intI = intV ?? 0;

            #endregion

            #region 知识点七 内插字符串
            //关键符号:$
            //用$来构造字符串，让字符串中可以拼接变量
            string name = "nnn";
            Console.WriteLine($"你好{name}");
            #endregion

            #region 知识点八 单句逻辑简略写法
            if(true)
                Console.WriteLine("true");  //依据一句代码省略
            else
                Console.WriteLine("false");
            #endregion
        }
    }
}