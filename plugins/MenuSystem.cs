 /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ using Oxide.Core.Plugins;
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
using UnityEngine.Networking;
using System.Collections;
using SilentOrbit.ProtocolBuffers;

namespace Oxide.Plugins
{
    /* СКАЧАНО С https://discord.gg/k3hXsVua7Q */ [Info("MenuSystem", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class MenuSystem : RustPlugin
    {
        private string KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG = "MS_UI";
        private float FadeIn = 0.25f;
        public string ILTWZHVIKJVSTNTEYYICFHHKFFAJDAMMPGRMGYTVZNGYMVE = "";
        [PluginReference] private Plugin Duel, ImageLibrary;
        private bool PVESTOVSNUXCKDEMDIPGGIFZJHTAWAESPGMWYKQLBONUFNYD(BasePlayer player) => Duel?.Call<bool>("IsPlayerOnActiveDuel", player) ?? false;
        public class MenuItem : SubMenuItem
        {
            [JsonProperty("Пункты подменю", Order = 0)] public List<SubMenuItem> items;
        }
        public class SubMenuItem
        {
            [JsonProperty("Заголовок")] public Dictionary<string, string> HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN;
            [JsonProperty("Sprite")] public string WBDSRAAJELUAWZVLHTCKIOACRTFYBTGXPIEGTRJDCMQ = "assets/icons/community_servers.png";
            [JsonProperty("Чат команда для доступа к пункту меню")] public string chatCommand;
            [JsonProperty("Имя плагина, api которого необходимо вызвать")] public string LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM;
            [JsonProperty("Имя функции из плагина для показа GUI")] public string WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS;
            [JsonProperty("Передаваемые аргументы (player - передавать не нужно он передается первым параметром)")] public List<object> CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY = new List<object>();
            [JsonProperty("Названия слоев для дестроя GUI")] public List<string> BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO = new List<string>();
            [JsonProperty("Имя функции из плагина для дополнительной отработки закрытия")] public string YLPQCNPVFDHXIJTBXCNZETUSZNZLMMJGPUGNXFGGIS;
        }
        public class Settings
        {
            [JsonProperty("Название кнопки")] public string DisplayName;
            [JsonProperty("Описание")] public string Info;
            [JsonProperty("Команда")] public string Command;
        }
        public Dictionary<ulong, SubMenuItem> OTLBBVXBCIPBFQXQONDITUBHNDGESVGRMMGZOLYQOK = new Dictionary<ulong, SubMenuItem>();
        Configuration config;
        class Configuration
        {
            [JsonProperty("Настройки")] public InterfaceSettings InterfaceSetting = new InterfaceSettings();
            internal class InterfaceSettings
            {
                [JsonProperty("Включить логотип?")] public bool HENUYAQMKUMUHTOBEVEVUHRTOOMVLNFQXPGRHBHPPRDQY;
                [JsonProperty("Ссылка на логотип (150x150)")] public string LogoLink;
                [JsonProperty("Открывать меню при подключении к серверу")] public bool QGBDCXKGIGCGGRWNZQLYCSTBZLXFSGHQMLMWZRMBEMZWMPF;
                [JsonProperty("Использовать уведомления в консоль")] public bool JRNFMDRXNZDRAFOCZLTUEANHDJTQTXOKFTWATBEIU;
            }
            [JsonProperty("Пункты меню")] public Dictionary<string, MenuItem> JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO;
            [JsonProperty("Версия конфигурации")] public VersionNumber KQYYATFUJWCCFSZGFGKACPGESZCAEXWQXHWCUPKWKBVXZW = new VersionNumber();
            public static Configuration GetNewConfig()
            {
                return new Configuration
                {
                    InterfaceSetting = new InterfaceSettings()
                    {
                        HENUYAQMKUMUHTOBEVEVUHRTOOMVLNFQXPGRHBHPPRDQY = true,
                        LogoLink = "https://i.imgur.com/2iCpDT7.png",
                        QGBDCXKGIGCGGRWNZQLYCSTBZLXFSGHQMLMWZRMBEMZWMPF = true,
                        JRNFMDRXNZDRAFOCZLTUEANHDJTQTXOKFTWATBEIU = false
                    },
                    JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO = new Dictionary<string, MenuItem>() { },
                    KQYYATFUJWCCFSZGFGKACPGESZCAEXWQXHWCUPKWKBVXZW = new VersionNumber(2, 0, 0)
                };
            }
        }
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                config = Config.ReadObject<Configuration>();
                if (config?.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO == null) LoadDefaultConfig();
                if (config.KQYYATFUJWCCFSZGFGKACPGESZCAEXWQXHWCUPKWKBVXZW < Version) LoadDefaultConfig();
                config.KQYYATFUJWCCFSZGFGKACPGESZCAEXWQXHWCUPKWKBVXZW = Version;
            }
            catch
            {
                PrintWarning($"Ошибка чтения конфигурации 'oxide/config/{Name}', создаём новую конфигурацию!!");
                LoadDefaultConfig();
            }
            NextTick(SaveConfig);
        }
        protected override void LoadDefaultConfig() => config = Configuration.GetNewConfig();
        protected override void SaveConfig() => Config.WriteObject(config);
        void OnServerInitialized()
        {
            fRXLBBEVFZPKQJWTSMHUURCOLTDQJVBKAWQULMWDSMBX();
            AFEEWPGPFIMVVWMPFNDRINSSEERVLTVJPSVVAOSRFGS();
            foreach (var player in BasePlayer.activePlayerList) CuiHelper.DestroyUi(player, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG);
            DPGRBFAAVMZMNLASXLELMDGDBRPQULLCUQOOYZTG();
            BasePlayer.activePlayerList.ToList().ForEach(OnPlayerConnected);
            DASZUQBPZVZGQYKXKSPLCYHTSOKQPWFTBYYHXFVTVF();
        }
        void AFEEWPGPFIMVVWMPFNDRINSSEERVLTVJPSVVAOSRFGS()
        {
            foreach (MenuItem ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB in config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.Values)
            {
                if (!string.IsNullOrEmpty(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.chatCommand)) Interface.Oxide.GetLibrary<ru.Libraries.Command>(null).AddChatCommand(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.chatCommand, this, "MenuChatCommands");
                if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items == null) continue;
                foreach (SubMenuItem item2 in ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items.Where(x => !string.IsNullOrEmpty(x.chatCommand)))
                {
                    Interface.Oxide.GetLibrary<ru.Libraries.Command>(null).AddChatCommand(item2.chatCommand, this, "SubMenuChatCommands");
                }
            }
        }
        void OnPlayerConnected(BasePlayer player)
        {
            if (config.InterfaceSetting.QGBDCXKGIGCGGRWNZQLYCSTBZLXFSGHQMLMWZRMBEMZWMPF)
            {
                if (player.IsReceivingSnapshot)
                {
                    timer.In(2f, () => OnPlayerConnected(player));
                    return;
                }
                PPCZSWBCBDDGHWSJYQWMLIGEXKNQDAFCDSGWUTBQ(player, "menu", false);
                return;
            }
        }
        void DPGRBFAAVMZMNLASXLELMDGDBRPQULLCUQOOYZTG()
        {
           //ServerMgr.Instance.StartCoroutine(DownloadImage());

            // if (config.InterfaceSetting.HENUYAQMKUMUHTOBEVEVUHRTOOMVLNFQXPGRHBHPPRDQY) ImageLibrary.Call("AddImage", config.InterfaceSetting.LogoLink, "LogoImage");


            //if (config.InterfaceSetting.HENUYAQMKUMUHTOBEVEVUHRTOOMVLNFQXPGRHBHPPRDQY) ImageLibrary.Call("AddImage", config.InterfaceSetting.LogoLink, "LogoImage");
            // foreach (var Key in Image)
            //{
            //    ImageLibrary.Call("AddImage", $"https://api-methods.st8.ru/v2/menu/{Key}.png", Key);
            //}

        }

        private IEnumerator DownloadImage()
        {
            yield return SaveImage("https://api-methods.st8.ru/v2/profile/promo", "C:\\Server Rust\\oxide\\Images\\123\\Promo.png");//
        }

        public IEnumerator SaveImage(string url, string path)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                yield return request.SendWebRequest();

                Puts(request.isDone.ToString());

                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());
                    // Делаем что-то с загруженным изображением, например, устанавливаем его на объект в сцене
                    // GameObject.GetComponent<Renderer>().material.mainTexture = texture;
                }

            }
        }


        private void MenuChatCommands(BasePlayer player, string command, string[] CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY) => PPCZSWBCBDDGHWSJYQWMLIGEXKNQDAFCDSGWUTBQ(player, command);
        private void SubMenuChatCommands(BasePlayer player, string command, string[] CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY) => PPCZSWBCBDDGHWSJYQWMLIGEXKNQDAFCDSGWUTBQ(player, command, true);
        [ConsoleCommand("closemenusystem")]
        void CJBPBYJANWNYZDCZDLIADCNRZNOIVGGVTFVCECWBGFZ(ConsoleSystem.Arg CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY)
        {
            var player = CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Player();
            DestroyUI(player);
            CuiHelper.DestroyUi(player, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG);
            ZLELIQOUENJOIOGJXBHJKZBYACOPWOEOGTLXBSOUYWYMVOV(player);
        }
        public void XWESGIWDZHFAWKPOKAFGPRFUIZVAPGUXCSTDJWBNKDVMAUFT(BasePlayer player)
        {
            DestroyUI(player);
            CuiHelper.DestroyUi(player, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG);
            ZLELIQOUENJOIOGJXBHJKZBYACOPWOEOGTLXBSOUYWYMVOV(player);
        }
        [ConsoleCommand("menu")]
        void HRFASFFRKKGMVNTMHXERLEOYSVMWTTNUBMHOPXKNOLZLU(ConsoleSystem.Arg CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY)
        {
            var player = CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Player();
            DestroyUI(player);
            NVHITAYIEBFGARFRFGWUZVDYYQJOXWAJDRVLWDTKOSKB(player, CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args[0]);
        }
        void PPCZSWBCBDDGHWSJYQWMLIGEXKNQDAFCDSGWUTBQ(BasePlayer player, string VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK = "menu", bool BQDVXCCVQKFIFWGFCIVDIFLTERLJPKZWDOKDVILXKTKBWSAV = false)
        {
            if (PVESTOVSNUXCKDEMDIPGGIFZJHTAWAESPGMWYKQLBONUFNYD(player))
            {
                SendReply(player, "Меню недоступно на дуэли!");
                return;
            }
            int ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL = 0;
            if (BQDVXCCVQKFIFWGFCIVDIFLTERLJPKZWDOKDVILXKTKBWSAV)
            {
                DestroySubUI(player, VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK);
                foreach (KeyValuePair<string, MenuItem> item1 in config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.Where(x => x.Value.items != null && x.Value.items.Count > 0))
                {
                    for (int i = 0; i < item1.Value.items.Count; i++)
                    {
                        if (item1.Value.items[i].chatCommand == VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK)
                        {
                            ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL = i;
                            VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK = item1.Key;
                        }
                    }
                }
            }
            string GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE = lang.GetLanguage(player.UserIDString);
            bool IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL = GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE == "ru";
            CuiHelper.DestroyUi(player, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG);
            var WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ = new CuiElementContainer();
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
            {
                Parent = "Overlay",
                Name = KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG,
                Components = {
          new CuiImageComponent {
            Color = "0.31 0.32 0.43 1",FadeIn =FadeIn
          },
          new CuiRectTransformComponent {
            AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-500 -285", OffsetMax = "500 285"
          }
        }
            });
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Image = {
          Color = "0.1 0.1 0.1 0"
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "Background");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "-100 -100",
          AnchorMax = "100 100"
        },
                Image = {
          Color = "0.1 0.1 0.1 0.5",
          Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "BackgroundClose");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Color = "0 0 0 0",
          Command = "closemenusystem"
        },
                Text = {
          Text = ""
        }
            }, "BackgroundClose");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "0 1",
          OffsetMin = "0 0",
          OffsetMax = "172 0"
        },
                Image = {
          Color = "0.18 0.19 0.28 0.75",
         FadeIn =FadeIn
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "MenuItemsLeft");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "1 0",
          AnchorMax = "1 1",
          OffsetMin = "-0.7 0",
          OffsetMax = "0.7 0"
        },
                Button = {
          Color = "0.32 0.33 0.43 1",
         FadeIn =FadeIn
        },
                Text = {
          Text = ""
        }
            }, "MenuItemsLeft");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel()
            {
                CursorEnabled = true,
                RectTransform = {
          AnchorMin = "0.172 1",
          AnchorMax = "1 1",
          OffsetMin = "0 -60",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0.18 0.19 0.28 0.75",
         FadeIn =FadeIn
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "MenuItemsUpper");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 0",
          OffsetMin = "0 -0.7",
          OffsetMax = "0 0.7"
        },
                Button = {
          Color = "0.32 0.33 0.43 1",
         FadeIn =FadeIn
        },
                Text = {
          Text = ""
        }
            }, "MenuItemsUpper");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
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
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "BackgroundGLITCH");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
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
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "BackgroundGLITCH");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
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
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "BackgroundGLITCH");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
            {
                Parent = KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG,
                Name = "MainImage",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "MainImage"), Color = "1 1 1 1"
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = $"1 1"
          }
        }
            });
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "0 1",
          OffsetMin = "0 0",
          OffsetMax = "172 0"
        },
                Image = {
          Color = "0 0 0 0",
         FadeIn =FadeIn
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "MenuItemsLeft2");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
            {
                Parent = KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG,
                Name = "ExitImage",
                Components = {
          new CuiRawImageComponent {
            Png = (string) ImageLibrary.Call("GetImage", "ExitImage"), Color = "1 1 1 1",FadeIn =FadeIn
          },
          new CuiRectTransformComponent {
            AnchorMin = "0 0", AnchorMax = $"0 0", OffsetMin = "42.5 0", OffsetMax = "132.5 55"
          }
        }
            });
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0.5 0.5",
          AnchorMax = $"0.5 0.5",
          OffsetMin = "-15 -14",
          OffsetMax = "40 15"
        },
                Text = {
          Text = IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL ? "ВЫХОД" : "EXIT",
          Color = "0.929 0.882 0.847 0.8",
          Align = TextAnchor.MiddleCenter,
         FontSize = 14,
         Font = "robotocondensed-bold.ttf",
         FadeIn =FadeIn
        }
            }, "ExitImage");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Button = {
          Color = "0 0 0 0",
          Command = "closemenusystem"
        },
                Text = {
          Text = ""
        }
            }, "ExitImage");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0.5",
          AnchorMax = $"0 0.5",
          OffsetMin = "10 -195",
          OffsetMax = "210 195"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "Button");
            if (config.InterfaceSetting.HENUYAQMKUMUHTOBEVEVUHRTOOMVLNFQXPGRHBHPPRDQY)
            {
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0.5 1",
            AnchorMax = $"0.5 1",
            OffsetMin = "-45 -90",
            OffsetMax = "45 -10"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = "chat.say /menu",
           FadeIn =FadeIn
          },
                    Text = {
            Text = $""
          }
                }, "MenuItemsLeft2", "LogoImage");
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
                {
                    Parent = "LogoImage",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "LogoImage"),FadeIn =FadeIn
            },
            new CuiRectTransformComponent {
              AnchorMin = "0 0", AnchorMax = "1 1"
            }
          }
                });
            }
            CuiHelper.AddUi(player, WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ);
            DestroyUI(player);
            NVHITAYIEBFGARFRFGWUZVDYYQJOXWAJDRVLWDTKOSKB(player, VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK);
            EETNTRTEHCAKYACJFFAPKFFQRMWFYOSOOPEQAHHVSBYJB(player, VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK, ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL);
        }
        void ZLELIQOUENJOIOGJXBHJKZBYACOPWOEOGTLXBSOUYWYMVOV(BasePlayer player)
        {
            if (!OTLBBVXBCIPBFQXQONDITUBHNDGESVGRMMGZOLYQOK.ContainsKey(player.userID)) OTLBBVXBCIPBFQXQONDITUBHNDGESVGRMMGZOLYQOK.Add(player.userID, null);
            SubMenuItem DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ = OTLBBVXBCIPBFQXQONDITUBHNDGESVGRMMGZOLYQOK[player.userID];
            if (DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ != null)
            {
                if (config.InterfaceSetting.JRNFMDRXNZDRAFOCZLTUEANHDJTQTXOKFTWATBEIU == true)
                {
                    Puts($"LAST ELEMENT IS {DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM}");
                }
                if (!string.IsNullOrEmpty(DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.YLPQCNPVFDHXIJTBXCNZETUSZNZLMMJGPUGNXFGGIS))
                {
                    if (!string.IsNullOrEmpty(DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM) && plugins.Find(DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM))
                    {
                        if (config.InterfaceSetting.JRNFMDRXNZDRAFOCZLTUEANHDJTQTXOKFTWATBEIU == true) Puts("CALL CLOSEfUNCTION");
                        plugins.Find(DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM).Call(DPTSWUQWXIJYZYGEJUSZHUYTIAMEXORAKWVTJEFWZ.YLPQCNPVFDHXIJTBXCNZETUSZNZLMMJGPUGNXFGGIS, player);
                    }
                }
            }
        }
        bool ANWSUHIAKFKFBYXPIUIODJHEMNKNBOCMHKPJSMUYL(SubMenuItem ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB, BasePlayer player)
        {
            string LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM = "";
            ZLELIQOUENJOIOGJXBHJKZBYACOPWOEOGTLXBSOUYWYMVOV(player);
            if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB == null || player == null || string.IsNullOrEmpty(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS)) return false;
            if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS == "close")
            {
                XWESGIWDZHFAWKPOKAFGPRFUIZVAPGUXCSTDJWBNKDVMAUFT(player);
                return false;
            }
            LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM = "MenuSystem";
            if (!string.IsNullOrEmpty(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM)) LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM = ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM;
            if (!plugins.Find(LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM))
            {
                PrintWarning($"Plugin notfound: {LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM}");
                return false;
            }
            var Plugin = plugins.Find(LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM);
            if (Plugin == null) return false;
            if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY == null || ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Count == 0)
            {
                Plugin.Call(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS, player);
                if (config.InterfaceSetting.JRNFMDRXNZDRAFOCZLTUEANHDJTQTXOKFTWATBEIU == true)
                {
                    Puts($"{LKWQMMZEMCZIBBAXVBILFWLNUPRQKYIWXPRHXOMOUBKM}.Call({ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS}, {player});");
                }
            }
            switch (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Count)
            {
                case 1:
                    Plugin.Call(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS, player, ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[0]);
                    break;
                case 2:
                    Plugin.Call(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS, player, ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[0], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[1]);
                    break;
                case 3:
                    Plugin.Call(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS, player, ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[0], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[1], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[2]);
                    break;
                case 4:
                    Plugin.Call(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.WFSQLIAEFFPYIWXUITOUDKLKSAHOTQDLYEXJYZZQHRS, player, ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[0], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[1], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[2], ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY[3]);
                    break;
            }
            OTLBBVXBCIPBFQXQONDITUBHNDGESVGRMMGZOLYQOK[player.userID] = ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB;
            return true;
        }
        void NVHITAYIEBFGARFRFGWUZVDYYQJOXWAJDRVLWDTKOSKB(BasePlayer player, string VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK = "")
        {
            CuiHelper.DestroyUi(player, "Command");
            CuiHelper.DestroyUi(player, "Info");
            var WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ = new CuiElementContainer();
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0.13",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, "Button", "Command");
            string GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE = lang.GetLanguage(player.UserIDString);
            bool IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL = GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE == "ru";
            string HKLODZOMRBSRWIRAKVHMYIRJNCCMVEPWZMMNHTWMPKWQHTZN = "";
            float IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO = 0.8f, UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS = 0.100875f, XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG = -0.049f, fXMGVYTVWOUTYNZOPOFYXOXPEJMXLBAIWWBQUIPXOSMV = 0.9300f - UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS, QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ = XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG, QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE = fXMGVYTVWOUTYNZOPOFYXOXPEJMXLBAIWWBQUIPXOSMV;
            foreach (KeyValuePair<string, MenuItem> ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB in config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO)
            {
                var color = "0.75 0.7 0.7 0.25";
                var JWIOTJLKPJGJMRGPQQPWSRFGEHENNHZOLJMLCQJFIBHGBI = "0.75 0.7 0.7 0.1";
                var YPBOICMXSRCKLEXWHKRXCEUNAGJORJZEWAFYMTRLZM = "0 0 0 0";
                if (VQIAEFRVPXHWUFXDRTBOCNKLTZDIAMOBLBBGSHEQPFK == ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Key)
                {
                    ANWSUHIAKFKFBYXPIUIODJHEMNKNBOCMHKPJSMUYL(ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value, player);
                    color = "0.959 0.922 0.927 0.8";
                    JWIOTJLKPJGJMRGPQQPWSRFGEHENNHZOLJMLCQJFIBHGBI = "0.929 0.882 0.847 0.8";
                    YPBOICMXSRCKLEXWHKRXCEUNAGJORJZEWAFYMTRLZM = "0.32 0.33 0.43 1.5";
                }
                HKLODZOMRBSRWIRAKVHMYIRJNCCMVEPWZMMNHTWMPKWQHTZN = $"menu {ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Key}";
                if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value.items != null && ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value.items.Count > 0) HKLODZOMRBSRWIRAKVHMYIRJNCCMVEPWZMMNHTWMPKWQHTZN = $"subMenu {ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Key}";
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = $"{QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ} {QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE}",
            AnchorMax = $"{QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ + IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO} {QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE + UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS * 1f}",
            OffsetMin = "0 1",
            OffsetMax = "0 -1"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = HKLODZOMRBSRWIRAKVHMYIRJNCCMVEPWZMMNHTWMPKWQHTZN
          },
                    Text = {
            Text = ""
          }
                }, "Command", "Really");
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0.35 0",
            AnchorMax = "1 1",
            OffsetMin = "0 0",
            OffsetMax = "0 0"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = HKLODZOMRBSRWIRAKVHMYIRJNCCMVEPWZMMNHTWMPKWQHTZN
          },
                    Text = {
            Text = IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL ? ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["ru"] : ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["en"],
            Color = JWIOTJLKPJGJMRGPQQPWSRFGEHENNHZOLJMLCQJFIBHGBI,
            Align = TextAnchor.MiddleLeft,
           FontSize = 18,
           Font = "robotocondensed-bold.ttf"
          }
                }, "Really");
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
                {
                    Parent = "Really",
                    Components = {
            new CuiImageComponent {
              Color = color, Sprite = ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.Value.WBDSRAAJELUAWZVLHTCKIOACRTFYBTGXPIEGTRJDCMQ
            },
            new CuiRectTransformComponent {
              AnchorMin = $"0.15 0.1", AnchorMax = $"0.31445 0.9"
            }
          }
                });
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "0 1",
            OffsetMin = "0 2.5",
            OffsetMax = "4 -2.5"
          },
                    Image = {
            Color = YPBOICMXSRCKLEXWHKRXCEUNAGJORJZEWAFYMTRLZM
          }
                }, "Really");
                QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ += IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO;
                if (QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ + IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO >= -1)
                {
                    QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ = XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG;
                    QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE -= UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS;
                }
            }
            CuiHelper.AddUi(player, WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ);
        }
        [ConsoleCommand("subMenu")]
        void AKYDAHNCQMRSJKCQKKHAVCJVUUBMMGGLCRXGLLWPMH(ConsoleSystem.Arg CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY)
        {
            var player = CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Player();
            if (CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args.Length == 0) return;
            int ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL = 0;
            if (CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args.Length == 2)
                if (!int.TryParse(CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args[1], out ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL)) ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL = 0;
            DestroyUI(player);
            NVHITAYIEBFGARFRFGWUZVDYYQJOXWAJDRVLWDTKOSKB(player, CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args[0]);
            EETNTRTEHCAKYACJFFAPKFFQRMWFYOSOOPEQAHHVSBYJB(player, CTEYDXUENEUGXEEHGDSKJWWAHJWGBATIMYAVGTORY.Args[0], ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL);
        }
        void EETNTRTEHCAKYACJFFAPKFFQRMWFYOSOOPEQAHHVSBYJB(BasePlayer player, string YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ, int ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL = 0)
        {
            if (!config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.ContainsKey(YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ)) return;
            MenuItem ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB = config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO[YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ];
            if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB == null || ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items == null || ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items.Count < 1)
            {
                return;
            }
            string GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE = lang.GetLanguage(player.UserIDString);
            bool IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL = GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE == "ru";
            var WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ = new CuiElementContainer();
            CuiHelper.DestroyUi(player, "Info");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0.173 1",
          AnchorMax = "1 1",
          OffsetMin = "0 -60",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0 0 0 0",
         FadeIn =FadeIn
        }
            }, KYNSNRDTRMXBYOSTCKKPEACVZAXZUTDVWQHINXJBLDOPG, "Info");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1"
        },
                Image = {
          Color = "0.15 0.17 0.13 0",
         FadeIn =FadeIn
        }
            }, "Info", "Left");
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiLabel
            {
                RectTransform = {
          AnchorMin = "0 0.91",
          AnchorMax = $"1 1",
          OffsetMax = "0 0"
        },
                Text = {
          Text = IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL ? ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["ru"] : ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["en"],
          Color = "0.87 0.87 0.87 0.8",
          Align = TextAnchor.MiddleCenter,
         FontSize = 28,
         Font = "robotocondensed-bold.ttf",
         FadeIn =FadeIn
        }
            }, "Left");
            CuiHelper.AddUi(player, WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ);
            ZFICQJMRDYYDVGUNFTJMWIWMIYXEWIHWOKNRXWXIBW(player, YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ, ILABHZHDOCXNOHIXUWRDULRRRRWNVKBEEKRXPJLWCL);
        }
        void ZFICQJMRDYYDVGUNFTJMWIWMIYXEWIHWOKNRXWXIBW(BasePlayer player, string YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ, int CAODJSFVWRWKWUIJPDTIDBTJDPKHLLVAJCPQDNMVPOE = 0)
        {
            if (!config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.ContainsKey(YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ)) return;
            MenuItem ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB = config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO[YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ];
            if (ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB == null || ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items == null || ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items.Count < 1)
            {
                PrintWarning($"MenuItem {YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ} not contains submenu");
                return;
            }
            CuiHelper.DestroyUi(player, "InfoButton");
            var WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ = new CuiElementContainer();
            WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiPanel
            {
                RectTransform = {
          AnchorMin = "0 0",
          AnchorMax = "1 1",
          OffsetMax = "0 0"
        },
                Image = {
          Color = "0 0 0 0"
        }
            }, "Left", "InfoButton");
            string GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE = lang.GetLanguage(player.UserIDString);
            bool IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL = GHBUDKJVHBFHIJCFRRSHVUTBOYDFUPOUGMCZNCAGE == "ru";
            float IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO = 1f, UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS = 0.06f, XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG = 0f, fXMGVYTVWOUTYNZOPOFYXOXPEJMXLBAIWWBQUIPXOSMV = 0.6f - UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS, QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ = XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG, QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE = fXMGVYTVWOUTYNZOPOFYXOXPEJMXLBAIWWBQUIPXOSMV;
            int i = 0;
            int UAGXALEZVJKETVONBSYGIRXNLZYKOTFYQKZMUJJCMKDVMWL = 0;
            int YFPSBGLCDSLBMTLCDLNJVBTSJVTXOBBPNVMIDNXKY = 0;
            SubMenuItem JBXIPTZBRAICIWMXJFMNOBQWNRGCYQODKYSRUBFAYNKBHLNQ = null;
            foreach (SubMenuItem check in ZOHKHNVFKQGQSFGLIFQMDJUWXSPUJWMQQIPVSMVB.items)
            {
                var GDSXKIHLBUYMWCBMERJEUCIZMPBROOCDQGRNWGZQKGTHGOBK = "1 1 1 0.2";
                var PDTEMBEVSKVHQWMRUVQKOPXSSTNIBSYNQIZKJZEENRD = "0.7 0.7 0.7 0.2";
                if (CAODJSFVWRWKWUIJPDTIDBTJDPKHLLVAJCPQDNMVPOE == i)
                {
                    JBXIPTZBRAICIWMXJFMNOBQWNRGCYQODKYSRUBFAYNKBHLNQ = check;
                    GDSXKIHLBUYMWCBMERJEUCIZMPBROOCDQGRNWGZQKGTHGOBK = "1 1 1 1";
                    PDTEMBEVSKVHQWMRUVQKOPXSSTNIBSYNQIZKJZEENRD = "0.929 0.882 0.847 0.75";
                }
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiElement
                {
                    Parent = "InfoButton",
                    Name = "ButtonImageBlock",
                    Components = {
            new CuiRawImageComponent {
              Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = GDSXKIHLBUYMWCBMERJEUCIZMPBROOCDQGRNWGZQKGTHGOBK
            },
            new CuiRectTransformComponent {
              AnchorMin = $"{0.038 + (UAGXALEZVJKETVONBSYGIRXNLZYKOTFYQKZMUJJCMKDVMWL * 0.187)} {0.08 - (YFPSBGLCDSLBMTLCDLNJVBTSJVTXOBBPNVMIDNXKY * 0.18)}", AnchorMax = $"{0.038 + (UAGXALEZVJKETVONBSYGIRXNLZYKOTFYQKZMUJJCMKDVMWL * 0.187) + 0.175f} {0.92 - (YFPSBGLCDSLBMTLCDLNJVBTSJVTXOBBPNVMIDNXKY * 0.18)}"
            }
          }
                });
                WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ.Add(new CuiButton
                {
                    RectTransform = {
            AnchorMin = "0 0",
            AnchorMax = "1 1",
            OffsetMax = "0 0"
          },
                    Button = {
            Color = "0 0 0 0",
            Command = $"subMenu {YLREHRNEQNMKIXPUKMOXAVNDQZJQKTVJPXFYCSQACQTJZ} {i}",
            Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
          },
                    Text = {
            Text = IUSXEXBRHFHGHLOZFFHEBRMKBVHCSPQLCWMZJRUGDCHINZFQL ? check.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["ru"].ToUpper() : check.HHFQHDNBEIRUGMEJWIDMVHYAEMCRBIXJAECWVWFLSQIXGYPN["en"].ToUpper(),
            Color = PDTEMBEVSKVHQWMRUVQKOPXSSTNIBSYNQIZKJZEENRD,
            Align = TextAnchor.MiddleCenter,
           FontSize = 24,
           Font = "robotocondensed-bold.ttf"
          }
                }, "ButtonImageBlock");
                i++;
                UAGXALEZVJKETVONBSYGIRXNLZYKOTFYQKZMUJJCMKDVMWL++;
                if (UAGXALEZVJKETVONBSYGIRXNLZYKOTFYQKZMUJJCMKDVMWL == 5)
                {
                    break;
                }
                QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ += IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO;
                if (QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ + IUJONXZTBABXBRMMWRKVDSQYUWNLACUDPKMKFILO >= 1)
                {
                    QYYZWBTBINRZXCLMVKVNLXBLJTGYIJFBCENLOYPZHHNJ = XLWFUOVEABGMXHWNGXXWSJQCHHOHPLWIOJKGJXLZKRIHG;
                    QXGELSIRHZTWMQCVUTZIPXTOAXXUVGEJSASWAUWRWKUE -= UFTVPNTJELBORZQEKTQJNSZGXHRFCGNFWIINXDFJUCWRS;
                }
            }
            CuiHelper.AddUi(player, WVZZXQHHVIPYZRPVDLZPQNLAAZJDXBQQRETVMDYVRBVLQ);
            if (JBXIPTZBRAICIWMXJFMNOBQWNRGCYQODKYSRUBFAYNKBHLNQ != null) ANWSUHIAKFKFBYXPIUIODJHEMNKNBOCMHKPJSMUYL(JBXIPTZBRAICIWMXJFMNOBQWNRGCYQODKYSRUBFAYNKBHLNQ, player);
        }
        void fRXLBBEVFZPKQJWTSMHUURCOLTDQJVBKAWQULMWDSMBX()
        {
     
        }
        private int AWIADFWUBRNPIAIYOMJXEJUSBIFPDCHPEPKWVPFQEPZEDFCMN() => UnityEngine.Random.Range(0, 9999);
        private void DASZUQBPZVZGQYKXKSPLCYHTSOKQPWFTBYYHXFVTVF()
        {
     
        }
        void DestroyUI(BasePlayer player)
        {
            foreach (MenuItem JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC in config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.Values.Where(x => x.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO != null && x.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO.Count > 0))
            {
                foreach (string layer in JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO) CuiHelper.DestroyUi(player, layer);
            }
            CuiHelper.DestroyUi(player, "Info");
        }
        void DestroySubUI(BasePlayer player, string key, int destroyid = 16)
        {
            if (!config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO.ContainsKey(key)) return;
            if (key != "map") player.Command("close_map");
            MenuItem JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC = config.JZOUBZYXWAVKZIDFCCKBEPKSLGINIXGLAPROTIIURWAOO[key];
            if (JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC.items == null || JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC.items.Count < 1) return;
            foreach (SubMenuItem subMenu in JVNEWQGSQDOJTBAPZNJKSMSCBRDDJAXHAOCQIGMNJNTC.items.Where(x => x.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO != null && x.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO.Count > 0)) foreach (string layer in subMenu.BIORPTLHWSFMUIXLBMLOCEAEYNWIUXNMSBIJLPZZFVO) CuiHelper.DestroyUi(player, layer);
        }
        
        void MS_CustomCMD(BasePlayer player, string command, bool BQDVXCCVQKFIFWGFCIVDIFLTERLJPKZWDOKDVILXKTKBWSAV = false)
        {
            PPCZSWBCBDDGHWSJYQWMLIGEXKNQDAFCDSGWUTBQ(player, command, BQDVXCCVQKFIFWGFCIVDIFLTERLJPKZWDOKDVILXKTKBWSAV);
        }
    }
}