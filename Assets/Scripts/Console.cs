using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public InputField output;
    public InputField input;
    public int linesToDisplay;
    public Connectable connected;

    private void Start()
    {
        input.caretWidth = 10;
    }

    public void SubmitText(string text)
    {
        string[] args = text.Split(' ');
        output.text += "\n> " + text + "\n ";
        if (Command.list.ContainsKey(args[0]))
            output.text += Command.list[args[0]].Execute(args,connected);
        else
            output.text += "Unknown command. Try 'help' for a list of commands.";
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

    public void PrintLine(string text)
    {
        output.text += "\n" + text;
        FitText();
    }

    abstract class Command
    {
        public static Dictionary<string, Command> list = new Dictionary<string, Command>()
        {
            {"help",new HelpCommand() },
            {"echo",new EchoCommand() },
            {"activate",new ActivateCommand() },
            {"ls",new FilesCommand() },
            {"files",new FilesCommand() },
            {"read",new ReadCommand() }
        };
        abstract public string Execute(string[] args, Connectable connected);

        class HelpCommand : Command
        {
            public override string Execute(string[] args, Connectable connected)
            {
                return "HELP: Show command list\n" +
                       "ACTIVATE: Activate nearby switch\n" + 
                       "FILES: Show file list in connected device\n" +
                       "READ <file>: Read the named file";
            }
        }

        class EchoCommand : Command
        {
            public override string Execute(string[] args, Connectable connected)
            {
                string output = "";
                for(int i = 1; i < args.Length; i++)
                    output += args[i] + " ";
                return output;
            }
        }

        class ActivateCommand : Command
        {
            public override string Execute(string[] args, Connectable connected)
            {
                if (connected is Activatable)
                {
                    return ((Activatable)connected).Activate();
                } else
                {
                    return "Nothing nearby to activate.";
                }
            }
        }

        class FilesCommand : Command
        {
            public override string Execute(string[] args, Connectable connected)
            {
                if(connected == null || connected.files == null || connected.files.Length == 0)
                    return "Not connected to any storage.";
                string output = "Files in storage:\n";
                foreach (File f in connected.files)
                    output += f.name + "\n";
                return output;
            }
        }

        class ReadCommand : Command
        {
            public override string Execute(string[] args, Connectable connected)
            {
                if (connected == null || connected.files.Length == 0)
                    return "Not connected to any storage.";
                File file = null;
                string search = "";
                for (int i = 1; i < args.Length; i++)
                    search += args[i] + " ";
                foreach (File f in connected.files)
                    if (f.name.StartsWith(search.Trim()))
                        file = f;
                if (file == null)
                    return "File not found.";
                else
                    return file.contents;
            }
        }
    }
}
