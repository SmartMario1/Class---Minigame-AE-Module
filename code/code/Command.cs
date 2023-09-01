using AdminEssentials.commands;
using Sandbox;
using TTT_Classes;

namespace AEMinigameClassModule;

public class ClassCommand : BaseCommand
{
    public ClassCommand()
    {
        commandName = "class";
        org = "ttt";
        helpText = "Open the class UI.\n \n (ADMINS BEWARE) Also makes you at least a moderator in the internal TTT moderation system. You can view what permissions this grants at https://wiki.threethieves.org/admin_commands.";
    }

    protected override void DoCommand(IClient callingUser, params string[] args)
    {
		Log.Info( "Class time" );
		if ( callingUser.Pawn is TerrorTown.Player ply )
		{
			// The class and minigame manager are currently coded to check the permission level added by base TTT, so I set this here. It is up to admins
			// to make sure this does not grant any unwanted permissions.
			if ( !(ply.PermissionLevel >= TerrorTown.PermissionLevel.Moderator) )
			{
				ply.UserData.PermissionLevel = TerrorTown.PermissionLevel.Moderator;
				ply.PermissionLevel = TerrorTown.PermissionLevel.Moderator;
			}
			callingUser.SendCommandToClient( "class_toggle_ui" );
		}

	}
}

public class MinigameCommand : BaseCommand
{
	public MinigameCommand()
	{
		commandName = "minigame";
		org = "ttt";
		helpText = "Open the minigame UI.\n \n (ADMINS BEWARE) Also makes you at least a moderator in the internal TTT moderation system. You can view what permissions this grants at https://wiki.threethieves.org/admin_commands.";
	}

	protected override void DoCommand( IClient callingUser, params string[] args )
	{
		if (callingUser.Pawn is TerrorTown.Player ply)
		{
			// The class and minigame manager are currently coded to check the permission level added by base TTT, so I set this here. It is up to admins
			// to make sure this does not grant any unwanted permissions.
			if (!(ply.PermissionLevel >= TerrorTown.PermissionLevel.Moderator))
			{
				ply.UserData.PermissionLevel = TerrorTown.PermissionLevel.Moderator;
				ply.PermissionLevel = TerrorTown.PermissionLevel.Moderator;
			}
			callingUser.SendCommandToClient( "minigame_toggle_ui" );
		}
	}
}

public class ClassDescription : BaseCommand
{
	public ClassDescription()
	{
		commandName = "class_desc";
		org = "ttt";
		helpText = "Sends you the description of your class in the chat.";
	}

	// This command is copied from the class addon, but fixed for the AE chat.
	protected override void DoCommand( IClient callingUser, params string[] args )
	{
		var attached_class = ConsoleSystem.Caller.Pawn.Components.Get<TTT_Class>();
		if ( attached_class == null )
		{
			ClientPrint( callingUser, "You don't have an assigned class!" );
		}
		else
		{
			ClientPrint(callingUser, attached_class.Description );
		}
	}
}
