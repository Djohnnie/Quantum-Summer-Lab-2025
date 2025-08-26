namespace QuantumSummerLab.Admin.Helpers;

public class NavigationHelper
{
    public event EventHandler? NavigationShouldRefresh;

    public void RefreshNavigation()
    {
        NavigationShouldRefresh?.Invoke(this, EventArgs.Empty);
    }
}