using Cemetery_Adventure_Logic.Entity.Character;
using Moq;

namespace UnitTests;

public class CharacterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IncreaseMaxHp_PositiveValue_IncreasesCharactersMaxHp()
    {
        var character = new Mock<Character>(MockBehavior.Strict, new object[] { "Name", (1, 1), 20, 5, 1 });
        character.Object.IncreaseMaxHP(5);
        Assert.That(character.Object.MaxHP, Is.EqualTo(25));
    }

    [Test]
    public void IncreaseMaxHp_NegativeValue_ThrowsException()
    {
        var character = new Mock<Character>(MockBehavior.Strict, new object[] { "Name", (1, 1), 20, 5, 1 });
        Assert.Throws<ArgumentException>(() => character.Object.IncreaseMaxHP(-5));
    }

    [Test]
    [TestCase(1,1)]
    [TestCase(-1,-1)]
    public void Move_ValidValues_ChangesCoordinates(int x, int y)
    {
        var character = new Mock<Character>(MockBehavior.Default, new object[] { "Name", (1, 1), 20, 5, 1 });
        character.Object.Move(x, y);
        Assert.Multiple(() =>
        {
            Assert.That(character.Object.Position.X, Is.EqualTo(x));
            Assert.That(character.Object.Position.Y, Is.EqualTo(y));
        });
    }
}