using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    [Test]
    public void WhenLevelStarted_PlayerCanMove()
    {
        PlayerMovement playerMovement = new GameObject().AddComponent<PlayerMovement>();

        playerMovement.OnStarted();
        
        Assert.IsTrue(playerMovement.CanRun);
    }
    
    [Test]
    public void WhenPlayerCollideObstacle_PlayerCantMove()
    {
        PlayerMovement playerMovement = new GameObject().AddComponent<PlayerMovement>();
        playerMovement.Initialize(new GameObject().AddComponent<Rigidbody>());
        
        playerMovement.OnHit();
        
        Assert.IsFalse(playerMovement.CanRun);
        Assert.AreEqual(Vector3.zero, playerMovement.Velocity);
    }
    
    [Test]
    public void WhenPlayerCollideCoin_AddOneCoinToWallet()
    {
        MoneyHolder playerMoney = new GameObject().AddComponent<MoneyHolder>();
        Coin coin = new GameObject().AddComponent<Coin>();
 
        playerMoney.AddMoney(coin.Value);
 
        Assert.AreEqual(1, playerMoney.Balance);
    }
}
