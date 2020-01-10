/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：MyClass3
 * 创建时间：2016-11-08 12:16:58
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
    public class MyClass3<T>
    {
        public delegate void GenericDelegate(T t);
        public void SomeMethod(T t)
        {
           
            Type type = typeof(T);
            if (type == t.GetType() )
            {
                System.Windows.Forms.MessageBox.Show("小静静的妹妹？");
            }
           
        }
    }
}
