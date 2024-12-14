using System.Windows;
using System.Windows.Controls;
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
            PageFrame.Navigate(new Pages.HomePage());
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

        private void PageRadioButton_Checked(object sender, RoutedEventArgs e) // 页面跳转逻辑
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                switch (radioButton.Content)
                {
                    case "Home":
                        PageFrame.Navigate(new Pages.HomePage());
                        break;
                    case "Download":
                        PageFrame.Navigate(new Pages.DownloadPage());
                        break;
                    case "Settings":
                        PageFrame.Navigate(new Pages.SettingsPage());
                        break;
                }
            }
        }
    
    
    }
}