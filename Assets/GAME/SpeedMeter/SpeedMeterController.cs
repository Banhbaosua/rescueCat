using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Watermelon;

public class SpeedMeterController : MonoBehaviour
{
    [SerializeField] RectTransform arrow;

    private void Start()
    {
    }

    private void Update()
    {
        RotateArrow();
    }

    void RotateArrow()
    {
        arrow.transform.DORotate(new Vector3(0,0,90),0.5f);
    }
    
}
