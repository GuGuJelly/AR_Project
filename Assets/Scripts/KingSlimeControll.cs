using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingSlimeControll : MonoBehaviour
{
    [SerializeField] Slider kingSlimeSlider;
    [SerializeField] KingSlimeModel kingSlimeModel;

    private void OnEnable()
    {
        kingSlimeModel.OnKingSlimeHPChanged += UpdateHP;
    }

    private void OnDisable()
    {
        kingSlimeModel.OnKingSlimeHPChanged -= UpdateHP;
    }

    private void Start()
    {
        UpdateHP(kingSlimeModel.KingSlimeHP);
    }

    #region UI
    private void UpdateHP(int KingSlimeHP)
    {
        kingSlimeSlider.value = KingSlimeHP;
    }
    #endregion 

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            kingSlimeModel.KingSlimeHP -= 0;
        }
    }
}
