using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("ReactFood");
    }

    void ReactToBrush()
    {
        Debug.Log("Pet is being brushed!");
        animator.SetTrigger("ReactBrush");
    }
}