using CommunityToolkit.Mvvm.ComponentModel;

using TXM.Core.Global;
using TXM.Core.Models;

namespace TXM.Core.ViewModels;

public partial class AutoSaveViewModel : ObservableObject
{
    [ObservableProperty]
    public List<AutoSaveFile> files;
    
    public string FileName => SelectedFile == null ? "" : SelectedFile.FileName;

    [ObservableProperty]
    public Texts text = State.Text;

    [ObservableProperty]
    private AutoSaveFile? _selectedFile;
}