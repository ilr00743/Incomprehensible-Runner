using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    private PlayerMovement playerMovement = new GameObject().AddComponent<PlayerMovement>().GetComponent<PlayerMovement>();
    // A Test behaves as an ordinary method
    [Test]
    public void WhenPlayerCollideObstacle_PlayerCantMove()
    {
        playerMovement = new GameObject().AddComponent<PlayerMovement>().GetComponent<PlayerMovement>();
        playerMovement.OnHit();
        Assert.IsFalse(playerMovement.CanRun);
    }
    
    [Test]
    public void WhenPlayerCollideCoin_AddOneCoinToWallet()
    {
        MoneyHolder playerMoney = new GameObject().AddComponent<MoneyHolder>().GetComponent<MoneyHolder>();
        Coin coin = new GameObject().AddComponent<Coin>().GetComponent<Coin>();
        
        playerMoney.AddMoney(coin.Value);
        
        Assert.AreEqual(1, playerMoney.Balance);
    }

    [Test]
    public void WhenLevelStarted_PlayerCanMove()
    {
        playerMovement.OnStarted();
        Assert.IsTrue(playerMovement.CanRun);
    }
    
    
}
