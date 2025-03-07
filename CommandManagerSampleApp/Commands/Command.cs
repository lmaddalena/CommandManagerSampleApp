using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandManagerSampleApp.Commands
{
    delegate void CommandClickHandler(object sender, EventArgs args);

    internal class Command
    {
        public event CommandClickHandler CommandClick;
        public string CommandName { get; set; }
        public List<ToolStripItem> UICommands { get; set; }

        protected void OnCommandClick(object sender, EventArgs args)
        {
            CommandClick?.Invoke(sender, args);
        }

        internal void UICommandClick(object sender, EventArgs e)
        {
            OnCommandClick(sender, e);
        }

        public void Enable()
        { 
            UICommands?.ForEach(x => x.Enabled = true);
        }

        public void Disable() 
        {
            UICommands?.ForEach(x => x.Enabled = false);
        }


    }
}
