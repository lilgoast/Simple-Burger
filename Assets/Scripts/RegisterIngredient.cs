using Unity.VisualScripting;
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
        if(other.CompareTag("Ingredient") && !PickUpIngredient.objectPickedUp)
        {
            GrabIngredient(other);
        }
    }

    private void GrabIngredient(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.transform.localScale = Vector3.Scale(other.transform.localScale, new Vector3(.07f, .07f, .07f));
        other.transform.localPosition = new Vector3(-0.08f, 0.01f, 0.06f);
        other.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
        other.tag = "PickedUpIngredient";
        Instantiate(other, parent, false);
        Destroy(other.gameObject);
        PickUpIngredient.objectPickedUp = true;
    }
}
