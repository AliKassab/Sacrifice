using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashCollision : MonoBehaviour
{
    //This Script processes the crashing of the player after colliding with an obstacle

    private PlayerControls controls;
    private MeshRenderer meshRenderer;
    [SerializeField] private GameObject Timeline;
    [SerializeField] private float delayTime = 1f;
    [SerializeField] private ParticleSystem crashVFX;

    private void Start()
    {
        controls = GetComponent<PlayerControls>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CrashSequence();
        Invoke(nameof(Reset), delayTime);
    }

    private void CrashSequence()
    {
        crashVFX.Play();
        controls.enabled = false;
        meshRenderer.enabled = false;
        //Timeline.SetActive(false);
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
