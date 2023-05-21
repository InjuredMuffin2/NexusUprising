using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    public GameObject ringObject;
    public SkinnedMeshRenderer playerMesh;

    public float timer;

    public Material[] regularMaterials;
    public Material[] poweredUpMaterials;

    public ParticleSystem rays;

    public ParticleSystem laserParticleEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) /*TEMP*/ || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) /*TEMP*/ /*&& gameObject.GetComponent<PlayerBasicMovement>().isGrounded == true*/)
        {
            animator.SetInteger("PlayerState", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) /*TEMP*/ || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) /*TEMP*/ /*&& gameObject.GetComponent<PlayerBasicMovement>().isGrounded == true*/)
        {
            animator.SetInteger("PlayerState", 0);
        }
    }

    public void SetPlayerState(int playerState)
    {
        animator.SetInteger("PlayerState", playerState);
    }

    public void Shoot()
    {
        if (laserParticleEffect != null)
            laserParticleEffect.Play();
    }
}
