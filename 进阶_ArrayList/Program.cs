using System.Collections;
namespace 进阶_ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 Arraylist的本质
            //ArrayList是一个c#为我们封装好的类
            //它的本质是一个object类型的数组，
            //ArrayList类帮助我们实现了很多方法
            //比如数组的增删查改
            #endregion

            #region Arraylist的申明
              ArrayList array = new ArrayList();
            #endregion

            #region 增删查改
            //增加元素
            array.Add(1);
            array.Add("ssad");     //object数组 万物之父
            
            //插入元素
            array.Insert(0, "ssad");

            //删除
            array.Remove(1);
            array.RemoveAt(0);

           //是否存在
           array.Contains("ssad");

            //正向查找元素位置
            array.IndexOf("ssad");
            //反向
            array.LastIndexOf("ssad");

            //改
            array[0] = "ssad";


            #endregion
             
        
        }
    }
}