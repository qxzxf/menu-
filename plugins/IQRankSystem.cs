using Newtonsoft.Json;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using System.Linq;
using System;
using ConVar;
using System.Text;
using Oxide.Core;
namespace Oxide.Plugins
{
      /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ [Info("IQRankSystem", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class IQRankSystem : RustPlugin
    {
        [PluginReference] Plugin IQChat, IQCases, IQHeadReward, IQEconomic;
        public void SendChat(BasePlayer player, string Message, Chat.ChatChannel channel = Chat.ChatChannel.Global)
        {
            var Chat = config.Setting.ReferenceSetting.IQChatSetting;
            if (IQChat) IQChat?.Call("API_ALERT_PLAYER", player, Message, Chat.CustomPrefix, Chat.CustomAvatar);
            else player.SendConsoleCommand("chat.add", channel, 0, Message);
        }
        void OpenCase(BasePlayer player, string DisplayNameCase)
        {
            if (!DataInformation.ContainsKey(player.userID)) return;
            var Data = DataInformation[player.userID];
            Data.InformationUser.IQCasesOpenCase++;
        }
        void KilledTask(BasePlayer player)
        {
            if (!DataInformation.ContainsKey(player.userID)) return;
            var Data = DataInformation[player.userID];
            Data.InformationUser.IQHeadRewardKillAmount++;
        }
        void SET_BALANCE_USER(ulong userID, int SetBalance)
        {
            if (!DataInformation.ContainsKey(userID)) return;
            var Data = DataInformation[userID];
            Data.InformationUser.IQEconomicAmountBalance += SetBalance;
        }
        public enum Obtaining
        {
            Gather,
            Time,
            GatherAndTime,
            IQCases,
            IQHeadReward,
            IQEconomic,
        }
        StringBuilder sb = new StringBuilder();
        private string GetLang(string LangKey, string userID = null, params object[] args)
        {
            sb.Clear();
            if (args != null)
            {
                sb.AppendFormat(lang.GetMessage(LangKey, this, userID), args);
                return sb.ToString();
            }
            return lang.GetMessage(LangKey, this, userID);
        }
        void RegisteredPermissions()
        {
            foreach (var Perm in config.RankList.Where(p => !String.IsNullOrWhiteSpace(p.Value.PermissionRank))) if (!permission.PermissionExists(Perm.Value.PermissionRank, this)) permission.RegisterPermission(Perm.Value.PermissionRank, this);
        }
        private static Configuration config = new Configuration();
        private class Configuration
        {
            [JsonProperty("Формат для отображения рангов в чате (В IQChat настраивается отдельно) [Не добавляйте значения в {} и не меняйте их порядок, если не уверены в своих возможностях или не знаете что это!!].Все что не внутри {} - можете смело вертеть")] public String FormatRanks = "{0} {1} {2} {3}: {4}";
            [JsonProperty("Список рангов и их настройка")] public Dictionary<string, RankSettings> RankList = new Dictionary<string, RankSettings>();
            [JsonProperty("Настройки плагина")] public Settings Setting = new Settings();
            internal class RankSettings
            {
                [JsonProperty("Название ранга")] public String DisplayNameRank;
                [JsonProperty("Права с которыми доступен данный ранг")] public String PermissionRank;
                [JsonProperty("Настройки получения ранга")] public Obtainings Obtaining = new Obtainings();
                internal class Obtainings
                {
                    [JsonProperty("Выберите за что возможно получить доступ к данному рангу" + "(0 - Добыча, " + "1 - Время игры на сервере, " + "2 - Вермя игры на сервере и добыча вместе," + "3 - IQCases , открыть N количество кейсов," + "4 - IQHeadReward , убить N количество игроков в розыске" + "5 - IQEconomic, собрать за все время N количество валюты")] public Obtaining ObtainingType;
                    [JsonProperty("Настройки получения ранга за время")] public ObtainingsTime ObtainingsTimes = new ObtainingsTime();
                    [JsonProperty("Настройки получения ранга за добычу")] public ObtainingsGather ObtainingsGathers = new ObtainingsGather();
                    [JsonProperty("Настройки получения ранга за открытие кейсов IQCases")] public ObtainingsIQCases ObtainingsIQCase = new ObtainingsIQCases();
                    [JsonProperty("Настройки получения ранга за убийство разыскиваемых IQHeadReward")] public ObtainingsIQHeadReward ObtainingsIQHeadRewards = new ObtainingsIQHeadReward();
                    [JsonProperty("Настройки получения ранга за собранную валюту IQEconomic")] public ObtainingsIQEconomic ObtainingsIQEconomics = new ObtainingsIQEconomic();
                    internal class ObtainingsIQEconomic
                    {
                        [JsonProperty("Сколько собрать валюты для получения этого ранга")] public Int32 IQEconomicBalance;
                    }
                    internal class ObtainingsIQCases
                    {
                        [JsonProperty("Сколько кейсов открыть для получения этого ранга")] public Int32 OpenCaseAmount;
                    }
                    internal class ObtainingsIQHeadReward
                    {
                        [JsonProperty("Сколько нужно убить разыскиваемых для получения этого ранга")] public Int32 KillHeadAmount;
                    }
                    internal class ObtainingsTime
                    {
                        [JsonProperty("Время, которое нужно отыграть для получения этого ранга")] public Int32 TimeGame;
                    }
                    internal class ObtainingsGather
                    {
                        [JsonProperty("Сколько нужно добыть всего ресурсов для ранга")] public Int32 Amount;
                        [JsonProperty("Использовать детальную добычу true - да(из списка, по критериям)/false - нет(учитывается на все ресурсы)")] public Boolean UseDetalisGather;
                        [JsonProperty("Настройки детальной добычи : Shortname = Amount")] public Dictionary<String, Int32> GatherDetalis = new Dictionary<String, Int32>();
                    }
                }
            }
            internal class Settings
            {
                [JsonProperty("Настройки плагинов совместимости")] public ReferenceSettings ReferenceSetting = new ReferenceSettings();
                [JsonProperty("Общие настройки")] public GeneralSettings GeneralSetting = new GeneralSettings();
                internal class GeneralSettings
                {
                    [JsonProperty("Отображать время игры на сервере перед рангом")] public Boolean ShowTimeGame;
                    [JsonProperty("При получении нового ранга сразу устанавливать его(true - да/false - нет)")] public Boolean RankSetupNew;
                }
                internal class ReferenceSettings
                {
                    [JsonProperty("Настройки IQChat")] public IQChatSettings IQChatSetting = new IQChatSettings();
                    internal class IQChatSettings
                    {
                        [JsonProperty("IQChat : Кастомный префикс в чате")] public String CustomPrefix;
                        [JsonProperty("IQChat : Кастомный аватар в чате(Если требуется)")] public String CustomAvatar;
                    }
                }
            }
            public static Configuration GetNewConfiguration()
            {
                return new Configuration
                {
                    FormatRanks = "{0} {1} {2} {3}: {4}",
                    Setting = new Settings
                    {
                        GeneralSetting = new Settings.GeneralSettings
                        {
                            ShowTimeGame = false,
                            RankSetupNew = true,
                        },
                        ReferenceSetting = new Settings.ReferenceSettings
                        {
                            IQChatSetting = new Settings.ReferenceSettings.IQChatSettings
                            {
                                CustomAvatar = "",
                                CustomPrefix = "",
                            },
                        },
                    },
                    RankList = new Dictionary<String, RankSettings>
                    {
                        ["newmember"] = new RankSettings
                        {
                            DisplayNameRank = "Новобранец",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.Time,
                                ObtainingsTimes = new RankSettings.Obtainings.ObtainingsTime
                                {
                                    TimeGame = 0,
                                },
                            },
                        },
                        ["member"] = new RankSettings
                        {
                            DisplayNameRank = "Местный",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.Time,
                                ObtainingsTimes = new RankSettings.Obtainings.ObtainingsTime
                                {
                                    TimeGame = 300,
                                },
                            },
                        },
                        ["experienced"] = new RankSettings
                        {
                            DisplayNameRank = "Бывалый",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.Time,
                                ObtainingsTimes = new RankSettings.Obtainings.ObtainingsTime
                                {
                                    TimeGame = 600,
                                },
                            },
                        },
                        ["farmer"] = new RankSettings
                        {
                            DisplayNameRank = "Фармила",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.Gather,
                                ObtainingsGathers = new RankSettings.Obtainings.ObtainingsGather
                                {
                                    Amount = 5000,
                                    UseDetalisGather = true,
                                    GatherDetalis = new Dictionary<String, Int32>
                                    {
                                        ["wood"] = 500,
                                        ["stones"] = 1000,
                                    }
                                }
                            },
                        },
                        ["adminFriend"] = new RankSettings
                        {
                            DisplayNameRank = "Кент Админа",
                            PermissionRank = "iqranksystem.vip",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.Time,
                                ObtainingsTimes = new RankSettings.Obtainings.ObtainingsTime
                                {
                                    TimeGame = 600,
                                }
                            },
                        },
                        ["gamer"] = new RankSettings
                        {
                            DisplayNameRank = "Задрот",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.GatherAndTime,
                                ObtainingsTimes = new RankSettings.Obtainings.ObtainingsTime
                                {
                                    TimeGame = 500,
                                },
                                ObtainingsGathers = new RankSettings.Obtainings.ObtainingsGather
                                {
                                    Amount = 5000,
                                    UseDetalisGather = true,
                                    GatherDetalis = new Dictionary<String, Int32>
                                    {
                                        ["sulfur.ore"] = 500,
                                    }
                                }
                            },
                        },
                        ["azart"] = new RankSettings
                        {
                            DisplayNameRank = "Азартный игрок",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.IQCases,
                                ObtainingsIQCase = new RankSettings.Obtainings.ObtainingsIQCases
                                {
                                    OpenCaseAmount = 3
                                }
                            },
                        },
                        ["killer"] = new RankSettings
                        {
                            DisplayNameRank = "Шериф",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.IQHeadReward,
                                ObtainingsIQHeadRewards = new RankSettings.Obtainings.ObtainingsIQHeadReward
                                {
                                    KillHeadAmount = 5,
                                }
                            },
                        },
                        ["IqEconomicMillioner"] = new RankSettings
                        {
                            DisplayNameRank = "Скрудж Макдак",
                            PermissionRank = "",
                            Obtaining = new RankSettings.Obtainings
                            {
                                ObtainingType = Obtaining.IQEconomic,
                                ObtainingsIQEconomics = new RankSettings.Obtainings.ObtainingsIQEconomic
                                {
                                    IQEconomicBalance = 350,
                                }
                            },
                        },
                    }
                };
            }
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                config = Config.ReadObject<Configuration>();
                if (config == null) LoadDefaultConfig();
            }
            catch
            {
                PrintWarning($"Ошибка чтения # конфигурации 'oxide/config/{Name}', создаём новую конфигурацию!!");
                LoadDefaultConfig();
            }
            NextTick(SaveConfig);
        }
        protected override void LoadDefaultConfig() => config = Configuration.GetNewConfiguration();
        protected override void SaveConfig() => Config.WriteObject(config);
        [JsonProperty("Информация о пользователях")] public Dictionary<UInt64, DataClass> DataInformation = new Dictionary<UInt64, DataClass>();
        public class DataClass
        {
            [JsonProperty("Активный ранг")] public String RankActive;
            [JsonProperty("Доступные ранги")] public List<String> RankAccessList = new List<String>();
            [JsonProperty("Информация о прогрессе игроков")] public Infromation InformationUser = new Infromation();
            internal class Infromation
            {
                [JsonProperty("Время на сервере")] public Int32 TimeGame;
                [JsonProperty("Добыто всего")] public Int32 GatherAll;
                [JsonProperty("Добыто всего : детально")] public Dictionary<String, Int32> GatherDetalis = new Dictionary<String, Int32>();
                [JsonProperty("IQCases : Открыто кейсов")] public Int32 IQCasesOpenCase;
                [JsonProperty("IQHeadReward : Убито разыскиваемых")] public Int32 IQHeadRewardKillAmount;
                [JsonProperty("IQEconomic : Собрано валюты")] public Int32 IQEconomicAmountBalance;
            }
        }
        void ReadData() => DataInformation = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<Dictionary<UInt64, DataClass>>("IQRankSystem/DataPlayers");
        void WriteData() => Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQRankSystem/DataPlayers", DataInformation);
        void RegisteredDataUser(UInt64 userID)
        {
            if (!DataInformation.ContainsKey(userID)) DataInformation.Add(userID, new DataClass
            {
                RankActive = "",
                RankAccessList = new List<String> { },
                InformationUser = new DataClass.Infromation
                {
                    GatherAll = 0,
                    GatherDetalis = new Dictionary<String, Int32> { },
                    TimeGame = 0,
                    IQCasesOpenCase = 0,
                    IQHeadRewardKillAmount = 0,
                    IQEconomicAmountBalance = 0
                }
            });
            foreach (var List in config.RankList.Where(x => x.Value.Obtaining.ObtainingsGathers.UseDetalisGather)) foreach (var GatherList in List.Value.Obtaining.ObtainingsGathers.GatherDetalis.Where(g => !DataInformation[userID].InformationUser.GatherDetalis.ContainsKey(g.Key))) DataInformation[userID].InformationUser.GatherDetalis.Add(GatherList.Key, 0);
        }
        private void Init() => Unsubscribe(nameof(OnPlayerChat));
        private void OnServerInitialized()
        {
            if (!IQChat) Subscribe(nameof(OnPlayerChat));
            RegisteredPermissions();
            ReadData();
            foreach (var player in BasePlayer.activePlayerList) OnPlayerConnected(player);
            WriteData();
            TrackerTime();
        }
        void OnPlayerConnected(BasePlayer player) => RegisteredDataUser(player.userID);
        object OnDispenserGather(ResourceDispenser dispenser, BaseEntity entity, Item item)
        {
            BasePlayer player = entity as BasePlayer;
            if (player == null) return null;
            if (item == null) return null;
            if (entity == null) return null;
            if (!DataInformation.ContainsKey(player.userID)) return null;
            var Data = DataInformation[player.userID].InformationUser;
            Data.GatherAll += item.amount;
            if (Data.GatherDetalis.ContainsKey(item.info.shortname)) Data.GatherDetalis[item.info.shortname] += item.amount;
            return null;
        }
        void OnDispenserBonus(ResourceDispenser dispenser, BasePlayer player, Item item)
        {
            if (player == null) return;
            if (item == null) return;
            if (!DataInformation.ContainsKey(player.userID)) return;
            var Data = DataInformation[player.userID].InformationUser;
            Data.GatherAll += item.amount;
            if (Data.GatherDetalis.ContainsKey(item.info.shortname)) Data.GatherDetalis[item.info.shortname] += item.amount;
        }
        private void Unload() => WriteData();
        private bool OnPlayerChat(BasePlayer player, string message, Chat.ChatChannel channel)
        {
            if (Interface.Oxide.CallHook("CanChatMessage", player, message) != null) return false;
            SeparatorChat(channel, player, message);
            return false;
        }
        private void SeparatorChat(Chat.ChatChannel channel, BasePlayer player, string Message)
        {
            if (IQChat) return;
            var Data = DataInformation[player.userID];
            String Rank = config.RankList[Data.RankActive].DisplayNameRank;
            String Time = API_GET_TIME_GAME(player.userID);
            String ModifiedChannel = channel == Chat.ChatChannel.Team ? "<color=#a5e664>[Team]</color>" : "";
            String MessageSeparator = String.Format(config.FormatRanks, ModifiedChannel, Time, Rank, player.displayName, Message);
            if (channel == Chat.ChatChannel.Global) foreach (BasePlayer p in BasePlayer.activePlayerList) p.SendConsoleCommand("chat.add", new object[] {
                                (int) channel, player.userID, MessageSeparator
                        });
            if (channel == Chat.ChatChannel.Team)
            {
                RelationshipManager.PlayerTeam Team = RelationshipManager.ServerInstance.FindTeam(player.currentTeam);
                if (Team == null) return;
                foreach (var FindPlayers in Team.members)
                {
                    BasePlayer TeamPlayer = BasePlayer.FindByID(FindPlayers);
                    if (TeamPlayer == null) continue;
                    TeamPlayer.SendConsoleCommand("chat.add", channel, player.userID, MessageSeparator);
                }
            }
        }
        public void RankAccess(BasePlayer player)
        {
            var Ranks = config.RankList;
            if (Ranks == null) return;
            var Data = DataInformation[player.userID];
            if (Data == null) return;
            foreach (var Rank in Ranks.Where(r => !Data.RankAccessList.Contains(r.Key) && (String.IsNullOrEmpty(Ranks[r.Key].PermissionRank) || permission.UserHasPermission(player.UserIDString, Ranks[r.Key].PermissionRank))))
            {
                var ObtainingSetup = Rank.Value.Obtaining;
                switch (ObtainingSetup.ObtainingType)
                {
                    case Obtaining.Time:
                        {
                            if (ObtainingSetup.ObtainingsTimes.TimeGame <= Data.InformationUser.TimeGame) SetupRank(player, Rank.Key);
                            break;
                        };
                    case Obtaining.Gather:
                        {
                            if (!ObtainingSetup.ObtainingsGathers.UseDetalisGather)
                            {
                                if (ObtainingSetup.ObtainingsGathers.Amount <= Data.InformationUser.GatherAll) SetupRank(player, Rank.Key);
                            }
                            else
                            {
                                Int32 ConditionSuccess = 0;
                                foreach (KeyValuePair<String, Int32> DataGather in ObtainingSetup.ObtainingsGathers.GatherDetalis) if (DataGather.Value <= Data.InformationUser.GatherDetalis[DataGather.Key]) ConditionSuccess++;
                                if (ConditionSuccess == ObtainingSetup.ObtainingsGathers.GatherDetalis.Count) SetupRank(player, Rank.Key);
                            }
                            break;
                        };
                    case Obtaining.GatherAndTime:
                        {
                            if (!ObtainingSetup.ObtainingsGathers.UseDetalisGather)
                            {
                                if (ObtainingSetup.ObtainingsGathers.Amount <= Data.InformationUser.GatherAll && ObtainingSetup.ObtainingsTimes.TimeGame <= Data.InformationUser.TimeGame) SetupRank(player, Rank.Key);
                            }
                            else
                            {
                                if (ObtainingSetup.ObtainingsTimes.TimeGame <= Data.InformationUser.TimeGame)
                                {
                                    Int32 ConditionSuccess = 0;
                                    foreach (KeyValuePair<String, Int32> DataGather in ObtainingSetup.ObtainingsGathers.GatherDetalis) if (DataGather.Value <= Data.InformationUser.GatherDetalis[DataGather.Key]) ConditionSuccess++;
                                    if (ConditionSuccess == ObtainingSetup.ObtainingsGathers.GatherDetalis.Count) SetupRank(player, Rank.Key);
                                }
                            }
                            break;
                        }
                    case Obtaining.IQCases:
                        {
                            if (!IQCases) return;
                            if (ObtainingSetup.ObtainingsIQCase.OpenCaseAmount <= Data.InformationUser.IQCasesOpenCase) SetupRank(player, Rank.Key);
                            break;
                        }
                    case Obtaining.IQHeadReward:
                        {
                            if (!IQHeadReward) return;
                            if (ObtainingSetup.ObtainingsIQHeadRewards.KillHeadAmount <= Data.InformationUser.IQHeadRewardKillAmount) SetupRank(player, Rank.Key);
                            break;
                        }
                    case Obtaining.IQEconomic:
                        {
                            if (!IQEconomic) return;
                            if (ObtainingSetup.ObtainingsIQEconomics.IQEconomicBalance <= Data.InformationUser.IQEconomicAmountBalance) SetupRank(player, Rank.Key);
                            break;
                        }
                }
            }
        }
        void SetupRank(BasePlayer player, string RankKey)
        {
            var Data = DataInformation[player.userID];
            string NameRank = config.RankList[RankKey].DisplayNameRank;
            var GeneralSetting = config.Setting.GeneralSetting;
            Data.RankAccessList.Add(RankKey);
            SendChat(player, GetLang("RANK_NEW", player.UserIDString, NameRank));
            if (GeneralSetting.RankSetupNew) Data.RankActive = RankKey;
        }
        public void TrackerTime()
        {
            timer.Every(60f, () => {
                foreach (var player in BasePlayer.activePlayerList)
                {
                    if (!DataInformation.ContainsKey(player.userID)) RegisteredDataUser(player.userID);
                    else DataInformation[player.userID].InformationUser.TimeGame += 60;
                    RankAccess(player);
                }
            });
        }
        void RankSetUp(BasePlayer player, string RankName)
        {
            var Data = DataInformation[player.userID];
            string RankKey = config.RankList.FirstOrDefault(r => r.Value.DisplayNameRank.Contains(RankName)).Key;
            if (String.IsNullOrWhiteSpace(RankName) || String.IsNullOrWhiteSpace(RankKey) || !Data.RankAccessList.Contains(RankKey))
            {
                SendChat(player, GetLang("COMMAND_RANK_LIST_NO_ANY", player.UserIDString));
                return;
            }
            Data.RankActive = RankKey;
            SendChat(player, GetLang("COMMAND_RANK_LIST_TO_ACTIVE", player.UserIDString, config.RankList[RankKey].DisplayNameRank));
        }
        public static string FormatTime(TimeSpan time)
        {
            string result = string.Empty;
            if (time.Days != 0) result = $"{Format(time.Days, "дней", "дня", "день")}";
            if (time.Hours != 0 && time.Days == 0) result = $"{Format(time.Hours, "часов", "часа", "час")}";
            if (time.Minutes != 0 && time.Hours == 0 && time.Days == 0) result = $"{Format(time.Minutes, "минут", "минуты", "минута")}";
            if (time.Seconds != 0 && time.Days == 0 && time.Minutes == 0 && time.Hours == 0) result = $"{Format(time.Seconds, "секунд", "секунды", "секунда")}";
            return result;
        }
        private static string Format(int units, string form1, string form2, string form3)
        {
            var tmp = units % 10;
            if (units >= 5 && units <= 20 || tmp >= 5 && tmp <= 9) return $"{units} {form1}";
            if (tmp >= 2 && tmp <= 4) return $"{units} {form2}";
            return $"{units} {form3}";
        }
        [ChatCommand("rank")]
        void ChatRankCommand(BasePlayer player, string cmd, string[] arg)
        {
            if (arg.Length == 0 || arg == null)
            {
                SendChat(player, GetLang("COMMAND_RANK_NO_ARG", player.UserIDString));
                return;
            }
            string Action = arg[0];
            switch (Action)
            {
                case "list":
                    {
                        if (!DataInformation.ContainsKey(player.userID) || DataInformation[player.userID].RankAccessList.Count == 0)
                        {
                            SendChat(player, GetLang("COMMAND_RANK_LIST_NO_ACCES", player.UserIDString));
                            return;
                        }
                        StringBuilder RankListString = new StringBuilder();
                        var RankList = DataInformation[player.userID].RankAccessList;
                        foreach (string RankMe in RankList.Where(r => config.RankList.ContainsKey(r)))
                        {
                            string NameRankInConfig = config.RankList[RankMe].DisplayNameRank;
                            RankListString.Append($"\n- {NameRankInConfig}");
                        }
                        SendChat(player, GetLang("COMMAND_RANK_LIST", player.UserIDString, RankListString));
                        break;
                    }
                case "add":
                case "take":
                case "set":
                case "setup":
                    {
                        RankSetUp(player, arg[1]);
                        break;
                    }
                case "remove":
                case "clear":
                case "stop":
                case "revoke":
                    {
                        if (!DataInformation.ContainsKey(player.userID) || String.IsNullOrWhiteSpace(DataInformation[player.userID].RankActive))
                        {
                            SendChat(player, GetLang("COMMAND_RANK_LIST_NO_CLEAR", player.UserIDString));
                            return;
                        }
                        DataInformation[player.userID].RankActive = string.Empty;
                        SendChat(player, GetLang("COMMAND_RANK_LIST_CLEAR", player.UserIDString));
                        break;
                    }
            }
        }
        private new void LoadDefaultMessages()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["RANK_NEW"] = "Поздравляем, вы получили ранг {0}",
                ["COMMAND_RANK_NO_ARG"] = "\n<size=15>Используйте синтаксис</size>\n- rank list - список доступных рангов" + "\n- rank add НазваниеРанга - устанавливает нужнный вам ранг" + "\n- rank remove - очищает ваш активный ранг",
                ["COMMAND_RANK_LIST"] = "\n<size=15>Список доступных рангов:</size>{0}",
                ["COMMAND_RANK_LIST_NO_ACCES"] = "У вас нет доступных рангов",
                ["COMMAND_RANK_LIST_NO_ANY"] = "Вы ввели неправильно название ранга , либо такого ранга у вас нет",
                ["COMMAND_RANK_LIST_TO_ACTIVE"] = "Вы успешно установили себе ранг: {0}",
                ["COMMAND_RANK_LIST_NO_CLEAR"] = "У вас нет установленного ранга",
                ["COMMAND_RANK_LIST_CLEAR"] = "Вы успешно очистили ранг",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["RANK_NEW"] = "Поздравляем, вы получили ранг {0}",
                ["COMMAND_RANK_NO_ARG"] = "\n<size=15>Используйте синтаксис</size>\n- rank list - список доступных рангов" + "\n- rank add НазваниеРанга - устанавливает нужнный вам ранг" + "\n- rank remove - очищает ваш активный ранг",
                ["COMMAND_RANK_LIST"] = "\n<size=15>Список доступных рангов:</size>{0}",
                ["COMMAND_RANK_LIST_NO_ACCES"] = "У вас нет доступных рангов",
                ["COMMAND_RANK_LIST_NO_ANY"] = "Вы ввели неправильно название ранга , либо такого ранга у вас нет",
                ["COMMAND_RANK_LIST_TO_ACTIVE"] = "Вы успешно установили себе ранг: {0}",
                ["COMMAND_RANK_LIST_NO_CLEAR"] = "У вас нет установленного ранга",
                ["COMMAND_RANK_LIST_CLEAR"] = "Вы успешно очистили ранг",
            }, this, "ru");
            PrintWarning("Языковой файл загружен успешно");
        }
        string API_GET_RANK_NAME(ulong userID)
        {
            string Rank = DataInformation[userID].RankActive;
            if (!config.RankList.ContainsKey(Rank)) return null;
            string RankDisplayName = config.RankList[Rank].DisplayNameRank;
            return RankDisplayName;
        }
        string API_GET_RANK_NAME(string Key)
        {
            if (!config.RankList.ContainsKey(Key)) return null;
            string Rank = config.RankList[Key].DisplayNameRank;
            return Rank;
        }
        void API_ADD_RANK(UInt64 userID, String Key)
        {
            if (!DataInformation.ContainsKey(userID)) return;
            if (!API_IS_RANK_REALITY(Key)) return;
            DataInformation[userID].RankAccessList.Add(Key);
        }
        bool API_IS_RANK_REALITY(string Key)
        {
            if (!config.RankList.ContainsKey(Key)) return false;
            else return true;
        }
        string API_GET_RANK_PERM(string Key)
        {
            if (!config.RankList.ContainsKey(Key)) return null;
            string RankPermission = config.RankList[Key].PermissionRank;
            return RankPermission;
        }
        bool API_GET_RANK_ACCESS(ulong userID, string Key)
        {
            if (!config.RankList.ContainsKey(Key)) return false;
            string RankPermission = config.RankList[Key].PermissionRank;
            if (String.IsNullOrWhiteSpace(RankPermission)) return true;
            return permission.UserHasPermission(userID.ToString(), RankPermission);
        }
        bool API_GET_AVAILABILITY_RANK_USER(ulong userID, string Key)
        {
            if (!config.RankList.ContainsKey(Key)) return false;
            if (!DataInformation.ContainsKey(userID)) return false;
            var RankAccesList = DataInformation[userID].RankAccessList;
            return RankAccesList.Contains(Key);
        }
        string API_GET_TIME_GAME(ulong userID)
        {
            if (!config.Setting.GeneralSetting.ShowTimeGame) return "";
            string TimeGame = FormatTime(TimeSpan.FromSeconds(DataInformation[userID].InformationUser.TimeGame));
            return TimeGame;
        }
        int API_GET_SECONDGAME(ulong userID)
        {
            string Rank = DataInformation[userID].RankActive;
            if (!config.RankList.ContainsKey(Rank)) return 0;
            int SecondGame = DataInformation[userID].InformationUser.TimeGame;
            return SecondGame;
        }
        List<string> API_RANK_USER_KEYS(ulong userID)
        {
            if (!DataInformation.ContainsKey(userID)) return null;
            List<string> RankList = DataInformation[userID].RankAccessList;
            return RankList;
        }
        void API_SET_ACTIVE_RANK(ulong userID, string RankKey)
        {
            if (!DataInformation.ContainsKey(userID)) return;
            if (String.IsNullOrWhiteSpace(RankKey)) return;
            if (!config.RankList.ContainsKey(RankKey)) return;
            var Data = DataInformation[userID];
            Data.RankActive = RankKey;
            BasePlayer player = BasePlayer.FindByID(userID);
            if (player != null) SendChat(player, GetLang("COMMAND_RANK_LIST_TO_ACTIVE", player.UserIDString, config.RankList[RankKey].DisplayNameRank));
        }
    }
}