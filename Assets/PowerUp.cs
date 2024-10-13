using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreMultipliyerText;

    private void Start()
    {
        scoreMultipliyerText.text = "x1";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Stats.Instance.scoreMultiplier += 0.5f;
            scoreMultipliyerText.text = "x" + Stats.Instance.scoreMultiplier.ToString();
            Destroy(gameObject.transform.parent.gameObject);
        }
            
    }
}
