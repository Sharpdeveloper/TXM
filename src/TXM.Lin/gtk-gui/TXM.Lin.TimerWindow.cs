
// This file has been generated by the GUI designer. Do not modify.
namespace TXM.Lin
{
	public partial class TimerWindow
	{
		private global::Gtk.Fixed fixed1;
		
		private global::Gtk.Label LabelTime;
		
		private global::Gtk.Button ButtonPause;
		
		private global::Gtk.Button ButtonStart;
		
		private global::Gtk.Button ButtonReset;
		
		private global::Gtk.Button ButtonSetImage;
		
		private global::Gtk.SpinButton IntegerUpDownMinutes;
		
		private global::Gtk.Label labelMinutes;
		
		private global::Gtk.RadioButton radiobuttonWhite;
		
		private global::Gtk.RadioButton radiobuttonBlack;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget TXM.Lin.TimerWindow
			this.Name = "TXM.Lin.TimerWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("X-Wing Timer");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TXM.Lin.TimerWindow.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.LabelTime = new global::Gtk.Label ();
			this.LabelTime.Name = "LabelTime";
			this.LabelTime.LabelProp = global::Mono.Unix.Catalog.GetString ("HH:MM");
			this.fixed1.Add (this.LabelTime);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.LabelTime]));
			w1.X = 8;
			w1.Y = 7;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.ButtonPause = new global::Gtk.Button ();
			this.ButtonPause.CanFocus = true;
			this.ButtonPause.Name = "ButtonPause";
			this.ButtonPause.UseUnderline = true;
			this.ButtonPause.Label = global::Mono.Unix.Catalog.GetString ("Pausieren");
			this.fixed1.Add (this.ButtonPause);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.ButtonPause]));
			w2.X = 58;
			w2.Y = 461;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.ButtonStart = new global::Gtk.Button ();
			this.ButtonStart.CanFocus = true;
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.UseUnderline = true;
			this.ButtonStart.Label = global::Mono.Unix.Catalog.GetString ("Start");
			this.fixed1.Add (this.ButtonStart);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.ButtonStart]));
			w3.X = 10;
			w3.Y = 461;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.ButtonReset = new global::Gtk.Button ();
			this.ButtonReset.CanFocus = true;
			this.ButtonReset.Name = "ButtonReset";
			this.ButtonReset.UseUnderline = true;
			this.ButtonReset.Label = global::Mono.Unix.Catalog.GetString ("Zurücksetzen");
			this.fixed1.Add (this.ButtonReset);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.ButtonReset]));
			w4.X = 144;
			w4.Y = 461;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.ButtonSetImage = new global::Gtk.Button ();
			this.ButtonSetImage.Sensitive = false;
			this.ButtonSetImage.CanFocus = true;
			this.ButtonSetImage.Name = "ButtonSetImage";
			this.ButtonSetImage.UseUnderline = true;
			this.ButtonSetImage.Label = global::Mono.Unix.Catalog.GetString ("Bild setzen");
			this.fixed1.Add (this.ButtonSetImage);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.ButtonSetImage]));
			w5.X = 248;
			w5.Y = 461;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.IntegerUpDownMinutes = new global::Gtk.SpinButton (0, 100, 1);
			this.IntegerUpDownMinutes.CanFocus = true;
			this.IntegerUpDownMinutes.Name = "IntegerUpDownMinutes";
			this.IntegerUpDownMinutes.Adjustment.PageIncrement = 10;
			this.IntegerUpDownMinutes.ClimbRate = 1;
			this.IntegerUpDownMinutes.Numeric = true;
			this.fixed1.Add (this.IntegerUpDownMinutes);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.IntegerUpDownMinutes]));
			w6.X = 337;
			w6.Y = 460;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.labelMinutes = new global::Gtk.Label ();
			this.labelMinutes.Name = "labelMinutes";
			this.labelMinutes.LabelProp = global::Mono.Unix.Catalog.GetString ("Minuten");
			this.fixed1.Add (this.labelMinutes);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelMinutes]));
			w7.X = 401;
			w7.Y = 463;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.radiobuttonWhite = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Weiße Schrift"));
			this.radiobuttonWhite.CanFocus = true;
			this.radiobuttonWhite.Name = "radiobuttonWhite";
			this.radiobuttonWhite.Active = true;
			this.radiobuttonWhite.DrawIndicator = true;
			this.radiobuttonWhite.UseUnderline = true;
			this.radiobuttonWhite.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.fixed1.Add (this.radiobuttonWhite);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonWhite]));
			w8.X = 460;
			w8.Y = 462;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.radiobuttonBlack = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Schwarze Schrift"));
			this.radiobuttonBlack.CanFocus = true;
			this.radiobuttonBlack.Name = "radiobuttonBlack";
			this.radiobuttonBlack.DrawIndicator = true;
			this.radiobuttonBlack.UseUnderline = true;
			this.radiobuttonBlack.Group = this.radiobuttonWhite.Group;
			this.fixed1.Add (this.radiobuttonBlack);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonBlack]));
			w9.X = 581;
			w9.Y = 462;
			this.Add (this.fixed1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 736;
			this.DefaultHeight = 497;
			this.Show ();
			this.ButtonPause.Clicked += new global::System.EventHandler (this.ButtonPause_Click);
			this.ButtonStart.Clicked += new global::System.EventHandler (this.ButtonStart_Click);
			this.ButtonReset.Clicked += new global::System.EventHandler (this.ButtonReset_Click);
			this.ButtonSetImage.Clicked += new global::System.EventHandler (this.ButtonReset_Click);
			this.IntegerUpDownMinutes.ValueChanged += new global::System.EventHandler (this.Minutes_Changed);
			this.radiobuttonWhite.Released += new global::System.EventHandler (this.SetWhite);
			this.radiobuttonBlack.Pressed += new global::System.EventHandler (this.SetBlack);
		}
	}
}
