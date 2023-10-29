/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using Color = UnityEngine.Color;
namespace Oxide.Plugins
{
    [Info("WipeBlock", "https://discord.gg/k3hXsVua7Q", "2.0")]
    public class WipeBlock : RustPlugin
    {
        private class Configuration
        {
            public class Block
            {
                [JsonProperty("Сдвиг блокировки в секундах ('1852' - на 1852 секунд вперёд, '-1852' на 1852 секунд назад)")] public int TimeMove = 0;
                [JsonProperty("Настройки блокировки предметов")] public Dictionary<int, List<string>> FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM;
            }
            [JsonProperty("Настройки текущей блокировки")] public Block NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ;
            public static Configuration GetDefaultConfiguration()
            {
                var newConfiguration = new Configuration();
                newConfiguration.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ = new Block();
                newConfiguration.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM = new Dictionary<int, List<string>>
                {
                    [1800] = new List<string> {
            "shotgun.waterpipe",
            "pistol.revolver",
            "shotgun.double",
          },
                    [3600] = new List<string> {
            "flamethrower",
            "bucket.helmet",
            "riot.helmet",
            "pants",
            "hoodie",
          },
                    [7200] = new List<string> {
            "pistol.python",
            "pistol.semiauto",
            "coffeecan.helmet",
            "roadsign.jacket",
            "roadsign.kilt",
            "icepick.salvaged",
            "axe.salvaged",
            "hammer.salvaged",
          },
                    [14400] = new List<string> {
            "shotgun.pump",
            "shotgun.spas12",
            "pistol.m92",
            "pistol.prototype17",
            "smg.mp5",
            "jackhammer",
            "chainsaw",
          },
                    [28800] = new List<string> {
            "smg.2",
            "smg.thompson",
            "rifle.semiauto",
            "explosive.satchel",
            "grenade.f1",
            "grenade.molotov",
            "grenade.flashbang",
            "grenade.beancan",
            "surveycharge"
          },
                    [43200] = new List<string> {
            "rifle.bolt",
            "rifle.ak",
            "rifle.ak.ice",
            "hmlmg",
            "rifle.lr300",
            "metal.facemask",
            "metal.plate.torso",
            "rifle.l96",
            "rifle.m39"
          },
                    [64800] = new List<string> {
            "ammo.rifle.explosive",
            "ammo.rocket.mlrs",
            "ammo.rocket.basic",
            "ammo.rocket.fire",
            "ammo.rocket.hv",
            "rocket.launcher",
            "multiplegrenadelauncher",
            "explosive.timed"
          },
                    [86400] = new List<string> {
            "lmg.m249",
            "heavy.plate.helmet",
            "heavy.plate.jacket",
            "heavy.plate.pants",
          }
                };
                return newConfiguration;
            }
        }
        [PluginReference] private Plugin ImageLibrary, Duel, Duels, Battles;
        private Configuration MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM = null;
        public Dictionary<string, string> HUUSOFYXCNYWKHAOBZEYUAWTNUZJOFFCSFPRRTJEPZAQ = new Dictionary<string, string>
        {
            ["Total"] = "ОБЩЕЕ",
            ["Weapon"] = "ОРУЖИЕ",
            ["Ammunition"] = "БОЕПРИПАСЫ",
            ["Tool"] = "ИНСТРУМЕНТЫ",
            ["Attire"] = "ОДЕЖДА"
        };
        private string TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI = "UI_1852InstanceBlock";
        private string QOOYAQCJROTARTVXFEWHSVLYYFMVOYZPJQHTBAIEXVNECGR = "UI_1852Block";
        private string FVRASBAVCQZVDHUTPERBMCVFVRKWHGWSNJPTHZWHP = "UI_1852InfoBlock";
        private string RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX = "wipeblock.ignore";
        private Dictionary<ulong, int> WTMTUUVQLYWRTFGYZIAQFEPSQIWKWIZEWELAFIRUM = new Dictionary<ulong, int>();
        private Coroutine ABPRLDKWWFQHXRDUCMYKUDZSVOUFSQRFDMEODYXTAALUNOH;
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM = Config.ReadObject<Configuration>();
                if (MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM?.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ == null) LoadDefaultConfig();
            }
            catch
            {
                PrintWarning($"Ошибка чтения конфигурации 'oxide/config/{Name}', создаём новую конфигурацию!!");
                LoadDefaultConfig();
            }
            NextTick(SaveConfig);
        }
        protected override void LoadDefaultConfig() => MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM = Configuration.GetDefaultConfiguration();
        protected override void SaveConfig() => Config.WriteObject(MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM);
        private void OnServerInitialized()
        {
            if (!ImageLibrary)
            {
                PrintError("ImageLibrary not found, plugin will not work!");
                return;
            }
            permission.RegisterPermission(RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX, this);
            InitializeLang();
            QKJIKYVSYQQHARYQIMFONGUKRNZWJOCCKGGYXJDJI();
        }
        private void Unload()
        {
            if (ABPRLDKWWFQHXRDUCMYKUDZSVOUFSQRFDMEODYXTAALUNOH != null) ServerMgr.Instance.StopCoroutine(ABPRLDKWWFQHXRDUCMYKUDZSVOUFSQRFDMEODYXTAALUNOH);
            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                player.SetFlag(BaseEntity.Flags.Reserved3, false);
                CuiHelper.DestroyUi(player, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI);
                CuiHelper.DestroyUi(player, QOOYAQCJROTARTVXFEWHSVLYYFMVOYZPJQHTBAIEXVNECGR);
                CuiHelper.DestroyUi(player, FVRASBAVCQZVDHUTPERBMCVFVRKWHGWSNJPTHZWHP);
            }
        }
        private object CanWearItem(PlayerInventory inventory, Item item)
        {
            var player = inventory.gameObject.ToBaseEntity() as BasePlayer;
            var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info) > 0 ? false : (bool?)null;
            if (WPDQZYCLDULYRKQYRXYYJKOOXTKATYIVFKKEGANBU(player)) return null;
            if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
            {
                if (player.GetComponent<NPCPlayer>() != null || player.GetComponent<BaseNpc>() != null || player.IsNpc) return null;
                if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
                RMOPIZXSONMCMKHSYEFRDRZHAFVXMTMNLQTOCQSJPKDWXT(player, item);
            }
            return XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK;
        }
        private object CanEquipItem(PlayerInventory inventory, Item item)
        {
            var player = inventory.gameObject.ToBaseEntity() as BasePlayer;
            if (player == null) return null;
            if (WPDQZYCLDULYRKQYRXYYJKOOXTKATYIVFKKEGANBU(player)) return null;
            var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info) > 0 ? false : (bool?)null;
            if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
            {
                if (player.GetComponent<NPCPlayer>() != null || player.GetComponent<BaseNpc>() != null || player.IsNpc) return null;
                if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
                RMOPIZXSONMCMKHSYEFRDRZHAFVXMTMNLQTOCQSJPKDWXT(player, item);
            }
            return XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK;
        }
        private object OnReloadWeapon(BasePlayer player, BaseProjectile projectile)
        {
            if (player is NPCPlayer) return null;
            if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
            if (player.GetComponent<NPCPlayer>() != null || player.GetComponent<BaseNpc>() != null || player.IsNpc) return null;
            var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(projectile.primaryMagazine.ammoType) > 0 ? false : (bool?)null;
            if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false && !WPDQZYCLDULYRKQYRXYYJKOOXTKATYIVFKKEGANBU(player))
            {
                List<Item> WFGBJWGHTCPQSEGXROPIWVVBCDWGDLAPVPXLYDXKUANIXSIK = player.inventory.FindItemIDs(projectile.primaryMagazine.ammoType.itemid).ToList<Item>();
                if (WFGBJWGHTCPQSEGXROPIWVVBCDWGDLAPVPXLYDXKUANIXSIK.Count == 0)
                {
                    List<Item> OOOKBYBJEZFZAEIBAUCGUZOQEOWHNEJVMEPWMETR = new List<Item>();
                    player.inventory.FindAmmo(OOOKBYBJEZFZAEIBAUCGUZOQEOWHNEJVMEPWMETR, projectile.primaryMagazine.definition.ammoTypes);
                    if (OOOKBYBJEZFZAEIBAUCGUZOQEOWHNEJVMEPWMETR.Count > 0)
                    {
                        XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(OOOKBYBJEZFZAEIBAUCGUZOQEOWHNEJVMEPWMETR[0].info) > 0 ? false : (bool?)null;
                    }
                }
                if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
                {
                    SendReply(player, $"Вы <color=#81B67A>не можете</color> использовать этот тип боеприпасов!");
                }
                return XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK;
            }
            return null;
        }
        private object OnReloadMagazine(BasePlayer player, BaseProjectile projectile)
        {
            if (player is NPCPlayer) return null;
            if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
            NextTick(() => {
                var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(projectile.primaryMagazine.ammoType) > 0 ? false : (bool?)null;
                if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
                {
                    player.GiveItem(ItemManager.CreateByItemID(projectile.primaryMagazine.ammoType.itemid, projectile.primaryMagazine.contents, 0UL), BaseEntity.GiveItemReason.Generic);
                    projectile.primaryMagazine.contents = 0;
                    projectile.GetItem().LoseCondition(projectile.GetItem().maxCondition);
                    projectile.SendNetworkUpdate();
                    player.SendNetworkUpdate();
                    PrintError($"[{DateTime.Now.ToShortTimeString()}] {player} пытался взломать систему блокировки!");
                    SendReply(player, $"<color=#81B67A>Хорошая</color> попытка, правда ваше оружие теперь сломано!");
                }
            });
            return null;
        }
        private void OnPlayerConnected(BasePlayer player, bool first = true)
        {
            if (player.IsReceivingSnapshot)
            {
                NextTick(() => OnPlayerConnected(player, first));
                return;
            }
            if (!BPFPEIVYDPSHFBTQGUKJXHKTCQLTYNUXQVGXQMOGHLDCSQKH()) return;
        }
        private object CanMoveItem(Item item, PlayerInventory inventory, ItemContainerId targetContainer)
        {
            if (inventory == null || item == null) return null;
            BasePlayer player = inventory.GetComponent<BasePlayer>();
            if (player == null) return null;
            if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
            ItemContainer JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP = inventory.FindContainer(targetContainer);
            if (JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP == null || JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.entityOwner == null) return null;
            if (JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.entityOwner is AutoTurret)
            {
                var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info.shortname) > 0 ? false : (bool?)null;
                if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
                {
                    RMOPIZXSONMCMKHSYEFRDRZHAFVXMTMNLQTOCQSJPKDWXT(player, item);
                    return true;
                }
            }
            return null;
        }
        private object CanAcceptItem(ItemContainer JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP, Item item)
        {
            if (JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info.shortname) > 0)
            {
                item.SetFlag(global::Item.Flag.Cooking, true);
                item.MarkDirty();
            }
            else
            {
                item.SetFlag(global::Item.Flag.Cooking, false);
                item.MarkDirty();
            }
            if (JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP == null || item == null || JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.entityOwner == null) return null;
            if (JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.entityOwner is AutoTurret)
            {
                BasePlayer player = item.GetOwnerPlayer();
                if (player == null) return null;
                if (permission.UserHasPermission(player.UserIDString, RLANAPAUPYPQQDAMEBQENVTHHURBMPHJLALJEIQUVNRX)) return null;
                var XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK = JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info.shortname) > 0 ? false : (bool?)null;
                if (XLGEWCYXCWWWIFDGOLEKNPRDPFKUREEHHAIHKMJAOHLGCAK == false)
                {
                    RMOPIZXSONMCMKHSYEFRDRZHAFVXMTMNLQTOCQSJPKDWXT(player, item);
                    return ItemContainer.CanAcceptResult.CannotAcceptRightNow;
                }
            }
            return null;
        }
        [ConsoleCommand("UI_WipeBlock")]
        private void ZHYFBLHDAJMMWHBZQVMTBQXKYANSAGMIUEFEPOFQF(ConsoleSystem.Arg args)
        {
            var player = args.Player();
            if (!player || !args.HasArgs(1)) return;
            switch (args.Args[0].ToLower())
            {
                case "page":
                    {
                        OpenWipeBlock(player, args.Args[1], int.Parse(args.Args[2]), true);
                        break;
                    }
            }
        }
        [ConsoleCommand("wipeblock.ui.open")]
        private void GLJYEAEFFYVMBIKOHBXODUXESRBWKBQVNCJMAAVNNVANMIDXU(ConsoleSystem.Arg args)
        {
            if (args.Player() == null) return;
            OpenWipeBlock(args.Player());
        }
        [ConsoleCommand("blockmove")]
        private void HDTRWMOFFNYIUDHZYYYXOGFJAHTJRKNECJUMCVGX(ConsoleSystem.Arg args)
        {
            if (args.Player() != null) return;
            if (!args.HasArgs(1))
            {
                PrintWarning($"Введите количество секунд для перемещения!");
                return;
            }
            int BTERLTWFGXXGDGPZXGNBTWAPKNVOLPVBLKSFKZTUACGGLPIY;
            if (!int.TryParse(args.Args[0], out BTERLTWFGXXGDGPZXGNBTWAPKNVOLPVBLKSFKZTUACGGLPIY))
            {
                PrintWarning("Вы ввели не число!");
                return;
            }
            MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.TimeMove += BTERLTWFGXXGDGPZXGNBTWAPKNVOLPVBLKSFKZTUACGGLPIY;
            SaveConfig();
            PrintWarning("Время блокировки успешно изменено!");
            QKJIKYVSYQQHARYQIMFONGUKRNZWJOCCKGGYXJDJI();
        }
        private void UUHOFAWGNJEYWMAYJROSENVZUFKJUXCSBZTMYVUGXCEBIFGXT(BasePlayer player)
        {
            OpenWipeBlock(player);
        }
        [ConsoleCommand("wipeblock.ui.close")]
        private void SERETGZHTAPMLQGMXWSOZOXIVBJURPYNPGEYBWGMNQBTQ(ConsoleSystem.Arg args)
        {
            if (args.Player() == null) return;
            args.Player()?.SetFlag(BaseEntity.Flags.Reserved3, false);
        }
        private void OpenWipeBlock(BasePlayer player, string FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY = "Total", int page = 0, bool MNSAYHGWRDNJJLOFKFXBWBVWFTODQQQMYNJJGULYRYFA = false)
        {
            CuiElementContainer JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP = new CuiElementContainer();
            if (!MNSAYHGWRDNJJLOFKFXBWBVWFTODQQQMYNJJGULYRYFA)
            {
                CuiHelper.DestroyUi(player, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI);
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
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
                }, "MS_UI", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI);
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel()
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
                }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".RS");
            }
            CuiHelper.DestroyUi(player, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".C");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel()
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
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".RS", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".C");
            if (!MNSAYHGWRDNJJLOFKFXBWBVWFTODQQQMYNJJGULYRYFA)
            {
                CuiHelper.DestroyUi(player, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R");
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel()
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
                }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".RSE");
            }
            CuiHelper.DestroyUi(player, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel()
            {
                CursorEnabled = true,
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = "0 0",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0.08 0.08 0.08 0"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".RSE", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R");
            float XPYGQCFSOHXYHTRBWUSOJPYMTARPUEVEXOOZXUVI = (1 / 2f * 40 + (1 - 1) / 2f * 5);
            int NVRVVTJPEOUQJRHQLMPLPYKLSBSERECZKBVTGQXHHAPPB = 0;
            int NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ = 0;
            string NDHDCOCGIEBSYQTYTHGPWYGEHOHSASEPEKILAANUSDVJUEKCA = lang.GetLanguage(player.UserIDString);
            bool TWZTDOWCVNGKGQALONHIYTTMWTDXKCEFSFZHQLHTOXEANIWF = NDHDCOCGIEBSYQTYTHGPWYGEHOHSASEPEKILAANUSDVJUEKCA == "ru";
            foreach (var vip in HUUSOFYXCNYWKHAOBZEYUAWTNUZJOFFCSFPRRTJEPZAQ)
            {
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiElement
                {
                    Parent = TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".C",
                    Name = TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + vip.Value,
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY == vip.Key ? "1 1 1 1" : "1 1 1 0.2"
            },
            new CuiRectTransformComponent {
              AnchorMin = $"{0.038 + (NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ * 0.187)} {0.08 - (NVRVVTJPEOUQJRHQLMPLPYKLSBSERECZKBVTGQXHHAPPB * 0.18)}", AnchorMax = $"{0.038 + (NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ * 0.187) + 0.175f} {0.92 - (NVRVVTJPEOUQJRHQLMPLPYKLSBSERECZKBVTGQXHHAPPB * 0.18)}"
            }
          }
                });
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1",
            OffsetMin = "0 0",
            OffsetMax = "0 0"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = $"UI_WipeBlock page {vip.Key} {0}"
          },
                    Text = {
            Text = TWZTDOWCVNGKGQALONHIYTTMWTDXKCEFSFZHQLHTOXEANIWF ? vip.Value.ToUpper() : vip.Key.ToUpper(),
            Align = TextAnchor.MiddleCenter,
            Font = "robotocondensed-bold.ttf",
            FontSize = 18,
            Color = FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY == vip.Key ? "0.929 0.882 0.847 0.75" : "0.7 0.7 0.7 0.2"
          }
                }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + vip.Value);
                XPYGQCFSOHXYHTRBWUSOJPYMTARPUEVEXOOZXUVI -= 40 + 5;
                NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ++;
                if (NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ == 5)
                {
                    break;
                }
            }
            var itemList = new Dictionary<string,
              double>();
            foreach (var check in MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM)
            {
                foreach (var test in check.Value)
                {
                    var item = ItemManager.FindItemDefinition(test);
                    if (item.category.ToString() == FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY || FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY == "Total") itemList.Add(item.shortname, JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item));
                }
            }
            int IQXUSXZDMWJKZSTJBRAQSUCFOTAPTZOWYOBMHKAHZEE = 5;
            float XIPELQLQWOQNNRGZWKJNINMKQGBRRSQOQOIFDVDCNYAJY = 90;
            float YQDBLPURGKWFNEOUYDXCXYIBVAGGZKMDLCILNQHBTZIXI = 1f / IQXUSXZDMWJKZSTJBRAQSUCFOTAPTZOWYOBMHKAHZEE;
            int HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT = 0;
            float HMZQFWCKLRAPNTJVIJRAUKLHADZNYVXZDDQELCQWEI = 5;
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMin = $"40 30",
          OffsetMax = $"-40 -30"
        },
                Image = {
          Color = "1 1 1 0"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".HRPStore");
            foreach (var check in itemList.Skip(page * 20).Take(20))
            {
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = $"{HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT * YQDBLPURGKWFNEOUYDXCXYIBVAGGZKMDLCILNQHBTZIXI} 1",
            AnchorMax = $"{(HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT + 1) * YQDBLPURGKWFNEOUYDXCXYIBVAGGZKMDLCILNQHBTZIXI} 1",
            OffsetMin = $"{(HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT == 0 ? "0" : "10")} {HMZQFWCKLRAPNTJVIJRAUKLHADZNYVXZDDQELCQWEI - XIPELQLQWOQNNRGZWKJNINMKQGBRRSQOQOIFDVDCNYAJY}",
            OffsetMax = $"{(HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT == 4 ? "0" : "-5")} {HMZQFWCKLRAPNTJVIJRAUKLHADZNYVXZDDQELCQWEI}"
          },
                    Image = {
            Color = "0 0 0 0"
          }
                }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".HRPStore", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key);
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiElement
                {
                    Parent = TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key,
                    Name = "Btn",
                    Components = {
            new CuiRawImageComponent {
              Png = check.Value > 0 ? (string) ImageLibrary.Call("GetImage", "BlockButtonImage") : (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.05 -0.05", AnchorMax = "0.95 1.05"
            }
          }
                });
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "1 1",
            AnchorMax = "1 1",
            OffsetMin = "-25 -20",
            OffsetMax = "-10 -5.5"
          },
                    Image = {
            Color = check.Value > 0 ? "1 1 1 1" : "0 0 0 0",
            Sprite = check.Value > 0 ? "assets/icons/bp-lock.png" : "assets/content/textures/generic/fulltransparent.tga"
          }
                }, "Btn");
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiElement
                {
                    Parent = TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key,
                    Components = {
            new CuiImageComponent {
                ItemId = GetItemId(check.Key)
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0", AnchorMax = "0.5 1", OffsetMin = "-35 10", OffsetMax = "35 -10"
            }
          }
                });
                string color = check.Value > 0 ? "0.7 0.64 0.7 0.95" : "0.376 0.384 0.459 0.85";
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0.5 0",
            AnchorMax = "0.5 0",
            OffsetMin = $"-35 -2.5",
            OffsetMax = $"35 15"
          },
                    Image = {
            Color = color
          }
                }, "Btn", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key + ".L");
                JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = check.Value > 0 ? TimeSpan.FromSeconds(check.Value).ToShortString() : string.Format(lang.GetMessage("AVAILABLE", this, player.UserIDString)),
            Align = check.Value > 0 ? TextAnchor.MiddleCenter : TextAnchor.MiddleCenter,
            Font = "robotocondensed-bold.ttf",
            FontSize = check.Value > 0 ? 12 : 11,
            Color = check.Value > 0 ? "0.2 0.2 0.2 1" : "0.81 0.80 0.85 1"
          }
                }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key + ".L");
                if (check.Value > 0)
                {
                    JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "0 0",
              AnchorMax = "0 1",
              OffsetMin = "4 4",
              OffsetMax = "15 -3"
            },
                        Button = {
              Color = "0.3 0.25 0.3 1",
              Sprite = "assets/icons/electric.png"
            },
                        Text = {
              Text = ""
            }
                    }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R" + check.Key + ".L");
                }
                HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT++;
                if (HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT == 5)
                {
                    HZNSZWLWRZHBFKINRWXSTLWDHIWWIXQLSWSHTHKQRPLIELKXT = 0;
                    HMZQFWCKLRAPNTJVIJRAUKLHADZNYVXZDDQELCQWEI -= XIPELQLQWOQNNRGZWKJNINMKQGBRRSQOQOIFDVDCNYAJY + 15;
                }
            }
            string NPZPWGZOQSPUYXJKWYHIARAPAXXYHBRJARSDVGPISDHJRTQ = $"UI_WipeBlock page {FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY} {page - 1}";
            string MJOTMVRWOJOZIAGPAGUHEGOPJYPXKQXHGBMYNXXFZVOLRQAS = $"UI_WipeBlock page {FSDNFIILEGPDARYZLAYHLJBZZWYWWZVKFYUWDOVFTHSKJNY} {page + 1}";
            bool RILZIQGUYKNGUMXLHSHOHCCJOIJRCYSYXASIMHXKGEPNJYFJ = page > 0;
            bool ZKXSEPPGBKAHORZROJTUPZZUWHDMPZPCZBCNUGSLCCLWXC = (page + 1) * 20 < itemList.Count;
            var MPWVPLPAAKDVWLCQBUXINOMWIQHRNOCXUQRXTEZRKACDRK = page + 1;
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
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
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".R", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
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
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS", "LabelPage");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Text = {
          Text = string.Format(lang.GetMessage("PAGE", this, player.UserIDString)) + $" {MPWVPLPAAKDVWLCQBUXINOMWIQHRNOCXUQRXTEZRKACDRK}",
          FontSize = 25,
          Font = "robotocondensed-regular.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = "0.889 0.882 0.847 0.8"
        }
            }, "LabelPage", "ThisLabel");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.15 0",
          AnchorMax = "0.29 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = RILZIQGUYKNGUMXLHSHOHCCJOIJRCYSYXASIMHXKGEPNJYFJ ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS.L");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = RILZIQGUYKNGUMXLHSHOHCCJOIJRCYSYXASIMHXKGEPNJYFJ ? NPZPWGZOQSPUYXJKWYHIARAPAXXYHBRJARSDVGPISDHJRTQ : ""
        },
                Text = {
          Text = "<b><</b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = RILZIQGUYKNGUMXLHSHOHCCJOIJRCYSYXASIMHXKGEPNJYFJ ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS.L");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.71 0",
          AnchorMax = "0.85 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = ZKXSEPPGBKAHORZROJTUPZZUWHDMPZPCZBCNUGSLCCLWXC ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS", TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS.R");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = ZKXSEPPGBKAHORZROJTUPZZUWHDMPZPCZBCNUGSLCCLWXC ? MJOTMVRWOJOZIAGPAGUHEGOPJYPXKQXHGBMYNXXFZVOLRQAS : ""
        },
                Text = {
          Text = "<b>></b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = ZKXSEPPGBKAHORZROJTUPZZUWHDMPZPCZBCNUGSLCCLWXC ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, TXSARDNFNQHYAFUFOJXHWEERJXHQZJUAFFTWHJWBSXEOI + ".PS.R");
            CuiHelper.AddUi(player, JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP);
        }
        private void RMOPIZXSONMCMKHSYEFRDRZHAFVXMTMNLQTOCQSJPKDWXT(BasePlayer player, Item item)
        {
            CuiHelper.DestroyUi(player, "Notification");
            CuiElementContainer JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP = new CuiElementContainer();
            string AZLJCZUEXDZMZEXNMHFBGUFXXUGXNMIEXTHRCFAYZLTUTRAN = string.Format(lang.GetMessage("TIME BLOCKED", this, player.UserIDString)) + " {1}".Replace("{1}", $"{Convert.ToInt32(Math.Floor(TimeSpan.FromSeconds(JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info)).TotalHours))} " + string.Format(lang.GetMessage("HOURS", this, player.UserIDString)) + $" {TimeSpan.FromSeconds(JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(item.info)).Minutes} " + string.Format(lang.GetMessage("MINUTES", this, player.UserIDString)));
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                FadeOut = 1f,
                Image = {
          FadeIn = 1f,
          Color = "0.1 0.1 0.1 0"
        },
                RectTransform = {
          AnchorMin = "0.5 1",
          AnchorMax = "0.5 1",
          OffsetMin = "-200 -150",
          OffsetMax = "200 -100"
        },
                CursorEnabled = false
            }, "Overlay", "Notification");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                FadeOut = 1f,
                Image = {
          FadeIn = 1f,
          Color = "0 0 0 0"
        },
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
            }, "Notification", "Main");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiElement
            {
                FadeOut = 1f,
                Parent = "Main",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "PanelButtonsImage"), Color = "1 1 1 1", FadeIn = 1f
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-15 -5", OffsetMax = "15 5"
          }
        }
            });
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiPanel
            {
                FadeOut = 1f,
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "0 1",
          OffsetMax = "55 0"
        },
                Image = {
          Color = "0.65 0.65 0.65 1",
          Sprite = "assets/icons/info.png"
        }
            }, "Main");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiLabel
            {
                FadeOut = 1f,
                Text = {
          FadeIn = 1f,
          Color = "0.9 0.9 0.9 1",
          Text = string.Format(lang.GetMessage("ITEM BLOCKED", this, player.UserIDString)),
          FontSize = 22,
          Align = TextAnchor.UpperCenter,
          Font = "robotocondensed-bold.ttf"
        },
                RectTransform = {
          AnchorMin = "0.08 0",
          AnchorMax = "1 1"
        }
            }, "Main");
            JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP.Add(new CuiLabel
            {
                FadeOut = 1f,
                Text = {
          FadeIn = 1f,
          Text = AZLJCZUEXDZMZEXNMHFBGUFXXUGXNMIEXTHRCFAYZLTUTRAN,
          FontSize = 14,
          Align = TextAnchor.MiddleCenter,
          Color = "0.85 0.85 0.85 1",
          Font = "robotocondensed-regular.ttf"
        },
                RectTransform = {
          AnchorMin = "0.1 0",
          AnchorMax = "1 0.75"
        }
            }, "Main");
            CuiHelper.AddUi(player, JPUHDXYRRNGOAMJEFSYQUBHJDWHVRAPGCANBSWRYQYCLMEBXP);
            timer.Once(2f, () => CuiHelper.DestroyUi(player, "Notification"));
        }
        private double KZWKFMINZMGODEAGUAZQWRSQIMVBTOCJGSLXPJHACCTC(int LVITNZDQWOLRVVFTCFAMBLVBEYPUYJYWVVTYFKDR) => JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM.ElementAt(LVITNZDQWOLRVVFTCFAMBLVBEYPUYJYWVVTYFKDR).Value.First());
        private bool BPFPEIVYDPSHFBTQGUKJXHKTCQLTYNUXQVGXQMOGHLDCSQKH() => ELOHXAZMSJBBEPMPWLAITXLXIGSNHDWUGUYZPACMGQN(MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM.Last().Key) > CurrentTime();
        private double JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(string shortname)
        {
            if (!MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM.SelectMany(p => p.Value).Contains(shortname)) return 0;
            var NPVMIPFUNLHSXRLUUPFWFKHHHCUBKEGUTLZWNSOEBXPT = MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.FYSNSGVQBIJAJNSZQTEHDUTWCPHTOXZGHCGFRBGHTOKVETM.FirstOrDefault(p => p.Value.Contains(shortname)).Key;
            var FCUIAZCUQGCIOEGVEJJFMZMROGBABUIUNNBAATKEDACEWOZ = (ELOHXAZMSJBBEPMPWLAITXLXIGSNHDWUGUYZPACMGQN(NPVMIPFUNLHSXRLUUPFWFKHHHCUBKEGUTLZWNSOEBXPT)) - CurrentTime();
            return FCUIAZCUQGCIOEGVEJJFMZMROGBABUIUNNBAATKEDACEWOZ > 0 ? FCUIAZCUQGCIOEGVEJJFMZMROGBABUIUNNBAATKEDACEWOZ : 0;
        }
        private double ELOHXAZMSJBBEPMPWLAITXLXIGSNHDWUGUYZPACMGQN(int VBZYSKZFFPSFNZAZGOOJJRNPOVABGNSCIZFJWDMNQOTU) => SaveRestore.SaveCreatedTime.ToUniversalTime().Subtract(IJWOGNGGQCTTXBSVYIUADGULYEBMWHUAHNRSYTOAHVKXZ).TotalSeconds + VBZYSKZFFPSFNZAZGOOJJRNPOVABGNSCIZFJWDMNQOTU + MGLBAEMANXNLQCAGDBYKUJTMEQXLLMYJNWCEMQHZBGENJM.NWMBIFRLEVKCYBCDJDSHHMIONWOOKYSIDNGSKXYBKVAVQDJ.TimeMove;
        private double JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(ItemDefinition itemDefinition) => JVHJSYTEMMOWCZPVVQKUWAUGECLEHAMGDFOSMOYXNSEZZ(itemDefinition.shortname);
        private void QKJIKYVSYQQHARYQIMFONGUKRNZWJOCCKGGYXJDJI()
        {
            if (BPFPEIVYDPSHFBTQGUKJXHKTCQLTYNUXQVGXQMOGHLDCSQKH())
            {
                foreach (BasePlayer player in BasePlayer.activePlayerList) OnPlayerConnected(player, false);
                ABPRLDKWWFQHXRDUCMYKUDZSVOUFSQRFDMEODYXTAALUNOH = ServerMgr.Instance.StartCoroutine(KHQLPWIYRGLJTMBPTGNCSFLPSHALSQJWELZGXLEOSVGCKWQYD());
                SubscribeHooks(true);
            }
            else SubscribeHooks(false);
        }
        private void SubscribeHooks(bool QHWTYZVOHDDOJJWKXYRWQWOUQDDCBSVYSKXOEIIOXN)
        {
            if (QHWTYZVOHDDOJJWKXYRWQWOUQDDCBSVYSKXOEIIOXN)
            {
                Subscribe(nameof(CanWearItem));
                Subscribe(nameof(CanEquipItem));
                Subscribe(nameof(OnReloadWeapon));
                Subscribe(nameof(OnReloadMagazine));
                Subscribe(nameof(CanAcceptItem));
                Subscribe(nameof(CanMoveItem));
            }
            else
            {
                Unsubscribe(nameof(CanWearItem));
                Unsubscribe(nameof(CanEquipItem));
                Unsubscribe(nameof(OnReloadWeapon));
                Unsubscribe(nameof(OnReloadMagazine));
                Unsubscribe(nameof(CanAcceptItem));
                Unsubscribe(nameof(CanMoveItem));
            }
        }
        static readonly DateTime IJWOGNGGQCTTXBSVYIUADGULYEBMWHUAHNRSYTOAHVKXZ = new DateTime(1970, 1, 1, 0, 0, 0);
        static double CurrentTime()
        {
            return DateTime.UtcNow.Subtract(IJWOGNGGQCTTXBSVYIUADGULYEBMWHUAHNRSYTOAHVKXZ).TotalSeconds;
        }
        public static string ToShortString(TimeSpan WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL)
        {
            int NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ = 0;
            string HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM = "";
            if (WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Days > 0)
            {
                HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Days + " День";
                NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ++;
            }
            if (WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Hours > 0 && NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ < 2)
            {
                if (HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM.Length != 0) HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += " ";
                HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Days + " Час";
                NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ++;
            }
            if (WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Minutes > 0 && NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ < 2)
            {
                if (HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM.Length != 0) HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += " ";
                HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Days + " Мин.";
                NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ++;
            }
            if (WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Seconds > 0 && NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ < 2)
            {
                if (HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM.Length != 0) HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += " ";
                HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM += WBVNTQDTPBYPUTCDVWTNOIFVZLIGOQDZDVRSUPJL.Days + " Сек.";
                NXGILIFXXPKGDUAEXAMUFIVNKVOHDPIVJENVXISTTNEFJ++;
            }
            return HBHHFOTYKCOLPCMTJIITMJKAXETUSIVXLHWZFPCGGJCPDM;
        }
        private void GetConfig<T>(string ZFXUUDUCFNSEALOWAOIIWEZXYMYCJIFMHPPCHBEHNEJCLVCJD, string key, ref T UABDBVGZVIFSSWHFXKWLPZKAUSUWMDJOYOOELDNUVHFVCVMN)
        {
            if (Config[ZFXUUDUCFNSEALOWAOIIWEZXYMYCJIFMHPPCHBEHNEJCLVCJD, key] != null)
            {
                UABDBVGZVIFSSWHFXKWLPZKAUSUWMDJOYOOELDNUVHFVCVMN = Config.ConvertValue<T>(Config[ZFXUUDUCFNSEALOWAOIIWEZXYMYCJIFMHPPCHBEHNEJCLVCJD, key]);
            }
            else
            {
                Config[ZFXUUDUCFNSEALOWAOIIWEZXYMYCJIFMHPPCHBEHNEJCLVCJD, key] = UABDBVGZVIFSSWHFXKWLPZKAUSUWMDJOYOOELDNUVHFVCVMN;
            }
        }
        private bool WPDQZYCLDULYRKQYRXYYJKOOXTKATYIVFKKEGANBU(BasePlayer player)
        {
            if (Duels != null)
                if (Duels.Call<bool>("inDuel", player)) return true;
            if (Duel != null)
            {
                var MNOLBPGEXRGJAUZFCGQZHFMOUGCMCGUWLAHGEWUIF = (bool)Duel?.Call("IsPlayerOnActiveDuel", player);
                if (MNOLBPGEXRGJAUZFCGQZHFMOUGCMCGUWLAHGEWUIF) return true;
            }
            if (Battles != null)
                if (Battles.Call<bool>("IsPlayerOnBattle", player.userID)) return true;
            return false;
        }
        private IEnumerator KHQLPWIYRGLJTMBPTGNCSFLPSHALSQJWELZGXLEOSVGCKWQYD()
        {
            while (true)
            {
                if (!BPFPEIVYDPSHFBTQGUKJXHKTCQLTYNUXQVGXQMOGHLDCSQKH())
                {
                    foreach (BasePlayer player in BasePlayer.activePlayerList) CuiHelper.DestroyUi(player, FVRASBAVCQZVDHUTPERBMCVFVRKWHGWSNJPTHZWHP);
                    SubscribeHooks(false);
                    this.ABPRLDKWWFQHXRDUCMYKUDZSVOUFSQRFDMEODYXTAALUNOH = null;
                    yield
                    break;
                }
                yield
                return new WaitForSeconds(30);
            }
        }
        private void InitializeLang()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["AVAILABLE"] = "AVAILABLE",
                ["PAGE"] = "PAGE:",
                ["ITEM BLOCKED"] = "THE ITEM IS BLOCKED!",
                ["TIME BLOCKED"] = "The item is temporarily blocked on",
                ["HOURS"] = "hours",
                ["MINUTES"] = "minutes",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["AVAILABLE"] = "ДОСТУПНО",
                ["PAGE"] = "СТРАНИЦА:",
                ["ITEM BLOCKED"] = "ПРЕДМЕТ ЗАБЛОКИРОВАН!",
                ["TIME BLOCKED"] = "Предмет временно заблокирован на",
                ["HOURS"] = "часов",
                ["MINUTES"] = "минут",
            }, this, "ru");
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