using UnityEngine;

public class Slime : MonoBehaviour, IInteractable
{
    [SerializeField]
    MeshFilter meshFilter;
    [SerializeField]
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void Setup(Mesh mesh, Material material)
    {
        meshFilter.mesh = Instantiate(mesh);
        meshRenderer.material = material;
    }
    public void OnInteraction(PlayerController interactor)
    {

    }
}
