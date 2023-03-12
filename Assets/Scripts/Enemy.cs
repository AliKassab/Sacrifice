using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crashVFX;
    [SerializeField] GameObject cd;
    [SerializeField] int scoreAmount;
    [SerializeField] int hitpoint = 1;

    GameObject parentGameObject;
    Rigidbody rb;
    ScoreBoard scoreboard;

    private void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTimeParent");
        AddRigidBody();

    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitpoint < 1)
        {
            KillEnemy();
        }
    }
    private void AddRigidBody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    

    private void ProcessHit()
    {   
        hitpoint--;
        scoreboard.increaseScore(scoreAmount);
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(crashVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        cd.SetActive(false);
        Destroy(this.gameObject);
    }
}
