using Entitas;
using UnityEngine;

public class LastSelectedListener : MonoBehaviour, IEventListener, ILastSelectedListener, ILastSelectedRemovedListener
{
    [SerializeField] private GameObject _lastSelectedEffect;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddLastSelectedListener(this);
        _entity.AddLastSelectedRemovedListener(this);

        SetLastSelected(_entity, _entity.isLastSelected);
    }

    public void OnLastSelected(GameEntity entity)
    {
        SetLastSelected(entity, true);
    }

    public void OnLastSelectedRemoved(GameEntity entity)
    {
        SetLastSelected(entity, false);
    }
    
    private void SetLastSelected(GameEntity entity, bool value)
    {
        _lastSelectedEffect.SetActive(value);
    }
}