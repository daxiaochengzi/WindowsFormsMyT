/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：MyBaseClass
 * 创建时间：2016-11-08 11:58:20
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
    public class MyBaseClass
    {
        public virtual void SomeMethod<T>(T t)
        {
            //
        }
        public virtual void SomeMethod2<T>(T t,T b) where T : new()
        {
            // 
        }
    }
}
