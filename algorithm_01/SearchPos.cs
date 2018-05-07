using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 * 计算邮局位置
 * 
 */

public class SearchPos
{
    /**
     * 获取邮局在一维的位置
     * array 该维度的数据源
     * 返回该维度的位置
     */
    public int getPositionOnLine(int[] array)
    {
        if (array.Length == 0)
        {
            return 0;
        }
        return randomizedSelect(array, 0, array.Length - 1, array.Length / 2 + 1);
    }

    /**
     * 选择一个中位数
     * a 数据源
     * start 数据的开始位置
     * end 数据的结束位置
     * wantNum 想获取第几大的数据
     * 返回第wantNum大的数据，相同数字也进入了排名
     */
    private int randomizedSelect(int [] a, int start, int end, int wantNum)
    {
        if (start == end)
        {
            return a[start];
        }
        else if (start + 1 == end)
        {
            if (a[start] > a[end])
            {
                swap(a, start, end);
            }
            return wantNum == 1 ? a[start] : a[end];
        }

        //获取中位数的位置并根据中位数进行划分
        int i = randomizedPartition(a, start, end);

        //获取中位数是分段中的第几大
        int j = i - start + 1;

        if (wantNum == j)
        {
            return a[i];
        }
        else if (wantNum < j)
        {
            return randomizedSelect(a, start, i - 1, wantNum);
        }
        else
        {
            return randomizedSelect(a, i + 1, end, wantNum - j);
        }
    }

    /**
     * 获取中位数的位置，并将数组根据中位数进行一次快排
     * array 数据源
     * begin 数据的开始位置
     * end   数据结束位置
     */
    private int randomizedPartition(int[] array, int begin, int end)
    {
        return getMidNum(array, begin, end, 5);
    }

    /**
     * 将数组根据中位数划分为三部分，并将其中位数的位置返回来
     * array 原始数据源
     * begin 数组开始位置
     * end   数组结束位置
     * length 截取长度
     * 返回最终的中位数
     */
    private int getMidNum(int[] array, int begin, int end, int length)
    {
        int[] newArray = new int[end - begin + 1];
        Array.Copy(array, begin, newArray, 0, newArray.Length);
        int midNum = getMidArray(newArray, length)[0];

        /**
         * 准备将数组根据中值划分为三部分
         */
        for (int i = 0; i < newArray.Length; i++)
        {
            if (newArray[i] == midNum)
            {//将中值替换到开头
                swap(array, begin, begin + i);
                break;
            }
        }
        /**
         * 划分为三部分,并返回中值的位置
         */
        return quickLevel1(array, begin, end);
    }

    /**
     * 进行快排的第一遍排序操作，来划分数组
     * array 数据源
     * begin 快排的开始位置
     * end 	快排的结束位置
     */
    private int quickLevel1(int[] array, int begin, int end)
    {
        int head = begin;
        int tail = end;
        int cur = head;
        for (; head < tail;)
        {
            if (cur == head)
            {
                if (array[cur] >= array[tail])
                {//将尾部不超过当前的数据放到前面
                    swap(array, cur, tail);
                    cur = tail;
                    head++;
                }
                else
                {
                    tail--;
                }
            }
            else if (cur == tail)
            {
                if (array[cur] < array[head])
                {//将头部大于当前的数据放到前面
                    swap(array, cur, head);
                    cur = head;
                    tail--;
                }
                else
                {
                    head++;
                }
            }
        }
        return cur;
    }

    /**
     * 交换数组中的两个数
     * array 数据源
     * a 交换位置a
     * b 交换位置b
     */
    private void swap(int[] array, int a, int b)
    {
        int copyA = array[a];
        array[a] = array[b];
        array[b] = copyA;
    }

    /**
     * 获取中位数数组
     * array 数据源
     * length 切分数组的长度
     * 返回截取的中位数数组
     */
    private int[] getMidArray(int[] array, int length)
    {
        int midSize = array.Length / length;
        if (midSize > 1)
        {
            int[] midResult = new int[midSize];
            for (int i = 0; i < midResult.Length; i++)
            {
                midResult[i] = getMidNumMini(array, i * length, length);
            }
            return getMidArray(midResult, length);
        }
        else
        {
            return new int[] { getMidNumMini(array, 0, length) };//获取最后的中位数
        }
    }

    /**
     * 获取小范围的中位数
     * array 总的数据源
     * begin 数据截取的开始位置
     * length 数据截取的长度
     * 返回截取段的中位数
     */
    private int getMidNumMini(int[] array, int begin, int length)
    {
        if (array.Length == 1)
        {
            return array[begin];
        }
        else if (array.Length == 2)
        {
            return array[begin] > array[begin + 1] ? array[begin] : array[begin + 1];
        }

        int newLength = begin + length > array.Length ? array.Length - begin : length;
        List<int> arrayList = new List<int>();

        for (int i = begin; i < begin + newLength; i++)
        {
            arrayList.Add(array[i]);
        }

        arrayList.Sort((a, b)=>a - b);

        return arrayList[(arrayList.Count() / 2)];
    }
}

