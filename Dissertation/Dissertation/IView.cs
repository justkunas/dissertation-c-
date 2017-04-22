using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dissertation
{
    public interface IView
    {
        
        TextBox getSearchBox();
        TreeView getTreeView();
        Label getQuantityLabel();
        Label getSaveLabel();
        Dictionary<string, object> getItem();

    }
}
