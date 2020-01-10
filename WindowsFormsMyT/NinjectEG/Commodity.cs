/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：WindowsFormsMyT.NinjectEG
 * 类名称：Commodity
 * 创建时间：2016-11-14 15:54:39
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
    /// 货品
    /// </summary>
    public class Commodity
    {
        public string CommodityID { get; set; }
        public string Name { get; set; }
       public float Price { get; set; }

    }
     /// <summary>
     /// 货品计价规范
     /// </summary>
     public interface IValuation
     {
        float CommodityValuation(params Commodity[] commodities);
    }
 
    

     /// <summary>
     /// 计价折扣算法规范
     /// </summary>
     public interface IValuationDisCount
     {
         float ValuationDisCount(float listPrice);
     }

     /// <summary>
     /// 计价折扣算法规范实现一：九折 走起
     /// </summary>
     public class DisCount : IValuationDisCount
     {
         
         public float ValuationDisCount(float listPrice)
         {//1.5
             return listPrice - (listPrice * 10 / 100);
         }
     }
     /// <summary>
     /// 货品计价规范实现一：商品价格合计
     /// </summary>
     public class CommoditySumValuation : IValuation
     {
         //public float CommodityValuation(params Commodity[] commodities)
         //{
         //    return commodities.Sum(commodity => commodity.Price);
         //}

         private IValuationDisCount valuationDisCount;

         public CommoditySumValuation(IValuationDisCount valuationdiscount)
         {
             // 1.1
             this.valuationDisCount = valuationdiscount;
         }

         public float CommodityValuation(params Commodity[] commodities)
         {//1.4
             return valuationDisCount.ValuationDisCount(commodities.Sum(commodity => commodity.Price));
         }
     }
 }
