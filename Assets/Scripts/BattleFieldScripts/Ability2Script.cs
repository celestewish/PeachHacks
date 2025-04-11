using UnityEngine;

public class Ability2Script : MonoBehaviour
{
    public AudioClip hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
