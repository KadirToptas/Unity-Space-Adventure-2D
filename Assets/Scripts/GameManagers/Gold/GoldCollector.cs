using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
        {
            GetComponentInParent<GoldCollectedManager>().DisableGold();
            FindObjectOfType<GameScoreController>().CollectGold();
        }
    }
}
