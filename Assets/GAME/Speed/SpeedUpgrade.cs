using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpeedUpgrade : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] float speedPerUpgrade;
    public Button Button => button;
    public float SpeedPerUpgrade => speedPerUpgrade;
}
