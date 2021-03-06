﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
using WX_Store.Filters;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace WX_Store.Controllers
{
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }//这里需要用public  依赖注入
        public IShowNewsService ShowNewsService { get; set; }//滚动新闻属性  依赖注入
        public IProService ProService { get; set; }
        public IShopCartService shopCartService { get; set; }
        // GET: Home
        [OAuth]
        public ActionResult Index()
        {
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;
            Session["cid"] = userInfo.openid;
            var shopcart = shopCartService.GetEntities(x => x.Cid == userInfo.openid);
            ViewBag.count = shopcart.Count();   
            //查询banner
            var GetBanner = BannerService.GetEntities(x => true);
            ViewBag.Banner = GetBanner.ToList();
            //查询滚动新闻
            var GetShowNews = ShowNewsService.GetEntities(x => true);
            ViewBag.ShowNews = GetShowNews.ToList();
            ViewBag.show11 = GetShowNews.Count();
            Session["count"]= shopcart.Count();
			Session["shownews"]= GetShowNews.Count();
			return View();
        }
        /// <summary>
        /// 搜索的分部视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Seach()
        {
            return PartialView();
        }
        public ActionResult SeachHtml()
        {
            return View();
        }
        /// <summary>
        /// ShowNews内容页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult News(int id)//利用路由规则
        {
            //查询处点击的新闻的信息
            var GetShowNews = ShowNewsService.GetEntity(x => x.id == id);
            //赋值
            ViewBag.ShowNews_Title = GetShowNews.Title;
            ViewBag.ShowNews_ConTent = GetShowNews.Content;
            ViewBag.ShowNews_Time = GetShowNews.CreateTime;
            return View();
        }
        //查询热销信息
        public ActionResult HotSell()
        {
            //查询热销商品信息 WxShop_Model Fish_Model
            var GetPro = ProService.GetEntities(x => x.IsHot = true).Take(3);
            ViewBag.Pro = GetPro.ToList();
            return PartialView();
        }
        //查询推荐信息
        public ActionResult tuijian()
        {
            //查询推荐商品信息
            var GetPro = ProService.GetEntities(x =>true).OrderByDescending(x=>x.IsHot).Take(1);
            ViewBag.Pro = GetPro.ToList();
            return PartialView();
        }
		public ActionResult seachHtml1()
		{
			string seach = Request["seach"];
			string sea = "%seach%";
			var seachAll = ProService.GetEntities(x => x.Name == sea);
			
			return Content(seachAll.Count().ToString());
		}
    }
}