﻿using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Mall.Controllers
{
    public class AppraisesController : Controller
    {
        UsersBLL usersBLL = new UsersBLL();
        ProductsBLL productsBLL = new ProductsBLL();
        AppraisesBLL appraisesBLL = new AppraisesBLL();

        private IEnumerable<Appraises> GetAppraise(string key = "")
        {
            TempData["Search"] = key;
            int uid = MyAuthentication.GetUserID();
            return appraisesBLL.ListEntity(key).Where(a => a.UserID == uid).ToList();
        }

        [UserAuthentication]
        public ActionResult Index(int? id = 1,string key = "")
        {
            var appraises = GetAppraise(key);
            if (key.Length > 0)
            {
                TempData["Message"] = $"检索到{appraises.Count()}条数据";
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", GetAppraise(key).ToPagedList(id.Value, 10));
            }
            return View(appraises.ToPagedList(id.Value, 10));
        }

        // GET: Appraises
        [UserAuthentication]
        public ActionResult Create(int id)
        {
            Products products = productsBLL.FindEntityById(id);
            Users users = usersBLL.FindEntityById(MyAuthentication.GetUserID());
            ViewBag.products = products;
            ViewBag.users = users;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [UserAuthentication]
        public ActionResult Create(Appraises a)
        {
            a.RateTime = DateTime.Now;
            if (ModelState.IsValid && (appraisesBLL.AddEntity(a) != null))
            {
                TempData["Message"] = "评价成功";
            }
            else
            {
                TempData["Message"] = "评价失败";
            }
            return RedirectToAction("Index");
        }

        [UserAuthentication]
        public ActionResult Update(int id)
        {
            return View(appraisesBLL.FindEntityById(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        [UserAuthentication]
        public ActionResult Update(Appraises a)
        {
            a.RateTime = DateTime.Now;
            if (ModelState.IsValid && appraisesBLL.UpdateEntity(a))
            {
                TempData["Message"] = "评价成功";
            }
            else
            {
                TempData["Message"] = "评价失败";
            }
            return RedirectToAction("Index");
        }

        // GET: Appraises
        [UserAuthentication]
        public ActionResult Delete(int id, int? pageIndex = 1, string key = "")
        {
            if(appraisesBLL.DeleteEntityById(id))
            {
                return PartialView("_Index", GetAppraise(key).ToPagedList(pageIndex.Value, 10));
            }
            else
            {
                TempData["Message"] = "删除失败";
                return RedirectToAction("Index");
            }
        }
    }
}