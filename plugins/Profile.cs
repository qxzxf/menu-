 /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */  using System; using Oxide.Game.Rust.Cui; using Oxide.Core.Plugins; using UnityEngine; using System.Linq; using System.Collections.Generic; using System.Reflection; using Oxide.Core; using Oxide.Core.Configuration; using UnityEngine; namespace Oxide.Plugins { [Info("Profile", "anfunny", "2.0")] class Profile : RustPlugin { [PluginReference] private Plugin Promocode, ImageLibrary, VipRemainInfo, Grant, VKBot; public string CXHXVBLKCJWEMVGGIWNFVHUEEMEWBYAHGVPDQIFSBPOKFQZ = "ProfileMenu_UI"; DynamicConfigFile WCNICPYUDDSJXOIDIOXQGCQZQUDFSJYOMMZZLSFRXUAMQWV = Interface.Oxide.DataFileSystem.GetFile("Profile/Users"); Dictionary<ulong, string> HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA; void OnServerInitialized() { LoadData(); AFHMIFCBAYMMLSOXZWMIZXCYZGLPCCIHQMYRSCVPGHUWDIVV(); BasePlayer.activePlayerList.ToList().ForEach(OnPlayerConnected); 
            if (ImageLibrary == null) 
                return; 
          
        } 
        void OnPlayerConnected(BasePlayer BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU) { if (BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.IsReceivingSnapshot) { timer.In(2f, () => OnPlayerConnected(BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU)); return; } if (HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA.ContainsKey(BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.userID)) return; var FESGIMAKYXSMHLQASIDYHVUUMWHSLIWTPKBOSVVXTORAOUAKN = DateTime.Now.ToString("yyyy-MM-dd"); HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA[BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.userID] = FESGIMAKYXSMHLQASIDYHVUUMWHSLIWTPKBOSVVXTORAOUAKN; return; } void LoadData() { HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA = WCNICPYUDDSJXOIDIOXQGCQZQUDFSJYOMMZZLSFRXUAMQWV.ReadObject<Dictionary<ulong, string>>() ?? new Dictionary<ulong, string>(); } void SaveData() { WCNICPYUDDSJXOIDIOXQGCQZQUDFSJYOMMZZLSFRXUAMQWV.WriteObject(HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA); } void OnServerSave() => SaveData(); void Unload() => SaveData(); void Load() => SaveData(); void ProfileMenu(BasePlayer BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU) { string NDUBQJKYTLEHZQBYXWKBHWNFFTETFSVWFMVSZNUREUBJTMPBZ = HLCQSJMUMNSHLSCTEEWLOJSPJGSLCDJTZPYHGIWDZFMYA[BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.userID]; string WDALRQQOWXEQSAPHCNUIZJCSXNUEMSEDUPWSWTVECKRXMO = BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.displayName.ToString(); string ATLJBGQQNBHODVLBDSAWCEXLJRQGOSFGJKUKBJCX = BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.userID.ToString(); CuiHelper.DestroyUi(BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU, CXHXVBLKCJWEMVGGIWNFVHUEEMEWBYAHGVPDQIFSBPOKFQZ); var ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH = new CuiElementContainer(); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "MS_UI", Name = CXHXVBLKCJWEMVGGIWNFVHUEEMEWBYAHGVPDQIFSBPOKFQZ, Components = { new CuiImageComponent { Color = "0 0 0 0" }, new CuiRectTransformComponent{ AnchorMin = "0 0", AnchorMax = "1 0.9", OffsetMin = "172 0", OffsetMax = "0 0" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" }, Image = { Color = "0.1 0.1 0.1 0" } }, CXHXVBLKCJWEMVGGIWNFVHUEEMEWBYAHGVPDQIFSBPOKFQZ, "Background"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "1 0.1", AnchorMax = "1 0.9", OffsetMin = "-400 0", OffsetMax = "-50 0" }, Image = { Color = "0.1 0.1 0.1 0" } }, "Background", "MainProfile"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "MainProfile", Name = "AvatarLower", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.UserIDString), Color = "1 1 1 1" }, new CuiRectTransformComponent { AnchorMin = "0.5 0.5",  AnchorMax = "0.5 0.5", OffsetMin = "-175 -70", OffsetMax = "175 180" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" }, Image = { Color = "0 0 0 0", Material = "assets/content/ui/uibackgroundblur.mat" } }, "AvatarLower"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" }, Image = { Color = "0.23 0.20 0.13 0.3", Sprite = "assets/content/ui/ui.background.transparent.radial.psd" } }, "AvatarLower"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" }, Image = { Color = "0.20 0.17 0.13 0.7", Sprite = "assets/content/ui/ui.background.transparent.radial.psd" } }, "AvatarLower"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1" }, Image = { Color = "0.20 0.17 0.22 0.7", Sprite = "assets/content/ui/ui.background.transparent.radial.psd" } }, "AvatarLower"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "MainProfile", Name = "ProfileBlur", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ProfileBlur"), Color = "1 1 1 0.5" }, new CuiRectTransformComponent{ AnchorMin = "0 0", AnchorMax = "1 1" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "ProfileBlur", Components = { new CuiTextComponent { Text = lang.GetMessage("PROFILE", this, BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.UserIDString), Color = "1 1 1 1", Align = TextAnchor.MiddleLeft, Font = "robotocondensed-bold.ttf", FontSize = 18 }, new CuiRectTransformComponent{ AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "15 -90", OffsetMax = "200 -60" }, new CuiOutlineComponent { Color = "0 0 0 0.6", Distance = "-0.4 0.4" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "ProfileBlur", Components = { new CuiTextComponent { Text = lang.GetMessage("PROFILE_STATUS", this, BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.UserIDString), Color = "0.75 0.75 0.75 1.00", Align = TextAnchor.MiddleLeft, Font = "robotocondensed-regular.ttf", FontSize = 14 }, new CuiRectTransformComponent{ AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "15 -120", OffsetMax = "200 -90" }, new CuiOutlineComponent { Color = "0 0 0 0.6", Distance = "-0.4 0.4" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "ProfileBlur", Components = { new CuiTextComponent { Text = string.Format(lang.GetMessage("PROFILE_REG", this, BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.UserIDString), NDUBQJKYTLEHZQBYXWKBHWNFFTETFSVWFMVSZNUREUBJTMPBZ), Color = "0.75 0.75 0.75 1.00", Align = TextAnchor.MiddleLeft, Font = "robotocondensed-regular.ttf", FontSize = 14 }, new CuiRectTransformComponent{ AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "15 -140", OffsetMax = "200 -110" }, new CuiOutlineComponent { Color = "0 0 0 0.6", Distance = "-0.4 0.4" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "MainProfile", Name = "AvatarUpper", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU.UserIDString) }, new CuiRectTransformComponent { AnchorMin = "0.5 0.5",  AnchorMax = "0.5 0.5", OffsetMin = "-50 -50", OffsetMax = "50 50" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0.09 0.25", AnchorMax = "0.45 0.25" }, Image = { Color = "0.7 0.7 0.7 0.3" } }, "MainProfile", "Input_1"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "Input_1", Components = { new CuiInputFieldComponent { Text = WDALRQQOWXEQSAPHCNUIZJCSXNUEMSEDUPWSWTVECKRXMO, FontSize = 14, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1", ReadOnly = true, NeedsKeyboard = true}, new CuiRectTransformComponent { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 20", OffsetMin = "0 2.5" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "Input_1", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ProfileUser"), Color = "0.7 0.7 0.7 0.7" }, new CuiRectTransformComponent { AnchorMin = "0.5 0.5",  AnchorMax = "0.5 0.5", OffsetMin = "-7 -17", OffsetMax = "7 -5" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiPanel { RectTransform = { AnchorMin = "0.56 0.25", AnchorMax = "0.91 0.25" }, Image = { Color = "0.7 0.7 0.7 0.3" } }, "MainProfile", "Input_2"); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "Input_2", Components = { new CuiInputFieldComponent { Text = ATLJBGQQNBHODVLBDSAWCEXLJRQGOSFGJKUKBJCX, FontSize = 14, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1", ReadOnly = true, NeedsKeyboard = true}, new CuiRectTransformComponent { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 20", OffsetMin = "0 2.5" } } }); ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH.Add(new CuiElement { Parent = "Input_2", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ProfileSteam"), Color = "0.7 0.7 0.7 0.7" }, new CuiRectTransformComponent { AnchorMin = "0.5 0.5",  AnchorMax = "0.5 0.5", OffsetMin = "-7 -17", OffsetMax = "7 -5" } } }); CuiHelper.AddUi(BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU, ZIQOERIQINELRZWVAAKQKBUWBFTBBAUQDTDVHWEAH); if (Promocode != null) { Promocode.Call("PromoMenu", BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU); } if (Grant != null && VipRemainInfo != null) { VipRemainInfo.Call("ShowRemainVipInfo", BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU, false); } if (VKBot != null) { VKBot.Call("VkMain", BNHFOXISUZOFZYTALUFXAPRBYGBUNZRTBULODJVEPU); } } private void AFHMIFCBAYMMLSOXZWMIZXCYZGLPCCIHQMYRSCVPGHUWDIVV() { lang.RegisterMessages(new Dictionary<string, string> { {"PROFILE", "My profile"}, {"PROFILE_STATUS", "Status: <color=green>Online</color>"}, {"PROFILE_REG", "Registration: {0}"}, }, this); lang.RegisterMessages(new Dictionary<string, string> { {"PROFILE", "Мой профиль"}, {"PROFILE_STATUS", "Статус: <color=green>Онлайн</color>"}, {"PROFILE_REG", "Регистрация: {0}"}, }, this, "ru"); } } }