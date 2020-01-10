using Ninject;
/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.NinjectEG
 * 类名称：Samurai1
 * 创建时间：2016-11-15 14:33:05
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

namespace WindowsFormsMyT.NinjectEG
{
    /// <summary>
    /// 
    /// </summary>
    public class Samurai1
    {
         /// <summary>  
　　/// 勇士  
　　/// </summary>  
        private IWeapon _weapon;  
  
        [Inject]  
        public Samurai1(IWeapon weapon)  
        {  
            _weapon = weapon;  
        }  
  
        public string Attack(string target)  
        {  
          return  _weapon.Hit(target);  
        }  

    }
}
