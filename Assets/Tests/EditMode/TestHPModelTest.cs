using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestHPModelTest {
        [Test]
        public void HPの初期値は100 () {
            var hpModel = new TestHPModel ();
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
        }

        [Test]
        public void ダメージを受けるとHPが減少する() {
            var hpModel = new TestHPModel ();
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
            hpModel.Damage (30);
            Assert.That (hpModel.HP.Value, Is.EqualTo (70));
        }

        [Test]
        public void ダメージ0ではHPは変化しない() {
            var hpModel = new TestHPModel ();
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
            hpModel.Damage (0);
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
        }

        [Test]
        public void HP以上のダメージを受けたらHPは0になる() {
            var hpModel = new TestHPModel ();
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
            hpModel.Damage (120);
            Assert.That (hpModel.HP.Value, Is.EqualTo (0));
        }

        [Test]
        public void 負のダメージはHPを変化させない() {
            var hpModel = new TestHPModel ();
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
            hpModel.Damage (-50);
            Assert.That (hpModel.HP.Value, Is.EqualTo (100));
        }
    }
}
