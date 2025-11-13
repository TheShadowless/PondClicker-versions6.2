using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMinus : CoinManager
{
    protected override void ApplyEffect()
    {
        PondManager.instance.CurrentChillCount /= 2;
        PondManager.instance.UpdateChillUI();
    }
}
