/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT
 * 类名称：Class2
 * 创建时间：2016-11-08 11:58:48
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
    public class MyClass2:MyBaseClass  //泛型参数虚方法的重写:子类方法必须重新定义该方法特定的泛型参数
    {
        public override void SomeMethod<X>(X x)
        {
            System.Windows.Forms.MessageBox.Show("大静静？");
        }
        public override void SomeMethod2<X>(X x,X b) //同时子类中的泛型方法不能重复基类泛型方法的约束，这一点和泛型类中的虚方法重写是有区别的
        {
            System.Windows.Forms.MessageBox.Show("小静静？");
        }
        ////错误 重写和显式接口实现方法的约束是从基方法继承的，因此不能直接指定这些约束
        //public override void SomeMethod2<X>(X x) where X:new()
        //{

        //}
    }
}
