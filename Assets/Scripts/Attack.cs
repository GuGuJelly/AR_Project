using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Attack : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(ChangedState());
            }
        }else if (AttackIdleStateChange != null)
        {
            StopCoroutine(AttackIdleStateChange);
            AttackIdleStateChange = null;
        }
    }

    Coroutine AttackIdleStateChange;

    public IEnumerator ChangedState()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Action", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Action", false);
        yield return new WaitForSeconds(1f);
    } 
}
