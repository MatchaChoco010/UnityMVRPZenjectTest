using Zenject;

public class TestPresenterInstaller : MonoInstaller {
    public override void InstallBindings () {
        Container.Bind<TestPresenter> ().AsCached ().NonLazy ();
    }
}
