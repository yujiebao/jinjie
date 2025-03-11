using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 顺序存储和链式存储
{
    class LNode<T>
    {
        public T data;
        public LNode<T> next;
        public LNode<T> front;

        public LNode(T data)
        {
            this.data = data;
            this.next = null;
            this.front = null;
        }
        public LNode(T data, LNode<T> next, LNode<T> front)
        {
            this.data = data;
            this.next = next;
            this.front = front;
        }
        public LNode(T date, LNode<T> next)
        {
            this.data = date;
            this.next = next;
            this.front = null;
        }
        public override string ToString()
        {
            return data.ToString();
        }
        public LNode(LNode<T> front, T date)
        {
            this.front = front;
            this.data = date;
            this.next = null;
        }
        
    }

    class Pro3_Link<T>
    {
        public LNode<T> head;
        private LNode<T> tail;
        private int count;
        #region 创建链表
        public void init()
        {
            head = new LNode<T>(default(T));    //虚拟头结点
            tail = head;
            count = 0;
        }
        #endregion

        #region 操作
        #region 增添元素
        public void add(T data)
        {
            LNode<T> p = tail;
            p.next = new LNode<T>(p,data);
            tail = p.next;
            count++;
        }
        #endregion

        #region 删除元素
        #region 删除指定元素
        public void removeElem(T data)
        {
            LNode<T> p = head.next;
            while(p != tail)     
            {
                if(p.data.Equals(data))
                {
                 
                    p.front.next = p.next;   //更改前一个元素的next节点
                    p.next.front = p.front;
                    p.next = null;
                    p.front = null;
                    count--;
                    break;
                }
                p = p.next;  //p = tail.front 
            }
            if(p == tail && p.data.Equals(data))
            {
                p.front.next = p.next;
                tail = p.front;
                p.next = null;
                p.front = null;
                count--;
            }
        }
        #endregion

        #region 删除指定位置元素
        public T remove(int index)
        {
            if (index > count)
            {
                throw new Exception("超出链表长度");
            }
            LNode<T> p = head.next;
            for (int i = 0; i < index; i++)
            {
                p = p.next;
            }
            p.front.next = p.next;
            p.next.front = p.front;
            p.next = null;
            p.front = null;
            count--;
            return p.data;
        }
        #endregion
        #endregion

        #region 查找元素
        public bool contains(T data)
        {
            LNode<T> p = head;
            while (p != tail)
            {
                if (p.data.Equals(data))
                {
                    return true;
                }
                p = p.next;
            }
            return false;
        }
        #endregion

        #region 更改元素
        public void replace(int index, T data)
        {
            if (index > count)
            {
                throw new Exception("超出链表长度");
            }
            LNode<T> p = head.next;
            for(int i = 0; i < index; i++)
            {
                p = p.next;
            }
            p.data = data;
        }
        #endregion
        #endregion

        #region  打印
        public void print()
        {
            LNode<T> p = head.next;  //第一个元素
            while (p != tail)
            {
                Console.Write(p.data + " ");
                p = p.next;
            }
            Console.Write(p.data);
            Console.WriteLine();
        }

        public void printF()
        {
            LNode<T> p = tail;
            while (p != head)
            {
                Console.Write(p.data + " ");
                p = p.front;
            }
            Console.WriteLine();
        }
        #endregion
    }
}
