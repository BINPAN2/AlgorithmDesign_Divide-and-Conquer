using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

/*
 * 邮局类
 */
public class PostOffice
    {
    static List<Village> villages = new List<Village>();
    static int x;
    static int y;

/**
 * 清除之前的运算数据
 */
    public void clear()
    {
        villages = new List<Village>();
        x = 0;
        y = 0;
    }

 /**
 * 获取邮局的位置
 * @return
 */
    public String getPosition()
    {
        return "(" + x + "," + y + ")";
    }

 /**
 * 根据居民点信息获取邮局的位置
 * @return
 */
    public String getPosition(String path)
    {
        setPosition(path);
        return "(" + x + "," + y + ")";
    }

 /**
 * 计算邮局应该建立的位置
 * @return
 */
    public void setPosition(String path)
    {
        getVillages(path);//获取居民点信息

        int[] px = new int[villages.Count()];
        int[] py = new int[villages.Count()];


        for (int i = 0; i < villages.Count(); i++)
        {
            px[i] = villages[i].x;
            py[i] = villages[i].y;
        }

        SearchPos p = new SearchPos();
        x = p.getPositionOnLine(px);
        y = p.getPositionOnLine(py);
    }

 /**
 * 获取邮局附近的居民点信息
 * @param path 信息文件地址
 */
    private void getVillages(String path)
    {
        string str;
        str = DataReader.readDat(path);
        Console.WriteLine(str);
        String[] villagesStr = str.Split(' ');
        foreach (var item in villagesStr)
        {
            string villagesStrTemp = item.Substring(1, item.Length - 2);
            villages.Add(new Village(villagesStrTemp.Split(',')));
        }

    }

}




