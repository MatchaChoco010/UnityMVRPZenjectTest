using UniRx;
using UnityEngine;

public class TestHPModel : ITestHPModel {
    private IntReactiveProperty _hp = new IntReactiveProperty (100);
    public IReadOnlyReactiveProperty<int> HP => _hp;
    public void Damage (int damage) {
        if (damage < 0) return;

        var tmp = _hp.Value - damage;
        if (tmp < 0) {
            _hp.Value = 0;
        } else {
            _hp.Value = tmp;
            Debug.Log (tmp);
        }
    }
}
