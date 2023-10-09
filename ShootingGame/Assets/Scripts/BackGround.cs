using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private Material bgMat;
    private float _scrollSpeed = 0.2f;

    private void Update()
    {
        Vector2 direction = Vector2.up;
        ;

        bgMat.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
