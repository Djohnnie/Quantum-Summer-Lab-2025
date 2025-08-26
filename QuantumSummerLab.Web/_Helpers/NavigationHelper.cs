namespace QuantumSummerLab.Web.Helpers;

public class NavigationHelper
{
    public event EventHandler<EventArgs>? ShouldUpdate;

    public void Update()
    {
        ShouldUpdate?.Invoke(this, new EventArgs());
    }
}