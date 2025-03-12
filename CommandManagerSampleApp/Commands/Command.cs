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
        public List<Component> UICommands { get; set; }

        protected void OnCommandClick(object sender, EventArgs args)
        {
            CommandClick?.Invoke(sender, args);
        }

        public void UICommandClick(object sender, EventArgs e)
        {
            OnCommandClick(sender, e);
        }

        public void Enable()
        { 
            UICommands?.ForEach(x => {
                
                if (x is Button)
                    ((Button)x).Enabled = true;
                else if (x is ToolStripItem)
                    ((ToolStripItem)x).Enabled = true;
            });
        }

        public void Disable() 
        {
            UICommands?.ForEach(x => {
                if (x is Button)
                    ((Button)x).Enabled = false;
                else if (x is ToolStripItem)
                    ((ToolStripItem)x).Enabled = false;
            });

        }


    }
}
