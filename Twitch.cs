using ModShardLauncher;
using ModShardLauncher.Mods;
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
        Msl.AddFunction(ModFiles.GetCode("format.gml"), "format");
        Msl.AddFunction(ModFiles.GetCode("twitch_send_raw.gml"), "twitch_send_raw");
        Msl.AddFunction(ModFiles.GetCode("console_log.gml"), "console_log");
        Msl.AddFunction(ModFiles.GetCode("example_command.gml"), "example_command");
        Msl.AddFunction(ModFiles.GetCode("twitch_send_response.gml"), "twitch_send_response");
        Msl.AddFunction(ModFiles.GetCode("twitch_commands.gml"), "twitch_commands");
        Msl.AddFunction(ModFiles.GetCode("twitch_handle_data.gml"), "twitch_handle_data");
        Msl.AddFunction(ModFiles.GetCode("twitch_chat_async.gml"), "twitch_chat_async");
        Msl.AddFunction(ModFiles.GetCode("twitch_send_msg.gml"), "twitch_send_msg");
        Msl.AddFunction(ModFiles.GetCode("twitch_chat_connect.gml"), "twitch_chat_connect");
        Msl.AddFunction(ModFiles.GetCode("twitch_chat_disconnect.gml"), "twitch_chat_disconnect");
        Msl.AddFunction(ModFiles.GetCode("twitch_config.gml"), "twitch_config");
        Msl.AddFunction(ModFiles.GetCode("twitch_init.gml"), "twitch_init");
    }

    /// <summary>
    /// Initializes the object responsible for creating and maintaining the connection to twitch.
    /// </summary>
    public void InitTwitchObject()
    {
        // Creating o_twitch_connection Object
        UndertaleGameObject o_twitch_connection = Msl.AddObject("o_twitch_connection");
        o_twitch_connection.Persistent = true;
        
        
        // Making o_twitch_connection really persistent
        Msl.InsertGMLString(ModFiles.GetCode("sessionDataInit.gml"), "gml_GlobalScript_scr_sessionDataInit", 51);
        Msl.InsertGMLString(ModFiles.GetCode("persistentRoomController.gml"), "gml_Object_persistentRoomController_Other_11", 19);
        
        
        // Create Event
        Msl.AddCode(ModFiles.GetCode("createEvent.gml"), "gml_Object_o_twitch_connection_Create_0");
        UndertaleGameObject.Event create = new();
        create.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = Msl.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Create_0")
        });
        o_twitch_connection.Events[0].Add(create);
        
        
        // Alarm 0 Event
        Msl.AddCode(ModFiles.GetCode("alarm0Event.gml"), "gml_Object_o_twitch_connection_Alarm_0");
        UndertaleGameObject.Event alarm0 = new();
        alarm0.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = Msl.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Alarm_0")
        });
        o_twitch_connection.Events[2].Add(alarm0);
        
        
        // CleanUp Event
        Msl.AddCode(ModFiles.GetCode("cleanUpEvent.gml"), "gml_Object_o_twitch_connection_CleanUp_0");
        UndertaleGameObject.Event cleanUp = new();
        cleanUp.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = Msl.GetUMTCodeFromFile("gml_Object_o_twitch_connection_CleanUp_0")
        });
        o_twitch_connection.Events[12].Add(cleanUp);
        

        // Async Networking Event
        Msl.AddCode(ModFiles.GetCode("asyncNetworkingEvent.gml"), "gml_Object_o_twitch_connection_Other_68");
        UndertaleGameObject.Event asyncNetworking = new();
        asyncNetworking.EventSubtypeOther = EventSubtypeOther.AsyncNetworking;
        asyncNetworking.Actions.Add(new UndertaleGameObject.EventAction()
        {
            CodeId = Msl.GetUMTCodeFromFile("gml_Object_o_twitch_connection_Other_68")
        });
        o_twitch_connection.Events[7].Add(asyncNetworking);
    }
}
