
using Assets.mPushAndMerge.Scripts.Game.Settings;
using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using System.Collections.Generic;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        private IExitableState _activeState;

        public GameStateMachine(
            SceneLoader sceneLoader, 
            UIRootView uiRoot, 
            SceneEnterParamsService sceneEnterParamsService,
            ISettingsProvider settingsProvider)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, uiRoot, settingsProvider),
                [typeof(MainMenuState)] = new MainMenuState(
                    this, 
                    sceneLoader, 
                    uiRoot),
                [typeof(LoadGameplayState)] = new LoadGameplayState(
                    this, 
                    sceneLoader, 
                    uiRoot, 
                    sceneEnterParamsService
                    ),
                [typeof(GameplayLoopState)] = new GameplayLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangedState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangedState<TState>();
            state.Enter(payload);
        }

        private TState ChangedState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            if (_states[typeof(TState)] is TState state)
                return state;

            throw new Exception($"Incorrect type state ({typeof(TState)}) in GetState()");
        }
    }
} 
