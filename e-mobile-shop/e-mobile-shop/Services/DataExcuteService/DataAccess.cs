using Microsoft.AspNetCore.Http;
using System;

namespace e_mobile_shop.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        static int soCtdh;


        public string GetRoleName(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistUser(string id)
        {
            throw new NotImplementedException();
        }

        public string getSoCtdh()
        {
            throw new NotImplementedException();
        }

        public void AddCtdh(int value)
        {
            throw new NotImplementedException();
        }
    }
}