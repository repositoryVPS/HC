using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerManager.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerManager.Instance.SetPowerUpText("Speed up");
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerManager.Instance.ResetSpeed();
        PlayerManager.Instance.SetPowerUpText("");
    }

}
