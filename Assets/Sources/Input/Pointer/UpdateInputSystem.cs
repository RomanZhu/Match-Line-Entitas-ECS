using Entitas;

public sealed class UpdateInputSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IInputService _inputService;

    public UpdateInputSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _inputService = services.InputService;
    }

    public void Execute()
    {
        if (_contexts.gameState.isGameOver)
        {
            _contexts.input.isPointerHolding = false;
            _contexts.input.isPointerStartedHolding = false;
            _contexts.input.isPointerReleased = true;
        }
        else
        {
            _inputService.Update(_contexts.input.deltaTime.value);
            _contexts.input.isPointerHolding = _inputService.IsHolding();
            _contexts.input.isPointerStartedHolding = _inputService.IsStartedHolding();
            _contexts.input.isPointerReleased = _inputService.IsReleased();
            _contexts.input.ReplacePointerHoldingPosition(_inputService.HoldingPosition());
            _contexts.input.ReplacePointerHoldingTime(_inputService.HoldingTime());
        }
    }
}