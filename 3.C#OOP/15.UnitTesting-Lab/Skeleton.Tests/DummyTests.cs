using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLoseHealthAfterTakeDamage()
    {
        Dummy dummy = new Dummy(10,10);

        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5), "Dummy not attack properly");
    }

    [Test]
    public void DummyDeadNeedToThrowException()
    {
        Dummy dummy = new Dummy(0, 5);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(4));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0, 5);


        Assert.That(dummy.GiveExperience(), Is.EqualTo(5), "Dead Dummy doesnt Recieve XP.");
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        Dummy dummy = new Dummy(10,5);


        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
