using UnityEngine;
using UnityEngine.UI;

public class UIGameOverView : MonoBehaviour, IGameOverListener, IGameOverRemovedListener
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _boolName;

    private int _boolHash;

    private void Start()
    {
        Contexts.sharedInstance.gameState.CreateEntity().AddGameOverListener(this);
        Contexts.sharedInstance.gameState.CreateEntity().AddGameOverRemovedListener(this);
        _boolHash = Animator.StringToHash(_boolName);

        SetGameOver(Contexts.sharedInstance.gameState.gameOverEntity, Contexts.sharedInstance.gameState.isGameOver);
    }

    public void OnGameOver(GameStateEntity entity)
    {
        SetGameOver(entity, true);
    }

    public void OnGameOverRemoved(GameStateEntity entity)
    {
        SetGameOver(entity, false);
    }

    private void SetGameOver(GameStateEntity entity, bool value)
    {
        _animator.SetBool(_boolHash, value);
    }
}