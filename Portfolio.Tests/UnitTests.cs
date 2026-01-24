namespace Portfolio.Tests;
using Portfolio.core;

public class UnitTests
{
    [Test]
    public void Constructor_InitializesStatsCorrectly()
    {
        //Arrange
        //maxHp, currentHp, atk, def, range, movement;
        int maxHp = 20;
        int atk = 5;
        int def = 2;
        int range = 1;
        int movement = 3;

        //Act
        Unit unit = new Unit(maxHp, atk, def, range, movement);

        //Assert
        Assert.AreEqual(maxHp, unit.MaxHp);
        Assert.AreEqual(maxHp, unit.CurrentHp);
        Assert.AreEqual(atk, unit.Atk);
        Assert.AreEqual(def, unit.Def);
        Assert.AreEqual(range, unit.Range);
        Assert.AreEqual(movement, unit.Movement);
    }

    [Test]
    public void CalcDamageTaken_ReturnsAttackMinusDefense()
    {
        //Arrange
        Unit unit = new Unit(20, 5, 2, 1, 3);

        //Act
        int damage = unit.CalcDamageTaken(10);

        //Assert
        Assert.AreEqual(8, damage);
    }

    [Test]
    public void CalcDamageTaken_NeverReturnsNegativeDamage()
    {
        //Arrange
        Unit unit = new Unit(20, 5, 10, 1, 3);

        //Act
        int damage = unit.CalcDamageTaken(5);

        //Assert
        Assert.AreEqual(0, damage);
    }

    [Test]
    public void TakeDamage_ReducesCurrentHpCorrectly()
    {
        //Arrenge
        Unit unit = new Unit(20, 5, 2, 1, 3);

        //Act
        unit.TakeDamage(10);

        //Assert
        Assert.AreEqual(12, unit.CurrentHp);
    }

    [Test]
    public void TakeDamage_DoesNotReduceHpBelowZero()
    {
        //Arrenge
        Unit unit = new Unit(20, 5, 0, 1, 3);

        //Act
        unit.TakeDamage(50);

        //Assert
        Assert.AreEqual(0, unit.CurrentHp);
    }

    [Test]
    public void TakeDamage_MultipleHitsStackCorrectly()
    {
        //Arrenge
        Unit unit = new Unit(20, 5, 2, 1, 3);

        //Act
        unit.TakeDamage(6);
        unit.TakeDamage(10);

        //Assert
        Assert.AreEqual(8, unit.CurrentHp);
    }
}
