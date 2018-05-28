using Entitas;
using UnityEngine;

public class SelectedListener : MonoBehaviour, IEventListener, ISelectedListener, ISelectedRemovedListener
{
    [SerializeField] private GameObject _selectedEffect;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddSelectedListener(this);
        _entity.AddSelectedRemovedListener(this);

        SetSelected(_entity, _entity.isSelected);
    }

    public void OnSelected(GameEntity entity)
    {
        SetSelected(entity, true);
    }

    public void OnSelectedRemoved(GameEntity entity)
    {
        SetSelected(entity, false);
    }
    
    private void SetSelected(GameEntity entity, bool value)
    {
        _selectedEffect.SetActive(value);
    }
}