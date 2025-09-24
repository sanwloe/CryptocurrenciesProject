using CryptoCurrencies.Common.View.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoCurrencies.Common.Services
{
    public class TabNavigationService
    {
        private DevExpress.Xpf.Core.DXTabControl _tabControl;
        public TabNavigationService(DevExpress.Xpf.Core.DXTabControl dXTabControl)
        {
            _tabControl = dXTabControl;
        }
        public void ShowTab(ContentControl content,string header)
        {
            var tabItem = new DevExpress.Xpf.Core.DXTabItem()
            {
                AllowHide = DevExpress.Utils.DefaultBoolean.True,
                Content = content,
                Header = header
            };
            _tabControl.InsertTabItem(tabItem, _tabControl.Items.Count);
            _tabControl.ShowTabItem(tabItem, false);
        }
    }
}
