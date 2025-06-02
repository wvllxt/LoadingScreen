
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LoadingScreen;
    using Services;
    using UnityEngine;
    using Zenject;

    public class EntryPoint : MonoBehaviour
    {
        private List<IService> _services;
        [Inject]
        private void Initialize(List<IService> services)
        {
            _services = services;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            InitializeLoadingScreen(_services);
        }

        private async void InitializeLoadingScreen(List<IService> services)
        {
            var loadingSteps = CreateLoadingSteps();
           await LoadingManager.Instance.LoadSceneAsync("Game", loadingSteps);
        }

        private List<LoadingStep> CreateLoadingSteps()
        {
            return new List<LoadingStep>
            {
                new LoadingStep("Загрузка сервисов рекламы..", _services.OfType<AdsService>().FirstOrDefault().InitializeAsync),
                new LoadingStep("Загрузка сохранений", _services.OfType<SavesService>().FirstOrDefault().InitializeAsync),
                new LoadingStep("Загрузка покупок", _services.OfType<PurchasesService>().FirstOrDefault().InitializeAsync)
            };
        }
        
    }

 