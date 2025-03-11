namespace 反射加载的数据
{
    public enum aa
    {
        a,
        b,
        c
    }
    public class a
    {
        public aa k;
        public int c;
        public a(aa k ,int c)
        {
            this.k = k;
            this.c = c;
        }
        public void  show(aa a)
        {
            Console.WriteLine("sadasd");
        }
        public override string ToString()
        {
            return c + " " + k;
        }
    }
    public class Program
    {
        
        public struct ss
        {
            int a;
        }
        public int a = 6;
        public int b = 10;
 
       static  void test1()
        {
            Console.WriteLine("hello");
        }
        static void Main(string[] args)
        {
            test ab = new test();
            test1();
            a s = new a(aa.a,1);
        }
    }
}