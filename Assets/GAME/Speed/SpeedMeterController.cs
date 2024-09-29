using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Watermelon;

public class SpeedMeterController : MonoBehaviour
{
    [SerializeField] RectTransform arrow;
    [SerializeField] TextMeshProUGUI maxSpeedText;
    [SerializeField] SpeedBoost speedBoost;
    private PlayerMovement playerMovement;
    private float originalEulerZ;
    private void OnEnable()
    {
        originalEulerZ = arrow.localEulerAngles.z;
    }
    public void Init(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void RotateArrow()
    {
        arrow.transform.DORotate(new Vector3(0,0,90),0.5f);
    }

    public void ResetArrow()
    {
        arrow.transform.DORotate(new Vector3(0, 0, originalEulerZ), 0.5f);
    }
    
    public void UpdateMaxSpeedText(float _)
    {
        maxSpeedText.text = playerMovement.GetSpeed().ToString();
    }
}
