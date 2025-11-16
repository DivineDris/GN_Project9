using UnityEngine;


public enum SelectedObjectType
{
    Fetilaizer,
    SeedPack
}

public class SelectedObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    public SelectedObjectType selectedObjectType;
    public void OnInteraction(PlayerController interactor)
    {
        if (interactor == null) return;
        interactor.heldObject = this;
        Transform selectedItemSpot = interactor.transform.Find("CameraSelectedObjects/SelectedItemSpot");
        this.transform.position = selectedItemSpot.position;
        this.transform.rotation = Quaternion.identity;
        this.transform.SetParent(selectedItemSpot);
        this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public SelectedObjectType GetSelectedObjectType()
    {
        return selectedObjectType;
    }
}
