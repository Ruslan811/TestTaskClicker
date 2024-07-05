using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.Services;
using CodeBase.Factories;
using CodeBase.AssetManagement;
using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Scenes/Game";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() =>
          _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticDataService();

            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterAssetProvider();

            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());

            _services.RegisterSingle<IUIFactory>(new UIFactory(
              _services.Single<IAssetProvider>(),
              _services.Single<IStaticDataService>(),
              _services.Single<IPersistentProgressService>(),
              _services.Single<IWindowService>()
             ));

            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService( _services.Single<IPersistentProgressService>()));
        }

        private void RegisterAssetProvider()
        {
            AssetProvider assetProvider = new AssetProvider();
            _services.RegisterSingle<IAssetProvider>(assetProvider);
            assetProvider.Initialize();
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private void EnterLoadLevel() =>
          _stateMachine.Enter<LoadProgressState>();
    }  
}
