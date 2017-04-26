using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation
{
    interface IPagedView
    {

        void loadNextPage();
        void loadPreviousPage();

    }
}
