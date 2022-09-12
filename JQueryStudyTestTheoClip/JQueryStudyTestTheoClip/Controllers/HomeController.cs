using JQueryStudyTestTheoClip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JQueryStudyTestTheoClip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public List<NhanVien> ListNhanVien = new List<NhanVien>() {
            new NhanVien()
            {
                id = 1,
                Hoten = "Châu Tinh Trì",
                Luong = 100000,
                TrangThai = true
            },
             new NhanVien()
            {
                id = 2,
                Hoten = "Trương Vô Kị",
                Luong = 200000,
                TrangThai = true
            },
              new NhanVien()
            {
              id = 3,
                Hoten = "Chu Tước",
                Luong = 30000,
                TrangThai = true
            },
               new NhanVien()
            {
                id = 4,
                Hoten = "Tô Kim Đào",
                Luong = 500000,
                TrangThai = false
            }
        };


        [HttpGet]
        public JsonResult LoadNhanVien()
        {
            //var ListNhanVien = new List<NhanVien>();
            //ListNhanVien.Add(new NhanVien()
            //{
            //    id = 1,
            //    Hoten = "Châu Tinh Trì",
            //    Luong = 100000,
            //    TrangThai = true
            //});
            //ListNhanVien.Add(new NhanVien()
            //{
            //    id = 2,
            //    Hoten = "Châu Tinh Trí",
            //    Luong = 100000,
            //    TrangThai = true
            //});
            //ListNhanVien.Add(new NhanVien()
            //{
            //    id = 3,
            //    Hoten = "Châu Tinh Tri",
            //    Luong = 100000,
            //    TrangThai = true
            //});
            //ListNhanVien.Add(new NhanVien()
            //{
            //    id = 4,
            //    Hoten = "Châu Tinh Trĩ",
            //    Luong = 100000,
            //    TrangThai = true
            //});


            return Json(new
            {
                data = ListNhanVien,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            NhanVien employee = serializer.Deserialize<NhanVien>(model);

            var entity = ListNhanVien.Single(x => x.id == employee.id);
            entity.Luong = employee.Luong;
            return Json(new { status = true });
        }
    }
    
}