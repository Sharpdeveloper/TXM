using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using TXM.Core.Global;

namespace TXM.Core.Models;

public partial class Pairing : ObservableObject
{
    #region Static

    private static int startingTableNo = 0;

    public static void ResetTableNo(int startNo = 0)
    {
        startingTableNo = startNo;
    }
    #endregion

    [ObservableProperty]
    private List<string> _winners = new List<string>();

    #region Properties
    [ObservableProperty]
    public int _tableNo;

    [ObservableProperty]
    private int _player1ID;

    [ObservableProperty]
    private int _player2ID;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHidden))]
    private int _player1Score;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHidden))]
    private int _player2Score;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHidden))]
    private string _winner;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHidden))]
    private bool _isResultEdited;

    [ObservableProperty]
    private int _player1Points;

    [ObservableProperty]
    private int _player2Points;

    [ObservableProperty]
    private string _player1Name;

    [ObservableProperty]
    private string _player2Name;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHidden))]
    private bool _isLocked;

    [ObservableProperty]
    private bool _isDoubleLoss;

    public bool IsHidden
    {
        get
        {
            return (Player1Score != 0 && Player2Score != 0 && (Player1Score != Player2Score || Winner != "Automatic")) || IsResultEdited || IsLocked;
        }
    }
    public Player? Player1
    {
        private get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                Player1ID = value.ID;
                Player1Name = value.DisplayName;
            }
        }
    }
    public Player? Player2
    {
        private get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                Player2ID = value.ID;
                Player2Name = value.DisplayName;
            }
        }
    }
    #endregion

    #region Constructor
    public Pairing(int tableNo = -1)
    {
        Winners = new()
        {
            State.Text.Automatic,
            State.Text.Player1,
            State.Text.Player2
        };
        Winner = "Automatic";
        if (tableNo == -1)
        {
            tableNo = ++startingTableNo;
        }
        TableNo = tableNo;
        IsResultEdited = false;
        IsLocked = false;
    }

    public Pairing(Pairing p)
    {
        TableNo = p.TableNo;
        Player1ID = p.Player1ID;
        Player2ID = p.Player2ID;
        Player1Score = p.Player1Score;
        Player2Score = p.Player2Score;
        IsResultEdited = p.IsResultEdited;
        Winner = p.Winner;
        Player1Points = p.Player1Points;
        Player2Points = p.Player2Points;
        IsLocked = p.IsLocked;
        Player1Name = p.Player1Name;
        Player2Name = p.Player2Name;
        IsDoubleLoss = p.IsDoubleLoss;
    }
    #endregion
}
