 /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ using Newtonsoft.Json;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using System.Linq;
using System;
using System.Text;
using UnityEngine;
using Oxide.Game.Rust.Cui;
using System.Collections;
namespace Oxide.Plugins
{
    [Info("IQCraftSystem", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class IQCraftSystem : RustPlugin
    {
        [PluginReference] Plugin ImageLibrary, IQPlagueSkill, IQRankSystem;
        bool UFLBAREDIAKROHQUBLTSHYYNYEPUEXIPQLNTJTZGXBPZMBNE(BasePlayer player) => (bool)IQPlagueSkill?.Call("API_IS_ADVANCED_CRAFT", player);
        bool ZNNODNVHXCVBKYKSVBDUXLIMMUFIYBXRLDFJUAMXRLLQEE(BasePlayer player, string HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB) => (bool)IQRankSystem?.Call("API_GET_AVAILABILITY_RANK_USER", player.userID, HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB);
        string DFHQAJJTOFBCJINIWFDQHSBXVOGCLZRHHHCDRKXHBKRDS(string HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB) => (string)IQRankSystem?.Call("API_GET_RANK_NAME", HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB);
        bool DPEDPLAOFKDJVLDHHOOUUCGJRLIVOXBXFXLRXIJGGSBRZHPLE(string HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB) => (bool)IQRankSystem?.Call("API_IS_RANK_REALITY", HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB);
        string YXLCGXCXANYZIETTLCCVCZHRBETUBYRAXFYIVCEDSTXYZZ = "electric.flasherlight";
        public Dictionary<BasePlayer, int> FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS = new Dictionary<BasePlayer, int>();
        Dictionary<BasePlayer, TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC> ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD = new Dictionary<BasePlayer, TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC>();
        public enum TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC
        {
            KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT,
            HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV,
            VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR,
            Items,
            UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH,
            NYBSDXCPBGCILLZZHSABCRBORQXZVNVRLZPEHGXRYD,
            RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF,
            QGXLSQFRFQEEVWNBNZCUNKKXLVUSBVICYJLHTEFJPWQ,
            OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF,
            Entity,
            ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE
        }
        [JsonProperty("Информация о крафте")] public Hash<ulong, DataCraft> OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP = new Hash<ulong, DataCraft>();
        public class DataCraft
        {
            [JsonProperty("Информация о предметах")] public Dictionary<String, Int32> HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN = new Dictionary<String, Int32>();
        }
        void ReadData()
        {
            OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<Hash<ulong, DataCraft>>("IQCraftSystem/CraftUsers");
        }
        void WriteData()
        {
            Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQCraftSystem/CraftUsers", OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP);
        }
        void CCPXDBIULECFAIIGDYALJYFIOBAOKJWXRUUYIIUJIDWFDBS(ulong player)
        {
            Boolean OANBWKCSOICVABVJQBZLPDWRYKAABBORGBEGZVTDSJUD = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Count(NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK => NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK.Value.Cooldown > 0) != 0;
            if (!OANBWKCSOICVABVJQBZLPDWRYKAABBORGBEGZVTDSJUD) return;
            if (!OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP.ContainsKey(player)) OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP.Add(player, new DataCraft
            {
                HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN = new Dictionary<string, int> { }
            });
        }
        private static Configuration config = new Configuration();
        private class Configuration
        {
            [JsonProperty("Настройка разрешений")] public PermissionSettings HTPSHJHVPHBEGICJOBMVOQPTENVRLSENFBBCDOBIRSGNHHT = new PermissionSettings();
            internal class PermissionSettings
            {
                [JsonProperty("Разрешение крафтов без требования верстака")] public string QUSRPJEQDWNUOQKWCNZFGZGZADDWJBLWUFAQANYVWKZGBH = "iqcraftsystem.noworkbench";
                [JsonProperty("Разрешение крафтов без остальных условий")] public string BHJLUINJROTQMFHHCLQZIPTWPPDJWAZYTJCPZQQOGWJCHWM = "iqcraftsystem.norequires";
            }
            [JsonProperty("Настройка интерфейса плагина")] public InterfaceSettings ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL = new InterfaceSettings();
            [JsonProperty("Настройка предметов, которые возможно скрафтить")] public Dictionary<string, ItemSettings> CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY = new Dictionary<string, ItemSettings>();
            internal class ItemSettings
            {
                [JsonProperty("Перезарядка на крафт предмета (Если она не нужна, поставьте значение 0")] public Int32 Cooldown;
                [JsonProperty("Права для доступа к этому крафту (оставьте поле пустым - будет доступно всем)")] public String Permission;
                [JsonProperty("К какой категории относится данный предмет : 0 - Оружие, 1 - Инструменты, 2 - Конструкции, 3 - Итемы, 4 - Одежда, 5 - Электричество, 6 - Транспорт, 7 - Фановые, 8 - Кастомные(команды), 9 - Иные(Крафтит префабы и предметы по типу Переработчика)")] public TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL;
                [JsonProperty("Отображаемое имя")] public string DisplayName;
                [JsonProperty("Описание (Необязательно)")] public string AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW;
                [JsonProperty("Shortname (Подходит ко всем категориям КРОМЕ : 6 - Транспорт и 8 - Кастомные(команды) и 9 - Иные(Крафтит префабы и предметы по типу Переработчика)")] public string Shortname;
                [JsonProperty("SkinID (Подходит ко всем категориям (Если вы используете категорию 6 - Транспорт или - 9 - Иные , обязательно устанавливайте SkinID для иконки)")] public ulong SkinID;
                [JsonProperty("PNG (Подходит только к категории : 6 - Транспорт и 8 - Кастомные(команды) и 9 - Иные(Крафтит префабы и предметы по типу Переработчика))")] public string LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX;
                [JsonProperty("Команда (Подходит только к категории : 8 - Кастомные(команды) %STEAMID% - заменится на Steam64ID игрока)")] public string Command;
                [JsonProperty("Префаб для транспорта (Подходит только к категории 6 - Транспорт)")] public string PrefabNameTransport;
                [JsonProperty("Префаб для предметов (Подходит только к категории 9 - Иные(Крафтит префабы и предметы по типу Переработчика))")] public string PrefabEntity;
                [JsonProperty("Какой уровень верстака требуется для крафта нужен, если верстак не требуется, установите 0")] public int MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC;
                [JsonProperty("IQPlagueSkill : Требуется ли нейтральный навык в IQPlagueSkill для крафта данного предмета(true - да/false - нет)")] public bool OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ;
                [JsonProperty("IQRankSystem : Укажите ранг, который требуется для крафта данного предмета(Если не нужно, оставьте поле пустым)")] public string WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ;
                [JsonProperty("Список предметов требующихся для крафта")] public List<ItemForCraft> MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemForCraft>();
                internal class ItemForCraft
                {
                    [JsonProperty("Shortname")] public string Shortname;
                    [JsonProperty("Количество")] public int Amount;
                    [JsonProperty("SkinID если требуется")] public ulong SkinID;
                    [JsonProperty("PNG для кастомных предметов (не забудьте установить SkinID)")] public string LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX;
                }
            }
            internal class InterfaceSettings
            {
                [JsonProperty("Настройка категорий")] public CategorySettings UZORUXDOLVXKHAXTCOYWBHBBCSHGESIRRRMITKUCPUNLS = new CategorySettings();
                [JsonProperty("Настройка требований")] public RequiresSettings RequiresSetting = new RequiresSettings();
                internal class RequiresSettings
                {
                    [JsonProperty("HEX : Цвет если требование выполнено")] public string RequiresDoTrueColor;
                    [JsonProperty("HEX : Цвет если требование не выполнено")] public string RequiresDoFalseColor;
                    [JsonProperty("Символ выполненного требования")] public string RequiresDoTrue;
                    [JsonProperty("HEX : Цвет если условие не требования")] public string RequiresDoFalse;
                }
                internal class CategorySettings
                {
                    [JsonProperty("Включения и отключения категорий")] public HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG TLKAZXPXCQNFUFSRECBTUYIZEBVOYKIWFYKTOIKSRMW = new HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG();
                    internal class HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG
                    {
                        [JsonProperty("Включить категорию оружие?")] public Boolean DHDPGGVHXROVDLWXBAZRIQZVUZCVSJBIBFVWXGIRP = true;
                        [JsonProperty("Включить категории инструментов")] public Boolean ZOJPPDMMRRMEUMHHUHEAONQGTYQZAURHCHRKLFJY = false;
                        [JsonProperty("Включить категории конструкций")] public Boolean FSJVWKIOPLANOMLYDWRMMMWZFCNVXVPYFRJUGLWNIKK = false;
                        [JsonProperty("Включить категории одежды")] public Boolean RTNUFMIIRLVSWJPUXMRUVCIXDRRRZDECCMILOSPKNHG = true;
                        [JsonProperty("Включить категории транспорта")] public Boolean VQYXVBQVTQNOLQROUQIOHTPJBEGEXGGOWOBMSUWYNJJMZUZ = true;
                        [JsonProperty("Включить кастомных предметов")] public Boolean AAQWYRMBAOWRVLYMJYRXPFVAUKAYKDKGEJDWQKQECZLEYECCL = true;
                    }
                }
            }
            public static Configuration GetNewConfiguration()
            {
                return new Configuration
                {
                    ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL = new InterfaceSettings
                    {
                        RequiresSetting = new InterfaceSettings.RequiresSettings
                        {
                            RequiresDoFalse = "?",
                            RequiresDoTrue = "?",
                            RequiresDoFalseColor = "#FF3366",
                            RequiresDoTrueColor = "#CCFFCC",
                        },
                    },
                    CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY = new Dictionary<string, ItemSettings>
                    {
                        ["ak47"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT,
                            Permission = "iqcraftsystem.ak47",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "Хорошее оружие для стрельбы на дальние и средние дистанции",
                            DisplayName = "АК-47",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "rifle.ak",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 0,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 500, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "scrap", Amount = 15, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "explosives", Amount = 1, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["jackhammer"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV,
                            Permission = "",
                            Cooldown = 5000,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "",
                            DisplayName = "Jackhammer",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "jackhammer",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 500, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "scrap", Amount = 15, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "explosives", Amount = 1, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["hazmatsuit"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "",
                            DisplayName = "Хазмат",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "hazmatsuit",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 3,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["floor.ladder.hatch"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "Удобно спргынуть и не вернуться",
                            DisplayName = "Люк",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "floor.ladder.hatch",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["privilegy3d"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF,
                            Permission = "",
                            Cooldown = 0,
                            Command = "say GivePrivilegy",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "Целая привилегия на 3 целых дня, самый лучший вариант",
                            DisplayName = "ПРИВИЛЕГИЯ 3 ДНЯ",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "https://i.imgur.com/vLCj3kO.png",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["turret"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.NYBSDXCPBGCILLZZHSABCRBORQXZVNVRLZPEHGXRYD,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "",
                            DisplayName = "Турель",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "autoturret",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "metal.refined", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["tree"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "Возьми и всади дерево",
                            DisplayName = "Дерево",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "https://i.imgur.com/XnuUmyZ.png",
                            PrefabEntity = "assets/bundled/prefabs/autospawn/resource/v2_temp_forest/pine_c.prefab",
                            PrefabNameTransport = "",
                            Shortname = "",
                            SkinID = 1337,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["firewerk"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.QGXLSQFRFQEEVWNBNZCUNKKXLVUSBVICYJLHTEFJPWQ,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "Взорвик небо",
                            DisplayName = "Фейверк",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "firework.romancandle.red",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["swetilnik"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Items,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "",
                            DisplayName = "Светилка на стенку",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "",
                            PrefabEntity = "",
                            PrefabNameTransport = "",
                            Shortname = "xmas.lightstring",
                            SkinID = 0,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                        ["copter"] = new ItemSettings
                        {
                            DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF,
                            Permission = "",
                            Cooldown = 0,
                            Command = "",
                            AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW = "",
                            DisplayName = "Коптер",
                            LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "https://i.imgur.com/kC8tfXF.png",
                            PrefabEntity = "",
                            PrefabNameTransport = "assets/content/vehicles/minicopter/minicopter.entity.prefab",
                            Shortname = "",
                            SkinID = 3333,
                            MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC = 1,
                            WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ = "",
                            OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ = false,
                            MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR = new List<ItemSettings.ItemForCraft> {
                                                                new ItemSettings.ItemForCraft {
                                                                        Shortname = "wood", Amount = 100, LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX = "", SkinID = 0
                                                                },
                                                        }
                        },
                    },
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
                PrintWarning($"Ошибка чтения #57 конфигурации 'oxide/config/{Name}', создаём новую конфигурацию!!");
                LoadDefaultConfig();
            }
            NextTick(SaveConfig);
        }
        protected override void LoadDefaultConfig() => config = Configuration.GetNewConfiguration();
        protected override void SaveConfig() => Config.WriteObject(config);
        public void SetCooldown(BasePlayer player, String KeyItem)
        {
            Int32 Cooldown = Convert.ToInt32(config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY[KeyItem].Cooldown + CurrentTime());
            if (Cooldown - CurrentTime() <= 1) return;
            if (!OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP.ContainsKey(player.userID)) CCPXDBIULECFAIIGDYALJYFIOBAOKJWXRUUYIIUJIDWFDBS(player.userID);
            if (!OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN.ContainsKey(KeyItem)) OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN.Add(KeyItem, Cooldown);
            else OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN[KeyItem] = Cooldown;
        }
        public String GetCooldown(BasePlayer player, String KeyItem)
        {
            String DACCIVEPBNRORXEPMMHBVYIMUPTRCQHYNOAJECAISBICNOIO = FormatTime(TimeSpan.FromSeconds(GetCooldownTime(OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN[KeyItem])), player.UserIDString);
            return DACCIVEPBNRORXEPMMHBVYIMUPTRCQHYNOAJECAISBICNOIO;
        }
        public Boolean IsCooldown(BasePlayer player, String KeyItem)
        {
            if (!OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP.ContainsKey(player.userID))
            {
                CCPXDBIULECFAIIGDYALJYFIOBAOKJWXRUUYIIUJIDWFDBS(player.userID);
                return false;
            }
            if (!OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN.ContainsKey(KeyItem)) return false;
            if (GetCooldownTime(OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN[KeyItem]) > 0) return true;
            else
            {
                OSISCRQLDKYBAICUYQZNNUPMELEKTQBLWBBPUFJKTBBIZGVRP[player.userID].HPRPMUCWNRMFRNIMFZHNZSHPULSGMXPNUBJMUGPHMYRSXN.Remove(KeyItem);
                return false;
            }
        }
        public string IRQUJAESPISBMNLFTADXVKKLZJUQFZGHFSTYRDDNVROUIGFNX = "server.stop";
        public Double GetCooldownTime(Int32 Cooldown) => (Cooldown - CurrentTime());
        static readonly DateTime UNEREYHFVAGOMQCKWUTNOPXQBEWQCSDGTIFSCONVRLICGHEY = new DateTime(1970, 1, 1, 0, 0, 0);
        static Double CurrentTime()
        {
            return DateTime.UtcNow.Subtract(UNEREYHFVAGOMQCKWUTNOPXQBEWQCSDGTIFSCONVRLICGHEY).TotalSeconds;
        }
        public String FormatTime(TimeSpan time, String UserID)
        {
            String Result = String.Empty;
            String Days = GetLang("TITLE_FORMAT_LOCKED_DAYS", UserID);
            String Hourse = GetLang("TITLE_FORMAT_LOCKED_HOURSE", UserID);
            String Minutes = GetLang("TITLE_FORMAT_LOCKED_MINUTES", UserID);
            String Seconds = GetLang("TITLE_FORMAT_LOCKED_SECONDS", UserID);
            if (time.Seconds != 0) Result = $"{Format(time.Seconds, Seconds, Seconds, Seconds)}";
            if (time.Minutes != 0) Result = $"{Format(time.Minutes, Minutes, Minutes, Minutes)}";
            if (time.Hours != 0) Result = $"{Format(time.Hours, Hourse, Hourse, Hourse)}";
            if (time.Days != 0) Result = $"{Format(time.Days, Days, Days, Days)}";
            return Result;
        }
        private String Format(Int32 XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI, String JQWWGYMLLFQDMTXQJHBQGFRXSRSYWUIPOFTYRQKWFWOK, String QDTOEFWBSEDYYEOGNOQXAOHAYZTWEKKRHMCOYKRPLOWA, String ZSLWQRHXMKBVTPFMAWHUMRMBZIDXBMMSHJZHHAOSCTVCAS)
        {
            var YJKUJIFPOPABQDCXZUELJHIHYWDGVJTZXYEITMJAZCNYNT = XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI % 10;
            if (XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI >= 5 && XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI <= 20 || YJKUJIFPOPABQDCXZUELJHIHYWDGVJTZXYEITMJAZCNYNT >= 5 && YJKUJIFPOPABQDCXZUELJHIHYWDGVJTZXYEITMJAZCNYNT <= 9) return $"{XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI}{JQWWGYMLLFQDMTXQJHBQGFRXSRSYWUIPOFTYRQKWFWOK}";
            if (YJKUJIFPOPABQDCXZUELJHIHYWDGVJTZXYEITMJAZCNYNT >= 2 && YJKUJIFPOPABQDCXZUELJHIHYWDGVJTZXYEITMJAZCNYNT <= 4) return $"{XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI}{QDTOEFWBSEDYYEOGNOQXAOHAYZTWEKKRHMCOYKRPLOWA}";
            return $"{XLEVYXINGHYMIFJRJLSXPDONMQVRHAPBTQNLVODCI}{ZSLWQRHXMKBVTPFMAWHUMRMBZIDXBMMSHJZHHAOSCTVCAS}";
        }
        public bool ITDRKSKDXGJBAUKCIFOFOKYVDQDGCAEMJIFRGFMYJQBBYSI(BasePlayer player, int UMDLROGEIGKWINKWAXJOJQYEZHPSSWKAHCJKXBUDA) => (bool)(player.currentCraftLevel >= UMDLROGEIGKWINKWAXJOJQYEZHPSSWKAHCJKXBUDA);
        public bool SUWYNMEYUINTPEBWCWSSPTVDSPWYJWXKIPNHDGZWDGWYR(BasePlayer player) => (bool)UFLBAREDIAKROHQUBLTSHYYNYEPUEXIPQLNTJTZGXBPZMBNE(player);
        public bool JFOEZBAQYZYTFXQGPYKCLZQTTVWVOIXXLAGRJEXVKRQOJKA(BasePlayer player, string HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB) => (bool)ZNNODNVHXCVBKYKSVBDUXLIMMUFIYBXRLDFJUAMXRLLQEE(player, HBQGRTNSOOSLIVFZNKVHJVTKWZKBAQYPXVJOEVCURIB);
        public bool FXRYNPGJOULDEFBQBAIFQZWKAPSUIBKJVUPRRZKVU(BasePlayer player, string Shortname, int Amount, ulong SkinID = 0)
        {
            int IGFHMZNIQBDVNEYUFWADSZTDNLDLGTKTEVVAQBGZ = 0;
            foreach (var TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN in player.inventory.AllItems())
            {
                if (TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN == null) continue;
                if (TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.info.shortname != Shortname) continue;
                if (TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.skin != SkinID) continue;
                IGFHMZNIQBDVNEYUFWADSZTDNLDLGTKTEVVAQBGZ += TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.amount;
            }
            return IGFHMZNIQBDVNEYUFWADSZTDNLDLGTKTEVVAQBGZ >= Amount;
        }
        bool COTUQEQAMICVMGBGXXXMAMJCHKPKZCPMKSWHRGZNDIPCGZHJP(BasePlayer player, List<Configuration.ItemSettings.ItemForCraft> QBWEGERWVEREVDNYLKZOLMVJPFEZZYCFNDAXIVBKAV)
        {
            int PNHPQVVBIIBMPHJNBUAWBBWRJRRJYDDPATCLLOWQIJXL = 0;
            for (int i = 0; i < QBWEGERWVEREVDNYLKZOLMVJPFEZZYCFNDAXIVBKAV.Count; i++)
            {
                var Item = QBWEGERWVEREVDNYLKZOLMVJPFEZZYCFNDAXIVBKAV[i];
                if (FXRYNPGJOULDEFBQBAIFQZWKAPSUIBKJVUPRRZKVU(player, Item.Shortname, Item.Amount, Item.SkinID)) PNHPQVVBIIBMPHJNBUAWBBWRJRRJYDDPATCLLOWQIJXL++;
            }
            return PNHPQVVBIIBMPHJNBUAWBBWRJRRJYDDPATCLLOWQIJXL >= QBWEGERWVEREVDNYLKZOLMVJPFEZZYCFNDAXIVBKAV.Count;
        }
        public void BNXHWQERMFPGBKSPKTJTPRXKISXHVIDFUOBCODWGCZUT(string FJCHFWYPKEMUDFNPBARXWCMRSDQQQJPNPLQAMXYC)
        {
            if (!String.IsNullOrWhiteSpace(FJCHFWYPKEMUDFNPBARXWCMRSDQQQJPNPLQAMXYC))
                if (!permission.PermissionExists(FJCHFWYPKEMUDFNPBARXWCMRSDQQQJPNPLQAMXYC, this)) permission.RegisterPermission(FJCHFWYPKEMUDFNPBARXWCMRSDQQQJPNPLQAMXYC, this);
        }
        void GiveItemUser(ulong userID, string ItemKey)
        {
            var Item = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY[ItemKey];
            BasePlayer player = BasePlayer.FindByID(userID);
            switch (Item.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL)
            {
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.NYBSDXCPBGCILLZZHSABCRBORQXZVNVRLZPEHGXRYD:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.QGXLSQFRFQEEVWNBNZCUNKKXLVUSBVICYJLHTEFJPWQ:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Items:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV:
                    {
                        Item item = ItemManager.CreateByName(Item.Shortname, 1, Item.SkinID);
                        if (!String.IsNullOrWhiteSpace(Item.DisplayName)) item.name = Item.DisplayName;
                        player.GiveItem(item);
                        break;
                    }
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF:
                    {
                        rust.RunServerCommand(Item.Command.Replace("%STEAMID%", player.UserIDString));
                        break;
                    }
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity:
                    {
                        Item item = ItemManager.CreateByName(YXLCGXCXANYZIETTLCCVCZHRBETUBYRAXFYIVCEDSTXYZZ, 1, Item.SkinID);
                        if (!String.IsNullOrWhiteSpace(Item.DisplayName)) item.name = Item.DisplayName;
                        player.GiveItem(item);
                        break;
                    }
            }
        }
        public string OVVIWMWGSGWWSIOLCJVPRJEGDXZORQJBNMRBFDBXRLL = "";
        void SpawnItem(BaseEntity entity)
        {
            if (entity == null) return;
            var ItemSpawn = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.FirstOrDefault(NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK => NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK.Value.SkinID == entity.skinID).Value;
            if (ItemSpawn == null) return;
            if (ItemSpawn.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity || ItemSpawn.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF)
            {
                string Prefab = ItemSpawn.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF ? ItemSpawn.PrefabNameTransport : ItemSpawn.PrefabEntity;
                BaseEntity SpawnedEntity = (BaseEntity)GameManager.server.CreateEntity(Prefab, entity.transform.position, entity.transform.rotation);
                if (SpawnedEntity == null) return;
                SpawnedEntity.Spawn();
                NextTick(() => entity.Kill());
            }
        }
        void CraftingItem(BasePlayer player, string ItemKey)
        {
            var Item = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY[ItemKey];
            if (!permission.UserHasPermission(player.UserIDString, config.HTPSHJHVPHBEGICJOBMVOQPTENVRLSENFBBCDOBIRSGNHHT.BHJLUINJROTQMFHHCLQZIPTWPPDJWAZYTJCPZQQOGWJCHWM)) foreach (var ItemTake in Item.MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR)
                {
                    Item Take = player.inventory.AllItems().FirstOrDefault(i => i.skin == ItemTake.SkinID && i.info.shortname == ItemTake.Shortname);
                    if (Take == null) return;
                    player.inventory.Take(null, Take.info.itemid, ItemTake.Amount);
                }
            switch (Item.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL)
            {
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.NYBSDXCPBGCILLZZHSABCRBORQXZVNVRLZPEHGXRYD:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.QGXLSQFRFQEEVWNBNZCUNKKXLVUSBVICYJLHTEFJPWQ:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Items:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV:
                    {
                        Item item = ItemManager.CreateByName(Item.Shortname, 1, Item.SkinID);
                        if (!String.IsNullOrWhiteSpace(Item.DisplayName)) item.name = Item.DisplayName;
                        player.GiveItem(item);
                        break;
                    }
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF:
                    {
                        rust.RunServerCommand(Item.Command.Replace("%STEAMID%", player.UserIDString));
                        break;
                    }
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF:
                case TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity:
                    {
                        Item item = ItemManager.CreateByName(YXLCGXCXANYZIETTLCCVCZHRBETUBYRAXFYIVCEDSTXYZZ, 1, Item.SkinID);
                        if (!String.IsNullOrWhiteSpace(Item.DisplayName)) item.name = Item.DisplayName;
                        player.GiveItem(item);
                        break;
                    }
            }
            SetCooldown(player, ItemKey);
            if (IsCooldown(player, ItemKey)) UPWFODYRXBCCYLJHDPQCTOLUREENUDQKMKHFHUZQWPQBUK(player);
            else DMDDNRBTJWNURIEBXXSGTJFHZVLPJWOTGTJAMZVPJ(player, ItemKey);
            PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
            INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE, -1);
        }
        private void OnEntityBuilt(Planner JSBAIWSUFZJJXECXLOBGHZBPZESOMCDBOWNKKQJH, GameObject WKJFERGODBJXWTKQLBEDDHCWHUBRSMUFUHLOSJVMLAJBUERDD)
        {
            SpawnItem(WKJFERGODBJXWTKQLBEDDHCWHUBRSMUFUHLOSJVMLAJBUERDD.ToBaseEntity());
        }
        private void Init() => ReadData();
        private void OnServerInitialized()
        {
            var Items = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY;
            var Interface = config.ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL;
            var MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG = Interface.RequiresSetting;
            foreach (var Icon in Items.Where(NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK => NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF || NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF || NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity))
            {
                if (Icon.Value.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX == String.Empty)
                {}
                else
                {
                    ImageLibrary.Call("AddImage", Icon.Value.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX, Icon.Value.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX);
                }
            }
            foreach (var Item in Items)
            {
            }
            foreach (var Item in Items)
            {
          
            }
            foreach (var p in BasePlayer.activePlayerList) OnPlayerConnected(p);
            foreach (var Item in config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY) BNXHWQERMFPGBKSPKTJTPRXKISXHVIDFUOBCODWGCZUT(Item.Value.Permission);
        }
        void Unload()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList) BGGPSLSVQCVTLSUQDATSJUAHNJUWQOHCADCSBAHU(player);
            WriteData();
        }
        void OnPlayerConnected(BasePlayer player)
        {
            CCPXDBIULECFAIIGDYALJYFIOBAOKJWXRUUYIIUJIDWFDBS(player.userID);
        }
        void OpenCrafts(BasePlayer player)
        {
            FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
            BTYLDDYHNSKTURHFZBIRVEBUSSHPBODSZGHACVKFWPDV(player);
        }
        [ConsoleCommand("craft_give")]
        void FDPRNLUVTQIQWFGNLZNSZZSLNDNTSEYDFPLLHMZZRXENK(ConsoleSystem.Arg arg)
        {
            if (!arg.Player().IsAdmin)
            {
                return;
            }
            if (arg == null || arg.Args == null || arg.Args.Length < 2)
            {
                PrintWarning("Используйте синтаксис : craft_give SteamID Ключ(из кфг)");
                return;
            }
            if (arg.Args[0] == null || String.IsNullOrWhiteSpace(arg.Args[0]))
            {
                PrintWarning("Вы неверно указали SteamID\nИспользуйте синтаксис : craft_give SteamID Ключ(из кфг)");
                return;
            }
            ulong userID = ulong.Parse(arg.Args[0]);
            if (arg.Args[1] == null || String.IsNullOrWhiteSpace(arg.Args[1]))
            {
                PrintWarning("Вы неверно указали ключ из кфг\nИспользуйте синтаксис : craft_give SteamID Ключ(из кфг)");
                return;
            }
            string ItemKey = (string)arg.Args[1];
            if (!config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.ContainsKey(ItemKey))
            {
                PrintWarning("Такого ключа не существует в конфигурации, используйте верный ключ!");
                return;
            }
            GiveItemUser(userID, ItemKey);
        }
        [ConsoleCommand("func_craft")]
        void JSMDACQZNFLEDJXACOREKGTUFZAOACVEAOTVHODWMGBGACIPB(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null) return;
            string EEYJTJOLHLBKQFWBRTFXSDGOTCLVUPZIBAQLBJKDHRNQ = arg.Args[0];
            switch (EEYJTJOLHLBKQFWBRTFXSDGOTCLVUPZIBAQLBJKDHRNQ)
            {
                case "close_ui":
                    {
                        BGGPSLSVQCVTLSUQDATSJUAHNJUWQOHCADCSBAHU(player);
                        break;
                    }
                case "category_all":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, true);
                        break;
                    }
                case "category_attirie":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, true);
                        break;
                    }
                case "category_construction":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, true);
                        break;
                    }
                case "category_custom":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, true);
                        break;
                    }
                case "category_electrical":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, true);
                        break;
                    }
                case "category_fun":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, false, true);
                        break;
                    }
                case "category_items":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, false, false, true);
                        break;
                    }
                case "category_tools":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, false, false, false, true);
                        break;
                    }
                case "category_transport":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, false, false, false, false, true);
                        break;
                    }
                case "category_weapon":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] = 0;
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN);
                        JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, false, false, false, false, false, false, false, false, false, true);
                        break;
                    }
                case "select_item":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        int DQLXMTQJZJQUMFEMLUWPMVXNPDJOEHFOTNNUYIYYF = int.Parse(arg.Args[2]);
                        string ItemKey = arg.Args[3];
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN, DQLXMTQJZJQUMFEMLUWPMVXNPDJOEHFOTNNUYIYYF);
                        DMDDNRBTJWNURIEBXXSGTJFHZVLPJWOTGTJAMZVPJ(player, ItemKey);
                        break;
                    }
                case "craft_item":
                    {
                        string ItemKey = arg.Args[1];
                        CraftingItem(player, ItemKey);
                        break;
                    }
                case "next.page":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        CuiHelper.DestroyUi(player, CRAFTSYSTEM_HUD + ".PS");
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player]++;
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN, 0);
                        break;
                    }
                case "back.page":
                    {
                        TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN = (TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC)int.Parse(arg.Args[1]);
                        CuiHelper.DestroyUi(player, CRAFTSYSTEM_HUD + ".PS");
                        PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
                        FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player]--;
                        INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, PBAAFZFYIRBYJPQXTRRLSIQPLAIICQBQQYEALUOPTKTIPN, 0);
                        break;
                    }
            }
        }
        public static string CRAFTSYSTEM_HUD = "CRAFTSYSTEM_HUD";
        void UPWFODYRXBCCYLJHDPQCTOLUREENUDQKMKHFHUZQWPQBUK(BasePlayer player)
        {
            for (int ItemCount = 0; ItemCount < 15; ItemCount++)
            {
                CuiHelper.DestroyUi(player, $"REQUIRES_ITEM_AMOUNT_{ItemCount}");
                CuiHelper.DestroyUi(player, $"REQUIRES_ITEM_ICO_{ItemCount}");
                CuiHelper.DestroyUi(player, $"REQUIRES_ITEM_LOGO_{ItemCount}");
                CuiHelper.DestroyUi(player, $"REQUIRES_ITEM_{ItemCount}");
            }
            CuiHelper.DestroyUi(player, "CREATE_ITEM_BUTTON");
            CuiHelper.DestroyUi(player, "REQUIRES_ITEM_LIST_TITLE");
            CuiHelper.DestroyUi(player, "REQUIRES_ITEM_LIST_PANEL");
            CuiHelper.DestroyUi(player, "TITLE_REQUIRES");
            CuiHelper.DestroyUi(player, "WORKBENCH_REQ");
            CuiHelper.DestroyUi(player, "WORKBENCH_REQ_ICON");
            CuiHelper.DestroyUi(player, "IQPLAGUESKILL");
            CuiHelper.DestroyUi(player, "IQPLAGUESKILL_ICON");
            CuiHelper.DestroyUi(player, "IQRANKSYSTEM_REQ_ICON");
            CuiHelper.DestroyUi(player, "IQRANKSYSTEM");
            CuiHelper.DestroyUi(player, "DESCRIPTION_CRAFT_INFO");
            CuiHelper.DestroyUi(player, "TITLE_CRAFT_INFO");
            CuiHelper.DestroyUi(player, "ICON_CRAFT_INFO");
            CuiHelper.DestroyUi(player, "CRAFT_INFORMATION_PANEL");
        }
        void PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(BasePlayer player)
        {
            TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF = !ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD.ContainsKey(player) ? TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE : ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD[player];
            int UUFNAVEYGLKOFRXVSQLIKKPMYCBSHPHZYINOXCAULAXPAF = 0;
            var Items = VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE ? config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY : config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Where(i => i.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF);
            foreach (var Item in Items)
            {
                CuiHelper.DestroyUi(player, $"ITEM_ICON_{UUFNAVEYGLKOFRXVSQLIKKPMYCBSHPHZYINOXCAULAXPAF}");
                CuiHelper.DestroyUi(player, $"ITEM_BACKGROUND_{UUFNAVEYGLKOFRXVSQLIKKPMYCBSHPHZYINOXCAULAXPAF}");
                CuiHelper.DestroyUi(player, $"ITEMS_{UUFNAVEYGLKOFRXVSQLIKKPMYCBSHPHZYINOXCAULAXPAF}");
                UUFNAVEYGLKOFRXVSQLIKKPMYCBSHPHZYINOXCAULAXPAF++;
            }
            CuiHelper.DestroyUi(player, "ITEM_PANEL");
            CuiHelper.DestroyUi(player, CRAFTSYSTEM_HUD + ".PS");
        }
        void BGGPSLSVQCVTLSUQDATSJUAHNJUWQOHCADCSBAHU(BasePlayer player)
        {
            UPWFODYRXBCCYLJHDPQCTOLUREENUDQKMKHFHUZQWPQBUK(player);
            PWTZTZZWGEBOKYLXULSPOEEZIPZFEXJAGWPQBDWKNN(player);
            CuiHelper.DestroyUi(player, "CLOSE_BTN");
            CuiHelper.DestroyUi(player, "CLOSE_ICON");
            CuiHelper.DestroyUi(player, "CATEGORY_WEAPON");
            CuiHelper.DestroyUi(player, "CATEGORY_WEAPON" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_TRANSPORT");
            CuiHelper.DestroyUi(player, "CATEGORY_TRANSPORT" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_TOOLS");
            CuiHelper.DestroyUi(player, "CATEGORY_TOOLS" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_ITEMS");
            CuiHelper.DestroyUi(player, "CATEGORY_ITEMS" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_FUN");
            CuiHelper.DestroyUi(player, "CATEGORY_FUN" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_ELECTRICAL");
            CuiHelper.DestroyUi(player, "CATEGORY_ELECTRICAL" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_CUSTOM");
            CuiHelper.DestroyUi(player, "CATEGORY_CUSTOM" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_CONSTRUCTION");
            CuiHelper.DestroyUi(player, "CATEGORY_CONSTRUCTION" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_ATTIRIE");
            CuiHelper.DestroyUi(player, "CATEGORY_ATTIRIE" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_ALL");
            CuiHelper.DestroyUi(player, "CATEGORY_ALL" + "BUTTON");
            CuiHelper.DestroyUi(player, "CATEGORY_PANEL");
            CuiHelper.DestroyUi(player, "LOGO");
            CuiHelper.DestroyUi(player, "DESCRIPTION");
            CuiHelper.DestroyUi(player, "TITLE");
            CuiHelper.DestroyUi(player, CRAFTSYSTEM_HUD);
        }
        void BTYLDDYHNSKTURHFZBIRVEBUSSHPBODSZGHACVKFWPDV(BasePlayer player)
        {
            BGGPSLSVQCVTLSUQDATSJUAHNJUWQOHCADCSBAHU(player);
            var Interface = config.ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL;
            float FadeOut = 0;
            float FadeIn = 0;
            CuiElementContainer YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE = new CuiElementContainer();
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
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
            }, "MS_UI", CRAFTSYSTEM_HUD);
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel()
            {
                CursorEnabled = true,
                RectTransform = {
                                        AnchorMin = "0 1",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 -60",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0.15 0.17 0.13 0"
                                }
            }, CRAFTSYSTEM_HUD, CRAFTSYSTEM_HUD + ".RedPanel");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel()
            {
                CursorEnabled = true,
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, CRAFTSYSTEM_HUD + ".RedPanel", CRAFTSYSTEM_HUD + ".Left");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel()
            {
                CursorEnabled = true,
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 0.9",
                                        OffsetMin = "0 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0.117 0.121 0.109 0"
                                }
            }, CRAFTSYSTEM_HUD, CRAFTSYSTEM_HUD + ".CONTENT_MAIN");
            CuiHelper.AddUi(player, YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE);
            JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(player, true);
            INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(player, TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE, -1);
        }
        public string ENCAZKGLPPMUNPLBNIXWEHWDPQWCNPWVZYUCNPXAHOW = ConVar.Server.ip;
        void JFMVMCYYDQWSDTLWIFYPSUOJGDERDVGBFXJMUUOMFTWPLIYB(BasePlayer player, bool ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE = false, bool UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH = false, bool VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR = false, bool OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF = false, bool NYBSDXCPBGCILLZZHSABCRBORQXZVNVRLZPEHGXRYD = false, bool QGXLSQFRFQEEVWNBNZCUNKKXLVUSBVICYJLHTEFJPWQ = false, bool Items = false, bool HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV = false, bool RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF = false, bool KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT = false)
        {
            var Interface = config.ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL;
            var HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG = Interface.UZORUXDOLVXKHAXTCOYWBHBBCSHGESIRRRMITKUCPUNLS.TLKAZXPXCQNFUFSRECBTUYIZEBVOYKIWFYKTOIKSRMW;
            int Add = 0;
            CuiHelper.DestroyUi(player, ".ButtonsMenu");
            CuiElementContainer YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE = new CuiElementContainer();
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "0 0",
                                                OffsetMax = "0 0"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, CRAFTSYSTEM_HUD + ".Left", ".ButtonsMenu");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
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
                }, ".ButtonsMenu", ".Buttons");
                Add++;
            }
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
            {
                Parent = ".Buttons",
                Name = "All",
                Components = {
                                        new CuiRawImageComponent {
                                                Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE ? "1 1 1 1" : "1 1 1 0.2"
                                        },
                                        new CuiRectTransformComponent {
                                                AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "6 0", OffsetMax = "118 51"
                                        }
                                }
            });
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = $"func_craft category_all {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE:d}"
                                },
                Text = {
                                        Text = GetLang("UI_CATEGORY_ALL", player.UserIDString),
                                        Align = TextAnchor.MiddleCenter,
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 18,
                                        Color = ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                }
            }, "All");
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.DHDPGGVHXROVDLWXBAZRIQZVUZCVSJBIBFVWXGIRP)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Weapon",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_weapon {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_WEAPON", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 16,
                                                Color = KOPKATPLYJUDLKTAJUNEOLHDKZJQUIYKXASXVZJBT ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Weapon");
                Add++;
            }
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.RTNUFMIIRLVSWJPUXMRUVCIXDRRRZDECCMILOSPKNHG)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Attirie",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_attirie {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_ATTIRIE", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 16,
                                                Color = UQBCVHUXJNLRQGJUHSAWDBDMCKPTPUVVZFHMAACHEPVMFUH ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Attirie");
                Add++;
            }
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.FSJVWKIOPLANOMLYDWRMMMWZFCNVXVPYFRJUGLWNIKK)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Construction",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_construction {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_CONSTRUCTION", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 14,
                                                Color = VREDVHOSMPZKSBHPSPSKYXUGPTSOFRGIDOXYPRZR ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Construction");
                Add++;
            }
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.ZOJPPDMMRRMEUMHHUHEAONQGTYQZAURHCHRKLFJY)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Tools",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_tools {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_TOOLS", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 14,
                                                Color = HVUITFKRWJUFVAAWVNQKHBFMLFHIUSFRUJQQBMZV ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Tools");
                Add++;
            }
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.VQYXVBQVTQNOLQROUQIOHTPJBEGEXGGOWOBMSUWYNJJMZUZ)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Transport",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_transport {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_TRANSPORT", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 16,
                                                Color = RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Transport");
                Add++;
            }
            if (HJIDDOILEIGXRZKJNDYZTQUOVIOXKWOPKSVGHTYZG.AAQWYRMBAOWRVLYMJYRXPFVAUKAYKDKGEJDWQKQECZLEYECCL)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = ".Buttons",
                    Name = "Custom",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF ? "1 1 1 1" : "1 1 1 0.2"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{6 + (118 * Add)} 0", OffsetMax = $"{118 + (118 * Add)} 51"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"func_craft category_custom {TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF:d}"
                                        },
                    Text = {
                                                Text = GetLang("UI_CATEGORY_CUSTOM", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-bold.ttf",
                                                FontSize = 16,
                                                Color = OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
                                        }
                }, "Custom");
                Add++;
            }
            CuiHelper.AddUi(player, YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE);
        }
        void INJEGEPRCOJXHVIJVMGKYBNRMKYXYYYFCSUHXWZSUVSGFOYXO(BasePlayer player, TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE, int DQLXMTQJZJQUMFEMLUWPMVXNPDJOEHFOTNNUYIYYF = 0)
        {
            if (!ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD.ContainsKey(player)) ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD.Add(player, VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF);
            else ASAACYKXWCBXAZIJLIECFWICZBQHDXLBJNFSXHWZSLFGQD[player] = VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF;
            var Interface = config.ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL;
            var Items = VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE ? config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Where(p => String.IsNullOrWhiteSpace(p.Value.Permission) || permission.UserHasPermission(player.UserIDString, p.Value.Permission)).Skip(24 * FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player]).Take(24) : config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Where(p => String.IsNullOrWhiteSpace(p.Value.Permission) || permission.UserHasPermission(player.UserIDString, p.Value.Permission)).Where(i => i.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF).Skip(24 * FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player]).Take(24);
            float FadeOut = 0;
            float FadeIn = 0;
            CuiElementContainer YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE = new CuiElementContainer();
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                FadeOut = FadeOut,
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        FadeIn = FadeIn,
                                        Color = "0 0 0 0"
                                }
            }, CRAFTSYSTEM_HUD + ".CONTENT_MAIN", "ITEM_PANEL");
            int RRSXLNENNDPWJROTIVZLAHTQMYDEBTFYTIYDWXXASXJL = VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.ZPFDVOHMXJQPVRGDCPHVYBFRSDYBCCCYOYNFZQMXGFMLWWE ? config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Where(p => String.IsNullOrWhiteSpace(p.Value.Permission) || permission.UserHasPermission(player.UserIDString, p.Value.Permission)).Skip(24 * (FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] + 1)).Take(24).Count() : config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY.Where(p => String.IsNullOrWhiteSpace(p.Value.Permission) || permission.UserHasPermission(player.UserIDString, p.Value.Permission)).Where(i => i.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL == VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF).Skip(24 * (FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] + 1)).Take(24).Count();
            int ItemCount = 0, NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK = 0, SKQNJJHLGQAFBDGMPMLXJNZLWSGCEFEXNHATHUHPHOFWHV = 0;
            foreach (var Item in Items)
            {
                TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC = Item.Value.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL;
                string EJEEDQFWUCEWMWHBQWQVDMQGQTHFCSOKNMDTYWQWDGV = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF || TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF || TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity ? (string)ImageLibrary.Call("GetImage", $"{Item.Value.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX}") : Item.Value.SkinID != 0 ? (string)ImageLibrary.Call("GetImage", Item.Value.SkinID.ToString()) : (string)ImageLibrary.Call("GetImage", $"{Item.Value.Shortname}");
                string RFOZAANTVGESTYOKJATBNUIZTODTGUSWQWOKEIECFUPGIKA = DQLXMTQJZJQUMFEMLUWPMVXNPDJOEHFOTNNUYIYYF == ItemCount ? "0.05000005 0.05" : "0.1583334 0.1333334";
                string IFMCNTGXWOFLXTNAOHBXJDFAVQVSFBRIODKAHPJWPROQCTELH = DQLXMTQJZJQUMFEMLUWPMVXNPDJOEHFOTNNUYIYYF == ItemCount ? "0.9666668 0.9666671" : "0.8750001 0.8500004";
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = $"{0.025 + (NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK * 0.1585)} {0.747216 - (SKQNJJHLGQAFBDGMPMLXJNZLWSGCEFEXNHATHUHPHOFWHV * 0.205)}",
                                                AnchorMax = $"{0.1719354 + (NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK * 0.1585)} {0.9493781 - (SKQNJJHLGQAFBDGMPMLXJNZLWSGCEFEXNHATHUHPHOFWHV * 0.205)}"
                                        },
                    Image = {
                                                FadeIn = FadeIn,
                                                Color = "0 0 0 0"
                                        }
                }, "ITEM_PANEL", $"ITEMS_{ItemCount}");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    Parent = $"ITEMS_{ItemCount}",
                    Name = "ButtonImage",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "-0.05 -0.05", AnchorMax = "1.05 1.05"
                                                }
                                        }
                });
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, $"ITEMS_{ItemCount}", $"ITEM_BACKGROUND_{ItemCount}");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                {
                    FadeOut = FadeOut,
                    Parent = $"ITEMS_{ItemCount}",
                    Name = $"ITEM_ICON_{ItemCount}",
                    Components = {
                                                new CuiImageComponent 
                                                {
                                                        FadeIn = FadeIn, 
                                                        ItemId = GetItemId(Item.Value.Shortname),
                                                        SkinId = Item.Value.SkinID
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.1 0.1", AnchorMax = "0.9 0.9"
                                                },
                                        }
                });
                if (IsCooldown(player, Item.Key))
                {
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                    {
                        FadeOut = FadeOut,
                        RectTransform = {
                                                        AnchorMin = "0.09 0.09",
                                                        AnchorMax = "0.91 0.91"
                                                },
                        Image = {
                                                        Color = "0 0 0 0"
                                                }
                    }, $"ITEMS_{ItemCount}", $"ITEMS_COOLDOWN_{ItemCount}");
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        Parent = $"ITEMS_{ItemCount}",
                        Name = $"ITEMS_COOLDOWN_{ItemCount}",
                        Components = {
                                                        new CuiRawImageComponent {
                                                                Png = (string) ImageLibrary.Call("GetImage", "BlockButtonImage"), Color = "1 1 1 1"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "-0.05 -0.05", AnchorMax = "1.05 1.05"
                                                        }
                                                }
                    });
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                    {
                        FadeOut = FadeOut,
                        RectTransform = {
                                                        AnchorMin = "0.5 0.5",
                                                        AnchorMax = "0.5 0.5",
                                                        OffsetMin = "-10 -10",
                                                        OffsetMax = "10 10"
                                                },
                        Image = {
                                                        Color = "1 1 1 1",
                                                        Sprite = "assets/icons/bp-lock.png"
                                                }
                    }, $"ITEMS_COOLDOWN_{ItemCount}");
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 0",
                                                        OffsetMin = "0 0",
                                                        OffsetMax = "0 70"
                                                },
                        Text = {
                                                        Text = GetCooldown(player, Item.Key),
                                                        Color = CEVYQVJJVPOYLTHVDSFLJNIUNYYDOXBDWPHALBEQG("#efedee"),
                                                        Font = "robotocondensed-bold.ttf",
                                                        Align = TextAnchor.MiddleCenter
                                                }
                    }, $"ITEMS_COOLDOWN_{ItemCount}");
                }
                else
                {
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                    {
                        FadeOut = FadeOut,
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 1"
                                                },
                        Button = {
                                                        FadeIn = FadeIn,
                                                        Command = $"func_craft select_item {VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF:d} {ItemCount} {Item.Key}",
                                                        Color = "0 0 0 0"
                                                },
                        Text = {
                                                        FadeIn = FadeIn,
                                                        Text = "",
                                                        Align = TextAnchor.MiddleCenter
                                                }
                    }, $"ITEMS_{ItemCount}");
                }
                ItemCount++;
                NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK++;
                if (NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK == 6)
                {
                    SKQNJJHLGQAFBDGMPMLXJNZLWSGCEFEXNHATHUHPHOFWHV++;
                    NIDROLDZVJKXCKNJAMTYQDBSLXKYYSDXHQZPZMMIBYXYOFTMK = 0;
                }
            }
            string SAJCQFZMGWXNRUXXXTIMSZYEHRPPYCMKLQJQYLNFAVIMZ = $"func_craft back.page {VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF:d}";
            string ATSFVLDUWTBEVYPJODKNBBLGYMGCMWQMFFRVXSHA = $"func_craft next.page {VPWRENLSFIZAOZGMAAKYQQKJFKRWFJKMKLPSHSUVF:d}";
            bool QTPOUQOPQHEBLAYILGIEAIACPZPGUMVWJGLIVSEVRM = FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] != 0;
            bool PLKUETNMMYVHITMYVAHVEMISFPQMTCMNNNLRFELNHAIXNZCP = RRSXLNENNDPWJROTIVZLAHTQMYDEBTFYTIYDWXXASXJL != 0;
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
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
            }, CRAFTSYSTEM_HUD + ".CONTENT_MAIN", CRAFTSYSTEM_HUD + ".PS");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
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
            }, CRAFTSYSTEM_HUD + ".PS", "LabelPage");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Text = {
                                        Text = GetLang("UI_PAGE", player.UserIDString) + " " + (FTIUGDFOYQUBCEIWBWYCDFLYIYYCJBIRBAOASEKWS[player] + 1).ToString(),
                                        FontSize = 25,
                                        Font = "robotocondensed-regular.ttf",
                                        Align = TextAnchor.MiddleCenter,
                                        Color = "0.929 0.882 0.847 0.8"
                                }
            }, "LabelPage", "ThisLabel");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.15 0",
                                        AnchorMax = "0.29 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = QTPOUQOPQHEBLAYILGIEAIACPZPGUMVWJGLIVSEVRM ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, CRAFTSYSTEM_HUD + ".PS", CRAFTSYSTEM_HUD + ".PS.L");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = QTPOUQOPQHEBLAYILGIEAIACPZPGUMVWJGLIVSEVRM ? SAJCQFZMGWXNRUXXXTIMSZYEHRPPYCMKLQJQYLNFAVIMZ : ""
                                },
                Text = {
                                        Text = "<b><</b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = QTPOUQOPQHEBLAYILGIEAIACPZPGUMVWJGLIVSEVRM ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, CRAFTSYSTEM_HUD + ".PS.L");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.71 0",
                                        AnchorMax = "0.85 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = PLKUETNMMYVHITMYVAHVEMISFPQMTCMNNNLRFELNHAIXNZCP ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, CRAFTSYSTEM_HUD + ".PS", CRAFTSYSTEM_HUD + ".PS.R");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = PLKUETNMMYVHITMYVAHVEMISFPQMTCMNNNLRFELNHAIXNZCP ? ATSFVLDUWTBEVYPJODKNBBLGYMGCMWQMFFRVXSHA : ""
                                },
                Text = {
                                        Text = "<b>></b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = PLKUETNMMYVHITMYVAHVEMISFPQMTCMNNNLRFELNHAIXNZCP ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, CRAFTSYSTEM_HUD + ".PS.R");
            CuiHelper.AddUi(player, YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE);
        }
        int QVRRAHZSRWGRSEPDVOBALYNNPDJHLYMAJSIDNLSNHF(string ItemKey)
        {
            var TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY[ItemKey];
            int MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG = 0;
            if (TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
            if (!String.IsNullOrWhiteSpace(TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ)) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
            if (TIVJRQCDSPODASJMITVHVTQOUOEDLEFMAEATRDVWINN.MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC != 0) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
            return MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG;
        }
        void DMDDNRBTJWNURIEBXXSGTJFHZVLPJWOTGTJAMZVPJ(BasePlayer player, string ItemKey)
        {
            UPWFODYRXBCCYLJHDPQCTOLUREENUDQKMKHFHUZQWPQBUK(player);
            var Interface = config.ODXVKHLLONWFEEMQPUXCCSHLUCTLGQPSCNUTDDNMXRAMTL;
            var WKGHZLFFHHMZSGPCMZROJBCVSQUFXYZHGARKIWEAYAETRA = Interface.RequiresSetting;
            var Item = config.CKSNMZJOVVLAINAFXYDCQJTNLGLFLRVSJRQBNDDTTZYY[ItemKey];
            Item items = ItemManager.CreateByName(Item.Shortname);
            TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC = Item.DFYXMDOQITSQFCFNDCDZTRQXYRTUKJRKVVIBMIYOHBAXYL;
            string EJEEDQFWUCEWMWHBQWQVDMQGQTHFCSOKNMDTYWQWDGV = TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.RGPOFMTEINCGGTFPHWNXCWDDDLLKKVJOUYQVQYFTODMF || TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.OALASODIGTPCWBYWXNCPANUIRGDDIZAPATKWIGXEPFZYQF || TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC == TSBPHBMHELFQQDFGBMCRTDMFVEWPUHDDAUMJCPWWBAVHCDQLC.Entity ? (string)ImageLibrary.Call("GetImage", $"{Item.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX}") : Item.SkinID != 0 ? (string)ImageLibrary.Call("GetImage", Item.SkinID.ToString()) : (string)ImageLibrary.Call("GetImage", $"{Item.Shortname}");
            float FadeOut = 0;
            float FadeIn = 0;
            CuiElementContainer YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE = new CuiElementContainer();
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                FadeOut = FadeOut,
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 0.999"
                                },
                Image = {
                                        Color = "0 0 0 0.35",
                                        Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
                                }
            }, CRAFTSYSTEM_HUD, "CRAFT_INFORMATION_PANEL");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.5 0.5",
                                        AnchorMax = "0.5 0.5",
                                        OffsetMin = "-120 60",
                                        OffsetMax = "120 250"
                                },
                Image = {
                                        Color = "0.20 0.20 0.24 0.85"
                                }
            }, "CRAFT_INFORMATION_PANEL", "Craft_Icon");
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
            {
                FadeOut = FadeOut,
                Parent = "Craft_Icon",
                Name = $"ICON_CRAFT_INFO",
                Components = {
                      new CuiImageComponent
                                                {
                                                        FadeIn = FadeIn,
                                                        ItemId = GetItemId(Item.Shortname),
                                                        SkinId = Item.SkinID
                                                },
                                      
                                        new CuiRectTransformComponent {
                                                AnchorMin = "0 0", AnchorMax = "1 1"
                                        },
                                }
            });
            YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 1",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 4",
                                        OffsetMax = "0 30"
                                },
                Image = {
                                        Color = "0.20 0.20 0.24 0.8"
                                }
            }, "Craft_Icon", "TITLE_CRAFT_INFO");
            if (Item.DisplayName == "")
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = $"{items.info.displayName.english}",
                                                FontSize = 20,
                                                Align = TextAnchor.MiddleCenter,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "TITLE_CRAFT_INFO");
            }
            else
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = $"<b>{Item.DisplayName}</b>",
                                                FontSize = 20,
                                                Align = TextAnchor.MiddleCenter,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "TITLE_CRAFT_INFO");
            }
            if (Item.AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW != "")
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "1 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "4 0",
                                                OffsetMax = "250 30"
                                        },
                    Image = {
                                                Color = "0.20 0.20 0.24 0.8"
                                        }
                }, "Craft_Icon", "DESCRIPTION_CRAFT_INFO");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "5 0",
                                                OffsetMax = "0 0"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = GetLang("UI_INFORMATION_DESCRIPTION", player.UserIDString),
                                                FontSize = 25,
                                                Align = TextAnchor.UpperCenter,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "DESCRIPTION_CRAFT_INFO");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0.85",
                                                OffsetMin = "5 0",
                                                OffsetMax = "0 0"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = $"{Item.AXFQWVYYLPBZUKTFZBHVJUEBVDPRRQSZNKSWESVPWWW}",
                                                FontSize = 22,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "DESCRIPTION_CRAFT_INFO");
            }
            int MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG = 0;
            int KOTJJWZGVHKOJQAHJIETSOFUPURPJWJESPKQEOPL = 0;
            if (QVRRAHZSRWGRSEPDVOBALYNNPDJHLYMAJSIDNLSNHF(ItemKey) != 0)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "0 1",
                                                OffsetMin = "-250 0",
                                                OffsetMax = "-4 30"
                                        },
                    Image = {
                                                Color = "0.20 0.20 0.24 0.8"
                                        }
                }, "Craft_Icon", "PANEL_REQUIRES");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "5 0",
                                                OffsetMax = "0 0"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = GetLang("UI_INFORMATION_TITLE_REQUIRES", player.UserIDString),
                                                Align = TextAnchor.UpperCenter,
                                                FontSize = 18,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "PANEL_REQUIRES", "TITLE_REQUIRES");
                if (Item.MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC != 0)
                {
                    string TWCXIVJYSVLMGIVJYUOEKXYYGVTGJDUSTMYRCXHZIQ = ITDRKSKDXGJBAUKCIFOFOKYVDQDGCAEMJIFRGFMYJQBBYSI(player, Item.MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC) || permission.UserHasPermission(player.UserIDString, config.HTPSHJHVPHBEGICJOBMVOQPTENVRLSENFBBCDOBIRSGNHHT.QUSRPJEQDWNUOQKWCNZFGZGZADDWJBLWUFAQANYVWKZGBH) ? $"<color={Interface.RequiresSetting.RequiresDoTrueColor}>{Interface.RequiresSetting.RequiresDoTrue}</color>" : $"<color={Interface.RequiresSetting.RequiresDoFalseColor}>{Interface.RequiresSetting.RequiresDoFalse}</color>";
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                    {
                        FadeOut = FadeOut,
                        RectTransform = {
                                                        AnchorMin = "0 0.75",
                                                        AnchorMax = "1 0.85",
                                                        OffsetMin = "40 0",
                                                        OffsetMax = "0 0"
                                                },
                        Text = {
                                                        Align = TextAnchor.MiddleLeft,
                                                        Text = GetLang("UI_INFORMATION_WOKBENCH_LEVEL", player.UserIDString, Item.MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC, TWCXIVJYSVLMGIVJYUOEKXYYGVTGJDUSTMYRCXHZIQ),
                                                        FontSize = 12,
                                                        Color = "0.929 0.882 0.847 0.75"
                                                }
                    }, "PANEL_REQUIRES", $"WORKBENCH_REQ");
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        FadeOut = FadeOut,
                        Parent = "WORKBENCH_REQ",
                        Name = $"WORKBENCH_REQ_ICON",
                        Components = {
                                                        new CuiRawImageComponent {
                                                                FadeIn = FadeIn, Png = (string) ImageLibrary.Call("GetImage", "WorkbenchImage")
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "-25 -20", OffsetMax = "-5 0"
                                                        },
                                                }
                    });
                    if (QVRRAHZSRWGRSEPDVOBALYNNPDJHLYMAJSIDNLSNHF(ItemKey) >= MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
                    if (ITDRKSKDXGJBAUKCIFOFOKYVDQDGCAEMJIFRGFMYJQBBYSI(player, Item.MCAYDKQOBPJXUMRUUPYRKIBOISTCMFZTOXETAICHIYWC) || permission.UserHasPermission(player.UserIDString, config.HTPSHJHVPHBEGICJOBMVOQPTENVRLSENFBBCDOBIRSGNHHT.QUSRPJEQDWNUOQKWCNZFGZGZADDWJBLWUFAQANYVWKZGBH)) KOTJJWZGVHKOJQAHJIETSOFUPURPJWJESPKQEOPL++;
                }
                if (IQPlagueSkill)
                    if (Item.OEYMAUGKGBEBLPKQNCVPQIWIXTMMQIMMZIUOVQLLSJ)
                    {
                        string BXRLHOHFUAHWWYDQMBDPPBTTTJDGBNPVTGWAPJMRCXZRLQ = SUWYNMEYUINTPEBWCWSSPTVDSPWYJWXKIPNHDGZWDGWYR(player) ? $"<color={Interface.RequiresSetting.RequiresDoTrueColor}>{Interface.RequiresSetting.RequiresDoTrue}</color>" : $"<color={Interface.RequiresSetting.RequiresDoFalseColor}>{Interface.RequiresSetting.RequiresDoFalse}</color>";
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                        {
                            FadeOut = FadeOut,
                            RectTransform = {
                                                                AnchorMin = $"0.1637938 {0.7016209 - (0.05 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}",
                                                                AnchorMax = $"1 {0.7748644 - (0.05 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}"
                                                        },
                            Text = {
                                                                FadeIn = FadeIn,
                                                                Text = GetLang("UI_INFORMATION_IQPLAGUESKILL", player.UserIDString, "", BXRLHOHFUAHWWYDQMBDPPBTTTJDGBNPVTGWAPJMRCXZRLQ),
                                                                Align = TextAnchor.MiddleLeft,
                                                                FontSize = 12,
                                                                Color = "0.929 0.882 0.847 0.75"
                                                        }
                        }, $"PANEL_REQUIRES", $"IQPLAGUESKILL");
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                        {
                            FadeOut = FadeOut,
                            Parent = $"IQPLAGUESKILL",
                            Name = $"IQPLAGUESKILL_ICON",
                            Components = {
                                                                new CuiRawImageComponent {
                                                                        FadeIn = FadeIn, Png = (string) ImageLibrary.Call("GetImage", "SkillImage")
                                                                },
                                                                new CuiRectTransformComponent {
                                                                        AnchorMin = $"0 0", AnchorMax = $"0 1", OffsetMin = "-25 0", OffsetMax = "-5 0"
                                                                },
                                                        }
                        });
                        if (QVRRAHZSRWGRSEPDVOBALYNNPDJHLYMAJSIDNLSNHF(ItemKey) >= MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
                        if (SUWYNMEYUINTPEBWCWSSPTVDSPWYJWXKIPNHDGZWDGWYR(player)) KOTJJWZGVHKOJQAHJIETSOFUPURPJWJESPKQEOPL++;
                    }
                if (IQRankSystem)
                    if (!String.IsNullOrWhiteSpace(Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ))
                    {
                        if (!DPEDPLAOFKDJVLDHHOOUUCGJRLIVOXBXFXLRXIJGGSBRZHPLE(Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ)) PrintError($"Вы указали не существующий ранг ({Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ}), в плагине IQRankSystem не обнаружен этот ранг! Проверьте данные!");
                        string TZGUXFBBZEXSXKBDHLLCQCCBCPLNRBBIDIKGVSRQ = JFOEZBAQYZYTFXQGPYKCLZQTTVWVOIXXLAGRJEXVKRQOJKA(player, Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ) ? $"<color={Interface.RequiresSetting.RequiresDoTrueColor}>{Interface.RequiresSetting.RequiresDoTrue}</color>" : $"<color={Interface.RequiresSetting.RequiresDoFalseColor}>{Interface.RequiresSetting.RequiresDoFalse}</color>";
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                        {
                            FadeOut = FadeOut,
                            Parent = $"PANEL_REQUIRES",
                            Name = $"IQRANKSYSTEM_REQ_ICON",
                            Components = {
                                                                new CuiRawImageComponent {
                                                                        FadeIn = FadeIn, Png = (string) ImageLibrary.Call("GetImage", "RankImage")
                                                                },
                                                                new CuiRectTransformComponent {
                                                                        AnchorMin = $"0.06645446 {0.7016209 - (0.08 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}", AnchorMax = $"0.14162677 {0.7848644 - (0.08 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}"
                                                                },
                                                        }
                        });
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                        {
                            FadeOut = FadeOut,
                            RectTransform = {
                                                                AnchorMin = $"0.1637938 {0.7016209 - (0.08 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}",
                                                                AnchorMax = $"1 {0.7748644 - (0.08 * MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG)}"
                                                        },
                            Text = {
                                                                FadeIn = FadeIn,
                                                                Text = GetLang("UI_INFORMATION_IQRANK_RANK", player.UserIDString, DFHQAJJTOFBCJINIWFDQHSBXVOGCLZRHHHCDRKXHBKRDS(Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ), TZGUXFBBZEXSXKBDHLLCQCCBCPLNRBBIDIKGVSRQ),
                                                                Align = TextAnchor.UpperLeft,
                                                                FontSize = 12,
                                                                Color = "0.929 0.882 0.847 0.75"
                                                        }
                        }, "PANEL_REQUIRES", $"IQRANKSYSTEM");
                        if (QVRRAHZSRWGRSEPDVOBALYNNPDJHLYMAJSIDNLSNHF(ItemKey) >= MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG) MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG++;
                        if (JFOEZBAQYZYTFXQGPYKCLZQTTVWVOIXXLAGRJEXVKRQOJKA(player, Item.WASPTSRVVAMPGHQOGHUTXPRBCUVUWQKXHZAIFETUZNQ)) KOTJJWZGVHKOJQAHJIETSOFUPURPJWJESPKQEOPL++;
                    }
            }
            List<Configuration.ItemSettings.ItemForCraft> FWWRRPGBTSGZNLRWERITOJYDPOPAUIOTVKLFGKLZELXJVIQ = Item.MSOGFCEDYPLGIQMYWWYEQPIGGIICOZTJYGPJGPPTMHYR;
            if (FWWRRPGBTSGZNLRWERITOJYDPOPAUIOTVKLFGKLZELXJVIQ != null)
            {
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = "-160 0",
                                                OffsetMax = "160 85"
                                        },
                    Text = {
                                                FadeIn = FadeIn,
                                                Text = GetLang("UI_INFORMATION_ITEM_LIST_TITLE", player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 18,
                                                Color = "0.929 0.882 0.847 0.75"
                                        }
                }, "CRAFT_INFORMATION_PANEL", "REQUIRES_ITEM_LIST_TITLE");
                YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                {
                    FadeOut = FadeOut,
                    RectTransform = {
                                                AnchorMin = "0.03490228 0.07837844",
                                                AnchorMax = "1 0.5337838"
                                        },
                    Image = {
                                                FadeIn = FadeIn,
                                                Color = "0 0 0 0"
                                        }
                }, "CRAFT_INFORMATION_PANEL", "REQUIRES_ITEM_LIST_PANEL");
                int ItemCount = 0;
                float TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY = 219f;
                float MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ = 0.353646f - 0.25f; /* Ширина */
                float TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR = 0.439895f - 0.42f; /* Расстояние между */
                int PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU = FWWRRPGBTSGZNLRWERITOJYDPOPAUIOTVKLFGKLZELXJVIQ.Count;
                float VLJJGKNQPREZWZZCFVQWTIQSVBMYXPVKWLZWLIFSLLZLAUTX = 0.7f; /* Сдвиг по вертикали */
                float ZEYPYBNVQNEYPTAWUDKADRXPXLIJESAIOSXLXUYKMB = 0.3f; /* Высота */
                int UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO = 7;
                if (PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU > UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO)
                {
                    TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY = 0.5f - UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO / 2f * MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ - (UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO - 1) / 2f * TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR;
                    PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU -= UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO;
                }
                else TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY = 0.5f - PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU / 2f * MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ - (PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU - 1) / 2f * TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR;
                foreach (var ItemCraft in FWWRRPGBTSGZNLRWERITOJYDPOPAUIOTVKLFGKLZELXJVIQ)
                {
                    string NCLRILWHEKYVKQGMJKBMEVPWCUALDYUHHLLXSIEQA = !String.IsNullOrWhiteSpace(ItemCraft.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX) ? (string)ImageLibrary.Call("GetImage", $"{ItemCraft.LJEEOVBWQPXGTEUSFGHUWCMKRWBGGRYNXSPLZLDVPWIX}") : ItemCraft.SkinID != 0 ? (string)ImageLibrary.Call("GetImage", ItemCraft.SkinID.ToString()) : (string)ImageLibrary.Call("GetImage", $"{ItemCraft.Shortname}");
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                    {
                        FadeOut = FadeOut,
                        RectTransform = {
                                                        AnchorMin = $"{TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY} {VLJJGKNQPREZWZZCFVQWTIQSVBMYXPVKWLZWLIFSLLZLAUTX}",
                                                        AnchorMax = $"{TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY + MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ} {VLJJGKNQPREZWZZCFVQWTIQSVBMYXPVKWLZWLIFSLLZLAUTX + ZEYPYBNVQNEYPTAWUDKADRXPXLIJESAIOSXLXUYKMB}"
                                                },
                        Image = {
                                                        FadeIn = FadeIn,
                                                        Color = "0 0 0 0"
                                                }
                    }, $"REQUIRES_ITEM_LIST_PANEL", $"REQUIRES_ITEM_{ItemCount}");
                    string KSQUZYGWPFOCZSNPOOKKEGQRNZEJUBGKLJLWGIVCFGJOTFM = FXRYNPGJOULDEFBQBAIFQZWKAPSUIBKJVUPRRZKVU(player, ItemCraft.Shortname, ItemCraft.Amount, ItemCraft.SkinID) ? WKGHZLFFHHMZSGPCMZROJBCVSQUFXYZHGARKIWEAYAETRA.RequiresDoTrueColor : WKGHZLFFHHMZSGPCMZROJBCVSQUFXYZHGARKIWEAYAETRA.RequiresDoFalseColor;
                    string JDTPGPQECZGATXCOYDQPHRJGTIFXXBXIMLZQHQEVTHTGBVI = FXRYNPGJOULDEFBQBAIFQZWKAPSUIBKJVUPRRZKVU(player, ItemCraft.Shortname, ItemCraft.Amount, ItemCraft.SkinID) ? WKGHZLFFHHMZSGPCMZROJBCVSQUFXYZHGARKIWEAYAETRA.RequiresDoTrue : WKGHZLFFHHMZSGPCMZROJBCVSQUFXYZHGARKIWEAYAETRA.RequiresDoFalse;
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        Parent = $"REQUIRES_ITEM_{ItemCount}",
                        Name = $"REQUIRES_ITEM_LOGO_{ItemCount}",
                        Components = {
                                                        new CuiImageComponent {
                                                                Color = "0.20 0.20 0.24 0.8", Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 0", AnchorMax = "1 1"
                                                        },
                                                        new CuiOutlineComponent {
                                                                Color = CEVYQVJJVPOYLTHVDSFLJNIUNYYDOXBDWPHALBEQG(KSQUZYGWPFOCZSNPOOKKEGQRNZEJUBGKLJLWGIVCFGJOTFM), Distance = "1.2 -1.2", UseGraphicAlpha = true
                                                        }
                                                }
                    });
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        FadeOut = FadeOut,
                        Parent = $"REQUIRES_ITEM_LOGO_{ItemCount}",
                        Name = $"REQUIRES_ITEM_ICO_{ItemCount}",
                        Components = {
                                                        new CuiRawImageComponent {
                                                                FadeIn = FadeIn, Png = NCLRILWHEKYVKQGMJKBMEVPWCUALDYUHHLLXSIEQA
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 0", AnchorMax = "1 1"
                                                        },
                                                }
                    });
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        Parent = $"REQUIRES_ITEM_LOGO_{ItemCount}",
                        Name = $"REQUIRES_ITEM_CHECK_{ItemCount}",
                        Components = {
                                                        new CuiImageComponent {
                                                                Color = "0.20 0.20 0.24 0.8", Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "1 0", AnchorMax = "1 0", OffsetMin = "-15 5", OffsetMax = "-5 15"
                                                        },
                                                        new CuiOutlineComponent {
                                                                Color = CEVYQVJJVPOYLTHVDSFLJNIUNYYDOXBDWPHALBEQG(KSQUZYGWPFOCZSNPOOKKEGQRNZEJUBGKLJLWGIVCFGJOTFM), Distance = "0.8 -0.8", UseGraphicAlpha = true
                                                        }
                                                }
                    });
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiLabel
                    {
                        RectTransform = {
                                                        AnchorMin = "-0.35 -0.35",
                                                        AnchorMax = "1.35 1.35"
                                                },
                        Text = {
                                                        Text = JDTPGPQECZGATXCOYDQPHRJGTIFXXBXIMLZQHQEVTHTGBVI,
                                                        Align = TextAnchor.MiddleCenter,
                                                        FontSize = 15,
                                                        Color = "0.929 0.882 0.847 0.75"
                                                }
                    }, $"REQUIRES_ITEM_CHECK_{ItemCount}");
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiElement
                    {
                        FadeOut = FadeOut,
                        Parent = $"REQUIRES_ITEM_ICO_{ItemCount}",
                        Name = $"REQUIRES_ITEM_AMOUNT_{ItemCount}",
                        Components = {
                                                        new CuiTextComponent {
                                                                FadeIn = FadeIn, Text = $"x{ItemCraft.Amount}", FontSize = 16, Align = TextAnchor.MiddleCenter
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 0", AnchorMax = "1 1"
                                                        },
                                                        new CuiOutlineComponent {
                                                                Distance = "0.6 0.6", Color = CEVYQVJJVPOYLTHVDSFLJNIUNYYDOXBDWPHALBEQG("#222226")
                                                        }
                                                }
                    });
                    YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 1"
                                                },
                        Button = {
                                                        Close = "CRAFT_INFORMATION_PANEL",
                                                        Color = "0 0 0 0"
                                                },
                        Text = {
                                                        Text = ""
                                                }
                    }, "CRAFT_INFORMATION_PANEL", "Close");
                    if (COTUQEQAMICVMGBGXXXMAMJCHKPKZCPMKSWHRGZNDIPCGZHJP(player, FWWRRPGBTSGZNLRWERITOJYDPOPAUIOTVKLFGKLZELXJVIQ) && KOTJJWZGVHKOJQAHJIETSOFUPURPJWJESPKQEOPL >= MAKXSUWXHGTVRSBHYNHLVPZSEMWDUBRZSFXHRZEG || permission.UserHasPermission(player.UserIDString, config.HTPSHJHVPHBEGICJOBMVOQPTENVRLSENFBBCDOBIRSGNHHT.BHJLUINJROTQMFHHCLQZIPTWPPDJWAZYTJCPZQQOGWJCHWM))
                    {
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                        {
                            RectTransform = {
                                                                AnchorMin = "0.6 0",
                                                                AnchorMax = "0.5 0",
                                                                OffsetMin = "-150 7",
                                                                OffsetMax = "100 40"
                                                        },
                            Image = {
                                                                Color = "0.20 0.20 0.24 1"
                                                        }
                        }, $"CRAFT_INFORMATION_PANEL", "CREATE_ITEM_BUTTON");
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                        {
                            RectTransform = {
                                                                AnchorMin = "0 0",
                                                                AnchorMax = "0 1",
                                                                OffsetMin = "5 5",
                                                                OffsetMax = "25 -5"
                                                        },
                            Button = {
                                                                Color = "0.417 0.421 0.409 0.65"
                                                        },
                            Text = {
                                                                Text = "?",
                                                                Align = TextAnchor.MiddleCenter,
                                                                FontSize = 20,
                                                                Color = "0.5 1 0.5 1"
                                                        }
                        }, "CREATE_ITEM_BUTTON");
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                        {
                            RectTransform = {
                                                                AnchorMin = "0 0",
                                                                AnchorMax = "1 1"
                                                        },
                            Button = {
                                                                Command = $"func_craft craft_item {ItemKey}",
                                                                Color = "0 0 0 0"
                                                        },
                            Text = {
                                                                Text = "   " + GetLang("UI_CREATE_ITEM", player.UserIDString),
                                                                Align = TextAnchor.MiddleCenter,
                                                                FontSize = 20,
                                                                Color = "0.929 0.882 0.847 0.75"
                                                        }
                        }, "CREATE_ITEM_BUTTON");
                    }
                    else
                    {
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiPanel
                        {
                            RectTransform = {
                                                                AnchorMin = "0.6 0",
                                                                AnchorMax = "0.5 0",
                                                                OffsetMin = "-150 7",
                                                                OffsetMax = "100 40"
                                                        },
                            Image = {
                                                                Color = "0.20 0.20 0.24 1"
                                                        }
                        }, $"CRAFT_INFORMATION_PANEL", "UNAVAILABLE_ITEM_BUTTON");
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                        {
                            RectTransform = {
                                                                AnchorMin = "0 0",
                                                                AnchorMax = "0 1",
                                                                OffsetMin = "5 5",
                                                                OffsetMax = "25 -5"
                                                        },
                            Button = {
                                                                Color = "0.417 0.421 0.409 0.65"
                                                        },
                            Text = {
                                                                Text = "!",
                                                                Align = TextAnchor.MiddleCenter,
                                                                FontSize = 20,
                                                                Color = "1 0.5 0.5 1"
                                                        }
                        }, "UNAVAILABLE_ITEM_BUTTON");
                        YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE.Add(new CuiButton
                        {
                            RectTransform = {
                                                                AnchorMin = "0 0",
                                                                AnchorMax = "1 1"
                                                        },
                            Button = {
                                                                Color = "0 0 0 0"
                                                        },
                            Text = {
                                                                Text = "   " + GetLang("UI_UNAVAILABLE_ITEM", player.UserIDString),
                                                                Align = TextAnchor.MiddleCenter,
                                                                FontSize = 20,
                                                                Color = "0.929 0.882 0.847 0.75"
                                                        }
                        }, "UNAVAILABLE_ITEM_BUTTON");
                    }
                    ItemCount++;
                    TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY += (MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ + TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR);
                    if (ItemCount % UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO == 0)
                    {
                        VLJJGKNQPREZWZZCFVQWTIQSVBMYXPVKWLZWLIFSLLZLAUTX -= (ZEYPYBNVQNEYPTAWUDKADRXPXLIJESAIOSXLXUYKMB + (TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR * 2f));
                        if (PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU > UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO)
                        {
                            TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY = 0.5f - UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO / 2f * MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ - (UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO - 1) / 2f * TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR;
                            PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU -= UAUVRZPFRJXCIHJSMTDQYMWKWWPZZEZNBWCODPQJPMJYQPO;
                        }
                        else TKRBIXEVYSCDAGHLDMEDZLQTFJOCLPHGYSHJQNLXFPGNIIZY = 0.5f - PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU / 2f * MFIENXHUXVZICKJLVEIZXUQBGXKFCLXJPXZJYBLUZ - (PHURDVHXXHTVWYTXQSJEZZPPRHVHURMDYCPDFUQXFCKTFU - 1) / 2f * TRLPDFXCMDRZHRPHYPNCRLXQSFLZMTTNZHBZPRUFHZZUR;
                    }
                    if (ItemCount >= 15) break;
                }
            }
            CuiHelper.AddUi(player, YWOAREEHJETPXTMQRDLQWDIYPQQWKNAMSUDVTOPVTBE);
        }
        private static string CEVYQVJJVPOYLTHVDSFLJNIUNYYDOXBDWPHALBEQG(string KBVPZKNVGAZPPHSYHIKCERDBBYSKNDVYJRKWRADYAJAFPEYF)
        {
            Color color;
            ColorUtility.TryParseHtmlString(KBVPZKNVGAZPPHSYHIKCERDBBYSKNDVYJRKWRADYAJAFPEYF, out color);
            EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV.Clear();
            return EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV.AppendFormat("{0:F2} {1:F2} {2:F2} {3:F2}", color.r, color.g, color.b, color.a).ToString();
        }
        private new void LoadDefaultMessages()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["UI_TITLE"] = "CRAFTS",
                ["UI_PAGE"] = "PAGE:",
                ["UI_CATEGORY_ALL"] = "ALL",
                ["UI_CATEGORY_ATTIRIE"] = "ATTIRIE",
                ["UI_CATEGORY_CONSTRUCTION"] = "CONSTRUCTION",
                ["UI_CATEGORY_CUSTOM"] = "OTHER",
                ["UI_CATEGORY_FUN"] = "FUN",
                ["UI_CATEGORY_ITEMS"] = "ITEMS",
                ["UI_CATEGORY_TOOLS"] = "TOOLS",
                ["UI_CATEGORY_TRANSPORT"] = "TRANSPORT",
                ["UI_CATEGORY_WEAPON"] = "WEAPON",
                ["UI_CATEGORY_ELECTRICAL"] = "ELECTRICAL",
                ["UI_INFORMATION_DESCRIPTION"] = "Description",
                ["UI_INFORMATION_TITLE_REQUIRES"] = "Additional requirements",
                ["UI_INFORMATION_WOKBENCH_LEVEL"] = "Requires level {0} workbench {1}",
                ["UI_INFORMATION_IQRANK_RANK"] = "Requires rank {0} {1}",
                ["UI_INFORMATION_IQPLAGUESKILL"] = "Requires skill advanced craft {1}",
                ["UI_INFORMATION_ITEM_LIST_TITLE"] = "Items for crafting:",
                ["UI_CREATE_ITEM"] = "CREATE",
                ["UI_UNAVAILABLE_ITEM"] = "UNAVAILABLE",
                ["TITLE_FORMAT_LOCKED_DAYS"] = "<size=12><b>D</b></size>",
                ["TITLE_FORMAT_LOCKED_HOURSE"] = "<size=12><b>H</b></size>",
                ["TITLE_FORMAT_LOCKED_MINUTES"] = "<size=12><b>M</b></size>",
                ["TITLE_FORMAT_LOCKED_SECONDS"] = "<size=12><b>S</b></size>",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["UI_TITLE"] = "КРАФТЫ",
                ["UI_PAGE"] = "СТРАНИЦА:",
                ["UI_CATEGORY_ALL"] = "ВСЁ",
                ["UI_CATEGORY_ATTIRIE"] = "ОДЕЖДА",
                ["UI_CATEGORY_CONSTRUCTION"] = "КОНСТРУКЦИИ",
                ["UI_CATEGORY_CUSTOM"] = "ПРОЧЕЕ",
                ["UI_CATEGORY_TOOLS"] = "ИНСТРУМЕНТЫ",
                ["UI_CATEGORY_TRANSPORT"] = "ТРАНСПОРТ",
                ["UI_CATEGORY_WEAPON"] = "ОРУЖИЕ",
                ["UI_INFORMATION_TITLE_REQUIRES"] = "Дополнительные требования",
                ["UI_INFORMATION_WOKBENCH_LEVEL"] = "Требуется верстак {0} уровня {1}",
                ["UI_INFORMATION_IQRANK_RANK"] = "Требуется ранг {0} {1}",
                ["UI_INFORMATION_IQPLAGUESKILL"] = "Требуется навык продвинутый крафт {1}",
                ["UI_INFORMATION_ITEM_LIST_TITLE"] = "Предметы для крафта:",
                ["UI_INFORMATION_DESCRIPTION"] = "Описание",
                ["UI_CREATE_ITEM"] = "СКРАФТИТЬ",
                ["UI_UNAVAILABLE_ITEM"] = "НЕДОСТУПНО",
                ["TITLE_FORMAT_LOCKED_DAYS"] = "<size=12><b>Д</b></size>",
                ["TITLE_FORMAT_LOCKED_HOURSE"] = "<size=12><b>Ч</b></size>",
                ["TITLE_FORMAT_LOCKED_MINUTES"] = "<size=12><b>М</b></size>",
                ["TITLE_FORMAT_LOCKED_SECONDS"] = "<size=12><b>С</b></size>",
            }, this, "ru");
        }
        public static StringBuilder EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV = new StringBuilder();
        public string GetLang(string ABPODQTXTOBRCHDEBGYWWGHELBVQYMXZNJNCFJGA, string userID = null, params object[] args)
        {
            EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV.Clear();
            if (args != null)
            {
                EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV.AppendFormat(lang.GetMessage(ABPODQTXTOBRCHDEBGYWWGHELBVQYMXZNJNCFJGA, this, userID), args);
                return EVPQOXLRUMWYKSGBBYNIXMGIZUVAYCFXZXTCLHTPZIV.ToString();
            }
            return lang.GetMessage(ABPODQTXTOBRCHDEBGYWWGHELBVQYMXZNJNCFJGA, this, userID);
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