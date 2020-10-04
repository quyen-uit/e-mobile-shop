using AutoMapper;
<<<<<<< HEAD
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
=======
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System;
>>>>>>> origin/refactor-code-quyen
using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Services.SanPhamService
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _sanPhamRepository;
<<<<<<< HEAD
        private readonly IMapper _mapper;

        public SanPhamService(ISanPhamRepository sanPhamRepository, IMapper mapper)
        {
            _sanPhamRepository = sanPhamRepository;
=======
        private readonly IDonHangRepository _donHangRepository;
        private readonly IChiTietDonHangRepository _chiTietDonHangRepository;
        private readonly IMapper _mapper;

        public SanPhamService(ISanPhamRepository sanPhamRepository, IDonHangRepository donHangRepository,IChiTietDonHangRepository chiTietDonHangRepository, IMapper mapper)
        {
            _donHangRepository = donHangRepository;
            _sanPhamRepository = sanPhamRepository;
            _chiTietDonHangRepository = chiTietDonHangRepository;
>>>>>>> origin/refactor-code-quyen
            _mapper = mapper;
        }

        public SanPhamViewModel GetById(string Id)
        {
            var sanPham = _sanPhamRepository.GetById(Id);
            var result = _mapper.Map(sanPham, new SanPhamViewModel());
            return result;

        }

        public IQueryable<SanPhamViewModel> GetPaginatedListSanPham(string Id)
        {
            var sanphams = _sanPhamRepository.GetAll();

            if (Id != "LSP0006")
            {
                sanphams = _sanPhamRepository.GetAll().Where(x => x.LoaiSp == Id);
            }
            else
            {
                sanphams = _sanPhamRepository.GetAll().Where(x => x.LoaiSp != "LSP0002" && x.LoaiSp != "LSP0007" && x.LoaiSp != "LSP0008");
            }

            var sanPhamResult = sanphams.ToList();
            var result = _mapper.Map(sanPhamResult, new List<SanPhamViewModel>());
            var returnResult = result.AsQueryable<SanPhamViewModel>();
            return returnResult;
        }
<<<<<<< HEAD
=======

        public int GetTotalProductSellCurrentMonth()
        {
            // tính tổng sản phẩm đã bán tháng trước
           
            int sum = 0;

            List<DonHang> dhs = _donHangRepository.GetAll().ToList();
            foreach (var item in dhs)
            {

                if (item.NgayDatMua.Value.Month == DateTime.Now.Month)
                {
                    foreach (var i in _chiTietDonHangRepository.GetAllByIdDonHang(item.MaDh))
                    {
                        sum = sum + i.SoLuong.Value;
                    }
                }
            }
            return sum;
        }

        public int GetTotalProductSellPreMonth()
        {
            
            int sumPre = 0;
           
            int preMonth = DateTime.Now.AddMonths(-1).Month;
            List<DonHang> dhs = _donHangRepository.GetAll().ToList();
            foreach (var item in dhs)
            {

                if (item.NgayDatMua.Value.Month == preMonth)
                {
                    foreach (var i in _chiTietDonHangRepository.GetAllByIdDonHang(item.MaDh) /*context.ChiTietDonHang.Where(x=>x.MaDh == item.MaDh)*/)
                    {
                        sumPre = sumPre + i.SoLuong.Value;
                    }
                }
            }
            return sumPre;
        }

        public List<SanPhamViewModel> ReadSanPham(string id)
        {
            return _mapper.Map<List<SanPhamViewModel>>(_sanPhamRepository.ReadSanPham(id));
        }
        public string GetLoaiSp(string id)
        {
            return _sanPhamRepository.GetLoaiSp(id);
        }
        public List<SanPhamViewModel> Search(string id, string searchValue, string status)
        {
            var a = _sanPhamRepository.ReadSanPham(id);
            List<SanPham> rs = new List<SanPham>();
 
            if (!string.IsNullOrEmpty(status))
            {
                // a = context.SanPham.Where(x=>x.LoaiSp == id && x.Status == Int32.Parse(status)).ToList();
                a = _sanPhamRepository.GetSanPhamsByIdStatus(id, status);   
            }
            if (!String.IsNullOrEmpty(searchValue))
            {

                foreach (var item in a)
                {
                    if (item.TenSp.ToLower().Contains(searchValue.ToLower().Trim()) || item.MaSp.ToLower().Contains(searchValue.ToLower().Trim()))
                        rs.Add(item);
                }
                return _mapper.Map<List<SanPhamViewModel>>(rs);
            }
            return _mapper.Map<List<SanPhamViewModel>>(a);
        }

        public void Delete(string id)
        {
            _sanPhamRepository.Delete(id);
        }

        public void Update(SanPhamViewModel sp, string id)
        {
            _sanPhamRepository.Update(_mapper.Map<SanPham>(sp), id);
        }

        public void SaveChange()
        {
            _sanPhamRepository.SaveChanges();
        }

        public void Add(SanPhamViewModel sp)
        {
            _sanPhamRepository.Add(_mapper.Map<SanPham>(sp));
        }
>>>>>>> origin/refactor-code-quyen
    }
}
