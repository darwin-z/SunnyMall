﻿using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Mall.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesBLL bll = new CategoriesBLL();

        private List<Categories> GetCategories(string key = "")
        {
            TempData["Search"] = key;
            return bll.ListEntity(key);
        }

        [AdminAuthentication]
        public ActionResult Index(int? id = 1, string key = "")
        {
            var cates = GetCategories(key);
            if(key.Length > 0)
            {
                TempData["Message"] = $"检索到{cates.Count()}条数据";
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", cates.ToPagedList(id.Value, 10));
            }
            return View(cates.ToPagedList(id.Value,10));
        }


        [AdminAuthentication]
        public ActionResult Delete(int? id, int? pageIndex = 1, string key = "")
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cate = bll.FindEntityById(id.Value);
            if(cate.Categories1.Count > 0 || cate.Products.Count > 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (bll.DeleteEntityById(id.Value))
            {
                return PartialView("_Index", GetCategories(key).ToPagedList(pageIndex.Value, 10));
            }
            else
            {
                TempData["Message"] = "无效的ID";
            }

            return RedirectToAction("Index");
        }

        [AdminAuthentication]
        public ActionResult Update(int? id)
        {
            ViewBag.CateGroups = bll.ListEntityByCondition(c => !c.ParentID.HasValue);
            var createsub = Request.QueryString["createsub"];
            if (id.HasValue)
            {
                Categories c = bll.FindEntityById(id.Value);
                return View(c);
            }
            if (createsub != null)
            {
                Categories c = new Categories();
                c.ParentID = int.Parse(createsub);
                return View(c);
            }
            return View();
        }

        [HttpPost]
        [AdminAuthentication]
        public ActionResult Update(Categories c,int? id)
        {
            if (id.HasValue)
            {
                if (ModelState.IsValid && bll.UpdateEntity(c))
                {
                    TempData["Message"] = "更新成功";
                }
                else
                {
                    TempData["Message"] = "更新失败";
                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid && bll.AddEntity(c) != null)
                {
                    TempData["Message"] = "添加成功";
                }
                else
                {
                    TempData["Message"] = "添加失败";
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        [AdminAuthentication]
        public ActionResult States(int? id, int? pageIndex = 1, string key = "")
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories cates = bll.FindEntityById(id.Value);
            if (cates == null)
            {
                TempData["Message"] = "无效的ID";
            }
            cates.States = cates.States == 0 ? 1 : 0;
            if (bll.UpdateEntity(cates))
            {
                return PartialView("_Index", GetCategories(key).ToPagedList(pageIndex.Value, 10));
            }
            return RedirectToAction("Index");
        }
    }
}