using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    [Header("Power Up Invencible")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerManager.Instance.PowerUpInvencible();
        PlayerManager.Instance.SetPowerUpText("Invencible");
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerManager.Instance.ResetInvencible();
        PlayerManager.Instance.SetPowerUpText("");
    }
}
