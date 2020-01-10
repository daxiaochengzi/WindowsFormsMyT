using Ninject.Modules;
/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.Logger
 * 类名称：MyModule
 * 创建时间：2016-11-15 12:57:56
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
    public class MyModule:NinjectModule
    {
        public override void Load()
    {
        Bind<FileLogger>().ToSelf();
        Bind<ILogger>().To<DBLogger>();
        Bind<ITester>().To<NinjectTester>();
            //在Ninject中，我们可以通过重写Ninject.Modules.NinjectModule类的方法Load（）而实现依赖注入
            //Bind<T1>().To<T2>()
        //其实Bind就是接口IKernel的方法，把某个类绑定到某个接口，T1代表的就是接口或者抽象类，而T2代表的就是其实现类
    }
    }
}
