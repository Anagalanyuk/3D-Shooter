using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scorelable;

    void Update()
    {
        _scorelable.text = Time.realtimeSinceStartup.ToString();
    }

    public void OpenSettings()
    {
    }

    public void OnPointerDown()
    {
        Debug.LogError("Pointer down");
    }
}
