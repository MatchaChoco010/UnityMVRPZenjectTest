using UniRx;

public interface ITestHPModel {
    IReadOnlyReactiveProperty<int> HP { get; }
    void Damage (int damage);
}
