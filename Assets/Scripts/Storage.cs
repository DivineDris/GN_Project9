using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField]
    private SelectedObject PrefabObject;
    private SelectedObject StoredObject;
    [SerializeField]
    private Transform ObjectSpot;
    [SerializeField]
    float spinSpeed = 20f;

    private void Start()
    {
        ObjectSpot = transform.Find("ObjectSpot");
        UpdaeteStoredObject();
    }

    private void Update()
    {
        UpdaeteStoredObject();
        SpinObject();
    }

    private void SpinObject()
    {
        StoredObject.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void UpdaeteStoredObject()
    {
        if (StoredObject != null) return;
        StoredObject = Instantiate(PrefabObject, ObjectSpot.position, Quaternion.identity);
        StoredObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
