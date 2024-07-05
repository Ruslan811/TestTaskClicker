using CodeBase.Data;

namespace CodeBase.Services
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
