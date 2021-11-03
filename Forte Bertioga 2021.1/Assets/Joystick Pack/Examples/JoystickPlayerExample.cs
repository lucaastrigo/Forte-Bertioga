using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed, walkingSoundSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public SpriteRenderer sprite;
    public Animator anim;

    private void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingSoundSpeed);
    }

    void CallFootsteps()
    {
        if(variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0)
        {
            print("moving");

            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx/exploracao_forte/sfx_player_passos", transform.position);
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = (Vector3.forward + Vector3.right) * variableJoystick.Vertical + (Vector3.right + Vector3.back) * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (direction.z > -1 && direction.z < 1.5f && direction.x < 1)
        {
            EsquerdaSprite();
        }
        else
        {
            DireitaSprite();
        }

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.z);
        anim.SetFloat("Speed", direction.sqrMagnitude);
    }



    void DireitaSprite()
    {
        sprite.flipX = true; //dir
    }
    void EsquerdaSprite()
    {
        sprite.flipX = false; //esq
    }
}