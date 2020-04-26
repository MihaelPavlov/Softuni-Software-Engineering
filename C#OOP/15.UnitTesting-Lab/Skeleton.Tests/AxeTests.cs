using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    
    [Test]
    public void AxeLooseDurabilityAfterAttack()
    {
        Axe axe = new Axe(10,10);
        Dummy dummy = new Dummy(10, 10);
        axe.Attack(dummy) ;

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doest't change after attack.");
    }

    [Test]
    public void AttacingWithBrokenWeapon()
    {
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(10, 10);
        
        Assert.Throws<InvalidOperationException>(()=> axe.Attack(dummy));
    }

 
}