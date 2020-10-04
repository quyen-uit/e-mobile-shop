<<<<<<< HEAD
﻿namespace e_mobile_shop.Services
{
    public interface IThongSoService
    {
=======
﻿using e_mobile_shop.Core.Models;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;

namespace e_mobile_shop.Services
{
    public interface IThongSoService
    {
        public List<ThongSoViewModel> GetThongSo(string Id);

>>>>>>> origin/refactor-code-quyen
    }
}
