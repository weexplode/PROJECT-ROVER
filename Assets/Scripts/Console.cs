using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public InputField output;
    public InputField input;
    public int linesToDisplay;

    private void Start()
    {
        input.caretWidth = 10;
    }

    public void SubmitText(string text)
    {
        string[] args = text.Split(' ');
        output.text += "\n> " + text + "\n ";
        if (Command.list.ContainsKey(args[0]))
            output.text += Command.list[args[0]].Execute(args);
        else
            output.text += "Unknown command";
        input.text = "";
        input.Select();
        input.ActivateInputField();
        FitText();
    }

    void FitText()
    {
        string[] lines = output.text.Split('\n');
        output.text = "";
        for(int i = Mathf.Max(lines.Length-linesToDisplay,0); i<lines.Length; i++)
        {
            if(i != lines.Length - 1)
                output.text += lines[i] + "\n";
            else
                output.text += lines[i];
        }

    }

    abstract class Command
    {
        public static Dictionary<string, Command> list = new Dictionary<string, Command>()
        {
            {"help",new HelpCommand() },
            {"echo",new EchoCommand() }
        };
        abstract public string Execute(string[] args);

        class HelpCommand : Command
        {
            public override string Execute(string[] args)
            {
                return "Not implemented";
            }
        }

        class EchoCommand : Command
        {
            public override string Execute(string[] args)
            {
                string output = "";
                for(int i = 1; i < args.Length; i++)
                    output += args[i] + " ";
                return output;
            }
        }
    }
}
