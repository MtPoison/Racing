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
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float boostDuration = 2f;
    [SerializeField] private float boostCooldown = 5f;

    [SerializeField] private AudioClip accelerationSound;
    [SerializeField] private AudioClip brakeSound;
    [SerializeField] private AudioClip boostSound;

    private float currentSpeed = 0f;
    private bool isBoosting = false;
    private float boostEndTime = 0f;
    private float nextBoostAvailableTime = 0f;

    private SoundManager soundManager;
    private AudioSource audioSource;

    private void Awake()
    {
        playerControler = new PlayerControler();
        soundManager = GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();

        if (soundManager == null)
        {
            Debug.LogError("Aucun SoundManager trouvé sur " + gameObject.name);
        }

        if (audioSource == null)
        {
            Debug.LogError("Aucun AudioSource trouvé sur " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        deplacements = playerControler.Player.Deplacement;
        boost = playerControler.Player.Boost;

        deplacements.Enable();
        boost.Enable();

        boost.performed += OnBoost;
        boost.canceled += OnBoostCanceled;
    }

    private void OnDisable()
    {
        deplacements.Disable();
        boost.Disable();

        boost.performed -= OnBoost;
        boost.canceled -= OnBoostCanceled;
    }

    private void Update()
    {
        Vector2 input = deplacements.ReadValue<Vector2>();

        if (isBoosting && Time.time >= boostEndTime)
        {
            isBoosting = false;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed); // Réinitialisation à maxSpeed
            soundManager.StopSound();
        }

        float speedMultiplier = isBoosting ? boostMultiplier : 1f;

        if (input.y > 0)
        {
            currentSpeed += acceleration * Time.deltaTime * speedMultiplier;
            if (!isBoosting) soundManager.PlaySoundIfNotPlaying(accelerationSound);
        }
        else if (input.y < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
            if (!isBoosting) soundManager.PlaySoundIfNotPlaying(brakeSound);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * brakePower);
            if (!isBoosting) soundManager.StopSound();
        }

        currentSpeed = Mathf.Clamp(currentSpeed, maxReverseSpeed, maxSpeed * speedMultiplier);

        if (!isBoosting)
        {
            AdjustVolume();
        }

        float rotation = input.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
    }

    private void OnBoost(InputAction.CallbackContext context)
    {
        if (!isBoosting && Time.time >= nextBoostAvailableTime)
        {
            isBoosting = true;
            boostEndTime = Time.time + boostDuration;
            nextBoostAvailableTime = Time.time + boostCooldown;

            if (audioSource != null)
            {
                audioSource.volume = 1;
            }
            soundManager.PlaySound(boostSound);
        }
    }

    private void OnBoostCanceled(InputAction.CallbackContext context)
    {
        if (isBoosting)
        {
            isBoosting = false;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            soundManager.StopSound();
        }
    }

    private void AdjustVolume()
    {
        float normalizedSpeed = Mathf.InverseLerp(0, maxSpeed, Mathf.Abs(currentSpeed));
        soundManager.AdjustVolume(normalizedSpeed);
    }
}
