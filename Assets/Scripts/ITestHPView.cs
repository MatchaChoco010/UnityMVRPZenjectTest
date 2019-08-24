using System;
using UniRx;

public interface ITestHPView {
    IObservable<Unit> OnDamage { get; }
    void DisplayHP (int hp);
}
