﻿using Aop.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Properties;
using Models;
using Aop.Api.Request;
using Newtonsoft.Json;
using Aop.Api.Response;

namespace Mall.Controllers
{
    public class AlipayController : Controller
    {
        private static IAopClient client = new DefaultAopClient(
                                    Resources.GatewayUrl,
                                    Resources.AppID,
                                    Resources.MerchantPrivateKey,
                                    Resources.Format,
                                    Resources.Version,
                                    Resources.SignType,
                                    Resources.AlipayPublicKey,
                                    Resources.Charset);
        // GET: Alipay
        public ActionResult Index(Orders orders)
        {
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            request.SetReturnUrl(Resources.ReturnUrl);
            Dictionary<string, object> bizContent = new Dictionary<string, object>();
            bizContent.Add("out_trade_no",orders.SerialID);
            bizContent.Add("total_amount", orders.Total.Value.ToString("0.00"));
            bizContent.Add("subject","阳光商城支付宝收银台");
            bizContent.Add("product_code", "FAST_INSTANT_TRADE_PAY");
            bizContent.Add("goods_detail", orders.OrdersDetails.ToList());
            string contentJson = JsonConvert.SerializeObject(bizContent);
            request.BizContent = contentJson;
            AlipayTradePagePayResponse response = client.pageExecute(request);
            ContentResult content = new ContentResult();
            content.Content = response.Body;
            return content;
        }
    }
}