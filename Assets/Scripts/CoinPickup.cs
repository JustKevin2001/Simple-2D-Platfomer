using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Attributes
    [SerializeField] AudioClip coinSound;
    [SerializeField] int pointForCoinsPickUp;
    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            // Chay sound => SFX Va position cua sound
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            FindFirstObjectByType<GameSession>().AddToScore(pointForCoinsPickUp);
            Destroy(gameObject);
        }
    }
}
