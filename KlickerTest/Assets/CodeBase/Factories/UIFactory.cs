using CodeBase.AssetManagement;
using CodeBase.Elements;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.StaticData;
using CodeBase.Windows;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;
        private readonly IPersistentProgressService _progressService;
        private readonly IWindowService _windowService;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData, IPersistentProgressService progressService, IWindowService windowService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
            _windowService = windowService;
        }

        public void CreateClicker()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Clicker);
            ClickerWindow window = Object.Instantiate(config.Template, _uiRoot) as ClickerWindow;
            window.Construct(_progressService);
        }

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            ShopWindow window = Object.Instantiate(config.Template, _uiRoot) as ShopWindow;
            window.Construct(_progressService);

        }

        public async Task CreateUIRoot()
        {
            GameObject root = await _assets.Instantiate(AssetAddress.UIRootPath);
            _uiRoot = root.transform;
        }

        public async Task<GameObject> CreateHud()
        {
            GameObject hud = await _assets.Instantiate(AssetAddress.HudPath);

            OpenWindowButton openWindowButton = hud.GetComponentInChildren<OpenWindowButton>();

            return hud;
        }
    }
}