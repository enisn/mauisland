using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UraniumUI.Dialogs;

namespace MAUIsland;
class ColorPicker : IColorPicker
{
    public Task PickColorForAsync(object context, string bindingPath)
    {
        return GetCurrentPage().Navigation.PushModalAsync(new ColorEditPopupPage(context, bindingPath));
    }

    protected virtual Page GetCurrentPage()
    {
        if (Application.Current.MainPage is Shell shell)
        {
            return shell.CurrentPage;
        }

        if (Application.Current.MainPage is NavigationPage nav)
        {
            return nav.CurrentPage;
        }

        if (Application.Current.MainPage is TabbedPage tabbed)
        {
            return tabbed.CurrentPage;
        }

        return Application.Current.MainPage;
    }
}