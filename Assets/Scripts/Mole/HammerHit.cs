using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Mole"))
        {
            MoleBehaviour hole = other.gameObject.GetComponentInParent<Transform>().GetComponentInParent<MoleBehaviour>();
            hole.Hit();
        }
    }
}
