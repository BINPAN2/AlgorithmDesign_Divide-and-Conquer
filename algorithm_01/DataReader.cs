using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


/*
 * 文件读取类
 */
public static class DataReader
{
    public static string  readDat(String filepath)
    {
        StreamReader sr = new StreamReader(filepath, Encoding.Default);
        String line;
        line = sr.ReadLine();
        return line;
    }
}

