using UniRx;

public class TestPresenter {
    private ITestHPView _testHPView;
    private ITestHPModel _testHPModel;
    public TestPresenter (ITestHPView testHPView, ITestHPModel testHPModel) {
        _testHPView = testHPView;
        _testHPModel = testHPModel;
        _testHPModel.HP.Subscribe (_testHPView.DisplayHP);
        _testHPView.OnDamage.Subscribe (
            _ => _testHPModel.Damage (20)
        );
    }
}
