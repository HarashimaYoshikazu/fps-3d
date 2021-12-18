﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float _movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float _turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] float _jumpPower = 5f;
    /// <summary>接地判定の際、足元からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float _isGroundedLength = 0.2f;
    Rigidbody _rb;
    /// <summary>キャラクターの Animator</summary>
    [SerializeField] Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
            this.transform.forward = dir;   // そのベクトルの方向にオブジェクトを向ける

            // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する。
            Vector3 velo = this.transform.forward * _movingSpeed;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }
}
