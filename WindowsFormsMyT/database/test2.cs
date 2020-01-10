/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.database
 * 类名称：test2
 * 创建时间：2016-12-26 16:25:10
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

namespace WindowsFormsMyT.database
{
    /// <summary>
    /// 
    /// </summary>
    public class test2:IEntity
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _names;
        public string names
        {
            get { return _names; }
            set { _names = value; }
        }
        private string _nothing;
        public string nothing
        {
            get { return _nothing; }
            set { _nothing = value; }
        }
    }
}
