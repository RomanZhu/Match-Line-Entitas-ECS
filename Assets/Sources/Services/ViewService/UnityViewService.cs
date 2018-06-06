using System;
using Entitas;
using UnityEngine;

public sealed class UnityViewService : Service, IViewService
{
    private Transform _root;

    public UnityViewService(Contexts contexts) : base(contexts)
    {
    }

    public void LoadAsset(Contexts contexts, IEntity entity, string asset)
    {
        if (_root == null)
        {
            _root = new GameObject("ViewRoot").transform;
        }

        var viewObject = GameObject.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", asset)), _root);
        if (viewObject == null)
            throw new NullReferenceException(string.Format("Prefabs/{0} not found!", asset));

        var view = viewObject.GetComponent<IView>();
        if (view != null)
            view.InitializeView(contexts, entity);

        var eventListeners = viewObject.GetComponents<IEventListener>();
        foreach (var listener in eventListeners)
            listener.RegisterListeners(entity);
    }
}