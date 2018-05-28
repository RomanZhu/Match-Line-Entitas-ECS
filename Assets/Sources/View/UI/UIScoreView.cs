using UnityEngine;
using UnityEngine.UI;

public class UIScoreView : MonoBehaviour, IScoreListener
{
    [SerializeField] private Text _label;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName;

    private int _triggerHash;

    private void Start()
    {
        Contexts.sharedInstance.gameState.CreateEntity().AddScoreListener(this);
        _triggerHash = Animator.StringToHash(_triggerName);
    }

    public void OnScore(GameStateEntity entity, int value)
    {
        _label.text = value.ToString();
        _animator.SetTrigger(_triggerHash);
    }
}