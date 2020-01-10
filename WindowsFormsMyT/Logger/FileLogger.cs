/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.Logger
 * 类名称：FileLogger
 * 创建时间：2016-11-15 12:54:50
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

namespace WindowsFormsMyT.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class FileLogger : ILogger
    {
        public string Write(string message)
        {
            return message;
        }
    }
}
