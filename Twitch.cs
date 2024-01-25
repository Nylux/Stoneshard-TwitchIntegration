using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace Twitch;
public class Twitch : Mod
{
    public override string Author => "Nylux";
    public override string Name => "Twitch Integration";
    public override string Description => "Let Twitch Chat run commands in Stoneshard !";
    public override string Version => "0.1.0";

    public override void PatchMod()
    {
        InitTwitchIO();
        InitTwitchObject();
    }

    /// <summary>
    /// Adds TwitchIO functions used by o_twitch_connection to interact with twitch chat.
    /// </summary>
    public void InitTwitchIO()
    {
        ModLoader.AddFunction(ModFiles.GetCode("format.gml"), "format");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_send_raw.gml"), "twitch_send_raw");
        ModLoader.AddFunction(ModFiles.GetCode("console_log.gml"), "console_log");
        ModLoader.AddFunction(ModFiles.GetCode("example_command.gml"), "example_command");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_send_response.gml"), "twitch_send_response");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_commands.gml"), "twitch_commands");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_handle_data.gml"), "twitch_handle_data");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_chat_async.gml"), "twitch_chat_async");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_send_msg.gml"), "twitch_send_msg");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_chat_connect.gml"), "twitch_chat_connect");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_chat_disconnect.gml"), "twitch_chat_disconnect");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_config.gml"), "twitch_config");
        ModLoader.AddFunction(ModFiles.GetCode("twitch_init.gml"), "twitch_init");
    }

    /// <summary>
    /// Initializes the object responsible for creating and maintaining the connection to twitch.
    /// </summary>
    public void InitTwitchObject()
    {
        // Creating o_twitch_connection Object
        UndertaleGameObject o_twitch_connection = ModLoader.AddObject("o_twitch_connection");
        o_twitch_connection.Persistent = true;
        
        
        // Making o_twitch_connection really persistent
        ModLoader.InsertGMLString(ModFiles.GetCode("sessionDataInit.gml"), "gml_GlobalScript_scr_sessionDataInit", 51);
        ModLoader.InsertGMLString(ModFiles.GetCode("persistentRoomController.gml"), "gml_Object_persistentRoomController_Other_11", 19);
        
        
        // Create Event
        ModLoader.AddCode(ModFiles.GetCode("createEvent.gml"), "gml_Object_o_twitch_connection_Create_0");
        UndertaleGameObject.Event create = new();
        create.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = ModLoader.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Create_0")
        });
        o_twitch_connection.Events[0].Add(create);
        
        
        // Alarm 0 Event
        ModLoader.AddCode(ModFiles.GetCode("alarm0Event.gml"), "gml_Object_o_twitch_connection_Alarm_0");
        UndertaleGameObject.Event alarm0 = new();
        alarm0.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = ModLoader.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Alarm_0")
        });
        o_twitch_connection.Events[2].Add(alarm0);
        
        
        // CleanUp Event
        ModLoader.AddCode(ModFiles.GetCode("cleanUpEvent.gml"), "gml_Object_o_twitch_connection_CleanUp_0");
        UndertaleGameObject.Event cleanUp = new();
        cleanUp.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = ModLoader.GetUMTCodeFromFile("gml_Object_o_twitch_connection_CleanUp_0")
        });
        o_twitch_connection.Events[12].Add(cleanUp);
        

        // Async Networking Event
        ModLoader.AddCode(ModFiles.GetCode("asyncNetworkingEvent.gml"), "gml_Object_o_twitch_connection_Other_68");
        UndertaleGameObject.Event asyncNetworking = new();
        asyncNetworking.EventSubtypeOther = EventSubtypeOther.AsyncNetworking;
        asyncNetworking.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = ModLoader.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Other_68")
        });
        o_twitch_connection.Events[7].Add(asyncNetworking);
    }
}
