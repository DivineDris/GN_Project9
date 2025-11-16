using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Held Objects")]
    public SelectedObject heldObject;

    //[Header("Held Fertilizer Models")]
    //public GameObject modelFertilizerA;
    //public GameObject modelFertilizerB;
    //public GameObject modelFertilizerC;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float interactDistance = 5f;


    [Header("Mouse Settings")]
    public float mouseSensitivity = 0.5f;

    private float xRotation = 0f;
    private Camera cam;

    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private Vector2 lookInput;

    void Awake()
    {
        cam = Camera.main;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    void Start()
    {
        //// Make sure all models start disabled
        //modelFertilizerA.SetActive(false);
        //modelFertilizerB.SetActive(false);
        //modelFertilizerC.SetActive(false);
    }



    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
    void Update(){
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, interactDistance))
        //    {
        //        GameObject clicked = hit.collider.gameObject;

        //        Fertilizer fert = clicked.GetComponent<Fertilizer>();
        //        if (fert != null)
        //        {
        //            if (heldFertilizer == FertilizerType.NotDefined)
        //            {
        //                fert.OnClicked(this);
        //            }
        //            else
        //            {
        //                Debug.Log("You are already holding a fertilizer!");
        //            }

        //            return; 
        //        }

        //        //later add flow interactions
        //    }
        //}

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Interact();
        }

        HandleMovement();
        HandleMouseLook();

    }

    void HandleMovement()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = right * moveInput.x + forward * moveInput.y;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        //if (Mouse.current.rightButton.isPressed)
        //{
            xRotation -= lookInput.y * mouseSensitivity;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * lookInput.x * mouseSensitivity);
        //}
    }

    public void Interact()
    {
        Ray ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
            {
                StartInteraction(interactable);
            }
            else if (hit.collider.GetComponentInParent<IInteractable>() is IInteractable parentInteractable)
            {
                StartInteraction(parentInteractable);
            }

        }

    }

    private void StartInteraction(IInteractable interactable)
    {
        if (heldObject != null)
            Destroy(heldObject.gameObject);
        interactable.OnInteraction(this);
    }
    public void UpdateHeldFertilizerVisuals()
    {
        //// Turn ON the correct one
        //if (heldFertilizer == FertilizerType.FertilizerA)
        //    modelFertilizerA.SetActive(true);

        //if (heldFertilizer == FertilizerType.FertilizerB)
        //    modelFertilizerB.SetActive(true);

        //if (heldFertilizer == FertilizerType.FertilizerC)
        //    modelFertilizerC.SetActive(true);
    }
}
