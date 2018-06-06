using Entitas;
using UnityEngine;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
{
    [SerializeField] private float _lerpSpeed = 1f;

    private GameEntity _entity;

    private Vector3 _targetPosition;
    private Transform _transform;
    
    public void RegisterListeners(IEntity entity)
    {
        _transform = transform;
        _entity = (GameEntity) entity;
        _entity.AddPositionListener(this);

        OnPosition(_entity, _entity.position.value);
    }

    public void OnPosition(GameEntity entity, GridPosition value)
    {
        _targetPosition = value.ToVector3();
    }
    
    private void Update()
    {
        _transform.position = Vector3.Lerp(_transform.position, _targetPosition, _lerpSpeed * Time.deltaTime);
    }
}