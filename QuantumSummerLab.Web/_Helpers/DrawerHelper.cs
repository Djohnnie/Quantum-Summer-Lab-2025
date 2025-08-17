namespace QuantumSummerLab.Web.Helpers;

public class DrawerHelper
{
    public event EventHandler? ShouldPopout;

    public void Popout()
    {
        ShouldPopout?.Invoke(this, EventArgs.Empty);
    }
}