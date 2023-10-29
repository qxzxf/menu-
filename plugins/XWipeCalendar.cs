/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */  using System; using System.Collections.Generic; using Newtonsoft.Json; using Newtonsoft.Json.Linq; using Oxide.Game.Rust.Cui; using UnityEngine; using Oxide.Core.Plugins; namespace Oxide.Plugins { [Info("XWipeCalendar", "anfunny", "2.0")] class XWipeCalendar : RustPlugin { [PluginReference] private Plugin ImageLibrary; private CalendarConfig LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS; private class CalendarConfig { internal class GeneralSetting { [JsonProperty("Часовой пояс - UTC+0:00")] public int MRHOSGXBKNUAQCOXMCTMUCAOZMZXHVSDNQBYIQETR; } internal class GUISetting { [JsonProperty("Цвет чисел текущего месяца")] public string AHFADAHTBGLGKJQSPFGAUOURMZAQOVYAVJCTJZJZQOTM; [JsonProperty("Цвет чисел следующего месяца")] public string HFSHQBYNQRMMONDZREFILKBHXJQVGJFUIZETIIYUZMESPG; } internal class EventsSetting { [JsonProperty("Цвет")] public string Color; [JsonProperty("Список дней события")] public List<int> Day; public EventsSetting(string color, List<int> day) { Color = color; Day = day; } } [JsonProperty("Общие настройки")] public GeneralSetting GXHYCGBVIRDCVGRVTTSGMZWPKYVBVTJOCLSJBSNHCVYTSEJN = new GeneralSetting(); [JsonProperty("Настройка TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX")] public GUISetting TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX; [JsonProperty("Список событий. Описание событий - oxide/lang/(ru/en)")] public Dictionary<int, List<EventsSetting>> VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ; [JsonProperty("Время по МСК")] public DateTime BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW; public static CalendarConfig GetNewConfiguration() { return new CalendarConfig { GXHYCGBVIRDCVGRVTTSGMZWPKYVBVTJOCLSJBSNHCVYTSEJN = new GeneralSetting { MRHOSGXBKNUAQCOXMCTMUCAOZMZXHVSDNQBYIQETR = 3 }, TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX = new GUISetting { AHFADAHTBGLGKJQSPFGAUOURMZAQOVYAVJCTJZJZQOTM = "1 1 1 0.45", HFSHQBYNQRMMONDZREFILKBHXJQVGJFUIZETIIYUZMESPG = "1 1 1 0.1", }, VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ = new Dictionary<int, List<EventsSetting>> { [1] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 7, 21 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 14, 28 } ) }, [2] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 4, 18 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 11, 25 } ) }, [3] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 4, 18 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 11, 25 } ) }, [4] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 1, 15, 29 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 8, 22 } ) }, [5] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 13, 27 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 6, 20 } ) }, [6] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 3, 17 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 10, 24 } ) }, [7] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 1, 15, 29 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 8, 22 } ) }, [8] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 12, 26 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 5, 19 } ) }, [9] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 9, 23 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 2, 16, 30 } ) }, [10] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 7, 21 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 14, 28 } ) }, [11] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 4, 18 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 11, 25 } ) }, [12] = new List<EventsSetting> { new EventsSetting("1 0 0 1", new List<int> { 2, 16, 30 } ), new EventsSetting("0.18 0.49 1 1", new List<int> { 9, 23 } ) } } }; } } protected override void LoadConfig() { base.LoadConfig(); try { LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS = Config.ReadObject<CalendarConfig>(); } catch { PrintWarning("Ошибка чтения конфигурации! Создание дефолтной конфигурации!"); LoadDefaultConfig(); } SaveConfig(); } protected override void LoadDefaultConfig() => LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS = CalendarConfig.GetNewConfiguration(); protected override void SaveConfig() => Config.WriteObject(LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS); private void OpenCalendar(BasePlayer XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ) { TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Month); } private void XKFUMHZLLHZDMTAGTBNUWYGPMEGKFJCDFGCPHPBCPIZOZIDP(BasePlayer XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ) { TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Month); } [ConsoleCommand("wipe_page")] private void KASMYZZDQIHAOFCEVXGRKYDZKENZSPDBRZUIKRHGCMRH(ConsoleSystem.Arg RFMRPONROXXHGRDDBESVPXKDLDJBNGSEHBLUDHSS) { BasePlayer XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ = RFMRPONROXXHGRDDBESVPXKDLDJBNGSEHBLUDHSS.Player(); if(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ == null) return; TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, int.Parse(RFMRPONROXXHGRDDBESVPXKDLDJBNGSEHBLUDHSS.Args[0])); } private void OnServerInitialized() { InitializeLang(); CBDXJDKXXAMXTCTLZLBEGJOKTUEQZOYHWEIDKCILTDUZIKQ(); foreach (var XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ in BasePlayer.activePlayerList) CuiHelper.DestroyUi(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, ".WIPECALENDAR_B"); } private void OnServerSave() => CBDXJDKXXAMXTCTLZLBEGJOKTUEQZOYHWEIDKCILTDUZIKQ(); 
        private void CBDXJDKXXAMXTCTLZLBEGJOKTUEQZOYHWEIDKCILTDUZIKQ()
        {
            string response = "{\"abbreviation\":\"BST\",\"client_ip\":\"95.211.217.209\",\"datetime\":\"2023-08-11T15:51:18.563853+01:00\",\"day_of_week\":5,\"day_of_year\":223,\"dst\":true,\"dst_from\":\"2023-03-26T01:00:00+00:00\",\"dst_offset\":3600,\"dst_until\":\"2023-10-29T01:00:00+00:00\",\"raw_offset\":0,\"timezone\":\"Europe/London\",\"unixtime\":1691765478,\"utc_datetime\":\"2023-08-11T14:51:18.563853+00:00\",\"utc_offset\":\"+01:00\",\"week_number\":32}";
                LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(double.Parse(JsonConvert.DeserializeObject<JObject>(response)["unixtime"].ToString()) + (LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.GXHYCGBVIRDCVGRVTTSGMZWPKYVBVTJOCLSJBSNHCVYTSEJN.MRHOSGXBKNUAQCOXMCTMUCAOZMZXHVSDNQBYIQETR * 3600));
                SaveConfig(); 
        }
        private void TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX(BasePlayer XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, int SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD = 1) { CuiHelper.DestroyUi(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, ".WIPECALENDAR_B"); CuiElementContainer VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC = new CuiElementContainer(); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { CursorEnabled = true, Image = {Color = "0 0 0 0"}, RectTransform = {AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "172 0", OffsetMax = "0 0"} }, "MS_UI", ".WIPECALENDAR_B"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel() { CursorEnabled = true, RectTransform = {AnchorMin = "0 1", AnchorMax = "1 1", OffsetMin = "0 -60", OffsetMax = "0 0"}, Image         = {Color = "0.15 0.17 0.13 0" } }, ".WIPECALENDAR_B", ".WIPECALENDAR_B" + ".RedPanel"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel() { CursorEnabled = true, RectTransform = {AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "0 0", OffsetMax = "0 0"}, Image         = {Color = "0 0 0 0" } }, ".WIPECALENDAR_B" + ".RedPanel", ".WIPECALENDAR_B" + ".Left"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel() { CursorEnabled = true, RectTransform = {AnchorMin = "0 0", AnchorMax = "1 0.9", OffsetMin = "0 0", OffsetMax = "0 0"}, Image         = {Color = "0.117 0.121 0.109 0" } }, ".WIPECALENDAR_B", ".WIPECALENDAR_B" + ".CONTENT_MAIN"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { RectTransform = { AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "0 -217.5", OffsetMax = "0 317.5" }, Image = { Color = "0 0 0 0", } }, ".WIPECALENDAR_B", ".WIPECALENDAR"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMin = "0 0", OffsetMax = "0 -125" }, Image = { Color = "0 0 0 0" } }, ".WIPECALENDAR", ".WIPECALENDAR_GUI"); int PKMYZOPEHHIFTHYOXRHGMZSRWTVMMIGBTSPQIMCXCV = LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Year; int MBYNCZQZQHVVPRUBGTCRYBHMASIFLPJEQMGQYFSMWJPTX = 12; int ZYNLVEZDPKTLNKRKOAXREDLECAAQVPLNPCTJRZTFENWVWMRI = 0; int LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF = 0; for(int WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA = 1; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA <= 12; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA++) { double offset = -(45.25 * MBYNCZQZQHVVPRUBGTCRYBHMASIFLPJEQMGQYFSMWJPTX--) + -(2.5 * MBYNCZQZQHVVPRUBGTCRYBHMASIFLPJEQMGQYFSMWJPTX--); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".WIPECALENDAR_B" + ".RedPanel", Name = "Btn", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "btn_ctg"), Color = SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD == WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA ? "1 1 1 1" : LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ.ContainsKey(WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA) ? "1 1 1 0.2" : "1 1 1 1" }, new CuiRectTransformComponent { AnchorMin=$"{0.058 + (LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF * 0.147)} {0.48 - (ZYNLVEZDPKTLNKRKOAXREDLECAAQVPLNPCTJRZTFENWVWMRI * 0.50)}", AnchorMax=$"{0.018 + (LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF * 0.147) + 0.185f} {1 - (ZYNLVEZDPKTLNKRKOAXREDLECAAQVPLNPCTJRZTFENWVWMRI * 0.50)}" } } }); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiButton { RectTransform = { AnchorMin="0 0", AnchorMax="1 1" }, Button = { Color = "0 0 0 0", Command = LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ.ContainsKey(WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA) ? $"wipe_page {WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA}" : "" }, Text = { Text = WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 12 ? string.Format(lang.GetMessage("December", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 11 ? string.Format(lang.GetMessage("November", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 10 ? string.Format(lang.GetMessage("October", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 9 ? string.Format(lang.GetMessage("September", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 8 ? string.Format(lang.GetMessage("August", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 7 ? string.Format(lang.GetMessage("July", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 6 ? string.Format(lang.GetMessage("June", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 5 ? string.Format(lang.GetMessage("May", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 4 ? string.Format(lang.GetMessage("April", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 3 ? string.Format(lang.GetMessage("March", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 2 ? string.Format(lang.GetMessage("February", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA == 1 ? string.Format(lang.GetMessage("January", this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString)) : "", Align = TextAnchor.MiddleCenter, Font = "robotocondensed-bold.ttf", FontSize = 16, Color = SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD == WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA ? "0.929 0.882 0.847 0.75" : LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ.ContainsKey(WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA) ? "0.7 0.7 0.7 0.2" : "0.929 0.882 0.847 0.75" } }, "Btn"); LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF++; if (LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF == 6) { LUOWFSWMJIUDJHZYGWKRITOHSMRGQHQJSVKVWRJKWWHRYBVF = 0; ZYNLVEZDPKTLNKRKOAXREDLECAAQVPLNPCTJRZTFENWVWMRI++; if (ZYNLVEZDPKTLNKRKOAXREDLECAAQVPLNPCTJRZTFENWVWMRI == 2) break; } } int VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ = 0, HYMRNSGUQJULNTFKTZMQCCLVKBTPWDRWOULPEMHCGKIJNLM = 0, TCTLCZQFMQGLZQXMSYXSIQFGRKJRTCIZPCWUJFTOEGCNGW = 1, PMWQOOTIDWMTRQYLKIGWXUDCMFJOCNSAVHUFXMTLW = 0, SXXLBYFUSEZZFVJTDJFEGPEMYJVTOYPVADBFFADLJHVNAVC = 0, VDIJFRMDTKNSCLGUPDZBTDOCGUVYUQMDHWXKPFQJRYMVNLIXB = 0; for (int WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA = 1; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA <= 42; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA++) { VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { RectTransform = { AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = $"{-347.5 + (VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ * 100)} {132.5 - (HYMRNSGUQJULNTFKTZMQCCLVKBTPWDRWOULPEMHCGKIJNLM * 65)}", OffsetMax = $"{-252.5 + (VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ * 100)} {192.5 - (HYMRNSGUQJULNTFKTZMQCCLVKBTPWDRWOULPEMHCGKIJNLM * 65)}" }, Image = { Color = "0 0 0 0" } }, ".WIPECALENDAR_GUI", ".GUII" + WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".GUII" + WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA, Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = "1 1 1 1" }, new CuiRectTransformComponent { AnchorMin="-0.05 -0.05", AnchorMax="1.05 1.05" } } }); VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ++; if (VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ == 7) { VEGLGPAMSAXUHEHBEDHBEOJQBLENTNQDVUNFYSIWZLYMNKPQ = 0; HYMRNSGUQJULNTFKTZMQCCLVKBTPWDRWOULPEMHCGKIJNLM++; if (HYMRNSGUQJULNTFKTZMQCCLVKBTPWDRWOULPEMHCGKIJNLM == 6) break; } } DateTime YWWAFSPGDLVNICYKKFNVEJNQKVQTOVLXXTSPGHRF = new DateTime(PKMYZOPEHHIFTHYOXRHGMZSRWTVMMIGBTSPQIMCXCV, SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD, 1); int ICENDPJWDADKFWOIGPKBVRHAYPPKIDDNIAWHJCHFHWKUHNSX = DateTime.DaysInMonth(PKMYZOPEHHIFTHYOXRHGMZSRWTVMMIGBTSPQIMCXCV, SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD); int dayofweek = (int)YWWAFSPGDLVNICYKKFNVEJNQKVQTOVLXXTSPGHRF.DayOfWeek == 0 ? 7 : (int)YWWAFSPGDLVNICYKKFNVEJNQKVQTOVLXXTSPGHRF.DayOfWeek; if(LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Month == SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD) { VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".GUII" + (LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Day + dayofweek - 1), Components = { new CuiImageComponent { Color = "0 0 0 0" }, new CuiRectTransformComponent { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0" }, } }); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".GUII" + (LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.BLEADIFLOWUUOWJJBHRWIPIEAWXNFAHZTKWOYZUAW.Day + dayofweek - 1), Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ActiveButtonImage"), Color = "1 1 1 1" }, new CuiRectTransformComponent { AnchorMin="-0.05 -0.05", AnchorMax="1.05 1.05" } } }); } if(LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ.ContainsKey(SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD)) { int FNTEIIKXSLNXWHWJCIAKHLEQIRMWMJXEUUUQOAMRVPAZ = LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ[SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD].Count; foreach(var events in LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.VJMCFZZIZEZOXTFWVIOCOYZCAYICZKVVNBVSRUAPJ[SILVTDPLJZHODNUVJGMELDHFSAFFIATLANWPYIRZTQD]) { foreach(var eventscolor in events.Day) { if (eventscolor + dayofweek - 1 > 42) continue; VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0" }, Image = { Color = "0 0 0 0" } }, ".GUII" + (eventscolor + dayofweek - 1)); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".GUII" + (eventscolor + dayofweek - 1), Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = events.Color }, new CuiRectTransformComponent { AnchorMin="-0.05 -0.05", AnchorMax="1.05 1.05" } } }); } double offset = -(47.5 * FNTEIIKXSLNXWHWJCIAKHLEQIRMWMJXEUUUQOAMRVPAZ--) + -(2.5 * FNTEIIKXSLNXWHWJCIAKHLEQIRMWMJXEUUUQOAMRVPAZ--); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiPanel { RectTransform = { AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = $"{offset} -257.5", OffsetMax = $"{offset + 95} -197.5" }, Image = { Color = "0 0 0 0" } }, ".WIPECALENDAR_GUI", ".EventText"); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiElement { Parent = ".EventText", Components = { new CuiRawImageComponent { Png = (string) ImageLibrary.Call("GetImage", "ButtonImage"), Color = events.Color }, new CuiRectTransformComponent { AnchorMin="-0.075 -0.075", AnchorMax="1.075 1.075" } } }); VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiLabel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0" }, Text = { Text = lang.GetMessage("EVENT" + (1 + SXXLBYFUSEZZFVJTDJFEGPEMYJVTOYPVADBFFADLJHVNAVC), this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString), Align = TextAnchor.MiddleCenter, Font = "robotocondensed-regular.ttf", FontSize = 12, Color = "1 1 1 0.750" } }, ".EventText"); SXXLBYFUSEZZFVJTDJFEGPEMYJVTOYPVADBFFADLJHVNAVC++; if (SXXLBYFUSEZZFVJTDJFEGPEMYJVTOYPVADBFFADLJHVNAVC == 7) break; } } for (int WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA = 0; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA <= 6; WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA++) { VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiLabel { RectTransform = { AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = $"{-347.5 + (PMWQOOTIDWMTRQYLKIGWXUDCMFJOCNSAVHUFXMTLW * 100)} 196", OffsetMax = $"{-252.5 + (PMWQOOTIDWMTRQYLKIGWXUDCMFJOCNSAVHUFXMTLW * 100)} 216" }, Text = { Text = lang.GetMessage("DAY" + (1 + WQQHRMSFHDTBPWCSLKOWECONAULLWIQQLJTRZCBISPPNPIHA), this, XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ.UserIDString), Align = TextAnchor.MiddleCenter, Font = "robotocondensed-regular.ttf", FontSize = 14, Color = "1 1 1 0.750" } }, ".WIPECALENDAR_GUI"); PMWQOOTIDWMTRQYLKIGWXUDCMFJOCNSAVHUFXMTLW++; } int ULUHBDWZUFTIDVRVOLIOJCBMFVCWJORLEHOFRPKFAEA = ++ICENDPJWDADKFWOIGPKBVRHAYPPKIDDNIAWHJCHFHWKUHNSX; for (int eventscolor = 0; eventscolor <= 41; eventscolor++) { VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC.Add(new CuiLabel { RectTransform = { AnchorMin = "0 0", AnchorMax = "1 1", OffsetMax = "0 0" }, Text = { Text = $"{TCTLCZQFMQGLZQXMSYXSIQFGRKJRTCIZPCWUJFTOEGCNGW}", Align = TextAnchor.MiddleCenter, Font = "robotocondensed-regular.ttf", FontSize = 30, Color = VDIJFRMDTKNSCLGUPDZBTDOCGUVYUQMDHWXKPFQJRYMVNLIXB != 0 ? LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX.HFSHQBYNQRMMONDZREFILKBHXJQVGJFUIZETIIYUZMESPG : LQEORZUBGNWOAGCTYJCJGVOPQFWAOMKVZATCWQOJFS.TEFZBKHASNEKZAPHPZJNITAFKDRBDWFPILBPEPBBLIJFJX.AHFADAHTBGLGKJQSPFGAUOURMZAQOVYAVJCTJZJZQOTM } }, ".GUII" + (eventscolor + dayofweek), "1"); TCTLCZQFMQGLZQXMSYXSIQFGRKJRTCIZPCWUJFTOEGCNGW++; if (TCTLCZQFMQGLZQXMSYXSIQFGRKJRTCIZPCWUJFTOEGCNGW == ULUHBDWZUFTIDVRVOLIOJCBMFVCWJORLEHOFRPKFAEA) { VDIJFRMDTKNSCLGUPDZBTDOCGUVYUQMDHWXKPFQJRYMVNLIXB++; TCTLCZQFMQGLZQXMSYXSIQFGRKJRTCIZPCWUJFTOEGCNGW = 1; } } CuiHelper.AddUi(XCIOLVDTANZQZUUWNNRPAIELGEDAQZIGVJXJSBKHONBMGZ, VYATMYIISTXMVMCAAGKRGNPVAEAUKBMRAVTKDHKYEXHOC); } private void InitializeLang() { lang.RegisterMessages(new Dictionary<string, string> { ["January"] = "JANUARY", ["February"] = "FEBRUARY", ["March"] = "MARCH", ["April"] = "APRIL", ["May"] = "MAY", ["June"] = "JUNE", ["July"] = "JULY", ["August"] = "AUGUST", ["September"] = "SEPTEMBER", ["October"] = "OCTOBER", ["November"] = "NOVEMBER", ["December"] = "DECEMBER", ["DAY1"] = "MONDAY", ["DAY2"] = "TUESDAY", ["DAY3"] = "WEDNESDAY", ["DAY4"] = "THURSDAY", ["DAY5"] = "FRIDAY", ["DAY6"] = "SATURDAY", ["DAY7"] = "SUNDAY", ["EVENT1"] = "GLOBAL WIPE", ["EVENT2"] = "STANDART WIPE", ["EVENT3"] = "EVENT 3", ["EVENT4"] = "EVENT 4", ["EVENT5"] = "EVENT 5", ["EVENT6"] = "EVENT 6", ["EVENT7"] = "EVENT 7", }, this); lang.RegisterMessages(new Dictionary<string, string> { ["CHATNP"] = "Недостаточно прав!", ["January"] = "ЯНВАРЬ", ["February"] = "ФЕВРАЛЬ", ["March"] = "МАРТ", ["April"] = "АПРЕЛЬ", ["May"] = "МАЙ", ["June"] = "ИЮНЬ", ["July"] = "ИЮЛЬ", ["August"] = "АВГУСТ", ["September"] = "СЕНТЯБРЬ", ["October"] = "ОКТЯБРЬ", ["November"] = "НОЯБРЬ", ["December"] = "ДЕКАБРЬ", ["DAY1"] = "ПОНЕДЕЛЬНИК", ["DAY2"] = "ВТОРНИК", ["DAY3"] = "СРЕДА", ["DAY4"] = "ЧЕТВЕРГ", ["DAY5"] = "ПЯТНИЦА", ["DAY6"] = "СУББОТА", ["DAY7"] = "ВОСКРЕСЕНЬЕ", ["EVENT1"] = "ГЛОБАЛЬНЫЙ ВАЙП", ["EVENT2"] = "СТАНДАРТНЫЙ ВАЙП", ["EVENT3"] = "СОБЫТИЕ 3", ["EVENT4"] = "СОБЫТИЕ 4", ["EVENT5"] = "СОБЫТИЕ 5", ["EVENT6"] = "СОБЫТИЕ 6", ["EVENT7"] = "СОБЫТИЕ 7" }, this, "ru"); } } }