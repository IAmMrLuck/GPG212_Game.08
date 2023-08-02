using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuryBone : MonoBehaviour
{
    // ChatGPt designed this

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            DogCharacter dogCharacter = collision.GetComponent<DogCharacter>();

            if (dogCharacter != null)
            {
                // Call the function to add buryPoint if the player has bonePoint
                dogCharacter.AddBuryPoint();
            }
        }
    }


}
