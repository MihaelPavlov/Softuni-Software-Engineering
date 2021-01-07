using Moq;
using NUnit.Framework;


[TestFixture]
public class HeroTests
{
   
    [Test]
    public void HeroShouldGainExperienceIfTargerDies()
    {
        const int experiencer = 200;
        var weapon = Mock.Of<IWeapon>();
        var target = new Mock<ITarget>();
        target.Setup(t => t.IsDead())
            .Returns(true);

        target.Setup(t => t.GiveExperience()).Returns(experiencer); ;

        var hero = new Hero("TestHero", weapon);

        hero.Attack(target.Object);

        Assert.That(hero.Experience,Is.EqualTo(experiencer));
    }
}