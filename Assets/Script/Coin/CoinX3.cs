using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinX3 : CoinManager
{
    protected override void ApplyEffect()
    {
        PondManager.instance.CurrentChillCount *= 3;
        PondManager.instance.UpdateChillUI();
    }
}
