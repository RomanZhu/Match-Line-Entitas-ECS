using Entitas;
using UnityEngine;

public class ColorListener : MonoBehaviour, IEventListener, IColorListener
{
    [SerializeField] private Renderer _renderer;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddColorListener(this);
        OnColor(_entity, _entity.color.value);
    }

    public void OnColor(GameEntity entity, Color value)
    {
        _renderer.material.color = value;
    }
}