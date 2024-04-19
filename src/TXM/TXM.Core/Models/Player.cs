using CommunityToolkit.Mvvm.ComponentModel;

using TXM.Core.Enums;
using TXM.Core.Global;

namespace TXM.Core.Models;

public partial class Player : ObservableObject
{
    #region static

    private static int _currentId = 1;

    private static Player? _bye;
    public static Player Bye =>
        _bye ??= new Player("Bye")
        {
            ID = -1
            
        };

    private static Player? _wonBye;
    public static Player WonBye =>
        _wonBye ??= new Player("WonBye")
        {
            ID = -2
        };

    private static Player? _bonus;
    public static Player Bonus =>
        _bonus ??= new Player("Bonus")
        {
            ID = -3
        };

    /// <summary>
    /// Resets the internal player ID which is used to give each player an unique ID
    /// </summary>
    public static void ResetId()
    {
        _currentId = 0;
    }
    #endregion

    #region Player Information
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    private string? _name;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    private string? _firstname;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    private string _nickname;

    public NameDisplayMode DisplayMode { get; set; } = State.Setting.DisplayMode;

    [ObservableProperty]
    private int _tableNo;

    [ObservableProperty]
    private string? _team;

    [ObservableProperty]
    private string? _city;

    [ObservableProperty]
    private string? _squadList;

    [ObservableProperty]
    private bool _isDisqualified;

    [ObservableProperty]
    private bool _hasDropped;

    [ObservableProperty]
    private bool _isPresent;

    [ObservableProperty]
    private int _order;
    #endregion

    #region Game Infomation
    [ObservableProperty]
    private int _iD;

    [ObservableProperty]
    private int _wins;

    [ObservableProperty]
    private int _modifiedWins;

    [ObservableProperty]
    private int _losses;

    [ObservableProperty]
    private int _modifiedLosses;

    [ObservableProperty]
    private int _draws;

    [ObservableProperty]
    private int _tournamentPoints;

    [ObservableProperty]
    private int _destroyedPoints;

    [ObservableProperty]
    private int _lostPoints;

    [ObservableProperty]
    private double _strengthOfSchedule;

    [ObservableProperty]
    private double _extendedStrengthOfSchedule;

    [ObservableProperty]
    private int _marginOfVictory;

    [ObservableProperty]
    private string? _faction;

    [ObservableProperty]
    private bool _isInCut;

    public List<Result>? Results { get; set; }
    #endregion

    #region Tournament Information
    public List<Enemy>? Enemies { get; set; }

    [ObservableProperty]
    private bool _hasBye;

    [ObservableProperty]
    private bool _isPaired;

    [ObservableProperty]
    private bool _hasWonBye;
    #endregion

    #region T3 Information
    public int T3Id { get; private set; }

    [ObservableProperty]
    private int _rank;

    public int ArmyRank { get; set; }

    [ObservableProperty]
    private bool _hasPaid;

    [ObservableProperty]
    private bool _hasListGiven;
    #endregion

    #region Derived Information
    public string DisplayName
    {
        get
        {
            if (ID < 0)
            {
                DisplayMode = NameDisplayMode.Nick;
            }
            return DisplayMode switch
            {
                NameDisplayMode.Nick => Nickname
                , NameDisplayMode.FirstLast => $"{Firstname ?? Nickname} {Name ?? Nickname}"
                , NameDisplayMode.FirstNick => $"{Firstname ?? ""} {Nickname}"
                , NameDisplayMode.FirstNickLast => $"{Firstname ?? ""} \"{Nickname}\" {Name ?? ""}"
                , NameDisplayMode.FistLastShort => $"{Firstname ?? Nickname} {Name?.ToCharArray()[0]}."
                , _ => Nickname
            };
        }
    }
    #endregion

    #region Constructors
    public Player()
    {}
    //Copy Constructor
    public Player(Player p)
    {
        Name = p.Name;
        Firstname = p.Firstname;
        Nickname = p.Nickname;
        TableNo = p.TableNo;
        Team = p.Team;
        City = p.City;
        SquadList = p.SquadList;
        IsDisqualified = p.IsDisqualified;
        HasDropped = p.HasDropped;
        IsPresent = p.IsPresent;
        Order = p.Order;
        ID = p.ID;
        Wins = p.Wins;
        ModifiedWins = p.ModifiedWins;
        Losses = p.Losses;
        ModifiedLosses = p.ModifiedLosses;
        Draws = p.Draws;
        TournamentPoints = p.TournamentPoints;
        DestroyedPoints = p.DestroyedPoints;
        LostPoints = p.LostPoints;
        StrengthOfSchedule = p.StrengthOfSchedule;
        ExtendedStrengthOfSchedule = p.ExtendedStrengthOfSchedule;
        MarginOfVictory = p.MarginOfVictory;
        Faction = p.Faction;
        IsInCut = p.IsInCut;
        HasBye = p.HasBye;
        IsPaired = p.IsPaired;
        HasWonBye = p.HasWonBye;
        Rank = p.Rank;
        HasPaid = p.HasPaid;
        HasListGiven = p.HasListGiven;
        Results = p.Results;
        Enemies = p.Enemies;
        T3Id = p.T3Id;
        ArmyRank = p.ArmyRank;
        DisplayMode = p.DisplayMode;
    }

    public Player(string name, string firstname, string nickname, string team, string city, int wins, int modifiedWins, int looses, int draws, int points, int pointsDestroyed, int pointsLost, double strengthOfSchedule, int marginOfVictory, string faction, bool hasBye, bool isPaired, bool hasWonBye, int t3Id, int rank, int armyRank, bool hasPaid, bool hasListGiven, int nr = -1)
    {
        Name = name;
        Firstname = firstname;
        Nickname = nickname;
        Team = team;
        City = city;
        Wins = wins;
        ModifiedWins = modifiedWins;
        Losses = looses;
        Draws = draws;
        TournamentPoints = points;
        DestroyedPoints = pointsDestroyed;
        LostPoints = pointsLost;
        StrengthOfSchedule = strengthOfSchedule;
        MarginOfVictory = marginOfVictory;
        Faction = faction;
        HasBye = hasBye;
        IsPaired = isPaired;
        HasWonBye = hasWonBye;
        HasBye = hasBye;
        T3Id = t3Id;
        Rank = rank;
        ArmyRank = armyRank;
        HasPaid = hasPaid;
        HasListGiven = hasListGiven;
        if (nr == -1)
        {
            ID = ++_currentId;
        }
        else
        {
            ID = nr;
        }

        Enemies = new List<Enemy>();
        Results = new List<Result>();
    }

    public Player(int t3Id, string firstname, string name, string nickname, string faction, string city, string team, bool payed, bool armyListGiven)
        : this(name, firstname, nickname, team, city, 0, 0, 0, 0, 0, 0, 0, 0, 0, faction, false, false, false, t3Id, 0, 0, payed, armyListGiven)
    { }


    public Player(string nickname)
        : this(0, "", "", nickname, "", "", "", false, false)
    { }
    #endregion

    #region internal methods
    /// <summary>
    /// Checks if the player has played vs this Enemy
    /// </summary>
    /// <param name="enemyId">The Player.ID of the Enemy</param>
    /// <returns>Returns true if the player has played against this Enemy. Otherwise false.</returns>
    internal bool HasPlayedVs(int enemyId)
    {
        if (Enemies == null)
        {
            return false;
        }
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.ID == enemyId)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks if the player has played vs this Enemy and won the match
    /// </summary>
    /// <param name="enemyId">The Player.ID of the Enemy</param>
    /// <returns>Returns true if the player has played against this Enemy and won the match. Otherwise false.</returns>
    internal bool HasPlayedAndWonVs(int enemyId)
    {
        if (Enemies == null)
        {
            return false;
        }
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.ID == enemyId)
            {
                return enemy.WonAgainst;
            }
        }
        return false;
    }
    #endregion

    #region public methods
    public bool Equals(Player other)
    {
        return ID == other.ID;
    }

    public override int GetHashCode()
    {
        return ID;
    }

    /// <summary>
    /// Creates a new Random for Order
    /// </summary>
    public void NewRandom()        
    {
        Order = new Random().Next(0, 99999);
    }
    #endregion

    public static Player GetBye(int byeId)
    {
        if (byeId == Bonus.ID)
        {
            return Bonus;
        }
        return byeId == WonBye.ID ? WonBye : Bye;
    }
}