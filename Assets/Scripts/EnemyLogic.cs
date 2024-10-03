using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] GameObject crashVFX;
    [SerializeField] GameObject crashSFX;
    [SerializeField] GameObject collider;
    [SerializeField] int scoreAmount;
    [SerializeField] int killAmount;
    [SerializeField] int hitpoint = 1;

    GameObject parentGameObject;
    Rigidbody rigidBody;
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
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    

    private void ProcessHit()
    {   
        hitpoint--;
        scoreboard.increaseScore(scoreAmount);
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(crashVFX, transform.position, Quaternion.identity);
        GameObject sfx = Instantiate(crashSFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        sfx.GetComponent<AudioSource>().Play(); 
        collider.SetActive(false);
        scoreboard.increaseScore(killAmount);
        Destroy(this.gameObject);
    }
}