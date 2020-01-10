/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：MyClass1
 * 创建时间：2016-11-08 11:48:03
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
    //您无法为类级别的泛型参数提供方法级别的约束。类级别泛型参数的所有约束都必须在类作用范围中定义
        public class MyClass1<T> where T : IComparable<T> 
        {

            public void MyMethod<X>(X x, T t) where X : IComparable<X>
            {
                 System.Windows.Forms.MessageBox.Show("静静？");
            }
        }
    
}
