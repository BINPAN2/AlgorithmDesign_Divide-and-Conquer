using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
 * 
 * 居民点类
 * 
 * 
 */
public class Village
{
    public Village(String[] position)
    {
        if (position.Length == 2)
        {
            x = int.Parse(position[0]);
            y = int.Parse(position[1]);
        }
    }
    public int x;//横坐标
    public int y;//纵坐标
}
