/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.InterfaceEg
 * 类名称：IPeople
 * 创建时间：2016-12-26 16:56:06
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

namespace WindowsFormsMyT.InterfaceEg
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPeople
    {
        string Name
        {
            get;
            set;
        }
        string Sex
        {
            get;
            set;
        }
    }
    interface ITeacher : IPeople
    {
        object  teach();
    }
    interface IStudent : IPeople
    {
        object study();
    }
}
