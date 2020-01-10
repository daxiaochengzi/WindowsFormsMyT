/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.database
 * 类名称：IDataAccessor
 * 创建时间：2016-12-26 16:21:25
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsMyT.database
{
    /// <summary>
    /// 数据库操作接口定义
    /// </summary>
    public interface IDataAccessor
    {
        bool ExecuteNonQuery(string sql);
        DataTable Query(string sql);
        bool InsertEntity(IEntity entity);
        IEntity GetEntity(IEntity entity);
        bool UpdateEntity(IEntity entity);
        bool DeleteEntity(IEntity entity);
        object ExecuteScalar(string sql);
    }
}
