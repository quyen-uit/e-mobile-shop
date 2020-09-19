using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Services.SanPhamService
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IMapper _mapper;

        public SanPhamService(ISanPhamRepository sanPhamRepository, IMapper mapper)
        {
            _sanPhamRepository = sanPhamRepository;
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
    }
}
