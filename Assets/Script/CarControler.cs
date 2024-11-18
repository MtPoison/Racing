using UnityEngine;
using UnityEngine.InputSystem;

public class CarControler : MonoBehaviour
{
    private PlayerControler playerControler;
    private InputAction deplacements;
    private InputAction boost;

    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxReverseSpeed = -5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float brakePower = 2f;
    [SerializeField] private float boostMultiplier = 2f; // Multiplicateur pour la vitesse pendant le boost
    [SerializeField] private float boostDuration = 2f;   // Dur�e du boost en secondes

    private float currentSpeed = 0f;
    private bool isBoosting = false;
    private float boostEndTime = 0f;

    private void Awake()
    {
        playerControler = new PlayerControler();
    }

    private void OnEnable()
    {
        deplacements = playerControler.Player.Deplacement;
        boost = playerControler.Player.Boost;

        deplacements.Enable();
        boost.Enable();

        // Abonnement � l'action de boost
        boost.performed += OnBoost;
    }

    private void OnDisable()
    {
        deplacements.Disable();
        boost.Disable();

        boost.performed -= OnBoost;
    }

    private void Update()
    {
        Vector2 input = deplacements.ReadValue<Vector2>();

        // G�rer l'�tat du boost
        if (isBoosting && Time.time >= boostEndTime)
        {
            isBoosting = false;
        }

        // Appliquer le multiplicateur de boost si actif
        float speedMultiplier = isBoosting ? boostMultiplier : 1f;

        // Acc�l�ration progressive en appuyant sur Z
        if (input.y > 0)
        {
            currentSpeed += acceleration * Time.deltaTime * speedMultiplier;
        }
        // Marche arri�re en appuyant sur S
        else if (input.y < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else
        {
            // D�c�l�ration naturelle lorsque rien n'est press�
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * brakePower);
        }

        // Limiter la vitesse en marche avant et en marche arri�re
        currentSpeed = Mathf.Clamp(currentSpeed, maxReverseSpeed, maxSpeed * (isBoosting ? boostMultiplier : 1f));

        // Rotation progressive avec Q et D
        float rotation = input.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        // Appliquer le mouvement de la voiture
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
    }

    private void OnBoost(InputAction.CallbackContext context)
    {
        if (!isBoosting)
        {
            isBoosting = true;
            boostEndTime = Time.time + boostDuration;
        }
    }
}

