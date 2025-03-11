namespace List排序
{
    class Item : IComparable<Item>
    {
        public int money;

        public Item(int money)
        {
            this.money = money;
        }

        public int CompareTo(Item? other)
        {
            //小于0 放在传入对象的前面
            //等于0 保持当前位置不变
            //大于0 放在传入对象的后面

            //可以简单理解 传入对象的位置 就是θ
            //如果你的返回为负数 就放在它的左边 也就前面
            //如果你返回正数 就放在它的右边 也就是后面

            if(this.money < other.money)
                return -1;
            else if(this.money > other.money)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return money.ToString();
        }
    }

    class shopItem
    {
        public int id;

        public shopItem(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 List的排序
            /*List<int> list = new List<int>();
            list.Add(3);
            list.Add(8);
            list.Add(2);
            list.Add(9);
            list.Add(7);
            list.Add(4);
            list.Add(1);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Sort();
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }*/
            #endregion

            #region 知识点二  自定义类的排序
            /*List<Item> list = new List<Item>();
            list.Add(new Item(11));
            list.Add(new Item(7));
            list.Add(new Item(9));
            list.Add(new Item(4));
            list.Add(new Item(6));
            list.Add(new Item(8));
            list.Add(new Item(5));
            list.Add(new Item(10));
            list.Add(new Item(3));
            
            for(int i = 0; i < list.Count; i++)
                    Console.WriteLine(list[i]);
            list.Sort();
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);*/
            #endregion

            #region 知识点三 通过委托函数进行排序
            List<shopItem> list = new List<shopItem>();
            list.Add(new shopItem(11));
            list.Add(new shopItem(7));
            list.Add(new shopItem(9));
            list.Add(new shopItem(4));
            list.Add(new shopItem(6));
            list.Add(new shopItem(8));
            list.Add(new shopItem(5));
            list.Add(new shopItem(10));
            list.Add(new shopItem(3));
            for(int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();
            //list.Sort(sortShopItem);    //sortShopItem可以改为委托函数(Lambad)
            list.Sort((a, b) => { return b.id - a.id; });
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            #endregion
        }

        static int sortShopItem(shopItem a, shopItem b)
        {
            //传入的两个对象 为列表中的两个对象
            //进行两两的比较 用左边的和右边的条件 比较
            //返回值规则 和之前一样 0做标准 负数在左(前)  正数在右(后)
            if(a.id < b.id)
                return -1;
            else if(a.id > b.id)
                return 1;
            else
            return 0;
        }
    }
}