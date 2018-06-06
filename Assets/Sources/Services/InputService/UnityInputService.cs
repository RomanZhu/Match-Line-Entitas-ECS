using UnityEngine;

public sealed class UnityInputService : Service, IInputService
{
    private bool _isHolding = false;
    private Vector3 _holdingPosition = new Vector3(-1, -1, -1);
    private bool _isStartedHolding = false;
    private bool _isReleased = false;
    private float _holdingTime = 0f;

    private Camera _camera;

    #region Interface Implementation

    public bool IsHolding()
    {
        return _isHolding;
    }

    public Vector3 HoldingPosition()
    {
        return _holdingPosition;
    }

    public bool IsStartedHolding()
    {
        return _isStartedHolding;
    }

    public float HoldingTime()
    {
        return _holdingTime;
    }

    public bool IsReleased()
    {
        return _isReleased;
    }

    #endregion

    public UnityInputService(Contexts contexts, Camera camera) : base(contexts)
    {
        _camera = camera;
    }

    public void Update(float delta)
    {
        if (Input.GetMouseButton(0))
        {
            if (_isHolding)
            {
                _holdingTime += delta;
                _isStartedHolding = false;
            }
            else
            {
                _holdingTime = 0f;
                _isStartedHolding = true;
            }

            _holdingPosition = _camera.ScreenPointToRay(Input.mousePosition).origin;
            _isHolding = true;
            _isReleased = false;
        }
        else
        {
            if (_isHolding)
            {
                _isHolding = false;
                _isReleased = true;
            }
            else
            {
                _isReleased = false;
            }
        }
    }
}