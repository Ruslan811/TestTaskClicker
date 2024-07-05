using CodeBase.StaticData;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        WindowConfig ForWindow(WindowId shop);
    }
}
