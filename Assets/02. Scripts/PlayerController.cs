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

    void Update()
    {
        Jump();
    }
    
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
                //transform.position = new Vector3(0,transform.position.y, )
                anim.clip = animClip.idle;
                anim.Play();
            }
        }
    }
}
