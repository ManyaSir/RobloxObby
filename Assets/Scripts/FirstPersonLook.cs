using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] Transform character;
    public Vector3 CameraPosition;
    public Quaternion CameraRotation;
    public GameObject FPL_Camera;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        FPL_Camera = this.gameObject;
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -60, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
    public void PauseDataSave()
    {
        Cursor.lockState = CursorLockMode.None;
        CameraPosition = FPL_Camera.transform.position;
        //Debug.Log("dfh");
        CameraRotation = FPL_Camera.transform.rotation;
        //Debug.Log("" + CameraRotation);

    }
}
