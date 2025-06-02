using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LoadingScreen
{
    public class LoadingManager : MonoBehaviour
    {
        public static LoadingManager Instance;
        [SerializeField] private Slider progressBar;
        [SerializeField] private GameObject loadingUI;
        [SerializeField] private TextMeshProUGUI statusText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public async Task LoadSceneAsync(string sceneName, List<LoadingStep> loadingSteps)
        {
            var loadingSceneStep = new LoadingStep("Загрузка сцены....", async () => await LoadScene(sceneName));
            loadingSteps.Add(loadingSceneStep);
        
            var stepFraction = 1f / loadingSteps.Count;
            var totalProgress = 0f;
            
            progressBar.value = totalProgress;
            loadingUI.SetActive(true);

            foreach (var loadingStep in loadingSteps)
            {
                statusText.text = loadingStep.Description;
                await loadingStep.ActionAsync();
                
                totalProgress += stepFraction;
                progressBar.value = totalProgress;
            }
            statusText.text = "Готово!";
            await Task.Delay(300);
            //loadingUI.SetActive(false);


        }

        private static async Task LoadScene(string sceneName)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            while (asyncOperation.progress < 0.9f)
            {
                await Task.Yield();
            }

            await Task.Delay(500);
            asyncOperation.allowSceneActivation = true;
        }
    }
}
