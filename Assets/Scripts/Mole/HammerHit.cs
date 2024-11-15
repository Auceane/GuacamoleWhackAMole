using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{

    private bool _canHit = true;
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Mole") && _canHit)
        {
            _canHit = false;
            MoleBehaviour hole = other.gameObject.GetComponentInParent<Transform>().GetComponentInParent<MoleBehaviour>();
            hole.Hit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("MoleZone"))
        {
            _canHit = true;
        }
    }
}
