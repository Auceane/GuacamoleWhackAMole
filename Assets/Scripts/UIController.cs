using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField]
    TMP_Text _Score;

    [SerializeField]
    TMP_Text _Combos;

    [SerializeField]
    Transform _ScrollViewHeart;

    int _score=0;

    int _combos = 0;


    float _timePassedBeforeLosingACombos=0;

    float _maxTimeForLosingACombos = 3;


    float _timePassedBeforeLosingAHeart=0;

    float _maxTimeForLosingAHeart=5;

    bool _whacked = false;


    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        _timePassedBeforeLosingAHeart=Time.deltaTime;
        _timePassedBeforeLosingACombos=Time.deltaTime;


        if (_whacked)
        {
            _whacked = false;

            _ScrollViewHeart.GetChild(0).gameObject.SetActive(false);

            _timePassedBeforeLosingACombos = 0;

            _timePassedBeforeLosingAHeart = 0;

        }

        if (_timePassedBeforeLosingACombos >= _maxTimeForLosingACombos)
        {
            _combos = 0;

        }


    }


    private void UpadteCombos()
    {

    }


    private void UpdateScore()
    {
        
    }


}
