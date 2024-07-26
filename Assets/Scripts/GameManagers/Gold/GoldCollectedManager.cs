using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollectedManager : MonoBehaviour
{
   [SerializeField] private GameObject gold;

   public void EnableGold()
   {
      gold.SetActive(true);
   }
   
   public void DisableGold()
   {
      gold.SetActive(false);
   }
   
}
