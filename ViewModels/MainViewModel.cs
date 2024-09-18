using ReactiveUI;
using System.Windows.Input;

namespace SakuraCraftLauncher.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand GameLaunch { get; }

    public MainViewModel()
    {
        GameLaunch = ReactiveCommand.Create(() =>
        {
            // 当按钮被点击时，这里的代码将被执行。
        });
    }
}

