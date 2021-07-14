
using System;

public class DebugCommandBase
{
    private string _commandId;
    private string _commandDescription;
    private string _commandFormat;
    
    public string commandId {get { return _commandId;}}
    public string commandDesc {get { return _commandDescription;}}
    public string commandFormat {get { return _commandFormat;}}

    public DebugCommandBase(string id, string description, string format)
    {
        _commandId = id;
        _commandDescription = description;
        _commandFormat = format;
    }
    
}

public class DebugCommand : DebugCommandBase
{
    public Action command;

    public DebugCommand(string id, string description, string format, Action command) : base(id, description, format)
    {
        this.command = command;
    }

    public void InvokeAntion()
    {
        command.Invoke();
    }

}