using System;
using UniRx;
using UnityEngine;

public class TestPresenter : IDisposable {
    private IDisposable hpSubscribe;
    private IDisposable onDamageSubscribe;
    public TestPresenter (ITestHPView testHPView, ITestHPModel testHPModel) {
        hpSubscribe = testHPModel.HP.Subscribe (testHPView.DisplayHP);
        onDamageSubscribe = testHPView.OnDamage.Subscribe (
            _ => testHPModel.Damage (20)
        );
    }

    public void Dispose () {
        Debug.Log ("Call Presenter Dispose()");
        hpSubscribe.Dispose ();
        onDamageSubscribe.Dispose ();
    }
}
