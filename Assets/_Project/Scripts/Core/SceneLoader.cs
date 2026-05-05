using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Bloomkin.Utils;

namespace Bloomkin.Core
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        public static event Action<float>  OnLoadProgress;
        public static event Action<string> OnSceneLoadStarted;
        public static event Action<string> OnSceneLoadComplete;

        [Tooltip("Optional additive loading screen scene shown during transitions.")]
        [SerializeField] private string _loadingScreenScene = "";

        private bool _isLoading;
        public bool IsLoading => _isLoading;

        public void LoadScene(string sceneName, bool useLoadingScreen = false)
        {
            if (_isLoading)
            {
                Debug.LogWarning("[SceneLoader] Already loading. Request ignored.");
                return;
            }
            StartCoroutine(LoadAsync(sceneName, useLoadingScreen));
        }

        public void LoadScene(int buildIndex, bool useLoadingScreen = false)
        {
            LoadScene(SceneUtility.GetScenePathByBuildIndex(buildIndex), useLoadingScreen);
        }

        public void ReloadCurrentScene() => LoadScene(SceneManager.GetActiveScene().name);

        private IEnumerator LoadAsync(string sceneName, bool useLoadingScreen)
        {
            _isLoading = true;
            OnSceneLoadStarted?.Invoke(sceneName);

            if (useLoadingScreen && !string.IsNullOrEmpty(_loadingScreenScene))
                yield return SceneManager.LoadSceneAsync(_loadingScreenScene, LoadSceneMode.Additive);

            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            if (op == null)
            {
                Debug.LogError($"[SceneLoader] Scene not found in Build Settings: '{sceneName}'");
                _isLoading = false;
                yield break;
            }

            op.allowSceneActivation = false;

            while (!op.isDone)
            {
                float progress = Mathf.Clamp01(op.progress / 0.9f);
                OnLoadProgress?.Invoke(progress);

                if (op.progress >= 0.9f)
                {
                    OnLoadProgress?.Invoke(1f);
                    yield return new WaitForSecondsRealtime(0.1f);
                    op.allowSceneActivation = true;
                }

                yield return null;
            }

            if (useLoadingScreen && !string.IsNullOrEmpty(_loadingScreenScene))
                yield return SceneManager.UnloadSceneAsync(_loadingScreenScene);

            OnSceneLoadComplete?.Invoke(sceneName);
            _isLoading = false;
        }
    }
}
