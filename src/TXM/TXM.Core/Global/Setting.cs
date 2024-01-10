using CommunityToolkit.Mvvm.ComponentModel;

using TXM.Core.Enums;

namespace TXM.Core.Global;

public sealed partial class Settings : ObservableObject
{
    public Settings() { }
    private static Settings _instance = new Settings();
    public static Settings GetInstance() => _instance;
    
    #region Constants
    public const string FileExtension = "txmj";
    public const string FileExtensionsName = "TXM Tournaments";
    public const string TxmVersion = "V4.0.0 Beta 2";
    public const string CopyRightYear = "2014 - 2024";
    #endregion

    [ObservableProperty]
    private string _textColor = Literals.Black;
    
    [ObservableProperty]
    private string _bgImagePath = "";
    
    [ObservableProperty]
    private double _textSize = 300.0;
    
    [ObservableProperty]
    private string _language = Literals.LanguageDefault;

    [ObservableProperty]
    private bool _isTimerVisible = true;
    
    [ObservableProperty]
    private bool _isRandomVisible = false;

    [ObservableProperty]
    private NameDisplayMode _displayMode = NameDisplayMode.FirstNick;
}