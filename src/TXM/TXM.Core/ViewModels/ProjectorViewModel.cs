﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace TXM.Core.ViewModels;

public partial class ProjectorViewModel : ObservableObject
{
    [ObservableProperty]
    private TournamentTimer _timer;
    
    [ObservableProperty]
    private string _path;

    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private bool _timerVisibility;
}