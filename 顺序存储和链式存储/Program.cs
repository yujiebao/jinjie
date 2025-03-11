namespace 顺序存储和链式存储
{
    
    internal class Program
    {

        static void Main(string[] args)
        {
            Pro3_Link<string> link = new Pro3_Link<string>();
            link.init();
            /* link.add(8);
             link.add(1);
             link.add(2);
             link.add(3);
             link.add(7);*/
            link.add("dsadas");
            link.add("a");

            link.add("b");

            link.add("c");
            link.add("e");
            link.add("h");

            link.print();
            link.removeElem("dsadas");

            //link.remove(1);
            link.print();

            link.printF();
        }
    }
}