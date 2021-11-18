using EleCuit.Inventory;
using UnityEngine;
using Zenject;

namespace EleCuit.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField]
        private PartInventory m_partInventoryPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<IRxPartInventory>()
                .To<PartInventory>()
                .FromComponentInNewPrefab(m_partInventoryPrefab)
                .AsSingle();

        }
    }
}