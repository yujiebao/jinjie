using System.Collections;

namespace 哈希表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 hashtable的本质
            //哈希表(又称散列表)，是基于键的哈希代码组织起来的   键/键对
            //作用是提高数据查询的效率
            //使用键来访问集合中的元素
            #endregion

            #region 申明哈希表
            Hashtable ht = new Hashtable();
            #endregion

            #region 增删查改
            //增   不要出现相同的键
            ht.Add(1, 13);
            ht.Add(2, 15);
            ht.Add("name", "张三");
            ht.Add("age", 18);
            ht.Add("sex", "男");

            //删
            //1.只能通过键删除
            ht.Remove(1);
            //2.删除不存在的元素  没反应
            ht.Remove(100);
            //3.直接清空
            ht.Clear();

            //查
            //1.通过键去查   查不到返回空
            Console.WriteLine(ht[1]);
            Console.WriteLine(ht["age"]);


            //2.查看是否存在
                //根据键检测 
                ht.ContainsKey(1);
            //根据值检测
            ht.ContainsValue("张三");

            //改 
            //只能改键对应的值 无法修改键
            ht[1] = true;
            #endregion

            #region 遍历
            //1.Hashtable.Count 得到键值对数目
            
            //遍历所有键
            foreach (object item in ht.Keys)
            {
                Console.WriteLine("键"+item);
                Console.WriteLine("值：" + ht[item]);
            }

            //遍历所有值
            foreach (object item in ht.Values)
            {
                Console.WriteLine("值" + item);  //无法通过值获取键
            }

            //遍历所有键值对
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("键值对" + item);
            }

            //迭代器遍历
            IDictionaryEnumerator myEnumerator =  ht.GetEnumerator();
            bool flag = myEnumerator.MoveNext();
            while(flag)
            {
                Console.WriteLine("键 "+myEnumerator.Key+"值 " + myEnumerator.Value);
                flag  = myEnumerator.MoveNext();
            }
            #endregion

        }
    }
}