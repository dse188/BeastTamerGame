using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;

    [SerializeField] private TurnBaseManager _turnBaseManager;
    private InputAction _clickAction;
    private InputAction _pointerPositionAction;

    [Header("Movement Settings")]
    [Tooltip("Movement speed is a resource that is consumed when the player moves. When it reaches zero, the player cannot move until it regenerates.")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private CharacterStatsSO _characterStatsSO;

    private float _remainingMovement;
    private Vector3 _previousPosition;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _mainCamera = Camera.main;

        _clickAction = new InputAction("PointClick", binding: "<Pointer>/press");
        _pointerPositionAction = new InputAction("PointerPosition", binding: "<Pointer>/position");

        _movementSpeed = _characterStatsSO.MovementSpeed;
    }

    private void Start()
    {
        _remainingMovement = _movementSpeed;
        _previousPosition = transform.position;
    }

    private void OnEnable()
    {
        _clickAction.Enable();
        _pointerPositionAction.Enable();
    }

    private void OnDisable()
    {
        _clickAction.Disable();
        _pointerPositionAction.Disable();
    }

    private void Update()
    {
        if (_clickAction.triggered && _turnBaseManager.currentTurn == TurnState.PlayerTurn && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 screenPosition = _pointerPositionAction.ReadValue<Vector2>();
            Ray ray = _mainCamera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Vector3 hitpoint = hit.point; 
                
                if (_remainingMovement > 0f)
                {
                    MoveTo(hit.point);
                }
            }
        }

        float distanceTraveled = Vector3.Distance(transform.position, _previousPosition);
        _remainingMovement -= distanceTraveled;

        if (_remainingMovement <= 0f && _turnBaseManager.currentTurn != TurnState.PlayerTurn)
        {
            _remainingMovement = 0f;
            _agent.isStopped = true;
        }

        _previousPosition = transform.position;
    }


    protected void MoveTo(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
}
