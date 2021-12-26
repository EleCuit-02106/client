using EleCuit.Inventory;
using UnityEngine;
using Zenject;

namespace EleCuit.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IRxPartInventory>()
                .To<PartInventory>()
                .FromComponentInHierarchy()
                .AsSingle();

        }
    }
}