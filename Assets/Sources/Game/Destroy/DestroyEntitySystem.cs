using System.Collections.Generic;
using Entitas;

public sealed class DestroyEntitySystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _gameGroup;
    private readonly List<GameEntity> _gameBuffer;

    private readonly IGroup<InputEntity> _inputGroup;
    private readonly List<InputEntity> _inputBuffer;

    public DestroyEntitySystem(Contexts contexts)
    {
        _gameGroup = contexts.game.GetGroup(GameMatcher.Destroyed);
        _gameBuffer = new List<GameEntity>();

        _inputGroup = contexts.input.GetGroup(InputMatcher.Destroyed);
        _inputBuffer = new List<InputEntity>();
    }

    public void Cleanup()
    {
        foreach (var e in _gameGroup.GetEntities(_gameBuffer))
        {
            e.Destroy();
        }

        foreach (var e in _inputGroup.GetEntities(_inputBuffer))
        {
            e.Destroy();
        }
    }
}