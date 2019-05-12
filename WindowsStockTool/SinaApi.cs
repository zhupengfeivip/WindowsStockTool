using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStockTool
{
    public class SinaApi
    {
        /// <summary>
        /// 新浪获取股票数据接口，支持多个
        /// http://hq.sinajs.cn/list=sh601003,sh601001
        /// var hq_str_sh601003="柳钢股份,6.320,6.270,6.400,6.410,6.250,6.400,6.410,14132447,89830396.000,298300,6.400,146807,6.390,209900,6.380,23500,6.370,12900,6.360,175600,6.410,106600,6.420,52100,6.430,58800,6.440,83300,6.450,2019-05-10,15:00:00,00";
        /// var hq_str_sh601001 = "大同煤业,4.620,4.580,4.720,4.740,4.560,4.720,4.730,24263517,113214834.000,107600,4.720,327800,4.710,91200,4.700,60200,4.690,116800,4.680,111834,4.730,172800,4.740,231800,4.750,51400,4.760,37000,4.770,2019-05-10,15:00:07,00";
        /// </summary>
        private static string SinaDataAPI = "http://hq.sinajs.cn/list=";

        /// <summary>
        /// 
        /// </summary>
        private static string SinaDailyChartAPI = "http://image.sinajs.cn/newchart/min/n/";

        /// <summary>
        /// 
        /// </summary>
        private static string SinaKLineAPI = "http://image.sinajs.cn/newchart/daily/n/";

        /// <summary>
        /// 获取详情页地址
        /// </summary>
        /// <param name="type"></param>
        /// <param name="StockCode"></param>
        /// <returns></returns>
        public static string GetDetailUrl(string type, string StockCode)
        {
            return $"https://finance.sina.com.cn/realstock/company/{type}{StockCode}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StockCode"></param>
        /// <returns></returns>
        public static string GetDailyChartURL(string StockCode)
        {
            return SinaDailyChartAPI + StockCode + ".gif";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StockCode"></param>
        /// <returns></returns>
        public static string GetKLineURL(string StockCode)
        {
            return SinaKLineAPI + StockCode + ".gif";
        }

        /// <summary>
        /// 获取股票列表信息
        /// </summary>
        /// <param name="CodeBeingTested"></param>
        /// <returns></returns>
        public static Dictionary<string, StockInfo> CodeInspector(string CodeBeingTested)
        {
            Dictionary<string, StockInfo> valuePairs = new Dictionary<string, StockInfo>();
            string RetValue = HttpOperator.HttpGet(SinaDataAPI, CodeBeingTested, "GB2312", "gb2312");

            if (RetValue.Length <= 25)
                return valuePairs;

            string[] stockList = RetValue.Split(';');
            foreach (string stock in stockList)
            {
                if (string.IsNullOrWhiteSpace(stock)) continue;

                StockInfo info = InitSingleStockInfo(stock);
                valuePairs.Add(info.Code, info);
            }

            return valuePairs;
        }

        /// <summary>
        /// 
        /// var hq_str_sh601003="柳钢股份,6.320,6.270,6.400,6.410,6.250,6.400,6.410,14132447,89830396.000,298300,6.400,146807,6.390,209900,6.380,23500,6.370,12900,6.360,175600,6.410,106600,6.420,52100,6.430,58800,6.440,83300,6.450,2019-05-10,15:00:00,00";
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private static StockInfo InitSingleStockInfo(string stock)
        {
            string[] Metas = stock.Trim().Replace("\"", "").Replace("var hq_str_", "").Split(',');

            var Info = new StockInfo();
            Info.Type = Metas[0].Trim().Substring(0, 2);
            string[] strTemps = Metas[0].Split('=');
            Info.Code = strTemps[0].Replace(Info.Type, "");
            Info.Name = strTemps[1];
            Info.Open = Metas[2];
            Info.Close = Metas[3];
            Info.Price = Metas[4];
            Info.High = Metas[5];
            Info.Low = Metas[6];
            Info.BidBuy = Metas[7];
            Info.BidSell = Metas[8];
            Info.Volume = Metas[9];
            Info.Turnover = Metas[10];
            Info.BuyOne = Metas[11];
            Info.BuyOnePrice = Metas[12];
            Info.BuyTwo = Metas[13];
            Info.BuyTwoPrice = Metas[14];
            Info.BuyThree = Metas[15];
            Info.BuyThreePrice = Metas[16];
            Info.BuyFour = Metas[17];
            Info.BuyFourPrice = Metas[18];
            Info.BuyFive = Metas[19];
            Info.BuyFivePrice = Metas[20];
            Info.SellOne = Metas[21];
            Info.SellOnePrice = Metas[22];
            Info.SellTwo = Metas[23];
            Info.SellTwoPrice = Metas[24];
            Info.SellThree = Metas[25];
            Info.SellThreePrice = Metas[26];
            Info.SellFour = Metas[27];
            Info.SellFourPrice = Metas[28];
            Info.SellFive = Metas[29];
            Info.SellFivePrice = Metas[30];
            Info.Date = Metas[31];
            Info.Time = Metas[32];
            float IncreaseNum = float.Parse(Info.Price) - float.Parse(Info.Close);
            Info.Increase = IncreaseNum.ToString("F2");
            Info.IncreaseRate = (IncreaseNum / float.Parse(Info.Close) * 100).ToString("F2") + "%";
            Info.Color = IncreaseNum < 0 ? "Green" : (IncreaseNum == 0 ? "WhiteSmoke" : "Red");
            return Info;
        }

    }
}
