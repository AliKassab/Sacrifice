using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    PlayerControls controls;
    MeshRenderer mr;
    [SerializeField] GameObject Timeline;
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crashVFX;

    private void Start()
    {
        controls = GetComponent<PlayerControls>();
        mr = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CrashSequence();
        Invoke("Reset", delayTime);
    }

    private void CrashSequence()
    {
        crashVFX.Play();
        controls.enabled = false;
        mr.enabled = false;
        //Timeline.SetActive(false);
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
