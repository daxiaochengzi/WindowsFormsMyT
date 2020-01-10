/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：TaskType
 * 创建时间：2017-10-24 16:58:43
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsMyT
{
    /// <summary>
    /// 
    /// </summary>
    public enum TaskType
    {
        
        [Description("管网")]
        Pipe = 0,
        [Description("水厂")]
        Waterworks = 1,
        [Description("维护")]
        Maintain = 2,

    }
}
