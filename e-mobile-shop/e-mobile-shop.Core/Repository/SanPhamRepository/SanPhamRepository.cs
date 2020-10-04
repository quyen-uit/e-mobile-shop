using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace e_mobile_shop.Core.Repository
{
    public class SanPhamRepository : BaseRepository<SanPham>,ISanPhamRepository
    {
        public SanPhamRepository(ApplicationDbContext context ): base(context)
        {

        }

        public IQueryable<SanPham> FilterLaptopByRam(IQueryable<SanPham> sanphams, string _ramString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterLaptopByCpu(IQueryable<SanPham> sanphams, string _cpuString, ApplicationDbContext context)
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
            string _featureString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterLaptopByRequire(IQueryable<SanPham> sanphams, string _requireString, ApplicationDbContext context)
        {

            var _filter_ = new List<IQueryable<SanPham>>();

            foreach (var _requireValue in _requireString.Split('-'))
                if (!string.IsNullOrEmpty(_requireValue))
                {
                    if (_requireValue == "type_1") //học tập
                    {
                        var s1 = FilterLaptopByRam(sanphams, "4GB", context);
                        var s2 = FilterLaptopByCpu(sanphams, "i3", context);

                        _filter_.Add(s1);
                        _filter_.Add(s2);
                    }
                    else if (_requireValue.Contains("type_2")) //đồ họa
                    {
                        var s1 = from s in context.SanPham where s.TenSp.ToLower().Contains("macbook") select s;
                        var s2 = FilterLaptopByCpu(sanphams, "i5", context);
                        var s3 = FilterLaptopByRam(sanphams, "8gb", context);
                        _filter_.Add(s1);
                        _filter_.Add(s2);
                        _filter_.Add(s3);
                    }
                    else if (_requireValue == "type_3") //văn phòng
                    {
                        var s1 = from s in context.SanPham where s.TenSp.ToLower().Contains("macbook") select s;
                        var s2 = FilterLaptopByCpu(sanphams, "i3", context);
                        var s3 = FilterLaptopByRam(sanphams, "4gb", context);
                        _filter_.Add(s1);
                        _filter_.Add(s2);
                        _filter_.Add(s3);
                    }
                }

            _filter_.ToList().ForEach(item => _filter_[0] = _filter_[0].Union(item));
            return sanphams.Intersect(_filter_[0]);

        }

        public IQueryable<SanPham> FilterPhoneByOs(IQueryable<SanPham> sanphams, string _osString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterPhoneByBattery(IQueryable<SanPham> sanphams, string _batteryString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterPhoneByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ApplicationDbContext context)
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
            string _featureString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterTabletByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterTabletByRam(IQueryable<SanPham> sanphams, string _ramString, ApplicationDbContext context)
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

        public IQueryable<SanPham> FilterTabletBySim(IQueryable<SanPham> sanphams, string _simString, ApplicationDbContext context)
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
            string loaiSp, ApplicationDbContext context)
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
                                    sanphams = FilterLaptopByRam(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('j'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterLaptopByCpu(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('w'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "w", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterLaptopByRequire(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('z'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterSanphamBySpecialFeature(sanphams, _tmp_param_1, context);
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
                                    sanphams = FilterPhoneByOs(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('j'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterPhoneByBattery(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('w'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "w", "");

                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterPhoneByScreenSize(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('z'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterPhoneBySpecialFeature(sanphams, _tmp_param_1, context);
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
                                    sanphams = FilterTabletByScreenSize(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('j'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "j", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterTabletByRam(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('w'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "w", "");

                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterTabletBySim(sanphams, _tmp_param_1, context);
                            }
                            else if (_param.Contains('z'))
                            {
                                var _tmp_param_1 = Regex.Replace(_param, "z", "");
                                if (!string.IsNullOrEmpty(_tmp_param_1))
                                    sanphams = FilterPhoneBySpecialFeature(sanphams, _tmp_param_1, context);
                            }
                        }
                }

                return sanphams;
            }

            return sanphams;

        }

<<<<<<< HEAD
=======
        public SanPham GetSanPhamById(string id)
        {

                return DbContext.SanPham.Find(id);

        }


        public List<SanPham> GetSanPhamsByIdStatus(string id, string status)
        {

                try
                {
                    return DbContext.SanPham.Where(x => x.LoaiSp == id && x.Status == Int32.Parse(status)).ToList();
                }
                catch
                {
                    return DbContext.SanPham.ToList();
                }

        }

        public void Save(SanPham sp)
        {
            DbContext.SanPham.Add(sp);
            DbContext.SaveChanges();
        }

        //public void SaveAnhSP(AnhSanPham anh)
        //{
        //    DbContext.AnhSanPham.Add(anh);
        //    DbContext.SaveChanges();
        //}
        //public void UpdateAnhSP(AnhSanPham anh)
        //{
        //    DbContext.AnhSanPham.Update(anh);
        //    DbContext.SaveChanges();
        //}
        //public void SaveTSKT(ThongSoKiThuat tskt)
        //{
        //    DbContext.ThongSoKiThuat.AddAsync(tskt);
        //    DbContext.SaveChanges();
        //}
        //public void UpdateTSKT(ThongSoKiThuat tskt)
        //{
        //    context.Update(tskt);
        //    context.SaveChanges();
        //}
        public override void Delete(string id)
        {
            DbContext.SanPham.Find(id).Status = 0;
           // context.SaveChanges();
        }
        public void Update(SanPham sp, string masp)
        {
            SanPham a = DbContext.SanPham.Find(masp);
            DbContext.Entry(a).CurrentValues.SetValues(sp);
            //DbContext.SaveChanges();
        }

        //public List<ThongSo> GetThongSo(string Id)
        //{
        //    return DbContext.ThongSo.Where(x => x.MaLoai == Id).ToList();
        //}

        public string GetLoaiSp(string id)
        {
            return DbContext.LoaiSp.Find(id).TenLoai;
        }

        public int CountSanPham(string loaiSp)
        {
            return DbContext.SanPham.Where(x => x.LoaiSp == loaiSp).ToList().Count;
        }

        public void UpdateSoLuong(string maSp, int? soLuong)
        {
            DbContext.SanPham.Find(maSp).SoLuong = DbContext.SanPham.Find(maSp).SoLuong - soLuong;
            //context.SaveChanges();
        }

        public List<SanPham> ReadSanPham(string loaiSp)
        {
            try
            {
                return DbContext.SanPham.Where(x => x.LoaiSp == loaiSp).ToList();
            }
            catch (Exception)
            {
                return new List<SanPham>();
            }
        }

        //public AnhSanPham GetAnhSanPham(string maSp)
        //{
        //    return DbContext.AnhSanPham.Where(x => x.MaSp == maSp).FirstOrDefault();
        //}
>>>>>>> origin/refactor-code-quyen
    }
}
