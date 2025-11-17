using UnityEngine;

public class Slime : MonoBehaviour, IInteractable
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        Debug.Log("Mesh Filter: " + meshFilter);
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log("Mesh Renderer: " + meshRenderer);
        Debug.Log("Spawned slime at" + transform.position);
    }
    public void Setup(Mesh mesh, Material material)
    {
        meshFilter.mesh = Instantiate(mesh);
        meshRenderer.material = material;
        Debug.Log($"Slime Mesh: {meshFilter.mesh}, Material: {meshRenderer.material}");
    }
    public void OnInteraction(PlayerController interactor)
    {

    }
}
