﻿namespace TXM.Core.Text;


/// <summary>
/// Texts.cs
/// Static class which contains all texts which can be outputted.
/// These enables translation files
/// </summary>
public class Texts
{
    public static string Automatic { get; private set; } = "Automatic";
    public static string AutoSaveFolderDeleted { get; private set; } = "Auto save folder was deleted.";
    public static string Disqualified { get; private set; } = "disqualified";
    public static string Draws { get; private set; } = "Draws";
    public static string DrawsShort { get; private set; } = "D";
    public static string Dropped { get; private set; } = "dropped";
    public static string ExcelFile { get; private set; } = "Excel File";
    public static string ExportFile { get; private set; } = "Export File";
    public static string ExtendedStrengthOfSchedule { get; private set; } = "extended Strength of Schedule";
    public static string ExtendedStrengthOfScheduleShort { get; private set; } = "eSoS";
    public static string Faction { get; private set; } = "Faction";
    public static string Firstname { get; private set; } = "Firstname";
    public static string ImageFiles { get; private set; } = "Image Files";
    public static string ImportFile { get; private set; } = "Import File";
    public static string InvalidFile { get; private set; } = "Please choose a valid <filetype>-file.";
    public static string ListGiven { get; private set; } = "Has List given";
    public static string ListGivenShort { get; private set; } = "L";
    public static string Lock { get; private set; } = "Locks the Pairing, so it can't be accidentally changed.";
    public static string LockShort { get; private set; } = "L";
    public static string Losses { get; private set; } = "Losses";
    public static string LossesShort { get; private set; } = "L";
    public static string MarginOfVictory { get; private set; } = "Margin of Victory";
    public static string MarginOfVictoryShort { get; private set; } = "MoV";
    public static string ModifiedLosses { get; private set; } = "Modified Losses";
    public static string ModifiedLossesShort { get; private set; } = "ML";
    public static string ModifiedWins { get; private set; } = "Modified Wins";
    public static string ModifiedWinsShort { get; private set; } = "MW";
    public static string Nickname { get; private set; } = "Nickname";
    public static string NoAutoSaveFolder { get; private set; } = "There is no auto save folder.";
    public static string NoPairingsYet { get; private set; } = "No Pairings yet";
    public static string NoRoundStarted { get; private set; } = "No Round started";
    public static string Paid { get; private set; } = "Paid";
    public static string PaidShort { get; private set; } = "$";
    public static string Pairings { get; private set; } = "Pairings";
    public static string Player { get; private set; } = "Player";
    public static string PlayerShort { get; private set; } = "P";
    public static string Points { get; private set; } = "Points";
    public static string Present { get; private set; } = "Is Present";
    public static string PresentShort { get; private set; } = "!";
    public static string Rank { get; private set; } = "Rank";
    public static string RankShort { get; private set; } = "#";
    public static string ResultEdited { get; private set; } = "Is the result edited?";
    public static string ResultEditedShort { get; private set; } = "OK?";
    public static string Results { get; private set; } = "Results";
    public static string Round { get; private set; } = "Round";
    public static string Score { get; private set; } = "Score";
    public static string StrengthOfSchedule { get; private set; } = "Strength of Schedule";
    public static string StrengthOfScheduleShort { get; private set; } = "SoS";
    public static string Table { get; private set; } = "Table";
    public static string TableShort { get; private set; } = "T";
    public static string TableNo { get; private set; } = "Table Number";
    public static string TableNoShort { get; private set; } = "T#";
    public static string Team { get; private set; } = "Team";
    public static string TournamentPoints { get; private set; } = "Tournament Points";
    public static string TournamentPointsShort { get; private set; } = "TP";
    public static string Winner { get; private set; } = "Winner";
    public static string Wins { get; private set; } = "Wins";
    public static string WinsShort { get; private set; } = "W";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";
    //public static string Disqualified { get; private set; } = "disqualified";

    public static string Player1 => $"{Player} 1";
    public static string Player2 => $"{Player} 2";
    public static string Player1Points => $"{Player} 1 {Points}";
    public static string Player1PointsShort => $"{PlayerShort}1 {Points}";
    public static string Player2Points => $"{Player} 2 {Points}";
    public static string Player2PointsShort => $"{PlayerShort}2 {Points}";
    public static string Player1Score => $"{Player} 1 {Score}";
    public static string Player1ScoreShort => $"{PlayerShort}1 {Score}";
    public static string Player2Score => $"{Player} 2 {Score}";
    public static string Player2ScoreShort => $"{PlayerShort}2 {Score}";




    //TODO JSON Import (export)
}
