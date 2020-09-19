namespace e_mobile_shop.Services
{
    public interface IDataAccess
    {
        string GetRoleName(string id);
        bool ExistUser(string id);

        string getSoCtdh();
        void AddCtdh(int value);
    }
}
