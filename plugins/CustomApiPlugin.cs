using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Rust;
using System;
using System.Linq;
using ru = Oxide.Game.Rust;
using Newtonsoft.Json.Linq;
namespace Oxide.Plugins
{
    /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ [Info("CustomApiPlugin", "https://discord.gg/k3hXsVua7Q", "1.0.0")]
    class CustomApiPlugin : RustPlugin
    {
        public Dictionary<string, string> MenuImage = new Dictionary<string, string>  {
            { "WorkbenchImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599052888092812/WorkbenchImage.png"},
            { "LogoImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139974605319192698/Rust_Logo_video_game_-_PNG_Logo_Vector_Downloads_SVG_EPS.png"},
            { "RankImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599071733092535/RankImage.png" },
            { "SkillImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599064221106290/SkillImage.png"},
            { "MainImage", "https://img.freepik.com/free-photo/abstract-luxury-black-gradient-with-border-black-vignette-background-studio-backdrop-well-use-as-back-drop-background-black-board-black-studio-background-black-gradient-frame_1258-180.jpg?w=1380&t=st=1691781620~exp=1691782220~hmac=9a0f6984589103735e9d6b8cb45c73512b3dc03fa0eb26756f2c61553a21b38d"},
            { "ExitImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599111667073104/ExitImage.png"},
            { "ButtonImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599206638698557/ButtonImage.png"},
            { "PanelButtonsImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599097028947978/PanelButtonsImage.png"},
            { "ActiveButtonImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599260732625066/ActiveButtonImage.png"},
            { "BlockButtonImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599239991799929/BlockButtonImage.png"},
            { "BattlepassImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599249433169931/BattlepassImage.png"},
            { "UnderInfoImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599086836789348/UnderInfoImage.png"},
            { "btn_ctg", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599228600057956/btn_ctg.png"},
            { "btn_panel_width", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599214939226254/btn_panel_width.png"},
            { "skin_height", "https://cdn.discordapp.com/attachments/1139598345682305164/1139599273269407905/skin_height.png" }
        };

        public Dictionary<string, string> IQChatImage = new Dictionary<string, string>()
        {
            { "UI_IQCHAT_CONTEXT_NO_RANK", "https://cdn.discordapp.com/attachments/1139598345682305164/1139613355221463120/UI_IQCHAT_CONTEXT_NO_RANK.png"},
            { "UI_IQCHAT_CONTEXT_RANK", "https://cdn.discordapp.com/attachments/1139598345682305164/1139615528281985054/UI_IQCHAT_CONTEXT_RANK.png"},
            { "IQCHAT_INFORMATION_ICON","https://cdn.discordapp.com/attachments/1139598345682305164/1139615664672362586/IQCHAT_INFORMATION_ICON.png" },
            { "IQCHAT_SETTING_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139615728757133322/IQCHAT_SETTING_ICON.png" },
            { "IQCHAT_MULTIPLE_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139615807698112684/IQCHAT_MULTIPLE_ICON.png" },
            { "IQCHAT_PANEL_BACKGROUND", "https://cdn.discordapp.com/attachments/1139598345682305164/1139615941169258536/IQCHAT_PANEL_BACKGROUND.png"},
            { "IQCHAT_MULTIPLE_PANEL_BACKGROUND", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616038795890799/IQCHAT_MULTIPLE_PANEL_BACKGROUND.png"},
            { "IQCHAT_IGNORE_INFO_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616366115180614/IQCHAT_IGNORE_INFO_ICON.png"},
            { "IQCHAT_MODERATION_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616138418995362/IQCHAT_MODERATION_ICON.png"},
            { "IQCHAT_ELEMENT_PANEL_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616735960518706/IQCHAT_ELEMENT_PANEL_ICON.png"},
            { "IQCHAT_ELEMENT_PREFIX_MULTI_TAKE_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616892949110876/IQCHAT_ELEMENT_PREFIX_MULTI_TAKE_ICON.png"},
            { "IQCHAT_ELEMENT_SLIDER_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139616983634169957/IQCHAT_ELEMENT_SLIDER_ICON.png"},
            { "IQCHAT_ELEMENT_SLIDER_LEFT_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617073706844191/IQCHAT_ELEMENT_SLIDER_LEFT_ICON.png"},
            { "IQCHAT_ELEMENT_SLIDER_RIGHT_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617206410432553/IQCHAT_ELEMENT_SLIDER_RIGHT_ICON.png"},
            { "IQCHAT_ELEMENT_DROP_LIST_OPEN_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617314753482824/IQCHAT_ELEMENT_DROP_LIST_OPEN_ICON.png"},
            { "IQCHAT_ELEMENT_DROP_LIST_OPEN_ARGUMENT_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617422622609520/IQCHAT_ELEMENT_DROP_LIST_OPEN_ARGUMENT_ICON.png"},
            { "IQCHAT_ELEMENT_DROP_LIST_OPEN_TAKED", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617556055986227/IQCHAT_ELEMENT_DROP_LIST_OPEN_TAKED.png"},
            { "IQCHAT_ELEMENT_SETTING_CHECK_BOX", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617668769534063/IQCHAT_ELEMENT_SETTING_CHECK_BOX.png"},
            { "IQCHAT_ALERT_PANEL", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617804191023195/IQCHAT_ALERT_PANEL.png"},
            { "IQCHAT_MUTE_AND_IGNORE_PANEL", "https://cdn.discordapp.com/attachments/1139598345682305164/1139617951436243004/IQCHAT_MUTE_AND_IGNORE_PANEL.png"},
            { "IQCHAT_MUTE_AND_IGNORE_SEARCH", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618093413437450/IQCHAT_MUTE_AND_IGNORE_SEARCH.png"},
            { "IQCHAT_MUTE_AND_IGNORE_PAGE_PANEL", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618178033537144/IQCHAT_MUTE_AND_IGNORE_PAGE_PANEL.png"},
            { "IQCHAT_MUTE_AND_IGNORE_PLAYER", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618303590027345/IQCHAT_MUTE_AND_IGNORE_PLAYER.png"},
            { "IQCHAT_MUTE_AND_IGNORE_PLAYER_STATUS", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618360821289040/IQCHAT_MUTE_AND_IGNORE_PLAYER_STATUS.png"},
            { "IQCHAT_IGNORE_ALERT_PANEL", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618454614323301/IQCHAT_IGNORE_ALERT_PANEL.png"},
            { "IQCHAT_IGNORE_ALERT_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618560696647750/IQCHAT_IGNORE_ALERT_ICON.png"},
            { "IQCHAT_IGNORE_ALERT_BUTTON_YES", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618656779780146/IQCHAT_IGNORE_ALERT_BUTTON_YES.png"},
            { "IQCHAT_IGNORE_ALERT_BUTTON_NO", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618741135605900/IQCHAT_IGNORE_ALERT_BUTTON_NO.png"},
            { "IQCHAT_MUTE_ALERT_PANEL", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618839349428335/IQCHAT_MUTE_ALERT_PANEL.png"},
            { "IQCHAT_MUTE_ALERT_ICON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139618970199130164/IQCHAT_MUTE_ALERT_ICON.png"},
            { "IQCHAT_MUTE_ALERT_PANEL_REASON", "https://cdn.discordapp.com/attachments/1139598345682305164/1139619062272508066/IQCHAT_MUTE_ALERT_PANEL_REASON.png"},
        };

        public Dictionary<string, string> XDStatistics = new Dictionary<string, string> {
            { "BarrelImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622430114062346/BarrelImage.png" },
            { "AnimalImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622361251979405/AnimalImage.png" },
            { "NpcImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622682292404374/NpcImage.png" },
            { "CrateImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622555821547601/CrateImage.png" },
            { "HeliImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622626793369702/HeliImage.png" },
            { "BradleyImage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139622495381631097/BradleyImage.png" }
        };

        public Dictionary<string, string> Profile = new Dictionary<string, string>()
        {
            { "ProfileBlur", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623534667243641/ProfileBlur.png" },
            { "ProfileVk", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623623561318400/ProfileVk.png" },
            { "ProfileGift", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623692649893989/ProfileGift.png" },
            { "ProfileAlert", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623762279546972/ProfileAlert.png" },
            { "ProfileLine", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623820131569754/ProfileLine.png" },
            { "BgrndVk", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623872874946691/BgrndVk.png" },
            { "ProfileSteam", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623918957768804/ProfileSteam.png" },
            { "ProfileUser", "https://cdn.discordapp.com/attachments/1139598345682305164/1139623985324232844/ProfileUser.png" },
            { "RightPage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139624043985772586/RightPage.png" },
            { "LeftPage", "https://cdn.discordapp.com/attachments/1139598345682305164/1139624098243285052/LeftPage.png" },
            { "BgrndPrivileges", "https://cdn.discordapp.com/attachments/1139598345682305164/1139624244876161177/BgrndPrivileges.png" },
            { "ImageButton", "https://media.discordapp.net/attachments/1139598345682305164/1139623872874946691/BgrndVk.png" },
            ////ImageLibrary?.Call("AddImage", path + "Profile" + "https://api-methods.st8.ru/v2/profile/promo", path + "Profile" + "ImageButton.png");
            //
        };

        private void OnServerInitialized()
        {
            Puts("    ");
            new ImageLibrary(plugins.Find("ImageLibrary"));

            foreach(var image in MenuImage)
                if (!ImageLibrary.Instance.HasImage(image.Key) && !string.IsNullOrEmpty(image.Key))
                    ImageLibrary.Instance.AddImage(image.Value, image.Key);

            foreach(var image in IQChatImage)
                if (!ImageLibrary.Instance.HasImage(image.Key) && !string.IsNullOrEmpty(image.Key))
                    ImageLibrary.Instance.AddImage(image.Value, image.Key);

            foreach(var image in XDStatistics)
                if (!ImageLibrary.Instance.HasImage(image.Key) && !string.IsNullOrEmpty(image.Key))
                    ImageLibrary.Instance.AddImage(image.Value, image.Key);
            
            foreach(var image in Profile)
                if (!ImageLibrary.Instance.HasImage(image.Key) && !string.IsNullOrEmpty(image.Key))
                    ImageLibrary.Instance.AddImage(image.Value, image.Key);
        }


        private class ImageLibrary : PluginSigleton<ImageLibrary>
        {
            public ImageLibrary(Plugin plugin) : base(plugin) { }

            public string GetImage(string shortname, ulong skin = 0) =>
                (string)Plugin.Call("GetImage", shortname, skin);

            public bool AddImage(string url, string shortname, ulong skin = 0) =>
                (bool)Plugin.Call("AddImage", url, shortname, skin);

            public bool HasImage(string imageName, ulong imageId = 0) => (bool)Plugin.Call("HasImage", imageName, imageId);
        }

        #region Sigleton.cs
        public abstract class PluginSigleton<T> : Sigleton<T> where T : PluginSigleton<T>
        {
            public Plugin Plugin { get; private set; }
            public PluginSigleton(Plugin plugin)
            {
                Plugin = plugin;
            }
        }

        public abstract class Sigleton<T> where T : Sigleton<T>
        {
            public static T Instance;

            public Sigleton()
            {
                Instance = (T)this;
            }
        }
        #endregion
    }
}