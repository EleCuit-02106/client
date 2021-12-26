using UnityEngine;
using Zenject;
using EleCuit.UserCommand;

public class UserCommandInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IRxPartDragCommandPublisher>()
            .To<PartDragCommandDetector>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}