using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuteSlimeControll : MonoBehaviour
{
    [SerializeField] Slider cuteSlimeSlider;
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] CuteSlimeModel cuteSlimeModel;
    private Touch touch;

    private void Awake()
    {
        cuteSlimeSlider.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        cuteSlimeModel.OnCuteSlimeHPChanged += UpdateHP;
    }

    private void OnDisable()
    {
        cuteSlimeModel.OnCuteSlimeHPChanged -= UpdateHP;
    }

    private void Start()
    {
        UpdateHP(cuteSlimeModel.CuteSlimeHP);
    }

    #region UI
    private void UpdateHP(int CuteSlimeHP)
    {
        cuteSlimeSlider.value = CuteSlimeHP;
    }
    #endregion 

    private void Update()
    {
         if (Input.touchCount > 0)
         {
             touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                cuteSlimeSlider.gameObject.SetActive(true);
                cuteSlimeModel.CuteSlimeHP = cuteSlimeModel.CuteSlimeHP - 1;

                if (cuteSlimeModel.CuteSlimeHP == 0)
                {
                    Destroy(gameObject);
                    cuteSlimeSlider.gameObject.SetActive(false);
                }
            }
         }
    }
}
