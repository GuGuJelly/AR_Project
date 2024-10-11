using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] Animator m_Animator;

    private void Awake()
    {
        m_Animator.SetBool("Action", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌했어");
        if (SlimeAutoAttacker == null && collision.gameObject.CompareTag("KingSlime"))
        {
            SlimeAutoAttacker = StartCoroutine(SlimeAutoAttack());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌에서 벗어났어");
        if (SlimeAutoAttacker != null && collision.gameObject.CompareTag("KingSlime"))
        {
            m_Animator.SetBool("Action", false);
            StopCoroutine(SlimeAutoAttacker);
            SlimeAutoAttacker = null;
        }
    }

    Coroutine SlimeAutoAttacker;

    IEnumerator SlimeAutoAttack()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);
            m_Animator.SetBool("Action", true);
            yield return new WaitForSeconds(0.5f);
            m_Animator.SetBool("Action", false);
            yield return new WaitForSeconds(1f);
        }
    }
}
