using CodeBase.Factories;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit() => 
            Debug.Log("Exit");
        private async void OnLoaded()
        {
            await InitUIRoot();
            await InitHud();
            _stateMachine.Enter<GameLoopState>();
        }

        private async Task InitUIRoot() =>
          await _uiFactory.CreateUIRoot();

        private async Task InitHud()
        {
            GameObject hud = await _uiFactory.CreateHud();
        }
    }
}