using Zenject;

public class TestInstaller : MonoInstaller {
    public override void InstallBindings () {
        Container.Bind<ITestHPModel> ().To<TestHPModel> ().AsCached ();
        Container.Bind<TestPresenter> ().AsCached ().NonLazy ();
    }
}
