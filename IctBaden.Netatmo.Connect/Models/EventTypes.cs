namespace IctBaden.Netatmo.Connect.Models
{
    public class EventTypes
    {
        public const string Person = "person";                  // Event triggered when Welcome detects a face
        public const string Animal = "animal";                  // Event triggered when Welcome detects an animal
        public const string PersonAway = "person_away";         // Event triggered when geofencing implies the person has left the home
        public const string Movement = "movement";              // Event triggered when Welcome detects a motion
        public const string Outdoor = "outdoor";                // Event triggered when Presence detects a human, a car or an animal
        public const string Connection = "connection";          // When the camera connects to Netatmo servers
        public const string Disconnection = "disconnection";    // When the camera loses connection to Netatmo servers
        public const string On = "on";                          // Whenever monitoring is activated
        public const string Off = "off";                        // Whenever monitoring is suspended
        public const string Boot = "boot";                      // When the camera is booting
        // ReSharper disable once InconsistentNaming
        public const string SD = "sd";                          // Event triggered by the SD card status change
        public const string Alim = "alim";                      // Event triggered by the power supply status change
        public const string DailySummary = "daily_summary";             // Event triggered when the video summary of the last 24 hours is available
        public const string NewModule = "new_module";                   // A new module has been paired with Welcome
        public const string ModuleConnect = "module_connect";           // Module is connected with Welcome(after disconnection)
        public const string ModuleDisconnect = "module_disconnect";     // Module lost its connection with Welcome
        public const string ModuleLowBattery = "module_low_battery";    // Module's battery is low
        public const string ModuleEndUpdate = "module_end_update";      // Module's firmware update is over
        public const string TagBigMove = "tag_big_move";                // Tag detected a big move
        public const string TagSmallMove = "tag_small_move";            // Tag detected a small move
        public const string TagUninstalled = "tag_uninstalled";         // Tag was uninstalled
        public const string TagOpen = "tag_open";                       // Tag detected the door/window was left open
    }
}