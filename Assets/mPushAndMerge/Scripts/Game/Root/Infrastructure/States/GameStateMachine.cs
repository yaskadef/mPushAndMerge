
using Assets.mPushAndMerge.Scripts.Game.Settings;
using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using System.Collections.Generic;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly GameStateFactory _factory;
        private readonly Dictionary<Type, IExitableState> _states = new();
        private IExitableState _activeState;

        public GameStateMachine(GameStateFactory factory)
        {
            _factory = factory;
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
            if (!_states.TryGetValue(typeof(TState), out var state))
            {
                state = _factory.Create<TState>();
                _states[typeof(TState)] = state;
            }

            return (TState)state;
        }
    }
} 
