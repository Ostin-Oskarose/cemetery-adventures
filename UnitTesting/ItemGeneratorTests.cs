using System.Reflection;
using Cemetery_Adventure_Logic.Entity.Character.Enemy;
using Cemetery_Adventure_Logic.Item;

namespace UnitTests
{
    internal class ItemGeneratorTests
    {
        private static Enemy[] _enemyList =
        {
            new Rat((1, 1)),
            new Skeleton((1, 1)),
            new Ghoul((1, 1)),
            new Zombie((1, 1)),
            new Vampire((1, 1)),
            new Necromancer((1, 1))
        };

        [TestCaseSource(nameof(_enemyList))]
        public void GenerateItemToEnemy_EnemyHaveOneItem_WhenDropChanceEqualOneHundred(Enemy enemy)
        {
            const int dropChance = 100;

            ItemGenerator.GenerateItemToEnemy(enemy, dropChance);
            var result = enemy.GetInventory().Count;

            Assert.AreEqual(1, result);
        }

        [TestCaseSource(nameof(_enemyList))]
        public void GenerateItemToEnemy_EnemyHaveZeroItems_WhenDropChanceAreLessThanZero(Enemy enemy)
        {
            const int dropChance = -1;

            ItemGenerator.GenerateItemToEnemy(enemy, dropChance);
            var result = enemy.GetInventory().Count;

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetRandomItemType_ReturnRandomItemType_WhenCall()
        {
            var method = typeof(ItemGenerator).GetMethod("GetRandomItemType", BindingFlags.NonPublic | BindingFlags.Static);
            var expectedItemType = Enum.GetValues(typeof(ItemTypes));

            var result = (ItemTypes)method.Invoke(null, null);

            Assert.That(expectedItemType, Contains.Item(result));
        }
    }
}
