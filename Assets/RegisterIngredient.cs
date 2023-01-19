using UnityEngine;

public class RegisterIngredient : MonoBehaviour
{
    private Transform parent;

    private void Awake()
    {
        parent = gameObject.transform;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ingredient") && !PickUpIngridient.objectPickedUp)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localScale = new Vector3(.06f, .06f, .06f);
            other.transform.localPosition = new Vector3(-0.08f, 0.01f, 0.06f);
            Instantiate(other, parent, false);
            Destroy(other.gameObject);
            PickUpIngridient.objectPickedUp = true;
        }
    }
}
