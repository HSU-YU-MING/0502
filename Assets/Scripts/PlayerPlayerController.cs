using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("玩家基本設定")]
    public float maxLifeValue;               // 設定玩家最高生命值
    public float lifeHpChangeUnit;           // 設定每次改變生命值的單位

    [Header("UI控制元件")]
    public GameManager gameManager;

    float lifeValue;

    void Start()
    {
        lifeValue = maxLifeValue;
    }

    // 碰撞偵測
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            lifeValue -= lifeHpChangeUnit;
            gameManager.UpdateLifeBar(lifeValue / maxLifeValue); // 更新血條
        }
    }
}
