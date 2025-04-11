using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    private Animator animator;
    public AudioClip foodSound;
    public AudioClip brushSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject[] foodItems = GameObject.FindGameObjectsWithTag("Food");
        GameObject[] brushItems = GameObject.FindGameObjectsWithTag("Brush");

        if (foodItems.Length == 0 && brushItems.Length == 0)
        {
            animator.SetTrigger("groomed");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            ReactToFood();
        }
        else if (collision.CompareTag("Brush"))
        {
            Destroy(collision.gameObject);
            ReactToBrush();
        }
    }

    void ReactToFood()
    {
        Debug.Log("Pet found food!");
        AudioSource.PlayClipAtPoint(foodSound, transform.position);
        //animator.SetTrigger("ReactFood");
    }

    void ReactToBrush()
    {
        Debug.Log("Pet is being brushed!");
        AudioSource.PlayClipAtPoint(brushSound, transform.position);
        //animator.SetTrigger("ReactBrush");
    }
}