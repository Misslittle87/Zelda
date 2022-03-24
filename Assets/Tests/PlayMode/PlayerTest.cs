using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;


// Nu har jag gjort några enkla tester. Det va inte så lätt att göra men till slut så lyckades jag
// Och förstå vikten av att kunna testa koden utan att behöva starta spelet varenda gång.
// Tex om man måste lågnt in i spelet för att testa så att koden verklgen funkar.
public class PlayerTests
{
    [UnityTest]
    public IEnumerator SceneTransition()
    {
        var gameObject = new GameObject();
        var sceneTransition = gameObject.AddComponent<SceneTransition>();
        yield return sceneTransition;
    }
    public IEnumerator PlayerMovement()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<Player>();
        player.Movement();

        yield return new WaitForSeconds(1);

        Assert.AreEqual(expected: new Vector3 (0, 1, 0), actual: gameObject.transform.position);
    }

}
