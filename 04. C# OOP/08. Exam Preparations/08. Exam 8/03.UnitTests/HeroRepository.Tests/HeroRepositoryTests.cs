using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void TestCtor()
    {
        HeroRepository repo = new HeroRepository();

        Assert.That(repo.Heroes.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestCreateWithNull() 
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = null;
        
        Assert.That(() => repo.Create(hero), 
            Throws.ArgumentNullException, 
            string.Format(nameof(hero)), "Hero is null");
    }

    [Test]
    public void TestCreateWithExistHero()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Hero1", 1);
        repo.Create(hero);

        Assert.That(() => repo.Create(hero),
            Throws.InvalidOperationException,
            "Hero with name Hero1 already exists");
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void TestRemoveWithNullOrWhiteSpace(string name)
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Hero1", 1);
        repo.Create(hero);

        Assert.That(() => repo.Remove(name),
            Throws.ArgumentNullException,
            string.Format(nameof(name)), "Name cannot be null");
    }

    [Test]
    public void TestRemoveWithExistHero()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Hero1", 1);
        repo.Create(hero);

        bool isRemoved = repo.Remove("Hero1");

        Assert.That(isRemoved, Is.True);
    }

    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Hero1", 1);
        Hero hero2 = new Hero("Hero2", 2);
        Hero hero3 = new Hero("Hero3", 3);
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var heroWithHighestLevel = repo.GetHeroWithHighestLevel();

        Assert.That(heroWithHighestLevel, Is.EqualTo(hero3));
    }

    [Test]
    public void TestGetHero()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Hero1", 1);
        Hero hero2 = new Hero("Hero2", 2);
        Hero hero3 = new Hero("Hero3", 3);
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var returnedHero = repo.GetHero("Hero2");

        Assert.That(returnedHero, Is.EqualTo(hero2));
    }
}