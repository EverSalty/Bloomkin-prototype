using System.Collections.Generic;
using UnityEngine;
using Bloomkin.Utils;
using Bloomkin.Core;

namespace Bloomkin.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [System.Serializable]
        public class UIPanel
        {
            public string     name;
            public GameObject root;
        }

        [SerializeField] private List<UIPanel> _panels = new();

        private readonly Dictionary<string, UIPanel> _panelMap = new();

        protected override void Awake()
        {
            base.Awake();
            foreach (var panel in _panels)
            {
                if (panel.root == null || string.IsNullOrEmpty(panel.name)) continue;
                _panelMap.TryAdd(panel.name, panel);
            }

            GameManager.OnGameStateChanged += HandleStateChanged;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= HandleStateChanged;
        }

        public void ShowPanel(string panelName)
        {
            if (_panelMap.TryGetValue(panelName, out var p)) p.root.SetActive(true);
        }

        public void HidePanel(string panelName)
        {
            if (_panelMap.TryGetValue(panelName, out var p)) p.root.SetActive(false);
        }

        public void HideAllPanels()
        {
            foreach (var kv in _panelMap) kv.Value.root.SetActive(false);
        }

        public bool IsPanelVisible(string panelName)
        {
            return _panelMap.TryGetValue(panelName, out var p) && p.root.activeSelf;
        }

        private void HandleStateChanged(GameState previous, GameState next)
        {
            switch (next)
            {
                case GameState.MainMenu:
                    HideAllPanels();
                    ShowPanel("MainMenu");
                    break;
                case GameState.Playing:
                    HideAllPanels();
                    ShowPanel("HUD");
                    break;
                case GameState.Paused:
                    ShowPanel("PauseMenu");
                    break;
                case GameState.GameOver:
                    HideAllPanels();
                    ShowPanel("GameOver");
                    break;
            }
        }
    }
}
