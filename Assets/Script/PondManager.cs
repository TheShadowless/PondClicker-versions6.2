using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PondManager : MonoBehaviour
{
    public static PondManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private TextMeshProUGUI chillCountText;
    [SerializeField] private TextMeshProUGUI chillPerSecondText;
    [SerializeField] private GameObject pondObj;
    public GameObject pondTextPopup;
    [SerializeField] private AudioSource pondSoundClick;
    [SerializeField] private GameObject backgroundObj;

    [Space]
    public PondUpgrade[] PondUpgrades;
    [SerializeField] private GameObject upgradeUIToSpawn;
    [SerializeField] private Transform upgradeUIParent;
    public GameObject ChillPerSecObjToSpawn;

    public double CurrentChillCount {  get; set; }
    public double CurrentChillPerSecond { get; set; }

    //เขตอัพของ

    public double ChillPerClickUpgrade { get; set; }

    private InitializeUpgrades initializeUpgrades;
    private ChillDisplay chillDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        chillDisplay = GetComponent<ChillDisplay>();

        UpdateChillUI();
        UpdateChillPerSecondUI();

        upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);

        initializeUpgrades = GetComponent<InitializeUpgrades>();
        initializeUpgrades.Initialize(PondUpgrades, upgradeUIToSpawn, upgradeUIParent);
    }

    #region On Clicked
    public void OnChillClicked()
    {
        IncreaseChill();

        pondObj.transform.DOBlendableScaleBy(new Vector3(0.10f, 0.05f, 0.10f), 0.10f).OnComplete(PondscaleBack);
        backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.0f, 0.0f, 0.0f), 0.0f).OnComplete(BackgroundScaleBack);

        PopUpText.Create(1 + ChillPerClickUpgrade);
        pondSoundClick.Play();
    }

    private void PondscaleBack()
    {
        pondObj.transform.DOBlendableScaleBy(new Vector3(-0.10f, -0.05f, -0.10f), -0.10f);
    }

    private void BackgroundScaleBack()
    {
        backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.00f, 0.0f, 0.0f), 0.0f);
    }

    public void IncreaseChill()
    {
        CurrentChillCount += 1 + ChillPerClickUpgrade;
        UpdateChillUI();
    }

    #endregion

    #region UI Update
    //อัพเดต
    public void UpdateChillUI()
    {
        //chillCountText.text = CurrentChillCount.ToString();
        chillDisplay.UpdateChillText(CurrentChillCount,chillCountText);
    }

    private void UpdateChillPerSecondUI()
    {
        //chillPerSecondText.text = CurrentChillPerSecond.ToString() + "Chill/S";
        chillDisplay.UpdateChillText(CurrentChillPerSecond,chillPerSecondText, " Chill/S");
    }
    #endregion

    #region Button presses
    public void OnUpgradeButtonpress() 
    {
        MainGameCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
    }
    public void OnResumeButtonpress() 
    {
        upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }
    #endregion

    #region Simple increases
    public void SimpleChillIncreases(double amount)
    {
        CurrentChillCount += amount;
        UpdateChillUI();
        
    }
    public void SimpleChillPerSecondIncrease(double amount)
    {
        CurrentChillPerSecond += amount; 
        UpdateChillPerSecondUI();

    }
    #endregion

    #region Event

    public void OnUpgradeButtononClick(PondUpgrade upgrade,UpgradeButtonRef buttonRef)
    {
        if(CurrentChillCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrentChillCount -= upgrade.CurrentUpgradeCost;
            UpdateChillUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreasePerPurchase)));

            buttonRef.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }

    #endregion
}
