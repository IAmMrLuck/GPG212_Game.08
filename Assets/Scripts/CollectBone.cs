using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBone : MonoBehaviour
{

    private void Update()
    {
        //Debug.Log("You have " + DogCharacter.bonePoints + " Bone Points");
    }

    private void OnTriggerEnter(Collider collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            Debug.Log("Trigger");
            DogCharacter.bonePoints++;
        }

      
    }
}
