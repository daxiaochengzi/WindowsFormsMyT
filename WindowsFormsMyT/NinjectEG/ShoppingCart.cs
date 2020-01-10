/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.NinjectEG
 * 类名称：ShoppingCart
 * 创建时间：2016-11-14 15:57:42
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
    public class ShoppingCart
    {
        private IValuation _Valuation;
        public ShoppingCart(IValuation valuation)
        {//1.2
            _Valuation = valuation;
        }

        public float CommodityTotalPrice()
        {//1.3
            Commodity[] commodities =
            {
                new Commodity(){ CommodityID="A1", Price=14},
                new Commodity(){ CommodityID="A2", Price=76.5f},
                new Commodity(){ CommodityID="B2", Price=34.4f},
                new Commodity(){ CommodityID="C4", Price=23.1f}
            };

            return _Valuation.CommodityValuation(commodities);
        }

    }
}
