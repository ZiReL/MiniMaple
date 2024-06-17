using MiniMaple;

namespace Tests;

public class SumTests
{
    [Test]
    public void TestConstructor()
    {
        var x = new Term("x");
        var n = new Number(1);
        var s = new Sum(x, n);
        Assert.That(s, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(s.Lhs.Eq(x), Is.True);
            Assert.That(s.Rhs.Eq(n), Is.True);
        });
    }

    [Test]
    public void TestEq()
    {
        var x = new Term("x");
        var n = new Number(1);
        var s = new Sum(x, n);
        Assert.That(s.Eq(x.Add(n)));
    }

    [Test]
    public void TestNeg()
    {
        var s = new Sum(new Term("x"), new Number(1));
        s = (Sum)s.Neg();
        Assert.That(((Number)s.Rhs).Value, Is.EqualTo(-1));
    }

    [Test]
    public void TestAdd()
    {
        var x = new Term("x");
        var n = new Number(1);
        var s = new Sum(x);
        Assert.Multiple(() =>
        {
            Assert.That(s.Lhs.Eq(x));
            Assert.That(s.Rhs, Is.Null);
        });

        s = (Sum)s.Add(n);

        Assert.Multiple(() =>
        {
            Assert.That(s.Lhs.Eq(x), Is.True);
            Assert.That(s.Rhs.Eq(n), Is.True);
        });
    }

    [Test]
    public void TestSub()
    {
        var x = new Term("x");
        var n = new Number(1);
        var s = new Sum(x);
        Assert.Multiple(() =>
        {
            Assert.That(s.Lhs.Eq(x));
            Assert.That(s.Rhs, Is.Null);
        });

        s = (Sum)s.Sub(n);

        Assert.Multiple(() =>
        {
            Assert.That(s.Lhs.Eq(x), Is.True);
            Assert.That(s.Rhs.Eq(n.Neg()), Is.True);
        });
    }

    [Test]
    public void TestDiff()
    {
        var x = new Term("x");
        var n = new Number(1);
        Assert.Multiple(() =>
        {
            Assert.That(x.Add(n).Diff("x").Eq(n), Is.True);
            Assert.That(x.Pow(2).Add(x).Diff("x").Eq(x.Mul(2).Add(n)), Is.True);
            Assert.That(x.Pow(2).Add(x).Diff("y").Eq(new Number(0)), Is.True);
        });
    }

    [Test]
    public void TestToString()
    {
        var x = new Term("x");
        var n = new Number(1);
        var s = new Sum(x);
        Assert.Multiple(() =>
        {
            Assert.That(s.ToString(), Is.EqualTo("x"));
            Assert.That(s.Add(n).ToString(), Is.EqualTo("x + 1"));
            Assert.That(s.Sub(n).ToString(), Is.EqualTo("x - 1"));
        });
    }
}
