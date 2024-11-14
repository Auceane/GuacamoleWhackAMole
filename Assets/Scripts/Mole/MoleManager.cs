using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _MoleList = new List<GameObject>();

    [SerializeField]
    private GameObject _restart;

    [SerializeField]
    private float _minSpawnDelay, _startSpawnDelay;

    public UIController _scoreBoard;

    private MoleBehaviour[] _moles;
    public bool _canSpawn = true;

    private void Start() {
        _moles = GetComponentsInChildren<MoleBehaviour>();
    }

    public GameObject GetRandomMole()
    {
        if (_MoleList.Count > 0) return _MoleList[Random.Range(0, _MoleList.Count)];
        else return null;
    }

    private void CanSpawnInRandomHole()
    {
        if (_moles.Length > 0) 
        {
            int start = Random.Range(0, _moles.Length);
            for (int i = start; i < _moles.Length + start; i++)
            {
                if (i == _moles.Length){
                    i = 0;
                }
                if (_moles[i].CanSpawn())
                {
                    _moles[i]._canSpawnHere = true;
                    break;
                }
                if (i == start -1) break;
            }
        }
        else Debug.LogError("Component MoleBehaviour not found on GameObject ");
    }

    private IEnumerator SpawnWithInterval()
    {
        Debug.Log("start game");
        float time = _startSpawnDelay;
        while (_scoreBoard._numberHearts > 0)
        {
            Debug.Log("start Spawn");
            CanSpawnInRandomHole();
            yield return new WaitForSeconds(time);
            if (time > _minSpawnDelay + 0.1f) time -= 0.1f;
            _canSpawn = true;
        }
        _restart.SetActive(true);
        Debug.Log("stop game");
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnWithInterval());
    }
}
