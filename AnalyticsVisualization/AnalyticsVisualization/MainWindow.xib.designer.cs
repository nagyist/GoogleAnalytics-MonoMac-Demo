// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace AnalyticsVisualization {
	
	
	// Should subclass MonoMac.AppKit.NSWindow
	[MonoMac.Foundation.Register("MainWindow")]
	public partial class MainWindow {
	}
	
	// Should subclass MonoMac.AppKit.NSWindowController
	[MonoMac.Foundation.Register("MainWindowController")]
	public partial class MainWindowController {
		
		private global::MonoMac.AppKit.NSSecureTextField __mt__passwordField;
		
		private global::MonoMac.AppKit.NSTextField __mt__userNameField;
		
		#pragma warning disable 0169
		[MonoMac.Foundation.Export("login:")]
		partial void login (MonoMac.Foundation.NSObject sender);

		[MonoMac.Foundation.Connect("_passwordField")]
		private global::MonoMac.AppKit.NSSecureTextField _passwordField {
			get {
				this.__mt__passwordField = ((global::MonoMac.AppKit.NSSecureTextField)(this.GetNativeField("_passwordField")));
				return this.__mt__passwordField;
			}
			set {
				this.__mt__passwordField = value;
				this.SetNativeField("_passwordField", value);
			}
		}
		
		[MonoMac.Foundation.Connect("_userNameField")]
		private global::MonoMac.AppKit.NSTextField _userNameField {
			get {
				this.__mt__userNameField = ((global::MonoMac.AppKit.NSTextField)(this.GetNativeField("_userNameField")));
				return this.__mt__userNameField;
			}
			set {
				this.__mt__userNameField = value;
				this.SetNativeField("_userNameField", value);
			}
		}
	}
}
