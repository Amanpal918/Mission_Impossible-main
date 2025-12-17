using UnityEngine;

public class tokenactivation : MonoBehaviour
{
     [Header("Token Activation Settings")]
     public GameObject [] tokenobject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject token in tokenobject)
        {
            token.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(GameObject token in tokenobject)
            {
                token.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
