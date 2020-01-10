/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.database
 * 类名称：SqlDataAccessor
 * 创建时间：2016-12-26 16:28:46
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
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WindowsFormsMyT.database
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDataAccessor : IDataAccessor
    {
        private static object _lock = new object();//线程锁

        //获取sql连接
        private SqlConnection GetSqlConnection()
        {
            string strConn = "123";
// MohuFramework.Common.ConfigSettings.GetConnectionString();
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        public bool InsertEntity(IEntity entity)
        {
            SqlConnection conn = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                conn = GetSqlConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //生成sql语句
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                sql.Append("insert into " + type.Name + "(");
                sqlValue.Append(" values(");
                //string keyName = this.GetKeyName(type.Name);
                string keyName = "";
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName ||
                        info.GetValue(entity, null) == null)
                    {
                        continue;
                    }
                    sql.Append("[" + info.Name + "],");
                    sqlValue.Append("@" + info.Name + ",");
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@" + info.Name;
                    p.Value = info.GetValue(entity, null);
                    cmd.Parameters.Add(p);
                }
                string sqlGetId = "select max(" + keyName + ") from " + type.Name;
                string cmdText = sql.ToString().TrimEnd(new char[] { ',' }) + ")" +
                    sqlValue.ToString().TrimEnd(new char[] { ',' }) + ");" + sqlGetId;
                cmd.CommandText = cmdText;

                //找主键
                PropertyInfo pi = null;
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        pi = info;
                        break;
                    }
                }

                //执行并给ID赋值
                lock (_lock)
                {
                    object id = cmd.ExecuteScalar();
                    pi.SetValue(entity, id, null);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteEntity(IEntity entity)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;
            try
            {
                Type type = entity.GetType();
                PropertyInfo[] list = type.GetProperties();
                conn = GetSqlConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                string sql = "delete from " + type.Name + " where ";
               // string keyName = this.GetKeyName(type.Name);
                 string keyName ="";
                foreach (PropertyInfo info in list)
                {
                    if (info.Name == keyName)
                    {
                        sql += info.Name + "=" + info.GetValue(entity, null);
                        break;
                    }
                }
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public bool ExecuteNonQuery(string sqlstr)
        {
            return true;
        }
        public DataTable Query(string sql)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public IEntity GetEntity(IEntity entity)
        {
            return entity;
        }
        public bool UpdateEntity(IEntity entity)
        {
              return true;
        }
       public object ExecuteScalar(string sql)
        {
            return true;
        }
    }
}
