using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 测试类
 */

public class Test
{
    static void Main(string[] args)
    {
        PostOffice po = new PostOffice();
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine("第" + i + "组数据邮局选址位置为：" + po.getPosition("data/input_assign01_0" + i + ".txt"));
            po.clear();
        }
        Console.ReadKey();
    }
}
