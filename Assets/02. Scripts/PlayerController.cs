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
    Quaternion originRotation;
    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        originPos = transform.position;
        originRotation = transform.rotation;
    }

    public void Jump()
    {
        if (GameManager.instance.CurrentState != GameManager.GameState.GAMESTART) return;

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

    public void resetPos()
    {
        transform.position = originPos;
        transform.rotation = originRotation;
    }
 
}
