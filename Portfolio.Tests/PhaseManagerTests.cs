namespace Portfolio.Tests;

using NUnit.Framework.Internal;
using Portfolio.core;

public class PhaseManagerTests
{
    private PhaseManager phaseManager;
    private Unit testUnit;
    private Unit testUnit2;

    [SetUp]
    public void Setup()
    {
        phaseManager = new PhaseManager();
        testUnit = new Unit(20, 5, 2, 1, 3);
        testUnit2 = new Unit(18, 7, 2, 1, 3);
    }

    [Test]
    public void PhaseManager_CorrectSetUp()
    {
        Assert.AreEqual(TurnPhase.PlayerTurn, phaseManager.CurrentPhase);
        Assert.AreEqual(1, phaseManager.TurnCounter);
    }

    [Test]
    public void CanMove_NotYetMovedUnit_ReturnsTrue()
    {
        Assert.IsTrue(phaseManager.CanMove(testUnit));
    }

    [Test]
    public void CanMove_AlreadyMovedUnit_ReturnsFalse()
    {
        //Act
        phaseManager.RegisterMove(testUnit);

        //Assert
        Assert.IsFalse(phaseManager.CanMove(testUnit));
    }

    [Test]
    public void CanMove_NotYetMovedSecondUnit_ReturnsTrue()
    {
        //Act
        phaseManager.RegisterMove(testUnit2);

        //Assert
        Assert.IsTrue(phaseManager.CanMove(testUnit));
    }

    [Test]
    public void CanAttack_NotYetAttackedUnit_ReturnsTrue()
    {
        Assert.IsTrue(phaseManager.CanAttack(testUnit));
    }

    [Test]
    public void CanAttack_AlreadyAttackedUnit_ReturnsFalse()
    {
        //Act
        phaseManager.RegisterAttack(testUnit);

        //Assert
        Assert.IsFalse(phaseManager.CanAttack(testUnit));
    }

    [Test]
    public void CanAttack_NotYetAttackedSecondUnit_ReturnsTrue()
    {
        //Act
        phaseManager.RegisterAttack(testUnit2);

        //Assert
        Assert.IsTrue(phaseManager.CanAttack(testUnit));
    }

    [Test]
    public void CanAttack_MovedWithoutAttacking_ReturnsTrue()
    {
        //Act
        phaseManager.RegisterMove(testUnit);

        //Assert
        Assert.IsTrue(phaseManager.CanAttack(testUnit));
    }

    [Test]
    public void EndTurn_ResetsActions_IncrementsTurn_AdvancesPhase()
    {
        //Act
        phaseManager.RegisterMove(testUnit);
        phaseManager.RegisterAttack(testUnit);
        phaseManager.EndTurn();

        //Assert
        Assert.IsTrue(phaseManager.CanMove(testUnit));
        Assert.IsTrue(phaseManager.CanAttack(testUnit));
        Assert.AreEqual(2, phaseManager.TurnCounter);
        Assert.AreEqual(TurnPhase.EnemyTurn, phaseManager.CurrentPhase);
    }

    [Test]
    public void EndTurn_EnemyTurn_ReturnsToPlayerTurn()
    {
        //Act
        phaseManager.EndTurn();
        phaseManager.EndTurn();

        //Assert
        Assert.AreEqual(TurnPhase.PlayerTurn, phaseManager.CurrentPhase);
    }
}
