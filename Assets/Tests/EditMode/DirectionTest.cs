using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DirectionTest
{
    [Test]
    public void PlayerTest()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Player>();
        Assert.IsNotNull(gameObject);
    }
    [Test]
    public void EnemyTest()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Enemy>();
        Assert.IsNotNull(gameObject);
    }
    [Test]
    public void ArrowForce()
    {
        var go = new Shooting();
        Assert.AreEqual(go.arrowForce, 10f);
    }
}
