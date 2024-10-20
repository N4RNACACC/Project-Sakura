﻿using MinecraftLaunch.Classes.Interfaces;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Components.Launcher;
using MinecraftLaunch.Components.Resolver;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SakuraCraftLauncher.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand GameLaunch { get; }
    public static string? UserName { get; private set; }

    public MainViewModel()
    {
        GameLaunch = ReactiveCommand.Create(static async () =>
        {
            IGameResolver GameResolver = new GameResolver(".minecraft");
            // 登录的账户信息
            var LoginAccount = new OfflineAuthenticator(UserName).Authenticate();
            try
            {
                var config = new LaunchConfig
                {
                    // 设置启动的账户
                    Account = LoginAccount,
                    // 配置代码是否可独立运行
                    IsEnableIndependencyCore = true,
                    // Java配置
                    JvmConfig = new(@"C:\Program Files\Java\jre1.8.0_421\bin\javaw.exe")
                    {
                        MaxMemory = 4096,
                        MinMemory = 1024,
                    },
                };
                // 启动核心所需的信息
                Launcher launcher = new(GameResolver, config);
                // 异步启动游戏，防止启动器卡死
                await Task.Run(async () =>
                {
                    var gameProcessWatcher = await launcher.LaunchAsync("1.12.2");
                    // 2024-9-19 简单启动实现，已满足某些方面的基础需要
                    // 2024-9-19 请确保与启动器同目录的.minecraft文件夹存在版本“1.12.2”，否则当启动器START按钮按下后程序会因为此段代码崩溃，待后续完善
                });
            }
            catch (Exception)
            {
                var box = MessageBoxManager
                .GetMessageBoxStandard("ERROR", "Can't Launch Game !", ButtonEnum.Ok);
                var result = await box.ShowWindowAsync();
            }
        });

    }
}

