using System.Windows;
using System.Windows.Input;

namespace SakuraCraftLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e) // 自定义程序退出
        {
            this.Close();
        }
        private void Window_MinimizeButton_Click(object sender, RoutedEventArgs e) // 自定义窗口最小化
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) // 自定义窗口拖动
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}