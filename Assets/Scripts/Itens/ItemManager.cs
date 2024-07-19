using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ItemManager : Singleton<ItemManager>
{
    //public TextMeshProUGUI txCoin;
    //public TextMeshProUGUI txPlanet;

    public SOInt coins;
    public SOInt planets;
    public void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        //txCoin.text = "x " + coins.ToString();
    }
    public void AddPlanets(int amount = 1)
    {
        planets.value += amount;
        //txPlanet.text = "x " + planets.ToString();
    }
}
