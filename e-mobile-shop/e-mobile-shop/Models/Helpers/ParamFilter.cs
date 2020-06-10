using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Helpers
{
    public class ParamFilter
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }

    public class ParamsList
    {
        public List<ParamFilter> Params { get; set; }
    }
}
