/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ using Epic.OnlineServices.Ecom;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
namespace Oxide.Plugins
{
    [Info("Kits", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class Kits : RustPlugin
    {
        [PluginReference] Plugin ImageLibrary, MenuSystem;
        static Kits ins;
        private PluginConfig config;
        private List<Kit> kitsList;
        private Dictionary<ulong, Dictionary<string, KitData>> PlayersData;
        private Dictionary<BasePlayer, List<Kit>> CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF = new Dictionary<BasePlayer, List<Kit>>();
        public List<BasePlayer> UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA = new List<BasePlayer>();
        private class RarityColor
        {
            [JsonProperty("Шанс выпадения предмета данной редкости")] public int LCNYMPNUZHNPYGKUCYYYBKCBMPCGUXSHBYJHQHYDZEB;
            [JsonProperty("Цвет этой редкости в интерфейсе")] public string Color;
            public RarityColor(int chance, string color)
            {
                LCNYMPNUZHNPYGKUCYYYBKCBMPCGUXSHBYJHQHYDZEB = chance;
                Color = color;
            }
        }
        class PluginConfig
        {
            [JsonProperty("Настройка интерфейса")] public InterfaceSettings InterfaceSetting = new InterfaceSettings();
            internal class InterfaceSettings
            {
                [JsonProperty("Показывать в меню недоступные киты?(кроме скрытых)")] public bool CDGSBQQIDCHBZLLWMGABOGOAXDDVZUYWJPZJJJFEHJDZR;
            }
            [JsonProperty("Префикс чата | Chat Prefix")]
            public string DefaultPrefix
            {
                get;
                set;
            }
            [JsonProperty("Кастомные автокиты по привилегии (Привилегию устанавливаете в настройке кита) | Custom autokit, install privilege in the configuration of the kit")] public List<string> IFVCRSEZYVPGVXMVJIDKRKLCMCAVUEDOJPUXZXDGSJQ;
            [JsonProperty("Настройка цвета предмета по шансу")] public List<RarityColor> TCOHRLAUWGQYUTPORIEUSAXGDOVLFXSHTHJKOTDIE = new List<RarityColor>();
            [JsonProperty("Версия конфигурации | Configuration Version")] public VersionNumber PluginVersion = new VersionNumber();
            public static PluginConfig CreateDefault()
            {
                return new PluginConfig
                {
                    InterfaceSetting = new InterfaceSettings()
                    {
                        CDGSBQQIDCHBZLLWMGABOGOAXDDVZUYWJPZJJJFEHJDZR = true
                    },
                    DefaultPrefix = "<color=#F65050FF>[KITS]</color>",
                    IFVCRSEZYVPGVXMVJIDKRKLCMCAVUEDOJPUXZXDGSJQ = new List<string>() {
            "autokit1",
            "autokit2"
          },
                    PluginVersion = new VersionNumber(),
                    TCOHRLAUWGQYUTPORIEUSAXGDOVLFXSHTHJKOTDIE = new List<RarityColor> {
            new RarityColor(40, "1.00 1.00 1.00 1"),
            new RarityColor(30, "0.68 0.87 1.00 1"),
            new RarityColor(20, "0.77 0.65 1.00 1"),
            new RarityColor(10, "1.00 0.48 0.17 1"),
          },
                };
            }
            [JsonIgnore][JsonProperty("Server Initialized???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????")] public bool SCYWDFHPOJFWLSFHEDPPOYOIEMJFZYFVPJIUHGKQDQJ;
        }
        public class Kit
        {
            public string Name
            {
                get;
                set;
            }
            public string DisplayName
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
            public double Cooldown
            {
                get;
                set;
            }
            public bool Hide
            {
                get;
                set;
            }
            public string Permission
            {
                get;
                set;
            }
            public bool UseImageURL
            {
                get;
                set;
            }
            public string ImageURL
            {
                get;
                set;
            }
            public string Color
            {
                get;
                set;
            }
            public List<KitItem> Items
            {
                get;
                set;
            }
        }
        public class KitItem
        {
            public string ShortName
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
            public int Blueprint
            {
                get;
                set;
            }
            public ulong SkinID
            {
                get;
                set;
            }
            public string Container
            {
                get;
                set;
            }
            public float Condition
            {
                get;
                set;
            }
            public int Change
            {
                get;
                set;
            }
            public bool EnableCommand
            {
                get;
                set;
            }
            [JsonProperty("Command (Player identifier %STEAMID%)")]
            public string Command
            {
                get;
                set;
            }
            public string CustomImage
            {
                get;
                set;
            }
            public Weapon Weapon
            {
                get;
                set;
            }
            public List<ItemContent> Content
            {
                get;
                set;
            }
        }
        public class Weapon
        {
            public string ammoType
            {
                get;
                set;
            }
            public int ammoAmount
            {
                get;
                set;
            }
        }
        public class ItemContent
        {
            public string ShortName
            {
                get;
                set;
            }
            public float Condition
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
        }
        public class KitData
        {
            public int Amount
            {
                get;
                set;
            }
            public double Cooldown
            {
                get;
                set;
            }
        }
        public class Position
        {
            public string AnchorMin
            {
                get;
                set;
            }
            public string AnchorMax
            {
                get;
                set;
            }
        }
        protected override void LoadDefaultConfig()
        {
            Config.Clear();
            Config.WriteObject(PluginConfig.CreateDefault(), true);
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            config = Config.ReadObject<PluginConfig>();
            if (config.PluginVersion < Version) UpdateConfigValues();
            Config.WriteObject(config, true);
        }
        private void UpdateConfigValues()
        {
            PluginConfig baseConfig = PluginConfig.CreateDefault();
            if (config.PluginVersion < Version)
            {
                PrintWarning("Config update detected! Updating config values...");
                PrintWarning("Config update completed!");
            }
            config.PluginVersion = Version;
        }
        void OnPlayerRespawned(BasePlayer player)
        {
            foreach (var kits in config.IFVCRSEZYVPGVXMVJIDKRKLCMCAVUEDOJPUXZXDGSJQ)
            {
                if (kitsList.Exists(x => x.Name == kits))
                {
                    var kit1 = kitsList.First(x => x.Name.ToLower() == kits.ToLower());
                    if (permission.UserHasPermission(player.UserIDString, kit1.Permission))
                    {
                        player.inventory.Strip();
                        GiveItems(player, kit1);
                        return;
                    }
                }
            }
            if (kitsList.Exists(x => x.Name.ToLower() == "autokit"))
            {
                player.inventory.Strip();
                var kit = kitsList.First(x => x.Name.ToLower() == "autokit");
                GiveItems(player, kit);
            }
        }
        private void SaveKits()
        {
            Interface.Oxide.DataFileSystem.WriteObject("Kits/KitsList", kitsList);
        }
        private void SaveData()
        {
            if (PlayersData != null) Interface.Oxide.DataFileSystem.WriteObject("Kits/PlayersData", PlayersData);
        }
        void OnServerSave()
        {
            SaveData();
            SaveKits();
        }
        private void LoadMessages()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Kit Was Removed"] = "{Prefix} Kit {kitname} was removed",
                ["Kit Doesn't Exist"] = "{Prefix} This kit doesn't exist",
                ["Not Found Player"] = "{Prefix} Player not found",
                ["To Many Player"] = "{Prefix} Found multipy players",
                ["Permission Denied"] = "{Prefix} Access denied",
                ["Limite Denied"] = "{Prefix} Useage limite reached",
                ["Cooldown Denied"] = "{Prefix} You will be able to use this kit after {time}",
                ["Reset"] = "{Prefix} Kits data wiped",
                ["Kit Already Exist"] = "{Prefix} Kit with the same name already exist",
                ["Kit Created"] = "{Prefix} You have created a new kit - {name}",
                ["Kit Extradited"] = "{Prefix} You have claimed kit - {kitname}",
                ["Kit Cloned"] = "{Prefix} You inventory was copyed to the kit",
                ["UI Amount"] = "<b>Timeleft: {amount}</b>",
                ["UI GIVE"] = "RECEIVE",
                ["UI UNAVAILABLE"] = "UNAVAILABLE",
                ["PAGE"] = "PAGE:",
                ["INFO BACK"] = "BACK",
                ["INFO INSIDE"] = "ITEMS INSIDE:",
                ["Help"] = "/kit name|add|clone|remove|list|reset",
                ["Help Add"] = "/kit add <kitname>",
                ["Help Clone"] = "/kit clone <kitname>",
                ["Help Remove"] = "/kit remove <kitname>",
                ["Help Give"] = "/kit give <kitname> <playerName|steamID>",
                ["Give Succes"] = "You have successfully given the player {0} a set {1}",
                ["No Space"] = "Can't redeem kit. Not enought space",
                ["UI Admin ON"] = "DISPLAY ALL KITS",
                ["UI No Available"] = "There are no available ktis for you.",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Kit Was Removed"] = "{Prefix} {kitname} был удалён",
                ["Kit Doesn't Exist"] = "{Prefix} Этого комплекта не существует",
                ["Not Found Player"] = "{Prefix} Игрок не найден",
                ["To Many Player"] = "{Prefix} Найдено несколько игроков",
                ["Permission Denied"] = "{Prefix} У вас нет полномочий использовать этот комплект",
                ["Limite Denied"] = "{Prefix} Вы уже использовали этот комплект максимальное количество раз",
                ["Cooldown Denied"] = "{Prefix} Вы сможете использовать этот комплект через {time}",
                ["Reset"] = "{Prefix} Вы обнулили все данные о использовании комплектов игроков",
                ["Kit Already Exist"] = "{Prefix} Этот набор уже существует",
                ["Kit Created"] = "{Prefix} Вы создали новый набор - {name}",
                ["Kit Extradited"] = "{Prefix} Вы получили комплект {kitname}",
                ["Kit Cloned"] = "{Prefix} Предметы были скопированы из инвентаря в набор",
                ["UI Amount"] = "<b>Осталось: {amount}</b>",
                ["UI GIVE"] = "ПОЛУЧИТЬ",
                ["UI UNAVAILABLE"] = "НЕДОСТУПНО",
                ["PAGE"] = "СТРАНИЦА:",
                ["INFO BACK"] = "НАЗАД",
                ["INFO INSIDE"] = "ПРЕДМЕТЫ ВНУТРИ:",
                ["Help"] = "/kit name|add|clone|remove|list|reset",
                ["Help Add"] = "/kit add <kitname>",
                ["Help Clone"] = "/kit clone <kitname>",
                ["Help Remove"] = "/kit remove <kitname>",
                ["Help Give"] = "/kit give <kitname> <playerName|steamID>",
                ["Give Succes"] = "Вы успешно выдали игрок {0} набор {1}",
                ["No Space"] = "Невозможно получить набор - недостаточно места в инвентаре",
                ["UI Admin ON"] = "ОТОБРАЗИТЬ ВСЕ НАБОРЫ",
                ["UI No Available"] = "Для Вас нет доступных наборов.",
            }, this, "ru");
        }
        private void Loaded()
        {
            config = Config.ReadObject<PluginConfig>();
            LoadData();
            LoadMessages();
        }
        void LoadData()
        {
            try
            {
                kitsList = Interface.Oxide.DataFileSystem.ReadObject<List<Kit>>("Kits/KitsList");
                PlayersData = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, Dictionary<string, KitData>>>("Kits/PlayersData");
            }
            catch
            {
                kitsList = new List<Kit>();
                PlayersData = new Dictionary<ulong, Dictionary<string, KitData>>();
            }
            JVVMGVICUTBQCSPCVQSSLNLIRBBFMQBJSVHNJPQNGKPLXJ();
        }
        private void Unload()
        {
            SaveData();
            BasePlayer.activePlayerList.ToList().ForEach(DestroyUI);
        }
        public bool AddImage(string url, string name, ulong skin) => (bool)ImageLibrary?.Call("AddImage", url, name, skin);
        public string UZZKIFPJXHXMBHZWQGQDZMXEQHPNRIFCWIPNJEYZCXGLNPXX(string shortname, ulong skin = 0) => (string)ImageLibrary.Call("GetImage", shortname, skin);
        private void OnServerInitialized()
        {
            config.SCYWDFHPOJFWLSFHEDPPOYOIEMJFZYFVPJIUHGKQDQJ = true;
            ins = this;
            foreach (var kit in kitsList)
            {
                if (!permission.PermissionExists(kit.Permission)) permission.RegisterPermission(kit.Permission, this);
            }

            kitsList.ForEach(kit => kit.Items.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item.CustomImage)) ImageLibrary.Call("AddImage", item.CustomImage, item.CustomImage);
            }));
            kitsList.ForEach(kit =>
            {
                ImageLibrary.Call("AddImage", kit.ImageURL, kit.ImageURL);
            });
            timer.Repeat(1, 0, UBRXMOONOXZZGTRMRQGMMMDRPLBECSHFGZDBSVPFMHDN);
        }
        void JVVMGVICUTBQCSPCVQSSLNLIRBBFMQBJSVHNJPQNGKPLXJ()
        {
            kitsList.ForEach(kit =>
            {
                if (kit.Color == null) kit.Color = "0.55 0.68 0.31 0.6";
                kit.Items.ForEach(item =>
                {
                    if (item.Change <= 0) item.Change = 100;
                });
            });
            SaveKits();
        }
        private void OnPlayerDisconnected(BasePlayer player)
        {
            CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF.Remove(player);
        }
        [ConsoleCommand("kits.load")]
        void FRISZFFGWJNVFTCQDSRYHKBSFZFLAYALICWODYCEMPLDWULTE(ConsoleSystem.Arg args)
        {
            if (args.Connection != null && args.Connection.authLevel < 2) return;
            kitsList = Interface.Oxide.DataFileSystem.ReadObject<List<Kit>>("Kits/KitsList");
            if (args.Connection != null) args.Player().ConsoleMessage("Киты загружены с папки data/Kits/KitsList.json");
            else Puts("Киты загружены с папки data/Kits/KitsList.json");
        }
        [ConsoleCommand("kit")]
        private void LSFLRUPPMZZUFYJCNCXONFQNLSZYWLOMGGMHFXKBZNLCESJ(ConsoleSystem.Arg arg)
        {
            if (arg.Connection == null)
            {
                if (arg.Args[0].ToLower() == "give")
                {
                    var target = BasePlayer.Find(arg.Args[1]);
                    var kitname = arg.Args[2];
                    if (target != null) GIUKRREKCRXRPABGMOIGQJLQWEXXZEWHSHOGGJVQPYJN(target, kitname, 0, true);
                    return;
                }
            }
            var player = arg.Player();
            var page = int.Parse(arg.Args[1]);
            if (!arg.HasArgs()) return;
            var CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC = arg.Args[0].ToLower();
            if (CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC == "ui")
            {
                CuiHelper.DestroyUi(player, $"ui.kits.{arg.Args[2]}.info");
                UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(player, page);
                return;
            }
            if (!CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF.ContainsKey(player)) return;
            if (!CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF[player].Contains(kitsList.First(kits => kits.Name.ToLower() == CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC.ToLower()))) return;
            GIUKRREKCRXRPABGMOIGQJLQWEXXZEWHSHOGGJVQPYJN(player, CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC, page);
            var kit = kitsList.First(x => x.Name.ToLower() == CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC.ToLower());
            var playerData = UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(CXVQEGOATOTTNQRQWCPPEJGBKKAXSZLYPFFGRTBSJEC, player.userID);
            if (kit.Amount > 0)
            {
                if (playerData.Amount >= kit.Amount)
                {
                    WZMDXZXYIZIYZIBMJLWQUSHPPTVABZFJQOTLPBETK(player, 0);
                    return;
                }
            }
            if (kit.Cooldown > 0)
            {
                var currentTime = GetCurrentTime();
                if (playerData.Cooldown > currentTime)
                {
                    DestroyUI(player);
                    UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(player, page);
                }
            }
            return;
        }
        [ChatCommand("kit")]
        private void TTHIWQGGCRZZVQTAKNNZLCWPSVOATNITILEDEGQQZGFOX(BasePlayer player, string command, string[] args)
        {
            if (player == null) return;
            if (args.Length == 0)
            {
                MenuSystem?.Call("MS_CustomCMD", player, "kits");
                return;
            }
            if (!player.IsAdmin)
            {
                GIUKRREKCRXRPABGMOIGQJLQWEXXZEWHSHOGGJVQPYJN(player, args[0].ToLower(), 0);
                return;
            }
            switch (args[0].ToLower())
            {
                case "help":
                    SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Help", player));
                    return;
                case "add":
                    if (args.Length < 2) SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Help Add", player));
                    else NQPOTURFRTWWDONUGLXVPYHLUZDSRRSAYKINHJFJFC(player, args[1].ToLower());
                    return;
                case "clone":
                    if (args.Length < 2) SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Help Clone", player));
                    else ORKCUIWJNLRPOIDTTRYNAAWXTFZMWFOQNXTUKXIK(player, args[1].ToLower());
                    return;
                case "remove":
                    if (args.Length < 2) SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Help Remove", player));
                    else IFPHUTEEPLSGOBNVMIPIJMHXBCRPJJWJOSSVHQYLVIHTVJZW(player, args[1].ToLower());
                    return;
                case "list":
                    YXOTBLVYRFSCPVGPJRVJRNWKDNBEOBRCUIKLIQNGWX(player);
                    return;
                case "reset":
                    KGIFNAEMSDNOKAEPOKRJQNPHHKUGSEPNUYMDUHODKOZZH(player);
                    return;
                case "give":
                    if (args.Length < 3)
                    {
                        SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Help Give", player));
                    }
                    else
                    {
                        var foundPlayer = FindPlayer(player, args[1].ToLower());
                        if (foundPlayer == null) return;
                        SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Give Succes", player), foundPlayer.displayName, args[2]);
                        AKEAYVENZWRBYCGXTNOZUMOAUGWNZBOQZOKJCRFTIHZPMTJ(player, foundPlayer, args[2].ToLower());
                    }
                    return;
                default:
                    GIUKRREKCRXRPABGMOIGQJLQWEXXZEWHSHOGGJVQPYJN(player, args[0].ToLower(), 0);
                    return;
            }
        }
        private bool GIUKRREKCRXRPABGMOIGQJLQWEXXZEWHSHOGGJVQPYJN(BasePlayer player, string kitname, int page = -1, bool admin = false)
        {
            if (string.IsNullOrEmpty(kitname)) return false;
            if (Interface.Oxide.CallHook("canRedeemKit", player) != null && page > -1) return false;
            if (!kitsList.Exists(x => x.Name.ToLower() == kitname.ToLower()))
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Doesn't Exist", player));
                return false;
            }
            var kit = kitsList.First(x => x.Name.ToLower() == kitname.ToLower());
            if (!string.IsNullOrEmpty(kit.Permission) && !permission.UserHasPermission(player.UserIDString, kit.Permission) && !admin && page > -1)
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Permission Denied", player));
                return false;
            }
            var playerData = UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(kitname, player.userID);
            if (kit.Amount > 0 && playerData.Amount >= kit.Amount && !admin && page > -1)
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Limite Denied", player));
                return false;
            }
            if (kit.Cooldown > 0 && !admin && page > -1)
            {
                var currentTime = GetCurrentTime();
                if (playerData.Cooldown > currentTime)
                {
                    SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Cooldown Denied", player).Replace("{time}", TimeExtensions.FormatTime(TimeSpan.FromSeconds(playerData.Cooldown - currentTime))));
                    return false;
                }
            }
            int QOHRPTTBATETRTGTGRHTDVEIKKZCBWFZGELWDIIY = kit.Items.Where(i => i.Container == "belt").Count();
            int JXWAMOXNHMSWJXVKYHEURADNFNMIJPXIJNTXHHXWBP = kit.Items.Where(i => i.Container == "wear").Count();
            int KNDWHQMFBDEOJUIVZBPDSOKNWDYCRJITBHTACQFRXKVEFYK = kit.Items.Where(i => i.Container == "main").Count();
            int YMYULMAWCPADSJNSVKNCAISIWYFISFHYTVDEKOHOG = QOHRPTTBATETRTGTGRHTDVEIKKZCBWFZGELWDIIY + JXWAMOXNHMSWJXVKYHEURADNFNMIJPXIJNTXHHXWBP + KNDWHQMFBDEOJUIVZBPDSOKNWDYCRJITBHTACQFRXKVEFYK;
            if ((player.inventory.containerBelt.capacity - player.inventory.containerBelt.itemList.Count) < QOHRPTTBATETRTGTGRHTDVEIKKZCBWFZGELWDIIY || (player.inventory.containerWear.capacity - player.inventory.containerWear.itemList.Count) < JXWAMOXNHMSWJXVKYHEURADNFNMIJPXIJNTXHHXWBP || (player.inventory.containerMain.capacity - player.inventory.containerMain.itemList.Count) < KNDWHQMFBDEOJUIVZBPDSOKNWDYCRJITBHTACQFRXKVEFYK)
                if (YMYULMAWCPADSJNSVKNCAISIWYFISFHYTVDEKOHOG > (player.inventory.containerMain.capacity - player.inventory.containerMain.itemList.Count))
                {
                    player.ChatMessage(BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("No Space", player));
                    return false;
                }
            GiveItems(player, kit);
            if (page > -1)
            {
                if (kit.Amount > 0)
                {
                    playerData.Amount += 1;
                }
                if (kit.Cooldown > 0) playerData.Cooldown = GetCurrentTime() + kit.Cooldown;
                EffectNetwork.Send(new Effect("assets/prefabs/misc/xmas/presents/effects/unwrap.prefab", player, 0, Vector3.up, Vector3.zero)
                {
                    scale = UnityEngine.Random.Range(0f, 1f)
                });
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Extradited", player).Replace("{kitname}", kit.DisplayName));
                DestroyUI(player);
                UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(player, page);
            }
            return true;
        }
        private void NQPOTURFRTWWDONUGLXVPYHLUZDSRRSAYKINHJFJFC(BasePlayer player, string kitname)
        {
            if (kitsList.Exists(x => x.Name == kitname))
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Already Exist", player));
                return;
            }
            kitsList.Add(new Kit
            {
                Name = kitname,
                DisplayName = kitname,
                Cooldown = 600,
                Hide = true,
                Permission = "kits.default",
                UseImageURL = false,
                ImageURL = "",
                Amount = 0,
                Color = "0.55 0.68 0.31 0.6",
                Items = GetPlayerItems(player)
            });
            permission.RegisterPermission($"kits.default", this);
            SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Created", player).Replace("{name}", kitname));
            SaveKits();
            SaveData();
        }
        private void ORKCUIWJNLRPOIDTTRYNAAWXTFZMWFOQNXTUKXIK(BasePlayer player, string kitname)
        {
            if (!kitsList.Exists(x => x.Name == kitname))
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Doesn't Exist", player));
                return;
            }
            kitsList.First(x => x.Name.ToLower() == kitname.ToLower()).Items = GetPlayerItems(player);
            SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Cloned", player).Replace("{name}", kitname));
            SaveKits();
        }
        private void IFPHUTEEPLSGOBNVMIPIJMHXBCRPJJWJOSSVHQYLVIHTVJZW(BasePlayer player, string kitname)
        {
            if (kitsList.RemoveAll(x => x.Name == kitname) <= 0)
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Doesn't Exist", player));
                return;
            }
            SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Was Removed", player).Replace("{kitname}", kitname));
            SaveKits();
        }
        private void YXOTBLVYRFSCPVGPJRVJRNWKDNBEOBRCUIKLIQNGWX(BasePlayer player)
        {
            foreach (var kit in kitsList) SendReply(player, $"{kit.Name} - {kit.DisplayName}");
        }
        private void KGIFNAEMSDNOKAEPOKRJQNPHHKUGSEPNUYMDUHODKOZZH(BasePlayer player)
        {
            PlayersData.Clear();
            SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Reset", player));
        }
        private void AKEAYVENZWRBYCGXTNOZUMOAUGWNZBOQZOKJCRFTIHZPMTJ(BasePlayer player, BasePlayer foundPlayer, string kitname)
        {
            var reply = 1;
            if (reply == 0) { }
            if (!kitsList.Exists(x => x.Name == reply.ToString())) { }
            if (!kitsList.Exists(x => x.Name == kitname))
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Kit Doesn't Exist", player));
                return;
            }
            GiveItems(foundPlayer, kitsList.First(x => x.Name.ToLower() == kitname.ToLower()));
        }
        private void GiveItems(BasePlayer player, Kit kit)
        {
            foreach (var kitem in kit.Items)
            {
                if (kitem.EnableCommand && !string.IsNullOrEmpty(kitem.Command))
                {
                    Server.Command(kitem.Command.Replace("%STEAMID%", player.UserIDString));
                    continue;
                }
                GiveItem(player, XNULKHZNVDGSZRNXIABJRWUBIURMMZNBWKPMGCFROWNY(kitem.ShortName, kitem.Amount, kitem.SkinID, kitem.Condition, kitem.Blueprint, kitem.Weapon, kitem.Content), kitem.Change, kitem.Container == "belt" ? player.inventory.containerBelt : kitem.Container == "wear" ? player.inventory.containerWear : player.inventory.containerMain);
            }
        }
        private void GiveItem(BasePlayer player, Item item, int percent, ItemContainer cont = null)
        {
            if (item == null) return;
            var inv = player.inventory;
            if (UnityEngine.Random.Range(1, 100) < percent)
            {
                var XMQCZNWDJUKICQTPXNGSDXIBKXFJHHDZVEKGSUYSLPVNNKSN = item.MoveToContainer(cont) || item.MoveToContainer(inv.containerMain);
                if (!XMQCZNWDJUKICQTPXNGSDXIBKXFJHHDZVEKGSUYSLPVNNKSN)
                {
                    if (cont == inv.containerBelt) XMQCZNWDJUKICQTPXNGSDXIBKXFJHHDZVEKGSUYSLPVNNKSN = item.MoveToContainer(inv.containerWear);
                    if (cont == inv.containerWear) XMQCZNWDJUKICQTPXNGSDXIBKXFJHHDZVEKGSUYSLPVNNKSN = item.MoveToContainer(inv.containerBelt);
                }
                if (!XMQCZNWDJUKICQTPXNGSDXIBKXFJHHDZVEKGSUYSLPVNNKSN) item.Drop(player.GetCenter(), player.GetDropVelocity());
            }
        }
        private Item XNULKHZNVDGSZRNXIABJRWUBIURMMZNBWKPMGCFROWNY(string ShortName, int Amount, ulong SkinID, float Condition, int blueprintTarget, Weapon weapon, List<ItemContent> Content)
        {
            Item item = ItemManager.CreateByName(ShortName, Amount > 1 ? Amount : 1, SkinID);
            item.condition = Condition;
            if (blueprintTarget != 0) item.blueprintTarget = blueprintTarget;
            if (weapon != null)
            {
                (item.GetHeldEntity() as BaseProjectile).primaryMagazine.contents = weapon.ammoAmount;
                (item.GetHeldEntity() as BaseProjectile).primaryMagazine.ammoType = ItemManager.FindItemDefinition(weapon.ammoType);
            }
            if (Content != null)
            {
                foreach (var cont in Content)
                {
                    Item UQTINTZEORCHNVBQLMYFNXDOOHOBUOZESYMRJRIKLCDC = ItemManager.CreateByName(cont.ShortName, cont.Amount);
                    UQTINTZEORCHNVBQLMYFNXDOOHOBUOZESYMRJRIKLCDC.condition = cont.Condition;
                    UQTINTZEORCHNVBQLMYFNXDOOHOBUOZESYMRJRIKLCDC.MoveToContainer(item.contents);
                }
            }
            return item;
        }
        [ConsoleCommand("kits.page")]
        void MUQTCGLSZTBSSCPQMBWPEVOCBQFVJVVIVQVABSKTBJWQ(ConsoleSystem.Arg args)
        {
            var player = args.Player();
            var page = int.Parse(args.Args[0]);
            WZMDXZXYIZIYZIBMJLWQUSHPPTVABZFJQOTLPBETK(player, page);
        }
        private void UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(BasePlayer player, int page)
        {
            if (CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF.ContainsKey(player)) DestroyUI(player);
            else OpenKits(player, page);
        }
        private void OpenKits(BasePlayer player, int page)
        {
            CuiHelper.DestroyUi(player, $"ui.kits.info");
            var kits = GetKitsForPlayer(player).ToList();
            var HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL = new CuiElementContainer();
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "172 0",
          OffsetMax = "0 0"
        },
                CursorEnabled = true
            }, "MS_UI", "ui.kits");
            CuiHelper.AddUi(player, HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL);
            WZMDXZXYIZIYZIBMJLWQUSHPPTVABZFJQOTLPBETK(player, page);
        }
        private void DestroyUI(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, $"ui.kits.info");
            if (!CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF.ContainsKey(player)) return;
            foreach (var kitname in CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF[player])
            {
                CuiHelper.DestroyUi(player, $"ui.kits.{kitname}.time");
                CuiHelper.DestroyUi(player, $"ui.kits.{kitname}.mask");
                CuiHelper.DestroyUi(player, $"ui.kits.{kitname}.button");
                CuiHelper.DestroyUi(player, $"ui.kits.{kitname}.amount");
                CuiHelper.DestroyUi(player, $"ui.kits.{kitname}");
            }
            CuiHelper.DestroyUi(player, "ui.kits");
            CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF.Remove(player);
        }
        private void UBRXMOONOXZZGTRMRQGMMMDRPLBECSHFGZDBSVPFMHDN()
        {
            var currentTime = GetCurrentTime();
            List<Kit> KYTUWCXUIXXMEUGFXJASXPOIKGUENUKTBSDJUHXLBJJAPEFX = new List<Kit>();
            foreach (var playerGUIData in CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF)
            {
                if (!PlayersData.ContainsKey(playerGUIData.Key.userID)) continue;
                var FNTDJYUJKJPITHONDLMQXLQLPROGOTFBWCIGRQRU = PlayersData[playerGUIData.Key.userID];
                foreach (var kitname in playerGUIData.Value)
                {
                    var ZJXHCICVMLSTGEUWHNSKOURDOLQYHVMTRIXBSDMJLLB = FNTDJYUJKJPITHONDLMQXLQLPROGOTFBWCIGRQRU[kitname.Name.ToLower()];
                    if (ZJXHCICVMLSTGEUWHNSKOURDOLQYHVMTRIXBSDMJLLB.Cooldown > 0)
                    {
                        if (ZJXHCICVMLSTGEUWHNSKOURDOLQYHVMTRIXBSDMJLLB.Cooldown > currentTime)
                        {
                            var HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL = new CuiElementContainer();
                            YZVDTNOSCVHXIESWNDDWXIUZHKPPXIHCGMUHTMAHLI(ref HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL, playerGUIData.Key, kitname, 0);
                            CuiHelper.AddUi(playerGUIData.Key, HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL);
                        }
                    }
                }
                KYTUWCXUIXXMEUGFXJASXPOIKGUENUKTBSDJUHXLBJJAPEFX.ForEach(p => CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF[playerGUIData.Key].Remove(p));
            }
        }
        private string FormatTime(double time)
        {
            TimeSpan NIQYOJJCYKTESTTRRDNQZZBYHSEDBJYDTJQFVSKXMJV = TimeSpan.FromSeconds(time);
            var OSJYKURIXKINHSQVFFBPMQLJDNWYSQEPETJOJFTGSP = NIQYOJJCYKTESTTRRDNQZZBYHSEDBJYDTJQFVSKXMJV.Days;
            var IACYCBPSGIFVYHAVWYSPHFTJNICLZMUXWJDIAPTXDY = NIQYOJJCYKTESTTRRDNQZZBYHSEDBJYDTJQFVSKXMJV.Hours;
            IACYCBPSGIFVYHAVWYSPHFTJNICLZMUXWJDIAPTXDY += (OSJYKURIXKINHSQVFFBPMQLJDNWYSQEPETJOJFTGSP * 24);
            var GYXLGJKXIZAZCHTKUZDSTOIZOERVGEVLIHMLQXVCPOLXVKAAH = NIQYOJJCYKTESTTRRDNQZZBYHSEDBJYDTJQFVSKXMJV.Minutes;
            var ZYZFESPYWCSOQDEOQVVHUXDBCFCKDEDQOCFXMDCTV = NIQYOJJCYKTESTTRRDNQZZBYHSEDBJYDTJQFVSKXMJV.Seconds;
            if (IACYCBPSGIFVYHAVWYSPHFTJNICLZMUXWJDIAPTXDY > 0) return string.Format("{0:00}:{1:00}:{2:00}", IACYCBPSGIFVYHAVWYSPHFTJNICLZMUXWJDIAPTXDY, GYXLGJKXIZAZCHTKUZDSTOIZOERVGEVLIHMLQXVCPOLXVKAAH, ZYZFESPYWCSOQDEOQVVHUXDBCFCKDEDQOCFXMDCTV);
            else return string.Format("{0:00}:{1:00}", GYXLGJKXIZAZCHTKUZDSTOIZOERVGEVLIHMLQXVCPOLXVKAAH, ZYZFESPYWCSOQDEOQVVHUXDBCFCKDEDQOCFXMDCTV);
        }
        private void WZMDXZXYIZIYZIBMJLWQUSHPPTVABZFJQOTLPBETK(BasePlayer player, int page = 0)
        {
            CuiHelper.DestroyUi(player, $"ui.kits1");
            CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF[player] = new List<Kit>();
            var currentTime = GetCurrentTime();
            var kits = GetKitsForPlayer(player).Skip(6 * page).Take(6).ToList();
            int i = 0;
            int y = 0;
            var HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL = new CuiElementContainer();
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = $"0 0",
          AnchorMax = $"1 1"
        }
            }, "ui.kits", $"ui.kits1");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = $"0 0",
          AnchorMax = $"1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        }
            }, $"ui.kits1", $"ui.kits2");
            if (kits.Count > 0) foreach (var kit in kits)
                {
                    CuiHelper.DestroyUi(player, $"ui.kits.{kit.Name}");
                    CZNSPCNQRKILRKSYPCMKKAGICPTLJWAEEHRFZPHWRF[player].Add(kit);
                    var playerData = UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(kit.Name, player.userID);
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                    {
                        Image = {
            Color = "0.43 0.43 0.42 0"
          },
                        RectTransform = {
            AnchorMin = $"{0.12 + (i * 0.267)} {0.52 - (y * 0.33)}",
            AnchorMax = $"{0.182 + (i * 0.267) + 0.175f} {0.79 - (y * 0.33)}"
          }
                    }, $"ui.kits2", $"ui.kits.main.{kit.Name}");
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                    {
                        Image = {
            Color = "1 1 1 0"
          },
                        RectTransform = {
            AnchorMin = $"0 0.35",
            AnchorMax = $"1 0.98"
          }
                    }, $"ui.kits.main.{kit.Name}", $"ui.kits.image.{kit.Name}");
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.image.{kit.Name}",
                        Name = "PanelBtn",
                        Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "PanelButtonsImage"), Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1"
            }
          }
                    });
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.image.{kit.Name}",
                        Components = {
            new CuiTextComponent {
              Color = "1 1 1 1", Text = $"<b>{kit.DisplayName.ToUpper()}</b>", FontSize = 22, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleCenter,
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0 0", AnchorMax = $"1 1"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                    });
                    if (kit.UseImageURL == true)
                    {
                        HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                        {
                            RectTransform = {
              AnchorMin = $"0.5 1",
              AnchorMax = $"0.5 1",
              OffsetMin = "-15 -35",
              OffsetMax = "15 -5"
            },
                            Image = {
              Color = "0 0 0 0.4"
            }
                        }, $"ui.kits.image.{kit.Name}", "icon");
             
                        HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement()
                        {
                            Components = {
                                new CuiImageComponent
                                {
                                    Color = "1 1 1 1",
                                    Material = "assets/icons/greyout.mat",
                                    ItemId = GetItemId(kit.ImageURL),
                                },
                            },
                            Parent = "icon"
                        });
                    }
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                    {
                        Button = {
            Color = "0 0 0 0",
            Command = permission.UserHasPermission(player.UserIDString, kit.Permission) ? $"kit {kit.Name} {page}" : ""
          },
                        RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                        Text = {
            Text = "",
            Font = "robotocondensed-regular.ttf",
            Align = TextAnchor.MiddleCenter,
            FontSize = 18
          }
                    }, $"ui.kits.image.{kit.Name}");
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                    {
                        Image = {
            Color = "0.25 0.25 0.25 0.8"
          },
                        RectTransform = {
            AnchorMin = "0.015 0",
            AnchorMax = "0.985 0",
            OffsetMin = "0 -30",
            OffsetMax = "0 -2.5"
          }
                    }, "PanelBtn", ".PanelBtn");
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                    {
                        Image = {
            Color = "1 1 1 0"
          },
                        RectTransform = {
            AnchorMin = "0.015 0.06",
            AnchorMax = "0.98 0.82"
          }
                    }, ".PanelBtn", $"ui.kits.{kit.Name}");
                    YZVDTNOSCVHXIESWNDDWXIUZHKPPXIHCGMUHTMAHLI(ref HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL, player, kit, page);
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                    {
                        Button = {
            Color = "1 1 1 0.25",
            Command = $"kit.drawkitinfo {kit.Name} {page}"
          },
                        RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 1.098",
            OffsetMin = "-22 0",
            OffsetMax = "0 0"
          },
                        Text = {
            Text = "",
            Font = "robotocondensed-regular.ttf",
            Align = TextAnchor.MiddleCenter,
            FontSize = 18
          }
                    }, $"ui.kits.{kit.Name}", $"ui.kits.{kit.Name}.button");
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.{kit.Name}.button",
                        Components = {
            new CuiTextComponent {
              Color = "0.65 0.65 0.65 1", Text = "?", FontSize = 18, Font = "robotocondensed-bold.ttf", Align = TextAnchor.MiddleCenter
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0 0", AnchorMax = $"1 1"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                    });
                    i++;
                    if (i == 3)
                    {
                        i = 0;
                        y++;
                        if (y == 2) break;
                    }
                }
            else HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
            {
                Parent = "ui.kits2",
                Components = {
          new CuiTextComponent {
            FadeIn = 1f, Color = "1 1 1 0.5", Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("UI No Available", player).ToUpper(), FontSize = 35, Font = "robotocondensed-bold.ttf", Align = TextAnchor.MiddleCenter,
          },
          new CuiRectTransformComponent {
            AnchorMin = $"0 0.4", AnchorMax = $"1 0.6"
          },
          new CuiOutlineComponent {
            Color = "0 0 0 0.3", Distance = "-0.5 0.5"
          }
        },
            });
            if (player.IsAdmin)
            {
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                {
                    Image = {
            Color = "1 1 1 0.25"
          },
                    RectTransform = {
            AnchorMin = "0.795 0.487",
            AnchorMax = "0.975 0.537"
          },
                }, $"ui.kits2", "kits.adminSettings");
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                {
                    Image = {
            Color = "0.9 0.9 0.9 0.35"
          },
                    RectTransform = {
            AnchorMin = "0.02 0.2",
            AnchorMax = "0.13 0.8"
          },
                }, "kits.adminSettings", "btn");
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                {
                    Image = {
            Color = UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Contains(player) ? "0.53 0.77 0.35 0.8" : "0 0 0 0",
            Sprite = UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Contains(player) ? "assets/icons/check.png" : "assets/icons/check.png"
          },
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                }, "btn");
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = "kits.adminSettings",
                    Components = {
            new CuiTextComponent {
              Color = "1 1 1 1", Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("UI Admin ON", player), FontSize = 10, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleCenter,
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0.1 0", AnchorMax = $"1 1"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                });
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                {
                    Button = {
            Color = "1 1 1 0",
            Command = $"UIkits_adminSettings {page}"
          },
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = "",
            Font = "robotocondensed-regular.ttf",
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 0"
          }
                }, "kits.adminSettings");
            }
            string ASJBXHTHUEFZKBUYDZPEUSZBZOYHCNTBLCWKRBHVRVKYKO = $"kits.page {page - 1}";
            string DCOZCERWITIBJJLFHLEOHFKGBSUNYIAQLWUFONQWUFORJA = $"kits.page {page + 1}";
            bool LFQCNGAJYSHYKKDXASRQMOGRUUHTBRTXBUIHIFNKKMWMGPGMQ = page > 0;
            bool OYRKLXYZISYHIHZKWQBWPUFHFASULFNVCTDUFRJLIJW = GetKitsForPlayer(player).Skip(6 * (page + 1)).Count() > 0;
            var MDEPNVSQKTSTSJELEEODECEOEEEEGQOGYKVCVDGPMXKJAJC = page + 1;
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.5 0",
          AnchorMax = "0.5 0",
          OffsetMin = $"-195 15",
          OffsetMax = "205 60"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, $"ui.kits1", $"ui.kits1" + ".PS");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.5 0",
          AnchorMax = "0.5 1",
          OffsetMin = $"-84 0",
          OffsetMax = "85 0"
        },
                Image = {
          Color = "0.05 0.05 0.05 0.5"
        }
            }, $"ui.kits1" + ".PS", "LabelPage");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Text = {
          Text = lang.GetMessage("PAGE", this, player.UserIDString) + " " + (page + 1).ToString(),
          FontSize = 25,
          Font = "robotocondensed-regular.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = "0.929 0.882 0.847 0.8"
        }
            }, "LabelPage", "ThisLabel");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.15 0",
          AnchorMax = "0.29 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = LFQCNGAJYSHYKKDXASRQMOGRUUHTBRTXBUIHIFNKKMWMGPGMQ ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, $"ui.kits1" + ".PS", $"ui.kits1" + ".PS.L");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = LFQCNGAJYSHYKKDXASRQMOGRUUHTBRTXBUIHIFNKKMWMGPGMQ ? ASJBXHTHUEFZKBUYDZPEUSZBZOYHCNTBLCWKRBHVRVKYKO : ""
        },
                Text = {
          Text = "<b><</b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = LFQCNGAJYSHYKKDXASRQMOGRUUHTBRTXBUIHIFNKKMWMGPGMQ ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, $"ui.kits1" + ".PS.L");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.71 0",
          AnchorMax = "0.85 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = OYRKLXYZISYHIHZKWQBWPUFHFASULFNVCTDUFRJLIJW ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, $"ui.kits1" + ".PS", $"ui.kits1" + ".PS.R");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = OYRKLXYZISYHIHZKWQBWPUFHFASULFNVCTDUFRJLIJW ? DCOZCERWITIBJJLFHLEOHFKGBSUNYIAQLWUFONQWUFORJA : ""
        },
                Text = {
          Text = "<b>></b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = OYRKLXYZISYHIHZKWQBWPUFHFASULFNVCTDUFRJLIJW ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, $"ui.kits1" + ".PS.R");
            CuiHelper.AddUi(player, HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL);
        }
        private void YZVDTNOSCVHXIESWNDDWXIUZHKPPXIHCGMUHTMAHLI(ref CuiElementContainer HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL, BasePlayer player, Kit kit, int page)
        {
            CuiHelper.DestroyUi(player, $"ui.kits.{kit.Name}.kitmain");
            var playerData = UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(kit.Name.ToLower(), player.userID);
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "1 1 1 0",
        },
                RectTransform = {
          AnchorMin = $"0 0",
          AnchorMax = $"0.855 1"
        }
            }, $"ui.kits.{kit.Name}", $"ui.kits.{kit.Name}.kitmain");
            if (kit.Cooldown > 0 && playerData.Cooldown - 1 < GetCurrentTime() || kit.Cooldown == 0)
            {
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                {
                    Button = {
            Color = kit.Color,
            Command = permission.UserHasPermission(player.UserIDString, kit.Permission) ? $"kit {kit.Name} {page}" : ""
          },
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = "",
            Font = "robotocondensed-regular.ttf",
            Align = TextAnchor.MiddleCenter,
            FontSize = 18
          }
                }, $"ui.kits.{kit.Name}.kitmain", $"ui.kits.{kit.Name}.take");
                if (permission.UserHasPermission(player.UserIDString, kit.Permission))
                {
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.{kit.Name}.take",
                        Components = {
              new CuiTextComponent {
                Color = "0.85 0.85 0.85 1.00", Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("UI GIVE", player), FontSize = 17, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleCenter,
              },
              new CuiRectTransformComponent {
                AnchorMin = $"0 0", AnchorMax = $"1 1"
              },
              new CuiOutlineComponent {
                Color = "0 0 0 0.3", Distance = "-0.5 0.5"
              }
            },
                    });
                }
                else
                {
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.{kit.Name}.take",
                        Components = {
              new CuiTextComponent {
                Color = "0.85 0.85 0.85 1.00", Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("UI UNAVAILABLE", player), FontSize = 17, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleCenter,
              },
              new CuiRectTransformComponent {
                AnchorMin = $"0 0", AnchorMax = $"1 1"
              },
              new CuiOutlineComponent {
                Color = "0 0 0 0.3", Distance = "-0.5 0.5"
              }
            },
                    });
                }
                if (kit.Amount > 0)
                {
                    var amount = kit.Amount - playerData.Amount;
                    HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                    {
                        Parent = $"ui.kits.{kit.Name}.kitmain",
                        Components = {
              new CuiTextComponent {
                Color = "0.85 0.85 0.85 1.00", Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("UI Amount", player).Replace("{amount}", amount.ToString()), FontSize = 11, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleRight,
              },
              new CuiRectTransformComponent {
                AnchorMin = $"0 0.75", AnchorMax = $"0.95 0.95"
              },
              new CuiOutlineComponent {
                Color = "0 0 0 0.3", Distance = "-0.5 0.5"
              }
            },
                    });
                }
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                {
                    Button = {
            Color = "0.75 0.75 0.75 0",
            Command = playerData.Cooldown - 1 < GetCurrentTime() ? $"kit {kit.Name} {page}" : ""
          },
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = "",
            Font = "robotocondensed-regular.ttf",
            Align = TextAnchor.MiddleCenter,
            FontSize = 18
          }
                }, $"ui.kits.{kit.Name}");
            }
            else
            {
                var time = TimeSpan.FromSeconds(playerData.Cooldown - GetCurrentTime());
                var AnchorType = kit.Cooldown / (float)time.TotalSeconds - 0.03f;
                var max = 1 - ((time.TotalSeconds + (float)kit.Cooldown / 60) / kit.Cooldown);
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
                {
                    Image = {
            Color = kit.Color
          },
                    RectTransform = {
            AnchorMin = $"0 0",
            AnchorMax = $"{max} 1"
          }
                }, $"ui.kits.{kit.Name}.kitmain", $"ui.kits.{kit.Name}.time");
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = $"ui.kits.{kit.Name}.kitmain",
                    Components = {
            new CuiTextComponent {
              Color = "0.85 0.85 0.85 1.00", Text = TimeExtensions.FormatShortTime(time), FontSize = 14, Font = "robotocondensed-regular.ttf", Align = TextAnchor.MiddleCenter,
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0 0", AnchorMax = $"1 1"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                });
            }
        }
        [ConsoleCommand("kit.drawkitinfo")]
        void JBTGOTSNAPNKPFWVIYYVTOEQWJKCADWLOLKXOEAWEVGNSCEB(ConsoleSystem.Arg args)
        {
            var player = args.Player();
            if (player == null || player.Connection == null) return;
            var kit = kitsList.First(kits => kits.Name.ToLower() == args.Args[0].ToLower());
            if (kit == null) return;
            RRJNNDVXCKFIPMXTCVDVZGEYCQYIRXTFIFJMMXBIOZLUVNPI(player, kit, int.Parse(args.Args[1]));
        }
        void RRJNNDVXCKFIPMXTCVDVZGEYCQYIRXTFIFJMMXBIOZLUVNPI(BasePlayer player, Kit kit, int page)
        {
            DestroyUI(player);
            CuiHelper.DestroyUi(player, $"ui.kits.info");
            var HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL = new CuiElementContainer();
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "0.31 0.32 0.43 1"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "172 0",
          OffsetMax = "0 0"
        },
                CursorEnabled = true
            }, "MS_UI", $"ui.kits.info");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0.18 0.19 0.28 0.75"
        }
            }, $"ui.kits.info");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0.20 0.17 0.13 0.7",
          Sprite = "assets/content/ui/ui.background.transparent.radial.psd"
        }
            }, $"ui.kits.info", "BackgroundGLITCH");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0.23 0.20 0.13 0.3",
          Sprite = "assets/content/ui/ui.background.transparent.radial.psd"
        }
            }, $"ui.kits.info", "BackgroundGLITCH");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                CursorEnabled = true,
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0 0 0 0.6",
          Material = "assets/icons/greyout.mat"
        },
            }, $"ui.kits.info", "BackgroundGLITCH");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = $"0 0",
          AnchorMax = $"1 1"
        },
                CursorEnabled = true
            }, $"ui.kits.info", "Slots");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
            {
                Parent = $"ui.kits.info",
                Name = "ui.kits.info_text",
                Components = {
          new CuiTextComponent {
            Color = "1 1 1 1", Text = $"{kit.DisplayName.ToUpper()}", FontSize = 30, Align = TextAnchor.MiddleCenter,
          },
          new CuiRectTransformComponent {
            AnchorMin = $"0.5 1", AnchorMax = $"0.5 1", OffsetMin = "-200 -80", OffsetMax = "200 -10"
          },
          new CuiOutlineComponent {
            Color = "0 0 0 0.3", Distance = "-0.5 0.5"
          }
        },
            });
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        },
                Text = {
          Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("INFO INSIDE", player),
          Align = TextAnchor.LowerCenter,
          FontSize = 16,
          Color = "1 1 1 0.85",
          Font = "robotocondensed-regular.ttf"
        }
            }, "ui.kits.info_text");
            var pos = 0.5f - ((kit.Items.Count > 10 ? 10 : kit.Items.Count) * 0.09f + ((kit.Items.Count > 10 ? 10 : kit.Items.Count) - 1) * 0.005f) / 2;
            var NYGDVTPJZQLJQOJUFMVIOCPBYYRHSVNUCIRIJKKEULDFSWYX = 0.43;
            var PDOOUHKIFFWBIRDCQHIXBLUBQNCZKJBZTTCRZGIAGAEFN = 0.55;
            if (kit.Items.Count > 10)
            {
                NYGDVTPJZQLJQOJUFMVIOCPBYYRHSVNUCIRIJKKEULDFSWYX = 0.58;
                PDOOUHKIFFWBIRDCQHIXBLUBQNCZKJBZTTCRZGIAGAEFN = 0.695;
            }
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = $"0.4 0.05",
          AnchorMax = $"0.6 0.15"
        },
                CursorEnabled = true
            }, "ui.kits.info", "BACK");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiPanel
            {
                Image = {
          Color = "1 1 1 1"
        },
                RectTransform = {
          AnchorMin = $"0.5 0.5",
          AnchorMax = $"0.5 0.5",
          OffsetMin = "-100 -16",
          OffsetMax = "100 -15"
        },
            }, "BACK");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = $"0 0",
          AnchorMax = $"1 1"
        },
                Button = {
          Color = "0 0 0 0"
        },
                Text = {
          Text = BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("INFO BACK", player),
          FontSize = 25,
          Align = TextAnchor.MiddleCenter,
        }
            }, "BACK");
            HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
            {
                Parent = $"ui.kits.info",
                Components = {
          new CuiButtonComponent {
            Color = "0.16 0.15 0.31 0", Command = $"kit ui {page} {kit.Name}"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "1 1"
          },
        },
            });
            foreach (var item in kit.Items.OrderBy(p => p.Change < p.Change).Select((i, t) => new
            {
                A = i,
                B = t
            }).Take(30))
            {
                var MUZCBPQAMEIMYGELYVDXIOPLCKZHRAGPONAIZHIMJ = config.TCOHRLAUWGQYUTPORIEUSAXGDOVLFXSHTHJKOTDIE.Find(p => p.LCNYMPNUZHNPYGKUCYYYBKCBMPCGUXSHBYJHQHYDZEB == ChangeSelect(item.A.Change));
                if (MUZCBPQAMEIMYGELYVDXIOPLCKZHRAGPONAIZHIMJ == null)
                {
                    PrintError($"Ошибка загрузки цвета шанса у кита {kit.Name} {item.A.ShortName} Шанс {item.A.Change} {MUZCBPQAMEIMYGELYVDXIOPLCKZHRAGPONAIZHIMJ.Color}");
                    continue;
                }
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = $"{pos} {NYGDVTPJZQLJQOJUFMVIOCPBYYRHSVNUCIRIJKKEULDFSWYX}",
            AnchorMax = $"{pos + 0.09f} {PDOOUHKIFFWBIRDCQHIXBLUBQNCZKJBZTTCRZGIAGAEFN}",
            OffsetMax = "0 0"
          },
                    Button = {
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, $"Slots", $"Slots" + $".{item.B}");
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = $"Slots" + $".{item.B}",
                    Name = $"BtnImage",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = MUZCBPQAMEIMYGELYVDXIOPLCKZHRAGPONAIZHIMJ.Color
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = $"1 1", OffsetMin = "-8 -8", OffsetMax = "8 8"
            }
          }
                });
                pos += 0.09f + 0.005f;
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = $"Slots" + $".{item.B}",
                    Components = {
            //new CuiRawImageComponent {
            //  Png = 
              
              
            //  !string.IsNullOrEmpty(item.A.CustomImage) ? UZZKIFPJXHXMBHZWQGQDZMXEQHPNRIFCWIPNJEYZCXGLNPXX(item.A.CustomImage) : item.A.ShortName == "mailbox" ? UZZKIFPJXHXMBHZWQGQDZMXEQHPNRIFCWIPNJEYZCXGLNPXX("mailbox") : (string) ImageLibrary?.Call("GetImage", item.A.ShortName),
            //},
            new CuiImageComponent
            {
                ItemId = GetItemId(item.A.ShortName)
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.1 0", AnchorMax = "0.9 0.97", OffsetMax = "0 0"
            },
          },
                });
                HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = $"Slots" + $".{item.B}",
                    Components = {
            new CuiTextComponent {
              Color = "0.85 0.85 0.85 1.00", Text = $"<b>x{item.A.Amount}</b>", FontSize = 12, Align = TextAnchor.MiddleRight,
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0.4 0", AnchorMax = $"0.95 0.3"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                });
                if (item.A.Change < 99) HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL.Add(new CuiElement
                {
                    Parent = $"Slots" + $".{item.B}",
                    Components = {
            new CuiTextComponent {
              Color = "0.85 0.85 0.85 0.7", Text = $"<b>{item.A.Change}%</b>", FontSize = 45, Align = TextAnchor.MiddleCenter,
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0 0", AnchorMax = $"1 1"
            },
            new CuiOutlineComponent {
              Color = "0 0 0 0.3", Distance = "-0.5 0.5"
            }
          },
                });
                if (item.B == 9)
                {
                    NYGDVTPJZQLJQOJUFMVIOCPBYYRHSVNUCIRIJKKEULDFSWYX = 0.455;
                    PDOOUHKIFFWBIRDCQHIXBLUBQNCZKJBZTTCRZGIAGAEFN = 0.57;
                    pos = 0.5f - ((kit.Items.Skip(10).ToList().Count > 10 ? 10 : kit.Items.Skip(10).ToList().Count) * 0.09f + ((kit.Items.Skip(10).ToList().Count > 10 ? 10 : kit.Items.Skip(10).ToList().Count) - 1) * 0.005f) / 2;
                }
                if (item.B == 19)
                {
                    NYGDVTPJZQLJQOJUFMVIOCPBYYRHSVNUCIRIJKKEULDFSWYX = 0.325;
                    PDOOUHKIFFWBIRDCQHIXBLUBQNCZKJBZTTCRZGIAGAEFN = 0.445;
                    pos = 0.5f - ((kit.Items.Skip(20).ToList().Count > 10 ? 10 : kit.Items.Skip(20).ToList().Count) * 0.09f + ((kit.Items.Skip(20).ToList().Count > 10 ? 10 : kit.Items.Skip(20).ToList().Count) - 1) * 0.005f) / 2;
                }
            }
            CuiHelper.AddUi(player, HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL);
        }
        private int? ChangeSelect(int x)
        {
            var num = (from number in config.TCOHRLAUWGQYUTPORIEUSAXGDOVLFXSHTHJKOTDIE.Select(p => p.LCNYMPNUZHNPYGKUCYYYBKCBMPCGUXSHBYJHQHYDZEB) let difference = Math.Abs(number - x) orderby difference, Math.Abs(number), number descending select number).FirstOrDefault();
            return num;
        }
        private void TQHAGXKNKKWENFEQZAJDKGETVGZVJDOBPZXHMEBHYZB(BasePlayer player, string effectPrefab)
        {
            EffectNetwork.Send(new Effect(effectPrefab, player.transform.position, Vector3.zero), player.net.connection);
        }
        [ConsoleCommand("UIkits_adminSettings")]
        void EEBTHDVNFFYNMNFAYPDHVVONIXEVYCELERPQEFNFIBVJB(ConsoleSystem.Arg args)
        {
            var player = args.Player();
            int page = int.Parse(args.Args[0]);
            if (!UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Contains(player))
            {
                UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Add(player);
                DestroyUI(player);
                UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(player, page);
            }
            else
            {
                UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Remove(player);
                DestroyUI(player);
                UOZPBBVRJHRFNSLAQIEYTXCHPOUQDOVYXOGCGFHTZQMJE(player, page);
            }
        }
        private KitData UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(string name, ulong playerid = 1731584)
        {
            if (!PlayersData.ContainsKey(playerid)) PlayersData[playerid] = new Dictionary<string, KitData>();
            if (!PlayersData[playerid].ContainsKey(name)) PlayersData[playerid][name] = new KitData();
            return PlayersData[playerid][name];
        }
        private List<KitItem> GetPlayerItems(BasePlayer player)
        {
            List<KitItem> HXJNIBVUCIBQVYFNZQQIJLYSXKGWMQNROOHRCPCXLXYXNXS = new List<KitItem>();
            foreach (Item item in player.inventory.containerWear.itemList)
            {
                if (item != null)
                {
                    var DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN = YWDENQBNRQCWQPHWMGUHBSEDIVBSIHDQCOCQDPOCISEHTWXP(item, "wear");
                    HXJNIBVUCIBQVYFNZQQIJLYSXKGWMQNROOHRCPCXLXYXNXS.Add(DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN);
                }
            }
            foreach (Item item in player.inventory.containerMain.itemList)
            {
                if (item != null)
                {
                    var DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN = YWDENQBNRQCWQPHWMGUHBSEDIVBSIHDQCOCQDPOCISEHTWXP(item, "main");
                    HXJNIBVUCIBQVYFNZQQIJLYSXKGWMQNROOHRCPCXLXYXNXS.Add(DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN);
                }
            }
            foreach (Item item in player.inventory.containerBelt.itemList)
            {
                if (item != null)
                {
                    var DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN = YWDENQBNRQCWQPHWMGUHBSEDIVBSIHDQCOCQDPOCISEHTWXP(item, "belt");
                    HXJNIBVUCIBQVYFNZQQIJLYSXKGWMQNROOHRCPCXLXYXNXS.Add(DMIRVAKVZQPXUZIMVKCGRNLKOSWLMAEASESZHWVN);
                }
            }
            return HXJNIBVUCIBQVYFNZQQIJLYSXKGWMQNROOHRCPCXLXYXNXS;
        }
        string BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH(string key, BasePlayer player = null) => lang.GetMessage(key, this, player == null ? null : player.UserIDString).Replace("{Prefix}", config.DefaultPrefix);
        private KitItem YWDENQBNRQCWQPHWMGUHBSEDIVBSIHDQCOCQDPOCISEHTWXP(Item item, string HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL)
        {
            KitItem kitem = new KitItem();
            kitem.Amount = item.amount;
            kitem.Container = HWEYYKQXEOTPTPOQZCRSLYFHWMKJQXTVWRTDIZZL;
            kitem.SkinID = item.skin;
            kitem.Blueprint = item.blueprintTarget;
            kitem.ShortName = item.info.shortname;
            kitem.Condition = item.condition;
            kitem.Change = 100;
            kitem.Weapon = null;
            kitem.Content = null;
            if (item.info.category == ItemCategory.Weapon)
            {
                BaseProjectile weapon = item.GetHeldEntity() as BaseProjectile;
                if (weapon != null)
                {
                    kitem.Weapon = new Weapon();
                    kitem.Weapon.ammoType = weapon.primaryMagazine.ammoType.shortname;
                    kitem.Weapon.ammoAmount = weapon.primaryMagazine.contents;
                }
            }
            if (item.contents != null)
            {
                kitem.Content = new List<ItemContent>();
                foreach (var cont in item.contents.itemList)
                {
                    kitem.Content.Add(new ItemContent()
                    {
                        Amount = cont.amount,
                        Condition = cont.condition,
                        ShortName = cont.info.shortname
                    });
                }
            }
            return kitem;
        }
        private List<Kit> GetKitsForPlayer(BasePlayer player)
        {
            if (UYJIRKBLYRGVBSEQZIBGUJDGKTMZAVPTFZLKTGBA.Contains(player))
            {
                return kitsList.ToList();
            }
            else if (config.InterfaceSetting.CDGSBQQIDCHBZLLWMGABOGOAXDDVZUYWJPZJJJFEHJDZR) return kitsList.Where(kit => !kit.Hide && (kit.Amount == 0 || (kit.Amount > 0 && UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(kit.Name, player.userID).Amount < kit.Amount))).ToList();
            else return kitsList.Where(kit => !kit.Hide && (string.IsNullOrEmpty(kit.Permission) || permission.UserHasPermission(player.UserIDString, kit.Permission)) && (kit.Amount == 0 || (kit.Amount > 0 && UYYBJJVURJPNLKZZODBMIVYPVSBXZTZEMYCFXWSVQKZ(kit.Name, player.userID).Amount < kit.Amount))).ToList();
        }
        private BasePlayer FindPlayer(BasePlayer player, string nameOrID)
        {
            ulong id;
            if (ulong.TryParse(nameOrID, out id) && nameOrID.StartsWith("7656119") && nameOrID.Length == 17)
            {
                var AYBFGTCYJTSKGCSZKAMEGICPGKFUBNTMSBIAKJYWEJUGVEUC = BasePlayer.FindByID(id);
                if (AYBFGTCYJTSKGCSZKAMEGICPGKFUBNTMSBIAKJYWEJUGVEUC == null || !AYBFGTCYJTSKGCSZKAMEGICPGKFUBNTMSBIAKJYWEJUGVEUC.IsConnected)
                {
                    SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Not Found Player", player));
                    return null;
                }
                return AYBFGTCYJTSKGCSZKAMEGICPGKFUBNTMSBIAKJYWEJUGVEUC;
            }
            var ZZIDGQRVMYVOHXWAFRFUSPBCPZWOWTCPCSBNKJMK = BasePlayer.activePlayerList.Where(x => x.displayName.ToLower().Contains(nameOrID.ToLower()));
            if (ZZIDGQRVMYVOHXWAFRFUSPBCPZWOWTCPCSBNKJMK.Count() == 0)
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("Not Found Player", player));
                return null;
            }
            if (ZZIDGQRVMYVOHXWAFRFUSPBCPZWOWTCPCSBNKJMK.Count() > 1)
            {
                SendReply(player, BQUDGINSIOBZAJGQHYUXJKBMHTCSKGWXVSNEYYQQGH("To Many Player", player));
                return null;
            }
            return ZZIDGQRVMYVOHXWAFRFUSPBCPZWOWTCPCSBNKJMK.First();
        }
        private double GetCurrentTime() => new TimeSpan(DateTime.UtcNow.Ticks).TotalSeconds;
        private static string HexToRustFormat(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                hex = "#FFFFFFFF";
            }
            var str = hex.Trim('#');
            if (str.Length == 6) str += "FF";
            if (str.Length != 8)
            {
                throw new InvalidOperationException("Cannot convert a wrong format.???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????");
            }
            var r = byte.Parse(str.Substring(0, 2), NumberStyles.HexNumber);
            var g = byte.Parse(str.Substring(2, 2), NumberStyles.HexNumber);
            var b = byte.Parse(str.Substring(4, 2), NumberStyles.HexNumber);
            var a = byte.Parse(str.Substring(6, 2), NumberStyles.HexNumber);
            Color color = new Color32(r, g, b, a);
            return string.Format("{0:F2} {1:F2} {2:F2} {3:F2}", color.r, color.g, color.b, color.a);
        }
        private static class TimeExtensions
        {
            public static string FormatShortTime(TimeSpan time)
            {
                string FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA = string.Empty;
                if (time.Days != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{time.Days} д. ";
                if (time.Hours != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{time.Hours} ч. ";
                if (time.Minutes != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{time.Minutes} м. ";
                if (time.Seconds != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{time.Seconds} с. ";
                return FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA;
            }
            public static string FormatTime(TimeSpan time)
            {
                string FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA = string.Empty;
                if (time.Days != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{Format(time.Days, "дней", "дня", "день")}";
                if (time.Hours != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{Format(time.Hours, "часов", "часа", "час")}";
                if (time.Minutes != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{Format(time.Minutes, "минут", "минуты", "минута")} ";
                if (time.Seconds != 0) FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA += $"{Format(time.Seconds, "секунд", "секунды", "секунда")} ";
                return FYKCIXMYGPMPIKKYGOGTDZSWFMPVIPWFVEMQQAGCKPQDPA;
            }
            private static string Format(int units, string IDYPONJYKAUCDPIRXBLAGHGUYTCVKIADFRCUGRIZ, string LFXYTTCKMLYNKUBXDRUKNNCARWLMNKFSMZVBIWEA, string LYWBPVWBXDAOOOXCXGXHPWBFGALZZOHNUJBPGYCA)
            {
                var tmp = units % 10;
                if (units >= 5 && units <= 20 || tmp >= 5 && tmp <= 9) return $"{units} {IDYPONJYKAUCDPIRXBLAGHGUYTCVKIADFRCUGRIZ}";
                if (tmp >= 2 && tmp <= 4) return $"{units} {LFXYTTCKMLYNKUBXDRUKNNCARWLMNKFSMZVBIWEA}";
                return $"{units} {LYWBPVWBXDAOOOXCXGXHPWBFGALZZOHNUJBPGYCA}";
            }
        }
        [HookMethod("isKit")]
        public bool isKit(string kitName)
        {
            if (kitsList.Select(p => p.Name == kitName) != null) return true;
            return false;
        }
        [HookMethod("GetAllKits")] public string[] GetAllKits() => kitsList.Select(p => p.Name).ToArray();

        private static readonly Dictionary<string, int> _itemIds = new Dictionary<string, int>();

        public static int GetItemId(string name)
        {
            int id;
            if (_itemIds.TryGetValue(name, out id))
                return id;

            var def = ItemManager.FindItemDefinition(name);
            if (!def)
                return _itemIds[name] = int.MinValue;

            return _itemIds[name] = def.itemid;
        }
    }
}