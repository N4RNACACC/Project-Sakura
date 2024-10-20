using Avalonia.Controls;

namespace SakuraCraftLauncher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        {
            CanResize = false; //限制窗口大小不可更改

        };
    }
}
