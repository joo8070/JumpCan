﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // --------------------- 텍스처 관련 변수 --------------------- //
    [SerializeField] Texture[] textures; // 바꿀 텍스쳐들
    MeshRenderer mesh;

    // --------------------- 이동 관련 변수 --------------------- //
    Vector3 target;                      // 도착지점
    float speed;                         // 이동 스피드

    bool isPlayerUp;
    bool isClear;
    void Start()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        mesh.material.mainTexture = textures[Random.Range(0, textures.Length)];
        target = transform.position;
        target.x = 0;

        speed = Random.Range(0.5f, 1.0f);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (transform.position.x != 0 && !isPlayerUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 1);
            yield return null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerUp = true;

            if (transform.position.y - collision.gameObject.transform.position.y < -0.12f)
            {
                if (!isClear)
                {
                    isClear = true;
                    GameManager.instance.ScoreUp();
                }
            }
            else
            {
                // 못탔을 경우
                GameManager.instance.GameOver();
            }
        }
    }
}
