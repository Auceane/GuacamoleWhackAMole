using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _MoleList = new List<GameObject>();

    //public bool _canSpawn = true;

    public GameObject GetRandomMole()
    {
        if (_MoleList.Count > 0) return _MoleList[Random.Range(0, _MoleList.Count)];
        else return null;
    }
}
