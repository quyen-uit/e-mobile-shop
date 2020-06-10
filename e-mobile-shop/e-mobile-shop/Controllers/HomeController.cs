using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using e_mobile_shop.Models;
using e_mobile_shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using e_mobile_shop.Controllers.Components;
using Microsoft.AspNetCore.Http;
using e_mobile_shop.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace e_mobile_shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
   
            return View(DataAccess.ViewSanPham());
        }


        public async Task<IActionResult> Filter(
            string sortOrder,    
            string currentFilter,    
            string giaTien,    
            int? pageNumber, 
            string loaiSp,
            string tenSp)
        {
           
            //sort order
            ViewData["CurrentSort"] = sortOrder;
            if(string.IsNullOrEmpty(sortOrder))
            {
                ViewData["SortByPrice"] = "";
            }
            if (sortOrder == "high_first")
            {
                ViewData["SortByPrice"] = "high_first";
            }
            else if (sortOrder=="low_first")
            {
                ViewData["SortByPrice"] = "low_first";
            }else if(sortOrder=="view_first")
            {
                ViewData["SortByPrice"] = "view_first";
            } else if(sortOrder=="buy_first")
            {
                ViewData["SortByPrice"] = "buy_first";
            }

           

            if (giaTien != null)
            {
                pageNumber = 1;
            }
            else
            {
                giaTien = currentFilter;
            }
            ViewData["CurrentFilter"] = giaTien;
            var sanphams = from s in DataAccess.context.SanPham  select s;

            //filter by name 
            if (!String.IsNullOrEmpty(tenSp))
            {
                ViewData["TenSp"] = tenSp;
                sanphams = sanphams.Where(s => s.TenSp.ToLower().Contains(tenSp.ToLower()));
            }
<<<<<<< Updated upstream
            
=======

            //filter by cấu hình 
            if (!String.IsNullOrEmpty(params_list) && !String.IsNullOrEmpty(loaiSp))
            {
                sanphams = sanphams.Where(s => s.LoaiSp == loaiSp);

                //for Laptop 
                if (loaiSp == "LSP0008")
                {
                    foreach (var _param in params_list.Split('&'))
                    {
                        if (!String.IsNullOrEmpty(_param))
                        {
                            if (_param.Contains('f'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (var _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            var a1 = from s in DataAccess.context.SanPham
                                                     join t in DataAccess.context.ThongSoKiThuat
                                                      on s.MaSp equals t.MaSp
                                                     where (t.GiaTri.Contains(_sub_param) && t.ThongSo.Contains("TS0001"))
                                                     select s;
                                            _filter_.Add(a1);
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('j'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            var a1 = from s in DataAccess.context.SanPham
                                                     join t in DataAccess.context.ThongSoKiThuat
                                                      on s.MaSp equals t.MaSp
                                                     where (t.GiaTri.ToLower().Contains(_sub_param.ToLower()) == true && t.ThongSo.Contains("TS0002"))
                                                     select s;
                                            _filter_.Add(a1);
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('w'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            if (_sub_param == "type_1") //học tập
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("vivo")
                                                        || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                        || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param.Contains("type_2")) //đồ họa 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param == "type_3") //văn phòng 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                        select s;
                                                _filter_.Add(a);
                                            }
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('z'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {

                                            var a1 = from s in DataAccess.context.SanPham
                                                     join t in DataAccess.context.ThongSoKiThuat
                                                      on s.MaSp equals t.MaSp
                                                     where (t.GiaTri.ToLower().Contains(_sub_param.ToLower()) || s.TenSp.ToLower().Contains(_sub_param))
                                                     select s;
                                            _filter_.Add(a1);

                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                        }
                    }
                }
                else if (loaiSp == "LSP0002")
                {
                    foreach (var _param in params_list.Split('&'))
                    {
                        if (!String.IsNullOrEmpty(_param))
                        {
                            if (_param.Contains('f'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (var _sub_param in _tmp_param_1.Split('-'))
                                    {
                                       
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            var a1 = from s in DataAccess.context.SanPham
                                                     join t in DataAccess.context.ThongSoKiThuat
                                                     on s.MaSp equals t.MaSp
                                                     where (t.GiaTri.ToLower().Contains(_sub_param))
                                                     select s;
                                            _filter_.Add(a1);
                                           
                                           
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('j'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            switch (_sub_param)
                                            {
                                                case "small":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (Convert.ToInt32(t.GiaTri.Substring(0,4))<= 4000 && t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "big":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (4000< Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                 Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) <= 5000 &&
                                                                 t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "super":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (5000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                 t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('w'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            if (_sub_param == "type_1") //học tập
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("vivo")
                                                        || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                        || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param.Contains("type_2")) //đồ họa 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param == "type_3") //văn phòng 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                        select s;
                                                _filter_.Add(a);
                                            }
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('z'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            switch (_sub_param)
                                            {
                                                case "mongmat":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0028"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }

                                                case "khuonmat":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0029"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "vantay":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0027"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                            }
                                            
                                            

                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                        }
                    }
                }
                else if (loaiSp == "LSP0007")
                {
                    foreach (var _param in params_list.Split('&'))
                    {
                        if (!String.IsNullOrEmpty(_param))
                        {
                            if (_param.Contains('f'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (var _sub_param in _tmp_param_1.Split('-'))
                                    {

                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            var a1 = from s in DataAccess.context.SanPham
                                                     join t in DataAccess.context.ThongSoKiThuat
                                                     on s.MaSp equals t.MaSp
                                                     where (t.GiaTri.ToLower().Contains(_sub_param))
                                                     select s;
                                            _filter_.Add(a1);


                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('j'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            switch (_sub_param)
                                            {
                                                case "small":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (Convert.ToInt32(t.GiaTri.Substring(0, 4)) <= 4000 && t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "big":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (4000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                 Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) <= 5000 &&
                                                                 t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "super":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (5000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                 t.ThongSo.Contains("TS0018"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('w'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            if (_sub_param == "type_1") //học tập
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("vivo")
                                                        || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                        || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param.Contains("type_2")) //đồ họa 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                        || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                        select s;
                                                _filter_.Add(a);
                                            }
                                            else if (_sub_param == "type_3") //văn phòng 
                                            {
                                                var a = from s in DataAccess.context.SanPham
                                                        join t in DataAccess.context.ThongSoKiThuat
                                                        on s.MaSp equals t.MaSp
                                                        where s.LoaiSp == "LSP0008"
                                                        &&
                                                        (s.TenSp.Contains("macbook")
                                                        || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                        select s;
                                                _filter_.Add(a);
                                            }
                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                            else if (_param.Contains('z'))
                            {
                                string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (_param.Length > 1)
                                {
                                    var _filter_ = new List<IQueryable<SanPham>>();
                                    foreach (string _sub_param in _tmp_param_1.Split('-'))
                                    {
                                        if (!String.IsNullOrEmpty(_sub_param))
                                        {
                                            switch (_sub_param)
                                            {
                                                case "mongmat":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0028"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }

                                                case "khuonmat":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0029"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                                case "vantay":
                                                    {
                                                        var a1 = from s in DataAccess.context.SanPham
                                                                 join t in DataAccess.context.ThongSoKiThuat
                                                                  on s.MaSp equals t.MaSp
                                                                 where (t.ThongSo.Contains("TS0027"))
                                                                 select s;
                                                        _filter_.Add(a1);
                                                        break;
                                                    }
                                            }



                                        }
                                    }
                                    _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                    sanphams = sanphams.Intersect(_filter_[0]);
                                }
                            }
                        }
                    }
                }

            }

            //filter by NSX 
            if (!String.IsNullOrEmpty(hangSx))
            {
                ViewData["HangSx"] = hangSx;
                sanphams = sanphams.Where(s => s.Nsx == hangSx);
            }
>>>>>>> Stashed changes

            //filter by price
            if (!String.IsNullOrEmpty(giaTien))
            {
                string[] paramStrs = new string[2];
                if (giaTien.Contains('-'))
                {
                    paramStrs = giaTien.Split('-');
                    sanphams = sanphams.Where(s => s.GiaGoc <= int.Parse(paramStrs[1]) && s.GiaGoc >= int.Parse(paramStrs[0]));
                }
                else
                {
                    paramStrs[0] = giaTien;
                    paramStrs[1] = "";
                    sanphams = sanphams.Where(s => s.GiaGoc <= int.Parse(paramStrs[0]));
                }
            }

            //filter by type 
            if(!string.IsNullOrEmpty(loaiSp))
            {
                ViewData["LoaiSp"] = loaiSp;

                if (loaiSp != "00000")
                {
                    sanphams = sanphams.Where(x => x.LoaiSp == loaiSp);
                }
                else
                {
                    sanphams = sanphams.Where(x => x.LoaiSp != "15674" && x.LoaiSp != "87356" && x.LoaiSp != "89742");
                }
            }
            switch (sortOrder)
            {
                case "high_first":
                    sanphams = sanphams.OrderByDescending(s => s.GiaGoc);
                    break;
                case "low_first":
                    sanphams = sanphams.OrderBy(s => s.GiaGoc);
                    break;
<<<<<<< Updated upstream
                
=======
                case "view_first":
                    sanphams = sanphams.OrderByDescending(s => s.SoLuotXemSp);
                    break;
                case "buy_first":
                    sanphams = sanphams.OrderByDescending(s => s.SoLuong);
                    break;
>>>>>>> Stashed changes
                default:
                    sanphams = sanphams.OrderByDescending(s => s.TenSp);
                    break;
            }
            int pageSize =12;
            return View(await PaginatedList<SanPham>.CreateAsync(sanphams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult TestPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TestPage(IFormCollection fc)
        {
            ViewData["giatien"] = fc["GiaTien"].ToString();
            return View();
        }
        public void GiaTien()
        {
            ViewData["giatien"] = "5000000";
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
        [HttpPost]
        public JsonResult GetNumberProduct(string paramslist)
        {
            var axb = paramslist.Split("%");
            var params_list = axb[0];
            var loaiSp = axb[1];
            var sanphams = from s in DataAccess.context.SanPham select s;
            if (paramslist!=null )
            {
                if (!String.IsNullOrEmpty(params_list) && !String.IsNullOrEmpty(loaiSp))
                {
                    sanphams = sanphams.Where(s => s.LoaiSp == loaiSp);

                    //for Laptop 
                    if (loaiSp == "LSP0008")
                    {
                        foreach (var _param in params_list.Split('&'))
                        {
                            if (!String.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (var _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                var a1 = from s in DataAccess.context.SanPham
                                                         join t in DataAccess.context.ThongSoKiThuat
                                                          on s.MaSp equals t.MaSp
                                                         where (t.GiaTri.Contains(_sub_param) && t.ThongSo.Contains("TS0001"))
                                                         select s;
                                                _filter_.Add(a1);
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('j'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                var a1 = from s in DataAccess.context.SanPham
                                                         join t in DataAccess.context.ThongSoKiThuat
                                                          on s.MaSp equals t.MaSp
                                                         where (t.GiaTri.ToLower().Contains(_sub_param.ToLower()) == true && t.ThongSo.Contains("TS0002"))
                                                         select s;
                                                _filter_.Add(a1);
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('w'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                if (_sub_param == "type_1") //học tập
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("vivo")
                                                            || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                            || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param.Contains("type_2")) //đồ họa 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param == "type_3") //văn phòng 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('z'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {

                                                var a1 = from s in DataAccess.context.SanPham
                                                         join t in DataAccess.context.ThongSoKiThuat
                                                          on s.MaSp equals t.MaSp
                                                         where (t.GiaTri.ToLower().Contains(_sub_param.ToLower()) || s.TenSp.ToLower().Contains(_sub_param))
                                                         select s;
                                                _filter_.Add(a1);

                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                            }
                        }
                    }
                    else if (loaiSp == "LSP0002")
                    {
                        foreach (var _param in params_list.Split('&'))
                        {
                            if (!String.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (var _sub_param in _tmp_param_1.Split('-'))
                                        {

                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                var a1 = from s in DataAccess.context.SanPham
                                                         join t in DataAccess.context.ThongSoKiThuat
                                                         on s.MaSp equals t.MaSp
                                                         where (t.GiaTri.ToLower().Contains(_sub_param))
                                                         select s;
                                                _filter_.Add(a1);


                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('j'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                switch (_sub_param)
                                                {
                                                    case "small":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (Convert.ToInt32(t.GiaTri.Substring(0, 4)) <= 4000 && t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "big":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (4000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                     Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) <= 5000 &&
                                                                     t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "super":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (5000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                     t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('w'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                if (_sub_param == "type_1") //học tập
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("vivo")
                                                            || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                            || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param.Contains("type_2")) //đồ họa 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param == "type_3") //văn phòng 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('z'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                switch (_sub_param)
                                                {
                                                    case "mongmat":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0028"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }

                                                    case "khuonmat":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0029"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "vantay":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0027"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                }



                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                            }
                        }
                    }
                    else if (loaiSp == "LSP0007")
                    {
                        foreach (var _param in params_list.Split('&'))
                        {
                            if (!String.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (var _sub_param in _tmp_param_1.Split('-'))
                                        {

                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                var a1 = from s in DataAccess.context.SanPham
                                                         join t in DataAccess.context.ThongSoKiThuat
                                                         on s.MaSp equals t.MaSp
                                                         where (t.GiaTri.ToLower().Contains(_sub_param))
                                                         select s;
                                                _filter_.Add(a1);


                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('j'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                switch (_sub_param)
                                                {
                                                    case "small":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (Convert.ToInt32(t.GiaTri.Substring(0, 4)) <= 4000 && t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "big":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (4000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                     Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) <= 5000 &&
                                                                     t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "super":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (5000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                                     t.ThongSo.Contains("TS0018"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('w'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "w", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                if (_sub_param == "type_1") //học tập
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("vivo")
                                                            || (t.GiaTri.Contains("i3") && t.ThongSo.Contains("TS0002"))

                                                            || (t.GiaTri.Contains("4") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param.Contains("type_2")) //đồ họa 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("i7") && t.ThongSo.Contains("TS0002"))
                                                            || (t.GiaTri.Contains("8") && t.ThongSo.Contains("TS0001")))
                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                                else if (_sub_param == "type_3") //văn phòng 
                                                {
                                                    var a = from s in DataAccess.context.SanPham
                                                            join t in DataAccess.context.ThongSoKiThuat
                                                            on s.MaSp equals t.MaSp
                                                            where s.LoaiSp == "LSP0008"
                                                            &&
                                                            (s.TenSp.Contains("macbook")
                                                            || (t.GiaTri.Contains("i5") && t.ThongSo.Contains("TS0002")))

                                                            select s;
                                                    _filter_.Add(a);
                                                }
                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                                else if (_param.Contains('z'))
                                {
                                    string _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (_param.Length > 1)
                                    {
                                        var _filter_ = new List<IQueryable<SanPham>>();
                                        foreach (string _sub_param in _tmp_param_1.Split('-'))
                                        {
                                            if (!String.IsNullOrEmpty(_sub_param))
                                            {
                                                switch (_sub_param)
                                                {
                                                    case "mongmat":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0028"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }

                                                    case "khuonmat":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0029"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                    case "vantay":
                                                        {
                                                            var a1 = from s in DataAccess.context.SanPham
                                                                     join t in DataAccess.context.ThongSoKiThuat
                                                                      on s.MaSp equals t.MaSp
                                                                     where (t.ThongSo.Contains("TS0027"))
                                                                     select s;
                                                            _filter_.Add(a1);
                                                            break;
                                                        }
                                                }



                                            }
                                        }
                                        _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                                        sanphams = sanphams.Intersect(_filter_[0]);
                                    }
                                }
                            }
                        }
                    }

                }
                //Do something with paramslist

                return Json(sanphams.ToList().Count);
            } else return Json("Không có");
        }

    }
}
