using Configs;
using Game.Controllers;
using Game.Models;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class Main_Installer : MonoInstaller
    {
        [SerializeField] private Transform _placeForUI;

        [SerializeField] private MainConfig configurator;

        public override void InstallBindings()
        {
            Container.Bind<Profile>().FromNew().AsSingle().WithArguments(configurator.EntrySpeedCar);
            Container.Bind<MainController>().FromNew().AsSingle().WithArguments(_placeForUI);
        }
    }
}