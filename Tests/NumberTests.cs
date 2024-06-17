using MiniMaple;

namespace Tests;

public class NumberTests
{
    [Test]
    public void TestConstructor()
    {
        var n = new Number(1);
        Assert.That(n, Is.Not.Null);
    }

    [Test]
    public void TestEq()
    {
        var n1 = new Number(1);
        var n2 = new Number(1);
        var n3 = new Number(2);
        Assert.Multiple(() =>
        {
            Assert.That(n1.Eq(n2), Is.True);
            Assert.That(n1.Eq(n3), Is.False);
            Assert.That(n2.Eq(n3), Is.False);
        });
    }

    [Test]
    public void TestAdd()
    {
        var n1 = new Number(1);
        var n2 = new Number(2);

        Assert.Multiple(() =>
        {
            Assert.That(((Number)n1.Add(n2)).Value, Is.EqualTo(3));
            Assert.That(((Number)n2.Add(n1)).Value, Is.EqualTo(3));
        });
    }

    [Test]
    public void TestSub()
    {
        var n1 = new Number(1);
        var n2 = new Number(2);

        Assert.Multiple(() =>
        {
            Assert.That(((Number)n1.Sub(n2)).Value, Is.EqualTo(-1));
            Assert.That(((Number)n2.Sub(n1)).Value, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestNeg()
    {
        var n = new Number(1);
        Assert.That(((Number)n.Neg()).Value, Is.EqualTo(-1));
    }

    [Test]
    public void TestNegative()
    {
        var n = new Number(1);
        Assert.Multiple(() =>
        {
            Assert.That(n.Negative, Is.False);
            Assert.That(n.Neg().Negative, Is.True);
        });
    }

    [Test]
    public void TestDiff()
    {
        var n = new Number(1);
        Assert.Multiple(() =>
        {
            Assert.That(((Number)n.Diff()).Value, Is.EqualTo(0));
            Assert.That(((Number)n.Neg().Diff()).Value, Is.EqualTo(0));
        });
    }

    [Test]
    public void TestToString()
    {
        var n = new Number(1);
        Assert.Multiple(() =>
        {
            Assert.That(n.ToString(), Is.EqualTo("1"));
            Assert.That(n.Neg().ToString(), Is.EqualTo("-1"));
        });
    }
}
