using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace e_mobile_shop.Models
{
    public class DataAccess
    {
        public int soCtdh { get; set; }

        public List<AspNetUsers> ViewSanPham()
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AspNetUsers.ToList();
                }
                catch (Exception)
                {
                    return new List<AspNetUsers>();
                }
            }
        }

        public List<LoaiSp> ReadLoaiSp()
        {
            using (var context = new ClientDbContext())
            {
                var result = new List<LoaiSp>();

                foreach (var item in context.LoaiSp.ToList())
                    if (item.TenLoai != "Phụ Kiện")
                        result.Add(item);
                return result;
            }
        }

        public List<SanPham> ReadSanPham(string loaiSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.SanPham.Where(x => x.LoaiSp == loaiSp).ToList();
                }
                catch (Exception)
                {
                    return new List<SanPham>();
                }
            }
        }

        public List<ThongSo> ReadThongSo(string loaiSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSo.Where(x => x.MaLoai == loaiSp).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSo>();
                }
            }
        }

        public List<ThongSoKiThuat> ReadThongSoKiThuat(string ma)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSoKiThuat.Where(x => x.MaSp == ma).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSoKiThuat>();
                }
            }
        }

        public string GetTenTSKT(string masp, string mats)
        {
            using (var context = new ClientDbContext())
            {
                var temp = context.ThongSoKiThuat.FirstOrDefault(x => x.MaSp == masp && x.ThongSo == mats);
                if (temp != null)
                    return temp.GiaTri;
                return "";
            }
        }

        public string GetLoaiSp(string loaiSP)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.LoaiSp.Find(loaiSP).TenLoai;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public List<NhaSanXuat> GetNSX()
        {
            using (var context = new ClientDbContext())
            {
                try
                {

                    return context.NhaSanXuat.ToList();
                }
                catch (Exception)
                {
                    return new List<NhaSanXuat>();
                }
            }
        }

        public SanPham GetSanPham(string Id)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.SanPham.Find(Id);

                } catch(Exception)
                {
                    return new SanPham();
                }
            }
        }

        public List<ThongSoKiThuat> GetThongSoKiThuat(string maSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSoKiThuat.Where(x => x.MaSp == maSp).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSoKiThuat>();
                }
            }
        }

        public List<string> getGiaTriThongSoKiThuat(List<ThongSoKiThuat> lst)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    var result = new List<string>();
                    foreach (var item in lst) result.Add(item.GiaTri.ToLower());
                    return result;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
        }

        public AnhSanPham GetAnhSanPham(string maSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AnhSanPham.SingleOrDefault(x => x.MaSp == maSp);

                } catch(Exception)
                {
                    return new AnhSanPham();
                }
            }
        }

        public DonHang GetDonHang(string maDh)
        {
            using (var context = new ClientDbContext())
            {
                return context.DonHang.Find(maDh);
            }
        }

        public AspNetUsers GetUser(string userId)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AspNetUsers.Find(userId);
                }
                catch (Exception)
                {
                    return new AspNetUsers();
                }
            }
        }

        public IQueryable<SanPham> FilterLaptopByRam(IQueryable<SanPham> sanphams, string _ramString,ClientDbContext context)
        {
         
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _ramValue in _ramString.Split('-'))
                    if (!string.IsNullOrEmpty(_ramValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_ramValue.ToLower()) && t.ThongSo == "TS0048" &&
                                              s.LoaiSp == "LSP0008"
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                var result = sanphams.Intersect(_filter_[0]);
                return result;
            
        }

        public IQueryable<SanPham> FilterLaptopByCpu(IQueryable<SanPham> sanphams, string _cpuString,ClientDbContext context)
        {
          
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _cpuValue in _cpuString.Split('-'))
                    if (!string.IsNullOrEmpty(_cpuValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_cpuValue.ToLower()) && t.ThongSo.Contains("TS0046") &&
                                              s.LoaiSp.Contains("LSP0008")
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                return sanphams.Intersect(_filter_[0]);
        }

        public IQueryable<SanPham> FilterSanphamBySpecialFeature(IQueryable<SanPham> sanphams,
            string _featureString, ClientDbContext context)
        {
           
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _featureValue in _featureString.Split('-'))
                    if (!string.IsNullOrEmpty(_featureValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_featureValue.ToLower()) && s.LoaiSp.Contains("LSP0008")
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                return sanphams.Intersect(_filter_[0]);
            
        }

        public IQueryable<SanPham> FilterLaptopByRequire(IQueryable<SanPham> sanphams, string _requireString, ClientDbContext context)
        {
           
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _requireValue in _requireString.Split('-'))
                    if (!string.IsNullOrEmpty(_requireValue))
                    {
                        if (_requireValue == "type_1") //học tập
                        {
                            var s1 = FilterLaptopByRam(sanphams, "4GB",context);
                            var s2 = FilterLaptopByCpu(sanphams, "i3",context);

                            _filter_.Add(s1);
                            _filter_.Add(s2);
                        }
                        else if (_requireValue.Contains("type_2")) //đồ họa
                        {
                            var s1 = from s in context.SanPham where s.TenSp.ToLower().Contains("macbook") select s;
                            var s2 = FilterLaptopByCpu(sanphams, "i5",context);
                            var s3 = FilterLaptopByRam(sanphams, "8gb",context);
                            _filter_.Add(s1);
                            _filter_.Add(s2);
                            _filter_.Add(s3);
                        }
                        else if (_requireValue == "type_3") //văn phòng
                        {
                            var s1 = from s in context.SanPham where s.TenSp.ToLower().Contains("macbook") select s;
                            var s2 = FilterLaptopByCpu(sanphams, "i3",context);
                            var s3 = FilterLaptopByRam(sanphams, "4gb",context);
                            _filter_.Add(s1);
                            _filter_.Add(s2);
                            _filter_.Add(s3);
                        }
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                return sanphams.Intersect(_filter_[0]);
            
        }

        public IQueryable<SanPham> FilterPhoneByOs(IQueryable<SanPham> sanphams, string _osString, ClientDbContext context)
        {
            
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _osValue in _osString.Split('-'))
                    if (!string.IsNullOrEmpty(_osValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_osValue.ToLower()) && t.ThongSo.Contains("TS0008") &&
                                              s.LoaiSp.Contains("LSP0002")
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                return sanphams.Intersect(_filter_[0]);
            
        }

        public IQueryable<SanPham> FilterPhoneByBattery(IQueryable<SanPham> sanphams, string _batteryString, ClientDbContext context)
        {
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _batteryValue in _batteryString.Split('-'))
                    if (!string.IsNullOrEmpty(_batteryValue))
                        switch (_batteryValue)
                        {
                            case "small":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where Convert.ToInt32(t.GiaTri.Substring(0, 4)) < 4000 &&
                                                   t.ThongSo.Contains("TS0018") && s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                            case "big":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where 4000 <= Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                   Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) <= 5000 &&
                                                   t.ThongSo.Contains("TS0018") && s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                            case "super":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where 5000 < Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 4)) &&
                                                   t.ThongSo.Contains("TS0018") && s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                        }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                return sanphams.Intersect(_filter_[0]);
        }

        public IQueryable<SanPham> FilterPhoneByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ClientDbContext context)
        {
          
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _screenValue in _screenString.Split('-'))
                    if (!string.IsNullOrEmpty(_screenValue))
                        switch (_screenValue)
                        {
                            case "small":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where Convert.ToInt32(t.GiaTri.Substring(0, 1)) < 6 && t.ThongSo.Contains("TS0002") &&
                                                   s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                            case "medium":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where 6 <= Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 1)) &&
                                                   Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 1)) < 8 &&
                                                   t.ThongSo.Contains("TS0002") && s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                            case "big":
                                {
                                    var a1 = from s in context.SanPham
                                             join t in context.ThongSoKiThuat
                                                 on s.MaSp equals t.MaSp
                                             where 8 <= Convert.ToInt32(t.GiaTri.ToLower().Substring(0, 1)) &&
                                                   t.ThongSo.Contains("TS0002") && s.LoaiSp.Contains("LSP0002")
                                             select s;
                                    _filter_.Add(a1);
                                    break;
                                }
                        }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                return sanphams.Intersect(_filter_[0]);
            
        }

        public IQueryable<SanPham> FilterPhoneBySpecialFeature(IQueryable<SanPham> sanphams,
            string _featureString, ClientDbContext context)
        {
          
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _featureValue in _featureString.Split('-'))
                    if (!string.IsNullOrEmpty(_featureValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_featureValue.ToLower()) && s.LoaiSp.Contains("LSP0002")
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
                return sanphams.Intersect(_filter_[0]);
            
        }

        public IQueryable<SanPham> FilterTabletByScreenSize(IQueryable<SanPham> sanphams, string _screenString,ClientDbContext context)
        {
          
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _screenValue in _screenString.Split('-'))
                    if (!string.IsNullOrEmpty(_screenValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_screenValue.ToLower()) && t.ThongSo == "TS0025" &&
                                              s.LoaiSp == "LSP0007"
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                var result = sanphams.Intersect(_filter_[0]);
                return result;
            
        }

        public IQueryable<SanPham> FilterTabletByRam(IQueryable<SanPham> sanphams, string _ramString, ClientDbContext context)
        {
         
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _ramValue in _ramString.Split('-'))
                    if (!string.IsNullOrEmpty(_ramValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_ramValue.ToLower()) && t.ThongSo == "TS0034" &&
                                              s.LoaiSp == "LSP0007"
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                var result = sanphams.Intersect(_filter_[0]);
                return result;
            
        }

        public IQueryable<SanPham> FilterTabletBySim(IQueryable<SanPham> sanphams, string _simString, ClientDbContext context)
        {
          
                var _filter_ = new List<IQueryable<SanPham>>();

                foreach (var _simValue in _simString.Split('-'))
                    if (!string.IsNullOrEmpty(_simValue))
                    {
                        var _sanphams = from s in sanphams
                                        join t in context.ThongSoKiThuat
                                            on s.MaSp equals t.MaSp
                                        where t.GiaTri.ToLower().Contains(_simValue.ToLower()) && t.ThongSo == "TS0037" &&
                                              s.LoaiSp == "LSP0007"
                                        select s;
                        _filter_.Add(_sanphams);
                    }

                _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Intersect(item));
                var result = sanphams.Intersect(_filter_[0]);
                return result;
            
        }

        public IQueryable<SanPham> FilterSanPhamWithParam(IQueryable<SanPham> sanphams, string params_list,
            string loaiSp, ClientDbContext context)
        {
          
                if (!string.IsNullOrEmpty(params_list) && !string.IsNullOrEmpty(loaiSp))
                {
                    sanphams = sanphams.Where(s => s.LoaiSp == loaiSp);

                    //for Laptop
                    if (loaiSp == "LSP0008")
                    {
                        foreach (var _param in params_list.Split('&'))
                            if (!string.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterLaptopByRam(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('j'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterLaptopByCpu(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('w'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "w", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterLaptopByRequire(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('z'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterSanphamBySpecialFeature(sanphams, _tmp_param_1,context);
                                }
                            }
                    }
                    else if (loaiSp == "LSP0002")
                    {
                        foreach (var _param in params_list.Split('&'))
                            if (!string.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterPhoneByOs(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('j'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterPhoneByBattery(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('w'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "w", "");

                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterPhoneByScreenSize(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('z'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterPhoneBySpecialFeature(sanphams, _tmp_param_1,context);
                                }
                            }
                    }
                    else if (loaiSp == "LSP0007")
                    {
                        foreach (var _param in params_list.Split('&'))
                            if (!string.IsNullOrEmpty(_param))
                            {
                                if (_param.Contains('f'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "f", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterTabletByScreenSize(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('j'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterTabletByRam(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('w'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "w", "");

                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterTabletBySim(sanphams, _tmp_param_1,context);
                                }
                                else if (_param.Contains('z'))
                                {
                                    var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                    if (!string.IsNullOrEmpty(_tmp_param_1))
                                        sanphams = FilterPhoneBySpecialFeature(sanphams, _tmp_param_1,context);
                                }
                            }
                    }

                    return sanphams;
                }

                return sanphams;
            
        }

        public bool ExistUser(string id)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    var a = context.AspNetUsers.Find(id);
                    return a != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string GetRoleName(string id)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    var b = context.AspNetUserRoles.SingleOrDefault(x => x.UserId == id);
                    var res = context.AspNetRoles.SingleOrDefault(x => x.Id == b.RoleId);
                    return res.Name;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}