using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStockTool
{
    /// <summary>
    /// 股票信息
    /// </summary>
    public class StockInfo
    {
        /// <summary>
        /// 类型，上证或者深证
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        public string Open { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public string Close { get; set; }

        /// <summary>
        /// 当前价格
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 今日最高价
        /// </summary>
        public string High { get; set; }

        /// <summary>
        /// 今日最低价
        /// </summary>
        public string Low { get; set; }

        /// <summary>
        /// 竞买价，即“买一”报价；
        /// </summary>
        public string BidBuy { get; set; }

        /// <summary>
        /// 竞卖价，即“卖一”报价；
        /// </summary>
        public string BidSell { get; set; }

        /// <summary>
        /// 成交的股票数，由于股票交易以一百股为基本单位，所以在使用时，通常把该值除以一百；
        /// </summary>
        public string Volume { get; set; }

        /// <summary>
        /// 成交金额，单位为“元”，为了一目了然，通常以“万元”为成交金额的单位，所以通常把该值除以一万；
        /// </summary>
        public string Turnover { get; set; }

        /// <summary>
        /// “买一”申请4695股，即47手；
        /// </summary>
        public string BuyOne { get; set; }

        /// <summary>
        /// 买一”报价；
        /// </summary>
        public string BuyOnePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyTwo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyTwoPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyThree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyThreePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyFour { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyFourPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyFive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BuyFivePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellOne { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellOnePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellTwo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellTwoPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellThree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellThreePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellFour { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellFourPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellFive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SellFivePrice { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 涨跌幅，昨天收盘价 - 当前价
        /// </summary>
        public string Increase { get; set; }

        /// <summary>
        /// 涨跌率，涨跌幅 / 昨天收盘价 * 100
        /// </summary>
        public string IncreaseRate { get; set; }

        /// <summary>
        /// 涨跌颜色，涨为红色，跌为绿色，不变为白色
        /// </summary>
        public string Color { get; set; }
    }
}
