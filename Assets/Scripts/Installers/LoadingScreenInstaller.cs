using System.ComponentModel;
using Services;
using Zenject;

namespace Installers
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AdsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavesService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PurchasesService>().AsSingle();
        }
    }
}