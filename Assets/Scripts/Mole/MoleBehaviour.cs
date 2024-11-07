using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoleBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _startPos;

    [SerializeField]
    private Transform _endPos;
    private MoleManager _MoleManager;
    private GameObject _currentMole = null;
    public bool _canSpawnHere = false;


    private void Start() 
    {
        _MoleManager = GetComponentInParent<MoleManager>();
    }

    private void Update() 
    {
        if (_canSpawnHere)
        {
            SpawnMole();
            StartCoroutine(MoveMole());
            _canSpawnHere = false;
        }
    }

    private void SpawnMole()
    {
        _currentMole = Instantiate(_MoleManager.GetRandomMole(), transform, true);
        _currentMole.transform.localPosition = _startPos.localPosition;
        _currentMole.transform.Rotate( 0, 0, 90);
    }

    private IEnumerator MoveMole()
    {
        if (_currentMole) 
        {
            _currentMole.transform.DOMove(_endPos.position, 0.5f).SetEase(Ease.Linear);
        }
        yield return new WaitForSeconds(2f);
        if (_currentMole) 
        {
            _currentMole.transform.DOMove(_startPos.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => StartCoroutine(DestroyMole()));
        }
    }

    private IEnumerator DestroyMole()
    {
        Destroy(_currentMole);
        yield return new WaitForSeconds(3f);
        _canSpawnHere = true;
    }
}
