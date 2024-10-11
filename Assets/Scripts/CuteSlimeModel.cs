using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CuteSlimeModel : MonoBehaviour
{
    [SerializeField] int cuteSlimeHp;
    public int CuteSlimeHP { get { return cuteSlimeHp; } set { cuteSlimeHp = value; OnCuteSlimeHPChanged?.Invoke(cuteSlimeHp); } }
    public UnityAction<int> OnCuteSlimeHPChanged;
}
