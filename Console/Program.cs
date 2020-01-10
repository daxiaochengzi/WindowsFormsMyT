using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsMyT;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //建立一个字符串集合,总数为1000
            List<string> list = new List<string>(1000);
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add("字符串:" + i);
            }

            MyQueue mq = new MyQueue(list);
            //保存最后一个值,等下用于做比较
            string last = list[list.Count - 1];
            //开启1000个线程,同时执行LootFirst方法,并打印出结果
            for (int i = 0; i < list.Capacity; i++)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    System.Console.WriteLine(mq.LootFirst());
                });
            }
            //在主线程中不停调用mq的遍历方法,这样的操作是很容易出现线程争抢资源的,如果没有锁定访问机制,就会出现异常
            while (mq.Count > 0)
            {
                foreach (var item in mq)
                {
                    //如果最后一个值还在,就输出 "还在"
                    if (item == last)
                    {
                        System.Console.WriteLine("还在");
                    }
                }
            }
        }
    }
}
