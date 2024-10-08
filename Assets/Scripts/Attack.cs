using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] CapsuleCollider myCollider;
    private Touch touch;
    

    private void Awake()
    {
        myCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        
    }
    private void CheckTarget()
    {
        
    }

    private void Attack()
    {

    }

}
