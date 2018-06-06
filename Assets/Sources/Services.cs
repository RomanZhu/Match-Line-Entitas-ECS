//I would use Zenject, but "no third party code" rule exists

public class Services
{
    public IViewService ViewService;
    public IInputService InputService;
    public ITimeService TimeService;

    public ElementService ElementService;
}