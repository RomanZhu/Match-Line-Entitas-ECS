using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Contexts _contexts;
    private RootSystems _rootSystems;
    private Services _services;

    [SerializeField]
    private TextAsset ComboDefinitions;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        
        Configure(_contexts);
        
        //How to live without DI? 
        _services = new Services
        {
            ViewService = new UnityViewService(_contexts),
            InputService = new UnityInputService(_contexts, Camera.main),
            TimeService = new UnityTimeService(_contexts),
            ElementService = new ElementService(_contexts),
        };

        _rootSystems = new RootSystems(_contexts, _services);
        _rootSystems.Initialize();
    }

    private void Update()
    {
        _rootSystems.Execute();
        _rootSystems.Cleanup();
    }

    private void OnDestroy()
    {
        _rootSystems.DeactivateReactiveSystems();
        _rootSystems.ClearReactiveSystems();
        _rootSystems.TearDown();
    }

    private void Configure(Contexts contexts)
    {
        contexts.config.ReplaceMapSize(new GridSize(6, 6));
        contexts.config.ReplaceTypeCount(4);
        contexts.config.ReplaceMaxActionCount(20);
        contexts.config.ReplaceMinMatchCount(3);
        contexts.config.ReplaceScoringTable(new List<int> {0, 10, 30, 90, 200, 500, 1200, 2500});
        contexts.config.ReplaceExsplosiveScoringTable(new List<int> {300, 900, 1200, 2000});
        contexts.config.ReplaceComboDefinitions(JsonUtility.FromJson<ComboDefinitions>(ComboDefinitions.text));
    }
}