/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.InterfaceEg
 * 类名称：person
 * 创建时间：2016-12-26 16:57:47
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
    public class person : IPeople, ITeacher, IStudent
    {

        string name = "";
        string sex = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public object teach()
        {
            string teachinfo = Name + " " + Sex + " 老师";
            return teachinfo;
          
        }
        public object study()
        {
            string teachinfo = Name + " " + Sex + " 学生";
            return teachinfo;
           
        }
    }
}
