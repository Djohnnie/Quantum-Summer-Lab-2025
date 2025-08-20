namespace QuantumSummerLab.Web.Helpers;

public class DrawerHelper
{
    public event EventHandler<ParametrizedEventArgs>? ShouldPopout;

    public void Popout(string parameter1, string parameter2)
    {
        ShouldPopout?.Invoke(this, new ParametrizedEventArgs(parameter1, parameter2));
    }
}

public class ParametrizedEventArgs : EventArgs
{
    public string Parameter1 { get; }
    public string Parameter2 { get; }

    public ParametrizedEventArgs(string parameter1, string parameter2)
    {
        Parameter1 = parameter1;
        Parameter2 = parameter2;
    }
}