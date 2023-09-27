using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Best Score"))
            _counter.text = "0";

        _counter.text = PlayerPrefs.GetInt("Best Score").ToString();
    }
}
