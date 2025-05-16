using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandManagerSampleApp.Commands
{
    public delegate void CommandClickHandler(object sender, EventArgs args);

    public class Command
    {
        public event CommandClickHandler CommandClick;
        public string CommandName { get; set; }
        
        private List<Component> _UICommands;

        public Command()
        {
            _UICommands = new List<Component>();                
        }

        protected void OnCommandClick(object sender, EventArgs args)
        {
            CommandClick?.Invoke(sender, args);
        }

        public void UICommandClick(object sender, EventArgs e)
        {
            OnCommandClick(sender, e);
        }

        public void RegisterUICommand(ToolStripItem uiCommand)
        {
            this._UICommands.Add(uiCommand);
            uiCommand.Click += this.UICommandClick;
        }

        public void RegisterUICommand(IEnumerable<ToolStripItem> uiCommands)
        {
            foreach (ToolStripItem uiCommand in uiCommands)
            {
                this._UICommands.Add(uiCommand);
                uiCommand.Click += this.UICommandClick;
            }
        }

        public void RegisterUICommand(Button uiCommand)
        {
            this._UICommands.Add(uiCommand);
            uiCommand.Click += this.UICommandClick;
        }

        public void RegisterUICommand(IEnumerable<Button> uiCommands)
        {
            foreach (Button uiCommand in uiCommands)
            {
                this._UICommands.Add(uiCommand);
                uiCommand.Click += this.UICommandClick;
            }
        }

        public void Enable()
        {
            _UICommands?.ForEach(x => {

                if (x is Button)
                    ((Button)x).Enabled = true;
                else if (x is ToolStripItem)
                    ((ToolStripItem)x).Enabled = true;
            });
        }

        public void Disable()
        {
            _UICommands?.ForEach(x => {
                if (x is Button)
                    ((Button)x).Enabled = false;
                else if (x is ToolStripItem)
                    ((ToolStripItem)x).Enabled = false;
            });

        }


    }
}
