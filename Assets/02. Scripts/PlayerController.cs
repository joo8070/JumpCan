using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip jump;
}


public class PlayerController : MonoBehaviour
{
    [SerializeField] int jumpPower;
    [SerializeField] PlayerAnim animClip;
    Animation anim;
    Vector3 originPos;
    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }

    public void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            anim.clip = animClip.jump;
            anim.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Block")
        {
            if(isJump)
            {
                isJump = false;
                anim.clip = animClip.idle;
                anim.Play();
            }
        }
    }
}
