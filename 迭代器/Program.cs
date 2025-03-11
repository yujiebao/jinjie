using System.Collections;

namespace 迭代器
{
    #region 知识点一 迭代器是什么
    //迭代器(iterator)有时又称光标(cursor)
    //是程序设计的软件设计模式
    //迭代器模式提供一个方法顺序访问一个聚合对象中的各个元素
    //而又不暴露其内部的标识

    //在表现效果上看
    //是可以在容器对象(例如链表或数组)上遍历访问的接口
    //设计人员无需关心容器对象的内存分配的实现细节
    //可以用foreach遍历的类，都是实现了迭代器的
    #endregion

    #region 知识点二 标准迭代器的实现方法
    //关键接口:IEnumerator,IEnumerable
    //命名空间:using system.collections;
    //可以通过同时继承IEnumerable和IEnumerator实现其中的方法
    #endregion

    #region 知识点三 用yield return 语法糖实现迭代器
    //yield return 是c#提供给我们的语法糖
    //所谓语法糖，也称糖衣语法
    //主要作用就是将复杂逻辑简单化，可以增加程序的可读性
    //从而减少程序代码出错的机会

    //关键接口:IEnumerable
    //命名空间:using system.collections;
    //让想要通过foreach遍历的自定义类实现接口中的方法GetEnumerator即可
    #endregion

    #region 知识点四 用yield return 语法糖为泛型类实现迭代器
    class CustomList<T> : IEnumerable
    {
        private T[] array;
        public CustomList(params T[] array)
        {
            this.array = array;
        }
        public IEnumerator GetEnumerator()
        { 
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
    #endregion
    class CustomList :IEnumerable,IEnumerator
    {
        private int[] list;
        private int position = -1;  //从-1开始的光标 用于表示 数据得到了哪个位置
        public CustomList()
        {
            list = new int[] {1,2,3,4,5,6,7,8,9 };
        }

        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
        #endregion

        #region IEnumerator
        public object Current
        {
            get { return list[position];  }
        
        }
        public bool MoveNext()
        {
            ++position;
            //是否溢出
            return position < list.Length;
        }

        public void Reset()  //将光标复原  一般写在GetEnumerator中
        {
            position = -1;
        }
        #endregion
    }

    class CustomList2 : IEnumerable
    {
        private int[] list;
        public CustomList2()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,11};
        }
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < list.Length; i++)
            {
                //yield return 关键字 配合迭代器使用
                //可以理解为 暂时返回 保留当前的状态
                //一会还会再回来
                //C#语法糖
                yield return list[i];
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>(1,2,3,5,65,9,49,8);

            //foreach的本质
            //1.先获取in后面这个对象的IEnumerator
            //      会调用对象其中的GetEnumerator方法 来获取  只要有GetEnumerator方法就行，接口不实现也不报错
            //2.执行得到的IEnumerator中的MoveNext方法
            //3.如果MoveNext方法返回true,则执行Current方法 获取当前位置的值  然后赋值给 item
            //4.如果MoveNext方法返回false,则结束循环
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
//总结:
 //迭代器就是可以让我们在外部直接通过foreach遍历对象中元素而不需要了解其结构
 //主要的两种方式
 //1.传统方式 继承两个接口 实现里面的方法
 //2.用语法糖 yield return 去返回内容 只需要继承一个接口即可