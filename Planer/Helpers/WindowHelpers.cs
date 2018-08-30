using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Planer.Helpers
{
    public class WindowHelpers
    {
        public virtual void Btn_previousClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex - 1;

            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }

        public virtual void Btn_nextClick(TabControl tcSample)
        {
            int newIndex = tcSample.SelectedIndex + 1;

            if (newIndex >= tcSample.Items.Count)
                newIndex = 0;
            tcSample.SelectedIndex = newIndex;
        }
    }
}
