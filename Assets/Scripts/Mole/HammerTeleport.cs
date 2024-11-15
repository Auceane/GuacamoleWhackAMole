using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTeleport : MonoBehaviour
{
    [SerializeField]
    private Transform _hammer;

    [SerializeField]
    private float _distance;

    // Update is called once per frame
    void Update()
    {
        if((_hammer.position - transform.position).magnitude > _distance)
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        _hammer.rotation = transform.rotation;
        _hammer.position = transform.position;
    }
}
