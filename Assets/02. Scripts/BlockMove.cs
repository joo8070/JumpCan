using System.Collections;
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
            // 옆면에서 맞은거면 그냥 그대로 밀어버림
            // 위면 멈춤
            isPlayerUp = true;
            if (!isClear)
            {
                isClear = true;
                GameManager.instance.ScoreUp();
            }
        }
    }
}
