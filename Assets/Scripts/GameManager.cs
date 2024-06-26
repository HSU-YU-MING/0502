using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI設定")]
    public Image lifeBarImage;

    // 函式：更新血條
    public void UpdateLifeBar(float _value)
    {
        lifeBarImage.fillAmount = _value;
    }
}