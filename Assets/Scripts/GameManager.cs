using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI�]�w")]
    public Image lifeBarImage;

    // �禡�G��s���
    public void UpdateLifeBar(float _value)
    {
        lifeBarImage.fillAmount = _value;
    }
}