using Entitas;

public interface IViewService
{
    void LoadAsset(Contexts contexts, IEntity entity, string assetName);
}