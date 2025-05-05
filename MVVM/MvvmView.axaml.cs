using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lr9.MVVM
{
    public partial class MvvmView : UserControl
    {
        public MvvmView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}