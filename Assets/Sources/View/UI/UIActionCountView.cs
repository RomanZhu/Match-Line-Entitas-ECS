using UnityEngine;
using UnityEngine.UI;

public class UIActionCountView : MonoBehaviour, IActionCountListener, IMaxActionCountListener
{
    [SerializeField] private Text _label;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName;

    private int _triggerHash;

    private int _actionCount;
    private int _maxActionCount;

    private void Start()
    {
        Contexts.sharedInstance.gameState.CreateEntity().AddActionCountListener(this);
        Contexts.sharedInstance.config.CreateEntity().AddMaxActionCountListener(this);
        _triggerHash = Animator.StringToHash(_triggerName);

        var e = Contexts.sharedInstance.config.maxActionCountEntity;
        OnMaxActionCount(e, e.maxActionCount.value);
    }

    public void OnActionCount(GameStateEntity entity, int value)
    {
        _actionCount = value;
        Apply();
    }

    public void OnMaxActionCount(ConfigEntity entity, int value)
    {
        _maxActionCount = value;
        Apply();
    }

    private void Apply()
    {
        _label.text = string.Format("{0}/{1}", _actionCount, _maxActionCount);
        _animator.SetTrigger(_triggerHash);
    }
}