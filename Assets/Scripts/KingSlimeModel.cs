using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KingSlimeModel : MonoBehaviour
{
    [SerializeField] int kingSlimeHp;
    public int KingSlimeHP { get { return kingSlimeHp; } set { kingSlimeHp = value; OnKingSlimeHPChanged?.Invoke(kingSlimeHp); } }
    public UnityAction<int> OnKingSlimeHPChanged;
}
