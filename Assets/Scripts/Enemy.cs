using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject crashVFX;
    [SerializeField] GameObject cd;
    [SerializeField] Transform parent; 

    private void OnParticleCollision(GameObject other)
    {
        destroySequence();
    }

    private void destroySequence()
    {
        crashVfxSpawn();
        cd.SetActive(false);
        Destroy(this.gameObject);
    }

    private void crashVfxSpawn()
    {
        GameObject vfx = Instantiate(crashVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }
}
