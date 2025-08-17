namespace QuantumSummerLab.Web.Helpers;

public class DrawerHelper
{
    public event EventHandler<ParametrizedEventArgs>? ShouldPopout;

    public void Popout(string parameter)
    {
        ShouldPopout?.Invoke(this, new ParametrizedEventArgs(parameter));
    }
}

public class ParametrizedEventArgs : EventArgs
{
    public string Parameter { get; }

    public ParametrizedEventArgs(string parameter)
    {
        Parameter = parameter;
    }
}