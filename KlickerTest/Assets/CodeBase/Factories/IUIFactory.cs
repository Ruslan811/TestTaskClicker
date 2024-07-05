using CodeBase.Services;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        void CreateClicker();
        void CreateShop();
        Task<GameObject> CreateHud();
        Task CreateUIRoot();
    }
}