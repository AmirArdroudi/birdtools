using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = System.Object;

//TODO: create command history window
//DONE: change keyboard focus from inputField to gameplay after clicking return key
//TODO: after opening console keyboard focus should be set on inputField
//TODO: event-based triggering commands

public class DebugConsole : MonoBehaviour
{
    [Header("Console Settings")]
    public Vector2 consolePosition = new Vector2(0, 30);
    public Color consoleColor = new Color(0.8f, 1, 0, 0.9f);
    public KeyCode consoleKey = KeyCode.BackQuote;
    
    [SerializeField]private string _input;
    
    public static DebugCommand God, Mecry, Help;
    public List<Object> commandList;
    public bool showConsole = false;
    public bool showHelp = false;
    private void Awake()
    {
        Help = new DebugCommand("help", "show me verses",
            "help",
            () =>
            {
                    showHelp = true;
            });
        
        God = new DebugCommand("command1", "command description ",
            "command1",
            () =>
            {

            });
        Mecry = new DebugCommand("command2", "command descripsion ",
            "command2",
            () =>
            {

            });
        
        
        commandList = new List<object>
        {
            Help,
            God,
            Mecry
        };

    }

    private void Update()
    {
        if (Input.GetKeyDown(consoleKey))
        {
            showConsole = true;
        }
    }
    
    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (_input.Contains(commandBase.commandId))
            {
                DebugCommand command = commandList[i] as DebugCommand;
                command?.InvokeAntion();
            }
        }
    }

    private Vector2 _scroll;
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("return")))
        {
            showConsole = false;
            // showHelp = false;

            GUIUtility.keyboardControl = 0;
            HandleInput();
            _input = "";
        }

        if (showConsole)
        {
            // ********************** inputfield viewport **********************
            GUI.Box(new Rect(consolePosition.x, Screen.height + consolePosition.y, Screen.width, 50), "");
            GUI.backgroundColor = consoleColor;
            GUI.SetNextControlName("input");
            _input = GUI.TextField(
                new Rect(consolePosition.x, Screen.height + consolePosition.y, Screen.width - 20f, 23f), _input);
            GUI.FocusControl("input");
            
            
            // ********************** help viewport **********************
            GUI.Box(new Rect(0, Screen.height - consolePosition.y - 50, Screen.width, 100),"");
            Rect viewport = new Rect(0,0, Screen.width - 30, 20 * commandList.Count);

            _scroll = GUI.BeginScrollView(new Rect(0, consolePosition.y + 5f, Screen.width, 90), _scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.commandFormat} - {command.commandDesc}";
                Rect labelRect = new Rect(5, 20 * i, viewport.width-100, 23);
                GUI.Label(labelRect, label);

            }
            GUI.backgroundColor = consoleColor;

            GUI.EndScrollView();
            // **********************************************************
        }
    }
}
