using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : PowerUpBase
{
    [Header("Power Up Jump")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerManager.Instance.PowerUpJump();
        PlayerManager.Instance.SetPowerUpText("Jump");
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerManager.Instance.ResetJump();
        PlayerManager.Instance.SetPowerUpText("");
    }
}
