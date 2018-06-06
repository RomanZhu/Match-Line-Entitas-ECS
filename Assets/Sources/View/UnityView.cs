using Entitas;
using Entitas.Unity;
using UnityEngine;

public class UnityView : MonoBehaviour, IView, IGameDestroyedListener
{
    private GameEntity _entity;

    public void InitializeView(Contexts contexts, IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddGameDestroyedListener(this);

#if UNITY_EDITOR
        //gameObject.Link(entity, contexts.game);
#endif
    }

    public void OnDestroyed(GameEntity entity)
    {
#if UNITY_EDITOR
        //gameObject.Unlink();
#endif
        Destroy(gameObject);
    }
}