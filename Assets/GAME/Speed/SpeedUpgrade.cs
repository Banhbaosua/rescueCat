using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpeedUpgrade : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] Button raceButton;
    [SerializeField] float speedPerUpgrade;
    [SerializeField] TextMeshProUGUI speedText;
    private bool doneUpgrade;
    private float speedUpgrade;
    public Button Button => upgradeButton;
    public Button RaceButton => raceButton;
    public float SpeedUpgradeValue => speedUpgrade;
    public bool DoneUpgrade=> doneUpgrade;
    public void Init()
    {
        speedUpgrade = 0;
        upgradeButton.onClick.AddListener(() => Upgrade());
    }

    void Upgrade()
    {
        speedUpgrade += speedPerUpgrade;
        speedText.text = speedUpgrade.ToString("0.0");
    }
}
