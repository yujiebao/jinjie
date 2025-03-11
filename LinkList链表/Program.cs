namespace LinkList链表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 LinkedList
            //LinkedList是一个C#为我们封装好的类
            //它的本质是一个可变类型的泛型双向链表
            #endregion

            #region 知识点二 LinkedList的申明
            //需要引用命名空间
            //using System.Collections.Generic
            LinkedList<string> list = new LinkedList<string>();
            //链表对象 需要掌握两个类
            //一个是链表本身 一个是链表节点类LinkedListNode
            #endregion

            #region 增删改查
            #region 增
            list.AddLast("a");
            list.AddFirst("b");

            //在某一节点后添加一个节点
            LinkedListNode<string> node = list.Find("a");
            list.AddAfter(node, "c");
            //前面加入
            list.AddBefore(node, "d");
            #endregion

            #region 删
            list.RemoveFirst();
            list.RemoveLast();
            list.Remove("a");
            list.Clear();
            #endregion

            #region 查
            LinkedListNode<string> first = list.First;
            
            LinkedListNode<string> last = list.Last;
            
            LinkedListNode<string> second = list.Find("sa");//找不到返回空
            
            list.Contains("a");  //判断是否包含此元素
            #endregion

            #region 改
            //先得到节点  再更改其中的值
            LinkedListNode<string> node2 = list.Find("a");
            node.Value = "b";
            #endregion
            #endregion

            #region 遍历
            foreach(var a in list)
            {
                Console.WriteLine(a);
            }

            LinkedListNode<string> node3 = list.First;
            while(node3 != null)
            {
                Console.WriteLine(node3.Value);
                node3 = node3.Next;
            }
            #endregion
        }
    }
}