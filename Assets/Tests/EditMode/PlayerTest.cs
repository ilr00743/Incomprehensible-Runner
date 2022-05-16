using NUnit.Framework;
using UnityEngine;

public class PlayerTest
{
    private PlayerMovement _playerMovement = new GameObject().AddComponent<PlayerMovement>().GetComponent<PlayerMovement>();

    [Test]
    public void WhenPlayerCollideObstacle_PlayerCantMove()
    {
        _playerMovement.OnHit();
        Assert.IsFalse(_playerMovement.CanRun);
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
        _playerMovement.OnStarted();
        Assert.IsTrue(_playerMovement.CanRun);
    }
}
