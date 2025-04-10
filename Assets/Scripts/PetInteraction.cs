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
        if (collision.CompareTag("Food"))
        {
            ReactToFood();
        }
        else if (collision.CompareTag("Brush"))
        {
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