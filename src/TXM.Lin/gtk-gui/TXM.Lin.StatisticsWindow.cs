
// This file has been generated by the GUI designer. Do not modify.
namespace TXM.Lin
{
	public partial class StatisticsWindow
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.Action DateiAction;
		
		private global::Gtk.Action SpeichernAction;
		
		private global::Gtk.Action LadenAction;
		
		private global::Gtk.Action ImportAction;
		
		private global::Gtk.Action ExcelTxtDateiAction;
		
		private global::Gtk.Action ExcelTxtDateiMitBersichtsdateiAction;
		
		private global::Gtk.Action ExportAction;
		
		private global::Gtk.Action ExcelCsvDateiAction;
		
		private global::Gtk.Action BeendenAction;
		
		private global::Gtk.Action DatenAktualisierenAction;
		
		private global::Gtk.VBox vbox9;
		
		private global::Gtk.MenuBar menubar1;
		
		private global::Gtk.HBox hbox17;
		
		private global::Gtk.Entry TextBoxURL;
		
		private global::Gtk.Button button644;
		
		private global::Gtk.Button button645;
		
		private global::Gtk.HBox hbox16;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView DataGridShips;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.NodeView DataGridPilots;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow2;
		
		private global::Gtk.NodeView DataGridUpgrades;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget TXM.Lin.StatisticsWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.DateiAction = new global::Gtk.Action ("DateiAction", global::Mono.Unix.Catalog.GetString ("Datei"), null, null);
			this.DateiAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Datei");
			w1.Add (this.DateiAction, null);
			this.SpeichernAction = new global::Gtk.Action ("SpeichernAction", global::Mono.Unix.Catalog.GetString ("Speichern"), null, null);
			this.SpeichernAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Speichern");
			w1.Add (this.SpeichernAction, null);
			this.LadenAction = new global::Gtk.Action ("LadenAction", global::Mono.Unix.Catalog.GetString ("Laden"), null, null);
			this.LadenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Laden");
			w1.Add (this.LadenAction, null);
			this.ImportAction = new global::Gtk.Action ("ImportAction", global::Mono.Unix.Catalog.GetString ("Import"), null, null);
			this.ImportAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Import");
			w1.Add (this.ImportAction, null);
			this.ExcelTxtDateiAction = new global::Gtk.Action ("ExcelTxtDateiAction", global::Mono.Unix.Catalog.GetString ("Excel (txt-Datei)"), null, null);
			this.ExcelTxtDateiAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Excel (txt-Datei)");
			w1.Add (this.ExcelTxtDateiAction, null);
			this.ExcelTxtDateiMitBersichtsdateiAction = new global::Gtk.Action ("ExcelTxtDateiMitBersichtsdateiAction", global::Mono.Unix.Catalog.GetString ("Excel (txt-Datei mit Übersichtsdatei)"), null, null);
			this.ExcelTxtDateiMitBersichtsdateiAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Excel (txt-Datei mit Übersichtsdatei)");
			w1.Add (this.ExcelTxtDateiMitBersichtsdateiAction, null);
			this.ExportAction = new global::Gtk.Action ("ExportAction", global::Mono.Unix.Catalog.GetString ("Export"), null, null);
			this.ExportAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Export");
			w1.Add (this.ExportAction, null);
			this.ExcelCsvDateiAction = new global::Gtk.Action ("ExcelCsvDateiAction", global::Mono.Unix.Catalog.GetString ("Excel (csv-Datei)"), null, null);
			this.ExcelCsvDateiAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Excel (csv-Datei)");
			w1.Add (this.ExcelCsvDateiAction, null);
			this.BeendenAction = new global::Gtk.Action ("BeendenAction", global::Mono.Unix.Catalog.GetString ("Beenden"), null, null);
			this.BeendenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Beenden");
			w1.Add (this.BeendenAction, null);
			this.DatenAktualisierenAction = new global::Gtk.Action ("DatenAktualisierenAction", global::Mono.Unix.Catalog.GetString ("Daten aktualisieren"), null, null);
			this.DatenAktualisierenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Daten aktualisieren");
			w1.Add (this.DatenAktualisierenAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "TXM.Lin.StatisticsWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("StatisticsWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TXM.Lin.StatisticsWindow.Gtk.Container+ContainerChild
			this.vbox9 = new global::Gtk.VBox ();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			// Container child vbox9.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='DateiAction' action='DateiAction'><menuitem name='SpeichernAction' action='SpeichernAction'/><menuitem name='LadenAction' action='LadenAction'/><menu name='ImportAction' action='ImportAction'><menuitem name='ExcelTxtDateiAction' action='ExcelTxtDateiAction'/><menuitem name='ExcelTxtDateiMitBersichtsdateiAction' action='ExcelTxtDateiMitBersichtsdateiAction'/></menu><menu name='ExportAction' action='ExportAction'><menuitem name='ExcelCsvDateiAction' action='ExcelCsvDateiAction'/></menu><menuitem name='BeendenAction' action='BeendenAction'/></menu><menu name='DatenAktualisierenAction' action='DatenAktualisierenAction'/></menubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vbox9.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox17 = new global::Gtk.HBox ();
			this.hbox17.Name = "hbox17";
			this.hbox17.Spacing = 6;
			// Container child hbox17.Gtk.Box+BoxChild
			this.TextBoxURL = new global::Gtk.Entry ();
			this.TextBoxURL.CanFocus = true;
			this.TextBoxURL.Name = "TextBoxURL";
			this.TextBoxURL.IsEditable = true;
			this.TextBoxURL.InvisibleChar = '●';
			this.hbox17.Add (this.TextBoxURL);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox17 [this.TextBoxURL]));
			w3.Position = 0;
			// Container child hbox17.Gtk.Box+BoxChild
			this.button644 = new global::Gtk.Button ();
			this.button644.CanFocus = true;
			this.button644.Name = "button644";
			this.button644.UseUnderline = true;
			this.button644.Label = global::Mono.Unix.Catalog.GetString ("+");
			this.hbox17.Add (this.button644);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox17 [this.button644]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.button645 = new global::Gtk.Button ();
			this.button645.CanFocus = true;
			this.button645.Name = "button645";
			this.button645.UseUnderline = true;
			this.button645.Label = global::Mono.Unix.Catalog.GetString ("-");
			this.hbox17.Add (this.button645);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox17 [this.button645]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox9.Add (this.hbox17);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.hbox17]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox16 = new global::Gtk.HBox ();
			this.hbox16.Name = "hbox16";
			this.hbox16.Spacing = 6;
			// Container child hbox16.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.DataGridShips = new global::Gtk.NodeView ();
			this.DataGridShips.CanFocus = true;
			this.DataGridShips.Name = "DataGridShips";
			this.GtkScrolledWindow.Add (this.DataGridShips);
			this.hbox16.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox16 [this.GtkScrolledWindow]));
			w8.Position = 0;
			// Container child hbox16.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.DataGridPilots = new global::Gtk.NodeView ();
			this.DataGridPilots.CanFocus = true;
			this.DataGridPilots.Name = "DataGridPilots";
			this.GtkScrolledWindow1.Add (this.DataGridPilots);
			this.hbox16.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox16 [this.GtkScrolledWindow1]));
			w10.Position = 1;
			// Container child hbox16.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.DataGridUpgrades = new global::Gtk.NodeView ();
			this.DataGridUpgrades.CanFocus = true;
			this.DataGridUpgrades.Name = "DataGridUpgrades";
			this.GtkScrolledWindow2.Add (this.DataGridUpgrades);
			this.hbox16.Add (this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox16 [this.GtkScrolledWindow2]));
			w12.Position = 2;
			this.vbox9.Add (this.hbox16);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.hbox16]));
			w13.Position = 2;
			this.Add (this.vbox9);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.SpeichernAction.Activated += new global::System.EventHandler (this.Save_Click);
			this.LadenAction.Activated += new global::System.EventHandler (this.Load_Click);
			this.ExcelTxtDateiAction.Activated += new global::System.EventHandler (this.CSV_Import_Click);
			this.ExcelTxtDateiMitBersichtsdateiAction.Activated += new global::System.EventHandler (this.CSV_Import_Overview_Click);
			this.ExcelCsvDateiAction.Activated += new global::System.EventHandler (this.CSV_Export_Click);
			this.BeendenAction.Activated += new global::System.EventHandler (this.Beenden);
			this.DatenAktualisierenAction.Activated += new global::System.EventHandler (this.Update_Data_Click);
			this.button644.Clicked += new global::System.EventHandler (this.ButtonPlus_Click);
			this.button645.Clicked += new global::System.EventHandler (this.ButtonMinus_Click);
		}
	}
}
