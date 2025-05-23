﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandManagerSampleApp.Commands
{
    internal class CommandManager : ICommandManager
    {

        protected Dictionary<string, Command> Commands { get; set; }

        public CommandManager()
        {
            Commands = new Dictionary<string, Command>();
        }

        public Command CreateCommand(string commandName, CommandClickHandler handler)
        {
            Command cmd = new Command() { CommandName = commandName };
            cmd.CommandClick += handler;
            Commands.Add(commandName, cmd);

            return cmd;
        }

        public Command CreateCommand(string commandName, IEnumerable<ToolStripItem> uiCommands, CommandClickHandler handler)
        {
            Command cmd = new Command() { CommandName = commandName };
            cmd.CommandClick += handler;
            Commands.Add(commandName, cmd);

            foreach (var item in uiCommands)
                cmd.RegisterUICommand(item);

            return cmd;
        }

        public Command CreateCommand(string commandName, ToolStripItem uiCommand, CommandClickHandler handler)
        {
            Command cmd = new Command() { CommandName = commandName };
            cmd.CommandClick += handler;
            Commands.Add(commandName, cmd);

            cmd.RegisterUICommand(uiCommand);

            return cmd;
        }

        public Command CreateCommand(string commandName, Button uiCommand, CommandClickHandler handler)
        {
            Command cmd = new Command() { CommandName = commandName };
            cmd.CommandClick += handler;
            Commands.Add(commandName, cmd);

            cmd.RegisterUICommand(uiCommand);

            return cmd;
        }

        public Command RegisterUICommand(string commandName, ToolStripItem uiCommand)
        {
            Command cmd = Commands[commandName];
            cmd.RegisterUICommand(uiCommand);

            return cmd;

        }

        public Command RegisterUICommand(string commandName, Button uiCommand)
        {
            Command cmd = Commands[commandName];
            cmd.RegisterUICommand(uiCommand);

            return cmd;

        }


        public Command RegisterUICommand(string commandName, IEnumerable<ToolStripItem> uiCommands)
        {
            Command cmd = Commands[commandName];
            cmd.RegisterUICommand(uiCommands);
            return cmd;
        }

        public Command RegisterUICommand(string commandName, IEnumerable<Button> uiCommands)
        {
            Command cmd = Commands[commandName];
            cmd.RegisterUICommand(uiCommands);
            return cmd;
        }

        public Command GetCommand(string commandName)
        {
            return Commands[commandName];
        }

        public void SetCommandEnable(bool enabled, string commandName)
        {
            Command cmd = Commands[commandName];
            if (enabled)
                cmd?.Enable();
            else
                cmd?.Disable();

        }

        public void SetCommandEnable(bool enabled, IEnumerable<string> commandNames)
        {
            foreach (string commandName in commandNames)
            {
                Command cmd = Commands[commandName];
                if (enabled)
                    cmd?.Enable();
                else
                    cmd?.Disable();
            }

        }

        public void SetCommandEnable(bool enabled, IEnumerable<Command> commands)
        {
            foreach (Command command in commands)
            {
                if (enabled)
                    command.Enable();
                else
                    command.Disable();
            }

        }

    }

}
