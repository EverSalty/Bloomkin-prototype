using System;
using UnityEngine;
using Bloomkin.Utils;

namespace Bloomkin.Core
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public class GameManager : Singleton<GameManager>
    {
        public static event Action<GameState, GameState> OnGameStateChanged;

        [SerializeField] private GameState _initialState = GameState.MainMenu;

        private GameState _currentState;

        public GameState CurrentState => _currentState;
        public bool IsPlaying => _currentState == GameState.Playing;
        public bool IsPaused  => _currentState == GameState.Paused;

        protected override void Awake()
        {
            base.Awake();
            _currentState = _initialState;
        }

        private void Start()
        {
            OnGameStateChanged?.Invoke(GameState.MainMenu, _currentState);
        }

        public void ChangeState(GameState newState)
        {
            if (_currentState == newState) return;

            GameState previous = _currentState;
            _currentState = newState;

            switch (newState)
            {
                case GameState.Playing:   Time.timeScale = 1f; break;
                case GameState.Paused:    Time.timeScale = 0f; break;
                case GameState.GameOver:  Time.timeScale = 0f; break;
                case GameState.MainMenu:  Time.timeScale = 1f; break;
            }

            OnGameStateChanged?.Invoke(previous, newState);
        }

        public void StartGame()        => ChangeState(GameState.Playing);
        public void PauseGame()        => ChangeState(GameState.Paused);
        public void ResumeGame()       => ChangeState(GameState.Playing);
        public void TriggerGameOver()  => ChangeState(GameState.GameOver);
        public void ReturnToMainMenu() => ChangeState(GameState.MainMenu);
    }
}
