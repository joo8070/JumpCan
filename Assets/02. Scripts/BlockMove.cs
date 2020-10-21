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

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.mainTexture = textures[Random.Range(0, textures.Length)];
        target = transform.position;
        target.x = 0;

        speed = Random.Range(0.8f, 1.2f);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (transform.position.x != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }

        transform.position = new Vector3(0, target.y, target.z);
    }
   
}
