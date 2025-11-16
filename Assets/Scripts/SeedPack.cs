using UnityEngine;

public class SeedPack : SelectedObject
{
    public FlowerType flowerType = FlowerType.NotDefined;
    private void Awake()
    {
        selectedObjectType = SelectedObjectType.SeedPack;
    }

    public void OnInteraction(PlayerController interactor)
    {
        base.OnInteraction(interactor);
        Debug.Log("Player picked up " + flowerType);
    }
}
