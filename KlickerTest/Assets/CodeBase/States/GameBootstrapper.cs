using CodeBase.Services;
using CodeBase.States;
using UnityEngine;

namespace CodeBase
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public GameStateMachine StateMachine;

        private void Awake()
        {
            StateMachine = new GameStateMachine(new SceneLoader(this), AllServices.Container);
            StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}