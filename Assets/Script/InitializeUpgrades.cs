using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InitializeUpgrades : MonoBehaviour
{
   public void Initialize(PondUpgrade[] upgrades,GameObject UIToSpawn,Transform spawnParent)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int currentIndex = i;

            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            upgrades[currentIndex].CurrentUpgradeCost = upgrades[currentIndex].OriginalUpgradeCost;

            //set text
            UpgradeButtonRef buttonRef = go.GetComponent<UpgradeButtonRef>();
            buttonRef.UpgradeButtonText.text = upgrades[currentIndex].UpgradeButtonText;
            buttonRef.UpgradedescriptionText.SetText(upgrades[currentIndex].UpgradeButtonDescription, upgrades[currentIndex].UpgradeAmount);
            buttonRef.UpgradeCostText.text = "Cost: " + upgrades[currentIndex].CurrentUpgradeCost;

            //set onClick
            buttonRef.UpgradeButton.onClick.AddListener(delegate { PondManager.instance.OnUpgradeButtononClick(upgrades[currentIndex], buttonRef); });
        }
    }
}
