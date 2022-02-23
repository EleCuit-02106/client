using EleCuit.Course;
using UnityEngine;
using Zenject;

namespace EleCuit.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IRxPartSetupAcceptOrDeny>()
                .To<PartSetupAcceptor>()
                .FromComponentInHierarchy()
                .AsCached();
        }
    }
}