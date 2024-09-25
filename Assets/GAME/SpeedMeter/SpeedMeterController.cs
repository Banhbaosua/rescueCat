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
    private void Awake()
    {
        originalEulerZ = arrow.localEulerAngles.z;

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.AddOnMoveAction(RotateArrow);
        playerMovement.AddOnStopAction(ResetArrow);

        speedBoost.AddBoostAction(UpdateMaxSpeedText);
    }

    void RotateArrow()
    {
        arrow.transform.DORotate(new Vector3(0,0,90),0.5f);
    }

    void ResetArrow()
    {
        arrow.transform.DORotate(new Vector3(0, 0, originalEulerZ), 0.5f);
    }
    
    void UpdateMaxSpeedText()
    {
        maxSpeedText.text = playerMovement.GetSpeed().ToString();
    }
}
