using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;


// Nu har jag gjort n�gra enkla tester. Det va inte s� l�tt att g�ra men till slut s� lyckades jag
// Och f�rst� vikten av att kunna testa koden utan att beh�va starta spelet varenda g�ng.
// Tex om man m�ste l�gnt in i spelet f�r att testa s� att koden verklgen funkar.
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
