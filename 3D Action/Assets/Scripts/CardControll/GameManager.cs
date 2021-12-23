﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    OnStart,
    OnField,
    OnMenu,
    OnGameover,
}

public class GameManager : MonoBehaviour
{
    [SerializeField,Tooltip("カードを管理するパネル")] 
    GameObject m_playerUI;   
    [SerializeField, Tooltip("プレイヤーを操作するクラス")] 
    FPSPlayerMove _playercon;
    [SerializeField, Tooltip("カード情報を表示するパネル")] 
    GameObject _cardInfo;
    [SerializeField, Tooltip("スキルツリーを表示するパネル")] 
    GameObject _SkillPanel;
    /// <summary>/// パネルが表示されているかどうかのフラグ/// </summary>
    bool isPanel = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPanel)
        {
            PanelOn();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPanel)
        {
            PanelOf();
        }
    }

    public void PanelOn()
    {
        m_playerUI.SetActive(true);
        isPanel = true;
        _playercon.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PanelOf()
    {
        m_playerUI.SetActive(false);
        isPanel = false;
        _playercon.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void InfoOnOf(bool isActive)
    {
        _cardInfo.SetActive(isActive);
    }
    public void SkillTreeOn(bool isactive)
    {
        _SkillPanel.SetActive(isactive);
    }
}
