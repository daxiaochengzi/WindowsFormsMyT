/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：MyClass
 * 创建时间：2016-11-08 11:13:34
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsMyT
{
    /// <summary>
    /// 
    /// </summary>
   // public class MyClass //(1)
     public class MyClass<T>
    {
        //指定MyMethod方法用以执行类型为X的参数
         public void MyMethod<X>(X x,X b)
         {
             //
             System.Windows.Forms.MessageBox.Show("确定要退出吗2？");
         }

        //此方法也可不指定方法参数
        public void MyMethod<X>()
        {
            System.Windows.Forms.MessageBox.Show("确定要退出吗1？");
            //
        }
        public void MyMethod<X>(X x) where X : IComparable<string> //泛型参数的约束
        {
            //
            System.Windows.Forms.MessageBox.Show("确定要退出吗3？");
        }

    }
}
