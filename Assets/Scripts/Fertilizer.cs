using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    public FertilizerType fertilizerType = FertilizerType.NotDefined;

    void Awake()
    {
    }

    // Called when the player clicks this fertilizer
    public void OnClicked(PlayerController player)
    {
        if (player == null) return;

        // Give this fertilizer to the player
        player.heldFertilizer = fertilizerType;

        // Update the 3D model on the player
        player.UpdateHeldFertilizerVisuals();

        Debug.Log("Player picked up " + fertilizerType);
    }
}
