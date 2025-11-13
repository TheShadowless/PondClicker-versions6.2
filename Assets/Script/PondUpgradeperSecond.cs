using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pond Upgrade/Chill per Second", fileName = "Chill per Second")]
public class PondUpgradeperSecond : PondUpgrade
{
    public override void ApplyUpgrade()
    {
       GameObject go = Instantiate(PondManager.instance.ChillPerSecObjToSpawn,Vector3.zero, Quaternion.identity);
        go.GetComponent<PondPerSecondTimer>().ChillperSecond = UpgradeAmount;

        PondManager.instance.SimpleChillPerSecondIncrease(UpgradeAmount);
    }
}
