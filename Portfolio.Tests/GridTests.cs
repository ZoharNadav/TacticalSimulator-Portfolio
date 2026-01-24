using NUnit.Framework;
using Portfolio.core;

[TestFixture]
public class GridTests
{
    private Grid grid;
    private Unit unit;
    private Position position;

    [SetUp]
    public void Setup()
    {
        grid = new Grid(8, 8);
        unit = new Unit();
        position = new Position(1, 1);
    }

    [Test]
    public void Place_EmptyPosition_ReturnsTrue()
    {
        bool result = grid.Place(position, unit);
        Assert.IsTrue(result);
    }

    [Test]
    public void Place_ValidPosition_PositionIsOccupied()
    {
        grid.Place(position, unit);
        bool occupied = grid.IsOccupied(position);
        Assert.IsTrue(occupied);
    }

    [Test]
    public void Place_OutsideGrid_ReturnsFalse()
    {
        Position outside = new Position(-1, 0);
        bool result = grid.Place(outside, unit);
        Assert.IsFalse(result);
        //outside == occupied == can’t place
    }

    [Test]
    public void GetOccupant_PositionWithUnit_ReturnsUnit()
    {
        grid.Place(position, unit);
        Unit result = grid.GetOccupant(position);
        Assert.AreSame(unit, result);
    }

    [Test]
    public void GetOccupant_EmptyPosition_ThrowsException()
    {
        Assert.Throws<KeyNotFoundException>(() =>
        {
            grid.GetOccupant(position);
        });
        //check my exception behavior and make sure future changes won't cause harm.
    }

    [Test]
    public void ClearPosition_PositionWithUnit_RemovesUnit()
    {
        grid.Place(position, unit);
        bool cleared = grid.ClearPosition(position);
        Assert.IsTrue(cleared);
        Assert.IsFalse(grid.IsOccupied(position));
        //I want to check both the removal of unit and that the position is now clear
    }

    [Test]
    public void ClearUnit_UnitOnGrid_RemovesUnit()
    {
        grid.Place(position, unit);
        bool cleared = grid.ClearUnit(unit);
        Assert.IsTrue(cleared);
        Assert.IsFalse(grid.IsOccupied(position));
    }
}
