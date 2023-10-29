/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ using UnityEngine;
using System;
using Oxide.Game.Rust.Cui;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rust;
using System.Text;
using System.Globalization;
using System.Collections;
using UnityEngine.Networking;
using Oxide.Core.Libraries;
using System.Text.RegularExpressions;
using Epic.OnlineServices.Connect;

namespace Oxide.Plugins
{
    [Info("XDStatistics", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class XDStatistics : RustPlugin
    {
        [PluginReference] Plugin ImageLibrary, Friends, Clans, Battles, Duel, Economics, IQEconomic, ServerRewards, GameStoresRUST, RustStore;
        private bool EUZRIAXIWDUOKLVDAJKBNXVNJXIULYDJKIJEHJOCZNEGO(ulong userID, ulong targetID)
        {
            if (Friends) return (bool)Friends?.Call("HasFriend", userID, targetID);
            else if (RelationshipManager.ServerInstance.playerToTeam.ContainsKey(userID) && RelationshipManager.ServerInstance.playerToTeam[userID].members.Contains(targetID)) return true;
            else return false;
        }
        private bool XOFXRZDZZGYMIKRDWYZLEBBRWQVIBASPYPAUPNGEGKJCFUB(string userID, string targetID)
        {
            if (Clans)
            {
                String CPGNVKYODRJIVZNXGGKHYDGXPGWFAHULSFYJOSTFSCRJFFAI = (String)Clans?.Call("GetClanOf", userID);
                String XTTKFYZIIYOOTOVXYQQADIONEPWLXSKGNIDOABMGZAFUERYN = (String)Clans?.Call("GetClanOf", targetID);
                if (CPGNVKYODRJIVZNXGGKHYDGXPGWFAHULSFYJOSTFSCRJFFAI == null && XTTKFYZIIYOOTOVXYQQADIONEPWLXSKGNIDOABMGZAFUERYN == null) return false;
                return (bool)(CPGNVKYODRJIVZNXGGKHYDGXPGWFAHULSFYJOSTFSCRJFFAI == XTTKFYZIIYOOTOVXYQQADIONEPWLXSKGNIDOABMGZAFUERYN);
            }
            else return false;
        }
        private bool KWQGGDPVMNBADUYZNJOSKXNJRVETSYLBPRXEKMIUZ(ulong userID)
        {
            if (Battles) return (bool)Battles?.Call("IsPlayerOnBattle", userID);
            else if (Duel) return (bool)Duel?.Call("IsPlayerOnActiveDuel", BasePlayer.FindByID(userID));
            else return false;
        }
        private static XDStatistics _;
        private readonly string LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ = "XDStatistics.admin";
        private readonly string FWQNCPPKKAGQLLXSASYYFSMTVWXBAIEPMNNMWCGAWALVA = "XDStatistics.reset";
        private readonly string DYXDVMORKNKXRGRNJBWQDYXKVXMXCEHQTXSZEXNRBVDACZKZI = "XDStatistics.availability";
        private enum CatType
        {
            score,
            killer,
            time,
            AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO,
            JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL,
            killerNPC,
            MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT
        }
        private Dictionary<string, ItemDisplayName> _itemName = new Dictionary<string, ItemDisplayName>();
        private List<items> ItemList = new List<items>();
        public static StringBuilder QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP;
        private Dictionary<uint, string> _prefabID2Item = new Dictionary<uint, string>();
        private Dictionary<string, string> _prefabNameItem = new Dictionary<string, string>()
        {
            ["40mm_grenade_he"] = "multiplegrenadelauncher",
            ["grenade.beancan.deployed"] = "grenade.beancan",
            ["grenade.f1.deployed"] = "grenade.f1",
            ["explosive.satchel.deployed"] = "explosive.satchel",
            ["explosive.timed.deployed"] = "explosive.timed",
            ["rocket_basic"] = "ammo.rocket.basic",
            ["rocket_hv"] = "ammo.rocket.hv",
            ["rocket_fire"] = "ammo.rocket.fire",
            ["survey_charge.deployed"] = "surveycharge"
        };
        private List<int> SLFXUIVPMPZEWUUMKEDLJMAVRICURZUQXXMECXBZBXAATJ = new List<int>() {
      1548091822,
      1771755747,
      1112162468,
      1367190888,
      858486327,
      -1962971928,
      -2086926071,
      -567909622,
      1272194103,
      854447607,
      1660145984,
      1783512007,
      -858312878
    };
        public List<String> WPQDTOEGFKJGMGBXMUIGZHQJMDEKMMZCHIFEBWBC = new List<String> {
      "BarrelImage",
      "AnimalImage",
      "NpcImage",
      "CrateImage",
      "HeliImage",
      "BradleyImage",
    };
        protected override void LoadDefaultMessages()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["STAT_TOP_FIVE_KILL"] = "Top 5 <color=#4286f4>Killers</color>\n{0}</size>",
                ["STAT_TOP_FIVE_KILL_NPC"] = "Top 5 <color=#4286f4>NPC killers</color>\n{0}</size>",
                ["STAT_TOP_FIVE_FARM"] = "Top 5 <color=#4286f4>Farmers</color>\n{0}</size>",
                ["STAT_TOP_FIVE_EXPLOSION"] = "Top 5 <color=#4286f4>Explosions</color>\n{0}</size>",
                ["STAT_TOP_FIVE_TIMEPLAYED"] = "Top 5 <color=#4286f4>Most Time Played</color>\n{0}</size>",
                ["STAT_TOP_FIVE_BUILDINGS"] = "Top 5 <color=#4286f4>Builders</color>\n{0}</size>",
                ["STAT_TOP_FIVE_SCORE"] = "Top 5 <color=#4286f4>Most points</color>\n{0}</size>",
                ["STAT_TOP_FIVE_FERMER"] = "Top 5 <color=#4286f4>Farmers</color>\n{0}</size>",
                ["STAT_USER_TOTAL_GATHERED"] = "Total Gathered:",
                ["STAT_USER_TOTAL_EXPLODED"] = "Total Explosions:",
                ["STAT_USER_TOTAL_GROWED"] = "Total Farmed:",
                ["STAT_UI_MY_STAT"] = "STATS",
                ["STAT_UI_TOP_TEN"] = "TOP-10",
                ["STAT_UI_SEARCH"] = "SEARCH",
                ["STAT_UI_INFO"] = "Player Information {0}",
                ["STAT_UI_ACTIVITY"] = "Activity",
                ["STAT_UI_ACTIVITY_TODAY"] = "Today: {0}",
                ["STAT_UI_ACTIVITY_TOTAL"] = "All Time: {0}",
                ["STAT_UI_SETTINGS"] = "Settings",
                ["STAT_UI_PLACE_TOP"] = "Place On Top: {0}",
                ["STAT_UI_SCORE"] = "Score: {0}",
                ["STAT_UI_PVP"] = "PvP Statistics",
                ["STAT_UI_FAVORITE_WEAPON"] = "Favorite Weapon",
                ["STAT_UI_PVP_KILLS"] = "Kills",
                ["STAT_UI_PVP_KILLS_NPC"] = "Kills NPC",
                ["STAT_UI_PVP_DEATH"] = "Deaths",
                ["STAT_UI_PVP_KDR"] = "K/D",
                ["STAT_UI_FAVORITE_WEAPON_KILLS"] = "Kills: {0}\nHits: {1}",
                ["STAT_UI_FAVORITE_WEAPON_NOT_DATA"] = "Data is still being calculated..",
                ["STAT_UI_OTHER_STAT"] = "Other Statistics",
                ["STAT_UI_HIDE_STAT"] = "Public Profile",
                ["STAT_UI_CONFIRM"] = "Are You Sure?",
                ["STAT_UI_CONFIRM_YES"] = "Yes",
                ["STAT_UI_CONFIRM_NO"] = "No",
                ["STAT_UI_RESET_STAT"] = "Reset Statistics",
                ["STAT_UI_CRATE_OPEN"] = "Crates Opened: {0}",
                ["STAT_UI_BARREL_KILL"] = "Barrels Destroyed: {0}",
                ["STAT_UI_ANIMAL_KILL"] = "Animal Kills: {0}",
                ["STAT_UI_HELI_KILL"] = "Helicopter Kills: {0}",
                ["STAT_UI_BRADLEY_KILL"] = "Bradley Kills: {0}",
                ["STAT_UI_NPC_KILL"] = "NPC Kills: {0}",
                ["STAT_UI_BTN_MORE"] = "Show More",
                ["STAT_UI_CATEGORY_GATHER"] = "Gather",
                ["STAT_UI_CATEGORY_EXPLOSED"] = "Explosions",
                ["STAT_UI_CATEGORY_PLANT"] = "Farming",
                ["STAT_UI_CATEGORY_TOP_KILLER"] = "Top 10 Killers",
                ["STAT_UI_CATEGORY_TOP_KILLER_ANIMALS"] = "Top 10 Animal Killers",
                ["STAT_UI_CATEGORY_TOP_NPCKILLER"] = "Top 10 NPC Killers",
                ["STAT_UI_CATEGORY_TOP_TIME"] = "Top 10 Most Time Played",
                ["STAT_UI_CATEGORY_TOP_GATHER"] = "Top 10 Gatherers",
                ["STAT_UI_CATEGORY_TOP_SCORE"] = "Top 10 Most Score",
                ["STAT_UI_CATEGORY_TOP_EXPLOSED"] = "Top 10 Explosions",
                ["STAT_PRINT_WIPE"] = "Wipe Detected. Data was successfully cleared!",
                ["STAT_CMD_1"] = "No Permission!!",
                ["STAT_CMD_2"] = "Usage: stat.ignore <add/remove> <Steam ID|Name>",
                ["STAT_CMD_3"] = "The specified playername could not be found. Please use their SteamID.",
                ["STAT_CMD_4"] = "Found several players with similar names: {0}",
                ["STAT_CMD_5"] = "Player not found!",
                ["STAT_CMD_6"] = "Player {0} is already ignored",
                ["STAT_CMD_7"] = "You have successfully added a player {0} to the ignore list",
                ["STAT_CMD_8"] = "The player {0} is not in the ignore list",
                ["STAT_CMD_9"] = "You have successfully removed the player {0} from the ignore list",
                ["STAT_CMD_10"] = "Player {0} successfully credited {1} score",
                ["STAT_CMD_11"] = "Player {0} successfully removed {1} score",
                ["STAT_ADMIN_HIDE_STAT"] = "You've been added to the ignore list. You will not have access to the statistics. If this is an error, Please contact the Administrator!",
                ["STAT_TOP_PLAYER_WIPE_SCORE"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>HIGHEST SCORE</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_TIME"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>MOST TIME PLAYED</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_EXP"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>MOST EXPLOSIONS</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_FARM"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>MOST CROPS FARMED</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_KILL"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>MOST KILLS</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_KILL_NPC"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>NPC Killer</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_PLAYER_WIPE_KILL_ANIMAL"] = "Congratulations!\nYou successfully held the {0} position in the previous wipe in the category <color=#4286f4>ANIMAL Killer</color>\nYou received a well deserved Reward!",
                ["STAT_TOP_VK_SCORE"] = "Топ {0} игрока по очкам\n {1}",
                ["STAT_TOP_VK_KILLER"] = "Топ {0} игрока по убийствам\n {1}",
                ["STAT_TOP_VK_TIME"] = "Топ {0} игрока по онлайну\n {1}",
                ["STAT_TOP_VK_FARM"] = "Топ {0} игрока по фарму\n {1}",
                ["STAT_TOP_VK_RAID"] = "Топ {0} игрока по рейдам\n {1}",
                ["STAT_TOP_VK_KILLER_NPC"] = "Топ {0} игрока по убийствам NPC\n {1}",
                ["STAT_TOP_VK_KILLER_ANIMAL"] = "Топ {0} игрока по убийствам животных\n {1}",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["STAT_TOP_FIVE_KILL"] = "Топ 5 <color=#4286f4>киллеры</color>\n{0}</size>",
                ["STAT_TOP_FIVE_KILL_NPC"] = "Топ 5 <color=#4286f4>убийцы NPC</color>\n{0}</size>",
                ["STAT_TOP_FIVE_FARM"] = "Топ 5 <color=#4286f4>фармеры</color>\n{0}</size>",
                ["STAT_TOP_FIVE_EXPLOSION"] = "Топ 5 <color=#4286f4>рейдеры</color>\n{0}</size>",
                ["STAT_TOP_FIVE_TIMEPLAYED"] = "Топ 5 <color=#4286f4>долгожителей</color>\n{0}</size>",
                ["STAT_TOP_FIVE_BUILDINGS"] = "Топ 5 <color=#4286f4>строители</color>\n{0}</size>",
                ["STAT_TOP_FIVE_SCORE"] = "Топ 5 по <color=#4286f4>очкам</color>\n{0}</size>",
                ["STAT_TOP_FIVE_FERMER"] = "Топ 5 <color=#4286f4>фермеров</color>\n{0}</size>",
                ["STAT_USER_TOTAL_GATHERED"] = "Всего добыто:",
                ["STAT_USER_TOTAL_EXPLODED"] = "Всего взорвано:",
                ["STAT_USER_TOTAL_GROWED"] = "Всего выращено:",
                ["STAT_UI_MY_STAT"] = "СТАТИСТИКА",
                ["STAT_UI_TOP_TEN"] = "ТОП-10",
                ["STAT_UI_SEARCH"] = "ПОИСК",
                ["STAT_UI_INFO"] = "Информация о профиле {0}",
                ["STAT_UI_ACTIVITY"] = "Активность",
                ["STAT_UI_ACTIVITY_TODAY"] = "Сегодня: {0}",
                ["STAT_UI_ACTIVITY_TOTAL"] = "За все время: {0}",
                ["STAT_UI_SETTINGS"] = "Настройки",
                ["STAT_UI_PLACE_TOP"] = "Место в топе: {0}",
                ["STAT_UI_SCORE"] = "SCORE: {0}",
                ["STAT_UI_PVP"] = "PVP статистика",
                ["STAT_UI_FAVORITE_WEAPON"] = "Фаворитное оружие",
                ["STAT_UI_PVP_KILLS"] = "Убийств",
                ["STAT_UI_PVP_KILLS_NPC"] = "Убийств NPC",
                ["STAT_UI_PVP_DEATH"] = "Смертей",
                ["STAT_UI_PVP_KDR"] = "K/D",
                ["STAT_UI_FAVORITE_WEAPON_KILLS"] = "Убийств: {0}\nПопаданий: {1}",
                ["STAT_UI_FAVORITE_WEAPON_NOT_DATA"] = "Данные еще собираются...",
                ["STAT_UI_OTHER_STAT"] = "Другая статистика",
                ["STAT_UI_HIDE_STAT"] = "Общедоступный профиль",
                ["STAT_UI_CONFIRM"] = "Вы уверены ?",
                ["STAT_UI_CONFIRM_YES"] = "Да",
                ["STAT_UI_CONFIRM_NO"] = "Нет",
                ["STAT_UI_RESET_STAT"] = "Обнулить статистику",
                ["STAT_UI_CRATE_OPEN"] = "Открыто ящиков: {0}",
                ["STAT_UI_BARREL_KILL"] = "Разбито бочек: {0}",
                ["STAT_UI_ANIMAL_KILL"] = "Убито животных: {0}",
                ["STAT_UI_HELI_KILL"] = "Сбито вертолетов: {0}",
                ["STAT_UI_BRADLEY_KILL"] = "Танков уничтожено: {0}",
                ["STAT_UI_NPC_KILL"] = "Убито NPC: {0}",
                ["STAT_UI_BTN_MORE"] = "Показать еще",
                ["STAT_UI_CATEGORY_GATHER"] = "Добыча",
                ["STAT_UI_CATEGORY_EXPLOSED"] = "Взрывчатка",
                ["STAT_UI_CATEGORY_PLANT"] = "Фермерство",
                ["STAT_UI_CATEGORY_TOP_KILLER"] = "Топ 10 киллеров",
                ["STAT_UI_CATEGORY_TOP_KILLER_ANIMALS"] = "Топ 10 убийц животных",
                ["STAT_UI_CATEGORY_TOP_NPCKILLER"] = "Топ 10 убийц npc",
                ["STAT_UI_CATEGORY_TOP_TIME"] = "Топ 10 по онлайну",
                ["STAT_UI_CATEGORY_TOP_GATHER"] = "Топ 10 фармил",
                ["STAT_UI_CATEGORY_TOP_SCORE"] = "Топ 10 по очкам",
                ["STAT_UI_CATEGORY_TOP_EXPLOSED"] = "Топ 10 рейдеров",
                ["STAT_PRINT_WIPE"] = "Произошел вайп. Данные успешно удалены!",
                ["STAT_CMD_1"] = "Недостаточно прав!",
                ["STAT_CMD_2"] = "Используйте: stat.ignore <add/remove> <Steam ID|Имя>",
                ["STAT_CMD_3"] = "Указанный игрок не найден. Для более точного поиска укажите его SteamID.",
                ["STAT_CMD_4"] = "Найдено несколько игроков с похожим именем: {0}",
                ["STAT_CMD_5"] = "Игрок не найден!",
                ["STAT_CMD_6"] = "Игрок {0} уже игнорируется",
                ["STAT_CMD_7"] = "Вы успешно добавили игрока {0} в игнор лист",
                ["STAT_CMD_8"] = "Игрока {0} нет в списке игнорируемых",
                ["STAT_CMD_9"] = "Вы успешно убрали игрока {0} из игнор листа",
                ["STAT_CMD_10"] = "Игроку {0} успешно зачислено {1} очков",
                ["STAT_CMD_11"] = "Игроку {0} успешно снято {1} очков",
                ["STAT_ADMIN_HIDE_STAT"] = "Вы добавлены в игнор лист. У вас нет доступа к статистики, если это ошибка, свяжитесь с администратором!",
                ["STAT_TOP_PLAYER_WIPE_SCORE"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>SCORE</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_TIME"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Долгожитель</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_EXP"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Рейдер</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_FARM"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Добытчик</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_KILL"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Киллер</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_KILL_NPC"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Убийца нпс</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_PLAYER_WIPE_KILL_ANIMAL"] = "Поздравляю!\nВ прошлом вайпе вы успешно удерживали {0} позицию в категории <color=#4286f4>Убийца животных</color>\nВы заслужено получаете награду!",
                ["STAT_TOP_VK_SCORE"] = "Топ {0} игрока по очкам\n {1}",
                ["STAT_TOP_VK_KILLER"] = "Топ {0} игрока по убийствам\n {1}",
                ["STAT_TOP_VK_TIME"] = "Топ {0} игрока по онлайну\n {1}",
                ["STAT_TOP_VK_FARM"] = "Топ {0} игрока по фарму\n {1}",
                ["STAT_TOP_VK_RAID"] = "Топ {0} игрока по рейдам\n {1}",
                ["STAT_TOP_VK_KILLER_NPC"] = "Топ {0} игрока по убийствам NPC\n {1}",
                ["STAT_TOP_VK_KILLER_ANIMAL"] = "Топ {0} игрока по убийствам животных\n {1}",
            }, this, "ru");
        }
        private Configuration QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE;
        private class Configuration
        {
            public class SettingsInterface
            {
                [JsonProperty("Цвет плашки заднего фона в топ 10 за 1 место | Background color in the top 10for 1st place")] public string PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL = "1 0.95 0 1";
                [JsonProperty("Цвет плашки заднего фона в топ 10 за 2 место | Background color in the top 10for 2st place")] public string OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD = "0 0 1 1";
                [JsonProperty("Цвет плашки заднего фона в топ 10 за 3 место | Background color in the top 10for 3st place")] public string KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA = "0.90 0.59 0.19 1";
            }
            public class DiscordMessage
            {
                [JsonProperty("Отправлять в дискорд топ 5 лучших игроков в разных категориях ? | Send the top 5 best players in different categories to discord ?")] public bool LLOENKMINHOIPEMWLFMZKERWRKKVTLXPUMUMBKGA = false;
                [JsonProperty("Раз в сколько секунд будет отправлятся сообщение ? | Once in how many seconds will a message be sent ?")] public int FESOJEZHDNKXARGURMDZQOBKZODKZUAYMUFZYHIFLN = 600;
                [JsonProperty("ВебХук дискорда | Discord WebHook")] public string XNRUVNSKXCAOQDIPUBPIIMLKFLHWJEXODYEXHTHWHKCWLF = string.Empty;
                [JsonProperty("Цвет линии в сообщения или несколько | The color of the line in the message or several", ObjectCreationHandling = ObjectCreationHandling.Replace)]
                public int[] WPSNEWFHLBHOJGVATFMLSYLIBTSAYJPZZXKGRRSSXQSVA = new int[] {
          53380,
          9359868,
          11253955
        };
                [JsonProperty("Дополнительный текст к сообщению | Additional text to the message")] public string message = string.Empty;
            }
            public class Settings
            {
                [JsonProperty("Отправлять в чат сообщения с топ 5 игроками в разных категориях | Send chat messages with top 5 players in different categories")] public bool BNBGFHPSGQISQLUWAIEFGTROCPPAQVCOIJKINDVFEV = true;
                [JsonProperty("Раз в сколько секунд будет отправлятся сообщение ? | Once in how many seconds will a message be sent ?")] public int PHQFKISOQUUYHVNDQROBLOTJHALIWNYALYBGMJFRYGLUNKDN = 600;
                [JsonProperty("Включить возможность сбросить свою статистику ? (требуется XDStatistics.reset) | Enable the ability to reset your stats ? (requires XDStatistics.reset)")] public bool ZENQTJBNGYJXJRDVTNJUGRGMWDFCZVWXYIXILKRP = false;
                [JsonProperty("Включить возможность скрыть свою статистику от пользователей ? (требуется XDStatistics.availability) | Enable the ability to hide your statistics from users ? (requires XDStatistics.availability)")] public bool SGLWUOPHZUWTTTHYATQEZOKBLZBUVKJWUUOLVQCOQUABZDEOP = true;
                [JsonProperty("очищать данные при вайпе | Clear data when wiped")] public bool KQALAEVJKVNVLOKAZYFWCKRCOENIBHUMELZSWJTJPLG = true;
                [JsonProperty("Раз во сколько минут будут сохранятся данные | Once in a rowman, the data will be saved.")] public int AUILQZEFJSHZYYXWQNHCAAQAOREQFVHREKBTVCSCDO = 30;
                [JsonProperty("Учитывать убийство npc для фаворитного оружия ? | Consider killing an NPC for a favorite weapon ?")] public bool LEAUXMXTCDDGAEIWYVNANLPVOWDAOVFZMXFVOXGEH = false;
                [JsonProperty("У вас PVE сервер ?  | You have a PVE server?")] public bool FNAEBONFTHPOQZOEFBIXFHYEUDYNHBOJSKGCVKVPM = false;
                [JsonProperty("Список игроков, которые не будут включены в статистику (SteamID) | List of players who will not be included in the statistics (SteamID)", ObjectCreationHandling = ObjectCreationHandling.Replace)] public List<ulong> BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI = new List<ulong>();
            }
            public class SettingsScore
            {
                [JsonProperty("Очки за крафт | Points for crafting")] public float NHNINZAXZMKJFDCBMTBXZCAASPANBWTBJJSNSKZJUIU = 1;
                [JsonProperty("Очки за бочки | Points for barrels")] public float MVTRUUHMVLKKHMQXYNWCTJAWLOJBURCQICNXVITGPGFXYHGFU = 1;
                [JsonProperty("Очки за установку строительных блоков | Points for installing building blocks")] public float KGMREDUXGFLFSEJTCEZTBPUPNNDDXEIDHRGWEQYJ = 1;
                [JsonProperty("Очки за использования взрывчатых предметов | Points for using explosive items")] public Dictionary<string, float> YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ = new Dictionary<string, float>();
                [JsonProperty("Очки за добычу ресурсов | Points for resource extraction")] public Dictionary<string, float> PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR = new Dictionary<string, float>();
                [JsonProperty("Очки за найденные скрап | Points for found scraps")] public float LDGYYGFCMPIRMYNBEMHWSEEGLQLJTXCCUCTYKVWJEWV = 0.5f;
                [JsonProperty("Очки за сбор урожая (с плантации) | Points for harvesting (from the plantation)")] public float TJEZOFYCDURGYZNIUVJOMGWJFPQIPXSWIONBLLVOYAZALM = 0.2f;
                [JsonProperty("Очки за убийство животных | Points for killing animals")] public float LIOOJMGENMVUYOQNFCVYKMLWJAVQMHWYTPFAAIJJBJAPQRWZI = 1;
                [JsonProperty("Очки за сбитие вертолета | Points for shooting down a helicopter")] public float TYQOPZXRFIRQRFPWBIIPNXSLWALVGSDVHZNYIEAGDICA = 5;
                [JsonProperty("Очки за взрыв танка | Points for tank explosion")] public float LRUZTPOQSZWFESONBKNFVISSROWICMEUSTKIRWNCPEPZRS = 5;
                [JsonProperty("Очки за убийство нпс | Points for killing NPCs")] public float MLTCXPUWCZCHFSFOGVBMLHGWEXLQQTSAZLJXJKGFY = 5;
                [JsonProperty("Очки за убийство игроков | Points for killing players")] public float IJOOIJJQJEPFRFFWXAEDFJHBITJIEVOWOOZXHPPBGAKNLTTE = 10;
                [JsonProperty("Очки за время (За кажду. минуту игры на сервере) | Points for time (for every minute of the game on the server)")] public float MMGBURZCNGOABLNQSQDGIPHKCWFYTPOAEQSJHVUWAUTJAA = 0.2f;
                [JsonProperty("Сколько отнять очков за суицид ? | How many points to take away for suicide ?")] public float OWXTDPXJWEWYXMAIYSNVKTEIWVHGNWYJCRQCWWKLGH = 2;
                [JsonProperty("Сколько отнять очков за смерть ? | How many points to take away for death ?")] public float ELXXJZMVQNEVVSOWHHRWAGMVGVYMBHCODXAXZYXGBAHWXWVK = 1;
                [JsonProperty("Черный список ресусов и взрывчатых предметов | Blacklist of resources and explosive items", ObjectCreationHandling = ObjectCreationHandling.Replace)]
                public List<string> ADDPLVXZBRNBZUJKPRYRRWJKLUZYPYKANEBDZZSBCYY = new List<string> {
          "ammo.rifle.explosive"
        };
            }
            public class SettingsPrize
            {
                [JsonProperty("Использовать выдачу награды после вайпа ? | Use the award issue after the wipe ?")] public bool JEBGYMHEXSQDUTEQWZJCHNNVSFLQYXPTYBAGTSZDQF = false;
                [JsonProperty("Награда в категории SCORE | Award in the SCORE category")] public List<Prize> VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW = new List<Prize>();
                [JsonProperty("Награда в категории Киллер | Award in the Killer category")] public List<Prize> MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG = new List<Prize>();
                [JsonProperty("Награда в категории Фармила | Award in the gathering category")] public List<Prize> QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM = new List<Prize>();
                [JsonProperty("Награда в категории рейдер | Reward in the Raider category")] public List<Prize> UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH = new List<Prize>();
                [JsonProperty("Награда в категории Большой онлайн | Award in the Big Online category")] public List<Prize> TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI = new List<Prize>();
                [JsonProperty("Награда в категории Убийца НПС | Reward in the NPC Killer category")] public List<Prize> HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV = new List<Prize>();
                [JsonProperty("Награда в категории убица животных | Award in the Animal killer category")] public List<Prize> KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA = new List<Prize>();
                [JsonProperty("[RU][GameStores] ID магазина")] public string HQVBNTNKXUKHZTDFIQJZXAAHWFGXUMIWAKAQFLLPRLUH = "";
                [JsonProperty("[RU][GameStores] ID сервера")] public string NUNYGWVNBNGQOEIMQQLMOGOTMAWFUILGSJILSYOPNIZXTAQHC = "";
                [JsonProperty("[RU][GameStores] Секретный ключ")] public string AUIVIHFUMFZPTSBAYEVWUSCVZGGRZLJPCRHQXWBBG = "";
                internal class Prize
                {
                    [JsonProperty("Использовать комманды в виде приза ? | Use command as a prize ?")] public bool LIQXPGVTCMLGIISNWCBOVBWKNBLLCBDUQWGTFCQZVGIXDWJZY = true;
                    [JsonProperty("За какое место давать эту награду ? (от 1 до 3) если не нужно награждать эту категорию. удалите все награды | For which place to give this award ? (from 1 to 3) if you do not need to award this category. remove all rewards")] public int top = 1;
                    [JsonProperty("[RU]Использовать магазин GameStore для выдачи награды")] public bool AZARCKLGKNVKQBIRPLCYIULBSOSZGRSMNSAEUYTVHYSC = false;
                    [JsonProperty("[RU]Использовать магазин MoscowOVH для выдачи награды")] public bool LQHOMGXWZCGNYZORMZTVJXXAEXRRGQJCIXHYLKUKU = false;
                    [JsonProperty("Использовать [IQEconomic или Economics или ServerRewards] для выдачи награды | Use [IQEconomic or Economics or Server Rewards] to issue a reward")] public bool NPUQVZFEVZZHUNSGKPPFQITEFBRPFCFIAUJHFNBRMCVJD = false;
                    [JsonProperty("Команды для приза | Command for the prize")] public List<string> DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List<string>();
                    [JsonProperty("[RU][GameStores] Сообщения для истории в магазине")] public string LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1!!!";
                    [JsonProperty("[RU][GameStores или MoscowOVH] Сколько начислять денег на баланс")] public int OJTINXXIRPIOXAWKZPGKWJZYRWSJLIYCFTZWDCSATKLFWKB = 30;
                    [JsonProperty("[IQEconomic или Economics или ServerRewards] Сколько начислять денег на баланс | [IQEconomic or Economics or ServerRewards] How much money to add to the balance")] public int XVPHDAXEKVRRENXIQGIDBZHXWGQLYTCGUHMPSQYEWVMI = 100;
                    public void HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(string player)
                    {
                        if (LIQXPGVTCMLGIISNWCBOVBWKNBLLCBDUQWGTFCQZVGIXDWJZY)
                        {
                            foreach (string cmd in DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA) _.Server.Command(cmd.Replace("%STEAMID%", player));
                        }
                        if (AZARCKLGKNVKQBIRPLCYIULBSOSZGRSMNSAEUYTVHYSC && _?.GameStoresRUST)
                        {
                            string AVGMCPPBYJYORLWKLGQTKXXBIPZHDGFNYMVKKYVEMEWY = $"https://gamestores.ru/api?shop_id={_.QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HQVBNTNKXUKHZTDFIQJZXAAHWFGXUMIWAKAQFLLPRLUH}&secret={_.QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.AUIVIHFUMFZPTSBAYEVWUSCVZGGRZLJPCRHQXWBBG}&server={_.QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.NUNYGWVNBNGQOEIMQQLMOGOTMAWFUILGSJILSYOPNIZXTAQHC}&action=moneys&type=plus&steam_id={player}&amount={OJTINXXIRPIOXAWKZPGKWJZYRWSJLIYCFTZWDCSATKLFWKB}&mess={LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL}";
                            _.webrequest.Enqueue(AVGMCPPBYJYORLWKLGQTKXXBIPZHDGFNYMVKKYVEMEWY, "", (code, response) =>
                            {
                                switch (code)
                                {
                                    case 0:
                                        {
                                            _.PrintError("Api does not responded to a request");
                                            break;
                                        }
                                    case 200:
                                        {
                                            break;
                                        }
                                    case 404:
                                        {
                                            _.PrintError($"Please check your configuration! {code}");
                                            break;
                                        }
                                }
                            }, _);
                        }
                        if (LQHOMGXWZCGNYZORMZTVJXXAEXRRGQJCIXHYLKUKU)
                        {
                            if (_?.RustStore)
                            {
                                _.RustStore.CallHook("APIChangeUserBalance", ulong.Parse(player), OJTINXXIRPIOXAWKZPGKWJZYRWSJLIYCFTZWDCSATKLFWKB, new Action<string>(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF =>
                                {
                                    if (LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF == "SUCCESS") return;
                                    Interface.Oxide.LogDebug($"Баланс игрока {ulong.Parse(player)} не был изменен, ошибка: {LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF}");
                                }));
                            }
                        }
                        if (NPUQVZFEVZZHUNSGKPPFQITEFBRPFCFIAUJHFNBRMCVJD)
                        {
                            if (_?.Economics)
                            {
                                _.Economics.Call("Deposit", ulong.Parse(player), (double)XVPHDAXEKVRRENXIQGIDBZHXWGQLYTCGUHMPSQYEWVMI);
                            }
                            else if (_?.IQEconomic)
                            {
                                _.IQEconomic.Call("API_SET_BALANCE", ulong.Parse(player), XVPHDAXEKVRRENXIQGIDBZHXWGQLYTCGUHMPSQYEWVMI);
                            }
                            else if (_?.ServerRewards)
                            {
                                _.ServerRewards.Call("AddPoints", ulong.Parse(player), XVPHDAXEKVRRENXIQGIDBZHXWGQLYTCGUHMPSQYEWVMI);
                            }
                        }
                    }
                }
            }
            [JsonProperty("Основные настройки плагина | Basic plugin settings")] public Settings settings = new Settings();
            [JsonProperty("Настройка выдачи очков | Setting up the issuance of points")] public SettingsScore GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW = new SettingsScore();
            [JsonProperty("Настройка награды топ игрокам в каждой категории | Customize rewards for top 1 players in each category")] public SettingsPrize DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS = new SettingsPrize();
            [JsonProperty("Настройки интерфейса | Interface Settings")] public SettingsInterface ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO = new SettingsInterface();
            [JsonProperty("Настройки дискорд | Discord Settings")] public DiscordMessage LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI = new DiscordMessage();
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE = Config.ReadObject<Configuration>();
                if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE == null) LoadDefaultConfig();
                KPVHYJVDYXVDBUZMVONSVNVLQNYWJCQFPUDMDDONYLD();
                SaveConfig();
            }
            catch (JsonException ex)
            {
                Debug.LogException(ex);
                LoadDefaultConfig();
            }
        }
        private void KPVHYJVDYXVDBUZMVONSVNVLQNYWJCQFPUDMDDONYLD()
        {
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR = new Dictionary<string, float>
                {
                    ["wood"] = 0.3f,
                    ["stones"] = 0.6f,
                    ["metal.ore"] = 1,
                    ["sulfur.ore"] = 1.5f,
                    ["hq.metal.ore"] = 2,
                };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ = new Dictionary<string, float>
                {
                    ["explosive.timed"] = 2,
                    ["explosive.satchel"] = 0.7f,
                    ["grenade.beancan"] = 0.3f,
                    ["grenade.f1"] = 0.1f,
                    ["ammo.rocket.basic"] = 1,
                    ["ammo.rocket.hv"] = 0.5f,
                    ["ammo.rocket.fire"] = 0.7f,
                    ["ammo.rifle.explosive"] = 0.02f,
                };
            }
            if (!QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ.ContainsKey("ammo.rifle.explosive"))
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ.Add("ammo.rifle.explosive", 0.02f);
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории фармер"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории фармер"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории киллер"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории киллер"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории рейдер"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории рейдер"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории больше всего очков"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории больше всего очков"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории большой онлайн"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории большой онлайн"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории убийца NPC"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории убийца NPC"
          },
        };
            }
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA.Count == 0)
            {
                QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA = new List<Configuration.SettingsPrize.Prize> {
          new Configuration.SettingsPrize.Prize {
            DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 1 в категории убийца NPC"
          },
          new Configuration.SettingsPrize.Prize {
            top = 2, DTGEAEUPZEWQLUHQYTTQGZDKBWNYTNNJBEXXJABA = new List < string > {
              "say %STEAMID%"
            }, LUFLPCHJVDCPMUDPVDDRWWLRNOGWKGXRTCVFYZLTGOXJL = "За топ 2 в категории убийца NPC"
          },
        };
            }
        }
        protected override void SaveConfig()
        {
            Config.WriteObject(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE);
        }
        protected override void LoadDefaultConfig()
        {
            QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE = new Configuration();
        }
        private static Dictionary<ulong, PlayerInfo> Players = new Dictionary<ulong, PlayerInfo>();
        private static Dictionary<ulong, PlayerInfo> BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE = new Dictionary<ulong, PlayerInfo>();
        private static Dictionary<ulong, List<PrizePlayer>> UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD = new Dictionary<ulong, List<PrizePlayer>>();
        private class PrizePlayer
        {
            public string Name = string.Empty;
            public CatType HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU;
            public int QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ;
            public int top;
        }
        private class PlayerInfo
        {
            public string Name = string.Empty;
            public bool CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV = false;
            internal string GetPlayerName(ulong steamId) => string.IsNullOrWhiteSpace(Name) ? _.covalence.Players.FindPlayerById(steamId.ToString())?.Name ?? "UNKNOWN" : Name;
            public float Score = 0;
            public Harvesting harvesting = new Harvesting();
            public OtherStat YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ = new OtherStat();
            public Explosion explosion = new Explosion();
            public Gather GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL = new Gather();
            public Weapon weapon = new Weapon();
            public PVP EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ = new PVP();
            public PlayedTime WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU = new PlayedTime();
            internal class PlayedTime
            {
                public string CDZQFGUSFWGFQRBKCHJMKXJPUMEKGTNBPXCJHAKCJBEKBI = DateTime.Now.ToShortDateString();
                public int ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ = 0;
                public int QXPXERAAPSBWSJKULTPEFXLVVJIYLTNHOKBRDFXFGC = 0;
            }
            internal class Harvesting
            {
                public Dictionary<string, int> BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI = new Dictionary<string, int>();
                public int JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD = 0;
            }
            internal class OtherStat
            {
                public int VUEPDWKZSMMQCOGXWHGPZDCMSMDZPQVGNOZCZKTJZWHTL = 0;
                public int MTVVPLJOPSRSXRTKKBRFDNPDYMNWPCWJAJAJETAKXYZ = 0;
                public int KHNCQOMFCGFYERXDXMYMWIRNRKFQBGHEOITQZLGBQQ = 0;
                public int UECFNWWMLZMKBQZLGIVDVYAJVYGEMGXWFCWIPFSUEU = 0;
                public int EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD = 0;
            }
            internal class Explosion
            {
                public Dictionary<string, int> VDDMUSCLTRGHDZCUNJUJLMILNNYXPLITNZFMXMHJSWDPYXIG = new Dictionary<string, int>()
                {
                    ["explosive.timed"] = 0,
                    ["explosive.satchel"] = 0,
                    ["grenade.beancan"] = 0,
                    ["grenade.f1"] = 0,
                    ["ammo.rocket.basic"] = 0,
                    ["ammo.rocket.hv"] = 0,
                    ["ammo.rocket.fire"] = 0,
                    ["ammo.rifle.explosive"] = 0
                };
                public int GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV = 0;
            }
            internal class Gather
            {
                public Dictionary<string, int> FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF = new Dictionary<string, int>()
                {
                    ["wood"] = 0,
                    ["stones"] = 0,
                    ["metal.ore"] = 0,
                    ["sulfur.ore"] = 0,
                    ["hq.metal.ore"] = 0,
                    ["scrap"] = 0,
                };
                public int YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM = 0;
            }
            internal class Weapon
            {
                public Dictionary<string, WeaponInfo> KFHCBVKQJKQSFNUUQMKUUHVSVZUPETTMBAFXRXFPHONRFM = new Dictionary<string, WeaponInfo>();
                internal class WeaponInfo
                {
                    public int Kills = 0;
                    public int LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC = 0;
                    public int BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM = 0;
                }
            }
            internal class PVP
            {
                public int Kills = 0;
                public int GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ = 0;
                public int CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD = 0;
                public int PHSBNIVBVHAXXTDEPREBKWUOEJCJDYCCCXDAKAGRSLRE = 0;
                public int BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM = 0;
                public int LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC = 0;
                public int ETRZRHLUBBSMDXEGLXXFYVAQDUPKNJYFQIAQLJMQQI = 0;
                public int WKNHDCLGOUYHITAWXSAHSCNWVXNVCLGOQVDFPNLH = 0;
            }
            public static void ACHHRTMDCZSHVJBXFZCZGFTELCXPBJOUJXOLZJVPEWX(ulong id)
            {
                var player = Players.ContainsKey(id) ? Players[id] : null;
                if (player == null) return;
                player.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.QXPXERAAPSBWSJKULTPEFXLVVJIYLTNHOKBRDFXFGC++;
                player.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ++;
                player.Score += _.QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.MMGBURZCNGOABLNQSQDGIPHKCWFYTPOAEQSJHVUWAUTJAA;
                if (player.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.CDZQFGUSFWGFQRBKCHJMKXJPUMEKGTNBPXCJHAKCJBEKBI != DateTime.Now.ToShortDateString())
                {
                    player.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.QXPXERAAPSBWSJKULTPEFXLVVJIYLTNHOKBRDFXFGC = 0;
                    player.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.CDZQFGUSFWGFQRBKCHJMKXJPUMEKGTNBPXCJHAKCJBEKBI = DateTime.Now.ToShortDateString();
                }
            }
            public static void QDWDZLXLWMDVJCVPWXCSLXXYUQYVDMVKHXNIFUQPLDYXUTCW(ulong id)
            {
                BasePlayer player = BasePlayer.FindByID(id);
                Players[id] = new PlayerInfo();
                Players[id].Name = player.displayName;
            }
            public static void GTHTEKSFYIINBHJQSNLPMJBGNHHZZDBOBHWTOQCNUDHLI()
            {
                if (BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE != null)
                {
                    BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.Clear();
                }
                if (Players != null)
                {
                    Players.Clear();
                }
            }
            public static PlayerInfo Find(ulong id)
            {
                if (Players.ContainsKey(id))
                {
                    return Players[id];
                }
                if (BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(id))
                {
                    return BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE[id];
                }
                Players.Add(id, new PlayerInfo());
                if (Players.ContainsKey(id))
                {
                    return Players[id];
                }
                return null;
            }
        }
        private void KVOHBFRHBWRBGXCTFUHTMTKQCCLXUJCQXMXMLSCV() => Players = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, PlayerInfo>>("XDStatistics/StatsUser");
        private void TGACNKELBXMEOOQKXEZUTNSTBDUAQHNSLWSNKNPSGLSLQLJX() => Interface.Oxide.DataFileSystem.WriteObject("XDStatistics/StatsUser", Players);
        private void BNNCADGNGBJPEVUKTTRWCAKPGOIVGDPUWTPTZPLTLZ() => BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, PlayerInfo>>("XDStatistics/IgnorePlayers");
        private void MFCBQXBXSRBDADYWLULHDLOTLGAKDHYKDWXJEMRXE() => Interface.Oxide.DataFileSystem.WriteObject("XDStatistics/IgnorePlayers", BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE);
        private void XDVPOQATZYASAAQJQKXRTKSQAEFPRZDNCXOLXVRKJJ() => UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, List<PrizePlayer>>>("XDStatistics/PlayersReward");
        private void ZKLWWSUWHANMNKFPJKLCAVMPCMFMUSMHKBSGOHIWXCV() => Interface.Oxide.DataFileSystem.WriteObject("XDStatistics/PlayersReward", UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD);
        private string[] DKLRARXKNPYQAITXQLFOQEDNKRNPVGKGSFPSCFUG = {
      "OnDispenserGather",
      "OnDispenserBonus",
      "OnCollectiblePickup",
    };
        private void OnPluginLoaded(Plugin plugin)
        {
            NextTick(() =>
            {
                foreach (string hook in DKLRARXKNPYQAITXQLFOQEDNKRNPVGKGSFPSCFUG)
                {
                    Unsubscribe(hook);
                    Subscribe(hook);
                }
            });
        }
        private void OnItemCraftFinished(ItemCraftTask MFBRLAIAODGWTFOTRBSVCLIWYTRKWVFZTNGHKZKBTTEOG, Item item, ItemCrafter crafter)
        {
            PlayerInfo Player = PlayerInfo.Find(crafter.owner.userID);
            Player.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.KHNCQOMFCGFYERXDXMYMWIRNRKFQBGHEOITQZLGBQQ += item.amount;
            Player.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.NHNINZAXZMKJFDCBMTBXZCAASPANBWTBJJSNSKZJUIU;
        }
        private void OnEntityDeath(LootContainer entity, HitInfo info)
        {
            if (entity == null || info == null) return;
            BasePlayer player = info.InitiatorPlayer;
            if (player == null) return;
            if (entity.ShortPrefabName.Contains("barrel"))
            {
                PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.MTVVPLJOPSRSXRTKKBRFDNPDYMNWPCWJAJAJETAKXYZ++;
                TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.MVTRUUHMVLKKHMQXYNWCTJAWLOJBURCQICNXVITGPGFXYHGFU;
            }
        }
        private void OnEntityBuilt(Planner OBJEQZOXMAXESRIXESXHDGZGISRQCJHTPZFQBRFFKVBFKGGSS, GameObject OLQZVHBCVYIXVCTDPTMSWMNSWIFUWCLYYGUVCPEXOZWHWMZY)
        {
            BasePlayer player = OBJEQZOXMAXESRIXESXHDGZGISRQCJHTPZFQBRFFKVBFKGGSS?.GetOwnerPlayer();
            if (player == null) return;
            BaseEntity entity = OLQZVHBCVYIXVCTDPTMSWMNSWIFUWCLYYGUVCPEXOZWHWMZY?.ToBaseEntity();
            if (entity == null) return;
            if (entity.PrefabName.Contains("building core"))
            {
                PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.UECFNWWMLZMKBQZLGIVDVYAJVYGEMGXWFCWIPFSUEU++;
                TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.KGMREDUXGFLFSEJTCEZTBPUPNNDDXEIDHRGWEQYJ;
            }
        }
        private void OnExplosiveThrown(BasePlayer player, BaseEntity entity, ThrownWeapon item)
        {
            if (player == null || item == null) return;
            XAKZCLWLACTVDWZBFWWBLOGUIWUWMVEIIPPSGROYJZHOL(player, entity);
        }
        private void OnWeaponFired(BaseProjectile projectile, BasePlayer player)
        {
            if (projectile == null || player == null) return;
            XAKZCLWLACTVDWZBFWWBLOGUIWUWMVEIIPPSGROYJZHOL(player, null, projectile.primaryMagazine?.ammoType?.shortname);
        }
        private void OnRocketLaunched(BasePlayer player, BaseEntity entity)
        {
            if (player == null || entity == null) return;
            XAKZCLWLACTVDWZBFWWBLOGUIWUWMVEIIPPSGROYJZHOL(player, entity);
        }
        private void OnDispenserBonus(ResourceDispenser dispenser, BaseEntity entity, Item item)
        {
            BasePlayer player = entity.ToPlayer();
            if (player == null) return;
            GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(player, item.info.shortname, item.amount, true);
        }
        private void OnDispenserGather(ResourceDispenser dispenser, BaseEntity entity, Item item)
        {
            BasePlayer player = entity.ToPlayer();
            if (player == null) return;
            GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(player, item.info.shortname, item.amount);
        }
        private void OnCollectiblePickup(CollectibleEntity collectible, BasePlayer player)
        {
            if (player == null) return;
            foreach (ItemAmount item in collectible.itemList)
            {
                NextTick(() =>
                {
                    if (SLFXUIVPMPZEWUUMKEDLJMAVRICURZUQXXMECXBZBXAATJ.Contains(item.itemDef.itemid))
                    {
                        PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                        if (!TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI.ContainsKey(item.itemDef.shortname))
                        {
                            TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI.Add(item.itemDef.shortname, (int)item.amount);
                        }
                        else
                        {
                            TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI[item.itemDef.shortname] += (int)item.amount;
                        }
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD += (int)item.amount;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.TJEZOFYCDURGYZNIUVJOMGWJFPQIPXSWIONBLLVOYAZALM;
                    }
                    else GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(player, item.itemDef.shortname, (int)item.amount, true);
                });
            }
        }
        private void OnContainerDropItems(ItemContainer GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM)
        {
            if (GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM == null) return;
            BaseEntity entity = GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.entityOwner;
            if (entity == null) return;
            if (!entity.ShortPrefabName.Contains("barrel")) return;
            foreach (Item lootitem in GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.itemList)
            {
                if (lootitem.info.shortname == "scrap") lootitem.skin = 2352567;
            }
        }
        void OnItemPickup(Item item, BasePlayer player)
        {
            if (item == null || item.skin != 2352567) return;
            item.skin = 0;
            if (item.info.shortname == "scrap") GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(player, item.info.shortname, item.amount);
        }
        private static Dictionary<BasePlayer, List<UInt64>> YUYSENGLODCXGSJUYDTQRYACJFWCJBKBXFFEXYSOWFBJDZJR = new Dictionary<BasePlayer, List<UInt64>>();
        private void OnLootEntity(BasePlayer player, LootContainer entity)
        {
            if (entity == null || player == null || entity.OwnerID.IsSteamId() || entity.net == null) return;
            if (!YUYSENGLODCXGSJUYDTQRYACJFWCJBKBXFFEXYSOWFBJDZJR.ContainsKey(player)) YUYSENGLODCXGSJUYDTQRYACJFWCJBKBXFFEXYSOWFBJDZJR.Add(player, new List<UInt64> { });
            ulong VRGNPFZTVJZQECMTBAANEXZLFUMXRZJWEENJDNHAFLBPSXRCO = entity.net.ID.Value;
            if (YUYSENGLODCXGSJUYDTQRYACJFWCJBKBXFFEXYSOWFBJDZJR[player].Contains(VRGNPFZTVJZQECMTBAANEXZLFUMXRZJWEENJDNHAFLBPSXRCO)) return;
            PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
            TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.VUEPDWKZSMMQCOGXWHGPZDCMSMDZPQVGNOZCZKTJZWHTL++;
            foreach (var item in entity.inventory.itemList)
            {
                if (item.info.shortname == "scrap") GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(player, item.info.shortname, item.amount);
            }
            YUYSENGLODCXGSJUYDTQRYACJFWCJBKBXFFEXYSOWFBJDZJR[player].Add(VRGNPFZTVJZQECMTBAANEXZLFUMXRZJWEENJDNHAFLBPSXRCO);
        }
        Dictionary<ulong, ulong> CYIETYSVIVTBBWZDLAPCPOTAHTVJSHDJJBXKNAKORIEMGE = new Dictionary<ulong, ulong>();
        private void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (entity == null || info == null) return;
            if (entity is BaseHelicopter && info.Initiator is BasePlayer)
            {
                BasePlayer player = info.InitiatorPlayer;
                if (player == null) return;
                CYIETYSVIVTBBWZDLAPCPOTAHTVJSHDJJBXKNAKORIEMGE[entity.net.ID.Value] = player.userID;
            }
        }
        private void OnEntityDeath(BaseCombatEntity entity, HitInfo info)
        {
            try
            {
                if (entity == null || info == null) return;
                BasePlayer player = null;
                if (entity is BaseHelicopter)
                {
                    ulong id = entity.net.ID.Value;
                    if (!CYIETYSVIVTBBWZDLAPCPOTAHTVJSHDJJBXKNAKORIEMGE.ContainsKey(id)) return;
                    player = BasePlayer.FindByID(CYIETYSVIVTBBWZDLAPCPOTAHTVJSHDJJBXKNAKORIEMGE[id]);
                    if (player == null) return;
                    PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.ETRZRHLUBBSMDXEGLXXFYVAQDUPKNJYFQIAQLJMQQI++;
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.TYQOPZXRFIRQRFPWBIIPNXSLWALVGSDVHZNYIEAGDICA;
                    CYIETYSVIVTBBWZDLAPCPOTAHTVJSHDJJBXKNAKORIEMGE.Remove(id);
                    return;
                }
                if (info.InitiatorPlayer != null) player = info.InitiatorPlayer;
                if (player == null || !player.userID.IsSteamId()) return;
                PlayerInfo EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ = PlayerInfo.Find(player.userID);
                if (entity is ScientistNPC)
                {
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ++;
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.MLTCXPUWCZCHFSFOGVBMLHGWEXLQQTSAZLJXJKGFY;
                    if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.LEAUXMXTCDDGAEIWYVNANLPVOWDAOVFZMXFVOXGEH) AVPIDNDBCIUQQFRZZFXKNOHGUNIXSLHRIIWZHESQ(EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ, info, true);
                    return;
                }
                if (entity is BaseAnimalNPC)
                {
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD++;
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.LIOOJMGENMVUYOQNFCVYKMLWJAVQMHWYTPFAAIJJBJAPQRWZI;
                    return;
                }
                if (entity is BradleyAPC)
                {
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.WKNHDCLGOUYHITAWXSAHSCNWVXNVCLGOQVDFPNLH++;
                    EPPLRNLANFIXZDICARKSAZOQLPAKHJHTDKRUDWMVXAJ.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.LRUZTPOQSZWFESONBKNFVISSROWICMEUSTKIRWNCPEPZRS;
                    return;
                }
            }
            catch (NullReferenceException ex) { }
        }
        private object OnPlayerDeath(BasePlayer player, HitInfo hitInfo)
        {
            if (player != null)
            {
                if (hitInfo == null || !player.userID.IsSteamId()) return null;
                PlayerInfo EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM = PlayerInfo.Find(player.userID);
                if (hitInfo.InitiatorPlayer != null)
                {
                    if (!hitInfo.InitiatorPlayer.userID.IsSteamId()) return null;
                    BasePlayer RBMTDXKIWHFHOJVZVFZOIQJORMQWXZQXLSCOZUVHVFYSKBXZ = hitInfo.InitiatorPlayer;
                    if (EUZRIAXIWDUOKLVDAJKBNXVNJXIULYDJKIJEHJOCZNEGO(RBMTDXKIWHFHOJVZVFZOIQJORMQWXZQXLSCOZUVHVFYSKBXZ.userID, player.userID)) return null;
                    if (XOFXRZDZZGYMIKRDWYZLEBBRWQVIBASPYPAUPNGEGKJCFUB(RBMTDXKIWHFHOJVZVFZOIQJORMQWXZQXLSCOZUVHVFYSKBXZ.UserIDString, player.UserIDString)) return null;
                    if (KWQGGDPVMNBADUYZNJOSKXNJRVETSYLBPRXEKMIUZ(RBMTDXKIWHFHOJVZVFZOIQJORMQWXZQXLSCOZUVHVFYSKBXZ.userID)) return null;
                    PlayerInfo PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB = PlayerInfo.Find(RBMTDXKIWHFHOJVZVFZOIQJORMQWXZQXLSCOZUVHVFYSKBXZ.userID);
                    if (hitInfo.damageTypes.GetMajorityDamageType() == DamageType.Suicide)
                    {
                        EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.PHSBNIVBVHAXXTDEPREBKWUOEJCJDYCCCXDAKAGRSLRE++;
                        EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD++;
                        EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.Score -= QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.OWXTDPXJWEWYXMAIYSNVKTEIWVHGNWYJCRQCWWKLGH;
                        return null;
                    }
                    AVPIDNDBCIUQQFRZZFXKNOHGUNIXSLHRIIWZHESQ(PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB, hitInfo, true);
                    PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills++;
                    PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM++;
                    PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC += hitInfo.isHeadshot ? 1 : 0;
                    PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.IJOOIJJQJEPFRFFWXAEDFJHBITJIEVOWOOZXHPPBGAKNLTTE;
                    EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD++;
                    EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.Score -= QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.ELXXJZMVQNEVVSOWHHRWAGMVGVYMBHCODXAXZYXGBAHWXWVK;
                }
                else
                {
                    if (hitInfo.damageTypes.GetMajorityDamageType() == DamageType.Suicide) return null;
                    EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD++;
                    EDKLJFDUWLIEBZZBMATDXPTPLNZEFOUZQJMIEPBCGM.Score -= QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.ELXXJZMVQNEVVSOWHHRWAGMVGVYMBHCODXAXZYXGBAHWXWVK;
                }
            }
            return null;
        }
        private void OnPlayerAttack(BasePlayer attacker, HitInfo hitinfo)
        {
            if (hitinfo == null || attacker == null || hitinfo.HitEntity == null || !attacker.IsConnected) return;
            if ((hitinfo.HitEntity is ScientistNPC && QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.LEAUXMXTCDDGAEIWYVNANLPVOWDAOVFZMXFVOXGEH) || (hitinfo.HitEntity is BasePlayer && (hitinfo.HitEntity as BasePlayer).userID.IsSteamId()))
            {
                if (hitinfo.HitEntity == attacker) return;
                PlayerInfo PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB = PlayerInfo.Find(attacker.userID);
                AVPIDNDBCIUQQFRZZFXKNOHGUNIXSLHRIIWZHESQ(PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB, hitinfo);
                PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM++;
                if (hitinfo.isHeadshot) PFXGXOBSXBRGNLXQIWVHGZAJSTCSRDQPRNHTTQNEAWB.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC++;
            }
        }
        private void OnGrowableGathered(GrowableEntity VHTCUNNJQNGRXRVBLSCTEUXQHORAIOBVNYSWENKIWZQWJU, Item item, BasePlayer player)
        {
            if (SLFXUIVPMPZEWUUMKEDLJMAVRICURZUQXXMECXBZBXAATJ.Contains(item.info.itemid))
            {
                NextTick(() =>
                {
                    PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                    if (!TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI.ContainsKey(item.info.shortname))
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI.Add(item.info.shortname, item.amount);
                    }
                    else
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI[item.info.shortname] += item.amount;
                    }
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.harvesting.JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD += item.amount;
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.TJEZOFYCDURGYZNIUVJOMGWJFPQIPXSWIONBLLVOYAZALM;
                });
            }
        }
        private void Unload()
        {
            TGACNKELBXMEOOQKXEZUTNSTBDUAQHNSLWSNKNPSGLSLQLJX();
            MFCBQXBXSRBDADYWLULHDLOTLGAKDHYKDWXJEMRXE();
            ZKLWWSUWHANMNKFPJKLCAVMPCMFMUSMHKBSGOHIWXCV();
            if (rewardPlayerCoroutine != null) ServerMgr.Instance.StopCoroutine(rewardPlayerCoroutine);
            foreach (BasePlayer player in BasePlayer.activePlayerList) CuiHelper.DestroyUi(player, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI);
            QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP = null;
            _ = null;
        }
        private void OnServerShutdown() => Unload();
        private void Init()
        {
            _ = this;
            QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP = new StringBuilder();
            KVOHBFRHBWRBGXCTFUHTMTKQCCLXUJCQXMXMLSCV();
            BNNCADGNGBJPEVUKTTRWCAKPGOIVGDPUWTPTZPLTLZ();
            XDVPOQATZYASAAQJQKXRTKSQAEFPRZDNCXOLXVRKJJ();
        }
        private void OnNewSave()
        {
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.JEBGYMHEXSQDUTEQWZJCHNNVSFLQYXPTYBAGTSZDQF)
            {
                rewardPlayerCoroutine = ServerMgr.Instance.StartCoroutine(BCEDZNLPCYHHFTRDZZYVHDLNUCKZIYNPKOCPCODVCWHXYBJF());
            }
            else if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.KQALAEVJKVNVLOKAZYFWCKRCOENIBHUMELZSWJTJPLG)
            {
                PlayerInfo.GTHTEKSFYIINBHJQSNLPMJBGNHHZZDBOBHWTOQCNUDHLI();
                NextTick(() =>
                {
                    TGACNKELBXMEOOQKXEZUTNSTBDUAQHNSLWSNKNPSGLSLQLJX();
                    MFCBQXBXSRBDADYWLULHDLOTLGAKDHYKDWXJEMRXE();
                });
                PrintWarning(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_PRINT_WIPE"));
            }
        }
        private void OnPlayerConnected(BasePlayer player)
        {
            if (!BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(player.userID))
            {
                var EAHUABCFBSCPENOEMIBULBPZDDWRJRGKYHERLHRPBLNYKRO = PlayerInfo.Find(player.userID);
                EAHUABCFBSCPENOEMIBULBPZDDWRJRGKYHERLHRPBLNYKRO.Name = TRUEDJLOIMJDUQJWQYJETUKFJUVNEOSWOCPDLDTKIVQLNY(player.displayName);
                if (EAHUABCFBSCPENOEMIBULBPZDDWRJRGKYHERLHRPBLNYKRO.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.CDZQFGUSFWGFQRBKCHJMKXJPUMEKGTNBPXCJHAKCJBEKBI != DateTime.Now.ToShortDateString())
                {
                    EAHUABCFBSCPENOEMIBULBPZDDWRJRGKYHERLHRPBLNYKRO.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.QXPXERAAPSBWSJKULTPEFXLVVJIYLTNHOKBRDFXFGC = 0;
                    EAHUABCFBSCPENOEMIBULBPZDDWRJRGKYHERLHRPBLNYKRO.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.CDZQFGUSFWGFQRBKCHJMKXJPUMEKGTNBPXCJHAKCJBEKBI = DateTime.Now.ToShortDateString();
                }
            }
            if (UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(player.userID)) UWOTRIPXJKRCHKTNHUCRJJGLVJBKDSHRDIOMJWGIOYJYNIUQ(player);
            EBZWDYDTICLASTBATWKTJUFIXUTKYXWBFXFXMAZW(player.UserIDString);
        }
        private void OnServerInitialized()
        {
            if (!ImageLibrary)
            {
                NextTick(() =>
                {
                    PrintError($"ERROR! Plugin ImageLibrary not found!");
                    Interface.Oxide.UnloadPlugin(Name);
                });
                return;
            }
            foreach (var itemDef in ItemManager.GetItemDefinitions())
            {
                Item CISSVHICLHRWEKVKMSRXJWSEQLSZOQPLOQPAZNOQYB = ItemManager.CreateByName(itemDef.shortname, 1, 0);
                BaseEntity DQVKRPCMRARWGPNBJPIOUSFHOVVLYDAYHPPOVBBKLE = CISSVHICLHRWEKVKMSRXJWSEQLSZOQPLOQPAZNOQYB.GetHeldEntity();
                if (DQVKRPCMRARWGPNBJPIOUSFHOVVLYDAYHPPOVBBKLE != null)
                {
                    _prefabID2Item[DQVKRPCMRARWGPNBJPIOUSFHOVVLYDAYHPPOVBBKLE.prefabID] = itemDef.shortname;
                }
                var deployablePrefab = itemDef.GetComponent<ItemModDeployable>()?.entityPrefab?.resourcePath;
                if (string.IsNullOrEmpty(deployablePrefab))
                {
                    continue;
                }
                var shortPrefabName = GameManager.server.FindPrefab(deployablePrefab)?.GetComponent<BaseEntity>()?.ShortPrefabName;
                if (!string.IsNullOrEmpty(shortPrefabName) && !_prefabNameItem.ContainsKey(shortPrefabName))
                {
                    _prefabNameItem.Add(shortPrefabName, itemDef.shortname);
                }
            }
            foreach (BasePlayer player in BasePlayer.activePlayerList) OnPlayerConnected(player);
            timer.Once(60f, UOCFVOZWNWFDTPTSFVFACDOJMMAFLFQDTRIROGPVPIF);
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BNBGFHPSGQISQLUWAIEFGTROCPPAQVCOIJKINDVFEV) timer.Once(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.PHQFKISOQUUYHVNDQROBLOTJHALIWNYALYBGMJFRYGLUNKDN, OCMFETOQUCNTBBBCAQDXDTUGZFPMCNFPJBWTBKOZQRTHRZ);
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.LLOENKMINHOIPEMWLFMZKERWRKKVTLXPUMUMBKGA && !string.IsNullOrEmpty(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.XNRUVNSKXCAOQDIPUBPIIMLKFLHWJEXODYEXHTHWHKCWLF)) timer.Once(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.FESOJEZHDNKXARGURMDZQOBKZODKZUAYMUFZYHIFLN, ZDWMPCVNVIGFYEBOGXXJAEHBPBEGMANOZRPJGBQMNNBLV);
            //foreach (var item in ItemManager.itemDictionary)
            //{
            //    if (item.Value.category == ItemCategory.Weapon || item.Value.category == ItemCategory.Resources || item.Value.category == ItemCategory.Food || item.Value.category == ItemCategory.Ammunition || item.Value.category == ItemCategory.Tool)
            //        if ((bool)ImageLibrary.Call("HasImage", item.Value.shortname) == false) ImageLibrary?.Call("AddImage", $"https://api.skyplugins.ru/api/getimage/{item.Value.shortname}/128", item.Value.shortname);
            //}
            CVOLFCOYMGREZHHXUJDITCQZOLBQXRIQVVFSDWYDWXZ();
            EBLEATPDAMPZEOWUBXBVYAIDCPTXKZLWDUUNZWPDBEQJFFNO();
            permission.RegisterPermission(LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ, this);
            permission.RegisterPermission(DYXDVMORKNKXRGRNJBWQDYXKVXMXCEHQTXSZEXNRBVDACZKZI, this);
            permission.RegisterPermission(FWQNCPPKKAGQLLXSASYYFSMTVWXBAIEPMNNMWCGAWALVA, this);
            timer.Every(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.AUILQZEFJSHZYYXWQNHCAAQAOREQFVHREKBTVCSCDO * 60, () =>
            {
                TGACNKELBXMEOOQKXEZUTNSTBDUAQHNSLWSNKNPSGLSLQLJX();
                MFCBQXBXSRBDADYWLULHDLOTLGAKDHYKDWXJEMRXE();
                ZKLWWSUWHANMNKFPJKLCAVMPCMFMUSMHKBSGOHIWXCV();
            });
        }
        public
        const string LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI = "INTERFACE_STATS";
        public
        const string FPUQJMDGRJNGWNRKUQPCCJJRBPALTMWTXDIIIAKIG = "MENU_BUTTON";
        public
        const string VAMGBLQKJNOGBWGCPUMSMFMTITEJBUFHVPNIFVNOVJCJF = "USER_STAT";
        public
        const string BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN = "USER_STAT_INFO";
        public
        const string EHOANBXGPEEJRIYRXNKDGQPZMGSVDWJDJVCQJCPBQKCNCMRGM = "CLOSE_MENU";
        public
        const string SLJJROSONGJCDSUBAVGIHUXJMVOBWAOLJNEYTZDOYUOIRO = "SEARCH_USER";
        public
        const string KSBLVAEHXNZWWAQRNRYSPNWHARSKNFOSYODJVOSLEF = "TOP_TEN_USER";
        private void PLAASGHZXHIEXWTKNIBPNFCLRYABBPEXZZARMEUOKNKCS(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, VAMGBLQKJNOGBWGCPUMSMFMTITEJBUFHVPNIFVNOVJCJF);
            CuiHelper.DestroyUi(player, SLJJROSONGJCDSUBAVGIHUXJMVOBWAOLJNEYTZDOYUOIRO);
            CuiHelper.DestroyUi(player, KSBLVAEHXNZWWAQRNRYSPNWHARSKNFOSYODJVOSLEF);
        }
        private void MainMenuStats(BasePlayer player)
        {
            if (BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(player.userID))
            {
                PrintToChat(player, PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_ADMIN_HIDE_STAT", player.UserIDString));
                return;
            }
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = true,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "172 0",
          OffsetMax = "0 0"
        }
            }, "MS_UI", LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = true,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        }
            }, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI, "BACKGROUND");
            CuiHelper.DestroyUi(player, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI);
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
            VAIEPCAHJLWLAAAOBZNJWFEXSUBMPLYEUANNEZKTZLUELCCF(player);
        }
        private void VAIEPCAHJLWLAAAOBZNJWFEXSUBMPLYEUANNEZKTZLUELCCF(BasePlayer player, int ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT = 0)
        {
            string KTDHOHDBQTVRWWULEIUUSYHYHWHWYYMOJGLNXKDCKD = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 0 ? "1 1 1 1" : "1 1 1 0.2";
            string ZCWHMBDODKLOMMEZSAGDRGHHPLGOUERKOAIVKOUVUKIDYRYBS = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 0 ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2";
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "1 1",
          OffsetMin = "0 -60",
          OffsetMax = "0 0"
        }
            }, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI, FPUQJMDGRJNGWNRKUQPCCJJRBPALTMWTXDIIIAKIG);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "5 5",
          OffsetMax = "-5 -5"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, FPUQJMDGRJNGWNRKUQPCCJJRBPALTMWTXDIIIAKIG, "BUTTONS_MAIN");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Parent = "BUTTONS_MAIN",
                Name = "MY_STAT_BUTTON",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 0 ? "1 1 1 1" : "1 1 1 0.2"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "26 0", OffsetMax = "173 51"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Command = $"UI_HandlerStat Page_swap 0",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_MY_STAT", player.UserIDString),
          FontSize = 20,
          Font = "robotocondensed-bold.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 0 ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
        }
            }, "MY_STAT_BUTTON");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Parent = "BUTTONS_MAIN",
                Name = "TOPTEN_BUTTON",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 1 ? "1 1 1 1" : "1 1 1 0.2"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "181 0", OffsetMax = "327 51"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Command = $"UI_HandlerStat Page_swap 1",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_TOP_TEN", player.UserIDString),
          FontSize = 20,
          Font = "robotocondensed-bold.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 1 ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
        }
            }, "TOPTEN_BUTTON");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Parent = "BUTTONS_MAIN",
                Name = "SEARCH_BUTTON",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 2 ? "1 1 1 1" : "1 1 1 0.2"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"336 0", OffsetMax = $"481 51"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Command = $"UI_HandlerStat Page_swap 2",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_SEARCH", player.UserIDString),
          FontSize = 20,
          Font = "robotocondensed-bold.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 2 ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
        }
            }, "SEARCH_BUTTON");
            CuiHelper.DestroyUi(player, FPUQJMDGRJNGWNRKUQPCCJJRBPALTMWTXDIIIAKIG);
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
            if (ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 0) LTVRTLCSCXPKJNQEWXWCEQKENQTAPVQOZAYRPHSDQDVJDOR(player);
            else if (ADFHECSMAJDVGVMBBLKDZZYXXITXEEBGNOQXDHXT == 1) MQOWMTCMXRUVFCPQFLCATCFXUFIIYPXREVTIEKBAPPKYFR(player);
            else HRZDXAPWKMUANSYMRQANMJCPTKKLZMPSVXHTYBXZXRTNP(player);
        }
        private void HRZDXAPWKMUANSYMRQANMJCPTKKLZMPSVXHTYBXZXRTNP(BasePlayer player, string target = "")
        {
            string LBDAGSVPRBUPUZTAALDJODGLIHXEIXMFVKSPGNUQAVW = "";
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0.875"
        }
            }, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI, SLJJROSONGJCDSUBAVGIHUXJMVOBWAOLJNEYTZDOYUOIRO);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                Image = {
          Color = "0.376 0.384 0.459 0.5"
        },
                RectTransform = {
          AnchorMin = "0.5 1",
          AnchorMax = "0.5 1",
          OffsetMin = "-181.67 -31.1",
          OffsetMax = "149.27 -7.1"
        }
            }, SLJJROSONGJCDSUBAVGIHUXJMVOBWAOLJNEYTZDOYUOIRO, "SEARCH_LINE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "LOUPE_SEARCH_IMG",
                Parent = "SEARCH_LINE",
                Components = {
          new CuiImageComponent {
            Color = "1 1 1 1", Sprite = "assets/icons/examine.png"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0.5", AnchorMax = "0 0.5", OffsetMin = "13.87 -10", OffsetMax = "33.87 10"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "INPUT_SEARCH",
                Parent = "SEARCH_LINE",
                Components = {
          new CuiInputFieldComponent {
            Text = LBDAGSVPRBUPUZTAALDJODGLIHXEIXMFVKSPGNUQAVW, Command = $"UI_HandlerStat listplayer {LBDAGSVPRBUPUZTAALDJODGLIHXEIXMFVKSPGNUQAVW}", Color = "1 1 1 1", FontSize = 10, Align = TextAnchor.MiddleLeft, NeedsKeyboard = true, CharsLimit = 45
          },
          new CuiRectTransformComponent {
            AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-119.86 -9.314", OffsetMax = "129.03 9.591"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-181.67 -1.95",
          OffsetMax = "149.27 212.35"
        }
            }, SLJJROSONGJCDSUBAVGIHUXJMVOBWAOLJNEYTZDOYUOIRO, "LIST_USER_SEARCH");
            int y = 0, x = 0;
            foreach (var players in Players.Where(z => z.Value.Name.ToLower().Contains(target) && !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(z.Key)))
            {
                string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = players.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                string Command = players.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {players.Key}";
                string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(players.Value.GetPlayerName(player.userID), 14) + "</color>";
                if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {players.Key}";
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_IN_SEARCH",
                    Parent = "LIST_USER_SEARCH",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = $"{-164.971 + (x * 112.586)} {84.138 - (y * 26.281)}", OffsetMax = $"{-62.801 + (x * 112.586)} {105.623 - (y * 26.281)}"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_HIDE_PROFILE",
                    Parent = "USER_IN_SEARCH",
                    Components = {
            new CuiImageComponent {
              Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-45.68 -7.5", OffsetMax = "-30.68 7.5"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = "-26.832 -10.743",
            OffsetMax = "48.365 10.743"
          },
                    Text = {
            Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL ?? "UNKNOW",
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleLeft,
            Color = "1 1 1 1"
          }
                }, "USER_IN_SEARCH");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Command = Command,
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, "USER_IN_SEARCH");
                x++;
                if (x == 3)
                {
                    x = 0;
                    y++;
                    if (y == 8) break;
                }
            }
            PLAASGHZXHIEXWTKNIBPNFCLRYABBPEXZZARMEUOKNKCS(player);
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void LTVRTLCSCXPKJNQEWXWCEQKENQTAPVQOZAYRPHSDQDVJDOR(BasePlayer player, ulong target = 0)
        {
            PlayerInfo PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV = PlayerInfo.Find(target == 0 ? player.userID : target);
            ulong userid = target == 0 ? player.userID : target;
            string color = BasePlayer.FindByID(userid) != null ? "0.55 0.78 0.24 1" : "0.8 0.28 0.2 1";
            int MLOUUMBDOHOEGLPMOZLTVDEEDVKCVCBFSQOMIDNK = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.FNAEBONFTHPOQZOEFBIXFHYEUDYNHBOJSKGCVKVPM ? PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ : PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills;
            string RUHWGBITAHYXNGIHKRYBZIMGJMPXDEKLBZDJXHWTCIVVCIE = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.FNAEBONFTHPOQZOEFBIXFHYEUDYNHBOJSKGCVKVPM ? PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PVP_KILLS_NPC", player.UserIDString) : PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PVP_KILLS", player.UserIDString);
            string GFXMOIUIIANUMLQVWMVNCYKDUEZQNQDBHFQXGXXTEVB = "<color=white>" + PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.Name.ToString() + "</color>";
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0.89"
        }
            }, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI, VAMGBLQKJNOGBWGCPUMSMFMTITEJBUFHVPNIFVNOVJCJF);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        }
            }, VAMGBLQKJNOGBWGCPUMSMFMTITEJBUFHVPNIFVNOVJCJF, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "PanelButtonsImage"), Color = "1 1 1 1"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "5 -206.438", OffsetMax = "247.492 -10.162"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "9.908 -36.438",
          OffsetMax = "242.492 -10.162"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_INFO", player.UserIDString, GFXMOIUIIANUMLQVWMVNCYKDUEZQNQDBHFQXGXXTEVB),
          Font = "robotocondensed-bold.ttf",
          FontSize = 14,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "INFO_USER_NICK");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "USER_AVATAR_LAYER",
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Color = "0 0 0 0"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "13 -92", OffsetMax = "70 -35"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "AVATAR_ON_STEAM",
                Parent = "USER_AVATAR_LAYER",
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", target == 0 ? player.UserIDString : target.ToString())
          },
          new CuiRectTransformComponent {
            AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-25 -25", OffsetMax = "25 25"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "15.477 -144.883",
          OffsetMax = "87.323 -116.717"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_ACTIVITY", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 14,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "USER_ACTIVE");
            if (target == 0 && (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.SGLWUOPHZUWTTTHYATQEZOKBLZBUVKJWUUOLVQCOQUABZDEOP && (permission.UserHasPermission(player.UserIDString, DYXDVMORKNKXRGRNJBWQDYXKVXMXCEHQTXSZEXNRBVDACZKZI) || QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.ZENQTJBNGYJXJRDVTNJUGRGMWDFCZVWXYIXILKRP && permission.UserHasPermission(player.UserIDString, FWQNCPPKKAGQLLXSASYYFSMTVWXBAIEPMNNMWCGAWALVA))))
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 1",
            AnchorMax = "0 1",
            OffsetMin = "15.477 -240.083",
            OffsetMax = "87.323 -221.917"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_SETTINGS", player.UserIDString),
            Font = "robotocondensed-bold.ttf",
            FontSize = 14,
            Align = TextAnchor.MiddleLeft,
            Color = "1 1 1 1"
          }
                }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "USER_SETINGS");
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "14.8 -106.281",
          OffsetMax = "227.38 -89.319"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PLACE_TOP", player.UserIDString, GJOSXHNOWNHQZTTINTLIGCJCGBDYFKKUXJCCYIHDRB(target == 0 ? player.userID : target)),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "TOP_IN_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "14.69 -156.181",
          OffsetMax = "227.27 -140.219"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_ACTIVITY_TODAY", player.UserIDString, TimeHelper.FormatTime(TimeSpan.FromMinutes(PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.QXPXERAAPSBWSJKULTPEFXLVVJIYLTNHOKBRDFXFGC), 5, lang.GetLanguage(player.UserIDString))),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "TODAY_ACTIVE_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "14.69 -176.181",
          OffsetMax = "227.27 -160.219"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_ACTIVITY_TOTAL", player.UserIDString, TimeHelper.FormatTime(TimeSpan.FromMinutes(PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ), 5, lang.GetLanguage(player.UserIDString))),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "ALLTIME_ACTIVE_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = "14.69 -196.181",
          OffsetMax = "227.27 -180.219"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_SCORE", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.Score.ToString("0.0")),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "SCORE_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 1",
          AnchorMax = "1 1",
          OffsetMin = "-209.5 -33.825",
          OffsetMax = "-100.043 -11.66"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PVP", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 14,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "PVP_STAT_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-209.505 31.618",
          OffsetMax = "-13.975 55.782"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_FAVORITE_WEAPON", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 14,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "RIFLE_FAVORITE_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "KILL_STAT_PLAYER",
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
          },
          new CuiRectTransformComponent {
            AnchorMin = "1 1", AnchorMax = "1 1", OffsetMin = "-209.389 -83.243", OffsetMax = "-14.469 -38.4"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "19 -7.014",
          OffsetMax = "97 8.414"
        },
                Text = {
          Text = RUHWGBITAHYXNGIHKRYBZIMGJMPXDEKLBZDJXHWTCIVVCIE,
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "KILL_STAT_PLAYER", "LABEL_KILL_AMOUNT");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-98 -7.014",
          OffsetMax = "-16.845 8.414"
        },
                Text = {
          Text = MLOUUMBDOHOEGLPMOZLTVDEEDVKCVCBFSQOMIDNK.ToString(),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleRight,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, "KILL_STAT_PLAYER", "LABEL_KILL_AMOUNTTWO");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "KILLSHOT_STAT_PLAYER",
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
          },
          new CuiRectTransformComponent {
            AnchorMin = "1 1", AnchorMax = "1 1", OffsetMin = "-209.389 -133.691", OffsetMax = "-14.469 -88.849"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "19 -7.014",
          OffsetMax = "97 8.414"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PVP_DEATH", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "KILLSHOT_STAT_PLAYER", "LABEL_KILL_AMOUNT");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-98 -7.014",
          OffsetMax = "-16.845 8.414"
        },
                Text = {
          Text = PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD.ToString(),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleRight,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, "KILLSHOT_STAT_PLAYER", "LABEL_KILL_AMOUNTTWO");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "DEATCH_STAT_PLAYER",
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
          },
          new CuiRectTransformComponent {
            AnchorMin = "1 1", AnchorMax = "1 1", OffsetMin = "-209.39 -184.721", OffsetMax = "-14.47 -139.879"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "19 -7.014",
          OffsetMax = "97 8.414"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_PVP_KDR", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "DEATCH_STAT_PLAYER", "LABEL_KILL_AMOUNT");
            float UBHQSZYQMQIHVUSKIEVRWLNGUSPZPCJHXNISWIXOSNPQXICM = PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD == 0 ? MLOUUMBDOHOEGLPMOZLTVDEEDVKCVCBFSQOMIDNK : (float)Math.Round(((float)MLOUUMBDOHOEGLPMOZLTVDEEDVKCVCBFSQOMIDNK) / PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.CDHMLISLFPYJGWFBMMAVEBFJSHDCUANNMLHBRKCWXCZD, 2);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-98 -7.014",
          OffsetMax = "-16.845 8.414"
        },
                Text = {
          Text = UBHQSZYQMQIHVUSKIEVRWLNGUSPZPCJHXNISWIXOSNPQXICM.ToString(),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleRight,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, "DEATCH_STAT_PLAYER", "LABEL_KILL_AMOUNTTWO");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "FAVORITE_WEAPON_STAT_PLAYER",
                Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
          },
          new CuiRectTransformComponent {
            AnchorMin = "1 1", AnchorMax = "1 1", OffsetMin = "-210.15 -274.607", OffsetMax = "-13.977 -228.569"
          }
        }
            });
            var NKAZKAIOBWAJYAJHAKHLZNZGHYIWWIMPCUCRIHMNA = PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.weapon.KFHCBVKQJKQSFNUUQMKUUHVSVZUPETTMBAFXRXFPHONRFM.OrderByDescending(x => x.Value.Kills).Take(1).FirstOrDefault();
            if (NKAZKAIOBWAJYAJHAKHLZNZGHYIWWIMPCUCRIHMNA.Key != null)
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "46.321 -16.5",
            OffsetMax = "176.509 16.5"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_FAVORITE_WEAPON_KILLS", player.UserIDString, NKAZKAIOBWAJYAJHAKHLZNZGHYIWWIMPCUCRIHMNA.Value.Kills, NKAZKAIOBWAJYAJHAKHLZNZGHYIWWIMPCUCRIHMNA.Value.BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "FAVORITE_WEAPON_STAT_PLAYER", "LABEL_KILL_AMOUNT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "WEAPON_IMG_USER",
                    Parent = "FAVORITE_WEAPON_STAT_PLAYER",
                    Components = {
            new CuiImageComponent
            {
                Color = "1 1 1 1",
                ItemId = GetItemId(NKAZKAIOBWAJYAJHAKHLZNZGHYIWWIMPCUCRIHMNA.Key)
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
            }
            else
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_FAVORITE_WEAPON_NOT_DATA", player.UserIDString),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "FAVORITE_WEAPON_STAT_PLAYER", "LABEL_KILL_AMOUNT");
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-209.498 -54.383",
          OffsetMax = "-79.669 -30.219"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_OTHER_STAT", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 14,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "OTHER_STAT_LABEL");
            PLAASGHZXHIEXWTKNIBPNFCLRYABBPEXZZARMEUOKNKCS(player);
            CuiHelper.DestroyUi(player, "USER_STAT");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
            SWPRHOKNZVSUKVXGHFUDPACTMFZTHOTSBHQZMBWMFZCLP(player, target);
            ETIZKVSCCJBWCLELISPQUIWBSEBPNCHHKWMLDTYXP(player, target);
            if (target == 0)
            {
                if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.ZENQTJBNGYJXJRDVTNJUGRGMWDFCZVWXYIXILKRP && permission.UserHasPermission(player.UserIDString, FWQNCPPKKAGQLLXSASYYFSMTVWXBAIEPMNNMWCGAWALVA)) KYCBIZKDDSGOBDMKVPWBQFMTITIPUGQOJAOYIOHL(player, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV);
                if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.SGLWUOPHZUWTTTHYATQEZOKBLZBUVKJWUUOLVQCOQUABZDEOP && permission.UserHasPermission(player.UserIDString, DYXDVMORKNKXRGRNJBWQDYXKVXMXCEHQTXSZEXNRBVDACZKZI)) JTVVQNOVIREDSBDHHALIOYOOFSLBUAAZYJQVZUYMLDI(player, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV);
            }
        }
        private void JTVVQNOVIREDSBDHHALIOYOOFSLBUAAZYJQVZUYMLDI(BasePlayer player, PlayerInfo info)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "13.865 -8.619",
          OffsetMax = "160.34 6.226"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "BUTTON_HIDE_STAT");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-120.779 -7.423",
          OffsetMax = "21.525 9.815"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_HIDE_STAT", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, "BUTTON_HIDE_STAT", "LABEL_HIDE_USER");
            if (!info.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV)
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "BUTTON_HIDE_STAT",
                    Name = "CHECK_BOX_HIDE",
                    Components = {
            new CuiImageComponent {
              Color = "0.20 0.20 0.24 0.8", Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0.5", AnchorMax = "0 0.5", OffsetMin = "1.381 -6.404", OffsetMax = "14.381 6.596"
            },
            new CuiOutlineComponent {
              Color = "1 1 1 1", Distance = "0.8 -0.8", UseGraphicAlpha = true
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "-0.35 -0.35",
            AnchorMax = "1.35 1.35"
          },
                    Text = {
            Text = "?",
            Align = TextAnchor.MiddleCenter,
            FontSize = 15,
            Color = "0.929 0.882 0.847 0.75"
          }
                }, "CHECK_BOX_HIDE");
            }
            else
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "BUTTON_HIDE_STAT",
                    Name = "CHECK_BOX_HIDE",
                    Components = {
            new CuiImageComponent {
              Color = "0.20 0.20 0.24 0.8", Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0.5", AnchorMax = "0 0.5", OffsetMin = "1.381 -6.404", OffsetMax = "14.381 6.596"
            },
            new CuiOutlineComponent {
              Color = "1 1 1 1", Distance = "0.8 -0.8", UseGraphicAlpha = true
            }
          }
                });
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Command = "UI_HandlerStat hidestat",
          Color = "0 0 0 0"
        },
                Text = {
          Text = ""
        }
            }, "BUTTON_HIDE_STAT");
            CuiHelper.DestroyUi(player, "BUTTON_HIDE_STAT");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void DPLOZOCDDJVLFGQXBNAHQEFILHHNBZWKPPKPHWBGYXWPNFQTD(BasePlayer player)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0.376 0.384 0.459 0.5"
        },
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "13.64 -104.387",
          OffsetMax = "160.12 -45.246"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "CONFIRMATIONS");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0.5 1",
          AnchorMax = "0.5 1",
          OffsetMin = "-73.24 -30",
          OffsetMax = "73.24 -0.43"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CONFIRM", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 12,
          Align = TextAnchor.MiddleCenter,
          Color = "1 1 1 1"
        }
            }, "CONFIRMATIONS");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "CONFIRMATIONS_YES",
                Parent = "CONFIRMATIONS",
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "ButtonImage")
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "6.28 1.7", OffsetMax = "51.28 28.7"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-22.5 -11",
          OffsetMax = "22.5 11"
        },
                Button = {
          Command = "UI_HandlerStat confirm_yes",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CONFIRM_YES", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 12,
          Align = TextAnchor.MiddleCenter,
          Color = "1 1 1 1"
        }
            }, "CONFIRMATIONS_YES", "LABEL_YES");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "CONFIRMATIONS_NO",
                Parent = "CONFIRMATIONS",
                Components = {
          new CuiRawImageComponent {
            Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "ButtonImage")
          },
          new CuiRectTransformComponent {
            AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-51.8 1.7", OffsetMax = "-6.8 28.7"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-22.5 -11",
          OffsetMax = "22.5 11"
        },
                Button = {
          Close = "CONFIRMATIONS",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CONFIRM_NO", player.UserIDString),
          Font = "robotocondensed-bold.ttf",
          FontSize = 12,
          Align = TextAnchor.MiddleCenter,
          Color = "1 1 1 1"
        }
            }, "CONFIRMATIONS_NO", "LABEL_NO");
            CuiHelper.DestroyUi(player, "CONFIRMATIONS");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void KYCBIZKDDSGOBDMKVPWBQFMTITIPUGQOJAOYIOHL(BasePlayer player, PlayerInfo info)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "13.75 -29.559",
          OffsetMax = "160.23 -15.727"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "BUTTON_REFRESH_STAT");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
            {
                Name = "USER_REFRESH_STAT",
                Parent = "BUTTON_REFRESH_STAT",
                Components = {
          new CuiImageComponent {
            Color = "1 1 1 1", Sprite = "assets/icons/clear_list.png"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0.5", AnchorMax = "0 0.5", OffsetMin = "-1.74 -8.5", OffsetMax = "18.74 8.5"
          }
        }
            });
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-120.55 -6.916",
          OffsetMax = "21.75 8.202"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_RESET_STAT", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleLeft,
          Color = "0.8538514 0.8491456 0.8867924 1"
        }
            }, "BUTTON_REFRESH_STAT", "LABEL_REFRESH_USER");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Command = "UI_HandlerStat confirm",
          Color = "0 0 0 0"
        },
                Text = {
          Text = ""
        }
            }, "BUTTON_REFRESH_STAT");
            CuiHelper.DestroyUi(player, "BUTTON_REFRESH_STAT");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void ETIZKVSCCJBWCLELISPQUIWBSEBPNCHHKWMLDTYXP(BasePlayer player, ulong target = 0, int LRNASEMJYPKYQABEHKWIVIWHWHSFPXUORINHLWEDGNGPQHWN = 0)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            PlayerInfo PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV = PlayerInfo.Find(target == 0 ? player.userID : target);
            if (LRNASEMJYPKYQABEHKWIVIWHWHSFPXUORINHLWEDGNGPQHWN == 0)
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "CRATE_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 151.391", OffsetMax = "-13.974 197.429"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CRATE_OPEN", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.VUEPDWKZSMMQCOGXWHGPZDCMSMDZPQVGNOZCZKTJZWHTL),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "CRATE_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "CRATE_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "CrateImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "BARREL_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 99.171", OffsetMax = "-13.974 145.209"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_BARREL_KILL", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.MTVVPLJOPSRSXRTKKBRFDNPDYMNWPCWJAJAJETAKXYZ),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "BARREL_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "BARREL_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "BarrelImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "ANIMALKILL_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 46.951", OffsetMax = "-13.974 92.989"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_ANIMAL_KILL", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "ANIMALKILL_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "ANIMALKILL_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "AnimalImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
            }
            else
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "Heli_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 151.391", OffsetMax = "-13.974 197.429"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_HELI_KILL", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.ETRZRHLUBBSMDXEGLXXFYVAQDUPKNJYFQIAQLJMQQI),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "Heli_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "Heli_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "HeliImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "BRADLEY_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 99.171", OffsetMax = "-13.974 145.209"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_BRADLEY_KILL", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.WKNHDCLGOUYHITAWXSAHSCNWVXNVCLGOQVDFPNLH),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "BRADLEY_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "BRADLEY_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "BradleyImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "NPCKILL_STAT",
                    Parent = BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN,
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width")
            },
            new CuiRectTransformComponent {
              AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-210.146 46.951", OffsetMax = "-13.974 92.989"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0.5",
            AnchorMax = "0 0.5",
            OffsetMin = "48.359 -7.014",
            OffsetMax = "176.509 8.414"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_NPC_KILL", player.UserIDString, PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ),
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleCenter,
            Color = "1 1 1 1"
          }
                }, "NPCKILL_STAT");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "NPC_IMG_USER",
                    Parent = "NPCKILL_STAT",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = (string) ImageLibrary.Call("GetImage", "NpcImage")
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-88.5 -16.5", OffsetMax = "-55.5 16.5"
            }
          }
                });
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                Button = {
          Color = "1 1 1 0.1",
          Command = $"UI_HandlerStat ShowMoreStat {target} {LRNASEMJYPKYQABEHKWIVIWHWHSFPXUORINHLWEDGNGPQHWN}"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_BTN_MORE", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleCenter,
          Color = "0.8538514 0.8491456 0.8867924 1"
        },
                RectTransform = {
          AnchorMin = "1 0",
          AnchorMax = "1 0",
          OffsetMin = "-210.146 22.951",
          OffsetMax = "-13.974 39.989"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "SHOW_MORE_STAT");
            CuiHelper.DestroyUi(player, "SHOW_MORE_STAT");
            CuiHelper.DestroyUi(player, "CRATE_STAT");
            CuiHelper.DestroyUi(player, "BARREL_STAT");
            CuiHelper.DestroyUi(player, "NPCKILL_STAT");
            CuiHelper.DestroyUi(player, "Heli_STAT");
            CuiHelper.DestroyUi(player, "BRADLEY_STAT");
            CuiHelper.DestroyUi(player, "ANIMALKILL_STAT");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void SWPRHOKNZVSUKVXGHFUDPACTMFZTHOTSBHQZMBWMFZCLP(BasePlayer player, ulong target = 0, int TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST = 0)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            PlayerInfo PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV = PlayerInfo.Find(target == 0 ? player.userID : target);
            var list = GVAVBQRXZGOVIOXKUTMOSAGLNEYWXEZRKKORDSRGXFQ(PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV, TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0.5803922 0.572549 0.6117647 0.4313726"
        },
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = $"151.69 {172.046 - ((list.Count - 1) * 50.729)}",
          OffsetMax = $"153.21 216.49"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "STAT_LINE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0.276 0.284 0.399 1"
        },
                RectTransform = {
          AnchorMin = "0.5 1",
          AnchorMax = "0.5 1",
          OffsetMin = $"-0.761 {-23.343 - ((list.Count - 1) * 30.729)}",
          OffsetMax = "0.761 0.17"
        }
            }, "STAT_LINE", "STAT_LINE_CHILD");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = "0.5 1",
          AnchorMax = "0.5 1",
          OffsetMin = "-146.988 -31.4",
          OffsetMax = "146.388 -13.16"
        }
            }, BMCGLQWOAPOSXIHGIPHHKMIXWTHXXDCDORRRHVIPLHPYUN, "MENU_USER_STAT");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = "0 0.5",
          OffsetMin = "0.312 -9.12",
          OffsetMax = "84.704 9.121"
        },
                Button = {
          Command = $"UI_HandlerStat changeCategory {target} 0",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_GATHER", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleCenter,
        }
            }, "MENU_USER_STAT", "Panel_5655");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 0 ? "0.276 0.284 0.399 1" : "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0.5 0",
          AnchorMax = "0.5 0",
          OffsetMin = "-42.347 0",
          OffsetMax = "42.196 1.871"
        }
            }, "Panel_5655", "Panel_8052");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-61.983 -9.121",
          OffsetMax = "31.232 9.12"
        },
                Button = {
          Command = $"UI_HandlerStat changeCategory {target} 1",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_EXPLOSED", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleCenter,
        }
            }, "MENU_USER_STAT", "Panel_56551");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 1 ? "0.276 0.284 0.399 1" : "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0.5 0",
          AnchorMax = "0.5 0",
          OffsetMin = "-46.608 0",
          OffsetMax = "46.608 1.871"
        }
            }, "Panel_56551", "Panel_8052");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "1 0.5",
          AnchorMax = "1 0.5",
          OffsetMin = "-115.459 -9.12",
          OffsetMax = "0.001 9.121"
        },
                Button = {
          Command = $"UI_HandlerStat changeCategory {target} 2",
          Color = "0 0 0 0"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_PLANT", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 10,
          Align = TextAnchor.MiddleCenter,
        }
            }, "MENU_USER_STAT", "Panel_56553");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 2 ? "0.276 0.284 0.399 1" : "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0.5 0",
          AnchorMax = "0.5 0",
          OffsetMin = "-57.73 0",
          OffsetMax = "57.73 1.871"
        }
            }, "Panel_56553", "Panel_8052");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-146.991 -134.121",
          OffsetMax = "146.389 216.031"
        }
            }, "USER_STAT_INFO", "MAIN_LIST_STAT_USER");
            int y = 0;
            string VMXETMFJWXVBEZLUSLRMSSJLHEYRZTXULWSMJCEWQ = lang.GetLanguage(player.UserIDString);
            foreach (var item in list)
            {
                if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.ADDPLVXZBRNBZUJKPRYRRWJKLUZYPYKANEBDZZSBCYY.Contains(item.Key)) continue;
                float MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX = 0.15f * y;
                string itemName = string.Empty;
                if (_itemName.ContainsKey(item.Key))
                {
                    itemName = VMXETMFJWXVBEZLUSLRMSSJLHEYRZTXULWSMJCEWQ == "ru" ? _itemName[item.Key].ru : _itemName[item.Key].EDCGMMQJNGIUGACVAHZJBWPUVHJEZKQYIJMVZQPDYOXGZZGBP;
                }
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "STAT_USER_LINE",
                    Parent = "MAIN_LIST_STAT_USER",
                    Components = {
            new CuiRawImageComponent {
              Color = "1 1 1 1", Png = item.Key == "all" ? (string) ImageLibrary.Call("GetImage", "btn_panel_width") : (string) ImageLibrary.Call("GetImage", "btn_panel_width"), FadeIn = MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 1", AnchorMax = "0.5 1", OffsetMin = $"-146.118 {-44.977 - (y * 50.729)}", OffsetMax = $"146.692 {-0.765 - (y * 50.729)}"
            }
          }
                });
                string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 0 ? item.Value.ToString("0,0", CultureInfo.InvariantCulture) : item.Value.ToString();
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = "26.03 -10.534",
            OffsetMax = "126.03 12.574"
          },
                    Text = {
            Text = KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI,
            Font = "robotocondensed-regular.ttf",
            FontSize = 10,
            Align = TextAnchor.MiddleRight,
            Color = "0.8538514 0.8491456 0.8867924 1",
            FadeIn = MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX
          }
                }, "STAT_USER_LINE", "STAT_USER_AMOUNT");
                if (item.Key == "all")
                {
                    string BHECWEDSCDNOQZEKLQSICURPDOAEZBWXSQBSUAGN = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 0 ? "STAT_USER_TOTAL_GATHERED" : TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 1 ? "STAT_USER_TOTAL_EXPLODED" : "STAT_USER_TOTAL_GROWED";
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                    {
                        RectTransform = {
              AnchorMin = "0.5 0.5",
              AnchorMax = "0.5 0.5",
              OffsetMin = "-128 -10.534",
              OffsetMax = "50 12.574"
            },
                        Text = {
              Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV(BHECWEDSCDNOQZEKLQSICURPDOAEZBWXSQBSUAGN, player.UserIDString),
              Font = "robotocondensed-regular.ttf",
              FontSize = 11,
              Align = TextAnchor.MiddleLeft,
              Color = "1 1 1 1",
              FadeIn = MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX
            }
                    }, "STAT_USER_LINE", "ALL_TOTAL");
                }
                else
                {
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Name = "IMAGE_ITEM",
                        Parent = "STAT_USER_LINE",
                        Components = {
              new CuiImageComponent {
                Color = "1 1 1 1", ItemId = GetItemId(item.Key), FadeIn = MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX
              },
              new CuiRectTransformComponent {
                AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-128 -17.5", OffsetMax = "-93 17.5"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                    {
                        RectTransform = {
              AnchorMin = "0.5 0.5",
              AnchorMax = "0.5 0.5",
              OffsetMin = "-73.17 -15.534",
              OffsetMax = "50 12.574"
            },
                        Text = {
              Text = itemName,
              Font = "robotocondensed-regular.ttf",
              FontSize = 10,
              Align = TextAnchor.MiddleLeft,
              Color = "0.8538514 0.8491456 0.8867924 1",
              FadeIn = MOUBPCGOPBWNLCCLXPOOJDZAQIHYKPGUVFGVRFOWKKEWX
            }
                    }, "STAT_USER_LINE");
                }
                y++;
            }
            CuiHelper.DestroyUi(player, "MENU_USER_STAT");
            CuiHelper.DestroyUi(player, "MAIN_LIST_STAT_USER");
            CuiHelper.DestroyUi(player, "STAT_LINE");
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void MQOWMTCMXRUVFCPQFLCATCFXUFIIYPXREVTIEKBAPPKYFR(BasePlayer player)
        {
            var GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM = new CuiElementContainer();
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "1 1 1 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0.875"
        }
            }, LXUIKLMFBQNLLKNWVURNNZTOQAYFIOYCQUUKTMKZMYZIUEDEI, KSBLVAEHXNZWWAQRNRYSPNWHARSKNFOSYODJVOSLEF);
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                CursorEnabled = false,
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        }
            }, KSBLVAEHXNZWWAQRNRYSPNWHARSKNFOSYODJVOSLEF, "TOP_10_TABLE");
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.FNAEBONFTHPOQZOEFBIXFHYEUDYNHBOJSKGCVKVPM)
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 1",
            AnchorMax = "0 1",
            OffsetMin = "44.2 -20.655",
            OffsetMax = "211.343 -3.545"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_NPCKILLER", player.UserIDString),
            Font = "robotocondensed-regular.ttf",
            FontSize = 11,
            Align = TextAnchor.MiddleLeft,
            Color = "1 1 1 1"
          }
                }, "TOP_10_TABLE");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0 1",
            AnchorMax = "0 1",
            OffsetMin = "44.575 -441.751",
            OffsetMax = "212.214 -26.861"
          }
                }, "TOP_10_TABLE", "TOP_TABLE_0");
                IEnumerable<KeyValuePair<ulong, PlayerInfo>> ZMJWCWSXMUIBAYHPPYIEZTAGQWZYLQKJENDIHSBSIGNHOVS = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ).Take(10);
                int i = 0;
                foreach (var item in ZMJWCWSXMUIBAYHPPYIEZTAGQWZYLQKJENDIHSBSIGNHOVS)
                {
                    string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                    string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                    string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                    if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                    string color = i == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : i == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : i == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                    {
                        CursorEnabled = false,
                        Image = {
              Color = "0 0 0 0"
            },
                        RectTransform = {
              AnchorMin = "0.5 0.5",
              AnchorMax = "0.5 0.5",
              OffsetMin = $"-83.82 {177.277 - (i * 42.863)}",
              OffsetMax = $"53.82 {207.448 - (i * 42.863)}"
            }
                    }, "TOP_TABLE_0", "USER_INFO");
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Parent = "USER_INFO",
                        Components = {
              new CuiRawImageComponent {
                Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Name = "USER_STAT_HIDE",
                        Parent = "USER_INFO",
                        Components = {
              new CuiImageComponent {
                Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Parent = "USER_INFO",
                        Components = {
              new CuiTextComponent {
                Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 8, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                    {
                        RectTransform = {
              AnchorMin = "1 0",
              AnchorMax = "1 1",
              OffsetMin = "-70 0",
              OffsetMax = "-3 0"
            },
                        Text = {
              Text = item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ.ToString(),
              Font = "robotocondensed-regular.ttf",
              FontSize = 8,
              Align = TextAnchor.MiddleRight,
              Color = "1 1 1 1"
            }
                    }, "USER_INFO");
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "0 0",
              AnchorMax = "1 1"
            },
                        Button = {
              Command = Command,
              Color = "0 0 0 0"
            },
                        Text = {
              Text = ""
            }
                    }, "USER_INFO");
                    i++;
                }
            }
            else
            {
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 1",
            AnchorMax = "0 1",
            OffsetMin = "44.2 -20.655",
            OffsetMax = "211.343 -3.545"
          },
                    Text = {
            Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_KILLER", player.UserIDString),
            Font = "robotocondensed-regular.ttf",
            FontSize = 11,
            Align = TextAnchor.MiddleLeft,
            Color = "1 1 1 1"
          }
                }, "TOP_10_TABLE");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0 1",
            AnchorMax = "0 1",
            OffsetMin = "44.575 -441.751",
            OffsetMax = "212.214 -26.861"
          }
                }, "TOP_10_TABLE", "TOP_TABLE_0");
                IEnumerable<KeyValuePair<ulong, PlayerInfo>> TCFCYJVGLCGGXUMWJYWMUZIWXQWSFTSUDGEJKILUSXWFMUU = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills).Take(10);
                int y = 0;
                foreach (var item in TCFCYJVGLCGGXUMWJYWMUZIWXQWSFTSUDGEJKILUSXWFMUU)
                {
                    string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                    string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                    string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                    if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                    string color = y == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : y == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : y == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                    {
                        CursorEnabled = false,
                        Image = {
              Color = "0 0 0 0"
            },
                        RectTransform = {
              AnchorMin = "0.5 0.5",
              AnchorMax = "0.5 0.5",
              OffsetMin = $"-83.82 {177.277 - (y * 42.863)}",
              OffsetMax = $"53.82 {207.448 - (y * 42.863)}"
            }
                    }, "TOP_TABLE_0", "USER_INFO");
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Parent = "USER_INFO",
                        Components = {
              new CuiRawImageComponent {
                Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Name = "USER_STAT_HIDE",
                        Parent = "USER_INFO",
                        Components = {
              new CuiImageComponent {
                Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                    {
                        Parent = "USER_INFO",
                        Components = {
              new CuiTextComponent {
                Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 8, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
              },
              new CuiRectTransformComponent {
                AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
              }
            }
                    });
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                    {
                        RectTransform = {
              AnchorMin = "1 0",
              AnchorMax = "1 1",
              OffsetMin = "-70 0",
              OffsetMax = "-3 0"
            },
                        Text = {
              Text = item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills.ToString(),
              Font = "robotocondensed-regular.ttf",
              FontSize = 8,
              Align = TextAnchor.MiddleRight,
              Color = "1 1 1 1"
            }
                    }, "USER_INFO");
                    GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "0 0",
              AnchorMax = "1 1"
            },
                        Button = {
              Command = Command,
              Color = "0 0 0 0"
            },
                        Text = {
              Text = ""
            }
                    }, "USER_INFO");
                    y++;
                }
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 1",
          AnchorMax = "1 1",
          OffsetMin = $"{-535.571 + 50} -20.655",
          OffsetMax = $"{-382.429 + 50} -3.545"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_TIME", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 11,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "TOP_10_TABLE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "1 1",
          AnchorMax = "1 1",
          OffsetMin = $"{-520.099 + 50} -441.751",
          OffsetMax = $"{-382.461 + 50} -26.861"
        }
            }, "TOP_10_TABLE", "TOP_TABLE_2");
            IEnumerable<KeyValuePair<ulong, PlayerInfo>> URYPZGYUUJEINCASKMCQPCLANBUWCDJCVIYOVCVXHJPBD = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ).Take(10);
            int c = 0;
            foreach (var item in URYPZGYUUJEINCASKMCQPCLANBUWCDJCVIYOVCVXHJPBD)
            {
                string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                string color = c == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : c == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : c == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"-83.82 {177.277 - (c * 42.863)}",
            OffsetMax = $"53.82 {207.448 - (c * 42.863)}"
          }
                }, "TOP_TABLE_2", "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_STAT_HIDE",
                    Parent = "USER_INFO",
                    Components = {
            new CuiImageComponent {
              Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiTextComponent {
              Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 9, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 1",
            OffsetMin = "-70 0",
            OffsetMax = "-3 0"
          },
                    Text = {
            Text = TimeHelper.FormatTime(TimeSpan.FromMinutes(item.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ), 5, lang.GetLanguage(player.UserIDString)),
            Font = "robotocondensed-regular.ttf",
            FontSize = 9,
            Align = TextAnchor.MiddleRight,
            Color = "1 1 1 1"
          }
                }, "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Command = Command,
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, "USER_INFO");
                c++;
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = $"{159.129 + 35} -20.655",
          OffsetMax = $"{326.271 + 35} -3.545"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_GATHER", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 11,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "TOP_10_TABLE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = $"{160.281 + 35} -441.751",
          OffsetMax = $"{327.919 + 35} -26.861"
        }
            }, "TOP_10_TABLE", "TOP_TABLE_3");
            IEnumerable<KeyValuePair<ulong, PlayerInfo>> HPXEVAREYSFXCXLCSRZBNFEMXHQFIFMKWKUEYXHIL = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM).Take(10);
            int f = 0;
            foreach (var item in HPXEVAREYSFXCXLCSRZBNFEMXHQFIFMKWKUEYXHIL)
            {
                string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                string color = f == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : f == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : f == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"-83.82 {177.277 - (f * 42.863)}",
            OffsetMax = $"53.82 {207.448 - (f * 42.863)}"
          }
                }, "TOP_TABLE_3", "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_STAT_HIDE",
                    Parent = "USER_INFO",
                    Components = {
            new CuiImageComponent {
              Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiTextComponent {
              Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 8, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 1",
            OffsetMin = "-70 0",
            OffsetMax = "-3 0"
          },
                    Text = {
            Text = item.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM.ToString("0,0", CultureInfo.InvariantCulture),
            Font = "robotocondensed-regular.ttf",
            FontSize = 8,
            Align = TextAnchor.MiddleRight,
            Color = "1 1 1 1"
          }
                }, "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Command = Command,
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, "USER_INFO");
                f++;
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = $"{459.229 + 35 } -20.655",
          OffsetMax = $"{626.371 + 35 } -3.545"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_EXPLOSED", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 11,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "TOP_10_TABLE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "0 1",
          OffsetMin = $"{444.231 + 35 } -441.751",
          OffsetMax = $"{641.869 + 35 } -26.861"
        }
            }, "TOP_10_TABLE", "TOP_TABLE_5");
            IEnumerable<KeyValuePair<ulong, PlayerInfo>> KGIXZXLFQYBCPCLLHNJMVSFVASDHDVJQQWVYDZHTUDPOIU = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV).Take(10);
            int z = 0;
            foreach (var item in KGIXZXLFQYBCPCLLHNJMVSFVASDHDVJQQWVYDZHTUDPOIU)
            {
                string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                string color = z == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : z == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : z == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"-83.82 {177.277 - (z * 42.863)}",
            OffsetMax = $"53.82 {207.448 - (z * 42.863)}"
          }
                }, "TOP_TABLE_5", "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_STAT_HIDE",
                    Parent = "USER_INFO",
                    Components = {
            new CuiImageComponent {
              Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiTextComponent {
              Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 9, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 1",
            OffsetMin = "-70 0",
            OffsetMax = "-3 0"
          },
                    Text = {
            Text = item.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV.ToString(),
            Font = "robotocondensed-regular.ttf",
            FontSize = 9,
            Align = TextAnchor.MiddleRight,
            Color = "1 1 1 1"
          }
                }, "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Command = Command,
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, "USER_INFO");
                z++;
            }
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "1 1",
          AnchorMax = "1 1",
          OffsetMin = $"{-221.151 + 35} -20.655",
          OffsetMax = $"{-54.009 + 35} -3.545"
        },
                Text = {
          Text = PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_UI_CATEGORY_TOP_SCORE", player.UserIDString),
          Font = "robotocondensed-regular.ttf",
          FontSize = 11,
          Align = TextAnchor.MiddleLeft,
          Color = "1 1 1 1"
        }
            }, "TOP_10_TABLE");
            GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
            {
                Image = {
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "1 1",
          AnchorMax = "1 1",
          OffsetMin = $"{-220.679 + 35} -441.751",
          OffsetMax = $"{-53.041 + 35} -26.861"
        }
            }, "TOP_10_TABLE", "TOP_TABLE_4");
            IEnumerable<KeyValuePair<ulong, PlayerInfo>> STNPUZZVRANWHUECVPLLTGNIIGQRSDRNGYKNPFORRADXQCA = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.Score).Take(10);
            int s = 0;
            foreach (var item in STNPUZZVRANWHUECVPLLTGNIIGQRSDRNGYKNPFORRADXQCA)
            {
                string AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "assets/icons/lock.png" : "assets/icons/unlock.png";
                string Command = item.Value.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV == true ? "" : $"UI_HandlerStat GoStatPlayers {item.Key}";
                string WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL = "<color=white>" + GetCorrectName(item.Value.Name, 17) + "</color>";
                if (permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ)) Command = $"UI_HandlerStat GoStatPlayers {item.Key}";
                string color = s == 0 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.PFTGLTZWOHLSLQDCXNEPTOCRUBXJHUSQUXLQCKGMOL : s == 1 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.OECCVHKAFMPNBDCLJVQPUPVYOENZNGRAHDNNRZCCXUMD : s == 2 ? QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.ZILVBRRKAMSMTVVHRIVFBRQLJVAZKDXIIJHNVZEKO.KKMAYXRYWRZJEOQTKMYUOFYQOTKSNRACRUDUAZPJA : "1 1 1 1";
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image = {
            Color = "0 0 0 0"
          },
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"-83.82 {177.277 - (s * 42.863)}",
            OffsetMax = $"53.82 {207.448 - (s * 42.863)}"
          }
                }, "TOP_TABLE_4", "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_panel_width"), Color = color
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 0", OffsetMax = "5 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Name = "USER_STAT_HIDE",
                    Parent = "USER_INFO",
                    Components = {
            new CuiImageComponent {
              Color = "1 1 1 1", Sprite = AFQJKYRNXJVIVSRYUQGUOPTKGDTMRNITGNKDROUKGZIMOKU
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "-1 8", OffsetMax = "14 -8"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiElement
                {
                    Parent = "USER_INFO",
                    Components = {
            new CuiTextComponent {
              Text = WVWJOCELLFDGEEVJABBHHOGFWVNPHGVVIFQVRZEEJZRLL, Font = "robotocondensed-regular.ttf", FontSize = 9, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "0 1", OffsetMin = "15 0", OffsetMax = "145 0"
            }
          }
                });
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 1",
            OffsetMin = "-70 0",
            OffsetMax = "-3 0"
          },
                    Text = {
            Text = item.Value.Score.ToString("0.00"),
            Font = "robotocondensed-regular.ttf",
            FontSize = 9,
            Align = TextAnchor.MiddleRight,
            Color = "1 1 1 1"
          }
                }, "USER_INFO");
                GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Command = Command,
            Color = "0 0 0 0"
          },
                    Text = {
            Text = ""
          }
                }, "USER_INFO");
                s++;
            }
            PLAASGHZXHIEXWTKNIBPNFCLRYABBPEXZZARMEUOKNKCS(player);
            CuiHelper.AddUi(player, GQNGZZBYYDNCHFTMJZPHYAZPOEXQFVJJHJPLYSYHSXEM);
        }
        private void UWOTRIPXJKRCHKTNHUCRJJGLVJBKDSHRDIOMJWGIOYJYNIUQ(BasePlayer player)
        {
            var PATYWIALFFHOIHDOJZQIKQMQATTTCQSFFSCRJSQXXYIKXAIKW = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[player.userID];
            foreach (var item in PATYWIALFFHOIHDOJZQIKQMQATTTCQSFFSCRJSQXXYIKXAIKW)
            {
                switch (item.HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU)
                {
                    case CatType.score:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_SCORE", player.UserIDString, item.top));
                        break;
                    case CatType.killer:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_KILL", player.UserIDString, item.top));
                        break;
                    case CatType.time:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_TIME", player.UserIDString, item.top));
                        break;
                    case CatType.AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_FARM", player.UserIDString, item.top));
                        break;
                    case CatType.JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_EXP", player.UserIDString, item.top));
                        break;
                    case CatType.killerNPC:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_KILL_NPC", player.UserIDString, item.top));
                        break;
                    case CatType.MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT:
                        player.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_PLAYER_WIPE_KILL_ANIMAL", player.UserIDString, item.top));
                        break;
                }
            }
            NextTick(() =>
            {
                UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Remove(player.userID);
                ZKLWWSUWHANMNKFPJKLCAVMPCMFMUSMHKBSGOHIWXCV();
            });
        }
        private Coroutine rewardPlayerCoroutine
        {
            get;
            set;
        } = null;
        private IEnumerator BCEDZNLPCYHHFTRDZZYVHDLNUCKZIYNPKOCPCODVCWHXYBJF()
        {
            UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Clear();
            List<CatType> NQLROZODXCPHIPNBIQEMERJTKLIBSALJWNCBUNDDCGUNI = new List<CatType> {
        CatType.score,
        CatType.killer,
        CatType.time,
        CatType.AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO,
        CatType.JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL,
        CatType.killerNPC,
        CatType.MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT
      };
            foreach (var TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST in NQLROZODXCPHIPNBIQEMERJTKLIBSALJWNCBUNDDCGUNI)
            {
                switch (TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST)
                {
                    case CatType.score:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var score = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.Score).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in score)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = (int)item.Value.Score,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.killer:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var killer = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in killer)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = (int)item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.time:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var time = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in time)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = (int)item.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = item.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = item.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.killerNPC:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    case CatType.MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                foreach (var item in MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT)
                                {
                                    if (!UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.ContainsKey(item.Key))
                                    {
                                        UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD.Add(item.Key, new List<PrizePlayer>());
                                    }
                                    var player = UNRAKPTVUSFJPAYXEAZWUXPAMRAFHKAYNZBVLQKYJDEZJD[item.Key];
                                    player.Add(new PrizePlayer
                                    {
                                        HFQJOFIWXYQNTOOOJSGWPYCMNQAMRSQQJCSARBLTECEXU = TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST,
                                        Name = item.Value.Name,
                                        QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ = item.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD,
                                        top = top
                                    });
                                    QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA.Find(x => x.top == top)?.HBMGALMKOWFITNJHOLZWDNBZKMXTPBAUSFPMXLUTG(item.Key.ToString());
                                    top++;
                                    yield
                                    return CoroutineEx.waitForSeconds(0.02f);
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            rewardPlayerCoroutine = null;
            ZKLWWSUWHANMNKFPJKLCAVMPCMFMUSMHKBSGOHIWXCV();
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.KQALAEVJKVNVLOKAZYFWCKRCOENIBHUMELZSWJTJPLG)
            {
                PlayerInfo.GTHTEKSFYIINBHJQSNLPMJBGNHHZZDBOBHWTOQCNUDHLI();
                NextTick(() =>
                {
                    TGACNKELBXMEOOQKXEZUTNSTBDUAQHNSLWSNKNPSGLSLQLJX();
                    MFCBQXBXSRBDADYWLULHDLOTLGAKDHYKDWXJEMRXE();
                });
                PrintWarning(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_PRINT_WIPE"));
            }
        }
        private Tuple<string, string> UOIVUNXQQJXCLHELSWQRBALVCSLWNPSTFHNJETQBEZMFGT()
        {
            int i = Core.Random.Range(0, 7);
            string AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH = string.Empty;
            string MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = string.Empty;
            int top = 1;
            switch (i)
            {
                case 0:
                    {
                        if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.FNAEBONFTHPOQZOEFBIXFHYEUDYNHBOJSKGCVKVPM)
                        {
                            var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ).Take(5);
                            foreach (var playerInfo in playerList)
                            {
                                AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ}\n";
                                top++;
                            }
                            MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_KILL_NPC";
                        }
                        else
                        {
                            var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills).Take(5);
                            foreach (var playerInfo in playerList)
                            {
                                AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills}\n";
                                top++;
                            }
                            MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_KILL";
                        }
                        break;
                    }
                case 1:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM.ToString("0, 0", CultureInfo.InvariantCulture)}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_FARM";
                        break;
                    }
                case 2:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_EXPLOSION";
                        break;
                    }
                case 3:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {TimeHelper.FormatTime(TimeSpan.FromMinutes(playerInfo.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ), 5, lang.GetServerLanguage())}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_TIMEPLAYED";
                        break;
                    }
                case 4:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.UECFNWWMLZMKBQZLGIVDVYAJVYGEMGXWFCWIPFSUEU).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.UECFNWWMLZMKBQZLGIVDVYAJVYGEMGXWFCWIPFSUEU}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_BUILDINGS";
                        break;
                    }
                case 5:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.Score).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.Score:0.0}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_SCORE";
                        break;
                    }
                case 6:
                    {
                        var playerList = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.harvesting.JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD).Take(5);
                        foreach (var playerInfo in playerList)
                        {
                            AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH += $"<color=#faec84>{top}</color>. {playerInfo.Value.Name} : {playerInfo.Value.harvesting.JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD}\n";
                            top++;
                        }
                        MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV = "STAT_TOP_FIVE_FERMER";
                        break;
                    }
            }
            return new Tuple<string, string>(MKLHTYOQBXWJPYZHCCPUKWBXBKDIQZBWCQPXLNIUNBSBNKMV, AHEWDIWCQZIVMYGCGGSJNBHWUBSCRTYKUBUYLGEVH);
        }
        private void OCMFETOQUCNTBBBCAQDXDTUGZFPMCNFPJBWTBKOZQRTHRZ()
        {
            var data = UOIVUNXQQJXCLHELSWQRBALVCSLWNPSTFHNJETQBEZMFGT();
            foreach (BasePlayer item in BasePlayer.activePlayerList)
            {
                item.ChatMessage(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV(data.Item1, item.UserIDString, data.Item2));
            }
            timer.Once(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.PHQFKISOQUUYHVNDQROBLOTJHALIWNYALYBGMJFRYGLUNKDN, OCMFETOQUCNTBBBCAQDXDTUGZFPMCNFPJBWTBKOZQRTHRZ);
        }
        private void ZDWMPCVNVIGFYEBOGXXJAEHBPBEGMANOZRPJGBQMNNBLV()
        {
            var data = UOIVUNXQQJXCLHELSWQRBALVCSLWNPSTFHNJETQBEZMFGT();
            UVUGHGNIDGJKHAYNHFFZRKOQOVPWHXOXGYZTKHWLTCRMGPMEC(Regex.Replace(lang.GetMessage(data.Item1, this), "<.*?>|{.*?}", string.Empty), new List<string> {
        data.Item2
      }, false);
            timer.Once(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.FESOJEZHDNKXARGURMDZQOBKZODKZUAYMUFZYHIFLN, ZDWMPCVNVIGFYEBOGXXJAEHBPBEGMANOZRPJGBQMNNBLV);
        }
        public string PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV(string ZTFUVZOAVAKQIISBNOPAHRYYWHBZCHNRMBDOWNVPVEUVRG, string userID = null, params object[] YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR)
        {
            QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP?.Clear();
            if (YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR != null)
            {
                QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP?.AppendFormat(lang.GetMessage(ZTFUVZOAVAKQIISBNOPAHRYYWHBZCHNRMBDOWNVPVEUVRG, this, userID), YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR);
                return QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP?.ToString();
            }
            return lang.GetMessage(ZTFUVZOAVAKQIISBNOPAHRYYWHBZCHNRMBDOWNVPVEUVRG, this, userID);
        }
        void CVOLFCOYMGREZHHXUJDITCQZOLBQXRIQVVFSDWYDWXZ() { }
        public class items
        {
            public String shortName;
            public String ENdisplayName;
            public String RUdisplayName;
        }
        private class ItemDisplayName
        {
            public String ru;
            public String EDCGMMQJNGIUGACVAHZJBWPUVHJEZKQYIJMVZQPDYOXGZZGBP;
        }
        private void EBLEATPDAMPZEOWUBXBVYAIDCPTXKZLWDUUNZWPDBEQJFFNO() { }
        private readonly Regex NDMLXHOHKFDMJDPKLXNGVKSVLNYIVVBHOTWMLWLEHR = new Regex(@"<avatarFull><!\[CDATA\[(.*)\]\]></avatarFull>", RegexOptions.Compiled);
        private void EBZWDYDTICLASTBATWKTJUFIXUTKYXWBFXFXMAZW(string userid)
        {
            if (ImageLibrary == null)
                return;
            if ((bool)ImageLibrary.Call("HasImage", userid))
                return;

            string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=AE4C104E68AB334B06F065DCD2B03014&" + "steamids=" + userid;
            webrequest.Enqueue(url, null, (code, response) =>
            {
                if (code == 200)
                {
                    string Avatar = (string)JObject.Parse(response)["response"]?["players"]?[0]?["avatarfull"];
                    ImageLibrary?.Call("AddImage", Avatar, userid);
                }
            }, this);
        }
        public static string TRUEDJLOIMJDUQJWQYJETUKFJUVNEOSWOCPDLDTKIVQLNY(string TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW, string LXKDLJCNIXVYEASTQKIBMMOVQKUWTTILLMTSUIDAIEDMNZ = "")
        {
            if (TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW == null) return null;
            StringBuilder QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP = null;
            for (int i = 0; i < TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW.Length; i++)
            {
                char UEITBUWBVCFQFDNOMNPZWEKGYCUACDNGHLBTIMBERKNWYND = TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW[i];
                if (char.IsSurrogate(UEITBUWBVCFQFDNOMNPZWEKGYCUACDNGHLBTIMBERKNWYND))
                {
                    if (QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP == null) QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP = new StringBuilder(TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW, 0, i, TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW.Length);
                    QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP.Append(LXKDLJCNIXVYEASTQKIBMMOVQKUWTTILLMTSUIDAIEDMNZ);
                    if (i + 1 < TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW.Length && char.IsHighSurrogate(UEITBUWBVCFQFDNOMNPZWEKGYCUACDNGHLBTIMBERKNWYND) && char.IsLowSurrogate(TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW[i + 1])) i++;
                }
                else if (QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP != null) QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP.Append(UEITBUWBVCFQFDNOMNPZWEKGYCUACDNGHLBTIMBERKNWYND);
            }
            return QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP == null ? TOPIRGHGIYCZTMDXYEPGLRBHLVHCFQEMOKKRLJIYVQUHNCJW : QKZJUFBMHXZQPFFTDUNSJMNEPIUWIWNMPTOXRJCNYSP.ToString();
        }
        private Dictionary<string, int> GVAVBQRXZGOVIOXKUTMOSAGLNEYWXEZRKKORDSRGXFQ(PlayerInfo PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV, int TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST)
        {
            Dictionary<string, int> LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = new Dictionary<string, int>();
            switch (TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST)
            {
                case 0:
                    {
                        foreach (var item in PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF.Take(8)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add(item.Key, item.Value);
                        LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add("all", PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM);
                        return LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF;
                    }
                case 1:
                    {
                        foreach (var item in PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.explosion.VDDMUSCLTRGHDZCUNJUJLMILNNYXPLITNZFMXMHJSWDPYXIG.Take(8)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add(item.Key, item.Value);
                        LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add("all", PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV);
                        return LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF;
                    }
                case 2:
                    {
                        foreach (var item in PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.harvesting.BWRTATDHEMMATMTBUIBOVFUIIHTRFWJXDCKYEQIEIMIUBJI.OrderByDescending(x => x.Value).Take(9)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add(item.Key, item.Value);
                        LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Add("all", PBOXSAVEYJOMAPFTOPKNSHAZHGISIJCIRTFVFWPKQHVJFV.harvesting.JDCWENYVCJLSALBICOXRCVXEAXGJWZGYZOIBTMSQD);
                        return LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF;
                    }
                default:
                    break;
            }
            return null;
        }
        private static List<KeyValuePair<ulong, PlayerInfo>> WILWKKVRAKSFPPIWRUZVHXLXZFHBCGRMKJPFTCLNIHRASJCN(string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI)
        {
            var players = new List<KeyValuePair<ulong,
              PlayerInfo>>();
            var LWIZEJRRMSRGAJZGTKAYHPGEKJDPUZILFLZUFIGPKXWSSHZG = Players.Concat(BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE);
            foreach (var activePlayer in LWIZEJRRMSRGAJZGTKAYHPGEKJDPUZILFLZUFIGPKXWSSHZG)
            {
                if (activePlayer.Value.Name.ToLower() == KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI) players.Add(activePlayer);
                else if (activePlayer.Value.Name.ToLower().Contains(KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI)) players.Add(activePlayer);
            }
            return players;
        }
        private void UOCFVOZWNWFDTPTSFVFACDOJMMAFLFQDTRIROGPVPIF()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                if (player == null || !player.userID.IsSteamId() || BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(player.userID)) continue;
                PlayerInfo.ACHHRTMDCZSHVJBXFZCZGFTELCXPBJOUJXOLZJVPEWX(player.userID);
            }
            timer.Once(60f, UOCFVOZWNWFDTPTSFVFACDOJMMAFLFQDTRIROGPVPIF);
        }
        public static class TimeHelper
        {
            public static string FormatTime(TimeSpan time, int KDKOWCLYIBOPMSCWPGGVGKKORAZXKLQTMDXPXUFFF = 5, string WTQGDSNKFCZAWASVXWDNNWKVDJUMYUAAPMNQYKXHJAGNTLG = "ru")
            {
                string LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = string.Empty;
                switch (WTQGDSNKFCZAWASVXWDNNWKVDJUMYUAAPMNQYKXHJAGNTLG)
                {
                    case "ru":
                        int i = 0;
                        if (time.Days != 0 && i < KDKOWCLYIBOPMSCWPGGVGKKORAZXKLQTMDXPXUFFF)
                        {
                            if (!string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += " ";
                            LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += $"{Format(time.Days, "д", "д", "д")}";
                            i++;
                        }
                        if (time.Hours != 0 && i < KDKOWCLYIBOPMSCWPGGVGKKORAZXKLQTMDXPXUFFF)
                        {
                            if (!string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += " ";
                            LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += $"{Format(time.Hours, "ч", "ч", "ч")}";
                            i++;
                        }
                        if (time.Minutes != 0 && i < KDKOWCLYIBOPMSCWPGGVGKKORAZXKLQTMDXPXUFFF)
                        {
                            if (!string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += " ";
                            LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += $"{Format(time.Minutes, "м", "м", "м")}";
                            i++;
                        }
                        if (time.Days == 0)
                        {
                            if (time.Seconds != 0 && i < KDKOWCLYIBOPMSCWPGGVGKKORAZXKLQTMDXPXUFFF)
                            {
                                if (!string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += " ";
                                LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF += $"{Format(time.Seconds, "с", "с", "с")}";
                                i++;
                            }
                        }
                        if (string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = "0 секунд";
                        break;
                    default:
                        LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = string.Format("{0}{1}{2}{3}", time.Duration().Days > 0 ? $"{time.Days:0} day{(time.Days == 1 ? String.Empty : "s ")}, " : string.Empty, time.Duration().Hours > 0 ? $"{time.Hours:0} hour{(time.Hours == 1 ? String.Empty : "s ")}, " : string.Empty, time.Duration().Minutes > 0 ? $"{time.Minutes:0} minute{(time.Minutes == 1 ? String.Empty : "s ")}, " : string.Empty, time.Duration().Seconds > 0 ? $"{time.Seconds:0} second{(time.Seconds == 1 ? String.Empty : "s")}" : string.Empty);
                        if (LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.EndsWith(", ")) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Substring(0, LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF.Length - 2);
                        if (string.IsNullOrEmpty(LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF)) LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF = "0 seconds";
                        break;
                }
                return LTSDRIVPUBVZZWYROYITBUGZMKHLQNILYBPJLJOZQLZHRBF;
            }
            private static string Format(int WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI, string VLUAXJUEKJGNSJLTMRALPMKANDZUTFWLVZULHQFNVRMHR, string NDWKULJWYIATNTJALFNUSTPZLVMMQYADJDQWYJKKCYB, string LNCMEVGHUWRUNWYZZXGAIXKKCNCCUCSTREOYTAIVRSIN)
            {
                var TNHAHOWQDPVGBWNKFBOJEAKDLNJTNMCKXDALAKXXDECS = WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI % 10;
                if (WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI >= 5 && WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI <= 20 || TNHAHOWQDPVGBWNKFBOJEAKDLNJTNMCKXDALAKXXDECS >= 5 && TNHAHOWQDPVGBWNKFBOJEAKDLNJTNMCKXDALAKXXDECS <= 9) return $"{WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI}{VLUAXJUEKJGNSJLTMRALPMKANDZUTFWLVZULHQFNVRMHR}";
                if (TNHAHOWQDPVGBWNKFBOJEAKDLNJTNMCKXDALAKXXDECS >= 2 && TNHAHOWQDPVGBWNKFBOJEAKDLNJTNMCKXDALAKXXDECS <= 4) return $"{WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI}{NDWKULJWYIATNTJALFNUSTPZLVMMQYADJDQWYJKKCYB}";
                return $"{WCXJCRGAIUDTXBMKCZKJNCXMZVENQXBRCXPWXRYXFNHDHDJI}{LNCMEVGHUWRUNWYZZXGAIXKKCNCCUCSTREOYTAIVRSIN}";
            }
        }
        Int32 GJOSXHNOWNHQZTTINTLIGCJCGBDYFKKUXJCCYIHDRB(ulong userid)
        {
            Int32 Top = 1;
            var IWVESABLEAALEGZRCSQHVLLMPWSYRRLICOTMZZYFYM = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.Score);
            foreach (var Data in IWVESABLEAALEGZRCSQHVLLMPWSYRRLICOTMZZYFYM)
            {
                if (Data.Key == userid) break;
                Top++;
            }
            return Top;
        }
        private string GetCorrectName(string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI, int WIBKLLESADNDSJQTDMSDYCJHZGYPKIPOXZFEARJQNARB) => KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI.ToPrintable(WIBKLLESADNDSJQTDMSDYCJHZGYPKIPOXZFEARJQNARB).EscapeRichText().Trim();
        private void XAKZCLWLACTVDWZBFWWBLOGUIWUWMVEIIPPSGROYJZHOL(BasePlayer player, BaseEntity entity, string shortname = "")
        {
            string WeaponName = string.IsNullOrWhiteSpace(shortname) == true ? string.Empty : shortname;
            if (entity != null)
            {
                if (_prefabID2Item.TryGetValue(entity.prefabID, out WeaponName) == false)
                {
                    _prefabNameItem.TryGetValue(entity.ShortPrefabName, out WeaponName);
                }
            }
            if (!string.IsNullOrEmpty(WeaponName))
            {
                PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
                if (TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.explosion.VDDMUSCLTRGHDZCUNJUJLMILNNYXPLITNZFMXMHJSWDPYXIG.ContainsKey(WeaponName) && !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.ADDPLVXZBRNBZUJKPRYRRWJKLUZYPYKANEBDZZSBCYY.Contains(WeaponName))
                {
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.explosion.VDDMUSCLTRGHDZCUNJUJLMILNNYXPLITNZFMXMHJSWDPYXIG[WeaponName]++;
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV++;
                    TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.YCNUJNBOFFBGAAUMWERARZCWIXAXMOLGPQCNGUDZ[WeaponName];
                }
            }
        }
        private void AVPIDNDBCIUQQFRZZFXKNOHGUNIXSLHRIIWZHESQ(PlayerInfo player, HitInfo hitinfo, bool VAQRCOGQJMUYTKFNPISNYGSEMSLCBPYLIGEFIYIU = false)
        {
            if (hitinfo == null || hitinfo.WeaponPrefab == null) return;
            string WeaponName = string.Empty;
            if (_prefabID2Item.TryGetValue(hitinfo.WeaponPrefab.prefabID, out WeaponName) == false)
            {
                _prefabNameItem.TryGetValue(hitinfo.WeaponPrefab.ShortPrefabName, out WeaponName);
            }
            if (!string.IsNullOrEmpty(WeaponName))
            {
                if (!player.weapon.KFHCBVKQJKQSFNUUQMKUUHVSVZUPETTMBAFXRXFPHONRFM.ContainsKey(WeaponName))
                {
                    player.weapon.KFHCBVKQJKQSFNUUQMKUUHVSVZUPETTMBAFXRXFPHONRFM.Add(WeaponName, new PlayerInfo.Weapon.WeaponInfo
                    {
                        Kills = VAQRCOGQJMUYTKFNPISNYGSEMSLCBPYLIGEFIYIU ? 1 : 0,
                        LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC = hitinfo.isHeadshot ? 1 : 0
                    });
                }
                else
                {
                    var weapon = player.weapon.KFHCBVKQJKQSFNUUQMKUUHVSVZUPETTMBAFXRXFPHONRFM[WeaponName];
                    weapon.LQLTIQRXDJPGBBULPQDQEHWDSHVMFTDMJQIZSALVJDC += hitinfo.isHeadshot ? 1 : 0;
                    weapon.BRDOMCYBCWEDTHABVESJGDXLSVSOFHGBFJCBEHACVBKNM++;
                    if (VAQRCOGQJMUYTKFNPISNYGSEMSLCBPYLIGEFIYIU) weapon.Kills++;
                }
            }
        }
        private void GMHYQAIHJACRBNMNINPFFJRBCHIJSSVMHEGBAIENZQ(BasePlayer player, string shortname, int YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY, bool GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR = false)
        {
            PlayerInfo TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG = PlayerInfo.Find(player.userID);
            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.ADDPLVXZBRNBZUJKPRYRRWJKLUZYPYKANEBDZZSBCYY.Contains(shortname)) return;
            switch (shortname)
            {
                case "wood":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF[shortname] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        if (GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR) TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR[shortname];
                        break;
                    }
                case "stones":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF[shortname] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        if (GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR) TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR[shortname];
                        break;
                    }
                case "metal.ore":
                case "metal.fragments":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF["metal.ore"] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        if (GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR) TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR["metal.ore"];
                        break;
                    }
                case "sulfur.ore":
                case "sulfur":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF["sulfur.ore"] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        if (GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR) TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR["sulfur.ore"];
                        break;
                    }
                case "hq.metal.ore":
                case "metal.refined":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF["hq.metal.ore"] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        if (GLVDOWWSYSFJTZBQTADYHSBJCXCSZYXEQCHXUJRDIYBEYR) TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.PSYHXGQMJIMHJLZARMLMEBQUVQJYHFBBRXBGDOKR["hq.metal.ore"];
                        break;
                    }
                case "scrap":
                    {
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF[shortname] += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM += YNNLFHHEDYSZNCPIMFJCDOTNJPNGAERZXEASFTGLEYY;
                        TQLFYKBIVIQQBUTIONJHUGJZRVHDCDYWRXBCQPMGXPJHQPKGG.Score += QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.GTIOEGFUCLVQPVYDKIUDZRXYVBPVMTFTXZTTCWBZVEKW.LDGYYGFCMPIRMYNBEMHWSEEGLQLJTXCCUCTYKVWJEWV;
                        break;
                    }
            }
        }
        [ConsoleCommand("stat.topuser")]
        private void LFAHVKLYQDLAXUFVJSZPREPKWGKNZJCFOAGVCAMYGTF(ConsoleSystem.Arg GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE)
        {
            if (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE == null) return;
            var players = GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Player();
            if (players != null && !permission.UserHasPermission(players.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ))
            {
                PrintToConsole(players, PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_1", players.UserIDString));
                return;
            }
            List<CatType> NQLROZODXCPHIPNBIQEMERJTKLIBSALJWNCBUNDDCGUNI = new List<CatType> {
        CatType.score,
        CatType.killer,
        CatType.time,
        CatType.AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO,
        CatType.JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL,
        CatType.killerNPC,
        CatType.MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT
      };
            string RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO = string.Empty;
            foreach (var TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST in NQLROZODXCPHIPNBIQEMERJTKLIBSALJWNCBUNDDCGUNI)
            {
                switch (TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST)
                {
                    case CatType.score:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.VNXJFVCECOVZWQGNTARFZCXFSTYXEZFMBJSHVVFVW.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var score = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.Score).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in score)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.Score.ToString("0.0")}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_SCORE", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.killer:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.MECBDPMEGDZZDSQRQMWEADJJYMYZRXVWJHQTCQPIKZSCMCG.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var killer = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in killer)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.Kills}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_KILLER", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.time:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.TXHJLEOBUNSPEMBATJRWOBCYCLXNNOBDXRFKNQUIKUBBI.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var time = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in time)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {TimeHelper.FormatTime(TimeSpan.FromMinutes(item.Value.WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU.ZMNVMKIGETKVSCJMLJEQSPSCCWGCJTYOLKEXSYBQ), 5)}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_TIME", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.QEESYRSJVTDQQMMJHDQWCXOAXOTBKGWVGZINSCYROGXIMYSYM.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in AMQVXWCFVFLOWGEAMZMHNHBHOOZCYSGQGOLOTCZZIO)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM.ToString("0, 0", CultureInfo.InvariantCulture)}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_FARM", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.UJLJWTPEVKXRZOXHKRDZQFFZHVZFNYVVOAMMKWDPXNH.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in JTILMZKPGITSSLIHIWAGDYUHHUPHKAMZZIROGDMDOCAIMVSDL)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.explosion.GFHFUKJVSZHTFVIINTDTPWBCLQPJSMQERTIGBNTOV}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_RAID", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.killerNPC:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.HYUCVOWKZRVJHZHANFLPRNGRMDOILTABQFEZTLSNGMROOEIV.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.EMVOBHOCIAUJXIUKPGEQALWRHLJFXNBPRQNKVKTXZKCTXXDBQ.GLZJAFKSGYTRVRKJWUPCYKFYWOEPOESKYNOHOVHBQ}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_KILLER_NPC", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    case CatType.MSBHJQTMRJOWNMERQWGOXKCCZNEVFPDIDDZDKTCFWVSIDPT:
                        {
                            int QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB = QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.DQNXNGBROMPWKTCRJIIFBSQBEBNGVHVGBFSLBYYMECIMEWS.KHVPSETSCPRZNYGQUTBVHHBNYIFWRCIVTHBLELXA.Count;
                            if (QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB != 0)
                            {
                                var RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX = Players.Where(x => !QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.BYJXGFGKSFWKXXPVJXQAYRSFVFTMJVFTKXFZVWWTGXI.Contains(x.Key)).OrderByDescending(x => x.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD).Take(QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB);
                                int top = 1;
                                string XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN = string.Empty;
                                foreach (var item in RCHHWLYADSJDFGVUTKTUBEKXSAYMVMBMWQIKSRLGPFZUTKX)
                                {
                                    XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN += $"{top}) {item.Value.Name} : {item.Value.YNACKJIIZMQVACVOZEVRQHVLCRJLHOGXTHMXYMTSZQMPXQ.EBYRAZAASVMKWESJOQSZECQEZTRWAQBZBBVHXGFEMGFASRAD}\n";
                                    top++;
                                }
                                RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO += PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_TOP_VK_KILLER_ANIMAL", null, QSXVRSFKKWHSHDQMKXRFKVNLHVMBJXWVKUVPEWISDLCGUB, XBRKCXVTACKJNQSPRMZFDYQXSETKIPLTVOPKASRN);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            PrintWarning(RCSDDFHTHKOMWKIOWIDTNPRJQMMRCUKIIYTKWSOSKXEYO);
        }
        [ConsoleCommand("stat.score")]
        void VEJGUNUUABRGPQKOZXZGAFLXOJTIFAIYZFOSXDTMOHF(ConsoleSystem.Arg GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE)
        {
            if (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE == null) return;
            var player = GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Player();
            if (player != null && !player.IsAdmin)
            {
                PrintToConsole(player, PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_1", player.UserIDString));
                return;
            }
            switch (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[0])
            {
                case "give":
                    {
                        ulong userID = ulong.Parse(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[1]);
                        int score = Convert.ToInt32(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[2]);
                        PlayerInfo Player = PlayerInfo.Find(userID);
                        Player.Score += score;
                        Puts(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_10", null, userID, score));
                        break;
                    }
                case "remove":
                    {
                        ulong userID = ulong.Parse(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[1]);
                        int score = Convert.ToInt32(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[2]);
                        PlayerInfo Player = PlayerInfo.Find(userID);
                        Player.Score -= score;
                        Puts(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_11", null, userID, score));
                        break;
                    }
            }
        }
        [ConsoleCommand("stat.ignore")]
        private void IZGLPYYJUYIQSMSKTMOZTTGKCSRWEMSTAYPODHTHBZDBW(ConsoleSystem.Arg GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE)
        {
            if (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE == null) return;
            var player = GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Player();
            if (player != null && !permission.UserHasPermission(player.UserIDString, LHOKHTOFGFQBNKQOIAKLGWWEJBCCTINQIPLLVWGOOJUVVFMQ))
            {
                PrintToConsole(player, PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_1", player.UserIDString));
                return;
            }
            if (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE == null || GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args == null || GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args.Count() == 0)
            {
                GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_2"));
                return;
            }
            ulong steamid = 0;
            if (!UInt64.TryParse(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[1], out steamid))
            {
                var players = WILWKKVRAKSFPPIWRUZVHXLXZFHBCGRMKJPFTCLNIHRASJCN(GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[1].ToLower());
                if (players.Count == 0)
                {
                    GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_3"));
                    return;
                }
                if (players.Count > 1)
                {
                    var PXQANEXAUGRYIZYLTSXDLKKRQOZBIPYVLSNAZXEZWKOI = "";
                    foreach (var plr in players) PXQANEXAUGRYIZYLTSXDLKKRQOZBIPYVLSNAZXEZWKOI = PXQANEXAUGRYIZYLTSXDLKKRQOZBIPYVLSNAZXEZWKOI + "\n" + plr.Value.Name + " - " + plr.Key;
                    GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_4", null, PXQANEXAUGRYIZYLTSXDLKKRQOZBIPYVLSNAZXEZWKOI));
                    return;
                }
                steamid = players[0].Key;
            }
            string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI = "";
            for (int ii = 1; ii < GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args.Count(); ii++) KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI += GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[ii] + " ";
            KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI = KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI.Trim(' ');
            if (string.IsNullOrEmpty(KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI))
            {
                GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_2"));
                return;
            }
            if (!Players.ContainsKey(steamid) && !BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(steamid))
            {
                GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_5"));
                return;
            }
            PlayerInfo playerInfo = Players.ContainsKey(steamid) ? Players[steamid] : BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE[steamid];
            switch (GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.Args[0])
            {
                case "add":
                case "a":
                    {
                        if (BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(steamid))
                        {
                            GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_6", null, playerInfo.Name));
                            break;
                        }
                        BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.Add(steamid, playerInfo);
                        Players.Remove(steamid);
                        GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_7", null, playerInfo.Name));
                        break;
                    }
                case "r":
                case "remove":
                    {
                        if (!BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.ContainsKey(steamid))
                        {
                            GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_8", null, playerInfo.Name));
                            break;
                        }
                        PlayerInfo info = BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE[steamid];
                        Players.Add(steamid, info);
                        BGVGZVVNZTWGOAVIIVYQCRQVICRUODYZRONEHDNNPEE.Remove(steamid);
                        GRQRDUZJOKMBRUDTAVASQSEVKJAQIRWKLXWBIGTJQTTNIHAIE.ReplyWith(PVPCNJTQOUVUWNYPBVURFHORIEGLWMDVGLMIRJMDV("STAT_CMD_9", null, playerInfo.Name));
                        break;
                    }
                default:
                    break;
            }
        }
        [ConsoleCommand("UI_HandlerStat")]
        private void AKLJSCSFUOTVJXGCEHGPQTXDGMTHXTPFOESGKUTPAUEAVIXVA(ConsoleSystem.Arg YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR)
        {
            BasePlayer player = YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Player();
            PlayerInfo playerInfo = PlayerInfo.Find(player.userID);
            if (player != null && YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.HasArgs(1))
            {
                switch (YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[0])
                {
                    case "hidestat":
                        {
                            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.SGLWUOPHZUWTTTHYATQEZOKBLZBUVKJWUUOLVQCOQUABZDEOP && !permission.UserHasPermission(player.UserIDString, DYXDVMORKNKXRGRNJBWQDYXKVXMXCEHQTXSZEXNRBVDACZKZI)) return;
                            if (playerInfo.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV)
                            {
                                playerInfo.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV = false;
                            }
                            else playerInfo.CDJXNFNOIYZPTYZOHSNAOPMOXLKYOECIYLCOLQICTZJOV = true;
                            JTVVQNOVIREDSBDHHALIOYOOFSLBUAAZYJQVZUYMLDI(player, playerInfo);
                            break;
                        }
                    case "confirm":
                        {
                            DPLOZOCDDJVLFGQXBNAHQEFILHHNBZWKPPKPHWBGYXWPNFQTD(player);
                            break;
                        }
                    case "confirm_yes":
                        {
                            if (QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.settings.ZENQTJBNGYJXJRDVTNJUGRGMWDFCZVWXYIXILKRP && !permission.UserHasPermission(player.UserIDString, FWQNCPPKKAGQLLXSASYYFSMTVWXBAIEPMNNMWCGAWALVA)) return;
                            PlayerInfo.QDWDZLXLWMDVJCVPWXCSLXXYUQYVDMVKHXNIFUQPLDYXUTCW(player.userID);
                            LTVRTLCSCXPKJNQEWXWCEQKENQTAPVQOZAYRPHSDQDVJDOR(player);
                            break;
                        }
                    case "changeCategory":
                        {
                            ulong target = ulong.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[1]);
                            int TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST = int.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[2]);
                            SWPRHOKNZVSUKVXGHFUDPACTMFZTHOTSBHQZMBWMFZCLP(player, target, TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST);
                            break;
                        }
                    case "ShowMoreStat":
                        {
                            ulong target = ulong.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[1]);
                            int TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST = int.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[2]);
                            if (TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST == 0) ETIZKVSCCJBWCLELISPQUIWBSEBPNCHHKWMLDTYXP(player, target, 1);
                            else ETIZKVSCCJBWCLELISPQUIWBSEBPNCHHKWMLDTYXP(player, target, 0);
                            break;
                        }
                    case "listplayer":
                        {
                            if (YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args.Length > 1)
                            {
                                string VMPRZHZTKBFNZJZFWSFIVMPLXLWOYGBWCXVBJJIIZBBRINA = YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[1].ToLower();
                                HRZDXAPWKMUANSYMRQANMJCPTKKLZMPSVXHTYBXZXRTNP(player, VMPRZHZTKBFNZJZFWSFIVMPLXLWOYGBWCXVBJJIIZBBRINA);
                            }
                            else HRZDXAPWKMUANSYMRQANMJCPTKKLZMPSVXHTYBXZXRTNP(player);
                            break;
                        }
                    case "GoStatPlayers":
                        {
                            ulong id = ulong.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[1]);
                            LTVRTLCSCXPKJNQEWXWCEQKENQTAPVQOZAYRPHSDQDVJDOR(player, id);
                            break;
                        }
                    case "Page_swap":
                        {
                            int TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST = int.Parse(YQIYRDTJHUHXNYPXOMSEGFEFASZEDWDGPCCIUIWOSR.Args[1]);
                            VAIEPCAHJLWLAAAOBZNJWFEXSUBMPLYEUANNEZKTZLUELCCF(player, TVWAKZDVFELMHUAUVHHNTTKFSCHBHRPKEQVCXNGIKMFST);
                            break;
                        }
                }
            }
        }
        private void UVUGHGNIDGJKHAYNHFFZRKOQOVPWHXOXGYZTKHWLTCRMGPMEC(string AJYYINMUHUUJBWNBQTYBKTBQCXZQMCJRLDQNLNPIO, List<string> embeds, bool inline = false)
        {
            Embed embed = new Embed();
            foreach (var item in embeds)
            {
                embed.ASQAHKHESMQRAFRMEJAECAJTGPSBKYILUZWWHGQPMGO(AJYYINMUHUUJBWNBQTYBKTBQCXZQMCJRLDQNLNPIO, item, inline, QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.WPSNEWFHLBHOJGVATFMLSYLIBTSAYJPZZXKGRRSSXQSVA.GetRandom());
            }
            webrequest.Enqueue(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.XNRUVNSKXCAOQDIPUBPIIMLKFLHWJEXODYEXHTHWHKCWLF, new DiscordMessage(QHTTRPSZZOGKDBPZHQPJTUSLHYDBWWQSFNIAWPVOLKMYTRE.LPFLTJGBVVBMCHSAMFQRAWOKDKNILSDLRTFAFXCRSI.message, embed).ToJson(), (code, response) => { }, this, RequestMethod.POST, new Dictionary<string, string> {
        {
          "Content-Type",
          "application/json"
        }
      });
        }
        private class DiscordMessage
        {
            public DiscordMessage(string content, params Embed[] embeds)
            {
                Content = content;
                Embeds = embeds.ToList();
            }
            [JsonProperty("content")]
            public string Content
            {
                get;
                set;
            }
            [JsonProperty("embeds")]
            public List<Embed> Embeds
            {
                get;
                set;
            }
            public string ToJson()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        private class Embed
        {
            public int color
            {
                get;
                set;
            }
            [JsonProperty("fields")]
            public List<Field> Fields
            {
                get;
                set;
            } = new List<Field>();
            public Embed ASQAHKHESMQRAFRMEJAECAJTGPSBKYILUZWWHGQPMGO(string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI, string QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ, bool inline, int PPKKLQOXALTNWAYPYHNDCEQVHUGFBBYVGPQRQUAPOVIKVZAUN)
            {
                Fields.Add(new Field(KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI, Regex.Replace(QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ, "<.*?>", string.Empty), inline));
                color = PPKKLQOXALTNWAYPYHNDCEQVHUGFBBYVGPQRQUAPOVIKVZAUN;
                return this;
            }
        }
        private class Field
        {
            public Field(string KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI, string QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ, bool inline)
            {
                Name = KPJXFPICDJOTLGVIDZUBSGWHURARDZYDDSYSOMKRMSBWGYUI;
                Value = QJVPVGCHZICDVYEVEEIAERVNWHGNRMUFSLZQRCWJ;
                Inline = inline;
            }
            [JsonProperty("name")]
            public string Name
            {
                get;
                set;
            }
            [JsonProperty("value")]
            public string Value
            {
                get;
                set;
            }
            [JsonProperty("inline")]
            public bool Inline
            {
                get;
                set;
            }
        }
        private JObject UBCMUULCDXFAIWTSRFTTDFWAIVEXSLRVLZYENFHQNFH(ulong id) => JObject.FromObject(PlayerInfo.Find(id));
        private JObject UWNKMYXHNVGPEBEZPOKRGJOIYOEMYCGXYAGLHULUOKIQTJZL(ulong id) => JObject.FromObject(PlayerInfo.Find(id).WNRTXSPEHQXJFVZESHVKOFMHQPJDTJHHOSROYYTUU);
        private Dictionary<string, int> HBYVQPKHEMXTLIKPIQEVSRUCPDVBYPOOTKQBHCIK(ulong id) => PlayerInfo.Find(id)?.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.FNZPNAUHLDEMNKDEUDVZDGJCBLMBGAAPYZROCVDOOLBMAF;
        private int? ECINADBXALSVQJPHWFNUJIPXIAARJHGITZNPLPPZTDXEWTCB(ulong id) => PlayerInfo.Find(id)?.GGEAETEZQROATAWBKGSCSPXQNKDRAVFNLBDFCOBEPIVGJL.YCWTQTWNZDXOBNTALDPONTPCYZGLSEWCWFOYKGJVBM;
        private int? HBYVQPKHEMXTLIKPIQEVSRUCPDVBYPOOTKQBHCIK(ulong id, string shortname)
        {
            Dictionary<string, int> data = HBYVQPKHEMXTLIKPIQEVSRUCPDVBYPOOTKQBHCIK(id);
            int amount = 0;
            if (data?.TryGetValue(shortname, out amount) == true) return amount;
            return null;
        }

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