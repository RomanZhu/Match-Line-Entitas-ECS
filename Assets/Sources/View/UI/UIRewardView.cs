using UnityEngine;
using UnityEngine.UI;

public class UIRewardView : MonoBehaviour, IScoreListener
{
    [SerializeField] private Text _label;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName;

    private int _lastValue = 0;

    private int _triggerHash;

    private void Start()
    {
        Contexts.sharedInstance.gameState.CreateEntity().AddScoreListener(this);
        _triggerHash = Animator.StringToHash(_triggerName);
    }

    public void OnScore(GameStateEntity entity, int value)
    {
        if (value == _lastValue) return;
        
        var difference = value - _lastValue;
                
        _label.text = difference.ToString();
        _animator.SetTrigger(_triggerHash);
        
        _lastValue = value;
    }
}