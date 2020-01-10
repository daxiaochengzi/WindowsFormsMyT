using Ninject;
/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.NinjectEG
 * 类名称：Samurai
 * 创建时间：2016-11-15 10:18:46
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
    /// 勇士
    /// </summary>
    public class Samurai
    {
        private IWeapon _weapon;

        //[Inject]  
        //public Samurai(IWeapon weapon)
        //{
        //    _weapon = weapon;
        //}
        /// <summary>  
        /// 定义注入接口属性  
        /// </summary>  
        [Inject]
        public IWeapon Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
            }
        }
        [Inject]
        public void Arm(IWeapon weapon)
        {
            _weapon = weapon;
        }
        public string  Attack(string target)
        {
           return _weapon.Hit(target);
            
        }
    }
}
