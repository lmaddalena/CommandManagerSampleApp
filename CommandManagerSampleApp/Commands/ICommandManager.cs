using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandManagerSampleApp.Commands
{
    public interface ICommandManager
    {
        Command CreateCommand(string commandName, CommandClickHandler handler);
        Command CreateCommand(string commandName, IEnumerable<ToolStripItem> uiCommands, CommandClickHandler handler);
        Command CreateCommand(string commandName, ToolStripItem uiCommand, CommandClickHandler handler);
        Command CreateCommand(string commandName, Button uiCommand, CommandClickHandler handler);
        Command RegisterUICommand(string commandName, Button uiCommand);
        Command RegisterUICommand(string commandName, ToolStripItem uiCommand);
        Command RegisterUICommand(string commandName, IEnumerable<ToolStripItem> uiCommands);
        Command RegisterUICommand(string commandName, IEnumerable<Button> uiCommands);
        void SetCommandEnable(bool enabled, string commandName);
        void SetCommandEnable(bool enabled, IEnumerable<string> commandNames);
        void SetCommandEnable(bool enabled, IEnumerable<Command> commands);
        Command GetCommand(string commandName);
    }
}