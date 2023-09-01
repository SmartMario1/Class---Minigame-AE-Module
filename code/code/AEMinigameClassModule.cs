
using Sandbox;
using System.Linq;
using TerrorTown;

namespace AEMinigameClassModule;



public static partial class AEMinigameClassModule
{
	// This initialisation code is copied from the example module @https://asset.party/ryan/adminessentials_examplemodule
	private static bool initialized = false;

	static AEMinigameClassModule()
	{
		Initialize();
	}

	[Event( "ae_module_smartmario.ae_ttt_sm1_class_minigame" )]
	public static void Initialize()
	{
		if ( initialized ) { return; }
		initialized = true;

		AdminEssentials.AdminEssentials.RegisterCommand( new ClassCommand() );
		AdminEssentials.AdminEssentials.RegisterCommand( new MinigameCommand() );
		AdminEssentials.AdminEssentials.RegisterCommand( new ClassDescription(), true );

		Log.Info( "AE Minigame Module Loaded." );
	}

	//[ConCmd.Client( "ae_testing" )]
	//public static void test()
	//{
	//	foreach ( var panel in Game.RootPanel.Children )
	//	{
	//		Log.Info( panel );
	//	}
	//}


	// The chat box is too low when using classes and overlaps causing a bunch of flickering and stuff,
	// so this code moves the chatbox up a bit to prevent that.
	
	[Event( "Game.Round.Start" )]
	public static void MoveTextBox()
	{
		Game.AssertServer();
		MoveTextBoxClient();
	}

	[ClientRpc]
	public static void MoveTextBoxClient()
	{
		var text = Game.RootPanel.ChildrenOfType<AdminEssentials.AEChatBox>().FirstOrDefault();
		if ( text == null ) { return; }
		text.SetProperty( "style", "bottom: 24%" );
	}
}
