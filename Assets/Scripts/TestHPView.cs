using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TestHPView : MonoBehaviour, ITestHPView {
    public TextMeshProUGUI text;
    public Button button;

    public IObservable<Unit> OnDamage => button.OnClickAsObservable ();

    public void DisplayHP (int hp) {
        text.text = hp.ToString ();
    }
}
