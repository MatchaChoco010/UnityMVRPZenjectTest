using Moq;
using NUnit.Framework;
using UniRx;
using Zenject;

namespace Tests {
    [TestFixture]
    public class TestPresenterTest : ZenjectUnitTestFixture {
        Mock<ITestHPModel> _mockModel;
        Mock<ITestHPView> _mockView;
        Subject<Unit> _onDamageSubject;
        IntReactiveProperty _hpIntReactiveProperty;

        [SetUp]
        public void SetUp () {
            _mockModel = new Mock<ITestHPModel> ();
            _mockView = new Mock<ITestHPView> ();
            _onDamageSubject = new Subject<Unit> ();
            _mockView.Setup (x => x.OnDamage).Returns (_onDamageSubject);
            _hpIntReactiveProperty = new IntReactiveProperty (100);
            _mockModel.SetupGet (x => x.HP).Returns (_hpIntReactiveProperty);

            Container.BindInstance<ITestHPModel> (_mockModel.Object);
            Container.BindInstance<ITestHPView> (_mockView.Object);
            Container.Bind<TestPresenter> ().AsCached ();
        }

        [Test]
        public void ViewのOnDamageが通知されるとModelのDamageが引数20で呼ばれる() {
            var presenter = Container.Resolve<TestPresenter> ();
            _onDamageSubject.OnNext (Unit.Default);
            _mockModel.Verify (x => x.Damage (20), Times.Once);
        }

        [Test]
        public void 初期化されるとViewのDisplayHPが呼ばれる() {
            var presenter = Container.Resolve<TestPresenter> ();
            _mockView.Verify (x => x.DisplayHP (100), Times.Once);
        }

        [Test]
        public void ModelのHPが変更されるとViewのDisplayHPが呼ばれる() {
            var presenter = Container.Resolve<TestPresenter> ();
            _mockView.Verify (x => x.DisplayHP (100), Times.Once);
            _hpIntReactiveProperty.Value = 60;
            _mockView.Verify (x => x.DisplayHP (60), Times.Once);
        }
    }
}
