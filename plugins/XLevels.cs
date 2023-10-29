/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */  using System;
using UnityEngine;
using System.Collections.Generic;
using Oxide.Core;
using ConVar;
using System.Linq;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using Newtonsoft.Json;
namespace Oxide.Plugins
{
    [Info("XLevels", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class XLevels : RustPlugin
    {
        [PluginReference] private Plugin ImageLibrary, StackSizeController, BetterChat, MenuSystem;
        private void LoadData(BasePlayer player)
        {
            var Inventory = Interface.Oxide.DataFileSystem.ReadObject<List<InvItems>>($"XDataSystem/XLevels/InvItems/{player.userID}");
            if (!KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST.ContainsKey(player.userID)) KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST.Add(player.userID, new List<InvItems>());
            KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID] = Inventory ?? new List<InvItems>();
        }
        [ConsoleCommand("x_levels")]
        private void GTUMXVSGYBFPUZRCKNOCALBKLQUPYEJCWHXYRLTWDFDUBFBC(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            OpenLevels(player);
        }
        [ConsoleCommand("level_give_xp")]
        private void NWSGGXURKBHADITSDSNCSKYTSZUIHIFOSUKIQVQKCHHKMVAX(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null || player.IsAdmin)
            {
                ulong steamID = Convert.ToUInt64(arg.Args[0]);
                BasePlayer KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB = BasePlayer.FindByID(steamID);
                float xp = Convert.ToSingle(arg.Args[1]);
                if (KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB != null) ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB, xp);
                else PrintWarning($"Ошибка выдачи XP игроку - [ {steamID} ] - возможно он оффлайн!");
            }
        }
        private void BXNNADCXZOHCMJBVSIIXLBHCDZKCOGWZXZFKSBRRILR(BasePlayer player, string command, string[] args)
        {
            MenuSystem?.Call("MS_CustomCMD", player, "level");
        }
        private void Top(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".LevelO_Overlay");
            CuiHelper.DestroyUi(player, ".ExchangeInfo");
            CuiHelper.DestroyUi(player, ".Inventory_Items");
            CuiHelper.DestroyUi(player, ".Top");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Level_Overlay", ".Top");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "300 130",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Top", ".TopMain");
            int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = 0, SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN = 0, WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX = 1;
            foreach (var i in StoredData.OrderByDescending(h => h.Value.XP).OrderByDescending(h => h.Value.Level).Take(18))
            {
                var KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB = covalence.Players.FindPlayerById(i.Key.ToString());
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = $"{-522 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 380)} {100 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 55)}",
                                                OffsetMax = $"{-177 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 380)} {150 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 55)}"
                                        },
                    Image = {
                                                Color = "0.20 0.20 0.24 0.8",
                                                Material = "assets/content/ui/uibackgroundblur.mat"
                                        }
                }, ".TopMain", ".TopList");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMax = "0 0"
                                        },
                    Text = {
                                                Text = string.Format(lang.GetMessage("Level_Top", this, player.UserIDString), WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX, i.Value.Level, Math.Round(i.Value.XP), KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB.Name),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-regular.ttf",
                                                FontSize = 16,
                                                Color = "1 1 1 0.75"
                                        }
                }, ".TopList");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = "-170 -22.5",
                                                OffsetMax = "-125 22.5"
                                        },
                    Image = {
                                                Color = "0.376 0.384 0.459 0.5"
                                        }
                }, ".TopList", ".TopAvatar");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".TopAvatar",
                    Components = {
                                                new CuiRawImageComponent {
                                                        FadeIn = 0.5f, Png = (string) ImageLibrary.Call("GetImage", KEGHXMQJERPUTUQGFSDKFDXPLVGUIXYWCAQAOYHB.Id)
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "2.5 2.5", OffsetMax = "-2.5 -2.5"
                                                }
                                        }
                });
                SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN++;
                WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX++;
                if (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN == 9)
                {
                    SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN = 0;
                    WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG++;
                }
            }
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private void IHQYGOUNRZXAQKJASAISSIEMDQDQQRPAJATVJMWAMJ(BasePlayer player, string message) => Player.Reply(player, message, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.SteamID);
        private void YCFUHRRYICZPADDUPLEWZKWRQROQGDIFIAGKYWVYZT(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".Level_Overlay");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            bool CJRWJDGXJCQTFWHGRWBFVBGSTSSDPRGKCUDTGSBSZXZVIC = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ;
            bool EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PDMQOEMFNMWEHLWHDBBUASEODNYWGOFVVKALCPSPIQE;
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                CursorEnabled = true,
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "172 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, "MS_UI", ".Level_Overlay");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".Level_Overlay", ".LevelO_Overlay");
            bool PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF = permission.UserHasPermission(player.UserIDString, "xlevels.battlepass");
            if (EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI)
                if (PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF)
                {
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.20 0.20 0.24 0.8"
                                                },
                        RectTransform = {
                                                        AnchorMin = "0.5 0",
                                                        AnchorMax = "0.5 0",
                                                        OffsetMin = "-100 125",
                                                        OffsetMax = "100 165"
                                                },
                    }, ".LevelO_Overlay", "1");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.376 0.384 0.459 0.5"
                                                },
                        RectTransform = {
                                                        AnchorMin = "1 0",
                                                        AnchorMax = "1 1",
                                                        OffsetMin = "-195 5",
                                                        OffsetMax = "-5 -5"
                                                }
                    }, "1", "UnderInfoBlock");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.20 0.20 0.24 0"
                                                },
                        RectTransform = {
                                                        AnchorMin = "1 0",
                                                        AnchorMax = "1 1",
                                                        OffsetMin = "-140 2.5",
                                                        OffsetMax = "0 -2.5"
                                                }
                    }, "UnderInfoBlock", "UnderInfoTextBlock");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 1"
                                                },
                        Text = {
                                                        Text = lang.GetMessage("VIPYES", this, player.UserIDString),
                                                        Align = TextAnchor.MiddleCenter,
                                                        FontSize = 12,
                                                        Font = "robotocondensed-regular.ttf",
                                                        Color = "0.75 0.95 0.41 1"
                                                }
                    }, "UnderInfoTextBlock", "UnderInfoText");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "0 1",
                                                        OffsetMin = "15 5",
                                                        OffsetMax = "55 -5"
                                                },
                        Image = {
                                                        Png = (string) ImageLibrary.Call("GetImage", "BattlepassImage"),
                                                        Color = "1 1 1 1",
                                                        Material = "assets/icons/greyout.mat"
                                                }
                    }, "1", "UnderInfoImage");
                }
                else
                {
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.20 0.20 0.24 0.8"
                                                },
                        RectTransform = {
                                                        AnchorMin = "0.5 0",
                                                        AnchorMax = "0.5 0",
                                                        OffsetMin = "-100 125",
                                                        OffsetMax = "100 165"
                                                },
                    }, ".LevelO_Overlay", "1");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.376 0.384 0.459 0.5"
                                                },
                        RectTransform = {
                                                        AnchorMin = "1 0",
                                                        AnchorMax = "1 1",
                                                        OffsetMin = "-195 5",
                                                        OffsetMax = "-5 -5"
                                                }
                    }, "1", "UnderInfoBlock");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        Image = {
                                                        Color = "0.20 0.20 0.24 0"
                                                },
                        RectTransform = {
                                                        AnchorMin = "1 0",
                                                        AnchorMax = "1 1",
                                                        OffsetMin = "-140 2.5",
                                                        OffsetMax = "0 -2.5"
                                                }
                    }, "UnderInfoBlock", "UnderInfoTextBlock");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 1"
                                                },
                        Text = {
                                                        Text = lang.GetMessage("VIPNO", this, player.UserIDString),
                                                        Align = TextAnchor.MiddleCenter,
                                                        FontSize = 12,
                                                        Font = "robotocondensed-regular.ttf",
                                                        Color = "0.92 0.79 0.76 1"
                                                }
                    }, "UnderInfoTextBlock", "UnderInfoText");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "0 1",
                                                        OffsetMin = "15 5",
                                                        OffsetMax = "55 -5"
                                                },
                        Image = {
                                                        Png = (string) ImageLibrary.Call("GetImage", "BattlepassImage"),
                                                        Color = "1 1 1 1",
                                                        Material = "assets/icons/greyout.mat"
                                                }
                    }, "1", "UnderInfoImage");
                }
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
            YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "progress");
            AQTNVOFEGZJAIUUVFTMPQRZKSRCGRFVTLNDMOSKCFA(player);
        }
        private void YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(BasePlayer player, string UBHOIUZJQZALEHOAUSAOJMEUXNGSRFBQKMLKKTVMUMJUGMXZV)
        {
            bool CJRWJDGXJCQTFWHGRWBFVBGSTSSDPRGKCUDTGSBSZXZVIC = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ;
            bool YSCNMNDKJBBCTYBMWWELCGHGNRKKZTTREMZAHXNWF = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.XOOCLZLAOZDVGAXNGGKVDEVWTUZWPBQQSXJFVZQNTF;
            bool CGEGJAZKALOTBSKWZVDTLPHJXHZBFZIHGSDBBHHJKOSI = permission.UserHasPermission(player.UserIDString, "xlevels.top");
            string LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP = null;
            string TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG = null;
            string KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE = null;
            string SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT = null;
            string CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL = null;
            string OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA = null;
            string MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD = null;
            string PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM = null;
            int i = 0;
            if (UBHOIUZJQZALEHOAUSAOJMEUXNGSRFBQKMLKKTVMUMJUGMXZV == "progress")
            {
                LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP = "1 1 1 1";
                TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG = "1 1 1 0.2";
                KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE = "1 1 1 0.2";
                SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT = "1 1 1 0.2";
                CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL = "0.929 0.882 0.847 0.75";
                OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA = "0.7 0.7 0.7 0.2";
                MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD = "0.7 0.7 0.7 0.2";
                PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM = "0.7 0.7 0.7 0.2";
            }
            else if (UBHOIUZJQZALEHOAUSAOJMEUXNGSRFBQKMLKKTVMUMJUGMXZV == "inventory")
            {
                LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP = "1 1 1 0.2";
                TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG = "1 1 1 1";
                KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE = "1 1 1 0.2";
                SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT = "1 1 1 0.2";
                CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL = "0.7 0.7 0.7 0.2";
                OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA = "0.929 0.882 0.847 0.75";
                MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD = "0.7 0.7 0.7 0.2";
                PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM = "0.7 0.7 0.7 0.2";
            }
            else if (UBHOIUZJQZALEHOAUSAOJMEUXNGSRFBQKMLKKTVMUMJUGMXZV == "exchange")
            {
                LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP = "1 1 1 0.2";
                TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG = "1 1 1 0.2";
                KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE = "0.929 0.882 0.847 0.75";
                SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT = "1 1 1 0.2";
                CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL = "0.7 0.7 0.7 0.2";
                OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA = "0.7 0.7 0.7 0.2";
                MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD = "0.929 0.882 0.847 0.75";
                PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM = "0.7 0.7 0.7 0.2";
            }
            else if (UBHOIUZJQZALEHOAUSAOJMEUXNGSRFBQKMLKKTVMUMJUGMXZV == "top")
            {
                LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP = "1 1 1 0.2";
                TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG = "1 1 1 0.2";
                KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE = "1 1 1 0.2";
                SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT = "1 1 1 1";
                CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL = "0.7 0.7 0.7 0.2";
                OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA = "0.7 0.7 0.7 0.2";
                MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD = "0.7 0.7 0.7 0.2";
                PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM = "0.929 0.882 0.847 0.75";
            }
            CuiHelper.DestroyUi(player, ".Title");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 1",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 -60",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Level_Overlay", ".Title");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".Title", ".T_Title");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
            {
                Parent = ".T_Title",
                Name = "ProgressButton",
                Components = {
                                        new CuiRawImageComponent {
                                                Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = LKGPLXSTMYMZVJCBYFBDGNJOIUSNTIXXYGMXSLUBP
                                        },
                                        new CuiRectTransformComponent {
                                                AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "26 0", OffsetMax = "173 51"
                                        }
                                }
            });
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = "level progress"
                                },
                Text = {
                                        Text = lang.GetMessage("PROGRESS", this, player.UserIDString),
                                        Color = CVUCIJZNVKYCRFJAJHWRUZZFBSOUXOIMUSYERUNWTDGYAPL,
                                        Align = TextAnchor.MiddleCenter,
                                        FontSize = 20,
                                        Font = "robotocondensed-bold.ttf"
                                }
            }, "ProgressButton");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
            {
                Parent = ".T_Title",
                Name = "InventoryButton",
                Components = {
                                        new CuiRawImageComponent {
                                                Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = TTQCGYFILJQEWXARHQFFZEBPAOWEINKZOSTQYGOTHLWNG
                                        },
                                        new CuiRectTransformComponent {
                                                AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = "181 0", OffsetMax = "327 51"
                                        }
                                }
            });
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = "level inventory"
                                },
                Text = {
                                        Text = lang.GetMessage("OPENINV", this, player.UserIDString),
                                        Color = OVSZIBYDWPBQVFQGCLIZGEIOTAYQSAELHUFBWIDSTVIBSXA,
                                        Align = TextAnchor.MiddleCenter,
                                        FontSize = 20,
                                        Font = "robotocondensed-bold.ttf"
                                }
            }, "InventoryButton");
            if (CJRWJDGXJCQTFWHGRWBFVBGSTSSDPRGKCUDTGSBSZXZVIC)
            {
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".T_Title",
                    Name = "CouponButton",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = KOWAEDWJOPRBCRBAZYYQQEEKTACLXNHNIGEIIIJGDEDDYWE
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{336 + 155 * i} 0", OffsetMax = $"{481 + 154 * i} 51"
                                                }
                                        }
                });
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = "level exchangeinfo"
                                        },
                    Text = {
                                                Text = lang.GetMessage("COUPONS", this, player.UserIDString),
                                                Color = MAWOHMMKMEFIDIKVKQIAZPKTIPFLWHVWZKDSEQDVIVOSD,
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 20,
                                                Font = "robotocondensed-bold.ttf"
                                        }
                }, "CouponButton");
                i++;
            }
            if (CGEGJAZKALOTBSKWZVDTLPHJXHZBFZIHGSDBBHHJKOSI && YSCNMNDKJBBCTYBMWWELCGHGNRKKZTTREMZAHXNWF)
            {
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".T_Title",
                    Name = "Top",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = SGMYPPDFKMGDBKLBIDTVMSSQORNLAAMXWFSRBIYSCYYVBGFT
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "0 0", OffsetMin = $"{336 + 155 * i} 0", OffsetMax = $"{481 + 154 * i} 51"
                                                }
                                        }
                });
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = "level top"
                                        },
                    Text = {
                                                Text = lang.GetMessage("STATS", this, player.UserIDString),
                                                Color = PLLMRCOAOXPDGRGBNFIIJTERRUMNSDASPNAUAJQTIZVGCAJM,
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 20,
                                                Font = "robotocondensed-bold.ttf"
                                        }
                }, "Top");
                i++;
            }
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private void OnPluginLoaded(Plugin name)
        {
            if (name.Title == "Better Chat") Unsubscribe(nameof(OnPlayerChat));
        }
        private void OnPlayerDisconnected(BasePlayer player, string FBLRQHWMQUOGSLYKBSVEQAXNUWDKOKQGXWZZESVENXCAYNTX)
        {
            if (StoredData.ContainsKey(player.userID)) SaveData(player);
        }
        private void Unload()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList)
            {
                CuiHelper.DestroyUi(player, ".Panel_GUI");
                CuiHelper.DestroyUi(player, ".Level_Overlay");
                SaveData(player);
            }
            Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XLevels/XLevels", StoredData);
            MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT = null;
        }
        [ConsoleCommand("level")]
        private void XWSSEKSFVYADEPETUMWMZCOCJGGZSHQEGAVKHEOKBJKZFAU(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            Effect WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = new Effect("assets/bundled/prefabs/fx/notice/loot.drag.grab.fx.prefab", player, 0, new Vector3(), new Vector3());
            switch (arg.Args[0].ToLower())
            {
                case "page_lvl":
                    {
                        int Page = int.Parse(arg.Args[2]);
                        switch (arg.Args[1])
                        {
                            case "next":
                                {
                                    AQTNVOFEGZJAIUUVFTMPQRZKSRCGRFVTLNDMOSKCFA(player, Page + 1);
                                    break;
                                }
                            case "back":
                                {
                                    AQTNVOFEGZJAIUUVFTMPQRZKSRCGRFVTLNDMOSKCFA(player, Page - 1);
                                    break;
                                }
                        }
                        break;
                    }
                case "page_inv":
                    {
                        int Page = int.Parse(arg.Args[2]);
                        switch (arg.Args[1])
                        {
                            case "next":
                                {
                                    GBECBQVLVVDZIVUEAMNRGKFHOROYKBWUURDTLTEJAZRBTFUSW(player, Page + 1);
                                    break;
                                }
                            case "back":
                                {
                                    GBECBQVLVVDZIVUEAMNRGKFHOROYKBWUURDTLTEJAZRBTFUSW(player, Page - 1);
                                    break;
                                }
                        }
                        break;
                    }
                case "exchangeinfo":
                    {
                        if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ) return;
                        ExchangeInfo(player);
                        YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "exchange");
                        break;
                    }
                case "exchange":
                    {
                        if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ) return;
                        LEUYPMLOSVKMDRQZVHOUGUFATIXMPATRFEXJYLFUOTOUHURS(player, int.Parse(arg.Args[1]));
                        YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "exchange");
                        break;
                    }
                case "progress":
                    {
                        var progressbtn = "1 1 1 1";
                        YCFUHRRYICZPADDUPLEWZKWRQROQGDIFIAGKYWVYZT(player);
                        YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "progress");
                        break;
                    }
                case "inventory":
                    {
                        var progressbtn = "0 0 0 0";
                        GBECBQVLVVDZIVUEAMNRGKFHOROYKBWUURDTLTEJAZRBTFUSW(player);
                        YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "inventory");
                        break;
                    }
                case "top":
                    {
                        if (!permission.UserHasPermission(player.UserIDString, "xlevels.top") && !MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.XOOCLZLAOZDVGAXNGGKVDEVWTUZWPBQQSXJFVZQNTF) return;
                        Top(player);
                        YJLTRGSGPHMINFNDQDASEUTGZXTVTPFXGDYHEXWKNX(player, "top");
                        break;
                    }
            }
            EffectNetwork.Send(WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG, player.Connection);
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT = Config.ReadObject<LevelConfig>();
            }
            catch
            {
                PrintWarning("Ошибка чтения конфигурации! Создание дефолтной конфигурации!");
                LoadDefaultConfig();
            }
            SaveConfig();
        }
        private void InitializeLang()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Level"] = "LEVEL: {0} from {1}   |   XP: {2} from {3}{4}",
                ["Level_2"] = "LEVEL: {0} from {1}   |   XP: {2}{4}",
                ["Level_Top"] = "{0}.     LEVEL: {1}   |   XP: {2}\n{3}",
                ["LevelGUI"] = "LEVEL: {0}",
                ["Exchange"] = "EXCHANGE VALUES",
                ["ExchangeTrue"] = "You have successfully exchanged coupons for - {0} XP.",
                ["InventaryInfo"] = "You have {0} XP coupons in your inventory!",
                ["Info"] = "Level up and get rewards!",
                ["Take"] = "TAKE",
                ["TakeItem"] = "You have successfully received - {0} [{1} pcs].",
                ["LevelUP"] = "<color=#F65050FF>[AWARDS]</color> Level up!\n<size=12>Your level: <color=#F5DA81>{0}</color></size>",
                ["XP"] = "On you {0}XP",
                ["InventoryEmpty"] = "YOUR INVENTORY IS EMPTY!",
                ["PROGRESS"] = "PROGRESS",
                ["OPENINV"] = "INVENTORY",
                ["COUPONS"] = "COUPONS",
                ["STATS"] = "STATISTICS",
                ["PAGE"] = "PAGE:",
                ["VIPYES"] = "BATTLEPASS ACTIVE",
                ["VIPNO"] = "BATTLEPASS INACTIVE",
                ["BUTTON"] = "OPEN MENU",
                ["RANK"] = "   |   RANK: {0}"
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Level"] = "УРОВЕНЬ: {0} из {1}   |   XP: {2} из  {3}{4}",
                ["Level_2"] = "УРОВЕНЬ: {0} из {1}   |   XP: {2}{4}",
                ["Level_Top"] = "{0}.     УРОВЕНЬ: {1}   |   XP: {2}\n{3}",
                ["LevelGUI"] = "УРОВЕНЬ: {0}",
                ["Exchange"] = "ОБМЕНЯТЬ КУПОНЫ",
                ["ExchangeTrue"] = "Вы успешно обменяли купоны на - {0} XP.",
                ["InventaryInfo"] = "В вашем инвентаре купонов на {0} XP!",
                ["Info"] = "Повышайте уровень и получайте награду!",
                ["Take"] = "ЗАБРАТЬ",
                ["TakeItem"] = "Вы успешно получили - {0} [ {1} шт ].",
                ["LevelUP"] = "<color=#F65050FF>[НАГРАДЫ]</color> Уровень повышен!\n<size=12>Ваш уровень: <color=#F5DA81>{0}</color></size>",
                ["XP"] = "У вас на {0}XP",
                ["InventoryEmpty"] = "ВАШ ИНВЕНТАРЬ ПУСТ!",
                ["PROGRESS"] = "ПРОГРЕСС",
                ["OPENINV"] = "ИНВЕНТАРЬ",
                ["COUPONS"] = "КУПОНЫ",
                ["STATS"] = "СТАТИСТИКА",
                ["PAGE"] = "СТРАНИЦА:",
                ["VIPYES"] = "BATTLEPASS АКТИВЕН",
                ["VIPNO"] = "BATTLEPASS НЕАКТИВЕН",
                ["BUTTON"] = "ОТКРЫТЬ МЕНЮ",
                ["RANK"] = "   |   РАНГ: {0}"
            }, this, "ru");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Level"] = "РІВЕНЬ: {0} з {1}   |   XP: {2} з  {3}{4}",
                ["Level_2"] = "РІВЕНЬ: {0} з {1}   |   XP: {2}{4}",
                ["Level_Top"] = "{0}.     РІВЕНЬ: {1}   |   XP: {2}\n{3}",
                ["LevelGUI"] = "РІВЕНЬ: {0}",
                ["Exchange"] = "ОБМІНЯТИ КУПОНИ",
                ["ExchangeTrue"] = "Ви успішно обміняли купони на - {0} XP.",
                ["InventaryInfo"] = "У вашому інвентарі купонів на {0} XP!",
                ["Info"] = "Підвищуйте рівень та отримуйте нагороду!",
                ["Take"] = "ЗАБРАТИ",
                ["TakeItem"] = "Ви успішно отримали - {0} [ {1} шт ].",
                ["LevelUP"] = "<color=#F65050FF>[НАГОРОДИ]</color> Рівень підвищений!!\n<size=12>Ваш рівень: <color=#F5DA81>{0}</color></size>",
                ["XP"] = "У вас на {0}XP",
                ["InventoryEmpty"] = "ВАШ ІНВЕНТАР ПОРОЖНІЙ!",
                ["PROGRESS"] = "ПРОГРЕС",
                ["OPENINV"] = "ІНВЕНТАР",
                ["COUPONS"] = "КУПОН",
                ["STATS"] = "СТАТИСТИКА",
                ["PAGE"] = "СТОРІНКА:",
                ["VIPYES"] = "BATTLEPASS АКТИВНИЙ",
                ["VIPNO"] = "BATTLEPASS НЕАКТИВНИЙ",
                ["BUTTON"] = "ВІДКРИТИ МЕНЮ",
                ["RANK"] = "   |   РАНГ: {0}"
            }, this, "uk");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["Level"] = "NIVEL: {0} de {1}   |   XP: {2} de {3}{4}",
                ["Level_2"] = "NIVEL: {0} de {1}   |   XP: {2}{4}",
                ["Level_Top"] = "{0}.     NIVEL: {1}   |   XP: {2}\n{3}",
                ["LevelGUI"] = "NIVEL: {0}",
                ["Exchange"] = "VALORES DE CAMBIO",
                ["ExchangeTrue"] = "Has canjeado con exito cupones por - {0} XP.",
                ["InventaryInfo"] = "?Tienes {0} cupones de XP en tu inventario!",
                ["Info"] = "?Sube de nivel SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN obten recompensas!",
                ["Take"] = "LLEVAR",
                ["TakeItem"] = "Ha recibido con exito - {0} [{1} piezas].",
                ["LevelUP"] = "<color=#F65050FF>[RECOMPENSAS]</color> Nivel elevado!\n<size=12>Su nivel: <color=#F5DA81>{0}</color></size>",
                ["XP"] = "En ti {0}XP",
                ["InventoryEmpty"] = "?TU INVENTARIO ESTA VACIO!",
                ["PROGRESS"] = "PROGRESO",
                ["OPENINV"] = "INVENTARIO",
                ["COUPONS"] = "CUPON",
                ["STATS"] = "ESTADISTICAS",
                ["PAGE"] = "PAGINA:",
                ["VIPYES"] = "BATTLEPASS ACTIVO",
                ["VIPNO"] = "BATTLEPASS INACTIVO",
                ["BUTTON"] = "MENU ABIERTO",
                ["RANK"] = "   |   RANGO: {0}"
            }, this, "es-ES");
        }
        private void OnPlayerConnected(BasePlayer player)
        {
            if (player.IsReceivingSnapshot)
            {
                NextTick(() => OnPlayerConnected(player));
                return;
            }
            if (!StoredData.ContainsKey(player.userID)) StoredData.Add(player.userID, new XLevelsData());
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.DGXJZQMAZNKXZECUWQHSCVSLRGXQOBYGJBZYOJRXFOSD) GUI(player);
            LoadData(player);
        }
        private class XLevelsData
        {
            [JsonProperty("Уровень")] public int Level = 0;
            [JsonProperty("ХР")] public float XP = 0;
        }
        private void ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(BasePlayer player, float WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ)
        {
            bool HIJJULWGTUWPAHKWXNTQMADPOAKXYORKAYLVRIUBENGPT = StoredData[player.userID].Level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PMKMWEOPBUJVRLBQQJHHEAQAPNUBJIEPMVCGZBVBBKFUHWSNC && HIJJULWGTUWPAHKWXNTQMADPOAKXYORKAYLVRIUBENGPT)
            {
                NextTick(() => {
                    if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.DGXJZQMAZNKXZECUWQHSCVSLRGXQOBYGJBZYOJRXFOSD) GUI(player);
                    Message(player, $"+ {WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ}");
                });
                StoredData[player.userID].XP += WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ;
                return;
            }
            else if (HIJJULWGTUWPAHKWXNTQMADPOAKXYORKAYLVRIUBENGPT) return;
            float IRKJFMQVCGETVUBYIEDMOBWPEPSRMYUOVJSSMOJEU = WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ;
            NextTick(() => {
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.DGXJZQMAZNKXZECUWQHSCVSLRGXQOBYGJBZYOJRXFOSD) GUI(player);
                Message(player, $"+ {IRKJFMQVCGETVUBYIEDMOBWPEPSRMYUOVJSSMOJEU}");
            });
            while (WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ > StoredData[player.userID].Level * MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI + MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC)
            {
                StoredData[player.userID].Level += 1;
                WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ -= StoredData[player.userID].Level * MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI + MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC;
                int level = StoredData[player.userID].Level;
                ERFCWUOBUSZEILTAYDVAJOSJVHZIGPRGVKYEAFMP(player, level);
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.ODQWGNTHVLEYNLDZKBVWWUEFQQEEOFOGTHYRODZBQ) IHQYGOUNRZXAQKJASAISSIEMDQDQQRPAJATVJMWAMJ(player, string.Format(lang.GetMessage("LevelUP", this, player.UserIDString), level));
                if (level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ)
                {
                    if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.YCSWABCBZTJXZXNBFQYYGBJWKLEOJLMKNYQAVBWEME)
                    {
                        StoredData[player.userID].Level = 0;
                        StoredData[player.userID].XP = 0;
                    }
                    if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PMKMWEOPBUJVRLBQQJHHEAQAPNUBJIEPMVCGZBVBBKFUHWSNC) StoredData[player.userID].XP = 0;
                    return;
                }
            }
            float FHEVIJMMCOEAWCKPCRPZEVBUYKFTUVYRBUIEBMWYAAMYDOXQF = StoredData[player.userID].Level * MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI + MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC;
            if (WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ > 0)
            {
                StoredData[player.userID].XP += WLFEQEEEXXUDMYFEHJWMYFIWRRSYWOGCFNRZKBGRUVHVBAAZ;
                if (StoredData[player.userID].XP >= FHEVIJMMCOEAWCKPCRPZEVBUYKFTUVYRBUIEBMWYAAMYDOXQF)
                {
                    StoredData[player.userID].XP -= FHEVIJMMCOEAWCKPCRPZEVBUYKFTUVYRBUIEBMWYAAMYDOXQF;
                    StoredData[player.userID].Level += 1;
                    int level = StoredData[player.userID].Level;
                    ERFCWUOBUSZEILTAYDVAJOSJVHZIGPRGVKYEAFMP(player, level);
                    if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.ODQWGNTHVLEYNLDZKBVWWUEFQQEEOFOGTHYRODZBQ) IHQYGOUNRZXAQKJASAISSIEMDQDQQRPAJATVJMWAMJ(player, string.Format(lang.GetMessage("LevelUP", this, player.UserIDString), level));
                    if (level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ)
                    {
                        if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.YCSWABCBZTJXZXNBFQYYGBJWKLEOJLMKNYQAVBWEME)
                        {
                            StoredData[player.userID].Level = 0;
                            StoredData[player.userID].XP = 0;
                        }
                        if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PMKMWEOPBUJVRLBQQJHHEAQAPNUBJIEPMVCGZBVBBKFUHWSNC) StoredData[player.userID].XP = 0;
                    }
                }
            }
        }
        private LevelConfig MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT;
        private void OnLootSpawn(LootContainer lootContainer)
        {
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ)
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FXFDRUPVWUDNOBHYLYWYVMLLIYRBCLCKYKSDLUOEIN) NextTick(() => LootSpawn(lootContainer));
                else LootSpawn(lootContainer);
        }
        private class LevelConfig
        {
            [JsonProperty("Общие настройки")] public GeneralSetting Setting = new GeneralSetting();
            [JsonProperty("Расположение мини-панели / Настройки главного меню")] public GUISetting GUI = new GUISetting();
            [JsonProperty("Настройки магазинов")] public VendingSetting Vending = new VendingSetting();
            [JsonProperty("Настройка уровней")] public LevelSetting Level = new LevelSetting();
            [JsonProperty("Множитель XP")] public XPRateSetting IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO = new XPRateSetting();
            [JsonProperty("Выдача XP за онлайн")] public OnlineSetting LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK = new OnlineSetting();
            [JsonProperty("Настройка ХР | Shortname : ValueXP")] public XPSetting XP = new XPSetting();
            [JsonProperty("Купоны на ХР")] public List<Coupons> Coupon;
            [JsonProperty("Награда за уровни")] public Dictionary<int, Awards> Award;
            [JsonProperty("Вип награда за уровни")] public Dictionary<int, Awards> BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP;
            internal class Crates
            {
                [JsonProperty("Имя ящика/бочки")] public string SFOKFRWRCOCFULGXUJXPTWCYQDTSRTFKMEGDWWLLJLYN;
                [JsonProperty("Шанс выпадения")] public float IEBYRYXFZQWDQTBXDAJJRTPFCAYXMFIYOOIZSUAVHFM;
                [JsonProperty("Минимальное количество купона")] public int JZFDJNFKPESPOVVQZZTUIYPBKBFJANBLGBVDUVNYZYJJW;
                [JsonProperty("Максимальное количество купона")] public int LWYJVILSFLKESIHWJBCGIMZSVEMUUKPFFQQILQSTZOWKTQC;
                public Crates(string namecrate, float chancedrop, int cmin, int cmax)
                {
                    SFOKFRWRCOCFULGXUJXPTWCYQDTSRTFKMEGDWWLLJLYN = namecrate;
                    IEBYRYXFZQWDQTBXDAJJRTPFCAYXMFIYOOIZSUAVHFM = chancedrop;
                    JZFDJNFKPESPOVVQZZTUIYPBKBFJANBLGBVDUVNYZYJJW = cmin;
                    LWYJVILSFLKESIHWJBCGIMZSVEMUUKPFFQQILQSTZOWKTQC = cmax;
                }
            }
            internal class VendingSetting
            {
                [JsonProperty("Открывать меню уровней. [ True - Сразу после открытия НПС магазина | False - Через UI кнопку ]")] public bool VendingOpen;
                [JsonProperty("Доступ к меню уровней только через магазины НПС. [ True - Магазины НПС | False - Команда ]")] public bool VendingUse;
                [JsonProperty("Список магазинов НПС в которых можно открыть меню уровней (Имя магазина)")] public List<string> ListNPCVending;
            }
            public static LevelConfig GetNewConfiguration()
            {
                return new LevelConfig
                {
                    Setting = new GeneralSetting
                    {
                        JMHUBTIIBJJNGTZLGPJPTQXYEGMLLHBUFGKSYWPLVFEEWG = true,
                        FSDWJRBWTPIPVGWWTHPHAIGMJAXTNMSBYFHTIKSC = true,
                        QMDPYNEUAFCMXEHFRGXSFAKJGDVSTKOSFPAGORRKYDRCFQQ = true,
                        IPJEVWEEQNCCBXCGLVSQYAQXGYYJRFCTEKVAVJKT = true,
                        NPPGVZXZXVVDSSRJRZPKMIMCJQSSHQXCYRIHDOEWRCTUX = true,
                        RLZAIBHOJDAULHULBZIKDPENFQKJOTGUWNYCGYFE = true,
                        ODQWGNTHVLEYNLDZKBVWWUEFQQEEOFOGTHYRODZBQ = true,
                        FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ = true,
                        XOOCLZLAOZDVGAXNGGKVDEVWTUZWPBQQSXJFVZQNTF = true,
                        PDMQOEMFNMWEHLWHDBBUASEODNYWGOFVVKALCPSPIQE = true,
                        LYFPIOBJLNVKSMTUTCOTKSSODJENRKSPIRZMDIINACQXCAZR = false,
                        ZUBUTKSFRMZJNRAUFBBMGRKUATIBVLDJNWSPRVOGHHLWJD = true,
                        PMKMWEOPBUJVRLBQQJHHEAQAPNUBJIEPMVCGZBVBBKFUHWSNC = false,
                        JRCPGTFYIKWHZAWLQMJUHJHWHRPYDOJPMDQRDXDGS = false,
                        YCSWABCBZTJXZXNBFQYYGBJWKLEOJLMKNYQAVBWEME = false,
                        FXFDRUPVWUDNOBHYLYWYVMLLIYRBCLCKYKSDLUOEIN = false,
                        SteamID = 0,
                        BBDMEBRKRSFZWTVMOWNSOHZJAHNGEUTMCFHVGZAMSBUSHYTG = false,
                        LVJIVPWKXJKMGSPUJVIUQPOGGUUVSTUHZIWIFDAN = false,
                        KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ = new Dictionary<int, string>
                        {
                            [0] = "КЕПКА-Х",
                            [1] = "ЖЕЛЕЗО-1",
                            [2] = "ЖЕЛЕЗО-2",
                            [3] = "ЖЕЛЕЗО-3",
                            [4] = "БРОНЗА-1",
                            [5] = "БРОНЗА-2",
                            [6] = "БРОНЗА-3",
                            [7] = "СЕРЕБРО-1",
                            [8] = "СЕРЕБРО-2",
                            [9] = "СЕРЕБРО-3",
                            [10] = "ЗОЛОТО-1",
                            [11] = "ЗОЛОТО-2",
                            [12] = "ЗОЛОТО-3",
                            [13] = "ПЛАТИНА-1",
                            [14] = "ПЛАТИНА-2",
                            [15] = "ПЛАТИНА-3",
                            [16] = "АЛМАЗ-1",
                            [17] = "АЛМАЗ-2",
                            [18] = "АЛМАЗ-3",
                            [19] = "БЕССМЕРТНЫЙ-1",
                            [20] = "БЕССМЕРТНЫЙ-2",
                            [21] = "БЕССМЕРТНЫЙ-3",
                            [22] = "РАДИАНТ-1",
                            [23] = "РАДИАНТ-2",
                            [24] = "РАДИАНТ-3",
                            [25] = "БОГ"
                        }
                    },
                    Vending = new VendingSetting
                    {
                        VendingOpen = false,
                        VendingUse = false,
                        ListNPCVending = new List<string> {
                                                        "Black Market"
                                                }
                    },
                    IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO = new XPRateSetting
                    {
                        YISOZLTAFLKFBDEASSJMKUKCKMJLDRQTAVXQPWLOYKOO = false,
                        RNHTHUEUVAEXPDNBIXOUQFFFNKWGUOAFWDSYCRVXMZFVSTZSY = new Dictionary<string, float>
                        {
                            ["xlevels.125p"] = 2.25f,
                            ["xlevels.75p"] = 1.75f,
                            ["xlevels.10p"] = 1.1f
                        }
                    },
                    LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK = new OnlineSetting
                    {
                        RDOHGPLYXFNRWRXVWEYCRZKSJJGUQPZFBGDRVHYQFS = false,
                        GDAXIRAOOSAOSSVYXIQIHFIPPOFZOFHWZNEPIMYCPBLM = 15.0f,
                        Permisssion = new Dictionary<string, float>
                        {
                            ["xlevels.default"] = 5.0f
                        }
                    },
                    GUI = new GUISetting
                    {
                        AnchorMin = "1 0",
                        AnchorMax = "1 0",
                        OffsetMin = "-403 16",
                        OffsetMax = "-210 42",
                        DGXJZQMAZNKXZECUWQHSCVSLRGXQOBYGJBZYOJRXFOSD = true,
                        JLOVTSJQIKHOLSSTVMYOEOXEDGMYKMODOUIVIUVIOQARRK = false,
                        RYEJCTOMVNJRMFLFVWEZRKXKAQPAONGMTEVAFCLKZ = true,
                        NIZCICDKFVNKLHBUILEOYHHWYIKKASKTAIWOKXIMXEH = true
                    },
                    Level = new LevelSetting
                    {
                        PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ = 30,
                        ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC = 100,
                        PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI = 25
                    },
                    XP = new XPSetting
                    {
                        OHIYMHUCTLXOLFXYTWRMAFPWBZNMHBBOGGPMLOQYMTNODYGVW = new Dictionary<string, float>
                        {
                            ["stones"] = 10.0f,
                            ["sulfur.ore"] = 15.0f,
                            ["metal.ore"] = 12.5f
                        },
                        OCCUZJRLXMTHURJIHEPKNFFSZHSBTCTRPNNZLMHGUAQEEEY = new Dictionary<string, float>
                        {
                            ["potato.entity"] = 2.5f,
                            ["corn.entity"] = 1.75f,
                            ["hemp.emtity"] = 0.25f
                        },
                        EUQCGMGJWJVRQQRUTBSHEJXVXIQNOBNUIWWZLQLDHDDCQPPE = new Dictionary<string, float>
                        {
                            ["stones"] = 5.0f,
                            ["sulfur.ore"] = 10.0f,
                            ["metal.ore"] = 7.5f
                        },
                        WLDMRQVXVFXVTVVVAITTRICQOZAGUEHTLERPKHRGBCQ = new Dictionary<string, float>
                        {
                            ["boar"] = 10.0f,
                            ["loot-barrel-1"] = 7.5f,
                            ["heavyscientist"] = 2.5f
                        },
                        OHOIIGPHVKRNJNYRPOCQYDKODFLTRNSORQBGKSYOPZXA = new Dictionary<string, float>
                        {
                            ["crate_normal"] = 5.0f,
                            ["crate_normal_2"] = 1.0f,
                            ["crate_tools"] = 3.5f
                        }
                    },
                    Coupon = new List<Coupons> {
                                                new Coupons("Купон 5ХР", "Купон на 5ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935697478, "note", 5, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 2)
                                                }),
                                                new Coupons("Купон 10ХР", "Купон на 10ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935699062, "note", 10, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 2)
                                                }),
                                                new Coupons("Купон 25ХР", "Купон на 25ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935692305, "note", 25, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 2)
                                                }),
                                                new Coupons("Купон 50ХР", "Купон на 50ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935693400, "note", 50, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 1)
                                                }),
                                                new Coupons("Купон 100ХР", "Купон на 100ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935694378, "note", 100, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 1)
                                                }),
                                                new Coupons("Купон 200ХР", "Купон на 200ХР\n\nОбменяйте его и получите ХР для повышения уровня!\n\nКоманда для обмена - /level", 2935695411, "note", 200, new List < Crates > {
                                                        new Crates("crate_normal_2", 50.0f, 1, 1)
                                                }),
                                        },
                    Award = new Dictionary<int, Awards>
                    {
                        [1] = new Awards("wood", "Дерево", 1250, 0, "", ""),
                        [2] = new Awards("charcoal", "Уголь", 1500, 0, "", ""),
                        [3] = new Awards("metal.ore", "Железная руда", 1000, 0, "", ""),
                        [4] = new Awards("metal.fragments", "Фрагменты металла", 750, 0, "", ""),
                        [5] = new Awards("sulfur.ore", "Серная руда", 500, 0, "", ""),
                        [6] = new Awards("sulfur", "Сера", 300, 0, "", ""),
                        [7] = new Awards("gunpowder", "Порох", 400, 0, "", ""),
                        [8] = new Awards("hq.metal.ore", "МВК руда", 25, 0, "", ""),
                        [9] = new Awards("metal.refined", "МВК", 20, 0, "", ""),
                        [10] = new Awards("scrap", "Металлолом", 50, 0, "", "")
                    },
                    BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP = new Dictionary<int, Awards>
                    {
                        [1] = new Awards("wood", "Дерево", 1250, 0, "", ""),
                        [2] = new Awards("charcoal", "Уголь", 1500, 0, "", ""),
                        [3] = new Awards("metal.ore", "Железная руда", 1000, 0, "", ""),
                        [4] = new Awards("metal.fragments", "Фрагменты металла", 750, 0, "", ""),
                        [5] = new Awards("sulfur.ore", "Серная руда", 500, 0, "", ""),
                        [6] = new Awards("sulfur", "Сера", 300, 0, "", ""),
                        [7] = new Awards("gunpowder", "Порох", 400, 0, "", ""),
                        [8] = new Awards("hq.metal.ore", "МВК руда", 25, 0, "", ""),
                        [9] = new Awards("metal.refined", "МВК", 20, 0, "", ""),
                        [10] = new Awards("scrap", "Металлолом", 50, 0, "", "")
                    }
                };
            }
            internal class OnlineSetting
            {
                [JsonProperty("Включить выдачу XP онлайн игрокам")] public bool RDOHGPLYXFNRWRXVWEYCRZKSJJGUQPZFBGDRVHYQFS;
                [JsonProperty("Интервал выдачи XP (в сек.)")] public float GDAXIRAOOSAOSSVYXIQIHFIPPOFZOFHWZNEPIMYCPBLM;
                [JsonProperty("Настройка пермишенов. [ Пермишен | XP ]")] public Dictionary<string, float> Permisssion;
            }
            internal class GeneralSetting
            {
                [JsonProperty("SteamID профиля для кастомной аватарки")] public ulong SteamID;
                [JsonProperty("Включить сообщения полученных  наград в чат")] public bool RLZAIBHOJDAULHULBZIKDPENFQKJOTGUWNYCGYFE;
                [JsonProperty("Зачислять ХР за убийство")] public bool IPJEVWEEQNCCBXCGLVSQYAQXGYYJRFCTEKVAVJKT;
                [JsonProperty("Есть плагин на кастомный лут")] public bool FXFDRUPVWUDNOBHYLYWYVMLLIYRBCLCKYKSDLUOEIN;
                [JsonProperty("Получить ВИП награду - [ True - только с пермишеном | False - без пермишена ]")] public bool LYFPIOBJLNVKSMTUTCOTKSSODJENRKSPIRZMDIINACQXCAZR;
                [JsonProperty("Забрать ВИП награду - [ True - забрать только с пермишеном | False - забрать в любое время без пермишена ]")] public bool ZUBUTKSFRMZJNRAUFBBMGRKUATIBVLDJNWSPRVOGHHLWJD;
                [JsonProperty("Список доступных рангов - [ Уровень - Ранг ] ( Если список пуст, то ранг не будет отображаться в меню )")] public Dictionary<int, string> KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ;
                [JsonProperty("Включить сообщения повышения уровня в чат")] public bool ODQWGNTHVLEYNLDZKBVWWUEFQQEEOFOGTHYRODZBQ;
                [JsonProperty("Зачислять ХР за подбор ресурсов")] public bool JMHUBTIIBJJNGTZLGPJPTQXYEGMLLHBUFGKSYWPLVFEEWG;
                [JsonProperty("Зачислять ХР за сбор урожая")] public bool FSDWJRBWTPIPVGWWTHPHAIGMJAXTNMSBYFHTIKSC;
                [JsonProperty("Обменивать купоны если уже достигнут максимальный уровень - [ Подходит для топа игроков ]")] public bool JRCPGTFYIKWHZAWLQMJUHJHWHRPYDOJPMDQRDXDGS;
                [JsonProperty("Включить купоны")] public bool FBVUZELHRXJIXZJGIPEHVTBHVWJFHTJCBMEFBMSKMVXLGEFQ;
                [JsonProperty("Включить топ")] public bool XOOCLZLAOZDVGAXNGGKVDEVWTUZWPBQQSXJFVZQNTF;
                [JsonProperty("Зачислять ХР за открытие ящиков")] public bool NPPGVZXZXVVDSSRJRZPKMIMCJQSSHQXCYRIHDOEWRCTUX;
                [JsonProperty("Зачислять ХР за бонусные ресурсы")] public bool QMDPYNEUAFCMXEHFRGXSFAKJGDVSTKOSFPAGORRKYDRCFQQ;
                [JsonProperty("Засчитывать ХР если уже достигнут максимальный уровень - [ Подходит для топа игроков ]")] public bool PMKMWEOPBUJVRLBQQJHHEAQAPNUBJIEPMVCGZBVBBKFUHWSNC;
                [JsonProperty("Включить префикс с рангом в чате")] public bool LVJIVPWKXJKMGSPUJVIUQPOGGUUVSTUHZIWIFDAN;
                [JsonProperty("Включить ВИП награды")] public bool PDMQOEMFNMWEHLWHDBBUASEODNYWGOFVVKALCPSPIQE;
                [JsonProperty("Обнулять уровень и ХР игрока после достижения максимального уровня - [ Игроки повторно будет открывать уровни и получать награды ]")] public bool YCSWABCBZTJXZXNBFQYYGBJWKLEOJLMKNYQAVBWEME;
                [JsonProperty("Включить префикс с уровнем в чате")] public bool BBDMEBRKRSFZWTVMOWNSOHZJAHNGEUTMCFHVGZAMSBUSHYTG;
            }
            internal class XPSetting
            {
                [JsonProperty("ХР за подбор ресурсов")] public Dictionary<string, float> OHIYMHUCTLXOLFXYTWRMAFPWBZNMHBBOGGPMLOQYMTNODYGVW;
                [JsonProperty("ХР за сбор урожая")] public Dictionary<string, float> OCCUZJRLXMTHURJIHEPKNFFSZHSBTCTRPNNZLMHGUAQEEEY;
                [JsonProperty("ХР за бонусную добычу")] public Dictionary<string, float> EUQCGMGJWJVRQQRUTBSHEJXVXIQNOBNUIWWZLQLDHDDCQPPE;
                [JsonProperty("ХР за убийство / разбитие бочек")] public Dictionary<string, float> WLDMRQVXVFXVTVVVAITTRICQOZAGUEHTLERPKHRGBCQ;
                [JsonProperty("ХР за открытие ящиков")] public Dictionary<string, float> OHOIIGPHVKRNJNYRPOCQYDKODFLTRNSORQBGKSYOPZXA;
            }
            internal class GUISetting
            {
                [JsonProperty("AnchorMin")] public string AnchorMin;
                [JsonProperty("AnchorMax")] public string AnchorMax;
                [JsonProperty("OffsetMin")] public string OffsetMin;
                [JsonProperty("OffsetMax")] public string OffsetMax;
                [JsonProperty("Отображать мини-панель")] public bool DGXJZQMAZNKXZECUWQHSCVSLRGXQOBYGJBZYOJRXFOSD;
                [JsonProperty("Отображать контейнер наград - [ True - Только когда есть награда на уровне | False - Всегда ]")] public bool JLOVTSJQIKHOLSSTVMYOEOXEDGMYKMODOUIVIUVIOQARRK;
                [JsonProperty("Отображать требуемый уровень наград")] public bool RYEJCTOMVNJRMFLFVWEZRKXKAQPAONGMTEVAFCLKZ;
                [JsonProperty("Отображать требуемый уровень ВИП наград")] public bool NIZCICDKFVNKLHBUILEOYHHWYIKKASKTAIWOKXIMXEH;
            }
            internal class Awards
            {
                [JsonProperty("Шортнейм предмета / имя кастомной награды [ Не должно быть пустым ]")] public string Shortname;
                [JsonProperty("Отображаемое имя награды")] public string Name;
                [JsonProperty("Количество предмета")] public int Amount;
                [JsonProperty("Скин предмета")] public ulong SkinID;
                [JsonProperty("Команда")] public string Command;
                [JsonProperty("Ссылка на кастомную картинку")] public string WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU;
                public Awards(string shortname, string name, int amount, ulong skinid, string command, string MTRMYOAPGVZLMFCKDJNSRPHZCJMLKIMAAFFGQPWGKNHVL)
                {
                    Shortname = shortname;
                    Name = name;
                    Amount = amount;
                    SkinID = skinid;
                    Command = command;
                    WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU = MTRMYOAPGVZLMFCKDJNSRPHZCJMLKIMAAFFGQPWGKNHVL;
                }
            }
            internal class XPRateSetting
            {
                [JsonProperty("Включить множитель XP при обмене купонов - [ Данный параметр влияет только на множители для обмена купонов ]")] public bool YISOZLTAFLKFBDEASSJMKUKCKMJLDRQTAVXQPWLOYKOO;
                [JsonProperty("Настройка пермишенов для умножителей ХР на обмен купонов и других действий. [ Пермишен | Множитель XP ]")] public Dictionary<string, float> RNHTHUEUVAEXPDNBIXOUQFFFNKWGUOAFWDSYCRVXMZFVSTZSY = new Dictionary<string, float>();
            }
            internal class Coupons
            {
                [JsonProperty("Имя купона")] public string Name;
                [JsonProperty("Текст купона")] public string Text;
                [JsonProperty("Скин купона")] public ulong SkinID;
                [JsonProperty("ShortName предмета")] public string ShortName;
                [JsonProperty("Кол-во ХР")] public int XP;
                [JsonProperty("Настройка шанса выпадения из ящиков/бочек")] public List<Crates> Crate;

                public Coupons(string name, string text, ulong skinid, string shortName, int xp, List<Crates> crates)
                {
                    Name = name;
                    Text = text;
                    SkinID = skinid;
                    XP = xp;
                    Crate = crates;
                    ShortName = shortName;
                }
            }
            internal class LevelSetting
            {
                [JsonProperty("Максимальный уровень")] public int PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ;
                [JsonProperty("Кол-во ХР для повышения одного уровня")] public float ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC;
                [JsonProperty("На сколько увеличивать кол-во ХР с каждым уровнем")] public float PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI;
            }
        }
        private string IWWRJDRXFSLZFZDCRTAMPUYHPHBWTRUUHFDTWYNFUR(BasePlayer player) => FEXXVPQZUFGOYZSBTGZUGAKCUGMGKTYQFDJVWTKOGKE(player.userID);
        private void WUSIVEXLYVERNYOBBCVENXRSZWJGTGURYABNWZGSVGWYDNP(BasePlayer player, string command, string[] args) => OpenLevels(player);
        private void SaveData(BasePlayer player) => Interface.Oxide.DataFileSystem.WriteObject($"XDataSystem/XLevels/InvItems/{player.userID}", KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID]);
        private object OnBetterChat(Dictionary<string, object> chat)
        {
            IPlayer player = chat["Player"] as IPlayer;
            string prefix = FEXXVPQZUFGOYZSBTGZUGAKCUGMGKTYQFDJVWTKOGKE(Convert.ToUInt64(player.Id));
            if (String.IsNullOrEmpty(prefix)) return chat;
            string name = $"{prefix} " + chat["Username"];
            chat["Username"] = name;
            return chat;
        }
        private float HWLDZNGYCAIYURRRAMTNXBECVDIGBSOMHPZWURSLTDKWQHX(BasePlayer player, float xp)
        {
            foreach (var perm in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO.RNHTHUEUVAEXPDNBIXOUQFFFNKWGUOAFWDSYCRVXMZFVSTZSY) if (permission.UserHasPermission(player.UserIDString, perm.Key)) return xp * perm.Value;
            return xp;
        }
        private Item OnItemSplit(Item item, int amount)
        {
            if (StackSizeController) return null;
            for (int i = 0; i < MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon.Count; i++)
                if (item.skin == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[i].SkinID)
                {
                    item.amount -= amount;
                    var Item = ItemManager.Create(item.info, amount, item.skin);
                    Item.name = item.name;
                    Item.skin = item.skin;
                    Item.text = item.text;
                    Item.amount = amount;
                    item.MarkDirty();
                    return Item;
                }
            return null;
        }
        private void OnLootEntityEnd(BasePlayer player, NPCVendingMachine PIDKDBDBMBIQJPNFVCXDUOPHASZKSHIQQBNRKKAIN)
        {
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.VendingUse)
            {
                CuiHelper.DestroyUi(player, ".Level_Overlay");
                CuiHelper.DestroyUi(player, ".Button");
            }
        }
        private void OnEntityDeath(BaseCombatEntity entity, HitInfo info)
        {
            if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.IPJEVWEEQNCCBXCGLVSQYAQXGYYJRFCTEKVAVJKT) return;
            if (entity == null) return;
            BasePlayer player = info?.InitiatorPlayer;
            if (player == null || player.IsNpc) return;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.WLDMRQVXVFXVTVVVAITTRICQOZAGUEHTLERPKHRGBCQ.ContainsKey(entity.ShortPrefabName)) JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(player, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.WLDMRQVXVFXVTVVVAITTRICQOZAGUEHTLERPKHRGBCQ[entity.ShortPrefabName]);
        }
        private void LootSpawn(LootContainer lootContainer)
        {
            var cfg = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon;
            for (int i = 0; i < cfg.Count; i++)
                for (int j = 0; j < cfg[i].Crate.Count; j++)
                {
                    var crate = cfg[i].Crate[j];
                    if (crate.SFOKFRWRCOCFULGXUJXPTWCYQDTSRTFKMEGDWWLLJLYN == lootContainer.ShortPrefabName)
                        if (UnityEngine.Random.Range(0, 100) <= crate.IEBYRYXFZQWDQTBXDAJJRTPFCAYXMFIYOOIZSUAVHFM)
                        {
                            Item item = ItemManager.CreateByItemID(1414245162, UnityEngine.Random.Range(crate.JZFDJNFKPESPOVVQZZTUIYPBKBFJANBLGBVDUVNYZYJJW, crate.LWYJVILSFLKESIHWJBCGIMZSVEMUUKPFFQQILQSTZOWKTQC), cfg[i].SkinID);
                            item.name = cfg[i].Name;
                            item.text = cfg[i].Text;
                            item.MoveToContainer(lootContainer.inventory);
                        }
                }
        }
        protected override void SaveConfig() => Config.WriteObject(MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT);
        private void Message(BasePlayer player, string VRDXLYRDJNZMGHIQRYZGGTFDERDXMUQQSBAXCFUPAWBOHENN)
        {
            CuiHelper.DestroyUi(player, ".Message");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                FadeOut = 0.5f,
                RectTransform = {
                                        AnchorMin = "1 0",
                                        AnchorMax = "1 0",
                                        OffsetMin = "-250 0",
                                        OffsetMax = "-200 26"
                                },
                Text = {
                                        FadeIn = 0.5f,
                                        Text = $"{VRDXLYRDJNZMGHIQRYZGGTFDERDXMUQQSBAXCFUPAWBOHENN}",
                                        Align = TextAnchor.MiddleRight,
                                        Font = "robotocondensed-regular.ttf",
                                        FontSize = 13,
                                        Color = "1 1 1 0.4"
                                }
            }, ".GUIProgress", ".Message");
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
            timer.Once(2.5f, () => {
                CuiHelper.DestroyUi(player, ".Message");
            });
        }
        public List<String> TOFJVEXDJJQMUGIKHWEJIQDBHNGXRYACCPFBSYQR = new List<String> {
                        "lvl",
                        "levels",
                        "reward",
                        "rewards"
                };
        private void OnServerInitialized()
        {
            foreach (var cmdName in TOFJVEXDJJQMUGIKHWEJIQDBHNGXRYACCPFBSYQR) cmd.AddChatCommand(cmdName, this, nameof(BXNNADCXZOHCMJBVSIIXLBHCDZKCOGWZXZFKSBRRILR));
            InitializeLang();
            if (BetterChat) Unsubscribe(nameof(OnPlayerChat));

            if (Interface.Oxide.DataFileSystem.ExistsDatafile("XDataSystem/XLevels/XLevels")) StoredData = Interface.Oxide.DataFileSystem.ReadObject<Dictionary<ulong, XLevelsData>>("XDataSystem/XLevels/XLevels");
            BasePlayer.activePlayerList.ToList().ForEach(OnPlayerConnected);
            timer.Every(90, () => {
                Interface.Oxide.DataFileSystem.WriteObject("XDataSystem/XLevels/XLevels", StoredData);
                BasePlayer.activePlayerList.ToList().ForEach(SaveData);
            }).Callback();
            permission.RegisterPermission("xlevels.battlepass", this);
            permission.RegisterPermission("xlevels.top", this);
            foreach (var perm in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO.RNHTHUEUVAEXPDNBIXOUQFFFNKWGUOAFWDSYCRVXMZFVSTZSY) permission.RegisterPermission(perm.Key, this);
            foreach (var perm in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK.Permisssion) permission.RegisterPermission(perm.Key, this);
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK.RDOHGPLYXFNRWRXVWEYCRZKSJJGUQPZFBGDRVHYQFS) timer.Every(MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK.GDAXIRAOOSAOSSVYXIQIHFIPPOFZOFHWZNEPIMYCPBLM, () => BasePlayer.activePlayerList.ToList().ForEach(CDVENCFXPGFRJQIVEMZMAEQPUQHHNJKKPUXHWMPEMHFMFWUWF));
        }
        private Dictionary<ulong, List<InvItems>> KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST = new Dictionary<ulong, List<InvItems>>();
        private void OEYQUBXFSJHWEZXKLWRERVXJUIUUQIMNFESXUXRFS(BasePlayer player, float FKCBTQCLASTVTQOWJTFGLNMDJFJSRVAEPZGKOOZKYMCMAUHFM)
        {
            if (StoredData.ContainsKey(player.userID)) ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(player, FKCBTQCLASTVTQOWJTFGLNMDJFJSRVAEPZGKOOZKYMCMAUHFM);
        }
        private void Button(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".Button");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "1 0",
                                        AnchorMax = "1 0",
                                        OffsetMin = "-447 16",
                                        OffsetMax = "-210 98"
                                },
                Image = {
                                        Color = "0.517 0.521 0.509 0.95",
                                        Material = "assets/icons/greyout.mat"
                                }
            }, "Overlay", ".Button");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "5 5",
                                        OffsetMax = "-5 -5"
                                },
                Button = {
                                        Color = "0.217 0.221 0.209 0.95",
                                        Material = "assets/icons/greyout.mat",
                                        Command = "x_levels"
                                },
                Text = {
                                        Text = lang.GetMessage("BUTTON", this, player.UserIDString),
                                        Align = TextAnchor.MiddleCenter,
                                        Font = "robotocondensed-regular.ttf",
                                        FontSize = 22,
                                        Color = "1 1 1 0.25"
                                }
            }, ".Button");
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        [ConsoleCommand("level_take")]
        private void ELKWGTFAKTQTMTHPWMHDPJWTQZHAPOFLMXQLYXBAOPXSXLR(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Count == 0) return;
            JFSURVWWOJCXAUYIFQSBSHIDQHTDOJWVCWSQCZZHWOEVH(player, int.Parse(arg.Args[0]), int.Parse(arg.Args[1]));
        }
        private class InvItems
        {
            [JsonProperty("Шортнейм предмета")] public string Shortname;
            [JsonProperty("Отображаемое имя награды")] public string Name;
            [JsonProperty("Количество предмета")] public int Amount;
            [JsonProperty("Скин предмета")] public ulong SkinID;
            [JsonProperty("Команда")] public string Command;
            [JsonProperty("Своя картинка")] public string WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU;
            [JsonProperty("Вип награда")] public bool NCXCRNWHSMXROHMTEFGWGBDSOEZRTYOTRVBIHXPEMYUKB;
            public InvItems(string shortname, string name, int amount, ulong skinid, string command, string MTRMYOAPGVZLMFCKDJNSRPHZCJMLKIMAAFFGQPWGKNHVL, bool QGXBSFEIDTDXKATWKKCSJETSZHCVVKCOQLYJJYATGJE)
            {
                Shortname = shortname;
                Name = name;
                Amount = amount;
                SkinID = skinid;
                Command = command;
                WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU = MTRMYOAPGVZLMFCKDJNSRPHZCJMLKIMAAFFGQPWGKNHVL;
                NCXCRNWHSMXROHMTEFGWGBDSOEZRTYOTRVBIHXPEMYUKB = QGXBSFEIDTDXKATWKKCSJETSZHCVVKCOQLYJJYATGJE;
            }
        }
        protected override void LoadDefaultConfig() => MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT = LevelConfig.GetNewConfiguration();
        private void OnDispenserBonus(ResourceDispenser dispenser, BasePlayer player, Item item)
        {
            if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.QMDPYNEUAFCMXEHFRGXSFAKJGDVSTKOSFPAGORRKYDRCFQQ) return;
            if (dispenser == null || item == null || player == null) return;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.EUQCGMGJWJVRQQRUTBSHEJXVXIQNOBNUIWWZLQLDHDDCQPPE.ContainsKey(item.info.shortname)) JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(player, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.EUQCGMGJWJVRQQRUTBSHEJXVXIQNOBNUIWWZLQLDHDDCQPPE[item.info.shortname]);
        }
        private void OnLootEntity(BasePlayer player, LootContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP, Item item)
        {
            if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.NPPGVZXZXVVDSSRJRZPKMIMCJQSSHQXCYRIHDOEWRCTUX) return;
            if (YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.OwnerID != 0 || player == null) return;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OHOIIGPHVKRNJNYRPOCQYDKODFLTRNSORQBGKSYOPZXA.ContainsKey(YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.ShortPrefabName)) JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(player, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OHOIIGPHVKRNJNYRPOCQYDKODFLTRNSORQBGKSYOPZXA[YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.ShortPrefabName]);
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.OwnerID = player.userID;
        }
        private void OnPluginUnloaded(Plugin name)
        {
            if (name.Title == "Better Chat") Subscribe(nameof(OnPlayerChat));
        }
        private void OpenLevels(BasePlayer player)
        {
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.VendingUse && player.inventory.loot.entitySource is NPCVendingMachine)
            {
                NPCVendingMachine PIDKDBDBMBIQJPNFVCXDUOPHASZKSHIQQBNRKKAIN = player.inventory.loot.entitySource.GetComponent<NPCVendingMachine>();
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.ListNPCVending.Contains(PIDKDBDBMBIQJPNFVCXDUOPHASZKSHIQQBNRKKAIN.shopName)) YCFUHRRYICZPADDUPLEWZKWRQROQGDIFIAGKYWVYZT(player);
            }
            else if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.VendingUse) YCFUHRRYICZPADDUPLEWZKWRQROQGDIFIAGKYWVYZT(player);
        }
        private object CanCombineDroppedItem(DroppedItem item, DroppedItem targetItem)
        {
            for (int i = 0; i < MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon.Count; i++)
            {
                if (item.GetItem().skin == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[i].SkinID)
                    if (!targetItem.GetItem().skin.Equals(item.GetItem().skin)) return false;
                if (targetItem.GetItem().skin == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[i].SkinID)
                    if (!item.GetItem().skin.Equals(targetItem.GetItem().skin)) return false;
            }
            return null;
        }
        private void ERFCWUOBUSZEILTAYDVAJOSJVHZIGPRGVKYEAFMP(BasePlayer player, int number)
        {
            if (player == null) return;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Award.ContainsKey(number))
            {
                var Award = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Award[number];
                InvItems Inventory = new InvItems(Award.Shortname, Award.Name, Award.Amount, Award.SkinID, Award.Command, Award.WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU, false);
                KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Add(Inventory);
            }
            bool contains = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.ContainsKey(number);
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PDMQOEMFNMWEHLWHDBBUASEODNYWGOFVVKALCPSPIQE)
                if (contains && MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.LYFPIOBJLNVKSMTUTCOTKSSODJENRKSPIRZMDIINACQXCAZR && permission.UserHasPermission(player.UserIDString, "xlevels.battlepass") || contains && !MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.LYFPIOBJLNVKSMTUTCOTKSSODJENRKSPIRZMDIINACQXCAZR)
                {
                    var BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP[number];
                    InvItems Inventory = new InvItems(BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.Shortname, BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.Name, BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.Amount, BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.SkinID, BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.Command, BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU, true);
                    KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Add(Inventory);
                }
        }
        private void GUI(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".Panel_GUI");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "1 0",
                                        AnchorMax = "1 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, "Hud", ".Panel_GUI");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.AnchorMin,
                                        AnchorMax = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.AnchorMax,
                                        OffsetMin = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.OffsetMin,
                                        OffsetMax = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.OffsetMax
                                },
                Image = {
                                        Color = "0.96 0.91 0.87 0.029",
                                        Material = "assets/icons/greyout.mat"
                                }
            }, ".Panel_GUI", ".GUIProgress");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "4 5",
                                        OffsetMax = "-172 -5"
                                },
                Button = {
                                        Color = "0.9 0.9 0.9 0.6",
                                        Sprite = "assets/icons/upgrade.png"
                                },
                Text = {
                                        Text = ""
                                }
            }, ".GUIProgress");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "25 3",
                                        OffsetMax = "-4 -3"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".GUIProgress", ".Progress");
            var data = StoredData[player.userID];
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = data.Level < MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ ? $"{1.0 / (data.Level * MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI + MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC) * data.XP} 1" : "1 1",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        FadeIn = 0.25f,
                                        Color = "0.269 0.208 0.348 0.9",
                                        Material = "assets/icons/greyout.mat"
                                }
            }, ".Progress");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = "-7 0"
                                },
                Text = {
                                        Text = string.Format(lang.GetMessage("LevelGUI", this, player.UserIDString), data.Level),
                                        Align = TextAnchor.MiddleRight,
                                        FontSize = 13,
                                        Color = "1 1 1 0.6"
                                }
            }, ".Progress");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "7 0",
                                        OffsetMax = "0 0"
                                },
                Text = {
                                        Text = $"XP: {Math.Round(data.XP, 2)}",
                                        Align = TextAnchor.MiddleLeft,
                                        FontSize = 13,
                                        Color = "1 1 1 0.6"
                                }
            }, ".Progress");
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private void LEUYPMLOSVKMDRQZVHOUGUFATIXMPATRFEXJYLFUOTOUHURS(BasePlayer player, int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG)
        {
            if (player.inventory.FindItemIDs(1414245162).Count == 0) return;
            int level = StoredData[player.userID].Level;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.JRCPGTFYIKWHZAWLQMJUHJHWHRPYDOJPMDQRDXDGS && level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ || level < MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ)
            {
                int xp = 0;
                foreach (var item in player.inventory.FindItemIDs(1414245162)) if (item.skin == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG].SkinID)
                    {
                        xp += MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG].XP * item.amount;
                        item.RemoveFromContainer();
                    }
                CuiHelper.DestroyUi(player, ".Inventory_Items");
                xp = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO.YISOZLTAFLKFBDEASSJMKUKCKMJLDRQTAVXQPWLOYKOO ? (int)HWLDZNGYCAIYURRRAMTNXBECVDIGBSOMHPZWURSLTDKWQHX(player, xp) : xp;
                ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(player, xp);
                AQTNVOFEGZJAIUUVFTMPQRZKSRCGRFVTLNDMOSKCFA(player);
                ExchangeInfo(player);
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.RLZAIBHOJDAULHULBZIKDPENFQKJOTGUWNYCGYFE) IHQYGOUNRZXAQKJASAISSIEMDQDQQRPAJATVJMWAMJ(player, string.Format(lang.GetMessage("ExchangeTrue", this, player.UserIDString), xp));
            }
        }
        private void OnOpenVendingShop(NPCVendingMachine PIDKDBDBMBIQJPNFVCXDUOPHASZKSHIQQBNRKKAIN, BasePlayer player)
        {
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.VendingUse && MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.ListNPCVending.Contains(PIDKDBDBMBIQJPNFVCXDUOPHASZKSHIQQBNRKKAIN.shopName))
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Vending.VendingOpen) OpenLevels(player);
                else Button(player);
        }
        private string FEXXVPQZUFGOYZSBTGZUGAKCUGMGKTYQFDJVWTKOGKE(ulong userID)
        {
            string prefix = String.Empty;
            if (StoredData.ContainsKey(userID))
            {
                if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.BBDMEBRKRSFZWTVMOWNSOHZJAHNGEUTMCFHVGZAMSBUSHYTG && MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.LVJIVPWKXJKMGSPUJVIUQPOGGUUVSTUHZIWIFDAN)
                    prefix = $"[ <color=orange>{StoredData[userID].Level}</color> ] [<color=orange>{(MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ.ContainsKey(StoredData[userID].Level) ? MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ[StoredData[userID].Level] : " ? ")}</color> ]";
                else if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.BBDMEBRKRSFZWTVMOWNSOHZJAHNGEUTMCFHVGZAMSBUSHYTG) prefix = $"[<color=orange>{StoredData[userID].Level}</color> ]";
                else if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.LVJIVPWKXJKMGSPUJVIUQPOGGUUVSTUHZIWIFDAN) prefix = $"[<color=orange>{(MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ.ContainsKey(StoredData[userID].Level) ? MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ[StoredData[userID].Level] : " ? ")}</color> ]";
            }
            return prefix;
        }
        private int YFPUWSNNSYBETVDPDKOAGQJVQWFAWLNWWEDOQSJSFL(BasePlayer player, int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG)
        {
            int xp = 0;
            foreach (var item in player.inventory.FindItemIDs(1414245162)) if (item.skin == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG].SkinID) xp += MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon[WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG].XP * item.amount;
            return MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO.YISOZLTAFLKFBDEASSJMKUKCKMJLDRQTAVXQPWLOYKOO ? (int)HWLDZNGYCAIYURRRAMTNXBECVDIGBSOMHPZWURSLTDKWQHX(player, xp) : xp;
        }
        private void GBECBQVLVVDZIVUEAMNRGKFHOROYKBWUURDTLTEJAZRBTFUSW(BasePlayer player, int Page = 0)
        {
            CuiHelper.DestroyUi(player, ".LevelO_Overlay");
            CuiHelper.DestroyUi(player, ".ExchangeInfo");
            CuiHelper.DestroyUi(player, ".Inventory_Items");
            CuiHelper.DestroyUi(player, ".Top");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 0.895",
                                        OffsetMin = "0 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Level_Overlay", ".Inventory_Items");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.38 0.5",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Inventory_Items", "Items");
            if (KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Count == 0) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Text = {
                                        Text = lang.GetMessage("InventoryEmpty", this, player.UserIDString),
                                        Align = TextAnchor.MiddleCenter,
                                        FontSize = 30,
                                        Color = "1 1 1 0.4"
                                }
            }, ".Inventory_Items");
            int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = 0, SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN = 0, WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX = 0;
            bool PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF = permission.UserHasPermission(player.UserIDString, "xlevels.battlepass");
            foreach (var inv in KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Skip(Page * 45))
            {
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = $"{-517.5 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 82)} {40 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 82)}",
                                                OffsetMax = $"{-442.5 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 82)} {115 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 82)}"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, "Items", ".Invitems");
                bool RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC = inv.NCXCRNWHSMXROHMTEFGWGBDSOEZRTYOTRVBIHXPEMYUKB && MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.ZUBUTKSFRMZJNRAUFBBMGRKUATIBVLDJNWSPRVOGHHLWJD && !PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF;
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".Invitems",
                    Name = "ButtonImage",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? (string) ImageLibrary.Call("GetImage", "BlockButtonImage") : (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 -5", OffsetMax = "5 5"
                                                }
                                        }
                });
                if (RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "1 1",
                                                AnchorMax = "1 1",
                                                OffsetMin = "-15 -12",
                                                OffsetMax = "-1.5 1.5"
                                        },
                    Image = {
                                                Color = "1 1 1 1",
                                                Sprite = "assets/icons/bp-lock.png"
                                        }
                }, ".Invitems");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".Invitems",
                    Components = {
                                                new CuiImageComponent {
                                                        ItemId = GetItemId(inv.Shortname),
                                                        SkinId = inv.SkinID, // + (inv.WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU),// == String.Empty ? 150 : 151)),
                                                        Color = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? "1 1 1 0.4" : "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "7.5 7.5", OffsetMax = "-7.5 -7.5"
                                                }
                                        }
                });
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                {
                    RectTransform = {
                                                AnchorMin = "0 0.03",
                                                AnchorMax = "0.855 1"
                                        },
                    Text = {
                                                Text = inv.Amount == 0 ? "" : $"x{inv.Amount}",
                                                Align = TextAnchor.LowerRight,
                                                FontSize = 12,
                                                Color = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? "1 1 1 0.15" : "1 1 1 0.75"
                                        }
                }, ".Invitems");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMax = "0 0"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Command = $"level_take {WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX + (Page * 39)} {Page}"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, ".Invitems", ".InvitemsTake");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".InvitemsTake",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? "" : lang.GetMessage("Take", this, player.UserIDString), Align = TextAnchor.MiddleCenter, FontSize = 12, Color = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? "0.38 0.61 0.99 0.4" : "0.7 0.64 0.7 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0"
                                                },
                                                new CuiOutlineComponent {
                                                        Color = RXYVVGMXHMZFOMOFOUXEATGELGPBKIGSRRMBSXCIHUNOICIC ? "0 0 0 0.4" : "0 0 0 1", Distance = "-1 1"
                                                }
                                        }
                });
                WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG++;
                WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX++;
                if (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG == 9)
                {
                    WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = 0;
                    SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN++;
                    if (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN == 5) break;
                }
            }
            string GJANXWYRUKORLNZGHNXAMMQROWGFRVIYMLDYGEUVOKYNOR = $"level page_inv back {Page}";
            string HNIBOLCDUSIZAQSZYBQEAJAZCTCMCNCDWAZRJTTMJHIFXFUF = $"level page_inv next {Page}";
            bool KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG = Page != 0;
            bool PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW = KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Count > ((Page + 1) * 45);
            var TMKSBFMURBSSXJQSKAYYFIVUPRXMXJSCDNYNPASJJUTHIJOO = Page + 1;
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".Inventory_Items", ".InventoryItems" + ".PS");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".InventoryItems" + ".PS", "LabelPage");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Text = {
                                        Text = lang.GetMessage("PAGE", this, player.UserIDString) + " " + (Page + 1).ToString(),
                                        FontSize = 25,
                                        Font = "robotocondensed-regular.ttf",
                                        Align = TextAnchor.MiddleCenter,
                                        Color = "0.929 0.882 0.847 0.8"
                                }
            }, "LabelPage", "ThisLabel");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.15 0",
                                        AnchorMax = "0.29 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, ".InventoryItems" + ".PS", ".InventoryItems" + ".PS.L");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? GJANXWYRUKORLNZGHNXAMMQROWGFRVIYMLDYGEUVOKYNOR : ""
                                },
                Text = {
                                        Text = "<b><</b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, ".InventoryItems" + ".PS.L");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.71 0",
                                        AnchorMax = "0.85 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, ".InventoryItems" + ".PS", ".InventoryItems" + ".PS.R");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? HNIBOLCDUSIZAQSZYBQEAJAZCTCMCNCDWAZRJTTMJHIFXFUF : ""
                                },
                Text = {
                                        Text = "<b>></b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, ".InventoryItems" + ".PS.R");
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private void OnCollectiblePickup(CollectibleEntity collectible, BasePlayer player)
        {
            if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.JMHUBTIIBJJNGTZLGPJPTQXYEGMLLHBUFGKSYWPLVFEEWG) return;
            if (collectible == null || player == null) return;
            foreach (ItemAmount item in collectible.itemList) if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OHIYMHUCTLXOLFXYTWRMAFPWBZNMHBBOGGPMLOQYMTNODYGVW.ContainsKey(item.itemDef.shortname)) JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(player, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OHIYMHUCTLXOLFXYTWRMAFPWBZNMHBBOGGPMLOQYMTNODYGVW[item.itemDef.shortname]);
        }
        private void JFSURVWWOJCXAUYIFQSBSHIDQHTDOJWVCWSQCZZHWOEVH(BasePlayer player, int number, int page)
        {
            if (player == null) return;
            var QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI = KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID][number];
            if (QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.NCXCRNWHSMXROHMTEFGWGBDSOEZRTYOTRVBIHXPEMYUKB && MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.ZUBUTKSFRMZJNRAUFBBMGRKUATIBVLDJNWSPRVOGHHLWJD && !permission.UserHasPermission(player.UserIDString, "xlevels.battlepass")) return;
            if (QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Command != String.Empty) Server.Command($"{QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Command}".Replace("%STEAMID%", player.UserIDString));
            else
            {
                Item item = ItemManager.CreateByName(QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Shortname, QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Amount, QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.SkinID);
                item.name = QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Name;
                player.GiveItem(item);
            }
            KCXWWYFMYEMOZRCKECIYAMKJOKFAHSIGNWYOGEKOALST[player.userID].Remove(QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI);
            EffectNetwork.Send(new Effect("assets/bundled/prefabs/fx/weapons/survey_charge/survey_charge_stick.prefab", player, 0, new Vector3(), new Vector3()), player.Connection);
            GBECBQVLVVDZIVUEAMNRGKFHOROYKBWUURDTLTEJAZRBTFUSW(player, page);
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.RLZAIBHOJDAULHULBZIKDPENFQKJOTGUWNYCGYFE) IHQYGOUNRZXAQKJASAISSIEMDQDQQRPAJATVJMWAMJ(player, string.Format(lang.GetMessage("TakeItem", this, player.UserIDString), QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Name, QIDKYQKQQCJHZXIJPOKKDDKHPOKONLGDJXGAORFWNWYXI.Amount));
        }
        private int YWCLZDAUVBXOEKCSIFMGUECHFFRKEDCMWNIWADJSV(ulong userID) => StoredData.ContainsKey(userID) ? StoredData[userID].Level : 0;
        private Dictionary<ulong, XLevelsData> StoredData = new Dictionary<ulong, XLevelsData>();
        private object OnPlayerChat(BasePlayer player, string message, Chat.ChatChannel XTKONVIJEQOYOGYUCPCDUGDTXHUSRWJQTGNFSBKHXPTXHJY)
        {
            string prefix = FEXXVPQZUFGOYZSBTGZUGAKCUGMGKTYQFDJVWTKOGKE(player.userID);
            if (String.IsNullOrEmpty(prefix)) return null;
            if (XTKONVIJEQOYOGYUCPCDUGDTXHUSRWJQTGNFSBKHXPTXHJY == ConVar.Chat.ChatChannel.Team) return null;
            else
            {
                PrintToChat($"{prefix} | " + $"<color=#538fef>{player.displayName}</color>: " + message);
                return true;
            }
        }
        private void AQTNVOFEGZJAIUUVFTMPQRZKSRCGRFVTLNDMOSKCFA(BasePlayer player, int Page = 0)
        {
            CuiHelper.DestroyUi(player, ".Pass");
            CuiHelper.DestroyUi(player, ".LevelO_Overlay" + ".PS");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "360 122.5",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".LevelO_Overlay", ".Pass");
            int FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW = Page * 6;
            int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = 0, g = 0, WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX = 0 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW, YJZAIYHJSWOQYYDIPTKSIZDSXTBQYYZYIMUFLLZUIP = 0 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW;
            var data = StoredData[player.userID];
            bool EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.PDMQOEMFNMWEHLWHDBBUASEODNYWGOFVVKALCPSPIQE;
            bool PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF = permission.UserHasPermission(player.UserIDString, "xlevels.battlepass");
            for (int i = 1 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW; i <= 6 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW; i++)
            {
                bool ENXYGLDWDZEXZGHCOXQLUWPHLEXWEUPJTNYFAUUFUBWZ = data.Level >= i, contains = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Award.ContainsKey(i), OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.JLOVTSJQIKHOLSSTVMYOEOXEDGMYKMODOUIVIUVIOQARRK;
                if (!OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS || OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS && contains)
                {
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        RectTransform = {
                                                        AnchorMin = "0.5 0.5",
                                                        AnchorMax = "0.5 0.5",
                                                        OffsetMin = $"{-475 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 95)} {(EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI ? -31.25 : -82.5)}",
                                                        OffsetMax = $"{-380 + (WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG * 95)} {(EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI ? 63.75 : 12.5)}"
                                                },
                        Image = {
                                                        Color = "0 0 0 0"
                                                }
                    }, ".Pass", ".Award");
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                    {
                        Parent = ".Award",
                        Name = ".Awards",
                        Components = {
                                                        new CuiRawImageComponent {
                                                                Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 -5", OffsetMax = "5 5"
                                                        }
                                                }
                    });
                    YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                    {
                        RectTransform = {
                                                        AnchorMin = "0 0",
                                                        AnchorMax = "1 1",
                                                        OffsetMin = "45 -9.5",
                                                        OffsetMax = "-45 -91"
                                                },
                        Image = {
                                                        Color = "0.20 0.20 0.24 1"
                                                }
                    }, ".Award");
                    if (contains)
                    {
                        var PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Award[i];
                        YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                        {
                            Parent = ".Awards",
                            Components = {
                                                                new CuiImageComponent {
                                                                    ItemId = GetItemId(PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB.Shortname),
                                                                    SkinId = PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB.SkinID,// + (PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB.WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU == String.Empty ? 150 : 151))
                                                                },
                                                                new CuiRectTransformComponent {
                                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "17.5 17.5", OffsetMax = "-17.5 -17.5"
                                                                }
                                                        }
                        });
                        YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                        {
                            RectTransform = {
                                                                AnchorMin = "0 0.08",
                                                                AnchorMax = "0.825 1"
                                                        },
                            Text = {
                                                                Text = PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB.Amount == 0 ? "" : $"x{PVQIKHSRNJNPKLISCHRUGNYIGNPRQPWARBNQRTRLKTCIMB.Amount}",
                                                                Align = TextAnchor.LowerRight,
                                                                FontSize = 12,
                                                                Color = "1 1 1 0.75"
                                                        }
                        }, ".Awards");
                    }
                    if (ENXYGLDWDZEXZGHCOXQLUWPHLEXWEUPJTNYFAUUFUBWZ) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                    {
                        Parent = ".Awards",
                        Components = {
                                                        new CuiImageComponent {
                                                                Color = "0.7 0.64 0.7 1", Sprite = "assets/icons/check.png"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-25 -25", OffsetMax = "25 25"
                                                        },
                                                        new CuiOutlineComponent {
                                                                Color = "0 0 0 1", Distance = "-0.6 0.6"
                                                        }
                                                }
                    });
                    else if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.RYEJCTOMVNJRMFLFVWEZRKXKAQPAONGMTEVAFCLKZ) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                    {
                        Parent = ".Awards",
                        Components = {
                                                        new CuiTextComponent {
                                                                Text = $"{i}", Align = TextAnchor.MiddleCenter, FontSize = 27, Color = "0.7 0.64 0.7 1"
                                                        },
                                                        new CuiRectTransformComponent {
                                                                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0"
                                                        },
                                                        new CuiOutlineComponent {
                                                                Color = "0 0 0 1", Distance = "-0.6 0.6"
                                                        }
                                                }
                    });
                }
                WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG++;
                WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX++;
                if (WGAVZNHLRYLKTTLGJOUHYOQJGGXBEWTUNFARMGHOCHVKGGRCX == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ) break;
            }
            if (EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI)
                for (int i = 1 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW; i <= 6 + FMSCSWVQRSTBBDHHEEULQGEJKWIFSSPLLHTPYEBBNXFOLMXJW; i++)
                {
                    bool ENXYGLDWDZEXZGHCOXQLUWPHLEXWEUPJTNYFAUUFUBWZ = data.Level >= i, contains = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP.ContainsKey(i), OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.JLOVTSJQIKHOLSSTVMYOEOXEDGMYKMODOUIVIUVIOQARRK;
                    if (!OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS || OUZEILXRDRIXPMBNGRIJUDMHBBTCKQSAQCXKXRVIS && contains)
                    {
                        YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                        {
                            RectTransform = {
                                                                AnchorMin = "0.5 0.5",
                                                                AnchorMax = "0.5 0.5",
                                                                OffsetMin = $"{-475 + (g * 95)} -166.25",
                                                                OffsetMax = $"{-380 + (g * 95)} -71.25"
                                                        },
                            Image = {
                                                                Color = "0 0 0 0"
                                                        }
                        }, ".Pass", ".Award");
                        if (!PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF)
                        {
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                            {
                                Parent = ".Award",
                                Name = ".Awards",
                                Components = {
                                                                        new CuiRawImageComponent {
                                                                                Png = (string) ImageLibrary.Call("GetImage", "BlockButtonImage"), Color = "1 1 1 1"
                                                                        },
                                                                        new CuiRectTransformComponent {
                                                                                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 -5", OffsetMax = "5 5"
                                                                        }
                                                                }
                            });
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                            {
                                RectTransform = {
                                                                        AnchorMin = "0.5 1",
                                                                        AnchorMax = "0.5 1",
                                                                        OffsetMin = "-2.5 -3.5",
                                                                        OffsetMax = "2.5 10"
                                                                },
                                Image = {
                                                                        Color = "0.20 0.20 0.24 1"
                                                                }
                            }, ".Award");
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                            {
                                RectTransform = {
                                                                        AnchorMin = "1 1",
                                                                        AnchorMax = "1 1",
                                                                        OffsetMin = "-17 -16",
                                                                        OffsetMax = "-1.5 -0.5"
                                                                },
                                Image = {
                                                                        Color = "1 1 1 1",
                                                                        Sprite = "assets/icons/bp-lock.png"
                                                                }
                            }, ".Award");
                        }
                        else
                        {
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                            {
                                Parent = ".Award",
                                Name = ".Awards",
                                Components = {
                                                                        new CuiRawImageComponent {
                                                                                Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
                                                                        },
                                                                        new CuiRectTransformComponent {
                                                                                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "-5 -5", OffsetMax = "5 5"
                                                                        }
                                                                }
                            });
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                            {
                                RectTransform = {
                                                                        AnchorMin = "0.5 1",
                                                                        AnchorMax = "0.5 1",
                                                                        OffsetMin = "-2.5 -2.5",
                                                                        OffsetMax = "2.5 10"
                                                                },
                                Image = {
                                                                        Color = "0.78 0.74 0.7 0.05",
                                                                        Material = "assets/content/ui/uibackgroundblur.mat"
                                                                }
                            }, ".Award");
                        }
                        if (contains)
                        {
                            var LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.BPHJKPIBZZWWWEKECFXFMMNBPYJLGQCGDACLNYMEOSGCP[i];
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                            {
                                Parent = ".Awards",
                                Components = {
                                                                        new CuiImageComponent {
                                                                            ItemId = GetItemId(LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.Shortname),
                                                                            SkinId = LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.SkinID,//Png = (string) ImageLibrary.Call("GetImage", LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.Shortname + (LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.WEWQPWWLWXLSKOCOEYJYKHAVTNMGIEHMNONHPUSPEPIIU == String.Empty ? 150 : 151)),
                                                                            Color = PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF ? "1 1 1 1" : "1 1 1 0.5"
                                                                        },
                                                                        new CuiRectTransformComponent {
                                                                                AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "17.5 17.5", OffsetMax = "-17.5 -17.5"
                                                                        }
                                                                }
                            });
                            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                            {
                                RectTransform = {
                                                                        AnchorMin = "0 0.08",
                                                                        AnchorMax = "0.825 1"
                                                                },
                                Text = {
                                                                        Text = LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.Amount == 0 ? "" : $"x{LBFOORXLCWHBXRABYNNXIXSAJPFKNLQVFVEQLAHITQLTJR.Amount}",
                                                                        Align = TextAnchor.LowerRight,
                                                                        FontSize = 12,
                                                                        Color = PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF ? "1 1 1 0.75" : "1 1 1 0.45"
                                                                }
                            }, ".Awards");
                        }
                        if (ENXYGLDWDZEXZGHCOXQLUWPHLEXWEUPJTNYFAUUFUBWZ) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                        {
                            Parent = ".Awards",
                            Components = {
                                                                new CuiImageComponent {
                                                                        Color = PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF ? "0.7 0.64 0.7 1" : "0 0 0 0", Sprite = PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF ? "assets/icons/check.png" : "assets/content/textures/generic/fulltransparent.tga"
                                                                },
                                                                new CuiRectTransformComponent {
                                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-25 -25", OffsetMax = "25 25"
                                                                },
                                                                new CuiOutlineComponent {
                                                                        Color = "0 0 0 1", Distance = "-0.6 0.6"
                                                                }
                                                        }
                        });
                        if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.GUI.NIZCICDKFVNKLHBUILEOYHHWYIKKASKTAIWOKXIMXEH) YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                        {
                            Parent = ".Awards",
                            Components = {
                                                                new CuiTextComponent {
                                                                        Text = ENXYGLDWDZEXZGHCOXQLUWPHLEXWEUPJTNYFAUUFUBWZ && PHZCLMKVUXHWOVXRPMWVILWQBKKQXSKKAKJVLHFIDYBXXHSF ? "" : $"{i}", Align = TextAnchor.MiddleCenter, FontSize = 27, Color = "0.7 0.64 0.7 1"
                                                                },
                                                                new CuiRectTransformComponent {
                                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0"
                                                                },
                                                                new CuiOutlineComponent {
                                                                        Color = "0 0 0 1", Distance = "-0.6 -0.6"
                                                                }
                                                        }
                        });
                    }
                    g++;
                    YJZAIYHJSWOQYYDIPTKSIZDSXTBQYYZYIMUFLLZUIP++;
                    if (YJZAIYHJSWOQYYDIPTKSIZDSXTBQYYZYIMUFLLZUIP == MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ) break;
                }
            string GJANXWYRUKORLNZGHNXAMMQROWGFRVIYMLDYGEUVOKYNOR = $"level page_lvl back {Page}";
            string HNIBOLCDUSIZAQSZYBQEAJAZCTCMCNCDWAZRJTTMJHIFXFUF = $"level page_lvl next {Page}";
            bool KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG = Page != 0;
            bool PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ > ((Page + 1) * 6);
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".LevelO_Overlay", ".LevelO_Overlay" + ".PS");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
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
            }, ".LevelO_Overlay" + ".PS", "LabelPage");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1"
                                },
                Text = {
                                        Text = lang.GetMessage("PAGE", this, player.UserIDString) + " " + (Page + 1).ToString(),
                                        FontSize = 25,
                                        Font = "robotocondensed-regular.ttf",
                                        Align = TextAnchor.MiddleCenter,
                                        Color = "0.929 0.882 0.847 0.8"
                                }
            }, "LabelPage", "ThisLabel");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.15 0",
                                        AnchorMax = "0.29 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, ".LevelO_Overlay" + ".PS", ".LevelO_Overlay" + ".PS.L");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? GJANXWYRUKORLNZGHNXAMMQROWGFRVIYMLDYGEUVOKYNOR : ""
                                },
                Text = {
                                        Text = "<b><</b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = KZMYMVXNIZVIQAGQFCZQBQFHDVSAVBWZXQROQFJFBEAUYDSG ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, ".LevelO_Overlay" + ".PS.L");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0.71 0",
                                        AnchorMax = "0.85 1",
                                        OffsetMin = $"0 0",
                                        OffsetMax = "-0 -0"
                                },
                Image = {
                                        Color = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? "0.196 0.200 0.239 1.8" : "0.196 0.200 0.239 0.4"
                                }
            }, ".LevelO_Overlay" + ".PS", ".LevelO_Overlay" + ".PS.R");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Button = {
                                        Color = "0 0 0 0",
                                        Command = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? HNIBOLCDUSIZAQSZYBQEAJAZCTCMCNCDWAZRJTTMJHIFXFUF : ""
                                },
                Text = {
                                        Text = "<b>></b>",
                                        Font = "robotocondensed-bold.ttf",
                                        FontSize = 35,
                                        Align = TextAnchor.MiddleCenter,
                                        Color = PSDUOUUUEURDWSGCWLAJSZASUPWPLJACLYFJTEJW ? "0.61 0.63 0.97 1" : "0.61 0.63 0.97 0.15"
                                }
            }, ".LevelO_Overlay" + ".PS.R");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "0 0",
                                        OffsetMin = "45 224",
                                        OffsetMax = $"40 224.5"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Pass", ".PassMain");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = $"-322.5 {(EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI ? -61.25 : -112.5)}",
                                        OffsetMax = $"322.5 {(EJUWCGVTADZDRKDHRVFRKTNAZUJGYCLJRUOUVUEEHACQHPKI ? -41.25 : -92.5)}"
                                },
                Image = {
                                        Color = "0.5 0.5 0.5 0.45"
                                }
            }, ".PassMain", ".PassLevel");
            float SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN = (data.Level - (Page * 6.0f)) / 6.0f;
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "0 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN >= 1 ? "640 0" : SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN < 0 ? "0 0" : $"{95 * (data.Level % 6) - 10} 0"
                                },
                Image = {
                                        Color = "0.269 0.208 0.348 1",
                                        Sprite = "assets/content/ui/ui.background.transparent.radial.psd"
                                }
            }, ".PassLevel");
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMin = "0 0",
                                        OffsetMax = "-7 0"
                                },
                Text = {
                                        Text = string.Format(lang.GetMessage(data.Level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ ? "Level_2" : "Level", this, player.UserIDString), data.Level, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ, Math.Round(data.XP, 2), data.Level * MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PDTRLXKEZIPHASWCKOQGSSAKIULPYQXILWJNLGNJTMUJMISI + MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.ZYUTSNHJNYLJMRMYOMMUPRINSZRFYZHERTRBPTBXVZUAC, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ.Count == 0 ? String.Empty : string.Format(lang.GetMessage("RANK", this, player.UserIDString), MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ.ContainsKey(data.Level) ? MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.KQCXYYEKHKHTACQKFIPWRZLDJMVEZFOKXFXLTOELILLFJ[data.Level] : "?")),
                                        Align = TextAnchor.MiddleCenter,
                                        FontSize = 13,
                                        Color = "1 1 1 0.75"
                                }
            }, ".PassLevel");
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private int YWCLZDAUVBXOEKCSIFMGUECHFFRKEDCMWNIWADJSV(BasePlayer player) => StoredData.ContainsKey(player.userID) ? StoredData[player.userID].Level : 0;
        private void CDVENCFXPGFRJQIVEMZMAEQPUQHHNJKKPUXHWMPEMHFMFWUWF(BasePlayer player)
        {
            foreach (var perm in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.LMYMLWVXDPEDVGZEXUATEXZDCTXHVSRXPHMWOGPZK.Permisssion) if (permission.UserHasPermission(player.UserIDString, perm.Key))
                {
                    ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(player, perm.Value);
                    break;
                }
        }
        private string IWWRJDRXFSLZFZDCRTAMPUYHPHBWTRUUHFDTWYNFUR(ulong userID) => FEXXVPQZUFGOYZSBTGZUGAKCUGMGKTYQFDJVWTKOGKE(userID);
        private void ExchangeInfo(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, ".Inventory_Items");
            CuiHelper.DestroyUi(player, ".LevelO_Overlay");
            CuiHelper.DestroyUi(player, ".ExchangeInfo");
            CuiHelper.DestroyUi(player, ".Top");
            CuiElementContainer YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP = new CuiElementContainer();
            YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
            {
                RectTransform = {
                                        AnchorMin = "0 0",
                                        AnchorMax = "1 1",
                                        OffsetMax = "0 0"
                                },
                Image = {
                                        Color = "0 0 0 0"
                                }
            }, ".Level_Overlay", ".ExchangeInfo");
            int WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG = 0;
            int SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN = 0;
            int GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB = 0;
            int level = StoredData[player.userID].Level;
            foreach (var coupon in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Coupon)
            {
                int xp = YFPUWSNNSYBETVDPDKOAGQJVQWFAWLNWWEDOQSJSFL(player, WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG);
                bool UJRDVZDJOJEFYLNXRGMWBNKQXFEDSMYRRVLBVHVWBMPGGVJ = MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.JRCPGTFYIKWHZAWLQMJUHJHWHRPYDOJPMDQRDXDGS && level >= MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ && xp != 0 || level < MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Level.PNZUIMIBGXXXZGAYBMLOZRCQIRAKNTKDIHYNGBVGPAKXZ && xp != 0;
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = $"{-370 + (GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB * 242)} {15 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 202)}",
                                                OffsetMax = $"{-110 + (GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB * 242)} {215 - (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN * 202)}"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, ".ExchangeInfo", ".Coupon");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiPanel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "10 10",
                                                OffsetMax = "-10 -10"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, ".Coupon", ".CouponBlocks");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".CouponBlocks",
                    Name = "Btn",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "15 0", OffsetMax = "-15 0"
                                                }
                                        }
                });
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiElement
                {
                    Parent = ".CouponBlocks",
                    Components = {
                                                new CuiImageComponent {
                                                    ItemId = GetItemId(coupon.ShortName),//  coupon.SkinID.ToString())
                                                    SkinId = coupon.SkinID,//  coupon.SkinID.ToString())
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-60 -60", OffsetMax = "60 60"
                                                }
                                        }
                });
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiLabel
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0",
                                                OffsetMin = "0 15",
                                                OffsetMax = "0 30"
                                        },
                    Text = {
                                                Text = string.Format(lang.GetMessage("XP", this, player.UserIDString), xp),
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-regular.ttf",
                                                FontSize = 11,
                                                Color = "1 1 1 0.5"
                                        }
                }, ".CouponBlocks");
                YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0.2 0",
                                                AnchorMax = "0.8 0",
                                                OffsetMin = "0 -10",
                                                OffsetMax = "0 10"
                                        },
                    Button = {
                                                Color = UJRDVZDJOJEFYLNXRGMWBNKQXFEDSMYRRVLBVHVWBMPGGVJ ? "0.376 0.384 0.459 0.5" : "0.417 0.421 0.409 0.15",
                                                Command = UJRDVZDJOJEFYLNXRGMWBNKQXFEDSMYRRVLBVHVWBMPGGVJ ? $"level exchange {WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG}" : ""
                                        },
                    Text = {
                                                Text = lang.GetMessage("Exchange", this, player.UserIDString),
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 14,
                                                Color = UJRDVZDJOJEFYLNXRGMWBNKQXFEDSMYRRVLBVHVWBMPGGVJ ? "0.75 0.75 0.75 1" : "0.75 0.75 0.75 0.2"
                                        }
                }, ".CouponBlocks");
                WFRYNAAFFBLHQGVVEPTYIEMQXLCIMTVZRJFRXGCSRG++;
                GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB++;
                if (GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB == 3)
                {
                    GISFZIPROTQGHUFRXNSUTCGFERSGCAOVDJQLCHGSBUSOYWAB = 0;
                    SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN++;
                    if (SDOTLXQJTKVWSSBABXRTLGLPHADXYNBHCKTMJSQLVJBPWMN == 2) break;
                }
            }
            CuiHelper.AddUi(player, YLIGMRYYROGJUESPFTJEIUUUIYLZDPYDFZXOVIMPMQXLEP);
        }
        private void JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(BasePlayer player, float xp)
        {
            foreach (var perm in MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.IFIRPVWZAWVBUPBDUMJPDMYIMSBVGWZWXSWDVYUSSO.RNHTHUEUVAEXPDNBIXOUQFFFNKWGUOAFWDSYCRVXMZFVSTZSY) if (permission.UserHasPermission(player.UserIDString, perm.Key))
                {
                    xp *= perm.Value;
                    break;
                }
            ZEBXQLTVHQJYETMNIVWDTULPYLLQSPWJLOZOFSNVHACRVQ(player, xp);
        }
        private void OnGrowableGather(GrowableEntity NVVVBLXQQRQGBQRHHXFHSSCAFVGFNFMNIMEWBNPHIWP, BasePlayer player)
        {
            if (!MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.Setting.FSDWJRBWTPIPVGWWTHPHAIGMJAXTNMSBYFHTIKSC) return;
            if (NVVVBLXQQRQGBQRHHXFHSSCAFVGFNFMNIMEWBNPHIWP == null || player == null) return;
            if (MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OCCUZJRLXMTHURJIHEPKNFFSZHSBTCTRPNNZLMHGUAQEEEY.ContainsKey(NVVVBLXQQRQGBQRHHXFHSSCAFVGFNFMNIMEWBNPHIWP.ShortPrefabName)) JUFDDYOTKODAKVLZJWTCBRARUIHPELMVZLADRHYSPATNUY(player, MQSUTKGKWXESSHQMZBTFNPVRZEJDQJNOOFIHZGAYYRQZT.XP.OCCUZJRLXMTHURJIHEPKNFFSZHSBTCTRPNNZLMHGUAQEEEY[NVVVBLXQQRQGBQRHHXFHSSCAFVGFNFMNIMEWBNPHIWP.ShortPrefabName]);
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