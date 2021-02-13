using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public Transform target;
    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    
    void Update()
    {
        var wantedPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = wantedPos;
    }
}
