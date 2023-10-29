/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */  using System;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;
using Oxide.Game.Rust.Cui;
using Oxide.Core;
using System.Collections.Generic;
using System.Collections;
using Oxide.Core.Plugins;
namespace Oxide.Plugins
{
    [Info("XSkinMenu", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class XSkinMenu : RustPlugin
    {
        private void SetSkinTransport(BasePlayer player, BaseVehicle SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR, string shortname)
        {
            ulong skin = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[shortname];
            if (skin == SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.skinID || skin == 0) return;
            if (CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT.ContainsKey(skin)) shortname = CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT[skin];
            if (XTEECDASVLBJYRVJPCCUAIUJTEXIZLVGGYKLURTGYVUSZKQHN.ContainsKey(shortname)) shortname = XTEECDASVLBJYRVJPCCUAIUJTEXIZLVGGYKLURTGYVUSZKQHN[shortname];
            BaseVehicle transport = GameManager.server.CreateEntity($"assets/content/vehicles/snowmobiles/{shortname}.prefab", SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.transform.position, SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.transform.rotation) as BaseVehicle;
            transport.health = SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.health;
            transport.skinID = skin;
            SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.Kill();
            transport.Spawn();
            Effect.server.Run("assets/prefabs/deployable/repair bench/effects/skinchange_spraypaint.prefab", transport.transform.localPosition);
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM = Config.ReadObject<SkinConfig>();
            }
            catch
            {
                PrintWarning("Ошибка чтения конфигурации! Создание дефолтной конфигурации!");
                LoadDefaultConfig();
            }
            SaveConfig();
        }
        private void SaveData(BasePlayer player)
        {
            ulong userID = player.userID;
            if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC.ContainsKey(userID)) Interface.Oxide.DataFileSystem.WriteObject($"XDataSystem/XSkinMenu/UserSettings/{userID}", CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[userID]);
        }
        private void OnPlayerDisconnected(BasePlayer player)
        {
            if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC.ContainsKey(player.userID))
            {
                SaveData(player);
                CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC.Remove(player.userID);
            }
            if (VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL.ContainsKey(player)) VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL.Remove(player);
        }
        [ConsoleCommand("skin_c")]
        private void HARNLIWJOCXXNTRYUWMVGEYNJGYSSSGDTIGAVKPTFJDUVD(ConsoleSystem.Arg args)
        {
            BasePlayer player = args.Player();
            if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.use"))
            {
                SendReply(player, lang.GetMessage("NOPERM", this, player.UserIDString));
                return;
            }
            if (VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL.ContainsKey(player))
                if (VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player].Subtract(DateTime.Now).TotalSeconds >= 0) return;
            Effect QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = new Effect("assets/bundled/prefabs/fx/notice/loot.drag.grab.fx.prefab", player, 0, new Vector3(), new Vector3());
            Effect VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP = new Effect("assets/bundled/prefabs/fx/weapons/survey_charge/survey_charge_stick.prefab", player, 0, new Vector3(), new Vector3());
            switch (args.Args[0])
            {
                case "category":
                    {
                        KJBSHYAYIPAVOZQNOCXMXLOEWCXBOGJRMDXKOETFRH(player, int.Parse(args.Args[2]));
                        ItemGUI(player, args.Args[1]);
                        EffectNetwork.Send(QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO, player.Connection);
                        VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(0.5f);
                        break;
                    }
                case "skin":
                    {
                        SkinGUI(player, args.Args[1]);
                        EffectNetwork.Send(QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO, player.Connection);
                        CuiHelper.DestroyUi(player, ".ItemGUI");
                        VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(0.5f);
                        break;
                    }
                case "setskin":
                    {
                        string item = args.Args[1];
                        ulong skin = ulong.Parse(args.Args[2]);
                        if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.skinchange") || !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(item)) return;
                        Effect NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = new Effect("assets/prefabs/deployable/repair bench/effects/skinchange_spraypaint.prefab", player, 0, new Vector3(), new Vector3());
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[item] = skin;
                        if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.inventory")) SendReply(player, lang.GetMessage("NOPERM", this, player.UserIDString));
                        else
                        {
                            if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI) SetSkinItem(player, item, skin);
                            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.GUI.FCDOFSXVAOXBBUJGDFRSZBVVGPKKPQQDSGHEZABIMYH) SkinGUI(player, item, int.Parse(args.Args[3]));
                        }
                        EffectNetwork.Send(NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC, player.Connection);
                        VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(1.5f);
                        break;
                    }
                case "clear":
                    {
                        if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.skinchange")) return;
                        string item = args.Args[1];
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[item] = 0;
                        CuiHelper.DestroyUi(player, $".I + {args.Args[2]}");
                        if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT) SetSkinItem(player, item, 0);
                        if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.GUI.XRTLAZSXPLMQXSERPRDIKZRWLHACNAQZYJHQJRIGI) ItemGUI(player, args.Args[3], int.Parse(args.Args[4]));
                        EffectNetwork.Send(VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP, player.Connection);
                        VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(0.5f);
                        break;
                    }
                case "clearall":
                    {
                        if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.skinchange")) return;
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.Clear();
                        foreach (var skin in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ) CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.Add(skin.Key, 0);
                        GUI(player);
                        EffectNetwork.Send(VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP, player.Connection);
                        VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(2.5f);
                        break;
                    }
            }
        }
        [ConsoleCommand("skinimage_reload")]
        private void DRYYHKDLDBEDEJEQWWUEENQDKHTPWBDSGTVAUTZTQXDZQ(ConsoleSystem.Arg args)
        {
            if (args.Player() == null || args.Player().IsAdmin)
            {
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ)
                {
                    PrintError("COMMAND_OFF");
                    return;
                }
                if (GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO == null) GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = ServerMgr.Instance.StartCoroutine(TYORIPERWJZQQVXVCZTJJTXMSZHDAYEYSBQCRIBSMD());
                else PrintWarning("Загрузка/перезагрузка изображений продолжается. Подождите!");
            }
        }
        private void KJBSHYAYIPAVOZQNOCXMXLOEWCXBOGJRMDXKOETFRH(BasePlayer player, int page = 0)
        {
            CuiHelper.DestroyUi(player, ".SkinBUTTON");
            CuiElementContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU = new CuiElementContainer();
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "1 0.115",
          AnchorMax = "1 0.95",
          OffsetMin = "-185 0",
          OffsetMax = "-2.5 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".SGUI", ".SkinBUTTON");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
            {
                Parent = ".SkinBUTTON",
                Name = "PanelBtn",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "skin_height"), Color = "1 1 1 1"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0.15", AnchorMax = "1 1"
          }
        }
            });
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
            {
                Parent = "PanelBtn",
                Name = "SettignsBtn",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = "1 1 1 1"
          },
          new CuiRectTransformComponent {
            AnchorMin = "-0.036 -0.15", AnchorMax = "1 0"
          }
        }
            });
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0.16",
          AnchorMax = "1 0.77"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".SkinBUTTON", ".CategoryPanel");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Color = "0 0 0 0",
          Command = "skin_s open"
        },
                Text = {
          Text = ""
        }
            }, "SettignsBtn", ".SettignsBtn");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-50 -20",
          OffsetMax = "70 20"
        },
                Text = {
          Text = lang.GetMessage("SETTINGS", this, player.UserIDString),
          Align = TextAnchor.MiddleCenter,
          FontSize = 22,
          Font = "robotocondensed-bold.ttf",
          Color = "0.929 0.882 0.847 1"
        }
            }, ".SettignsBtn", "ThisLabel");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0.2",
          AnchorMax = "0 0.8",
          OffsetMin = "-30 0",
          OffsetMax = "-5 0"
        },
                Button = {
          Color = "1 1 1 0.75",
          Sprite = "assets/icons/gear.png",
          Command = "skin_s open"
        },
                Text = {
          Text = ""
        }
            }, "ThisLabel");
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, IAQBAUVMIWEBNOIFTEHCNVIUNELOMUFVMTPFNBFCZBTKYAVH = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ.Count;
            foreach (var category in KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ)
            {
                string FUKOZJNSWOWJHANQIOTYCSSYEDMCXWNJDQGZVGMKCNRMJTSBF = page == QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO ? "0.8 0.8 0.8 1" : "0.7 0.7 0.7 0.3";
                string PLBJVMCLJWWKVAAMFRTOVBCJVPAFPLKLXDGCIUVTXJXPNSS = page == QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO ? "0.7507126 0.7507126 0.7507126 1" : "0.5507126 0.5507126 0.5507126 0.25";
                double offset = (25 * IAQBAUVMIWEBNOIFTEHCNVIUNELOMUFVMTPFNBFCZBTKYAVH--) + (-0.5 * IAQBAUVMIWEBNOIFTEHCNVIUNELOMUFVMTPFNBFCZBTKYAVH--);
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".CategoryPanel",
                    Name = ".BUTTON",
                    Components = {
            new CuiRawImageComponent {
              Color = "0 0 0 0"
            },
            new CuiRectTransformComponent {
              AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = $"-90 {offset}", OffsetMax = $"90 {offset + 50}"
            }
          }
                });
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".BUTTON",
                    Name = "Btn",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = FUKOZJNSWOWJHANQIOTYCSSYEDMCXWNJDQGZVGMKCNRMJTSBF
            },
            new CuiRectTransformComponent {
              AnchorMin = "-0.005 -0.005", AnchorMax = "1.005 1.005"
            }
          }
                });
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Color = "1 1 1 0",
            Command = $"skin_c category {category.Key} {QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO}"
          },
                    Text = {
            Text = lang.GetMessage(category.Key, this, player.UserIDString),
            Align = TextAnchor.MiddleCenter,
            Font = "robotocondensed-bold.ttf",
            FontSize = 18,
            Color = PLBJVMCLJWWKVAAMFRTOVBCJVPAFPLKLXDGCIUVTXJXPNSS
          }
                }, ".BUTTON", ".ThisButton");
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
            }
            CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
        }
        [ConsoleCommand("xskin")]
        private void FZZFZCCJBBEJYVXWEAZKBGIIKBGZJIRVPAIEWWXZLXHQ(ConsoleSystem.Arg args)
        {
            if (args.Player() == null || args.Player().IsAdmin)
            {
                string item = args.Args[1];
                if (!CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.ContainsKey(item))
                {
                    PrintWarning($"Не найдено предмета <{item}> в списке!");
                    return;
                }
                switch (args.Args[0])
                {
                    case "add":
                        {
                            ulong skinID = ulong.Parse(args.Args[2]);
                            if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Contains(skinID)) PrintWarning($"Скин <{skinID}> уже есть в списке скинов предмета <{item}>!");
                            else
                            {
                                CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Add(skinID);
                                PrintWarning($"Скин <{skinID}> успешно добавлен в список скинов предмета <{item}>!");
                                if (!KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ)
                                {
                                  //  if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.MNRSVJOCUDSDTEZCSJQDFSMIIIXFDCYAGSGKEPLOALPUSDXD) ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/{skinID}/128", $"{skinID}" + 152);
                                  //  else ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/v1/08102261/{skinID}/150", $"{skinID}" + 152);
                                }
                            }
                            break;
                        }
                    case "remove":
                        {
                            ulong skinID = ulong.Parse(args.Args[2]);
                            if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Contains(skinID))
                            {
                                CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Remove(skinID);
                                PrintWarning($"Скин <{skinID}> успешно удален из списка скинов предмета <{item}>!");
                            }
                            else PrintWarning($"Скин <{skinID}> не найден в списке скинов предмета <{item}>!");
                            break;
                        }
                    case "remove_ui":
                        {
                            ulong skinID = ulong.Parse(args.Args[2]);
                            if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Contains(skinID))
                            {
                                BasePlayer player = args.Player();
                                if (player != null)
                                {
                                    CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Remove(skinID);
                                    if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.GUI.FVLKXLUTAJJEHHHPHNGJYTIUNFHDDJFAUHQKEANDVXDJW) SkinGUI(player, item, int.Parse(args.Args[3]));
                                    EffectNetwork.Send(new Effect("assets/bundled/prefabs/fx/weapons/survey_charge/survey_charge_stick.prefab", player, 0, new Vector3(), new Vector3()), player.Connection);
                                    PrintWarning($"Скин <{skinID}> успешно удален из списка скинов предмета <{item}>!");
                                }
                            }
                            else PrintWarning($"Скин <{skinID}> не найден в списке скинов предмета <{item}>!");
                            break;
                        }
                    case "list":
                        {
                            if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Count == 0)
                            {
                                PrintWarning($"Список скинов предмета <{item}> пуст!");
                                return;
                            }
                            string AMZEBFAXOSDFIAMJWVKICEDBCIGMAENEGRPZFIUXWM = $"Список скинов предмета <{item}>:\n";
                            foreach (ulong skinID in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item]) AMZEBFAXOSDFIAMJWVKICEDBCIGMAENEGRPZFIUXWM += $"\n{skinID}";
                            PrintWarning(AMZEBFAXOSDFIAMJWVKICEDBCIGMAENEGRPZFIUXWM);
                            break;
                        }
                    case "clearlist":
                        {
                            if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Count == 0)
                            {
                                PrintWarning($"Список скинов предмета <{item}> уже пуст!");
                                return;
                            }
                            else
                            {
                                CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Clear();
                                PrintWarning($"Список скинов предмета <{item}> успешно очищен!");
                            }
                            break;
                        }
                }
                Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XSkinMenu/Skins", CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ);
            }
        }
        private void OnServerInitialized()
        {
            if (Interface.Oxide.DataFileSystem.ExistsDatafile("XDataSystem/XSkinMenu/Friends")) StoredDataFriends = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, bool>>("XDataSystem/XSkinMenu/Friends");
            if (Interface.Oxide.DataFileSystem.ExistsDatafile("XDataSystem/XSkinMenu/Skins")) CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<string, List<ulong>>>("XDataSystem/XSkinMenu/Skins");
            if (!KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ && GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO == null && ImageLibrary) GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = ServerMgr.Instance.StartCoroutine(PUKDXMXTCGYCSCCLAZNLUOYDLVDMKRQOTEZYTZLYNLR());
            foreach (var IJRHHUPNDLJMVLXWCOOFIJNAAQXWFBJACVQVQYSRHCPC in KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ) foreach (var item in IJRHHUPNDLJMVLXWCOOFIJNAAQXWFBJACVQVQYSRHCPC.Value)
                {
                    string key = item.Key;
                    AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC.Add(key, item.Value);
                    NZWATWLXMHBWXLMHBPQMDQCJJRLVUYKYKIABLJJRKCP.Add(key, ItemManager.FindItemDefinition(key).itemid);
                }
            foreach (var item in ItemManager.GetItemDefinitions())
            {
                var prefab = item.GetComponent<ItemModDeployable>()?.entityPrefab?.resourcePath;
                if (string.IsNullOrEmpty(prefab)) continue;
                var ATDUFSJWVVGEWJXCTZNWJEYZRKMDOANMQZCIYNAUR = Utility.GetFileNameWithoutExtension(prefab);
                if (!string.IsNullOrEmpty(ATDUFSJWVVGEWJXCTZNWJEYZRKMDOANMQZCIYNAUR) && !SJZMTPHGBYIPVWUEDVFFIUIUNXGPDFYTFBLPAERXWIZ.ContainsKey(ATDUFSJWVVGEWJXCTZNWJEYZRKMDOANMQZCIYNAUR)) SJZMTPHGBYIPVWUEDVFFIUIUNXGPDFYTFBLPAERXWIZ.Add(ATDUFSJWVVGEWJXCTZNWJEYZRKMDOANMQZCIYNAUR, item.shortname);
            }
            GenerateItems();
            BasePlayer.activePlayerList.ToList().ForEach(OnPlayerConnected);
            timer.Every(180, () => BasePlayer.activePlayerList.ToList().ForEach(SaveData));
            timer.Every(200, () => Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XSkinMenu/Friends", StoredDataFriends));
            InitializeLang();
            permission.RegisterPermission("xskinmenu.use", this);
            permission.RegisterPermission("xskinmenu.setting", this);
            permission.RegisterPermission("xskinmenu.craft", this);
            permission.RegisterPermission("xskinmenu.entity", this);
            permission.RegisterPermission("xskinmenu.inventory", this);
            permission.RegisterPermission("xskinmenu.give", this);
            permission.RegisterPermission("xskinmenu.skinchange", this);
            if (!KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ && !ImageLibrary) timer.Once(2, () => {
                PrintError("У вас не установлен плагин - ImageLibrary!");
                Interface.Oxide.UnloadPlugin(Name);
            });
        }
        private readonly Dictionary<string, string> SJZMTPHGBYIPVWUEDVFFIUIUNXGPDFYTFBLPAERXWIZ = new Dictionary<string, string>();
        private void SetSkinItem(BasePlayer player, string item, ulong skin)
        {
            foreach (var i in player.inventory.FindItemIDs(ItemManager.FindItemDefinition(item).itemid))
            {
                if (i.skin == skin || KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.LKTPDHVCCPHCZABDUQLGIHHKZWXHAIAKSRKYLLCVAWF.Contains(i.skin)) continue;
                if (CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT.ContainsKey(skin))
                {
                    i.UseItem();
                    Item DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB = ItemManager.CreateByName(CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT[skin]);
                    DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.condition = i.condition;
                    DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.maxCondition = i.maxCondition;
                    if (i.contents != null) foreach (var module in i.contents.itemList)
                        {
                            Item content = ItemManager.CreateByName(module.info.shortname, module.amount);
                            content.condition = module.condition;
                            content.maxCondition = module.maxCondition;
                            content.MoveToContainer(DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.contents);
                        }
                    player.GiveItem(DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB);
                }
                else
                {
                    i.skin = skin;
                    i.MarkDirty();
                    BaseEntity entity = i.GetHeldEntity();
                    if (entity != null)
                    {
                        entity.skinID = skin;
                        entity.SendNetworkUpdate();
                    }
                }
            }
        }
        private IEnumerator TYORIPERWJZQQVXVCZTJJTXMSZHDAYEYSBQCRIBSMD()
        {
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0, AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ = 0, ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY = 0;
            PrintWarning("Началась перезагрузка изображений категорий!");
            foreach (var category in KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ)
            {
                //foreach (var item in category.Value)
                //{
                //    //ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getimage/{item.Key}/128", item.Key + 150);
                //    NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC++;
                //    yield
                //    return CoroutineEx.waitForSeconds(0.3f);
                //}
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.ZVLIVWOCIOYVLTFZPRXTDAVJEBFCWZHRLMXHSOIXJL) PrintWarning($"[ Перезагружена категория {QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO} из {KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ.Count} ] - [ Перезагружено изображений категории {NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC} из {category.Value.Count} ]");
                NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0;
            }
            PrintWarning("Началась перезагрузка изображений скинов!");
            foreach (var item in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ)
            {
                foreach (var skin in item.Value)
                {
                //    if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.MNRSVJOCUDSDTEZCSJQDFSMIIIXFDCYAGSGKEPLOALPUSDXD) ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/{skin}/128", $"{skin}" + 152);
                //    else ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/v1/08102261/{skin}/150", $"{skin}" + 152);
                    ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY++;
                    yield
                    return CoroutineEx.waitForSeconds(0.3f);
                }
                AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ++;
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.ZVLIVWOCIOYVLTFZPRXTDAVJEBFCWZHRLMXHSOIXJL) PrintWarning($"[ Перезагружен предмет {item.Key} | {AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ} из {CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.Count} ] - [ Перезагружено изображений скинов {ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY} из {item.Value.Count} ]");
                ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY = 0;
            }
            PrintWarning("\n-----------------------------\n" + "     Перезагрузка всех изображений завершена.\n" + "-----------------------------");
            GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = null;
            yield
            return 0;
        }
        private void SkinGUI(BasePlayer player, string item, int AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE = 0)
        {
            CuiHelper.DestroyUi(player, ".SkinGUI");
            CuiElementContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU = new CuiElementContainer();
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.475 0",
          AnchorMax = "0.8 1"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".SGUI", ".SkinGUI");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0",
          OffsetMin = "-215 0",
          OffsetMax = "-140 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".SkinGUI", ".PagesGUI");
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0;
            ulong AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[item];
            int itemid = NZWATWLXMHBWXLMHBPQMDQCJJRLVUYKYKIABLJJRKCP[item];
            foreach (var skin in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Skip(AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE * 24))
            {
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"{-497.5 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 100)} {123.25 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 100)}",
            OffsetMax = $"{-402.5 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 100)} {218.25 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 100)}"
          },
                    Image = {
            Color = "0 0 0 0",
            Material = "assets/icons/greyout.mat"
          }
                }, ".SkinGUI", ".Skin");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".Skin",
                    Name = "Btn",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD == skin ? "0.5 1 0.5 1" : "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "-0.045 -0.045", AnchorMax = "1.045 1.045"
            }
          }
                });
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".Skin",
                    Components = {
                        new CuiImageComponent {
                          ItemId = itemid, SkinId = skin
                        },
                        new CuiRectTransformComponent {
                          AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "7.5 7.5", OffsetMax = "-7.5 -7.5"
                        }
                      }
                });
               
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1",
            OffsetMax = "0 0"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = $"skin_c setskin {item} {skin} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}"
          },
                    Text = {
            Text = ""
          }
                }, ".Skin");
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.KLFZUNMILDQWDKTQWPSSPAXMLUNDJSDFFLUHSWMG && player.IsAdmin) GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "1 0",
            AnchorMax = "1 0",
            OffsetMin = "-20 5",
            OffsetMax = "-5 20"
          },
                    Button = {
            Color = "1 1 1 0.7507126",
            Sprite = "assets/icons/clear.png",
            Command = $"xskin remove_ui {item} {skin} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}"
          },
                    Text = {
            Text = ""
          }
                }, ".Skin");
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
                if (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO == 6)
                {
                    QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0;
                    NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC++;
                    if (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC == 4) break;
                }
            }
            string EFVCIJBPYEDFBQVPRQAYLOCTTMSMTWKSDTAPKNKX = $"page.xskinmenu skin back {item} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}";
            string HIRZCBPRABULFPPDCJWROVBTKBIQGEEGCUDGLTQLC = $"page.xskinmenu skin next {item} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}";
            bool SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR = AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE != 0;
            bool NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX = CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Count > ((AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1) * 24);
            var OFLIXTRSDHRXADLHXPOTIKEJERQHFCPQBHIHUMNLOKOFT = AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1;
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
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
            }, ".PagesGUI", ".PagesGUI" + ".PS");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
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
            }, ".PagesGUI" + ".PS", "LabelPage");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Text = {
          Text = lang.GetMessage("PAGE", this, player.UserIDString) + " " + (AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1).ToString(),
          FontSize = 25,
          Font = "robotocondensed-regular.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = "0.929 0.882 0.847 0.8"
        }
            }, "LabelPage", "ThisLabel");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.15 0",
          AnchorMax = "0.29 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, ".PagesGUI" + ".PS", ".PagesGUI" + ".PS.L");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? EFVCIJBPYEDFBQVPRQAYLOCTTMSMTWKSDTAPKNKX : ""
        },
                Text = {
          Text = "<b><</b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, ".PagesGUI" + ".PS.L");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.71 0",
          AnchorMax = "0.85 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, ".PagesGUI" + ".PS", ".PagesGUI" + ".PS.R");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? HIRZCBPRABULFPPDCJWROVBTKBIQGEEGCUDGLTQLC : ""
        },
                Text = {
          Text = "<b>></b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, ".PagesGUI" + ".PS.R");
            CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
        }
        private void OnPlayerConnected(BasePlayer player)
        {
            if (player.IsReceivingSnapshot)
            {
                NextTick(() => OnPlayerConnected(player));
                return;
            }
            LoadData(player);
        }
        private void ItemGUI(BasePlayer player, string category, int AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE = 0)
        {
            CuiHelper.DestroyUi(player, ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY");
            CuiHelper.DestroyUi(player, ".SkinGUI");
            CuiHelper.DestroyUi(player, ".ItemGUI");
            CuiElementContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU = new CuiElementContainer();
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.475 0",
          AnchorMax = "0.8 1"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".SGUI", ".ItemGUI");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0",
          OffsetMin = "-215 0",
          OffsetMax = "-140 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".ItemGUI", ".PagesGUI");
            var IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins;
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0, VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP = 0;
            foreach (var item in KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ[category].Skip(AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE * 24))
            {
                string key = item.Key;
                bool FFTIHHEXNNSKQDPXDNKZJHCKHWLWRORWARQYTCTU = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.ContainsKey(key);
                ulong skinID = FFTIHHEXNNSKQDPXDNKZJHCKHWLWRORWARQYTCTU ? IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW[key] : 0;
                bool AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD = skinID != 0;
                int itemid = NZWATWLXMHBWXLMHBPQMDQCJJRLVUYKYKIABLJJRKCP[key];
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"{-497.5 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 100)} {123.25 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 100)}",
            OffsetMax = $"{-402.5 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 100)} {218.25 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 100)}"
          },
                    Image = {
            Color = "0 0 0 0"
          }
                }, ".ItemGUI", ".Item");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".Item",
                    Name = "Btn",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
            },
            new CuiRectTransformComponent {
              AnchorMin = "-0.045 -0.045", AnchorMax = "1.045 1.045"
            }
          }
                });
                    GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".Item",
                    Components = {
            new CuiImageComponent {
              ItemId = itemid, SkinId = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.GUI.XRTLAZSXPLMQXSERPRDIKZRWLHACNAQZYJHQJRIGI ? skinID : 0
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "7.5 7.5", OffsetMax = "-7.5 -7.5"
            }
          }
                });
                
                if (CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.ContainsKey(key) && CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[key].Count != 0 && FFTIHHEXNNSKQDPXDNKZJHCKHWLWRORWARQYTCTU)
                {
                    GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "0 0",
              AnchorMax = "1 1",
              OffsetMax = "0 0"
            },
                        Button = {
              Color = "0 0 0 0",
              Command = $"skin_c skin {key}"
            },
                        Text = {
              Text = ""
            }
                    }, ".Item");
                    if (AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD) GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "1 0",
              AnchorMax = "1 0",
              OffsetMin = "-20 5",
              OffsetMax = "-5 20"
            },
                        Button = {
              Color = "1 1 1 0.75",
              Sprite = "assets/icons/clear.png",
              Command = $"skin_c clear {key} {VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP} {category} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}"
            },
                        Text = {
              Text = ""
            }
                    }, ".Item", $".I + {VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP}");
                }
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
                VFYRQSSUTPNEWSTUALWRYYQLJVVJZBAXFPNQNCQJQRVP++;
                if (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO == 6)
                {
                    QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0;
                    NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC++;
                    if (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC == 4) break;
                }
            }
            string EFVCIJBPYEDFBQVPRQAYLOCTTMSMTWKSDTAPKNKX = $"page.xskinmenu item back {category} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}";
            string HIRZCBPRABULFPPDCJWROVBTKBIQGEEGCUDGLTQLC = $"page.xskinmenu item next {category} {AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE}";
            bool SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR = AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE != 0;
            bool NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ[category].Count > ((AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1) * 24);
            var OFLIXTRSDHRXADLHXPOTIKEJERQHFCPQBHIHUMNLOKOFT = AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1;
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
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
            }, ".PagesGUI", ".PagesGUI" + ".PS");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
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
            }, ".PagesGUI" + ".PS", "LabelPage");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Text = {
          Text = lang.GetMessage("PAGE", this, player.UserIDString) + " " + (AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1).ToString(),
          FontSize = 25,
          Font = "robotocondensed-regular.ttf",
          Align = TextAnchor.MiddleCenter,
          Color = "0.929 0.882 0.847 0.8"
        }
            }, "LabelPage", "ThisLabel");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.15 0",
          AnchorMax = "0.29 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, ".PagesGUI" + ".PS", ".PagesGUI" + ".PS.L");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? EFVCIJBPYEDFBQVPRQAYLOCTTMSMTWKSDTAPKNKX : ""
        },
                Text = {
          Text = "<b><</b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = SUPHXDKLIDOGOMHXPASZLVXOILMJSJSKPUCGDDEEFUWARWFR ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, ".PagesGUI" + ".PS.L");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.71 0",
          AnchorMax = "0.85 1",
          OffsetMin = $"0 0",
          OffsetMax = "-0 -0"
        },
                Image = {
          Color = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
        }
            }, ".PagesGUI" + ".PS", ".PagesGUI" + ".PS.R");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Button = {
          Color = "0 0 0 0",
          Command = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? HIRZCBPRABULFPPDCJWROVBTKBIQGEEGCUDGLTQLC : ""
        },
                Text = {
          Text = "<b>></b>",
          Font = "robotocondensed-bold.ttf",
          FontSize = 35,
          Align = TextAnchor.MiddleCenter,
          Color = NDPSCJXXAYMRATYLDRUJATMWOURZXWMFULFFDSNKFJCFRMEAX ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
        }
            }, ".PagesGUI" + ".PS.R");
            CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
        }
        [ConsoleCommand("page.xskinmenu")]
        private void SUODIYWZHWBKQGQQDJNRMPSDCJLLFTXYYVCEFLSZX(ConsoleSystem.Arg args)
        {
            BasePlayer player = args.Player();
            Effect QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = new Effect("assets/bundled/prefabs/fx/notice/loot.drag.grab.fx.prefab", player, 0, new Vector3(), new Vector3());
            string item = args.Args[2];
            int AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE = int.Parse(args.Args[3]);
            switch (args.Args[0])
            {
                case "item":
                    {
                        switch (args.Args[1])
                        {
                            case "next":
                                {
                                    ItemGUI(player, item, AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1);
                                    break;
                                }
                            case "back":
                                {
                                    ItemGUI(player, item, AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE - 1);
                                    break;
                                }
                        }
                        break;
                    }
                case "skin":
                    {
                        switch (args.Args[1])
                        {
                            case "next":
                                {
                                    SkinGUI(player, item, AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE + 1);
                                    break;
                                }
                            case "back":
                                {
                                    SkinGUI(player, item, AILXMSNYYJMTWRXCIBKWIFYVVKYNQDATPZIYRMUE - 1);
                                    break;
                                }
                        }
                        break;
                    }
            }
            EffectNetwork.Send(QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO, player.Connection);
        }
        private IEnumerator PUKDXMXTCGYCSCCLAZNLUOYDLVDMKRQOTEZYTZLYNLR()
        {
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0, AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ = 0, ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY = 0;
            PrintWarning("Началась загрузка изображений категорий!");
            foreach (var category in KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ)
            {
                foreach (var item in category.Value)
                {
                    if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.HasImage || !ImageLibrary.Call<bool>("HasImage", item.Key + 150))
                    {
                      // ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getimage/{item.Key}/128", item.Key + 150);
                        NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC++;
                        yield
                        return CoroutineEx.waitForSeconds(0.3f);
                    }
                    else yield
                    return CoroutineEx.waitForSeconds(0.03f);
                }
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.QIDMWRRRRVTTDDORRBEMSWDDXETYNRZJOBXMVSUNA) PrintWarning($"[ Загружена категория {QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO} из {KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ.Count} ] - [ Загружено изображений категории {NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC} из {category.Value.Count} ]");
                NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0;
            }
            PrintWarning("Началась загрузка изображений скинов!");
            foreach (var item in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ)
            {
                foreach (var skin in item.Value)
                {
                    if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.HasImage || !ImageLibrary.Call<bool>("HasImage", $"{skin}" + 152))
                    {
                      //  if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.MNRSVJOCUDSDTEZCSJQDFSMIIIXFDCYAGSGKEPLOALPUSDXD) ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/{skin}/128", $"{skin}" + 152);
                     //   else ImageLibrary.Call("AddImage", $"https://api.skyplugins.ru/api/getskin/v1/08102261/{skin}/150", $"{skin}" + 152);
                        ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY++;
                        yield
                        return CoroutineEx.waitForSeconds(0.3f);
                    }
                    else yield
                    return CoroutineEx.waitForSeconds(0.03f);
                }
                AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ++;
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.QIDMWRRRRVTTDDORRBEMSWDDXETYNRZJOBXMVSUNA) PrintWarning($"[ Загружен предмет {item.Key} | {AZPQQFNYVWSEANPYPSVXGVEZYRRLRWZZMKGUDTHAYCQ} из {CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.Count} ] - [ Загружено изображений скинов {ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY} из {item.Value.Count} ]");
                ABXJCQTHVOCFVPSZOCGYXTRPGVUWLUZDFLZWUHIADRDYIBY = 0;
            }
            PrintWarning("\n-----------------------------\n" + "     Загрузка всех изображений завершена.\n" + "     Изображения которые не были загружены, это означает что они уже есть в дате ImageLibrary.\n" + "     А если они сломаные, то вам нужно их перезагрузить командой skinimage_reload или очистить дату ImageLibrary.\n" + "-----------------------------");
            GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = null;
            yield
            return 0;
        }
        public Dictionary<string, string> XTEECDASVLBJYRVJPCCUAIUJTEXIZLVGGYKLURTGYVUSZKQHN = new Dictionary<string, string>
        {
            ["snowmobiletomaha"] = "tomahasnowmobile"
        };
        private void OnNewSave()
        {
            timer.Once(20, () => {
                PrintError("--------------------------------------------\n" + "Внимание! Обнаружен вайп! Все изображения принудительно будут перезагружены! Не выключайте сервер и не перезагружайте плагин!\n" + "Внимание! Обнаружен вайп! Все изображения принудительно будут перезагружены! Не выключайте сервер и не перезагружайте плагин!\n" + "Внимание! Обнаружен вайп! Все изображения принудительно будут перезагружены! Не выключайте сервер и не перезагружайте плагин!\n" + "--------------------------------------------");
                if (GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO != null)
                {
                    ServerMgr.Instance.StopCoroutine(GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO);
                    GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = null;
                }
                NextTick(() => {
                    if (GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO == null) GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = ServerMgr.Instance.StartCoroutine(TYORIPERWJZQQVXVCZTJJTXMSZHDAYEYSBQCRIBSMD());
                });
            });
        }
        private void AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY");
            CuiElementContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU = new CuiElementContainer();
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "0.9985 0.99"
        },
                Image = {
          Color = "0 0 0 0.35",
          Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
        }
            }, ".GUIS", ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Color = "0 0 0 0",
          Close = ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY"
        },
                Text = {
          Text = ""
        }
            }, ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = "0.5 0.5",
          OffsetMin = "-200 -175",
          OffsetMax = "200 175"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, ".AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY", ".SGUIM");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
            {
                Parent = ".SGUIM",
                Name = "ButtonImage",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "PanelButtonsImage"), Color = "1 1 1 1"
          },
          /*new CuiOutlineComponent { Color = "0.6 0.6 0.6 1", Distance = "-0.25 0.25" },*/ new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 -5", OffsetMax = "5 5"
          }
        }
            });
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 1",
          AnchorMax = "1 1",
          OffsetMin = "0 -35",
          OffsetMax = "0 -5"
        },
                Text = {
          Text = lang.GetMessage("SETTINGS", this, player.UserIDString),
          Align = TextAnchor.MiddleCenter,
          Font = "robotocondensed-bold.ttf",
          FontSize = 22,
          Color = "0.8507126 0.8507126 0.8507126 0.9"
        }
            }, ".SGUIM");
            var IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID];
            Dictionary<string, bool> setting = new Dictionary<string, bool>
            {
                ["inventory"] = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI,
                ["entity"] = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY,
                ["craft"] = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ,
                ["clear"] = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT,
                ["give"] = IZTKOPMEHDBBDFDJNBSAWSVEMLBCEXWYQWJRNVNADW.PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT,
                ["friends"] = StoredDataFriends[player.userID]
            };
            int QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0, NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC = 0;
            foreach (var AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD in setting)
            {
                string FUKOZJNSWOWJHANQIOTYCSSYEDMCXWNJDQGZVGMKCNRMJTSBF = AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Value ? "0.8 0.8 0.8 1" : "0.7 0.7 0.7 0.3";
                string PLBJVMCLJWWKVAAMFRTOVBCJVPAFPLKLXDGCIUVTXJXPNSS = AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Value ? "0.7507126 0.7507126 0.7507126 1" : "0.5507126 0.5507126 0.5507126 0.25";
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0.5 0.5",
            AnchorMax = "0.5 0.5",
            OffsetMin = $"{-188 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 192)} {65 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 55)}",
            OffsetMax = $"{-5 + (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO * 192)} {105 - (NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC * 55)}"
          },
                    Image = {
            Color = "0 0 0 0"
          }
                }, ".SGUIM", ".SM");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                {
                    Parent = ".SM",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = FUKOZJNSWOWJHANQIOTYCSSYEDMCXWNJDQGZVGMKCNRMJTSBF
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-8 -5", OffsetMax = "8 5"
            }
          }
                });
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0.2",
            AnchorMax = "0 0.8",
            OffsetMin = "10 0",
            OffsetMax = "35 0"
          },
                    Button = {
            Color = AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Value ? KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP.LIZKWJUEPPANFLHSPMPKPEEKSFELJJZXZVPNRKLOFSDQTC : KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP.PWLYQBKBGDPRRFIVGQCNJWTAEBBEWANQQCPPXKIVP,
            Sprite = AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Value ? KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP.SEYNCUZEIMGNTXZWATZPJOVNSOKNHXIXANHNYYFFDJSDSKPK : KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP.NROHSMDJKUNKLXKDINFQMXCOTMAVRUIYAWTFTQIBEDODRU,
            Command = $"skin_s {AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Key}"
          },
                    Text = {
            Text = ""
          }
                }, ".SM");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0.2 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = lang.GetMessage(AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Key, this, player.UserIDString),
            Align = TextAnchor.MiddleCenter,
            Font = "robotocondensed-regular.ttf",
            FontSize = 12,
            Color = PLBJVMCLJWWKVAAMFRTOVBCJVPAFPLKLXDGCIUVTXJXPNSS
          }
                }, ".SM");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = $"skin_s {AIMWWRVGKHDHWXWBPYAJPWFHUFVFPTHFWHVDICGNQTLMD.Key}"
          },
                    Text = {
            Text = ""
          }
                }, ".SM");
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.UGSGVLZIJIDPESLNKSIGKOKIAYDBVUEKYOGGVLWCLZXPV)
                {
                    GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiElement
                    {
                        Parent = ".SGUIM",
                        Name = ".Clear",
                        Components = {
              new CuiRawImageComponent {
                Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = FUKOZJNSWOWJHANQIOTYCSSYEDMCXWNJDQGZVGMKCNRMJTSBF
              },
              new CuiRectTransformComponent {
                AnchorMin = "0.5 0", AnchorMax = "0.5 0", OffsetMin = "-90 40", OffsetMax = "90 95"
              }
            }
                    });
                    GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiButton
                    {
                        RectTransform = {
              AnchorMin = "0.1 0",
              AnchorMax = "0.9 1"
            },
                        Button = {
              Color = "0 0 0 0",
              Command = "skin_c clearall"
            },
                        Text = {
              Text = lang.GetMessage("CLEARALL", this, player.UserIDString),
              Align = TextAnchor.MiddleCenter,
              FontSize = 13,
              Font = "robotocondensed-bold.ttf",
              Color = "0.75 0.95 0.41 1"
            }
                    }, ".Clear");
                }
                QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO++;
                if (QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO == 2)
                {
                    QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = 0;
                    NPKWKFYAXOWONIUXIUROPYGECGXVNBGCBIWGLNPWC++;
                }
            }
            CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
        }
        private void Unload()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                SaveData(player);
                CuiHelper.DestroyUi(player, ".GUIS");
            }
            if (GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO != null) ServerMgr.Instance.StopCoroutine(GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO);
            Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XSkinMenu/Friends", StoredDataFriends);
        }
        public Dictionary<ulong, string> CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT = new Dictionary<ulong, string>
        {
            [10180] = "hazmatsuit.spacesuit",
            [10201] = "hazmatsuit.nomadsuit",
            [10207] = "hazmatsuit.arcticsuit",
            [13070] = "rifle.ak.ice",
            [13068] = "snowmobiletomaha",
            [10189] = "door.hinged.industrial.a",
            [13050] = "skullspikes.candles",
            [13051] = "skullspikes.pumpkin",
            [13052] = "skull.trophy.jar",
            [13053] = "skull.trophy.jar2",
            [13054] = "skull.trophy.table",
            [13056] = "sled.xmas",
            [13057] = "discofloor.largetiles",
            [10198] = "factorydoor",
            [10211] = "hazmatsuit.lumberjack",
            [10212] = "metal.facemask.hockey",
            [10213] = "torch.torch.skull",
            [10214] = "mace.baseballbat",
            [13075] = "concretehatchet",
            [13074] = "concretepickaxe",
            [13073] = "lumberjack.hatchet",
            [13072] = "lumberjack.pickaxe",
            [10215] = "chair.icethrone",
            [10217] = "metal.facemask.icemask",
            [10216] = "metal.plate.torso.icevest",
        };
        [PluginReference] private Plugin ImageLibrary;
        private void OnItemAddedToContainer(ItemContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU, Item item)
        {
            if (item == null) return;
            if (GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU?.playerOwner != null)
            {
                BasePlayer player = GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.playerOwner;
                if (player == null || player.IsNpc || !player.userID.IsSteamId() || player.IsSleeping()) return;
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.IJJBOKZQOOZTSLKOTOZAJZSZLRRQLXADLSHQNLWJNMUEEMMAK && !AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC.ContainsKey(item.info.shortname)) return;
                if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.give") || !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC.ContainsKey(player.userID) || !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(item.info.shortname)) return;
                if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT) SetSkinCraftGive(player, item);
            }
        }
        private void OnPlayerRespawned(BasePlayer player)
        {
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.ZIMGQIRKQWSJEQOVIZDTBIRQNWFNVZFRFSYRRECYZDUAQDH) timer.Once(2, () => {
                if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC.ContainsKey(player.userID))
                {
                    var IJRHHUPNDLJMVLXWCOOFIJNAAQXWFBJACVQVQYSRHCPC = player?.inventory?.AllItems();
                    if (IJRHHUPNDLJMVLXWCOOFIJNAAQXWFBJACVQVQYSRHCPC != null) foreach (Item item in IJRHHUPNDLJMVLXWCOOFIJNAAQXWFBJACVQVQYSRHCPC) if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(item.info.shortname)) SetSkinCraftGive(player, item);
                }
            });
        }
        private void InitializeLang()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["ERRORSKIN"] = "THE SKIN YOU CHOSE CAN BE CHANGED ONLY IN THE INVENTORY OR WHEN CRAFTING!",
                ["CLEARALL"] = "RESET ALL SELECTED SKINS",
                ["NOPERM"] = "No permissions!",
                ["SETTINGS"] = "SETTINGS",
                ["PAGE"] = "PAGE:",
                ["weapon"] = "WEAPON",
                ["construction"] = "CONSTRUCTION",
                ["item"] = "ITEM",
                ["attire"] = "ATTIRE",
                ["tool"] = "TOOL",
                ["transport"] = "TRANSPORT",
                ["inventory"] = "CHANGE SKIN IN INVENTORY",
                ["entity"] = "CHANGE SKIN ON OBJECTS",
                ["craft"] = "CHANGE SKIN WHEN CRAFTING",
                ["clear"] = "CHANGE SKIN WHEN DELETING",
                ["give"] = "SKIN CHANGE WHEN DROP IN INVENTORY",
                ["friends"] = "ALLOW FRIENDS TO CHANGE YOUR SKINS"
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["ERRORSKIN"] = "ВЫБРАННЫЙ ВАМИ СКИН МОЖНО ИЗМЕНИТЬ ТОЛЬКО В ИНВЕНТАРЕ ИЛИ ПРИ КРАФТЕ!",
                ["CLEARALL"] = "СБРОСИТЬ ВСЕ ВЫБРАННЫЕ СКИНЫ",
                ["NOPERM"] = "Недостаточно прав!",
                ["SETTINGS"] = "НАСТРОЙКИ",
                ["PAGE"] = "СТРАНИЦА:",
                ["weapon"] = "ОРУЖИЕ",
                ["construction"] = "СТРОИТЕЛЬСТВО",
                ["item"] = "ПРЕДМЕТЫ",
                ["attire"] = "ОДЕЖДА",
                ["tool"] = "ИНСТРУМЕНТЫ",
                ["transport"] = "ТРАНСПОРТ",
                ["inventory"] = "ПОМЕНЯТЬ СКИН В ИНВЕНТАРЕ",
                ["entity"] = "ПОМЕНЯТЬ СКИН НА ПРЕДМЕТАХ",
                ["craft"] = "ПОМЕНЯТЬ СКИН ПРИ КРАФТЕ",
                ["clear"] = "ПОМЕНЯТЬ СКИН ПРИ УДАЛЕНИИ",
                ["give"] = "ПОМЕНЯТЬ СКИН ПРИ ПОПАДАНИИ В ИНВЕНТАРЬ",
                ["friends"] = "РАЗРЕШИТЬ ДРУЗЬЯМ ИЗМЕНЯТЬ ВАШИ СКИНЫ"
            }, this, "ru");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["ERRORSKIN"] = "ВИБРАНИЙ ВАМИ СК?Н МОЖНА ЗМ?НИТИ Т?ЛЬКИ В ?НВЕНТАР? АБО ПРИ КРАФТ?!",
                ["CLEARALL"] = "СКИНУТИ ВС? ОБРАН? СК?НИ",
                ["NOPERM"] = "Недостатньо прав!",
                ["SETTINGS"] = "НАСТРОЙКА",
                ["PAGE"] = "СТОР?НКА:",
                ["weapon"] = "ЗБРОЯ",
                ["construction"] = "БУД?ВНИЦТВО",
                ["item"] = "ПРЕДМЕТИ",
                ["attire"] = "ОДЯГ",
                ["tool"] = "?НСТРУМЕНТИ",
                ["transport"] = "ТРАНСПОРТ",
                ["inventory"] = "ЗМ?НИТИ СК?Н В ?НВЕНТАР?",
                ["entity"] = "ЗМ?НИТИ СК?Н НА ПРЕДМЕТАХ",
                ["craft"] = "ЗМ?НИТИ СК?Н ПРИ КРАФТ?",
                ["clear"] = "ЗМ?НИТИ СК?Н ПРИ ВИДАЛЕНН?",
                ["give"] = "ЗМ?НИТИ СК?Н ПРИ ПОТРАПЛЯНН? В ?НВЕНТАР",
                ["friends"] = "ДОЗВОЛИТИ ДРУЗЯМ ЗМ?НЮВАТИ ВАШ? СК?НИ"
            }, this, "uk");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["ERRORSKIN"] = "?LA SKIN QUE ELIGIO SE PUEDE CAMBIAR SOLO EN EL INVENTARIO O AL CREAR!",
                ["CLEARALL"] = "RESTABLECER TODAS LAS SKINS SELECCIONADAS",
                ["NOPERM"] = "?No tienes permisos!",
                ["SETTINGS"] = "AJUSTES",
                ["PAGE"] = "PAGINA:",
                ["weapon"] = "ARMAS",
                ["construction"] = "CONSTRUCCION",
                ["item"] = "ITEMS",
                ["attire"] = "ATUENDOS",
                ["tool"] = "HERRAMIENTAS",
                ["transport"] = "TRANSPORTES",
                ["inventory"] = "CAMBIO DE SKIN EN INVENTARIO",
                ["entity"] = "CAMBIAR LA SKIN DE LOS OBJETOS",
                ["craft"] = "CAMBIA DE SKIN AL CREAR",
                ["clear"] = "CAMBIAR LA SKIN AL ELIMINAR",
                ["give"] = "CAMBIO DE SKIN AL CAER EN EL INVENTARIO",
                ["friends"] = "PERMITE QUE AMIGOS CAMBIEN TUS SKINS"
            }, this, "es-ES");
        }
        private Dictionary<ulong, bool> StoredDataFriends = new Dictionary<ulong, bool>();
        [ChatCommand("skinentity")]
        private void MIIQCCGBQMOWXCKEWOFENEBKEASERHBYEBFSFYUGP(BasePlayer player)
        {
            if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.entity"))
            {
                SendReply(player, lang.GetMessage("NOPERM", this, player.UserIDString));
                return;
            }
            if (CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY)
            {
                RaycastHit BHRBJYKBNDZVQGRWTHCBIKZVCGDWWXFTLNZJFUWCZZOR;
                if (!Physics.Raycast(player.eyes.HeadRay(), out BHRBJYKBNDZVQGRWTHCBIKZVCGDWWXFTLNZJFUWCZZOR, 3f, LayerMask.GetMask("Deployed", "Construction", "Prevent Building"))) return;
                var entity = BHRBJYKBNDZVQGRWTHCBIKZVCGDWWXFTLNZJFUWCZZOR.GetEntity();
                if (entity == null) return;
                if (entity is BaseVehicle)
                {
                    var SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR = entity as BaseVehicle;
                    var shortname = SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR.ShortPrefabName;
                    if (!CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(shortname)) return;
                    SetSkinTransport(player, SQSHXCLHEYCPDSLHYZQGERDNXMMCWCDVSZHERSTWPJQRKHR, shortname);
                }
                else if (entity.OwnerID == player.userID || player.currentTeam != 0 && player.Team.members.Contains(entity.OwnerID) && StoredDataFriends.ContainsKey(entity.OwnerID) && StoredDataFriends[entity.OwnerID])
                    if (SJZMTPHGBYIPVWUEDVFFIUIUNXGPDFYTFBLPAERXWIZ.ContainsKey(entity.ShortPrefabName))
                    {
                        var shortname = SJZMTPHGBYIPVWUEDVFFIUIUNXGPDFYTFBLPAERXWIZ[entity.ShortPrefabName];
                        if (!CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(shortname)) return;
                        SetSkinEntity(player, entity, shortname);
                    }
            }
        }
        protected override void LoadDefaultConfig() => KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM = SkinConfig.GetNewConfiguration();
        private void cmdOpenGUI(BasePlayer player)
        {
            GUI(player);
        }
        public Dictionary<string, ulong> AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC = new Dictionary<string, ulong>();
        [ConsoleCommand("skin_s")]
        private void MDDHMOVTFSKTQIGYLBKCJIKQRWXSZYTYPGRYHXNDIY(ConsoleSystem.Arg args)
        {
            BasePlayer player = args.Player();
            if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.setting"))
            {
                SendReply(player, lang.GetMessage("NOPERM", this, player.UserIDString));
                return;
            }
            if (VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL.ContainsKey(player))
                if (VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player].Subtract(DateTime.Now).TotalSeconds >= 0) return;
            Effect QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO = new Effect("assets/bundled/prefabs/fx/notice/loot.drag.grab.fx.prefab", player, 0, new Vector3(), new Vector3());
            switch (args.Args[0])
            {
                case "open":
                    {
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "inventory":
                    {
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI = !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI;
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "entity":
                    {
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY = !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY;
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "craft":
                    {
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ = !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ;
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "clear":
                    {
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT = !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT;
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "give":
                    {
                        CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT = !CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT;
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
                case "friends":
                    {
                        StoredDataFriends[player.userID] = !StoredDataFriends[player.userID];
                        AVCZBULSLMOBVHRCILIKPKJODERAOOXJWHCPSEKQGXCHQY(player);
                        break;
                    }
            }
            EffectNetwork.Send(QGUSYAKNVCAHYZEHKUUCIWMUGBIMPEQRLDPEGJXO, player.Connection);
            VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL[player] = DateTime.Now.AddSeconds(0.5f);
        }
        private Dictionary<BasePlayer, DateTime> VUHLUXTLQWJUFPKNYVUZRXUITDHOYYUZFGDQSROYOTL = new Dictionary<BasePlayer, DateTime>();
        private Dictionary<ulong, DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL> CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC = new Dictionary<ulong, DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL>();
        private void OnItemCraftFinished(ItemCraftTask BKYJYSGRLNTNRSPZCNUXOAVBIQWMKDPGYYFOXSYZZXQKDZ, Item item, ItemCrafter crafter)
        {
            if (BKYJYSGRLNTNRSPZCNUXOAVBIQWMKDPGYYFOXSYZZXQKDZ.skinID == 0)
            {
                BasePlayer player = crafter.owner;
                if (!CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins.ContainsKey(item.info.shortname) || !permission.UserHasPermission(player.UserIDString, "xskinmenu.craft")) return;
                if (!CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT && CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ) SetSkinCraftGive(player, item);
            }
        }
        private void JNLKWLHMTWNXESMPQRCTHYMEJQIQONGTKGBDFLAH(BasePlayer player, string EYPWSOXCAPWAHWTGHYNPTMACKOUXQKLYJXSNUHWRAWEZARQ)
        {
            player.SendConsoleCommand("gametip.showgametip", EYPWSOXCAPWAHWTGHYNPTMACKOUXQKLYJXSNUHWRAWEZARQ);
            timer.Once(5f, () => player.SendConsoleCommand("gametip.hidegametip"));
        }
        private Coroutine GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO;
        private SkinConfig KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM;
        private void SetSkinCraftGive(BasePlayer player, Item item)
        {
            if (player == null || item == null) return;
            string shortname = item.info.shortname;
            ulong skin = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[shortname];
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.IJJBOKZQOOZTSLKOTOZAJZSZLRRQLXADLSHQNLWJNMUEEMMAK && !AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC.ContainsKey(shortname)) return;
            if (item.skin == skin || KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.LKTPDHVCCPHCZABDUQLGIHHKZWXHAIAKSRKYLLCVAWF.Contains(item.skin)) return;
            if (CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT.ContainsKey(skin))
            {
                item.UseItem();
                Item DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB = ItemManager.CreateByName(CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT[skin]);
                DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.condition = item.condition;
                DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.maxCondition = item.maxCondition;
                if (item.contents != null) foreach (var module in item.contents.itemList)
                    {
                        Item content = ItemManager.CreateByName(module.info.shortname, module.amount);
                        content.condition = module.condition;
                        content.maxCondition = module.maxCondition;
                        content.MoveToContainer(DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB.contents);
                    }
                player.GiveItem(DBDGNTKFOLZYAEYWJRCVAOKUKEEYDIJZUTQMTZBKUTFTB);
            }
            else
            {
                item.skin = skin;
                item.MarkDirty();
                BaseEntity entity = item.GetHeldEntity();
                if (entity != null)
                {
                    entity.skinID = skin;
                    entity.SendNetworkUpdate();
                }
            }
        }
        public Dictionary<string, List<ulong>> CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ = new Dictionary<string, List<ulong>>();
        private void LoadData(BasePlayer player)
        {
            ulong userID = player.userID;
            if (Interface.Oxide.DataFileSystem.ExistsDatafile($"XDataSystem/XSkinMenu/UserSettings/{userID}"))
            {
                var DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL = Interface.Oxide.DataFileSystem.ReadObject<DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL>($"XDataSystem/XSkinMenu/UserSettings/{userID}");
                CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[userID] = DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL ?? KRDYKUEBMVNIVOPMXTVLDZLQFACAUROUFHNYFLUWQ();
            }
            else CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[userID] = KRDYKUEBMVNIVOPMXTVLDZLQFACAUROUFHNYFLUWQ();
            if (!StoredDataFriends.ContainsKey(userID)) StoredDataFriends.Add(userID, KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.DUWGEOJEAFYSCGDGQJYYVFWSDOXBQLJEDPZBRIIOD);
            var list = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[userID].Skins;
            foreach (var skin in CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ)
            {
                string key = skin.Key;
                if (!list.ContainsKey(key)) list.Add(key, AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC.ContainsKey(key) ? AZRBVOVNAERHWZCVOEQYFJDHHQYKZCJWIECHMUBJKGLJIC[key] : 0);
            }
            CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[userID].Skins = list;
        }
        public Dictionary<string, int> NZWATWLXMHBWXLMHBPQMDQCJJRLVUYKYKIABLJJRKCP = new Dictionary<string, int>();
        private object OnItemSkinChange(int skinID, Item item, StorageContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU, BasePlayer player)
        {
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.MPQLPTVMDGVJFWIYNODSRPLFSYWGULQVMSLOKJFLOLK && KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.LKTPDHVCCPHCZABDUQLGIHHKZWXHAIAKSRKYLLCVAWF.Contains(item.skin))
            {
                EffectNetwork.Send(new Effect("assets/bundled/prefabs/fx/invite_notice.prefab", player, 0, new Vector3(), new Vector3()), player.Connection);
                return false;
            }
            else return null;
        }
        private class SkinConfig
        {
            internal class GeneralSetting
            {
                [JsonProperty("Сгенерировать/Проверять и добавлять новые скины принятые разработчиками или сделаные для твич дропсов")] public bool NIGEFFZENNFWXMQCKQCNXCLOLKWRFYBBBCWBKHPPZFKXDDEYS;
                [JsonProperty("Сгенерировать/Проверять и добавлять новые скины добавленные разработчиками [ К примеру скин на хазмат ]")] public bool HTZBCKWRSUIHZPLDVUQPRDBNNSROLHGXYYRICZZLET;
                [JsonProperty("Отображать кнопку для удаления всех скинов")] public bool UGSGVLZIJIDPESLNKSIGKOKIAYDBVUEKYOGGVLWCLZXPV;
                [JsonProperty("Распространять черный список скинов на ремонтный верстак")] public bool MPQLPTVMDGVJFWIYNODSRPLFSYWGULQVMSLOKJFLOLK;
                [JsonProperty("Включить кнопку для удаления скинов через UI")] public bool KLFZUNMILDQWDKTQWPSSPAXMLUNDJSDFFLUHSWMG;
                [JsonProperty("Запретить менять скин предмета которого нет в конфиге")] public bool IJJBOKZQOOZTSLKOTOZAJZSZLRRQLXADLSHQNLWJNMUEEMMAK;
                [JsonProperty("Изменять скины на предметы после респавна игрока")] public bool ZIMGQIRKQWSJEQOVIZDTBIRQNWFNVZFRFSYRRECYZDUAQDH;
                [JsonProperty("Логи в консоль загрузки изображений")] public bool QIDMWRRRRVTTDDORRBEMSWDDXETYNRZJOBXMVSUNA;
                [JsonProperty("Логи в консоль перезагрузки изображений")] public bool ZVLIVWOCIOYVLTFZPRXTDAVJEBFCWZHRLMXHSOIXJL;
                [JsonProperty("Черный список скинов которые нельзя изменить. [ Например: огненные перчатки, огненный топор ]]")] public List<ulong> LKTPDHVCCPHCZABDUQLGIHHKZWXHAIAKSRKYLLCVAWF = new List<ulong>();
            }
            [JsonProperty("Меню настроек")] public MenuSSetting EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP = new MenuSSetting();
            [JsonProperty("Настройка категорий - [ Шортнейм предмета | Дефолтный скин предмета ]")] public Dictionary<string, Dictionary<string, ulong>> TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ = new Dictionary<string, Dictionary<string, ulong>>();
            [JsonProperty("Настройки GUI")] public GUISetting GUI = new GUISetting();
            internal class PlayerSetting
            {
                [JsonProperty("Смена скинов в инвентаре")] public bool ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI;
                [JsonProperty("Смена скинов на предметах")] public bool TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY;
                [JsonProperty("Смена скинов при крафте")] public bool QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ;
                [JsonProperty("Смена скинов в инвентаре после удаления")] public bool JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT;
                [JsonProperty("Смена скинов при попадании в инвентарь")] public bool PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT;
                [JsonProperty("Разрешить друзьям изменять скины")] public bool DUWGEOJEAFYSCGDGQJYYVFWSDOXBQLJEDPZBRIIOD;
            }
            [JsonProperty("Общие настройки")] public GeneralSetting Setting = new GeneralSetting();
            [JsonProperty("Настройки игрока по умолчанию")] public PlayerSetting DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB = new PlayerSetting();
            internal class GUISetting
            {
                [JsonProperty("Обновлять UI страницу после выбора скина")] public bool FCDOFSXVAOXBBUJGDFRSZBVVGPKKPQQDSGHEZABIMYH;
                [JsonProperty("Обновлять UI страницу после удаления скина")] public bool FVLKXLUTAJJEHHHPHNGJYTIUNFHDDJFAUHQKEANDVXDJW;
                [JsonProperty("Отображать выбранные скины на главной")] public bool XRTLAZSXPLMQXSERPRDIKZRWLHACNAQZYJHQJRIGI;
            }
            internal class MenuSSetting
            {
                [JsonProperty("Иконка включенного параметра")] public string SEYNCUZEIMGNTXZWATZPJOVNSOKNHXIXANHNYYFFDJSDSKPK;
                [JsonProperty("Иконка вылюченного параметра")] public string NROHSMDJKUNKLXKDINFQMXCOTMAVRUIYAWTFTQIBEDODRU;
                [JsonProperty("Цвет включенного параметра")] public string LIZKWJUEPPANFLHSPMPKPEEKSFELJJZXZVPNRKLOFSDQTC;
                [JsonProperty("Цвет вылюченного параметра")] public string PWLYQBKBGDPRRFIVGQCNJWTAEBBEWANQQCPPXKIVP;
            }
            [JsonProperty("Настройки API/изображений")] public APISetting API = new APISetting();
            internal class APISetting
            {
                [JsonProperty("Какое API использовать для загрузки изображений - [ True - обычные изображения из Steam Workshop (практически все существующие скины) | False - красивые изображения (все принятые скины разработчиками, а также половина из Steam Workshop) ]")] public bool MNRSVJOCUDSDTEZCSJQDFSMIIIXFDCYAGSGKEPLOALPUSDXD;
                [JsonProperty("Отключить проверку на наличие изображения в дате ImageLibrary (изображение будет повторно загружаться после каждой загрузки/перезагрузки плагина) - Если вы не знаете/понимаете как работают изображения в ImageLibrary или у вас проблемы с изображениями, то полезно отключить проверку (true)")] public bool HasImage;
                [JsonProperty("Отображать изображения предметов и скинов методами игры. ( Установите false если хотите использовать API и плагин ImageLibrary )")] public bool JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ = true;
            }
            public static SkinConfig GetNewConfiguration()
            {
                return new SkinConfig
                {
                    API = new APISetting
                    {
                        JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ = true,
                        MNRSVJOCUDSDTEZCSJQDFSMIIIXFDCYAGSGKEPLOALPUSDXD = false,
                        HasImage = false
                    },
                    Setting = new GeneralSetting
                    {
                        NIGEFFZENNFWXMQCKQCNXCLOLKWRFYBBBCWBKHPPZFKXDDEYS = true,
                        HTZBCKWRSUIHZPLDVUQPRDBNNSROLHGXYYRICZZLET = false,
                        UGSGVLZIJIDPESLNKSIGKOKIAYDBVUEKYOGGVLWCLZXPV = true,
                        MPQLPTVMDGVJFWIYNODSRPLFSYWGULQVMSLOKJFLOLK = true,
                        KLFZUNMILDQWDKTQWPSSPAXMLUNDJSDFFLUHSWMG = true,
                        IJJBOKZQOOZTSLKOTOZAJZSZLRRQLXADLSHQNLWJNMUEEMMAK = false,
                        ZIMGQIRKQWSJEQOVIZDTBIRQNWFNVZFRFSYRRECYZDUAQDH = true,
                        QIDMWRRRRVTTDDORRBEMSWDDXETYNRZJOBXMVSUNA = true,
                        ZVLIVWOCIOYVLTFZPRXTDAVJEBFCWZHRLMXHSOIXJL = true,
                        LKTPDHVCCPHCZABDUQLGIHHKZWXHAIAKSRKYLLCVAWF = new List<ulong> {
              1742796979,
              841106268
            }
                    },
                    DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB = new PlayerSetting
                    {
                        ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI = true,
                        TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY = true,
                        QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ = true,
                        JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT = true,
                        PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT = true,
                        DUWGEOJEAFYSCGDGQJYYVFWSDOXBQLJEDPZBRIIOD = true
                    },
                    GUI = new GUISetting
                    {
                        FCDOFSXVAOXBBUJGDFRSZBVVGPKKPQQDSGHEZABIMYH = true,
                        FVLKXLUTAJJEHHHPHNGJYTIUNFHDDJFAUHQKEANDVXDJW = true,
                        XRTLAZSXPLMQXSERPRDIKZRWLHACNAQZYJHQJRIGI = false,
                    },
                    EKYHQKOHXFADDJQHKOBTPXJHPCSIOQFMCGGPXPQP = new MenuSSetting
                    {
                        SEYNCUZEIMGNTXZWATZPJOVNSOKNHXIXANHNYYFFDJSDSKPK = "assets/icons/check.png",
                        NROHSMDJKUNKLXKDINFQMXCOTMAVRUIYAWTFTQIBEDODRU = "assets/icons/close.png",
                        LIZKWJUEPPANFLHSPMPKPEEKSFELJJZXZVPNRKLOFSDQTC = "0.53 0.77 0.35 0.8",
                        PWLYQBKBGDPRRFIVGQCNJWTAEBBEWANQQCPPXKIVP = "1 0.4 0.35 0.8"
                    },
                    TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ = new Dictionary<string, Dictionary<string, ulong>>
                    {
                        ["weapon"] = new Dictionary<string,
                    ulong>
                        {
                            ["gun.water"] = 0,
                            ["pistol.revolver"] = 0,
                            ["pistol.semiauto"] = 0,
                            ["pistol.python"] = 0,
                            ["pistol.eoka"] = 0,
                            ["shotgun.waterpipe"] = 0,
                            ["shotgun.double"] = 0,
                            ["shotgun.pump"] = 0,
                            ["bow.hunting"] = 0,
                            ["crossbow"] = 0,
                            ["grenade.f1"] = 0,
                            ["smg.2"] = 0,
                            ["smg.thompson"] = 0,
                            ["smg.mp5"] = 0,
                            ["rifle.ak"] = 0,
                            ["rifle.lr300"] = 0,
                            ["lmg.m249"] = 0,
                            ["rocket.launcher"] = 0,
                            ["rifle.semiauto"] = 0,
                            ["rifle.m39"] = 0,
                            ["rifle.bolt"] = 0,
                            ["rifle.l96"] = 0,
                            ["longsword"] = 0,
                            ["salvaged.sword"] = 0,
                            ["mace"] = 0,
                            ["knife.combat"] = 0,
                            ["bone.club"] = 0,
                            ["knife.bone"] = 0
                        },
                        ["construction"] = new Dictionary<string,
                    ulong>
                        {
                            ["wall.frame.garagedoor"] = 0,
                            ["door.double.hinged.toptier"] = 0,
                            ["door.double.hinged.metal"] = 0,
                            ["door.double.hinged.wood"] = 0,
                            ["door.hinged.toptier"] = 0,
                            ["door.hinged.metal"] = 0,
                            ["door.hinged.wood"] = 0,
                            ["barricade.concrete"] = 0,
                            ["barricade.sandbags"] = 0
                        },
                        ["item"] = new Dictionary<string,
                    ulong>
                        {
                            ["locker"] = 0,
                            ["vending.machine"] = 0,
                            ["fridge"] = 0,
                            ["furnace"] = 0,
                            ["table"] = 0,
                            ["chair"] = 0,
                            ["box.wooden.large"] = 0,
                            ["box.wooden"] = 0,
                            ["rug.bear"] = 0,
                            ["rug"] = 0,
                            ["sleepingbag"] = 0,
                            ["water.purifier"] = 0,
                            ["target.reactive"] = 0,
                            ["sled"] = 0,
                            ["discofloor"] = 0,
                            ["paddlingpool"] = 0,
                            ["innertube"] = 0,
                            ["boogieboard"] = 0,
                            ["beachtowel"] = 0,
                            ["beachparasol"] = 0,
                            ["beachchair"] = 0,
                            ["skull.trophy"] = 0,
                            ["skullspikes"] = 0,
                            ["skylantern"] = 0
                        },
                        ["attire"] = new Dictionary<string,
                    ulong>
                        {
                            ["metal.facemask"] = 0,
                            ["coffeecan.helmet"] = 0,
                            ["riot.helmet"] = 0,
                            ["bucket.helmet"] = 0,
                            ["deer.skull.mask"] = 0,
                            ["twitch.headset"] = 0,
                            ["sunglasses"] = 0,
                            ["mask.balaclava"] = 0,
                            ["burlap.headwrap"] = 0,
                            ["hat.miner"] = 0,
                            ["hat.beenie"] = 0,
                            ["hat.boonie"] = 0,
                            ["hat.cap"] = 0,
                            ["mask.bandana"] = 0,
                            ["metal.plate.torso"] = 0,
                            ["roadsign.jacket"] = 0,
                            ["roadsign.kilt"] = 0,
                            ["roadsign.gloves"] = 0,
                            ["burlap.gloves"] = 0,
                            ["attire.hide.poncho"] = 0,
                            ["jacket.snow"] = 0,
                            ["jacket"] = 0,
                            ["tshirt.long"] = 0,
                            ["hazmatsuit"] = 0,
                            ["hoodie"] = 0,
                            ["shirt.collared"] = 0,
                            ["tshirt"] = 0,
                            ["burlap.shirt"] = 0,
                            ["attire.hide.vest"] = 0,
                            ["shirt.tanktop"] = 0,
                            ["attire.hide.helterneck"] = 0,
                            ["pants"] = 0,
                            ["burlap.trousers"] = 0,
                            ["pants.shorts"] = 0,
                            ["attire.hide.pants"] = 0,
                            ["attire.hide.skirt"] = 0,
                            ["shoes.boots"] = 0,
                            ["burlap.shoes"] = 0,
                            ["attire.hide.boots"] = 0
                        },
                        ["tool"] = new Dictionary<string,
                    ulong>
                        {
                            ["fun.guitar"] = 0,
                            ["jackhammer"] = 0,
                            ["icepick.salvaged"] = 0,
                            ["pickaxe"] = 0,
                            ["stone.pickaxe"] = 0,
                            ["rock"] = 0,
                            ["hatchet"] = 0,
                            ["stonehatchet"] = 0,
                            ["explosive.satchel"] = 0,
                            ["hammer"] = 0,
                            ["torch"] = 0
                        },
                        ["transport"] = new Dictionary<string,
                    ulong>
                        {
                            ["snowmobile"] = 0
                        }
                    }
                };
            }
        }
        [ConsoleCommand("skinimage_stop")]
        private void LACCJMGVHXMGFVKAHBGCQYFPTNYQIJEQVBVYJCADCVHQUN(ConsoleSystem.Arg args)
        {
            if (args.Player() == null || args.Player().IsAdmin)
            {
                if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.API.JVFZCRMYPAGWELDQSJDYRISGBREWIVCVAMFCYYYLGDCQ)
                {
                    PrintError("COMMAND_OFF");
                    return;
                }
                if (GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO == null) PrintWarning("На данный момент нет активной загрузки/перезагрузки изображений!");
                else
                {
                    ServerMgr.Instance.StopCoroutine(GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO);
                    GQTZWHJGUJRLXGEXFGQSSLPSXJCQHFVYMIGDCHKPBRRAO = null;
                    PrintWarning("Текущая загрузка/перезагрузка изображений прервана!");
                }
            }
        }
        protected override void SaveConfig() => Config.WriteObject(KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM);
        private DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL KRDYKUEBMVNIVOPMXTVLDZLQFACAUROUFHNYFLUWQ()
        {
            DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA = new DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL();
            OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA.ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI;
            OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA.TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY;
            OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA.QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ;
            OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA.JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT;
            OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA.PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT = KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.DTVQIQISMRCUJXYDCQRHNPVUPNGCOHAKUHCDWMFGSXYRB.PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT;
            return OPTZRQGYCUBDYYLMQQTXLVSFASTKRRNFCJMBLXQFWXYREYZA;
        }
        private void GUI(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".GUIS");
            CuiElementContainer GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU = new CuiElementContainer();
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
            {
                CursorEnabled = true,
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0.9",
          OffsetMin = "172 0",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, "MS_UI", ".GUIS");
            GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
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
            }, ".GUIS", ".SGUI");
            CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
            KJBSHYAYIPAVOZQNOCXMXLOEWCXBOGJRMDXKOETFRH(player);
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ.Count != 0) ItemGUI(player, KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.TMNRHVCVUKMULLGAQRNSGSHZOBWCBJUXMZWKWPIHQNTFSRQ.ElementAt(0).Key);
            if (!permission.UserHasPermission(player.UserIDString, "xskinmenu.use"))
            {
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Image = {
            Color = "0 0 0 0.25",
            Material = "assets/content/ui/uibackgroundblur.mat"
          }
                }, ".GUIS", "Label");
                GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU.Add(new CuiLabel
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1"
          },
                    Text = {
            Text = lang.GetMessage("NOPERM", this, player.UserIDString),
            FontSize = 50,
            Font = "robotocondensed-bold.ttf",
            Align = TextAnchor.MiddleCenter,
            Color = "0.929 0.882 0.847 0.8"
          }
                }, "Label", "ThisLabel");
                CuiHelper.AddUi(player, GGYNWDKMCCCTZWBSZACUPSOGYWBXSFOCXXNKWNPYFIU);
            }
        }
        internal class DPYMRSKKQLRFTKBXQMUFNTRKSPFCKMIHNFJTNNYYFL
        {
            [JsonProperty("Смена скинов в инвентаре")] public bool ZOGXCXNAENDGYZTKQPIMPWDBJGCTYBHWKCDMDXUOLWFJMCI;
            [JsonProperty("Смена скинов на предметах")] public bool TJPDIEFDKFOWVUBDFGVWWGHTVUBSQUOGYLZPLEOFWZBXIY;
            [JsonProperty("Смена скинов при крафте")] public bool QUCDFGMUMBWHODMNQQHYKUMSBSQZWEKKXBKYORJALRMOOWZ;
            [JsonProperty("Смена скинов в инвентаре после удаления")] public bool JMLGBZIVIJBMQMXIRMKMSOZYHGMSHXDFSNQJTDIXT;
            [JsonProperty("Смена скинов при попадании в инвентарь")] public bool PEPWJZTEWCLNKVNMZUNPOKFWTDWNONDNSEYUJKXMYCBBT;
            [JsonProperty("Скины")] public Dictionary<string, ulong> Skins = new Dictionary<string, ulong>();
        }
        private void GenerateItems()
        {
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.NIGEFFZENNFWXMQCKQCNXCLOLKWRFYBBBCWBKHPPZFKXDDEYS) foreach (var pair in Rust.Workshop.Approved.All)
                {
                    if (pair.Value == null || pair.Value.Skinnable == null) continue;
                    ulong skinID = pair.Value.WorkshopdId;
                    string item = pair.Value.Skinnable.ItemName;
                    if (item.Contains("lr300")) item = "rifle.lr300";
                    if (!CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.ContainsKey(item)) CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.Add(item, new List<ulong>());
                    if (!CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Contains(skinID)) CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item].Add(skinID);
                }
            if (KHJHGZVJWUAABMESZONTYOABVYVBQBUPEPZVGZZWDCM.Setting.HTZBCKWRSUIHZPLDVUQPRDBNNSROLHGXYYRICZZLET) foreach (ItemDefinition item in ItemManager.GetItemDefinitions())
                {
                    foreach (var skinID in ItemSkinDirectory.ForItem(item).Select(skin => Convert.ToUInt64(skin.id)))
                    {
                        if (!CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.ContainsKey(item.shortname)) CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ.Add(item.shortname, new List<ulong>());
                        if (!CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item.shortname].Contains(skinID)) CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ[item.shortname].Add(skinID);
                    }
                }
            Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XSkinMenu/Skins", CBFXKIRCMVJVGIMHDTSVALWMNILAPRPVCOYTSYRHJRDJ);
        }
        private void SetSkinEntity(BasePlayer player, BaseEntity entity, string shortname)
        {
            ulong skin = CAVTZTMNNDRXZYRRQFMRBKOYMUVHHWKYLJGTHNOFLGLC[player.userID].Skins[shortname];
            if (skin == entity.skinID || skin == 0) return;
            if (CKCEIPACYCBWOSBWLCJQVHYEHGALXQSNWNCDZFAZPT.ContainsKey(skin))
            {
                JNLKWLHMTWNXESMPQRCTHYMEJQIQONGTKGBDFLAH(player, lang.GetMessage("ERRORSKIN", this, player.UserIDString));
                return;
            }
            entity.skinID = skin;
            entity.SendNetworkUpdate();
            Effect.server.Run("assets/prefabs/deployable/repair bench/effects/skinchange_spraypaint.prefab", entity.transform.localPosition);
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