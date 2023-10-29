/* СКАЧАНО С https://discord.gg/k3hXsVua7Q */  using ConVar;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using System.Collections;
using Oxide.Core.Libraries;
using UnityEngine;
using System.IO;
using CompanionServer;
using System;
using Oxide.Core.Plugins;
using System.Text.RegularExpressions;
using System.Text;
using Oxide.Game.Rust.Cui;
using Facepunch;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Oxide.Plugins
{
    [Info("IQChat", "https://discord.gg/k3hXsVua7Q", "2.0")]
    class IQChat : RustPlugin
    {
        private String ERPAXVYQQQBDCSGDGMCMOAMMCJXMZCNLDWEFUESXP(BasePlayer playerInList)
        {
            GeneralInformation.RenameInfo GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(playerInList.userID);
            String NickNamed = GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ != null ? $"{GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.RenameNick ?? playerInList.displayName}" : playerInList.displayName;
            User Info = UserInformation[playerInList.userID];
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            Configuration.ControllerMute LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL;
            String GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Empty;
            String ColorNickPlayer = String.IsNullOrWhiteSpace(Info.Info.ColorNick) ? playerInList.IsAdmin ? "#a8fc55" : "#54aafe" : Info.Info.ColorNick;
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB)
            {
                if (Info.Info.PrefixList != null) GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Join("", Info.Info.PrefixList.Take(NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC));
            }
            else GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Info.Info.Prefix;
            String SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO = $"{GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP}<color={ColorNickPlayer}>{NickNamed}</color>";
            return SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO;
        }
        private void XVTPPUQLGGAWQEFCYNXMQNCPAGOBJBTEXHCRTMTDWO(BasePlayer player, String NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA, String Title = null)
        {
            if (MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY == null)
            {
                PrintWarning("Генерируем интерфейс, ожидайте сообщения об успешной генерации");
                return;
            }
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Alert");
            if (Interface == null) return;
            Interface = Interface.Replace("%TITLE%", Title ?? GetLang("IQCHAT_ALERT_TITLE", player.UserIDString));
            Interface = Interface.Replace("%DESCRIPTION%", NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA);
            CuiHelper.DestroyUi(player, InterfaceBuilder.UI_Chat_Alert);
            CuiHelper.AddUi(player, Interface);
            player.Invoke(() =>
            {
                CuiHelper.DestroyUi(player, InterfaceBuilder.UI_Chat_Alert);
            }, config.ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.IWSYZFBBRMBPBFKHPTQGOIZGSZFRPGRDTVQITYPEIDLUQFRAD);
        }
        protected override void LoadDefaultConfig() => config = Configuration.GetNewConfiguration();
        public static StringBuilder VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF = new StringBuilder();
        private void GKHFZZRGEZCPKSEPJGOCENVZICOJLTUQCQVFSAOBRUPFUSRY(BasePlayer player)
        {
            if (!permission.UserHasPermission(player.UserIDString, PermissionMutedAdmin)) return;
            String HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Administation_AllChat");
            if (HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE == null) return;
            HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE = HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE.Replace("%TEXT_MUTE_ALLCHAT%", GetLang(!GeneralInfo.TurnMuteAllChat ? "IQCHAT_BUTTON_MODERATION_MUTE_ALL_CHAT" : "IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_CHAT", player.UserIDString));
            HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE = HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE.Replace("%COMMAND_MUTE_ALLCHAT%", $"newui.cmd action.mute.ignore mute.controller {SelectedAction.Mute} mute.all.chat");
            CuiHelper.DestroyUi(player, "ModeratorMuteAllChat");
            CuiHelper.AddUi(player, HGGAQTYILWKGXEVBJPJNIPIUKWPCBEUSPKPSTHDZSE);
        }
        private void XKXHLRTOIWWLIVKFMMTWZWIRNKKXQEQLQUOJXIRYBQKES(Chat.ChatChannel channel, BasePlayer player, String Message)
        {
            Configuration.ControllerMessage.TurnedFuncional.AntiNoob.Settings YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM = config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY;
            if (YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP)
                if (OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(player.userID, YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("IQCHAT_INFO_ANTI_NOOB", player.UserIDString, FormatTime(UserInformationConnection[player.userID].EWEIMARKILVKEQRGSEHECRZMFNKKCXNUEEPLGUJWFRBQVX(YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI), player.UserIDString)));
                    return;
                }
            Configuration.ControllerMessage ControllerMessage = config.ControllerMessages;
            if (ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.NPIQMTLXTMSNVSLJMKXEUZDKNLVDZBIYJCVJZHVTRPLH)
                if (!permission.UserHasPermission(player.UserIDString, PermissionAntiSpam))
                {
                    if (!Flooders.ContainsKey(player.userID)) Flooders.Add(player.userID, new FlooderInfo
                    {
                        Time = CurrentTime + ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.HDRNMJFAERNMYDAXIYSETDSXCKFOEMFOWHFIEPMRC,
                        WZEJTHQVFVPFIEZDBBGVVBNKUTUQNKMHYYLIVLBRNDCDEXXVN = Message
                    });
                    else
                    {
                        if (Flooders[player.userID].Time > CurrentTime)
                        {
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("FLOODERS_MESSAGE", player.UserIDString, Convert.ToInt32(Flooders[player.userID].Time - CurrentTime)));
                            return;
                        }
                        if (ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX.EKNLBNZJGKGCCRFSBNEEFFSCXNOYCXSVUKNAMQTLHFZ)
                        {
                            if (Flooders[player.userID].WZEJTHQVFVPFIEZDBBGVVBNKUTUQNKMHYYLIVLBRNDCDEXXVN == Message)
                            {
                                if (Flooders[player.userID].EZKFCVMUPZNZHVJHGJSQHPAOIRZJFWWYCPFMWTVQWAWBDNVHT >= ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX.VQGLICRKXTEZSKNNZAHISKHRDEGLUTXZGSHGHCPZGHXBFOICC)
                                {
                                    KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(player, MuteType.Chat, 0, null, ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX.MGYQHKJOIDWFQEWESADGGWLHCKNGMOWEIOHQAQKWXT.Reason, ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX.MGYQHKJOIDWFQEWESADGGWLHCKNGMOWEIOHQAQKWXT.MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT);
                                    Flooders[player.userID].EZKFCVMUPZNZHVJHGJSQHPAOIRZJFWWYCPFMWTVQWAWBDNVHT = 0;
                                    return;
                                }
                                Flooders[player.userID].EZKFCVMUPZNZHVJHGJSQHPAOIRZJFWWYCPFMWTVQWAWBDNVHT++;
                            }
                        }
                    }
                    Flooders[player.userID].Time = ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM.HDRNMJFAERNMYDAXIYSETDSXCKFOEMFOWHFIEPMRC + CurrentTime;
                    Flooders[player.userID].WZEJTHQVFVPFIEZDBBGVVBNKUTUQNKMHYYLIVLBRNDCDEXXVN = Message;
                }
            GeneralInformation General = GeneralInfo;
            GeneralInformation.RenameInfo EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS = General.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(player.userID);
            User Info = UserInformation[player.userID];
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            Configuration.ControllerMute LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL;
            Configuration.ControllerMessage.GeneralSettings.OtherSettings OtherController = config.ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB;
            if (General.TurnMuteAllChat)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_CHAT", player.UserIDString));
                return;
            }
            if (channel == Chat.ChatChannel.Team && !ControllerMessage.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.CNTIFDGUDPXZGIFHXOOWMODHTPHYJDJHUXSRLAQPWDDEZIQWL) { }
            else if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_MUTED", player.UserIDString, FormatTime(Info.MuteInfo.GetTime(MuteType.Chat), player.UserIDString)));
                return;
            }
            String EBUVLKSBELXHSVBUERDCFDWZDBDBUQOUGAYVSVTNWKXRTXIOK = String.Empty;
            String GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Empty;
            String FormattingMessage = Message;
            String DisplayName = player.displayName;
            UInt64 UserID = player.userID;
            if (EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS != null)
            {
                DisplayName = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameNick;
                UserID = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameID;
            }
            String ColorNickPlayer = String.IsNullOrWhiteSpace(Info.Info.ColorNick) ? player.IsAdmin ? "#a8fc55" : "#54aafe" : Info.Info.ColorNick;
            DisplayName = $"<color={ColorNickPlayer}>{DisplayName}</color>";
            String ChannelMessage = channel == Chat.ChatChannel.Team ? "<color=#a5e664>[Team]</color>" : channel == Chat.ChatChannel.Cards ? "<color=#AA8234>[Cards]</color>" : "";
            if (ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.SPSDYJDGFXLAXEPBDLDFQLVJUSKAXMHXMYGKQHAYGSFOQEQAP)
            {
                Tuple<String, Boolean> NOOITBFURJHRHOWDBRXFCIYPGUGFFGSOQTCAFXGW = TFPUIFCXSIEPJPLFKTAXQYWDDXNQXDZHLZTUMNOXSHEURV(Message, ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU, ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT);
                FormattingMessage = NOOITBFURJHRHOWDBRXFCIYPGUGFFGSOQTCAFXGW.Item1;
                if (NOOITBFURJHRHOWDBRXFCIYPGUGFFGSOQTCAFXGW.Item2 && channel == Chat.ChatChannel.Global)
                {
                    if (permission.UserHasPermission(player.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) ZXUFHTIMNIUJCVLNDMEOPJNTVJEYBYGBDDQPWSSKGKUXDHPPE(player);
                    if (LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL.GYAVWNPXZXUIGUYFFZRRURTOYNBJYTUAGXHKLRROIZKNWM) KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(player, MuteType.Chat, 0, null, LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL.UMIRLSUWOFMXILFZGDUCJNNTOHCIUGGSLGGXPCIIMA.Reason, LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL.UMIRLSUWOFMXILFZGDUCJNNTOHCIUGGSLGGXPCIIMA.MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT);
                }
            }
            if (ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.XVDPKOKLPQWHLAGPFJQOWXYZAJKYIKZKMBFNEEMDHZK) FormattingMessage = $"{FormattingMessage.Substring(0, 1).ToUpper()}{FormattingMessage.Remove(0, 1).ToLower()}";
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB)
            {
                if (Info.Info.PrefixList != null) GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Join("", Info.Info.PrefixList.Take(NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC));
            }
            else GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Info.Info.Prefix;
            String ResultMessage = String.IsNullOrWhiteSpace(Info.Info.ColorMessage) ? FormattingMessage : $"<color={Info.Info.ColorMessage}>{FormattingMessage}</color>";
            String ResultReference = EAKOKYMFXNNHDYGYGOUSXACZQBETFSVOLRDOZODPSJEIUXRWX(player);
            EBUVLKSBELXHSVBUERDCFDWZDBDBUQOUGAYVSVTNWKXRTXIOK = $"{ChannelMessage} {ResultReference}<size={OtherController.SizePrefix}>{GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP}</size> <size={OtherController.SizeNick}>{DisplayName}</size>: <size={OtherController.SizeMessage}>{ResultMessage}</size>";
            if (config.RustPlusSettings.UseRustPlus)
                if (channel == Chat.ChatChannel.Team)
                {
                    RelationshipManager.PlayerTeam Team = RelationshipManager.ServerInstance.FindTeam(player.currentTeam);
                    if (Team == null) return;
                    Util.BroadcastTeamChat(player.Team, player.userID, player.displayName, FormattingMessage, Info.Info.ColorMessage);
                }
            if (LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.FZTIDDAEJCKXHYPCDQLBIYULCEIJEULPIUIUVZYFUCWQBIZ.AZFSAYKGFIGYURZPQUPMQVHERGHGBDKTFJIEPSPKKBONTAKCC && config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsMuted.UseLogged) QIVJTQMLJQODPYUFIKIOMBAGEYAQSVHVQMCKUCWY(player, FormattingMessage);
            LPPSTZKIJCOIOTHSVGEVROIHPREJYCFIFLGQDSRWA(channel, player, EBUVLKSBELXHSVBUERDCFDWZDBDBUQOUGAYVSVTNWKXRTXIOK);
            RSXAOZLLMSYKAIVPOMRONVXFFXNZXBUAFJFLFABRZXFA(player, ResultMessage.ToLower());
            Puts($"{player.displayName}({player.UserIDString}): {FormattingMessage}");
            XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"CHAT MESSAGE : {player}: {ChannelMessage} {FormattingMessage}" : $"СООБЩЕНИЕ В ЧАТ : {player}: {ChannelMessage} {FormattingMessage}");
            JDSCSLUGBRVAWBAEUKHAMQBCCQWGXILVMRDEOAKMEWENOVV(player, channel, Message);
            RCon.Broadcast(RCon.LogType.Chat, new Chat.ChatEntry
            {
                Message = $"{player.displayName} : {FormattingMessage}",
                UserId = player.UserIDString,
                Username = player.displayName,
                Channel = channel,
                Time = (DateTime.UtcNow.Hour * 3600) + (DateTime.UtcNow.Minute * 60),
            });
        }
        public class Footer
        {
            public string text
            {
                get;
                set;
            }
            public string icon_url
            {
                get;
                set;
            }
            public string proxy_icon_url
            {
                get;
                set;
            }
            public Footer(string text, string icon_url, string proxy_icon_url)
            {
                this.text = text;
                this.icon_url = icon_url;
                this.proxy_icon_url = proxy_icon_url;
            }
        }
        [ConsoleCommand("rename")]
        private void JZEZHFXBPABGUBHVXDFLVNGBIDVVUILEZWBKTRWLOOENIR(ConsoleSystem.Arg args)
        {
            BasePlayer GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ = args.Player();
            if (GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ == null)
            {
                PrintWarning(LanguageEn ? "You can only use this command while on the server" : "Вы можете использовать эту команду только находясь на сервере");
                return;
            }
            if (!permission.UserHasPermission(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString, PermissionRename)) return;
            GeneralInformation General = GeneralInfo;
            if (General == null) return;
            if (args.Args.Length == 0 || args == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, lang.GetMessage("COMMAND_RENAME_NOTARG", this, GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString));
                return;
            }
            String Name = args.Args[0];
            UInt64 ID = GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID;
            if (args.Args.Length == 2 && args.Args[1] != null && !String.IsNullOrWhiteSpace(args.Args[1]))
                if (!UInt64.TryParse(args.Args[1], out ID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, lang.GetMessage("COMMAND_RENAME_NOT_ID", this, GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString));
                    return;
                }
            if (General.RenameList.ContainsKey(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID))
            {
                General.RenameList[GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID].RenameNick = Name;
                General.RenameList[GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID].RenameID = ID;
            }
            else General.RenameList.Add(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID, new GeneralInformation.RenameInfo
            {
                RenameNick = Name,
                RenameID = ID
            });
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, GetLang("COMMAND_RENAME_SUCCES", GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString, Name, ID));
            GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.displayName = Name;
        }
        void QRGSHYGVVSDREJCGHPWGXAWCGGTXGJTSQPFDOQDGSBFSP(ulong userID, string QMJHWFPWUBBLPXJPPGHFHOHIICRNSJIICQMVXGRTBPODMVSF) => IQRankSystem?.Call("API_SET_ACTIVE_RANK", userID, QMJHWFPWUBBLPXJPPGHFHOHIICRNSJIICQMVXGRTBPODMVSF);
        [ConsoleCommand("set")]
        private void SBLIXYLKQPUDLBEJOMZKAOEYRQLQOVUENHNRLYLVHGYPJLECB(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.IsAdmin) return;
            if (args == null || args.Args == null || args.Args.Length != 3)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "Use syntax correctly : set [Steam64ID] [prefix/chat/nick/custom] [Argument]" : "Используйте правильно ситаксис : set [Steam64ID] [prefix/chat/nick/custom] [Argument]");
                else PrintWarning(LanguageEn ? "Use syntax correctly : set [Steam64ID] [prefix/chat/nick/custom] [Argument]" : "Используйте правильно ситаксис : set [Steam64ID] [prefix/chat/nick/custom] [Argument]");
                return;
            }
            UInt64 Steam64ID = 0;
            BasePlayer player = null;
            if (UInt64.TryParse(args.Args[0], out Steam64ID)) player = BasePlayer.FindByID(Steam64ID);
            if (player == null)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "Incorrect player Steam ID or syntax error\nUse syntax correctly : set [Steam64ID] [prefix/chat/nick/custom] [Argument]" : "Неверно указан SteamID игрока или ошибка в синтаксисе\nИспользуйте правильно ситаксис : set [Steam64ID] [prefix/chat/nick/custom] [Argument]");
                else PrintWarning(LanguageEn ? "Incorrect player Steam ID or syntax error\nUse syntax correctly : set [Steam64ID] [prefix/chat/nick/custom] [Argument]" : "Неверно указан SteamID игрока или ошибка в синтаксисе\nИспользуйте правильно ситаксис : set [Steam64ID] [prefix/chat/nick/custom] [Argument]");
                return;
            }
            if (!UserInformation.ContainsKey(player.userID))
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Player not found!" : $"Игрок не найден!");
                else PrintWarning(LanguageEn ? $"Player not found!" : $"Игрок не найден!");
                return;
            }
            User Info = UserInformation[player.userID];
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            switch (args.Args[1])
            {
                case "prefix":
                    {
                        String CWZLXRHJFRWWJTOIALEBPUEWKGLAXASNCSAVPNONJTAGHD = args.Args[2];
                        if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Count(prefix => prefix.Argument.Contains(CWZLXRHJFRWWJTOIALEBPUEWKGLAXASNCSAVPNONJTAGHD)) == 0)
                        {
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "Argument not found in your configuration" : $"Аргумент не найден в вашей конфигурации!");
                            else PrintWarning(LanguageEn ? $"Argument not found in your configuration" : $"Аргумент не найден в вашей конфигурации");
                            return;
                        }
                        foreach (Configuration.ControllerParameters.AdvancedFuncion Prefix in NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Where(prefix => prefix.Argument.Contains(CWZLXRHJFRWWJTOIALEBPUEWKGLAXASNCSAVPNONJTAGHD)).Take(1))
                        {
                            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) Info.Info.PrefixList.Add(Prefix.Argument);
                            else Info.Info.Prefix = Prefix.Argument;
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Prefix successfully set to - {Prefix.Argument}" : $"Префикс успешно установлен на - {Prefix.Argument}");
                            else Puts(LanguageEn ? $"Prefix successfully set to - {Prefix.Argument}" : $"Префикс успешно установлен на - {Prefix.Argument}");
                        }
                        break;
                    }
                case "chat":
                    {
                        String YBJUEWXAISCBRGGMEYJTQTTSMWQRWTXPGFMZOGOQ = args.Args[2];
                        if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ.Count(color => color.Argument.Contains(YBJUEWXAISCBRGGMEYJTQTTSMWQRWTXPGFMZOGOQ)) == 0)
                        {
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Argument not found in your configuration!" : $"Аргумент не найден в вашей конфигурации!");
                            else PrintWarning(LanguageEn ? $"Argument not found in your configuration" : $"Аргумент не найден в вашей конфигурации");
                            return;
                        }
                        foreach (Configuration.ControllerParameters.AdvancedFuncion ChatColor in NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ.Where(color => color.Argument.Contains(YBJUEWXAISCBRGGMEYJTQTTSMWQRWTXPGFMZOGOQ)).Take(1))
                        {
                            Info.Info.ColorMessage = ChatColor.Argument;
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Message color successfully set to - {ChatColor.Argument}" : $"Цвет сообщения успешно установлен на - {ChatColor.Argument}");
                            else Puts(LanguageEn ? $"Message color successfully set to - {ChatColor.Argument}" : $"Цвет сообщения успешно установлен на - {ChatColor.Argument}");
                        }
                        break;
                    }
                case "nick":
                    {
                        String SSCMMXGDHWIXJKFHQIHFGEOUNULUHYYKSOXBQGZZKN = args.Args[2];
                        if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ.Count(color => color.Argument.Contains(SSCMMXGDHWIXJKFHQIHFGEOUNULUHYYKSOXBQGZZKN)) == 0)
                        {
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Argument not found in your configuration!" : $"Аргумент не найден в вашей конфигурации!");
                            else PrintWarning(LanguageEn ? "Argument not found in your configuration" : $"Аргумент не найден в вашей конфигурации");
                            return;
                        }
                        foreach (Configuration.ControllerParameters.AdvancedFuncion NickColor in NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ.Where(color => color.Argument.Contains(SSCMMXGDHWIXJKFHQIHFGEOUNULUHYYKSOXBQGZZKN)).Take(1))
                        {
                            Info.Info.ColorNick = NickColor.Argument;
                            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Message color successfully set to - {NickColor.Argument}" : $"Цвет сообщения успешно установлен на - {NickColor.Argument}");
                            else Puts(LanguageEn ? $"Message color successfully set to - {NickColor.Argument}" : $"Цвет сообщения успешно установлен на - {NickColor.Argument}");
                        }
                        break;
                    }
                case "custom":
                    {
                        String XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH = args.Args[2];
                        if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) Info.Info.PrefixList.Add(XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH);
                        else Info.Info.Prefix = XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH;
                        if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? $"Custom prefix successfully set to - {XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH}" : $"Кастомный префикс успешно установлен на - {XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH}");
                        else Puts(LanguageEn ? $"Custom prefix successfully set to - {XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH}" : $"Кастомный префикс успешно установлен на - {XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH}");
                        break;
                    }
                default:
                    {
                        if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "Use syntax correctly : set [Steam64ID] [prefix/chat/nick/custom] [Argument]" : "Используйте правильно ситаксис : set [Steam64ID] [prefix/chat/nick/custom] [Argument]");
                        break;
                    }
            }
        }
        private class ConfigurationOld
        {
            [JsonProperty(LanguageEn ? "Setting up player information" : "Настройка информации о игроке")] public ControllerConnection ControllerConnect = new ControllerConnection();
            internal class ControllerConnection
            {
                [JsonProperty(LanguageEn ? "Function switches" : "Перключатели функций")] public Turned JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN = new Turned();
                [JsonProperty(LanguageEn ? "Setting Standard Values" : "Настройка стандартных значений")] public SetupDefault WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW = new SetupDefault();
                internal class SetupDefault
                {
                    [JsonProperty(LanguageEn ? "This prefix will be set if the player entered the server for the first time or in case of expiration of the rights to the prefix that he had earlier" : "Данный префикс установится если игрок впервые зашел на сервер или в случае окончания прав на префикс, который у него стоял ранее")] public String UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN = "<color=#CC99FF>[ИГРОК]</color>";
                    [JsonProperty(LanguageEn ? "This nickname color will be set if the player entered the server for the first time or in case of expiration of the rights to the nickname color that he had earlier" : "Данный цвет ника установится если игрок впервые зашел на сервер или в случае окончания прав на цвет ника, который у него стоял ранее")] public String NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK = "#33CCCC";
                    [JsonProperty(LanguageEn ? "This chat color will be set if the player entered the server for the first time or in case of expiration of the rights to the chat color that he had earlier" : "Данный цвет чата установится если игрок впервые зашел на сервер или в случае окончания прав на цвет чата, который у него стоял ранее")] public String MessageDefault = "#0099FF";
                }
                internal class Turned
                {
                    [JsonProperty(LanguageEn ? "Set automatically a prefix to a player when he got the rights to it" : "Устанавливать автоматически префикс игроку, когда он получил права на него")] public Boolean PGVXJYGKGXGAPYUBPIGKKNOUZRUMUMLLMCBJYQALYYOD;
                    [JsonProperty(LanguageEn ? "Set automatically the color of the nickname to the player when he got the rights to it" : "Устанавливать автоматически цвет ника игроку, когда он получил права на него")] public Boolean PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI;
                    [JsonProperty(LanguageEn ? "Set the chat color automatically to the player when he got the rights to it" : "Устанавливать автоматически цвет чата игроку, когда он получил права на него")] public Boolean FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK;
                    [JsonProperty(LanguageEn ? "Automatically reset the prefix when the player's rights to it expire" : "Сбрасывать автоматически префикс при окончании прав на него у игрока")] public Boolean DNQWOULREBBRIIBYYICCWZINIJALPERJDIICOFWDHNAXLO;
                    [JsonProperty(LanguageEn ? "Automatically reset the color of the nickname when the player's rights to it expire" : "Сбрасывать автоматически цвет ника при окончании прав на него у игрока")] public Boolean UTRKHVIUEFDOETABAKROZAYKTMYUJYKBUOGSYUJOUODXLRRJ;
                    [JsonProperty(LanguageEn ? "Automatically reset the color of the chat when the rights to it from the player expire" : "Сбрасывать автоматически цвет чата при окончании прав на него у игрока")] public Boolean LANTZVTUHQVWNLGUBTQNHDGACTLWAYCUPMXXXHVTMX;
                }
            }
            [JsonProperty(LanguageEn ? "Setting options for the player" : "Настройка параметров для игрока")] public ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = new ControllerParameters();
            internal class ControllerParameters
            {
                [JsonProperty(LanguageEn ? "Setting the display of options for player selection" : "Настройка отображения параметров для выбора игрока")] public VisualSettingParametres DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM = new VisualSettingParametres();
                [JsonProperty(LanguageEn ? "List and customization of colors for a nickname" : "Список и настройка цветов для ника")] public List<AdvancedFuncion> DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ = new List<AdvancedFuncion>();
                [JsonProperty(LanguageEn ? "List and customize colors for chat messages" : "Список и настройка цветов для сообщений в чате")] public List<AdvancedFuncion> RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ = new List<AdvancedFuncion>();
                [JsonProperty(LanguageEn ? "List and configuration of prefixes in chat" : "Список и настройка префиксов в чате")] public PrefixSetting GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new PrefixSetting();
                internal class PrefixSetting
                {
                    [JsonProperty(LanguageEn ? "Enable support for multiple prefixes at once (true - multiple prefixes can be set/false - only 1 can be set to choose from)" : "Включить поддержку нескольких префиксов сразу (true - можно установить несколько префиксов/false - установить можно только 1 на выбор)")] public Boolean UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB;
                    [JsonProperty(LanguageEn ? "The maximum number of prefixes that can be set at a time (This option only works if setting multiple prefixes is enabled)" : "Максимальное количество префиксов, которое можно установить за раз(Данный параметр работает только если включена установка нескольких префиксов)")] public Int32 LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC;
                    [JsonProperty(LanguageEn ? "List of prefixes and their settings" : "Список префиксов и их настройка")] public List<AdvancedFuncion> GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new List<AdvancedFuncion>();
                }
                internal class AdvancedFuncion
                {
                    [JsonProperty(LanguageEn ? "Permission" : "Права")] public String Permissions;
                    [JsonProperty(LanguageEn ? "Argument" : "Значение")] public String Argument;
                }
                internal class VisualSettingParametres
                {
                    [JsonProperty(LanguageEn ? "Player prefix selection display type - (0 - dropdown list, 1 - slider (Please note that if you have multi-prefix enabled, the dropdown list will be set))" : "Тип отображения выбора префикса для игрока - (0 - выпадающий список, 1 - слайдер (Учтите, что если у вас включен мульти-префикс, будет установлен выпадающий список))")] public SelectedParametres NGSKGILLMUCIMZNQAEBTPLUEIFMEGOIKZPLBNSSCL;
                    [JsonProperty(LanguageEn ? "Display type of player's nickname color selection - (0 - drop-down list, 1 - slider)" : "Тип отображения выбора цвета ника для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres ZSMICAHWXCZJPBLOCBWHFYLSIXNLDILYICLBSZCMXKQGK;
                    [JsonProperty(LanguageEn ? "Display type of message color choice for the player - (0 - drop-down list, 1 - slider)" : "Тип отображения выбора цвета сообщения для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres ZJPYPRGEHAHTZFMVSOQABMQKWCYJJVIFHTXDVFSUSDUKUY;
                    [JsonProperty(LanguageEn ? "IQRankSystem : Player rank selection display type - (0 - drop-down list, 1 - slider)" : "IQRankSystem : Тип отображения выбора ранга для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres XABRBPJONTFCNTXVMSBLGIIANWWIXSGPXCAJHDGP;
                }
            }
            [JsonProperty(LanguageEn ? "Plugin mute settings" : "Настройка мута в плагине")] public ControllerMute LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = new ControllerMute();
            internal class ControllerMute
            {
                [JsonProperty(LanguageEn ? "Setting up automatic muting" : "Настройка автоматического мута")] public AutoMute EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL = new AutoMute();
                internal class AutoMute
                {
                    [JsonProperty(LanguageEn ? "Enable automatic muting for forbidden words (true - yes/false - no)" : "Включить автоматический мут по запрещенным словам(true - да/false - нет)")] public Boolean GYAVWNPXZXUIGUYFFZRRURTOYNBJYTUAGXHKLRROIZKNWM;
                    [JsonProperty(LanguageEn ? "Reason for automatic muting" : "Причина автоматического мута")] public Muted UMIRLSUWOFMXILFZGDUCJNNTOHCIUGGSLGGXPCIIMA;
                }
                [JsonProperty(LanguageEn ? "Additional setting for logging about mutes in discord" : "Дополнительная настройка для логирования о мутах в дискорд")] public LoggedFuncion FZTIDDAEJCKXHYPCDQLBIYULCEIJEULPIUIUVZYFUCWQBIZ = new LoggedFuncion();
                internal class LoggedFuncion
                {
                    [JsonProperty(LanguageEn ? "Support for logging the last N messages (Discord logging about mutes must be enabled)" : "Поддержка логирования последних N сообщений (Должно быть включено логирование в дискорд о мутах)")] public Boolean AZFSAYKGFIGYURZPQUPMQVHERGHGBDKTFJIEPSPKKBONTAKCC;
                    [JsonProperty(LanguageEn ? "How many latest player messages to send in logging" : "Сколько последних сообщений игрока отправлять в логировании")] public Int32 ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO;
                }
                [JsonProperty(LanguageEn ? "Reasons to block chat" : "Причины для блокировки чата")] public List<Muted> VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL = new List<Muted>();
                [JsonProperty(LanguageEn ? "Reasons to block your voice" : "Причины для блокировки голоса")] public List<Muted> BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL = new List<Muted>();
                internal class Muted
                {
                    [JsonProperty(LanguageEn ? "Reason for blocking" : "Причина для блокировки")] public String Reason;
                    [JsonProperty(LanguageEn ? "Block time (in seconds)" : "Время блокировки(в секундах)")] public Int32 MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT;
                }
            }
            [JsonProperty(LanguageEn ? "Configuring Message Processing" : "Настройка обработки сообщений")] public ControllerMessage ControllerMessages = new ControllerMessage();
            internal class ControllerMessage
            {
                [JsonProperty(LanguageEn ? "Basic settings for chat messages from the plugin" : "Основная настройка сообщений в чат от плагина")] public GeneralSettings YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV = new GeneralSettings();
                [JsonProperty(LanguageEn ? "Configuring functionality switching in chat" : "Настройка переключения функционала в чате")] public TurnedFuncional NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY = new TurnedFuncional();
                [JsonProperty(LanguageEn ? "Player message formatting settings" : "Настройка форматирования сообщений игроков")] public FormattingMessage HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ = new FormattingMessage();
                internal class GeneralSettings
                {
                    [JsonProperty(LanguageEn ? "Customizing the chat alert format" : "Настройка формата оповещения в чате")] public BroadcastSettings BroadcastFormat = new BroadcastSettings();
                    [JsonProperty(LanguageEn ? "Setting the mention format in the chat, via @" : "Настройка формата упоминания в чате, через @")] public AlertSettings PLOMZYCAZCHTFUCOKPXEIQGWVXQFAOOTGXSGZSDOMLILN = new AlertSettings();
                    [JsonProperty(LanguageEn ? "Additional setting" : "Дополнительная настройка")] public OtherSettings NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB = new OtherSettings();
                    internal class BroadcastSettings
                    {
                        [JsonProperty(LanguageEn ? "The name of the notification in the chat" : "Наименование оповещения в чат")] public String BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG;
                        [JsonProperty(LanguageEn ? "Chat alert message color" : "Цвет сообщения оповещения в чат")] public String LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH;
                        [JsonProperty(LanguageEn ? "Steam64ID for chat avatar" : "Steam64ID для аватарки в чате")] public String DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ;
                    }
                    internal class AlertSettings
                    {
                        [JsonProperty(LanguageEn ? "The color of the player mention message in the chat" : "Цвет сообщения упоминания игрока в чате")] public String WVVQCIPDROVHWIIBDQRMRHCJHBRVSLQHPKCTDKTUSTCQLRRH;
                        [JsonProperty(LanguageEn ? "Sound when receiving and sending a mention via @" : "Звук при при получении и отправки упоминания через @")] public String PFYMWEPTMJARTLGYNSMFPYSWWUYELXPJKECGSVSGNARBTC;
                    }
                    internal class OtherSettings
                    {
                        [JsonProperty(LanguageEn ? "Time after which the message will be deleted from the UI from the administrator" : "Время,через которое удалится сообщение с UI от администратора")] public Int32 IWSYZFBBRMBPBFKHPTQGOIZGSZFRPGRDTVQITYPEIDLUQFRAD;
                        [JsonProperty(LanguageEn ? "The size of the message from the player in the chat" : "Размер сообщения от игрока в чате")] public Int32 SizeMessage = 14;
                        [JsonProperty(LanguageEn ? "Player nickname size in chat" : "Размер ника игрока в чате")] public Int32 SizeNick = 14;
                        [JsonProperty(LanguageEn ? "The size of the player's prefix in the chat (will be used if <size=N></size> is not set in the prefix itself)" : "Размер префикса игрока в чате (будет использовано, если в самом префиксе не установвлен <size=N></size>)")] public Int32 SizePrefix = 14;
                    }
                }
                internal class TurnedFuncional
                {
                    [JsonProperty(LanguageEn ? "Configuring spam protection" : "Настройка защиты от спама")] public AntiSpam RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM = new AntiSpam();
                    [JsonProperty(LanguageEn ? "Setting up a temporary chat block for newbies (who have just logged into the server)" : "Настройка временной блокировки чата новичкам (которые только зашли на сервер)")] public AntiNoob PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU = new AntiNoob();
                    [JsonProperty(LanguageEn ? "Setting up private messages" : "Настройка личных сообщений")] public PM XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ = new PM();
                    internal class AntiNoob
                    {
                        [JsonProperty(LanguageEn ? "Newbie protection in PM/R" : "Защита от новичка в PM/R")] public Settings GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS = new Settings();
                        [JsonProperty(LanguageEn ? "Newbie protection in global and team chat" : "Защита от новичка в глобальном и коммандном чате")] public Settings OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY = new Settings();
                        internal class Settings
                        {
                            [JsonProperty(LanguageEn ? "Enable protection?" : "Включить защиту?")] public Boolean BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP = false;
                            [JsonProperty(LanguageEn ? "Newbie Chat Lock Time" : "Время блокировки чата для новичка")] public Int32 KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI = 1200;
                        }
                    }
                    internal class AntiSpam
                    {
                        [JsonProperty(LanguageEn ? "Enable spam protection (Anti-spam)" : "Включить защиту от спама (Анти-спам)")] public Boolean NPIQMTLXTMSNVSLJMKXEUZDKNLVDZBIYJCVJZHVTRPLH;
                        [JsonProperty(LanguageEn ? "Time after which a player can send a message (AntiSpam)" : "Время через которое игрок может отправлять сообщение (АнтиСпам)")] public Int32 HDRNMJFAERNMYDAXIYSETDSXCKFOEMFOWHFIEPMRC;
                        [JsonProperty(LanguageEn ? "Additional Anti-Spam settings" : "Дополнительная настройка Анти-Спама")] public AntiSpamDuples FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX = new AntiSpamDuples();
                        internal class AntiSpamDuples
                        {
                            [JsonProperty(LanguageEn ? "Enable additional spam protection (Anti-duplicates, duplicate messages)" : "Включить дополнительную защиту от спама (Анти-дубликаты, повторяющие сообщения)")] public Boolean EKNLBNZJGKGCCRFSBNEEFFSCXNOYCXSVUKNAMQTLHFZ = true;
                            [JsonProperty(LanguageEn ? "How many duplicate messages does a player need to make to be confused by the system" : "Сколько дублирующих сообщений нужно сделать игроку чтобы его замутила система")] public Int32 VQGLICRKXTEZSKNNZAHISKHRDEGLUTXZGSHGHCPZGHXBFOICC = 3;
                            [JsonProperty(LanguageEn ? "Setting up automatic muting for duplicates" : "Настройка автоматического мута за дубликаты")]
                            public ControllerMute.Muted MGYQHKJOIDWFQEWESADGGWLHCKNGMOWEIOHQAQKWXT = new ControllerMute.Muted
                            {
                                Reason = LanguageEn ? "Blocking for duplicate messages (SPAM)" : "Блокировка за дублирующие сообщения (СПАМ)",
                                MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                            };
                        }
                    }
                    internal class PM
                    {
                        [JsonProperty(LanguageEn ? "Enable Private Messages" : "Включить личные сообщения")] public Boolean LCAQTFAVHYWZPVROWXDBTHSXBWFECQHIMCZEBUTALSPFMPS;
                        [JsonProperty(LanguageEn ? "Sound when receiving a private message" : "Звук при при получении личного сообщения")] public String JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO;
                    }
                    [JsonProperty(LanguageEn ? "Enable PM ignore for players (/ignore nick or via interface)" : "Включить игнор ЛС игрокам(/ignore nick или через интерфейс)")] public Boolean YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW;
                    [JsonProperty(LanguageEn ? "Hide the issue of items to the Admin from the chat" : "Скрыть из чата выдачу предметов Админу")] public Boolean BDKMGKGZLVXEBMLQZYSZGUUEEIVSCYHTWIWERPVJRM;
                    [JsonProperty(LanguageEn ? "Move mute to team chat (In case of a mute, the player will not be able to write even to the team chat)" : "Переносить мут в командный чат(В случае мута, игрок не сможет писать даже в командный чат)")] public Boolean CNTIFDGUDPXZGIFHXOOWMODHTPHYJDJHUXSRLAQPWDDEZIQWL;
                }
                internal class FormattingMessage
                {
                    [JsonProperty(LanguageEn ? "Enable message formatting [Will control caps, message format] (true - yes/false - no)" : "Включить форматирование сообщений [Будет контроллировать капс, формат сообщения] (true - да/false - нет)")] public Boolean XVDPKOKLPQWHLAGPFJQOWXYZAJKYIKZKMBFNEEMDHZK;
                    [JsonProperty(LanguageEn ? "Use a list of banned words (true - yes/false - no)" : "Использовать список запрещенных слов (true - да/false - нет)")] public Boolean SPSDYJDGFXLAXEPBDLDFQLVJUSKAXMHXMYGKQHAYGSFOQEQAP;
                    [JsonProperty(LanguageEn ? "The word that will replace the forbidden word" : "Слово которое будет заменять запрещенное слово")] public String ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU;
                    [JsonProperty(LanguageEn ? "List of banned words" : "Список запрещенных слов")] public List<String> GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT = new List<String>();
                    [JsonProperty(LanguageEn ? "Nickname controller setup" : "Настройка контроллера ников")] public NickController CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC = new NickController();
                    internal class NickController
                    {
                        [JsonProperty(LanguageEn ? "Enable player nickname formatting (message formatting must be enabled)" : "Включить форматирование ников игроков (должно быть включено форматирование сообщений)")] public Boolean DRHQLJMHSPIGEXWGVNKXGFYSSFUKWGDGHYKLPZTMCMPAQEDBQ = true;
                        [JsonProperty(LanguageEn ? "The word that will replace the forbidden word (You can leave it blank and it will just delete)" : "Слово которое будет заменять запрещенное слово (Вы можете оставить пустым и будет просто удалять)")] public String DVPFTYSPYFPBLMMBZGNKRWTYVTPYBOBSTTCHRCEM = "****";
                        [JsonProperty(LanguageEn ? "List of banned nicknames" : "Список запрещенных ников")] public List<String> AANXABDOOEXNGKHCRKZIUOKDWIRJFKXBBSRVGAURLJMJEFN = new List<String>();
                    }
                }
            }
            [JsonProperty(LanguageEn ? "Setting up chat alerts" : "Настройка оповещений в чате")] public ControllerAlert ControllerAlertSetting;
            internal class ControllerAlert
            {
                [JsonProperty(LanguageEn ? "Setting up chat alerts" : "Настройка оповещений в чате")] public Alert AlertSetting;
                [JsonProperty(LanguageEn ? "Setting notifications about the status of the player's session" : "Настройка оповещений о статусе сессии игрока")] public PlayerSession PlayerSessionSetting;
                [JsonProperty(LanguageEn ? "Configuring administrator session status alerts" : "Настройка оповещений о статусе сессии администратора")] public AdminSession AdminSessionSetting;
                [JsonProperty(LanguageEn ? "Setting up personal notifications to the player when connecting" : "Настройка персональных оповоещений игроку при коннекте")] public PersonalAlert PersonalAlertSetting;
                internal class Alert
                {
                    [JsonProperty(LanguageEn ? "Enable automatic messages in chat (true - yes/false - no)" : "Включить автоматические сообщения в чат (true - да/false - нет)")] public Boolean AlertMessage;
                    [JsonProperty(LanguageEn ? "Type of automatic messages : true - sequential / false - random" : "Тип автоматических сообщений : true - поочередные/false - случайные")] public Boolean AlertMessageType;
                    [JsonProperty(LanguageEn ? "List of automatic messages in chat" : "Список автоматических сообщений в чат")] public List<String> MessageList;
                    [JsonProperty(LanguageEn ? "Interval for sending messages to chat (Broadcaster) (in seconds)" : "Интервал отправки сообщений в чат (Броадкастер) (в секундах)")] public Int32 MessageListTimer;
                }
                internal class PlayerSession
                {
                    [JsonProperty(LanguageEn ? "When a player is notified about the entry / exit of the player, display his avatar opposite the nickname (true - yes / false - no)" : "При уведомлении о входе/выходе игрока отображать его аватар напротив ника (true - да/false - нет)")] public Boolean ConnectedAvatarUse;
                    [JsonProperty(LanguageEn ? "Notify in chat when a player enters (true - yes/false - no)" : "Уведомлять в чате о входе игрока (true - да/false - нет)")] public Boolean ConnectedAlert;
                    [JsonProperty(LanguageEn ? "Enable random notifications when a player from the list enters (true - yes / false - no)" : "Включить случайные уведомления о входе игрока из списка (true - да/false - нет)")] public Boolean ConnectionAlertRandom;
                    [JsonProperty(LanguageEn ? "Show the country of the entered player (true - yes/false - no)" : "Отображать страну зашедшего игрока (true - да/false - нет")] public Boolean ConnectedWorld;
                    [JsonProperty(LanguageEn ? "Notify when a player enters the chat (selected from the list) (true - yes/false - no)" : "Уведомлять о выходе игрока в чат(выбираются из списка) (true - да/false - нет)")] public Boolean DisconnectedAlert;
                    [JsonProperty(LanguageEn ? "Enable random player exit notifications (true - yes/false - no)" : "Включить случайные уведомления о выходе игрока (true - да/false - нет)")] public Boolean DisconnectedAlertRandom;
                    [JsonProperty(LanguageEn ? "Display reason for player exit (true - yes/false - no)" : "Отображать причину выхода игрока (true - да/false - нет)")] public Boolean DisconnectedReason;
                    [JsonProperty(LanguageEn ? "Random player entry notifications({0} - player's nickname, {1} - country (if country display is enabled)" : "Случайные уведомления о входе игрока({0} - ник игрока, {1} - страна(если включено отображение страны)")] public List<String> RandomConnectionAlert = new List<String>();
                    [JsonProperty(LanguageEn ? "Random notifications about the exit of the player ({0} - player's nickname, {1} - the reason for the exit (if the reason is enabled)" : "Случайные уведомления о выходе игрока({0} - ник игрока, {1} - причина выхода(если включена причина)")] public List<String> RandomDisconnectedAlert = new List<String>();
                }
                internal class AdminSession
                {
                    [JsonProperty(LanguageEn ? "Notify admin on the server in the chat (true - yes/false - no)" : "Уведомлять о входе админа на сервер в чат (true - да/false - нет)")] public Boolean ConnectedAlertAdmin;
                    [JsonProperty(LanguageEn ? "Notify about admin leaving the server in chat (true - yes/false - no)" : "Уведомлять о выходе админа на сервер в чат (true - да/false - нет)")] public Boolean DisconnectedAlertAdmin;
                }
                internal class PersonalAlert
                {
                    [JsonProperty(LanguageEn ? "Enable random message to the player who has logged in (true - yes/false - no)" : "Включить случайное сообщение зашедшему игроку (true - да/false - нет)")] public Boolean UseWelcomeMessage;
                    [JsonProperty(LanguageEn ? "List of messages to the player when entering" : "Список сообщений игроку при входе")] public List<String> WelcomeMessage = new List<String>();
                }
            }
            [JsonProperty(LanguageEn ? "Settings Rust+" : "Настройка Rust+")] public RustPlus RustPlusSettings;
            internal class RustPlus
            {
                [JsonProperty(LanguageEn ? "Use Rust+" : "Использовать Rust+")] public Boolean UseRustPlus;
                [JsonProperty(LanguageEn ? "Title for notification Rust+" : "Название для уведомления Rust+")] public String DisplayNameAlert;
            }
            [JsonProperty(LanguageEn ? "Configuring support plugins" : "Настройка плагинов поддержки")] public ReferenceSettings ReferenceSetting = new ReferenceSettings();
            internal class ReferenceSettings
            {
                [JsonProperty(LanguageEn ? "Settings IQFakeActive" : "Настройка IQFakeActive")] public IQFakeActive IQFakeActiveSettings = new IQFakeActive();
                [JsonProperty(LanguageEn ? "Settings IQRankSystem" : "Настройка IQRankSystem")] public IQRankSystem IQRankSystems = new IQRankSystem();
                internal class IQRankSystem
                {
                    [JsonProperty(LanguageEn ? "Rank display format in chat ( {0} is the user's rank, do not delete this value)" : "Формат отображения ранга в чате ( {0} - это ранг юзера, не удаляйте это значение)")] public String FormatRank = "[{0}]";
                    [JsonProperty(LanguageEn ? "Time display format with IQRank System in chat ( {0} is the user's time, do not delete this value)" : "Формат отображения времени с IQRankSystem в чате ( {0} - это время юзера, не удаляйте это значение)")] public String FormatRankTime = "[{0}]";
                    [JsonProperty(LanguageEn ? "Use support IQRankSystem" : "Использовать поддержку рангов")] public Boolean UseRankSystem;
                    [JsonProperty(LanguageEn ? "Show players their played time next to their rank" : "Отображать игрокам их отыгранное время рядом с рангом")] public Boolean UseTimeStandart;
                }
                internal class IQFakeActive
                {
                    [JsonProperty(LanguageEn ? "Use support IQFakeActive" : "Использовать поддержку IQFakeActive")] public Boolean UseIQFakeActive;
                }
            }
            [JsonProperty(LanguageEn ? "Setting up an answering machine" : "Настройка автоответчика")] public AnswerMessage AnswerMessages = new AnswerMessage();
            internal class AnswerMessage
            {
                [JsonProperty(LanguageEn ? "Enable auto-reply? (true - yes/false - no)" : "Включить автоответчик?(true - да/false - нет)")] public bool UseAnswer;
                [JsonProperty(LanguageEn ? "Customize Messages [Keyword] = Reply" : "Настройка сообщений [Ключевое слово] = Ответ")] public Dictionary<String, String> AnswerMessageList = new Dictionary<String, String>();
            }
            [JsonProperty(LanguageEn ? "Additional setting" : "Дополнительная настройка")] public OtherSettings NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB;
            internal class OtherSettings
            {
                [JsonProperty(LanguageEn ? "Setting up message logging" : "Настройка логирования сообщений")] public LoggedChat LogsChat = new LoggedChat();
                [JsonProperty(LanguageEn ? "Setting up logging of personal messages of players" : "Настройка логирования личных сообщений игроков")] public General LogsPMChat = new General();
                [JsonProperty(LanguageEn ? "Setting up chat/voice lock/unlock logging" : "Настройка логирования блокировок/разблокировок чата/голоса")] public General LogsMuted = new General();
                [JsonProperty(LanguageEn ? "Setting up logging of chat commands from players" : "Настройка логирования чат-команд от игроков")] public General LogsChatCommands = new General();
                internal class LoggedChat
                {
                    [JsonProperty(LanguageEn ? "Setting up general chat logging" : "Настройка логирования общего чата")] public General GlobalChatSettings = new General();
                    [JsonProperty(LanguageEn ? "Setting up team chat logging" : "Настройка логирования тим чата")] public General TeamChatSettings = new General();
                }
                internal class General
                {
                    [JsonProperty(LanguageEn ? "Enable logging (true - yes/false - no)" : "Включить логирование (true - да/false - нет)")] public Boolean UseLogged = false;
                    [JsonProperty(LanguageEn ? "Webhooks channel for logging" : "Webhooks канала для логирования")] public String Webhooks = "";
                }
            }
        }
        public string GetLang(string NUDCENBFBYUNBDLSSIZLOSJOODSAEVMJMIFPFGYCKP, string userID = null, params object[] args)
        {
            VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.Clear();
            if (args != null)
            {
                VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.AppendFormat(lang.GetMessage(NUDCENBFBYUNBDLSSIZLOSJOODSAEVMJMIFPFGYCKP, this, userID), args);
                return VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.ToString();
            }
            return lang.GetMessage(NUDCENBFBYUNBDLSSIZLOSJOODSAEVMJMIFPFGYCKP, this, userID);
        }
        private String ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM(String HXFALCKUMTTRUKPOAVBBGMKBSYWNMJWBYXBQIDGXTAAQSQKE, UInt64 skin = 0)
        {
            var imageId = (String)plugins.Find("ImageLibrary").Call("GetImage", HXFALCKUMTTRUKPOAVBBGMKBSYWNMJWBYXBQIDGXTAAQSQKE, skin);
            if (!string.IsNullOrEmpty(imageId)) return imageId;
            return String.Empty;
        }
        private void ZULJWHDVLBXLEFVQAPODKWMOXTJVAOBZHKGUBKHZSIHXKJR(BasePlayer player, String OffsetMin, String OffsetMax, String Title, TakeElementUser RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_DropList");
            if (Interface == null) return;
            Interface = Interface.Replace("%TITLE%", Title);
            Interface = Interface.Replace("%OFFSET_MIN%", OffsetMin);
            Interface = Interface.Replace("%OFFSET_MAX%", OffsetMax);
            Interface = Interface.Replace("%BUTTON_DROP_LIST_CMD%", $"newui.cmd droplist.controller open {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR}");
            CuiHelper.AddUi(player, Interface);
        }
        [ChatCommand("hmute")]
        void IRKODLLTKXYTWBQYOIDIJRUFRLUMUUXMJKZDUCNCZSLLHG(BasePlayer Moderator, string cmd, string[] arg)
        {
            if (!permission.UserHasPermission(Moderator.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Length != 3 || arg.Length > 3)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Invalid syntax, use : hmute Steam64ID/Nick Reason Time(seconds)" : "Неверный синтаксис,используйте : hmute Steam64ID/Ник Причина Время(секунды)");
                return;
            }
            string NameOrID = arg[0];
            string Reason = arg[1];
            Int32 TimeMute = 0;
            if (!Int32.TryParse(arg[2], out TimeMute))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Enter the time in numbers!" : "Введите время цифрами!");
                return;
            }
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "The player already has a chat lock" : "Игрок уже имеет блокировку чата");
                            return;
                        }
                        Info.MuteInfo.QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(MuteType.Chat, TimeMute);
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Chat blocking issued to offline player" : "Блокировка чата выдана offline-игроку");
                        return;
                    }
                    else
                    {
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(target, MuteType.Chat, 0, Moderator, Reason, TimeMute, true, true);
        }
        void NWTGVJJDIWLCYHUWZYETYAPQHPKCOOEOCWIEUVEYBDME()
        {
            Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQSystem/IQChat/Information", GeneralInfo);
            Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQSystem/IQChat/Users", UserInformation);
            Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQSystem/IQChat/AntiNoob", UserInformationConnection);
        }
        private String EAKOKYMFXNNHDYGYGOUSXACZQBETFSVOLRDOZODPSJEIUXRWX(BasePlayer player)
        {
            String Result = String.Empty;
            String Rank = String.Empty;
            String RankTime = String.Empty;
            if (IQRankSystem)
            {
                Configuration.ReferenceSettings.IQRankSystem IQRank = config.ReferenceSetting.IQRankSystems;
                if (IQRank.UseRankSystem)
                {
                    if (IQRank.UseTimeStandart) RankTime = String.IsNullOrWhiteSpace(OGDNBLPLELHGXIKLESNPZVUYCGTWRWKINDQHNQTGEMZEUL(player.userID)) ? String.Empty : String.Format(IQRank.FormatRank, OGDNBLPLELHGXIKLESNPZVUYCGTWRWKINDQHNQTGEMZEUL(player.userID));
                    Rank = String.IsNullOrWhiteSpace(ABFVUQNPHTARIKFNDAJRRXNAIDTXQXKETWBWVYLSK(player.userID)) ? String.Empty : String.Format(IQRank.FormatRank, ABFVUQNPHTARIKFNDAJRRXNAIDTXQXKETWBWVYLSK(player.userID));
                    if (!String.IsNullOrWhiteSpace(RankTime)) Result += $"{RankTime} ";
                    if (!String.IsNullOrWhiteSpace(Rank)) Result += $"{Rank} ";
                }
            }
            String XLevel = XLevel_GetLevel(player);
            if (!String.IsNullOrWhiteSpace(XLevel)) Result += $"{XLevel} ";
            String ClanTag = SUNOEXCIJHWFBRSLMVFIGDAKKACOJVHIPWRLJLZYY(player.userID);
            if (!String.IsNullOrWhiteSpace(ClanTag)) Result += $"{ClanTag} ";
            return Result;
        }
        private void UOSMCEYLXJTSZFSZVMVSYSKEZNWTESKIWFXHWZOY(BasePlayer player, Int32 Count)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_OpenDropListArgument_Taked");
            if (Interface == null) return;
            Interface = Interface.Replace("%COUNT%", Count.ToString());
            CuiHelper.DestroyUi(player, $"TAKED_INFO_{Count}");
            CuiHelper.AddUi(player, Interface);
        }
        internal class AntiNoob
        {
            public DateTime DateConnection = DateTime.UtcNow;
            public Boolean OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(Int32 KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI)
            {
                System.TimeSpan Time = DateTime.UtcNow.Subtract(DateConnection);
                return Time.TotalSeconds < KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI;
            }
            public Double EWEIMARKILVKEQRGSEHECRZMFNKKCXNUEEPLGUJWFRBQVX(Int32 KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI)
            {
                System.TimeSpan Time = DateTime.UtcNow.Subtract(DateConnection);
                return (KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI - Time.TotalSeconds);
            }
        }
        public Boolean OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(UInt64 userID, Int32 KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI)
        {
            if (UserInformationConnection.ContainsKey(userID)) return UserInformationConnection[userID].OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI);
            return false;
        }
        private void NFWQMXCOMXRCYQGHKYAFAAGZXULYKPIRHTWFGGAXBQCNPRL(IPlayer player)
        {
            if (player == null) return;
            Configuration.ControllerMessage ControllerMessage = config.ControllerMessages;
            String DisplayName = player.Name;
            Tuple<String, Boolean> GetTupleNick = TFPUIFCXSIEPJPLFKTAXQYWDDXNQXDZHLZTUMNOXSHEURV(DisplayName, ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.DVPFTYSPYFPBLMMBZGNKRWTYVTPYBOBSTTCHRCEM, ControllerMessage.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.AANXABDOOEXNGKHCRKZIUOKDWIRJFKXBBSRVGAURLJMJEFN);
            DisplayName = GetTupleNick.Item1;
            DisplayName = BVBCHAETAYXGRCIXCWUOWUBNKZRWOIEHPVQVRHBQBOIFKFLB(DisplayName);
            player.Rename(DisplayName);
        }
        void Unload()
        {
            InterfaceBuilder.OGCNXOIFTVOJBDZTCAYZVHCLNIHGHSZDNAUCINJZ();
            NWTGVJJDIWLCYHUWZYETYAPQHPKCOOEOCWIEUVEYBDME();
            _ = null;
        }
        private enum TakeElementUser
        {
            Prefix,
            Nick,
            Chat,
            Rank,
            MultiPrefix
        }
        public GeneralInformation GeneralInfo = new GeneralInformation();
        public Dictionary<BasePlayer, List<String>> LastMessagesChat = new Dictionary<BasePlayer, List<String>>();
        public List<String> YKRSUSTMYWSRMDDWOZVFTBBEXDDKYSKFJEAAYPXPAJ(BasePlayer player, Dictionary<String, List<String>> LanguageMessages)
        {
            String LangPlayer = _.lang.GetLanguage(player.UserIDString);
            if (LanguageMessages.ContainsKey(LangPlayer)) return LanguageMessages[LangPlayer];
            else if (LanguageMessages.ContainsKey("en")) return LanguageMessages["en"];
            else return LanguageMessages.FirstOrDefault().Value;
        }
        private
        const Boolean LanguageEn = false;
        private void JNILYMFZPWGMXIMUQOJOGMMHHDCYZCGEKVSQOSFXST(String ID, String Permissions)
        {
            UInt64 UserID = UInt64.Parse(ID);
            BasePlayer player = BasePlayer.FindByID(UserID);
            Configuration.ControllerConnection Controller = config.ControllerConnect;
            Configuration.ControllerParameters Parameters = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (!UserInformation.ContainsKey(UserID)) return;
            User Info = UserInformation[UserID];
            if (Controller.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.DNQWOULREBBRIIBYYICCWZINIJALPERJDIICOFWDHNAXLO)
            {
                if (Parameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB)
                {
                    Configuration.ControllerParameters.AdvancedFuncion GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Parameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.FirstOrDefault(prefix => Info.Info.PrefixList.Contains(prefix.Argument) && prefix.Permissions == Permissions);
                    if (GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP == null) return;
                    Info.Info.PrefixList.Remove(GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument);
                    if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("PREFIX_RETURNRED", player.UserIDString, GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument));
                    XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) expired prefix {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}" : $"У игрока ({UserID}) истек префикс {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}");
                }
                else
                {
                    Configuration.ControllerParameters.AdvancedFuncion GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Parameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.FirstOrDefault(prefix => prefix.Argument == Info.Info.Prefix && prefix.Permissions == Permissions);
                    if (GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP == null) return;
                    Info.Info.Prefix = Controller.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN;
                    if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("PREFIX_RETURNRED", player.UserIDString, GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument));
                    XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) expired prefix {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}" : $"У игрока ({UserID}) истек префикс {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}");
                }
            }
            if (Controller.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI)
            {
                Configuration.ControllerParameters.AdvancedFuncion ColorNick = Parameters.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ.FirstOrDefault(nick => Info.Info.ColorNick == nick.Argument && nick.Permissions == Permissions);
                if (ColorNick == null) return;
                Info.Info.ColorNick = Controller.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK;
                if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COLOR_NICK_RETURNRED", player.UserIDString, ColorNick.Argument));
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) expired nick color {ColorNick.Argument}" : $"У игрока ({UserID}) истек цвет ника {ColorNick.Argument}");
            }
            if (Controller.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK)
            {
                Configuration.ControllerParameters.AdvancedFuncion ColorChat = Parameters.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ.FirstOrDefault(message => Info.Info.ColorMessage == message.Argument && message.Permissions == Permissions);
                if (ColorChat == null) return;
                Info.Info.ColorMessage = Controller.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.MessageDefault;
                if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COLOR_CHAT_RETURNRED", player.UserIDString, ColorChat.Argument));
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) chat color expired {ColorChat.Argument}" : $"У игрока ({UserID}) истек цвет чата {ColorChat.Argument}");
            }
        }
        private void JDSCSLUGBRVAWBAEUKHAMQBCCQWGXILVMRDEOAKMEWENOVV(BasePlayer player, Chat.ChatChannel Channel, String TXSZXMVRLBSEFIJTUFYNAMQIAIOCVBAUMMMOBJEBXEJKVNEA)
        {
            List<Fields> fields = new List<Fields> {
                                new Fields(LanguageEn ? "Nick" : "Ник", player.displayName, true),
                                new Fields("Steam64ID", player.UserIDString, true),
                                new Fields(LanguageEn ? "Channel" : "Канал", Channel == Chat.ChatChannel.Global ? (LanguageEn ? "Global" : "Глобальный чат") : Channel == Chat.ChatChannel.Cards ? (LanguageEn ? "Poker" : "Покерный чат") : (LanguageEn ? "Team" : "Командный чат"), true),
                                new Fields(LanguageEn ? "Message" : "Сообщение", TXSZXMVRLBSEFIJTUFYNAMQIAIOCVBAUMMMOBJEBXEJKVNEA, false),
                        };
            FancyMessage newMessage = new FancyMessage(null, false, new FancyMessage.Embeds[1] {
                                new FancyMessage.Embeds(null, 10714449, fields, new Authors("Chat Chat-History", null, "https://api-methods.st8.ru/v2/chat/icon", null), null)
                        });
            switch (Channel)
            {
                case Chat.ChatChannel.Cards:
                case Chat.ChatChannel.Global:
                    {
                        Configuration.OtherSettings.General GlobalChat = config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsChat.GlobalChatSettings;
                        if (!GlobalChat.UseLogged) return;
                        UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC($"{GlobalChat.Webhooks}", newMessage.OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW());
                        break;
                    }
                case Chat.ChatChannel.Team:
                    {
                        Configuration.OtherSettings.General TeamChat = config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsChat.TeamChatSettings;
                        if (!TeamChat.UseLogged) return;
                        UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC($"{TeamChat.Webhooks}", newMessage.OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW());
                    }
                    break;
                default:
                    break;
            }
        }
        [ChatCommand("saybro")]
        private void NOLNLTITCQABOOISFZNEXWPTZUVQLONHUISJXYKTJJBXA(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] args)
        {
            if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            if (args == null || args.Length == 0)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "You didn't specify a player!" : "Вы не указали игрока!");
                return;
            }
            BasePlayer Recipient = BasePlayer.Find(args[0]);
            if (Recipient == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "The player is not on the server" : "Игрока нет на сервере!");
                return;
            }
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, Recipient, args.Skip(1).ToArray());
        }
        private void XPNMHPHRQRYRNQXRIODTHGWZVHPTUOVSTRXGCYGXZDR(BasePlayer player, String Command, String[] Args)
        {
            Configuration.OtherSettings.General Commands = config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsChatCommands;
            if (!Commands.UseLogged) return;
            List<Fields> fields = new List<Fields> {
                                new Fields(LanguageEn ? "Nick" : "Ник", player.displayName, true),
                                new Fields("Steam64ID", player.UserIDString, true),
                                new Fields(LanguageEn ? "Command" : "Команда", $"/{Command} ", true),
                        };
            String Arguments = String.Join(" ", Args);
            if (Args != null && Arguments != null && Arguments.Length != 0 && !String.IsNullOrWhiteSpace(Arguments)) fields.Insert(fields.Count, new Fields(LanguageEn ? "Arguments" : "Аргументы", Arguments, false));
            FancyMessage newMessage = new FancyMessage(null, false, new FancyMessage.Embeds[1] {
                                new FancyMessage.Embeds(null, 10710525, fields, new Authors("Chat Command-History", null, "https://api-methods.st8.ru/v2/chat/icon", null), null)
                        });
            UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC($"{Commands.Webhooks}", newMessage.OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW());
        }
        public void KFLTWSBNUGBQTORAZOWCWGYVTRPJHFTDPVOPVVXC(BasePlayer player) => IQPersonal?.CallHook("API_SET_MUTE", player.userID);
        public List<FakePlayer> PlayerBases = new List<FakePlayer>();
        public class Authors
        {
            public string name
            {
                get;
                set;
            }
            public string OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA
            {
                get;
                set;
            }
            public string icon_url
            {
                get;
                set;
            }
            public string proxy_icon_url
            {
                get;
                set;
            }
            public Authors(string name, string OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA, string icon_url, string proxy_icon_url)
            {
                this.name = name;
                this.OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA = OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA;
                this.icon_url = icon_url;
                this.proxy_icon_url = proxy_icon_url;
            }
        }
        [ChatCommand("hunmute")]
        void HYMQGNNHGYLHOEDHPAFCSGONXBXZBEDQTQOILFNEBBBH(BasePlayer Moderator, string cmd, string[] arg)
        {
            if (!permission.UserHasPermission(Moderator.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Length != 1 || arg.Length > 1)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Invalid syntax, please use : hunmute Steam64ID/Nick" : "Неверный синтаксис,используйте : hunmute Steam64ID/Ник");
                return;
            }
            string NameOrID = arg[0];
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (!Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "The player does not have a chat lock" : "У игрока нет блокировки чата");
                            return;
                        }
                        Info.MuteInfo.UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(MuteType.Chat);
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "You have unblocked the offline chat to the player" : "Вы разблокировали чат offline игроку");
                        return;
                    }
                    else
                    {
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(target, MuteType.Chat, Moderator, true, true);
        }
        private class Configuration
        {
            [JsonProperty(LanguageEn ? "Setting up player information" : "Настройка информации о игроке")] public ControllerConnection ControllerConnect = new ControllerConnection();
            internal class ControllerConnection
            {
                [JsonProperty(LanguageEn ? "Function switches" : "Перключатели функций")] public Turned JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN = new Turned();
                [JsonProperty(LanguageEn ? "Setting Standard Values" : "Настройка стандартных значений")] public SetupDefault WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW = new SetupDefault();
                internal class SetupDefault
                {
                    [JsonProperty(LanguageEn ? "This prefix will be set if the player entered the server for the first time or in case of expiration of the rights to the prefix that he had earlier" : "Данный префикс установится если игрок впервые зашел на сервер или в случае окончания прав на префикс, который у него стоял ранее")] public String UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN = "<color=#CC99FF>[ИГРОК]</color>";
                    [JsonProperty(LanguageEn ? "This nickname color will be set if the player entered the server for the first time or in case of expiration of the rights to the nickname color that he had earlier" : "Данный цвет ника установится если игрок впервые зашел на сервер или в случае окончания прав на цвет ника, который у него стоял ранее")] public String NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK = "#33CCCC";
                    [JsonProperty(LanguageEn ? "This chat color will be set if the player entered the server for the first time or in case of expiration of the rights to the chat color that he had earlier" : "Данный цвет чата установится если игрок впервые зашел на сервер или в случае окончания прав на цвет чата, который у него стоял ранее")] public String MessageDefault = "#0099FF";
                }
                internal class Turned
                {
                    [JsonProperty(LanguageEn ? "Set automatically a prefix to a player when he got the rights to it" : "Устанавливать автоматически префикс игроку, когда он получил права на него")] public Boolean PGVXJYGKGXGAPYUBPIGKKNOUZRUMUMLLMCBJYQALYYOD;
                    [JsonProperty(LanguageEn ? "Set automatically the color of the nickname to the player when he got the rights to it" : "Устанавливать автоматически цвет ника игроку, когда он получил права на него")] public Boolean PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI;
                    [JsonProperty(LanguageEn ? "Set the chat color automatically to the player when he got the rights to it" : "Устанавливать автоматически цвет чата игроку, когда он получил права на него")] public Boolean FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK;
                    [JsonProperty(LanguageEn ? "Automatically reset the prefix when the player's rights to it expire" : "Сбрасывать автоматически префикс при окончании прав на него у игрока")] public Boolean DNQWOULREBBRIIBYYICCWZINIJALPERJDIICOFWDHNAXLO;
                    [JsonProperty(LanguageEn ? "Automatically reset the color of the nickname when the player's rights to it expire" : "Сбрасывать автоматически цвет ника при окончании прав на него у игрока")] public Boolean UTRKHVIUEFDOETABAKROZAYKTMYUJYKBUOGSYUJOUODXLRRJ;
                    [JsonProperty(LanguageEn ? "Automatically reset the color of the chat when the rights to it from the player expire" : "Сбрасывать автоматически цвет чата при окончании прав на него у игрока")] public Boolean LANTZVTUHQVWNLGUBTQNHDGACTLWAYCUPMXXXHVTMX;
                }
            }
            [JsonProperty(LanguageEn ? "Setting options for the player" : "Настройка параметров для игрока")] public ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = new ControllerParameters();
            internal class ControllerParameters
            {
                [JsonProperty(LanguageEn ? "Setting the display of options for player selection" : "Настройка отображения параметров для выбора игрока")] public VisualSettingParametres DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM = new VisualSettingParametres();
                [JsonProperty(LanguageEn ? "List and customization of colors for a nickname" : "Список и настройка цветов для ника")] public List<AdvancedFuncion> DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ = new List<AdvancedFuncion>();
                [JsonProperty(LanguageEn ? "List and customize colors for chat messages" : "Список и настройка цветов для сообщений в чате")] public List<AdvancedFuncion> RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ = new List<AdvancedFuncion>();
                [JsonProperty(LanguageEn ? "List and configuration of prefixes in chat" : "Список и настройка префиксов в чате")] public PrefixSetting GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new PrefixSetting();
                internal class PrefixSetting
                {
                    [JsonProperty(LanguageEn ? "Enable support for multiple prefixes at once (true - multiple prefixes can be set/false - only 1 can be set to choose from)" : "Включить поддержку нескольких префиксов сразу (true - можно установить несколько префиксов/false - установить можно только 1 на выбор)")] public Boolean UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB;
                    [JsonProperty(LanguageEn ? "The maximum number of prefixes that can be set at a time (This option only works if setting multiple prefixes is enabled)" : "Максимальное количество префиксов, которое можно установить за раз(Данный параметр работает только если включена установка нескольких префиксов)")] public Int32 LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC;
                    [JsonProperty(LanguageEn ? "List of prefixes and their settings" : "Список префиксов и их настройка")] public List<AdvancedFuncion> GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new List<AdvancedFuncion>();
                }
                internal class AdvancedFuncion
                {
                    [JsonProperty(LanguageEn ? "Permission" : "Права")] public String Permissions;
                    [JsonProperty(LanguageEn ? "Argument" : "Значение")] public String Argument;
                }
                internal class VisualSettingParametres
                {
                    [JsonProperty(LanguageEn ? "Player prefix selection display type - (0 - dropdown list, 1 - slider (Please note that if you have multi-prefix enabled, the dropdown list will be set))" : "Тип отображения выбора префикса для игрока - (0 - выпадающий список, 1 - слайдер (Учтите, что если у вас включен мульти-префикс, будет установлен выпадающий список))")] public SelectedParametres NGSKGILLMUCIMZNQAEBTPLUEIFMEGOIKZPLBNSSCL;
                    [JsonProperty(LanguageEn ? "Display type of player's nickname color selection - (0 - drop-down list, 1 - slider)" : "Тип отображения выбора цвета ника для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres ZSMICAHWXCZJPBLOCBWHFYLSIXNLDILYICLBSZCMXKQGK;
                    [JsonProperty(LanguageEn ? "Display type of message color choice for the player - (0 - drop-down list, 1 - slider)" : "Тип отображения выбора цвета сообщения для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres ZJPYPRGEHAHTZFMVSOQABMQKWCYJJVIFHTXDVFSUSDUKUY;
                    [JsonProperty(LanguageEn ? "IQRankSystem : Player rank selection display type - (0 - drop-down list, 1 - slider)" : "IQRankSystem : Тип отображения выбора ранга для игрока - (0 - выпадающий список, 1 - слайдер)")] public SelectedParametres XABRBPJONTFCNTXVMSBLGIIANWWIXSGPXCAJHDGP;
                }
            }
            [JsonProperty(LanguageEn ? "Plugin mute settings" : "Настройка мута в плагине")] public ControllerMute LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = new ControllerMute();
            internal class ControllerMute
            {
                [JsonProperty(LanguageEn ? "Setting up automatic muting" : "Настройка автоматического мута")] public AutoMute EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL = new AutoMute();
                internal class AutoMute
                {
                    [JsonProperty(LanguageEn ? "Enable automatic muting for forbidden words (true - yes/false - no)" : "Включить автоматический мут по запрещенным словам(true - да/false - нет)")] public Boolean GYAVWNPXZXUIGUYFFZRRURTOYNBJYTUAGXHKLRROIZKNWM;
                    [JsonProperty(LanguageEn ? "Reason for automatic muting" : "Причина автоматического мута")] public Muted UMIRLSUWOFMXILFZGDUCJNNTOHCIUGGSLGGXPCIIMA;
                }
                [JsonProperty(LanguageEn ? "Additional setting for logging about mutes in discord" : "Дополнительная настройка для логирования о мутах в дискорд")] public LoggedFuncion FZTIDDAEJCKXHYPCDQLBIYULCEIJEULPIUIUVZYFUCWQBIZ = new LoggedFuncion();
                internal class LoggedFuncion
                {
                    [JsonProperty(LanguageEn ? "Support for logging the last N messages (Discord logging about mutes must be enabled)" : "Поддержка логирования последних N сообщений (Должно быть включено логирование в дискорд о мутах)")] public Boolean AZFSAYKGFIGYURZPQUPMQVHERGHGBDKTFJIEPSPKKBONTAKCC;
                    [JsonProperty(LanguageEn ? "How many latest player messages to send in logging" : "Сколько последних сообщений игрока отправлять в логировании")] public Int32 ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO;
                }
                [JsonProperty(LanguageEn ? "Reasons to block chat" : "Причины для блокировки чата")] public List<Muted> VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL = new List<Muted>();
                [JsonProperty(LanguageEn ? "Reasons to block your voice" : "Причины для блокировки голоса")] public List<Muted> BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL = new List<Muted>();
                internal class Muted
                {
                    [JsonProperty(LanguageEn ? "Reason for blocking" : "Причина для блокировки")] public String Reason;
                    [JsonProperty(LanguageEn ? "Block time (in seconds)" : "Время блокировки(в секундах)")] public Int32 MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT;
                }
            }
            [JsonProperty(LanguageEn ? "Configuring Message Processing" : "Настройка обработки сообщений")] public ControllerMessage ControllerMessages = new ControllerMessage();
            internal class ControllerMessage
            {
                [JsonProperty(LanguageEn ? "Basic settings for chat messages from the plugin" : "Основная настройка сообщений в чат от плагина")] public GeneralSettings YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV = new GeneralSettings();
                [JsonProperty(LanguageEn ? "Configuring functionality switching in chat" : "Настройка переключения функционала в чате")] public TurnedFuncional NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY = new TurnedFuncional();
                [JsonProperty(LanguageEn ? "Player message formatting settings" : "Настройка форматирования сообщений игроков")] public FormattingMessage HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ = new FormattingMessage();
                internal class GeneralSettings
                {
                    [JsonProperty(LanguageEn ? "Customizing the chat alert format" : "Настройка формата оповещения в чате")] public BroadcastSettings BroadcastFormat = new BroadcastSettings();
                    [JsonProperty(LanguageEn ? "Setting the mention format in the chat, via @" : "Настройка формата упоминания в чате, через @")] public AlertSettings PLOMZYCAZCHTFUCOKPXEIQGWVXQFAOOTGXSGZSDOMLILN = new AlertSettings();
                    [JsonProperty(LanguageEn ? "Additional setting" : "Дополнительная настройка")] public OtherSettings NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB = new OtherSettings();
                    internal class BroadcastSettings
                    {
                        [JsonProperty(LanguageEn ? "The name of the notification in the chat" : "Наименование оповещения в чат")] public String BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG;
                        [JsonProperty(LanguageEn ? "Chat alert message color" : "Цвет сообщения оповещения в чат")] public String LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH;
                        [JsonProperty(LanguageEn ? "Steam64ID for chat avatar" : "Steam64ID для аватарки в чате")] public String DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ;
                    }
                    internal class AlertSettings
                    {
                        [JsonProperty(LanguageEn ? "The color of the player mention message in the chat" : "Цвет сообщения упоминания игрока в чате")] public String WVVQCIPDROVHWIIBDQRMRHCJHBRVSLQHPKCTDKTUSTCQLRRH;
                        [JsonProperty(LanguageEn ? "Sound when receiving and sending a mention via @" : "Звук при при получении и отправки упоминания через @")] public String PFYMWEPTMJARTLGYNSMFPYSWWUYELXPJKECGSVSGNARBTC;
                    }
                    internal class OtherSettings
                    {
                        [JsonProperty(LanguageEn ? "Time after which the message will be deleted from the UI from the administrator" : "Время,через которое удалится сообщение с UI от администратора")] public Int32 IWSYZFBBRMBPBFKHPTQGOIZGSZFRPGRDTVQITYPEIDLUQFRAD;
                        [JsonProperty(LanguageEn ? "The size of the message from the player in the chat" : "Размер сообщения от игрока в чате")] public Int32 SizeMessage = 14;
                        [JsonProperty(LanguageEn ? "Player nickname size in chat" : "Размер ника игрока в чате")] public Int32 SizeNick = 14;
                        [JsonProperty(LanguageEn ? "The size of the player's prefix in the chat (will be used if <size=N></size> is not set in the prefix itself)" : "Размер префикса игрока в чате (будет использовано, если в самом префиксе не установвлен <size=N></size>)")] public Int32 SizePrefix = 14;
                    }
                }
                internal class TurnedFuncional
                {
                    [JsonProperty(LanguageEn ? "Configuring spam protection" : "Настройка защиты от спама")] public AntiSpam RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM = new AntiSpam();
                    [JsonProperty(LanguageEn ? "Setting up a temporary chat block for newbies (who have just logged into the server)" : "Настройка временной блокировки чата новичкам (которые только зашли на сервер)")] public AntiNoob PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU = new AntiNoob();
                    [JsonProperty(LanguageEn ? "Setting up private messages" : "Настройка личных сообщений")] public PM XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ = new PM();
                    internal class AntiNoob
                    {
                        [JsonProperty(LanguageEn ? "Newbie protection in PM/R" : "Защита от новичка в PM/R")] public Settings GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS = new Settings();
                        [JsonProperty(LanguageEn ? "Newbie protection in global and team chat" : "Защита от новичка в глобальном и коммандном чате")] public Settings OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY = new Settings();
                        internal class Settings
                        {
                            [JsonProperty(LanguageEn ? "Enable protection?" : "Включить защиту?")] public Boolean BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP = false;
                            [JsonProperty(LanguageEn ? "Newbie Chat Lock Time" : "Время блокировки чата для новичка")] public Int32 KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI = 1200;
                        }
                    }
                    internal class AntiSpam
                    {
                        [JsonProperty(LanguageEn ? "Enable spam protection (Anti-spam)" : "Включить защиту от спама (Анти-спам)")] public Boolean NPIQMTLXTMSNVSLJMKXEUZDKNLVDZBIYJCVJZHVTRPLH;
                        [JsonProperty(LanguageEn ? "Time after which a player can send a message (AntiSpam)" : "Время через которое игрок может отправлять сообщение (АнтиСпам)")] public Int32 HDRNMJFAERNMYDAXIYSETDSXCKFOEMFOWHFIEPMRC;
                        [JsonProperty(LanguageEn ? "Additional Anti-Spam settings" : "Дополнительная настройка Анти-Спама")] public AntiSpamDuples FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX = new AntiSpamDuples();
                        internal class AntiSpamDuples
                        {
                            [JsonProperty(LanguageEn ? "Enable additional spam protection (Anti-duplicates, duplicate messages)" : "Включить дополнительную защиту от спама (Анти-дубликаты, повторяющие сообщения)")] public Boolean EKNLBNZJGKGCCRFSBNEEFFSCXNOYCXSVUKNAMQTLHFZ = true;
                            [JsonProperty(LanguageEn ? "How many duplicate messages does a player need to make to be confused by the system" : "Сколько дублирующих сообщений нужно сделать игроку чтобы его замутила система")] public Int32 VQGLICRKXTEZSKNNZAHISKHRDEGLUTXZGSHGHCPZGHXBFOICC = 3;
                            [JsonProperty(LanguageEn ? "Setting up automatic muting for duplicates" : "Настройка автоматического мута за дубликаты")]
                            public ControllerMute.Muted MGYQHKJOIDWFQEWESADGGWLHCKNGMOWEIOHQAQKWXT = new ControllerMute.Muted
                            {
                                Reason = LanguageEn ? "Blocking for duplicate messages (SPAM)" : "Блокировка за дублирующие сообщения (СПАМ)",
                                MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                            };
                        }
                    }
                    internal class PM
                    {
                        [JsonProperty(LanguageEn ? "Enable Private Messages" : "Включить личные сообщения")] public Boolean LCAQTFAVHYWZPVROWXDBTHSXBWFECQHIMCZEBUTALSPFMPS;
                        [JsonProperty(LanguageEn ? "Sound when receiving a private message" : "Звук при при получении личного сообщения")] public String JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO;
                    }
                    [JsonProperty(LanguageEn ? "Enable PM ignore for players (/ignore nick or via interface)" : "Включить игнор ЛС игрокам(/ignore nick или через интерфейс)")] public Boolean YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW;
                    [JsonProperty(LanguageEn ? "Hide the issue of items to the Admin from the chat" : "Скрыть из чата выдачу предметов Админу")] public Boolean BDKMGKGZLVXEBMLQZYSZGUUEEIVSCYHTWIWERPVJRM;
                    [JsonProperty(LanguageEn ? "Move mute to team chat (In case of a mute, the player will not be able to write even to the team chat)" : "Переносить мут в командный чат(В случае мута, игрок не сможет писать даже в командный чат)")] public Boolean CNTIFDGUDPXZGIFHXOOWMODHTPHYJDJHUXSRLAQPWDDEZIQWL;
                }
                internal class FormattingMessage
                {
                    [JsonProperty(LanguageEn ? "Enable message formatting [Will control caps, message format] (true - yes/false - no)" : "Включить форматирование сообщений [Будет контроллировать капс, формат сообщения] (true - да/false - нет)")] public Boolean XVDPKOKLPQWHLAGPFJQOWXYZAJKYIKZKMBFNEEMDHZK;
                    [JsonProperty(LanguageEn ? "Use a list of banned words (true - yes/false - no)" : "Использовать список запрещенных слов (true - да/false - нет)")] public Boolean SPSDYJDGFXLAXEPBDLDFQLVJUSKAXMHXMYGKQHAYGSFOQEQAP;
                    [JsonProperty(LanguageEn ? "The word that will replace the forbidden word" : "Слово которое будет заменять запрещенное слово")] public String ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU;
                    [JsonProperty(LanguageEn ? "List of banned words" : "Список запрещенных слов")] public List<String> GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT = new List<String>();
                    [JsonProperty(LanguageEn ? "Nickname controller setup" : "Настройка контроллера ников")] public NickController CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC = new NickController();
                    internal class NickController
                    {
                        [JsonProperty(LanguageEn ? "Enable player nickname formatting (message formatting must be enabled)" : "Включить форматирование ников игроков (должно быть включено форматирование сообщений)")] public Boolean DRHQLJMHSPIGEXWGVNKXGFYSSFUKWGDGHYKLPZTMCMPAQEDBQ = true;
                        [JsonProperty(LanguageEn ? "The word that will replace the forbidden word (You can leave it blank and it will just delete)" : "Слово которое будет заменять запрещенное слово (Вы можете оставить пустым и будет просто удалять)")] public String DVPFTYSPYFPBLMMBZGNKRWTYVTPYBOBSTTCHRCEM = "****";
                        [JsonProperty(LanguageEn ? "List of banned nicknames" : "Список запрещенных ников")] public List<String> AANXABDOOEXNGKHCRKZIUOKDWIRJFKXBBSRVGAURLJMJEFN = new List<String>();
                        [JsonProperty(LanguageEn ? "List of allowed links in nicknames" : "Список разрешенных ссылок в никах")] public List<String> AllowedLinkNick = new List<String>();
                    }
                }
            }
            [JsonProperty(LanguageEn ? "Setting up chat alerts" : "Настройка оповещений в чате")] public ControllerAlert ControllerAlertSetting;
            internal class ControllerAlert
            {
                [JsonProperty(LanguageEn ? "Setting up chat alerts" : "Настройка оповещений в чате")] public Alert AlertSetting;
                [JsonProperty(LanguageEn ? "Setting notifications about the status of the player's session" : "Настройка оповещений о статусе сессии игрока")] public PlayerSession PlayerSessionSetting;
                [JsonProperty(LanguageEn ? "Configuring administrator session status alerts" : "Настройка оповещений о статусе сессии администратора")] public AdminSession AdminSessionSetting;
                [JsonProperty(LanguageEn ? "Setting up personal notifications to the player when connecting" : "Настройка персональных оповоещений игроку при коннекте")] public PersonalAlert PersonalAlertSetting;
                internal class Alert
                {
                    [JsonProperty(LanguageEn ? "Enable automatic messages in chat (true - yes/false - no)" : "Включить автоматические сообщения в чат (true - да/false - нет)")] public Boolean AlertMessage;
                    [JsonProperty(LanguageEn ? "Type of automatic messages : true - sequential / false - random" : "Тип автоматических сообщений : true - поочередные/false - случайные")] public Boolean AlertMessageType;
                    [JsonProperty(LanguageEn ? "List of automatic messages in chat" : "Список автоматических сообщений в чат")] public LanguageController MessageList = new LanguageController();
                    [JsonProperty(LanguageEn ? "Interval for sending messages to chat (Broadcaster) (in seconds)" : "Интервал отправки сообщений в чат (Броадкастер) (в секундах)")] public Int32 MessageListTimer;
                }
                internal class PlayerSession
                {
                    [JsonProperty(LanguageEn ? "When a player is notified about the entry / exit of the player, display his avatar opposite the nickname (true - yes / false - no)" : "При уведомлении о входе/выходе игрока отображать его аватар напротив ника (true - да/false - нет)")] public Boolean ConnectedAvatarUse;
                    [JsonProperty(LanguageEn ? "Notify in chat when a player enters (true - yes/false - no)" : "Уведомлять в чате о входе игрока (true - да/false - нет)")] public Boolean ConnectedAlert;
                    [JsonProperty(LanguageEn ? "Enable random notifications when a player from the list enters (true - yes / false - no)" : "Включить случайные уведомления о входе игрока из списка (true - да/false - нет)")] public Boolean ConnectionAlertRandom;
                    [JsonProperty(LanguageEn ? "Show the country of the entered player (true - yes/false - no)" : "Отображать страну зашедшего игрока (true - да/false - нет")] public Boolean ConnectedWorld;
                    [JsonProperty(LanguageEn ? "Notify when a player enters the chat (selected from the list) (true - yes/false - no)" : "Уведомлять о выходе игрока в чат(выбираются из списка) (true - да/false - нет)")] public Boolean DisconnectedAlert;
                    [JsonProperty(LanguageEn ? "Enable random player exit notifications (true - yes/false - no)" : "Включить случайные уведомления о выходе игрока (true - да/false - нет)")] public Boolean DisconnectedAlertRandom;
                    [JsonProperty(LanguageEn ? "Display reason for player exit (true - yes/false - no)" : "Отображать причину выхода игрока (true - да/false - нет)")] public Boolean DisconnectedReason;
                    [JsonProperty(LanguageEn ? "Random player entry notifications({0} - player's nickname, {1} - country (if country display is enabled)" : "Случайные уведомления о входе игрока({0} - ник игрока, {1} - страна(если включено отображение страны)")] public LanguageController RandomConnectionAlert = new LanguageController();
                    [JsonProperty(LanguageEn ? "Random notifications about the exit of the player ({0} - player's nickname, {1} - the reason for the exit (if the reason is enabled)" : "Случайные уведомления о выходе игрока({0} - ник игрока, {1} - причина выхода(если включена причина)")] public LanguageController RandomDisconnectedAlert = new LanguageController();
                }
                internal class AdminSession
                {
                    [JsonProperty(LanguageEn ? "Notify admin on the server in the chat (true - yes/false - no)" : "Уведомлять о входе админа на сервер в чат (true - да/false - нет)")] public Boolean ConnectedAlertAdmin;
                    [JsonProperty(LanguageEn ? "Notify about admin leaving the server in chat (true - yes/false - no)" : "Уведомлять о выходе админа на сервер в чат (true - да/false - нет)")] public Boolean DisconnectedAlertAdmin;
                }
                internal class PersonalAlert
                {
                    [JsonProperty(LanguageEn ? "Enable random message to the player who has logged in (true - yes/false - no)" : "Включить случайное сообщение зашедшему игроку (true - да/false - нет)")] public Boolean UseWelcomeMessage;
                    [JsonProperty(LanguageEn ? "List of messages to the player when entering" : "Список сообщений игроку при входе")] public LanguageController WelcomeMessage = new LanguageController();
                }
            }
            public class LanguageController
            {
                [JsonProperty(LanguageEn ? "Setting up Multilingual Messages [Language Code] = Translation Variations" : "Настройка мультиязычных сообщений [КодЯзыка] = ВариацииПеревода")] public Dictionary<String, List<String>> LanguageMessages = new Dictionary<String, List<String>>();
            }
            [JsonProperty(LanguageEn ? "Settings Rust+" : "Настройка Rust+")] public RustPlus RustPlusSettings;
            internal class RustPlus
            {
                [JsonProperty(LanguageEn ? "Use Rust+" : "Использовать Rust+")] public Boolean UseRustPlus;
                [JsonProperty(LanguageEn ? "Title for notification Rust+" : "Название для уведомления Rust+")] public String DisplayNameAlert;
            }
            [JsonProperty(LanguageEn ? "Configuring support plugins" : "Настройка плагинов поддержки")] public ReferenceSettings ReferenceSetting = new ReferenceSettings();
            internal class ReferenceSettings
            {
                [JsonProperty(LanguageEn ? "Settings XLevels" : "Настройка XLevels")] public XLevels XLevelsSettings = new XLevels();
                [JsonProperty(LanguageEn ? "Settings IQFakeActive" : "Настройка IQFakeActive")] public IQFakeActive IQFakeActiveSettings = new IQFakeActive();
                [JsonProperty(LanguageEn ? "Settings IQRankSystem" : "Настройка IQRankSystem")] public IQRankSystem IQRankSystems = new IQRankSystem();
                internal class IQRankSystem
                {
                    [JsonProperty(LanguageEn ? "Rank display format in chat ( {0} is the user's rank, do not delete this value)" : "Формат отображения ранга в чате ( {0} - это ранг юзера, не удаляйте это значение)")] public String FormatRank = "[{0}]";
                    [JsonProperty(LanguageEn ? "Time display format with IQRank System in chat ( {0} is the user's time, do not delete this value)" : "Формат отображения времени с IQRankSystem в чате ( {0} - это время юзера, не удаляйте это значение)")] public String FormatRankTime = "[{0}]";
                    [JsonProperty(LanguageEn ? "Use support IQRankSystem" : "Использовать поддержку рангов")] public Boolean UseRankSystem;
                    [JsonProperty(LanguageEn ? "Show players their played time next to their rank" : "Отображать игрокам их отыгранное время рядом с рангом")] public Boolean UseTimeStandart;
                }
                internal class IQFakeActive
                {
                    [JsonProperty(LanguageEn ? "Use support IQFakeActive" : "Использовать поддержку IQFakeActive")] public Boolean UseIQFakeActive;
                }
                internal class XLevels
                {
                    [JsonProperty(LanguageEn ? "Use support XLevels" : "Использовать поддержку XLevels")] public Boolean UseXLevels;
                }
            }
            [JsonProperty(LanguageEn ? "Setting up an answering machine" : "Настройка автоответчика")] public AnswerMessage AnswerMessages = new AnswerMessage();
            internal class AnswerMessage
            {
                [JsonProperty(LanguageEn ? "Enable auto-reply? (true - yes/false - no)" : "Включить автоответчик?(true - да/false - нет)")] public bool UseAnswer;
                [JsonProperty(LanguageEn ? "Customize Messages [Keyword] = Reply" : "Настройка сообщений [Ключевое слово] = Ответ")] public Dictionary<String, LanguageController> AnswerMessageList = new Dictionary<String, LanguageController>();
            }
            [JsonProperty(LanguageEn ? "Additional setting" : "Дополнительная настройка")] public OtherSettings NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB;
            internal class OtherSettings
            {
                [JsonProperty(LanguageEn ? "Setting up message logging" : "Настройка логирования сообщений")] public LoggedChat LogsChat = new LoggedChat();
                [JsonProperty(LanguageEn ? "Setting up logging of personal messages of players" : "Настройка логирования личных сообщений игроков")] public General LogsPMChat = new General();
                [JsonProperty(LanguageEn ? "Setting up chat/voice lock/unlock logging" : "Настройка логирования блокировок/разблокировок чата/голоса")] public General LogsMuted = new General();
                [JsonProperty(LanguageEn ? "Setting up logging of chat commands from players" : "Настройка логирования чат-команд от игроков")] public General LogsChatCommands = new General();
                internal class LoggedChat
                {
                    [JsonProperty(LanguageEn ? "Setting up general chat logging" : "Настройка логирования общего чата")] public General GlobalChatSettings = new General();
                    [JsonProperty(LanguageEn ? "Setting up team chat logging" : "Настройка логирования тим чата")] public General TeamChatSettings = new General();
                }
                internal class General
                {
                    [JsonProperty(LanguageEn ? "Enable logging (true - yes/false - no)" : "Включить логирование (true - да/false - нет)")] public Boolean UseLogged = false;
                    [JsonProperty(LanguageEn ? "Webhooks channel for logging" : "Webhooks канала для логирования")] public String Webhooks = "";
                }
            }
            public static Configuration GetNewConfiguration()
            {
                return new Configuration
                {
                    NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = new ControllerParameters
                    {
                        DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM = new ControllerParameters.VisualSettingParametres
                        {
                            NGSKGILLMUCIMZNQAEBTPLUEIFMEGOIKZPLBNSSCL = SelectedParametres.DropList,
                            ZJPYPRGEHAHTZFMVSOQABMQKWCYJJVIFHTXDVFSUSDUKUY = SelectedParametres.DropList,
                            ZSMICAHWXCZJPBLOCBWHFYLSIXNLDILYICLBSZCMXKQGK = SelectedParametres.Slider,
                            XABRBPJONTFCNTXVMSBLGIIANWWIXSGPXCAJHDGP = SelectedParametres.Slider,
                        },
                        GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new ControllerParameters.PrefixSetting
                        {
                            UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB = false,
                            LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC = 5,
                            GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = new List<ControllerParameters.AdvancedFuncion> {
                                                                new ControllerParameters.AdvancedFuncion {
                                                                        Argument = LanguageEn ? "<color=#CC99FF>[PLAYER]</color>" : "<color=#CC99FF>[ИГРОК]</color>", Permissions = "iqchat.default",
                                                                },
                                                                new ControllerParameters.AdvancedFuncion {
                                                                        Argument = "<color=#ffff99>[VIP]</color>", Permissions = "iqchat.admin",
                                                                },
                                                                new ControllerParameters.AdvancedFuncion {
                                                                        Argument = LanguageEn ? "<color=#ff9999>[ADMIN]</color>" : "<color=#ff9999>[АДМИН]</color>", Permissions = "iqchat.admin",
                                                                },
                                                        },
                        },
                        RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ = new List<ControllerParameters.AdvancedFuncion> {
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#CC99FF", Permissions = "iqchat.default",
                                                        },
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#ffff99", Permissions = "iqchat.admin",
                                                        },
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#ff9999", Permissions = "iqchat.admin",
                                                        },
                                                },
                        DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ = new List<ControllerParameters.AdvancedFuncion> {
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#CC99FF", Permissions = "iqchat.default",
                                                        },
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#ffff99", Permissions = "iqchat.admin",
                                                        },
                                                        new ControllerParameters.AdvancedFuncion {
                                                                Argument = "#ff9999", Permissions = "iqchat.admin",
                                                        },
                                                },
                    },
                    ControllerConnect = new ControllerConnection
                    {
                        WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW = new ControllerConnection.SetupDefault
                        {
                            UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN = LanguageEn ? "<color=#CC99FF>[PLAYER]</color>" : "<color=#CC99FF>[ИГРОК]</color>",
                            MessageDefault = "#33CCCC",
                            NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK = "#0099FF",
                        },
                        JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN = new ControllerConnection.Turned
                        {
                            LANTZVTUHQVWNLGUBTQNHDGACTLWAYCUPMXXXHVTMX = true,
                            UTRKHVIUEFDOETABAKROZAYKTMYUJYKBUOGSYUJOUODXLRRJ = true,
                            DNQWOULREBBRIIBYYICCWZINIJALPERJDIICOFWDHNAXLO = true,
                            FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK = true,
                            PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI = true,
                            PGVXJYGKGXGAPYUBPIGKKNOUZRUMUMLLMCBJYQALYYOD = true,
                        }
                    },
                    LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = new ControllerMute
                    {
                        FZTIDDAEJCKXHYPCDQLBIYULCEIJEULPIUIUVZYFUCWQBIZ = new ControllerMute.LoggedFuncion
                        {
                            AZFSAYKGFIGYURZPQUPMQVHERGHGBDKTFJIEPSPKKBONTAKCC = false,
                            ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO = 10,
                        },
                        EKKPCFBUIHRSMTPRBEFTBRUNQEKSONJMMNCYXKKRVNPKOXKJL = new ControllerMute.AutoMute
                        {
                            GYAVWNPXZXUIGUYFFZRRURTOYNBJYTUAGXHKLRROIZKNWM = true,
                            UMIRLSUWOFMXILFZGDUCJNNTOHCIUGGSLGGXPCIIMA = new ControllerMute.Muted
                            {
                                Reason = LanguageEn ? "Automatic chat blocking" : "Автоматическая блокировка чата",
                                MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                            }
                        },
                        VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL = new List<ControllerMute.Muted> {
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Aggressive behavior" : "Агрессивное поведение", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 100,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Insults" : "Оскорбления", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Insult (repeated violation)" : "Оскорбление (повторное нарушение)", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 1000,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Advertising" : "Реклама", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 5000,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Humiliation" : "Унижение", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Spam" : "Спам", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 60,
                                                        },
                                                },
                        BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL = new List<ControllerMute.Muted> {
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Aggressive behavior" : "Агрессивное поведение", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 100,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Insults" : "Оскорбления", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                                                        },
                                                        new ControllerMute.Muted {
                                                                Reason = LanguageEn ? "Disruption of the event by shouting" : "Срыв мероприятия криками", MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                                                        },
                                                }
                    },
                    ControllerMessages = new ControllerMessage
                    {
                        HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ = new ControllerMessage.FormattingMessage
                        {
                            SPSDYJDGFXLAXEPBDLDFQLVJUSKAXMHXMYGKQHAYGSFOQEQAP = true,
                            GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT = LanguageEn ? new List<String> {
                                                                "fuckyou",
                                                                "sucking",
                                                                "fucking",
                                                                "fuck"
                                                        } : new List<String> {
                                                                "бля",
                                                                "сука",
                                                                "говно",
                                                                "тварь"
                                                        },
                            XVDPKOKLPQWHLAGPFJQOWXYZAJKYIKZKMBFNEEMDHZK = true,
                            ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU = "***",
                            CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC = new ControllerMessage.FormattingMessage.NickController
                            {
                                AANXABDOOEXNGKHCRKZIUOKDWIRJFKXBBSRVGAURLJMJEFN = LanguageEn ? new List<String> {
                                                                        "Admin",
                                                                        "Moderator",
                                                                        "Administrator",
                                                                        "Moder",
                                                                        "Owner"
                                                                } : new List<String> {
                                                                        "Администратор",
                                                                        "Модератор",
                                                                        "Админ",
                                                                        "Модер",
                                                                        "Овнер"
                                                                },
                                AllowedLinkNick = new List<String> {
                                                                        "mysite.com"
                                                                },
                                DVPFTYSPYFPBLMMBZGNKRWTYVTPYBOBSTTCHRCEM = "",
                                DRHQLJMHSPIGEXWGVNKXGFYSSFUKWGDGHYKLPZTMCMPAQEDBQ = true,
                            },
                        },
                        NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY = new ControllerMessage.TurnedFuncional
                        {
                            BDKMGKGZLVXEBMLQZYSZGUUEEIVSCYHTWIWERPVJRM = true,
                            YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW = true,
                            CNTIFDGUDPXZGIFHXOOWMODHTPHYJDJHUXSRLAQPWDDEZIQWL = true,
                            PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU = new ControllerMessage.TurnedFuncional.AntiNoob
                            {
                                OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY = new ControllerMessage.TurnedFuncional.AntiNoob.Settings
                                {
                                    BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP = false,
                                    KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI = 1200,
                                },
                                GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS = new ControllerMessage.TurnedFuncional.AntiNoob.Settings
                                {
                                    BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP = false,
                                    KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI = 1200,
                                },
                            },
                            RZQGICVDTCCHEKJICKTEILKOIZPBRWKZLJSBAORGBJJJVAHLM = new ControllerMessage.TurnedFuncional.AntiSpam
                            {
                                NPIQMTLXTMSNVSLJMKXEUZDKNLVDZBIYJCVJZHVTRPLH = true,
                                HDRNMJFAERNMYDAXIYSETDSXCKFOEMFOWHFIEPMRC = 10,
                                FLIWADUVJRTDJDKULBERWRMYQQXSTSLABVYGPFJBTIDNVSYCX = new ControllerMessage.TurnedFuncional.AntiSpam.AntiSpamDuples
                                {
                                    EKNLBNZJGKGCCRFSBNEEFFSCXNOYCXSVUKNAMQTLHFZ = true,
                                    MGYQHKJOIDWFQEWESADGGWLHCKNGMOWEIOHQAQKWXT = new ControllerMute.Muted
                                    {
                                        Reason = LanguageEn ? "Duplicate messages (SPAM)" : "Повторяющиеся сообщения (СПАМ)",
                                        MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT = 300,
                                    },
                                    VQGLICRKXTEZSKNNZAHISKHRDEGLUTXZGSHGHCPZGHXBFOICC = 3,
                                }
                            },
                            XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ = new ControllerMessage.TurnedFuncional.PM
                            {
                                LCAQTFAVHYWZPVROWXDBTHSXBWFECQHIMCZEBUTALSPFMPS = true,
                                JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO = "assets/bundled/prefabs/fx/notice/stack.world.fx.prefab",
                            },
                        },
                        YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV = new ControllerMessage.GeneralSettings
                        {
                            BroadcastFormat = new ControllerMessage.GeneralSettings.BroadcastSettings
                            {
                                LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH = "#efedee",
                                BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG = LanguageEn ? "<color=#68cacd><b>[Alert]</b></color>" : "<color=#68cacd><b>[ОПОВЕЩЕНИЕ]</b></color>",
                                DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ = "0",
                            },
                            PLOMZYCAZCHTFUCOKPXEIQGWVXQFAOOTGXSGZSDOMLILN = new ControllerMessage.GeneralSettings.AlertSettings
                            {
                                WVVQCIPDROVHWIIBDQRMRHCJHBRVSLQHPKCTDKTUSTCQLRRH = "#efedee",
                                PFYMWEPTMJARTLGYNSMFPYSWWUYELXPJKECGSVSGNARBTC = "assets/bundled/prefabs/fx/notice/item.select.fx.prefab",
                            },
                            NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB = new ControllerMessage.GeneralSettings.OtherSettings
                            {
                                IWSYZFBBRMBPBFKHPTQGOIZGSZFRPGRDTVQITYPEIDLUQFRAD = 5,
                                SizePrefix = 14,
                                SizeMessage = 14,
                                SizeNick = 14,
                            }
                        },
                    },
                    ControllerAlertSetting = new ControllerAlert
                    {
                        AlertSetting = new ControllerAlert.Alert
                        {
                            AlertMessage = true,
                            AlertMessageType = false,
                            MessageList = new LanguageController()
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "Automatic message #1 (Edit in configuration)",
                                                                                "Automatic message #2 (Edit in configuration)",
                                                                                "Automatic message #3 (Edit in configuration)",
                                                                                "Automatic message #4 (Edit in configuration)",
                                                                                "Automatic message #5 (Edit in configuration)",
                                                                                "Automatic message #6 (Edit in configuration)",
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "Автоматическое сообщение #1 (Редактировать в конфигурации)",
                                                                                "Автоматическое сообщение #2 (Редактировать в конфигурации)",
                                                                                "Автоматическое сообщение #3 (Редактировать в конфигурации)",
                                                                                "Автоматическое сообщение #4 (Редактировать в конфигурации)",
                                                                                "Автоматическое сообщение #5 (Редактировать в конфигурации)",
                                                                                "Автоматическое сообщение #6 (Редактировать в конфигурации)",
                                                                        }
                                },
                            },
                            MessageListTimer = 60,
                        },
                        AdminSessionSetting = new ControllerAlert.AdminSession
                        {
                            ConnectedAlertAdmin = false,
                            DisconnectedAlertAdmin = false,
                        },
                        PlayerSessionSetting = new ControllerAlert.PlayerSession
                        {
                            ConnectedAlert = true,
                            ConnectedAvatarUse = true,
                            ConnectedWorld = true,
                            ConnectionAlertRandom = false,
                            DisconnectedAlert = true,
                            DisconnectedAlertRandom = false,
                            DisconnectedReason = true,
                            RandomConnectionAlert = new LanguageController
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "{0} flew in from {1}",
                                                                                "{0} flew into the server from{1}",
                                                                                "{0} jumped on a server"
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "{0} влетел как дурачок из {1}",
                                                                                "{0} залетел на сервер из {1}, соболезнуем",
                                                                                "{0} прыгнул на сервачок"
                                                                        }
                                }
                            },
                            RandomDisconnectedAlert = new LanguageController()
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "{0} gone to another world",
                                                                                "{0} left the server with a reason {1}",
                                                                                "{0} went to another server"
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "{0} ушел в мир иной",
                                                                                "{0} вылетел с сервера с причиной {1}",
                                                                                "{0} пошел на другой сервачок"
                                                                        }
                                }
                            },
                        },
                        PersonalAlertSetting = new ControllerAlert.PersonalAlert
                        {
                            UseWelcomeMessage = true,
                            WelcomeMessage = new LanguageController
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "Welcome to the server SUPERSERVER\nWe are glad that you chose us!",
                                                                                "Welcome back to the server!\nWe wish you good luck",
                                                                                "Welcome to the server\nWe have the best plugins",
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "Добро пожаловать на сервер SUPERSERVER\nРады,что выбрал именно нас!",
                                                                                "С возвращением на сервер!\nЖелаем тебе удачи",
                                                                                "Добро пожаловать на сервер\nУ нас самые лучшие плагины",
                                                                        }
                                }
                            },
                        }
                    },
                    ReferenceSetting = new ReferenceSettings
                    {
                        IQFakeActiveSettings = new ReferenceSettings.IQFakeActive
                        {
                            UseIQFakeActive = true,
                        },
                        IQRankSystems = new ReferenceSettings.IQRankSystem
                        {
                            FormatRank = "[{0}]",
                            FormatRankTime = "[{0}]",
                            UseRankSystem = false,
                            UseTimeStandart = true
                        },
                        XLevelsSettings = new ReferenceSettings.XLevels()
                        {
                            UseXLevels = false,
                        }
                    },
                    RustPlusSettings = new RustPlus
                    {
                        UseRustPlus = true,
                        DisplayNameAlert = LanguageEn ? "SUPER SERVER" : "СУПЕР СЕРВЕР",
                    },
                    AnswerMessages = new AnswerMessage
                    {
                        UseAnswer = true,
                        AnswerMessageList = new Dictionary<String, LanguageController>()
                        {
                            ["wipe"] = new LanguageController()
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "Wipe will be 27.06"
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "Вайп будет 27.06"
                                                                        }
                                }
                            },
                            ["читер"] = new LanguageController()
                            {
                                LanguageMessages = new Dictionary<String, List<String>>()
                                {
                                    ["en"] = new List<String>() {
                                                                                "Found a cheater? Write /report and send a complaint"
                                                                        },
                                    ["ru"] = new List<String>() {
                                                                                "Нашли читера?Напиши /report и отправь жалобу"
                                                                        }
                                }
                            }
                        },
                    },
                    NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB = new OtherSettings
                    {
                        LogsChat = new OtherSettings.LoggedChat
                        {
                            GlobalChatSettings = new OtherSettings.General
                            {
                                UseLogged = false,
                                Webhooks = "",
                            },
                            TeamChatSettings = new OtherSettings.General
                            {
                                UseLogged = false,
                                Webhooks = "",
                            }
                        },
                        LogsChatCommands = new OtherSettings.General
                        {
                            UseLogged = false,
                            Webhooks = "",
                        },
                        LogsPMChat = new OtherSettings.General
                        {
                            UseLogged = false,
                            Webhooks = "",
                        },
                        LogsMuted = new OtherSettings.General
                        {
                            UseLogged = false,
                            Webhooks = "",
                        },
                    },
                };
            }
        }
        Boolean WBQLIFVSZUBJZTEPOGBUUNYQUVKMABQFGEAAHOTZIXU(UInt64 ID)
        {
            if (!UserInformation.ContainsKey(ID)) return false;
            return UserInformation[ID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice);
        }
        private void UserConnecteionData(BasePlayer player)
        {
            if (config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP || config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP)
            {
                if (!UserInformationConnection.ContainsKey(player.userID)) UserInformationConnection.Add(player.userID, new AntiNoob());
            }
            Configuration.ControllerConnection ControllerConntect = config.ControllerConnect;
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (ControllerConntect == null || NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ == null || UserInformation.ContainsKey(player.userID)) return;
            User Info = new User();
            if (ControllerConntect.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.PGVXJYGKGXGAPYUBPIGKKNOUZRUMUMLLMCBJYQALYYOD)
            {
                if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) Info.Info.PrefixList.Add(ControllerConntect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN ?? "");
                else Info.Info.Prefix = ControllerConntect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN ?? "";
            }
            if (ControllerConntect.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI) Info.Info.ColorNick = ControllerConntect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK;
            if (ControllerConntect.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN.FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK) Info.Info.ColorMessage = ControllerConntect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.MessageDefault;
            Info.Info.Rank = String.Empty;
            UserInformation.Add(player.userID, Info);
        }
        void OnPlayerCommand(BasePlayer player, string command, string[] args)
        {
            XPNMHPHRQRYRNQXRIODTHGWZVHPTUOVSTRXGCYGXZDR(player, command, args);
        }
        private void NYMLIONVZNNJCAQMUIRYDVDUTEIZNBLWTCCWJZEMOVFTRQXG(BasePlayer player)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Context");
            User Info = UserInformation[player.userID];
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (Info == null || NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ == null || Interface == null) return;
            String BackgroundStatic = IQRankSystem && config.ReferenceSetting.IQRankSystems.UseRankSystem ? "UI_IQCHAT_CONTEXT_RANK" : "UI_IQCHAT_CONTEXT_NO_RANK";
            Interface = Interface.Replace("%IMG_BACKGROUND%", ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM(BackgroundStatic));
            Interface = Interface.Replace("%TITLE%", GetLang("IQCHAT_CONTEXT_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTING_ELEMENT%", GetLang("IQCHAT_CONTEXT_SETTING_ELEMENT_TITLE", player.UserIDString));
            Interface = Interface.Replace("%INFORMATION%", GetLang("IQCHAT_CONTEXT_INFORMATION_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTINGS%", GetLang("IQCHAT_CONTEXT_SETTINGS_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTINGS_PM%", GetLang("IQCHAT_CONTEXT_SETTINGS_PM_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTINGS_ALERT%", GetLang("IQCHAT_CONTEXT_SETTINGS_ALERT_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTINGS_ALERT_PM%", GetLang("IQCHAT_CONTEXT_SETTINGS_ALERT_PM_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SETTINGS_SOUNDS%", GetLang("IQCHAT_CONTEXT_SETTINGS_SOUNDS_TITLE", player.UserIDString));
            Interface = Interface.Replace("%MUTE_STATUS_TITLE%", GetLang("IQCHAT_CONTEXT_MUTE_STATUS_TITLE", player.UserIDString));
            Interface = Interface.Replace("%IGNORED_STATUS_COUNT%", GetLang("IQCHAT_CONTEXT_IGNORED_STATUS_COUNT", player.UserIDString, Info.Settings.IgnoreUsers.Count));
            Interface = Interface.Replace("%IGNORED_STATUS_TITLE%", GetLang("IQCHAT_CONTEXT_IGNORED_STATUS_TITLE", player.UserIDString));
            Interface = Interface.Replace("%MUTE_STATUS_PLAYER%", Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) ? FormatTime(Info.MuteInfo.GetTime(MuteType.Chat), player.UserIDString) : GetLang("IQCHAT_CONTEXT_MUTE_STATUS_NOT", player.UserIDString));
            Interface = Interface.Replace("%SLIDER_PREFIX_TITLE%", GetLang("IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SLIDER_NICK_COLOR_TITLE%", GetLang("IQCHAT_CONTEXT_SLIDER_NICK_COLOR_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SLIDER_MESSAGE_COLOR_TITLE%", GetLang("IQCHAT_CONTEXT_SLIDER_MESSAGE_COLOR_TITLE", player.UserIDString));
            Interface = Interface.Replace("%SLIDER_IQRANK_TITLE%", IQRankSystem && config.ReferenceSetting.IQRankSystems.UseRankSystem ? GetLang("IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE", player.UserIDString) : String.Empty);
            CuiHelper.DestroyUi(player, InterfaceBuilder.UI_Chat_Context);
            CuiHelper.AddUi(player, Interface);
            TPITDOQLLZTKBZCKLMXVSYHIACJTGFZVZTPKZLDFHWT(player);
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM.NGSKGILLMUCIMZNQAEBTPLUEIFMEGOIKZPLBNSSCL == SelectedParametres.DropList || NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) ZULJWHDVLBXLEFVQAPODKWMOXTJVAOBZHKGUBKHZSIHXKJR(player, "-46.788 162.4", "-19.788 187.4", GetLang("IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE_DESCRIPTION", player.UserIDString), NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB ? TakeElementUser.MultiPrefix : TakeElementUser.Prefix);
            else RNSHFUZKZZAFDZQEBWVWHDGJESBFQQEUJUVWANBPXDFPQVO(player, "SLIDER_PREFIX", "-275 150", "-16 184", TakeElementUser.Prefix);
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM.ZSMICAHWXCZJPBLOCBWHFYLSIXNLDILYICLBSZCMXKQGK == SelectedParametres.DropList) ZULJWHDVLBXLEFVQAPODKWMOXTJVAOBZHKGUBKHZSIHXKJR(player, "254.788 162.4", "281.788 187.4", GetLang("IQCHAT_CONTEXT_SLIDER_CHAT_NICK_TITLE_DESCRIPTION", player.UserIDString), TakeElementUser.Nick);
            else RNSHFUZKZZAFDZQEBWVWHDGJESBFQQEUJUVWANBPXDFPQVO(player, "SLIDER_NICK_COLOR", "28 150", "287 184", TakeElementUser.Nick);
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM.ZJPYPRGEHAHTZFMVSOQABMQKWCYJJVIFHTXDVFSUSDUKUY == SelectedParametres.DropList) ZULJWHDVLBXLEFVQAPODKWMOXTJVAOBZHKGUBKHZSIHXKJR(player, "-46.788 78.4", "-19.788 103.4", GetLang("IQCHAT_CONTEXT_SLIDER_CHAT_MESSAGE_TITLE_DESCRIPTION", player.UserIDString), TakeElementUser.Chat);
            else RNSHFUZKZZAFDZQEBWVWHDGJESBFQQEUJUVWANBPXDFPQVO(player, "SLIDER_MESSAGE_COLOR", "-275 68", "-16 102", TakeElementUser.Chat);
            if (IQRankSystem && config.ReferenceSetting.IQRankSystems.UseRankSystem)
            {
                if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.DOSHDXDJYBVAIUMQFJXUIOAHANIWUXWBJMCMKMHZXPETTM.XABRBPJONTFCNTXVMSBLGIIANWWIXSGPXCAJHDGP == SelectedParametres.DropList) ZULJWHDVLBXLEFVQAPODKWMOXTJVAOBZHKGUBKHZSIHXKJR(player, "254.788 78.4", "281.788 103.4", GetLang("IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_DESCRIPTION", player.UserIDString), TakeElementUser.Rank);
                else RNSHFUZKZZAFDZQEBWVWHDGJESBFQQEUJUVWANBPXDFPQVO(player, "SLIDER_IQRANK", "28 68", "287 102", TakeElementUser.Rank);
            }
            HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, ElementsSettingsType.PM, "226.38 -37.712", "243.125 -20.088", Info.Settings.TurnPM);
            HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, ElementsSettingsType.Broadcast, "226.38 -57.712", "243.125 -40.088", Info.Settings.TurnBroadcast);
            HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, ElementsSettingsType.Alert, "226.38 -77.712", "243.125 -60.088", Info.Settings.TurnAlert);
            HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, ElementsSettingsType.Sound, "226.38 -97.712", "243.125 -80.088", Info.Settings.TurnSound);
            VIFYOMSRCUSMSKKCZFVEXVATVJJLBPDMIVHQHASYVENJZNQY(player);
        }
        private void OnServerInitialized()
        {
            _ = this;
            ImageUi.HWRJJNURJCATMXHIDBVAKGXGDCNQODOHVCHLQFHRPGTDH();
            XIMABJEQZGJFQDKXXZTBKFXAEVAXNYVZENPBBPQD();
            foreach (BasePlayer player in BasePlayer.activePlayerList) UserConnecteionData(player);
            AKTMJPMNGJDMTUTJUGVIDTEOUGZEYRSIECFGWSKUIHQRJPVCJ();
            PGEOWITOZGZDTAMRSOLTHMLKPOVBNVADBLPZGIYU();
            GMFFIIDMPLTJQBINKKKJCXMAWUHVSKUCPDYBWSDZOUUZ();
            if (!config.ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.DRHQLJMHSPIGEXWGVNKXGFYSSFUKWGDGHYKLPZTMCMPAQEDBQ) Unsubscribe("OnUserConnected");
        }
        [PluginReference] Plugin ImageLibrary, IQPersonal, IQFakeActive, IQRankSystem, XLevels, Clans;
        void Init()
        {
            ReadData();
        }
        public String GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(BasePlayer player, Dictionary<String, List<String>> LanguageMessages)
        {
            String LangPlayer = _.lang.GetLanguage(player.UserIDString);
            if (LanguageMessages.ContainsKey(LangPlayer)) return LanguageMessages[LangPlayer].GetRandom();
            else if (LanguageMessages.ContainsKey("en")) return LanguageMessages["en"].GetRandom();
            else return LanguageMessages.FirstOrDefault().Value.GetRandom();
        }
        public class FakePlayer
        {
            public ulong UserID;
            public string DisplayName;
        }
        private void OnUserConnected(IPlayer player) => NFWQMXCOMXRCYQGHKYAFAAGZXULYKPIRHTWFGGAXBQCNPRL(player);
        List<String> AAXIDDIVAMJBLOQWELBAPATPNULPDZIUJSDCKSYDOQPKBJ(ulong userID) => (List<string>)(IQRankSystem?.Call("API_RANK_USER_KEYS", userID));
        private void DPEAPMGBAGHVJRTSBDPRSKOLMNXMYKIODEIZYYTIDRCVC(BasePlayer player, BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, UInt64 KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU = 0)
        {
            String InterfacePanel = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Alert_Panel");
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_Alert");
            if (Interface == null || InterfacePanel == null) return;
            User InfoTarget = (IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? null : UserInformation[JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID];
            Interface = Interface.Replace("%TITLE%", GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT", player.UserIDString));
            Interface = Interface.Replace("%BUTTON_TAKE_CHAT_ACTION%", InfoTarget == null ? GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_CHAT", player.UserIDString) : InfoTarget.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) ? GetLang("IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_CHAT", player.UserIDString) : GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_CHAT", player.UserIDString));
            Interface = Interface.Replace("%BUTTON_TAKE_VOICE_ACTION%", InfoTarget == null ? GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_VOICE", player.UserIDString) : InfoTarget.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice) ? GetLang("IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_VOICE", player.UserIDString) : GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_VOICE", player.UserIDString));
            Interface = Interface.Replace("%COMMAND_TAKE_ACTION_MUTE_CHAT%", InfoTarget == null ? $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} open.reason.mute {KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU} {MuteType.Chat}" : InfoTarget.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) ? $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} unmute.yes {JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString} {MuteType.Chat}" : $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} open.reason.mute {JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString} {MuteType.Chat}");
            Interface = Interface.Replace("%COMMAND_TAKE_ACTION_MUTE_VOICE%", InfoTarget == null ? $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} open.reason.mute {KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU} {MuteType.Voice}" : InfoTarget.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice) ? $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} unmute.yes {JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString} {MuteType.Voice}" : $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} open.reason.mute {JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString} {MuteType.Voice}");
            CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
            CuiHelper.AddUi(player, InterfacePanel);
            CuiHelper.AddUi(player, Interface);
        }
        private void OLVYOHLRWSBTOCOTDPYTSEJTTCKHOBISJPYMRZWACLIQYFKR(BasePlayer player, BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, String Reason, Int32 Y, MuteType Type, UInt64 KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU = 0)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_Alert_DropList_Reason");
            if (Interface == null) return;
            Interface = Interface.Replace("%OFFSET_MIN%", $"-147.5 {85.42 - (Y * 40)}");
            Interface = Interface.Replace("%OFFSET_MAX%", $"147.5 {120.42 - (Y * 40)}");
            Interface = Interface.Replace("%REASON%", Reason);
            Interface = Interface.Replace("%COMMAND_REASON%", $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Mute} confirm.yes {((IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID)} {Type} {Y}");
            CuiHelper.AddUi(player, Interface);
        }
        private String Format(Int32 units, String form1, String form2, String form3)
        {
            var tmp = units % 10;
            if (units >= 5 && units <= 20 || tmp >= 5 && tmp <= 9) return $"{units}{form1}";
            if (tmp >= 2 && tmp <= 4) return $"{units}{form2}";
            return $"{units}{form3}";
        }
        private void JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, MuteType Type, BasePlayer Moderator = null, Boolean DVRYGVXMLONPWDHCLXFHWTYJPZUBOHLHGDIXUPZASDGWQFWS = false, Boolean Command = false)
        {
            if (!UserInformation.ContainsKey(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID)) return;
            User Info = UserInformation[JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID];
            GeneralInformation.RenameInfo TargetRename = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID);
            GeneralInformation.RenameInfo ModeratorRename = Moderator != null ? GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(Moderator.userID) : null;
            if (!Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(Type))
            {
                if (Moderator != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "The player is not banned" : "У игрока нет блокировки");
                else Puts(LanguageEn ? "The player is not banned!" : "У игрока нет блокировки!");
                return;
            }
            String TargetName = TargetRename != null ? $"{TargetRename.RenameNick ?? JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName}" : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName;
            String NameModerator = Moderator == null ? GetLang("IQCHAT_FUNCED_ALERT_TITLE_SERVER", JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString) : ModeratorRename != null ? $"{ModeratorRename.RenameNick ?? Moderator.displayName}" : Moderator.displayName;
            String LangMessage = Type == MuteType.Chat ? "FUNC_MESSAGE_UNMUTE_CHAT" : "FUNC_MESSAGE_UNMUTE_VOICE";
            if (!DVRYGVXMLONPWDHCLXFHWTYJPZUBOHLHGDIXUPZASDGWQFWS) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName));
            else
            {
                if (JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName));
                if (Moderator != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName));
            }
            Info.MuteInfo.UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(Type);
            ZJPPIBOBJVOTCSYYRTCCFRQZLOGTCKGVRLOUHHNMOFOICH(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, Type, Moderator: Moderator);
        }
        private void MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(BasePlayer player, SelectedAction Action, Int32 Page = 0, String SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ = null)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Panel_Content");
            if (Interface == null) return;
            CuiHelper.DestroyUi(player, "MuteIgnorePanelContent");
            CuiHelper.AddUi(player, Interface);
            if (IQFakeActive)
            {
                var FakePlayerList = Action == SelectedAction.Mute ? SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ != null ? PlayerBases.Where(p => p.DisplayName.ToLower().Contains(SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ.ToLower())).OrderByDescending(p => !IsFake(p.UserID) && UserInformation.ContainsKey(p.UserID) && (UserInformation[p.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || UserInformation[p.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice))) : PlayerBases.OrderByDescending(p => !IsFake(p.UserID) && UserInformation.ContainsKey(p.UserID) && (UserInformation[p.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || UserInformation[p.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice))) : SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ != null ? PlayerBases.Where(p => p.DisplayName.ToLower().Contains(SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ.ToLower())).OrderByDescending(p => !IsFake(p.UserID) && UserInformation.ContainsKey(p.UserID) && (UserInformation[player.userID].Settings.IgnoreUsers.Contains(p.UserID))) : PlayerBases.OrderByDescending(p => !IsFake(p.UserID) && UserInformation.ContainsKey(p.UserID) && (UserInformation[player.userID].Settings.IgnoreUsers.Contains(p.UserID)));
                NBLZTCQEADSPRPGJEWLVHGNGRHUASPVLAEVRRYCAJLV(player, (Boolean)(FakePlayerList.Skip(12 * (Page + 1)).Count() > 0), Action, Page);
                EFKYEBMIENRSRMCPOIVTOUCPNQXADPXHFYRSKPGWNMQ(player, Action, null, FakePlayerList.Skip(12 * Page).Take(12));
            }
            else
            {
                IOrderedEnumerable<BasePlayer> PlayerList = Action == SelectedAction.Mute ? SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ != null ? BasePlayer.activePlayerList.Where(p => UserInformation.ContainsKey(p.userID) && p.displayName.ToLower().Contains(SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ.ToLower())).OrderBy(p => UserInformation[p.userID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || UserInformation[p.userID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice)) : BasePlayer.activePlayerList.Where(p => UserInformation.ContainsKey(p.userID)).OrderBy(p => UserInformation[p.userID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || UserInformation[p.userID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice)) : SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ != null ? BasePlayer.activePlayerList.Where(p => UserInformation.ContainsKey(p.userID) && p.displayName.ToLower().Contains(SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ.ToLower())).OrderBy(p => UserInformation[player.userID].Settings.IgnoreUsers.Contains(p.userID)) : BasePlayer.activePlayerList.Where(p => UserInformation.ContainsKey(p.userID)).OrderBy(p => UserInformation[player.userID].Settings.IgnoreUsers.Contains(p.userID));
                NBLZTCQEADSPRPGJEWLVHGNGRHUASPVLAEVRRYCAJLV(player, (Boolean)(PlayerList.Skip(12 * (Page + 1)).Count() > 0), Action, Page);
                EFKYEBMIENRSRMCPOIVTOUCPNQXADPXHFYRSKPGWNMQ(player, Action, PlayerList.Skip(12 * Page).Take(12));
            }
        }
        private
        const String PermissionRename = "iqchat.renameuse";
        private void XIMABJEQZGJFQDKXXZTBKFXAEVAXNYVZENPBBPQD()
        {
            if (config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP || config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.OYTVZYCTFRLTVFOCOGCNGHPKTNCGOSADWRVOTCWNGXYY.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP)
            {
                if (UserInformationConnection.Count == 0 || UserInformationConnection == null)
                {
                    PrintWarning(LanguageEn ? "Migration of old players to Anti-Nub.." : "Миграция старых игроков в Анти-Нуб..");
                    foreach (KeyValuePair<UInt64, User> InfoUser in UserInformation.Where(x => !UserInformationConnection.ContainsKey(x.Key))) UserInformationConnection.Add(InfoUser.Key, new AntiNoob
                    {
                        DateConnection = new DateTime(2022, 1, 1)
                    });
                    PrintWarning(LanguageEn ? "Migration of old players completed" : "Миграция старых игроков завершена");
                }
            }
        }
        private String SUNOEXCIJHWFBRSLMVFIGDAKKACOJVHIPWRLJLZYY(UInt64 playerID)
        {
            if (!Clans) return String.Empty;
            String ClanTag = (String)Clans?.CallHook("GetClanOf", playerID);
            return String.IsNullOrWhiteSpace(ClanTag) ? String.Empty : GetLang("CLANS_SYNTAX_PREFIX", playerID.ToString(), ClanTag);
        }
        [ConsoleCommand("alertuip")]
        private void ERYUCWWQPTLVXPTCDDUOZNZNPFAHBAWHKSYJMPYGRTGNX(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            if (args.Args == null || args.Args.Length == 0)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "You didn't specify a player!" : "Вы не указали игрока!");
                else PrintWarning(LanguageEn ? "You didn't specify a player!" : "Вы не указали игрока!");
                return;
            }
            BasePlayer Recipient = BasePlayer.Find(args.Args[0]);
            if (Recipient == null)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "The player is not on the server!" : "Игрока нет на сервере!");
                else PrintWarning(LanguageEn ? "The player is not on the server!" : "Игрока нет на сервере!");
                return;
            }
            AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, Recipient, args.Args.Skip(1).ToArray());
        }
        private List<String> YBRHHVDJORRKFWWPOOXDKFRJQNFOXFGLQUGZPUSBDADHSBK()
        {
            List<String> PlayerNames = new List<String>();
            Int32 Count = 1;
            foreach (BasePlayer playerInList in BasePlayer.activePlayerList.Where(p => !permission.UserHasPermission(p.UserIDString, PermissionHideOnline)))
            {
                String SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO = $"{Count} - {ERPAXVYQQQBDCSGDGMCMOAMMCJXMZCNLDWEFUESXP(playerInList)}";
                PlayerNames.Add(SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO);
                Count++;
            }
            if (IQFakeActive)
            {
                foreach (FakePlayer fakePlayer in PlayerBases.Where(x => IsFake(x.UserID)))
                {
                    String SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO = $"{Count} - {API_GET_DEFAULT_PREFIX()}<color={API_GET_DEFAULT_NICK_COLOR()}>{fakePlayer.DisplayName}</color>";
                    PlayerNames.Add(SRLWQNUUFUHICVJMDDNGQFRLHIAFPJDKJBNQTMQZLPCO);
                    Count++;
                }
            }
            return PlayerNames;
        }
        private void KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, MuteType Type, Int32 FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV, BasePlayer Moderator = null, String EYHNCJDZVMENBWNWCPFTPNEKGSKPPCMWTVFXISDJ = null, Int32 IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ = 0, Boolean IRKODLLTKXYTWBQYOIDIJRUFRLUMUUXMJKZDUCNCZSLLHG = false, Boolean Command = false, UInt64 KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU = 0)
        {
            Configuration.ControllerMute LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL = config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL;
            if (IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && (IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, GetLang(Type == MuteType.Chat ? "FUNC_MESSAGE_MUTE_CHAT" : "FUNC_MESSAGE_MUTE_VOICE", Moderator != null ? Moderator.displayName : Moderator.UserIDString, GetLang("IQCHAT_FUNCED_ALERT_TITLE_SERVER"), FindFakeName(KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU), FormatTime(IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ == 0 ? config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT : IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ), EYHNCJDZVMENBWNWCPFTPNEKGSKPPCMWTVFXISDJ ?? config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].Reason));
                QXMQDFSQHUFLPIRFUNGQDTYCQIVGWWDEEFONQDILYJWV(KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU);
                FakePlayer FakeP = PlayerBases.FirstOrDefault(x => x.UserID == KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU);
                if (FakeP != null) PlayerBases.Remove(FakeP);
                return;
            }
            if (!UserInformation.ContainsKey(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID)) return;
            User Info = UserInformation[JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID];
            String LangMessage = String.Empty;
            String Reason = String.Empty;
            Int32 MuteTime = 0;
            String NameModerator = GetLang("IQCHAT_FUNCED_ALERT_TITLE_SERVER", JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString);
            if (Moderator != null)
            {
                GeneralInformation.RenameInfo ModeratorRename = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(Moderator.userID);
                NameModerator = ModeratorRename != null ? $"{ModeratorRename.RenameNick ?? Moderator.displayName}" : Moderator.displayName;
            }
            GeneralInformation.RenameInfo TagetRename = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID);
            String TargetName = TagetRename != null ? $"{TagetRename.RenameNick ?? JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName}" : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName;
            if (JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null || !JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.IsConnected)
            {
                if (Moderator != null && !Command) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, GetLang("UI_CHAT_PANEL_MODERATOR_MUTE_PANEL_TAKE_TYPE_CHAT_ACTION_NOT_CONNNECTED", Moderator.UserIDString));
                return;
            }
            if (Moderator != null && !Command)
                if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(Type))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, GetLang("IQCHAT_FUNCED_ALERT_TITLE_ISMUTED", Moderator.UserIDString));
                    return;
                }
            switch (Type)
            {
                case MuteType.Chat:
                    {
                        Reason = EYHNCJDZVMENBWNWCPFTPNEKGSKPPCMWTVFXISDJ ?? LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].Reason;
                        MuteTime = IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ == 0 ? LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT : IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ;
                        LangMessage = "FUNC_MESSAGE_MUTE_CHAT";
                        break;
                    }
                case MuteType.Voice:
                    {
                        Reason = EYHNCJDZVMENBWNWCPFTPNEKGSKPPCMWTVFXISDJ ?? LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].Reason;
                        MuteTime = IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ == 0 ? LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL[FDTKVDXHJLIVYHXVNZEXMCDYYQPWKVPFFSOIIJOYFCMNVLUV].MEPHDKKCIUXNHIIUFATNGUFBLVASPKRDMWFZYUBJAYTHHMMLT : IMWJKDFYRSWOCLRTWHJYNKSAIUFQQNKMWIGAIBVOEQXJ;
                        LangMessage = "FUNC_MESSAGE_MUTE_VOICE";
                        break;
                    }
            }
            Info.MuteInfo.QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(Type, MuteTime);
            if (!IRKODLLTKXYTWBQYOIDIJRUFRLUMUUXMJKZDUCNCZSLLHG) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName, FormatTime(MuteTime, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString), Reason));
            else
            {
                if (JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName, FormatTime(MuteTime, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString), Reason));
                if (Moderator != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, GetLang(LangMessage, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString, NameModerator, TargetName, FormatTime(MuteTime, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString), Reason));
            }
            if (Moderator != null && Moderator != JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI) KFLTWSBNUGBQTORAZOWCWGYVTRPJHFTDPVOPVVXC(Moderator);
            ZJPPIBOBJVOTCSYYRTCCFRQZLOGTCKGVRLOUHHNMOFOICH(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, Type, Reason, FormatTime(MuteTime, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString), Moderator);
        }
        String API_GET_DEFAULT_PREFIX() => config.ControllerConnect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN;
        [ConsoleCommand("mute")]
        void ICSQUQTBEKUOPCHZBWNBCJAIFHTXIFDMONSOSWWRC(ConsoleSystem.Arg arg)
        {
            if (arg.Player() != null)
                if (!permission.UserHasPermission(arg.Player().UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Args == null || arg.Args.Length != 3 || arg.Args.Length > 3)
            {
                PrintWarning(LanguageEn ? "Invalid syntax, use : mute Steam64ID/Nick Reason Time(seconds)" : "Неверный синтаксис,используйте : mute Steam64ID/Ник Причина Время(секунды)");
                return;
            }
            string NameOrID = arg.Args[0];
            string Reason = arg.Args[1];
            Int32 TimeMute = 0;
            if (!Int32.TryParse(arg.Args[2], out TimeMute))
            {
                PrintWarning(LanguageEn ? "Enter time in numbers!" : "Введите время цифрами!");
                return;
            }
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            PrintWarning(LanguageEn ? "The player already has a chat lock" : "Игрок уже имеет блокировку чата");
                            return;
                        }
                        Info.MuteInfo.QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(MuteType.Chat, TimeMute);
                        PrintWarning(LanguageEn ? "Chat blocking issued to offline player" : "Блокировка чата выдана offline-игроку");
                        return;
                    }
                    else
                    {
                        PrintWarning(LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    PrintWarning(LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(target, MuteType.Chat, 0, arg.Player(), Reason, TimeMute, false, true);
            Puts(LanguageEn ? "Successfully" : "Успешно");
        }
        private void TPITDOQLLZTKBZCKLMXVSYHIACJTGFZVZTPKZLDFHWT(BasePlayer player)
        {
            String InterfaceVisualNick = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Context_Visual_Nick");
            User Info = UserInformation[player.userID];
            Configuration.ControllerParameters Controller = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (Info == null || InterfaceVisualNick == null || Controller == null) return;
            String DisplayNick = String.Empty;
            String Pattern = @"</?size.*?>";
            if (Controller.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB)
            {
                if (Info.Info.PrefixList != null && Info.Info.PrefixList.Count != 0) DisplayNick += Info.Info.PrefixList.Count > 1 ? $"{(Regex.IsMatch(Info.Info.PrefixList[0], Pattern) ? Regex.Replace(Info.Info.PrefixList[0], Pattern, "") : Info.Info.PrefixList[0])}+{Info.Info.PrefixList.Count - 1}" : (Regex.IsMatch(Info.Info.PrefixList[0], Pattern) ? Regex.Replace(Info.Info.PrefixList[0], Pattern, "") : Info.Info.PrefixList[0]);
            }
            else DisplayNick += Regex.IsMatch(Info.Info.Prefix, Pattern) ? Regex.Replace(Info.Info.Prefix, Pattern, "") : Info.Info.Prefix;
            DisplayNick += $"<color={Info.Info.ColorNick ?? "#ffffff "}>{player.displayName}</color>: <color={Info.Info.ColorMessage ?? "#ffffff "}>{GetLang("IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE", player.UserIDString)}</color>";
            InterfaceVisualNick = InterfaceVisualNick.Replace("%NICK_DISPLAY%", DisplayNick);
            CuiHelper.DestroyUi(player, InterfaceBuilder.UI_Chat_Context_Visual_Nick);
            CuiHelper.AddUi(player, InterfaceVisualNick);
        }
        [ChatCommand("ignore")]
        void SDMSLIKKUHQVIATBEWFGAXLHKRLZJRNVEDPWQQHYU(BasePlayer player, String cmd, String[] arg)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            if (!ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW) return;
            User Info = UserInformation[player.userID];
            if (arg.Length == 0 || arg == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("INGORE_NOTARG", player.UserIDString));
                return;
            }
            String NameUser = arg[0];
            BasePlayer TargetUser = BasePlayer.Find(NameUser);
            if (TargetUser == null || NameUser == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COMMAND_PM_NOT_USER", player.UserIDString));
                return;
            }
            String Lang = !Info.Settings.IsIgnored(TargetUser.userID) ? GetLang("IGNORE_ON_PLAYER", player.UserIDString, TargetUser.displayName) : GetLang("IGNORE_OFF_PLAYER", player.UserIDString, TargetUser.displayName);
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, Lang);
            Info.Settings.LURXCJHXVGTLXWQVXZDMELEPUDLOCMACKOJBRTNBUNNCT(TargetUser.userID);
        }
        private void UOSMCEYLXJTSZFSZVMVSYSKEZNWTESKIWFXHWZOY(BasePlayer player, TakeElementUser RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR, Configuration.ControllerParameters.AdvancedFuncion Info, Int32 AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG, Int32 Y, Int32 Count)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_OpenDropListArgument");
            if (Interface == null) return;
            String Argument = RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.MultiPrefix || RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.Prefix ? Info.Argument : RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.Nick ? $"<color={Info.Argument}>{player.displayName}</color>" : RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.Chat ? $"<color={Info.Argument}>{GetLang("IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE", player.UserIDString)}</color>" : RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.Rank ? TIRHWFQNPLKGITDVTYIMRADFVBHLNKKQRQODUDSIF(Info.Argument) : String.Empty;
            Interface = Interface.Replace("%OFFSET_MIN%", $"{-140.329 - (-103 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {-2.243 + (Y * -28)}");
            Interface = Interface.Replace("%OFFSET_MAX%", $"{-65.271 - (-103 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {22.568 + (Y * -28)}");
            Interface = Interface.Replace("%COUNT%", Count.ToString());
            Interface = Interface.Replace("%ARGUMENT%", Argument);
            Interface = Interface.Replace("%TAKE_COMMAND_ARGUMENT%", $"newui.cmd droplist.controller element.take {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR} {Count} {Info.Permissions} {Info.Argument}");
            CuiHelper.DestroyUi(player, $"ArgumentDropList_{Count}");
            CuiHelper.AddUi(player, Interface);
        }
        void OnPlayerConnected(BasePlayer player)
        {
            UserConnecteionData(player);
            LRGTFXVRCLXCZBXSMLXQFBZIAGBFYDGWGROYUIHSJUHMY(player);
        }
        private
        const String PermissionMutedAdmin = "iqchat.adminmuted";
        public class GeneralInformation
        {
            public Boolean TurnMuteAllChat;
            public Boolean TurnMuteAllVoice;
            public Dictionary<UInt64, RenameInfo> RenameList = new Dictionary<UInt64, RenameInfo>();
            internal class RenameInfo
            {
                public String RenameNick;
                public UInt64 RenameID;
            }
            public RenameInfo BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(UInt64 UserID)
            {
                if (!RenameList.ContainsKey(UserID)) return null;
                return RenameList[UserID];
            }
        }
        [ChatCommand("alertui")]
        private void AUELINBIOZYIDYOUQNWKASZYASEKDULRRZEQSZFAEDWWUW(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] args)
        {
            if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args);
        }
        public void QXMQDFSQHUFLPIRFUNGQDTYCQIVGWWDEEFONQDILYJWV(UInt64 userID)
        {
            if (!IQFakeActive) return;
            IQFakeActive?.Call("RemoveReserver", userID);
        }
        public class FancyMessage
        {
            public string content
            {
                get;
                set;
            }
            public bool tts
            {
                get;
                set;
            }
            public Embeds[] embeds
            {
                get;
                set;
            }
            public class Embeds
            {
                public string title
                {
                    get;
                    set;
                }
                public int color
                {
                    get;
                    set;
                }
                public List<Fields> fields
                {
                    get;
                    set;
                }
                public Footer footer
                {
                    get;
                    set;
                }
                public Authors author
                {
                    get;
                    set;
                }
                public Embeds(string title, int color, List<Fields> fields, Authors author, Footer footer)
                {
                    this.title = title;
                    this.color = color;
                    this.fields = fields;
                    this.author = author;
                    this.footer = footer;
                }
            }
            public FancyMessage(string content, bool tts, Embeds[] embeds)
            {
                this.content = content;
                this.tts = tts;
                this.embeds = embeds;
            }
            public string OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW() => JsonConvert.SerializeObject(this);
        }
        String OGDNBLPLELHGXIKLESNPZVUYCGTWRWKINDQHNQTGEMZEUL(ulong userID) => (string)(IQRankSystem?.Call("API_GET_TIME_GAME", userID));
        private String KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String[] arg)
        {
            if (arg == null || arg.Length == 0)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("FUNC_MESSAGE_NO_ARG_BROADCAST", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                else PrintWarning(GetLang("FUNC_MESSAGE_NO_ARG_BROADCAST"));
                return null;
            }
            String Message = String.Empty;
            foreach (String msg in arg) Message += " " + msg;
            return Message;
        }
        private void VIFYOMSRCUSMSKKCZFVEXVATVJJLBPDMIVHQHASYVENJZNQY(BasePlayer player)
        {
            if (!permission.UserHasPermission(player.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            String InterfaceModeration = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Moderation");
            if (InterfaceModeration == null) return;
            InterfaceModeration = InterfaceModeration.Replace("%TITLE%", GetLang("IQCHAT_TITLE_MODERATION_PANEL", player.UserIDString));
            InterfaceModeration = InterfaceModeration.Replace("%COMMAND_MUTE_MENU%", $"newui.cmd action.mute.ignore open {SelectedAction.Mute}");
            InterfaceModeration = InterfaceModeration.Replace("%TEXT_MUTE_MENU%", GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU", player.UserIDString));
            CuiHelper.AddUi(player, InterfaceModeration);
            GKHFZZRGEZCPKSEPJGOCENVZICOJLTUQCQVFSAOBRUPFUSRY(player);
            SKZIQLTVULHXUUVYSHUAQTFVHTWVIUHLMXFBJABUVVMVAJQWZ(player);
        }
        String DMRLGZZHMDECGQNRFDWDUVZMXITIQUHSLNXDMBBWHIVWNWONA() => config.ControllerConnect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.MessageDefault;
        void TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(BasePlayer player, String Message, String XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH = null, String FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV = null, String QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU = null)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            String Prefix = (XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH == null || String.IsNullOrWhiteSpace(XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH)) ? (ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG == null || String.IsNullOrWhiteSpace(ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG)) ? "" : ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.BBGPKWWZAFONDOBODJQJIJRIASENSBQIVGQKCBLMYJG : XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH;
            String AvatarID = (FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV == null || String.IsNullOrWhiteSpace(FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV)) ? (ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ == null || String.IsNullOrWhiteSpace(ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ)) ? "0" : ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.DHYZENTUOCHQGQGVJTFLYGZPYBWCHWUFHZOPZQIODJ : FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV;
            String Hex = (QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU == null || String.IsNullOrWhiteSpace(QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU)) ? (ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH == null || String.IsNullOrWhiteSpace(ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH)) ? "#ffff" : ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.BroadcastFormat.LIDTAGHICRZSKXOSSJGZOFSWXQMCXDKZCLWSPKMLUH : QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU;
            player.SendConsoleCommand("chat.add", Chat.ChatChannel.Global, AvatarID, $"{Prefix}<color={Hex}>{Message}</color>");
        }
        String ABFVUQNPHTARIKFNDAJRRXNAIDTXQXKETWBWVYLSK(ulong userID) => (string)(IQRankSystem?.Call("API_GET_RANK_NAME", userID));
        void QFPSHGBZAPHAMCOENRWPYJIVYLIISFPRHGHHKQVNVRXV(BasePlayer player, String Message) => XVTPPUQLGGAWQEFCYNXMQNCPAGOBJBTEXHCRTMTDWO(player, Message);
        private void SKZIQLTVULHXUUVYSHUAQTFVHTWVIUHLMXFBJABUVVMVAJQWZ(BasePlayer player)
        {
            if (!permission.UserHasPermission(player.UserIDString, PermissionMutedAdmin)) return;
            String InterfaceAdministratorVoice = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Administation_AllVoce");
            if (InterfaceAdministratorVoice == null) return;
            InterfaceAdministratorVoice = InterfaceAdministratorVoice.Replace("%TEXT_MUTE_ALLVOICE%", GetLang(!GeneralInfo.TurnMuteAllVoice ? "IQCHAT_BUTTON_MODERATION_MUTE_ALL_VOICE" : "IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_VOICE", player.UserIDString));
            InterfaceAdministratorVoice = InterfaceAdministratorVoice.Replace("%COMMAND_MUTE_ALLVOICE%", $"newui.cmd action.mute.ignore mute.controller {SelectedAction.Mute} mute.all.voice");
            CuiHelper.DestroyUi(player, "ModeratorMuteAllVoice");
            CuiHelper.AddUi(player, InterfaceAdministratorVoice);
        }
        private static ConfigurationOld configOld = new ConfigurationOld();
        protected override void SaveConfig() => Config.WriteObject(config);
        public Dictionary<UInt64, FlooderInfo> Flooders = new Dictionary<UInt64, FlooderInfo>();
        [ConsoleCommand("hunmute")]
        void DJDVHZFDBWOYNAEVKWOUOSFZEUHJVXDAVTQXIRQGWFZEG(ConsoleSystem.Arg arg)
        {
            if (arg.Player() != null)
                if (!permission.UserHasPermission(arg.Player().UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Args == null || arg.Args.Length != 1 || arg.Args.Length > 1)
            {
                PrintWarning(LanguageEn ? "Invalid syntax, please use : hunmute Steam64ID" : "Неверный синтаксис,используйте : hunmute Steam64ID");
                return;
            }
            string NameOrID = arg.Args[0];
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (!Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "The player does not have a chat lock" : "У игрока нет блокировки чата");
                            return;
                        }
                        Info.MuteInfo.UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(MuteType.Chat);
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "You have unblocked the offline chat to the player" : "Вы разблокировали чат offline игроку");
                        return;
                    }
                    else
                    {
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(target, MuteType.Chat, arg.Player(), true, true);
        }
        private void ILRFYTHFALEDQMSVIDTNCTJGMTGIYJSATIMVSQYKSQSFTFBD(BasePlayer player, TakeElementUser RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Slider_Update_Argument");
            User Info = UserInformation[player.userID];
            if (Info == null || Interface == null) return;
            String Argument = String.Empty;
            String Name = String.Empty;
            String Parent = String.Empty;
            switch (RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR)
            {
                case TakeElementUser.Prefix:
                    Argument = Info.Info.Prefix;
                    Parent = "SLIDER_PREFIX";
                    Name = "ARGUMENT_PREFIX";
                    break;
                case TakeElementUser.Nick:
                    Argument = $"<color={Info.Info.ColorNick}>{player.displayName}</color>";
                    Parent = "SLIDER_NICK_COLOR";
                    Name = "ARGUMENT_NICK_COLOR";
                    break;
                case TakeElementUser.Chat:
                    Argument = $"<color={Info.Info.ColorMessage}>{GetLang("IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE", player.UserIDString)}</color>";
                    Parent = "SLIDER_MESSAGE_COLOR";
                    Name = "ARGUMENT_MESSAGE_COLOR";
                    break;
                case TakeElementUser.Rank:
                    Argument = TIRHWFQNPLKGITDVTYIMRADFVBHLNKKQRQODUDSIF(Info.Info.Rank) ?? GetLang("IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_NULLER", player.UserIDString);
                    Parent = "SLIDER_IQRANK";
                    Name = "ARGUMENT_RANK";
                    break;
                default:
                    break;
            }
            String Pattern = @"</?size.*?>";
            String ArgumentRegex = Regex.IsMatch(Argument, Pattern) ? Regex.Replace(Argument, Pattern, "") : Argument;
            Interface = Interface.Replace("%ARGUMENT%", ArgumentRegex);
            Interface = Interface.Replace("%PARENT%", Parent);
            Interface = Interface.Replace("%NAME%", Name);
            CuiHelper.DestroyUi(player, Name);
            CuiHelper.AddUi(player, Interface);
        }
        void AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, string[] arg)
        {
            if (MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY == null)
            {
                PrintWarning(LanguageEn ? "We generate the interface, wait for a message about successful generation" : "Генерируем интерфейс, ожидайте сообщения об успешной генерации");
                return;
            }
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg);
            if (Message == null) return;
            foreach (BasePlayer PlayerInList in BasePlayer.activePlayerList) XVTPPUQLGGAWQEFCYNXMQNCPAGOBJBTEXHCRTMTDWO(PlayerInList, Message);
        }
        [ConsoleCommand("adminalert")]
        private void TKBNQWTEQXFPCXINXYMNKEIFVNIUBCVUMLBBZQWKZYDAFHMD(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args.Args, true);
        }
        [ConsoleCommand("newui.cmd")]
        private void KWJKFMOBVSCNYCNCLDRWGOGBCNMBIANBFORGLKGYNA(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            if (player == null) return;
            String Action = arg.Args[0];
            if (Action == null || String.IsNullOrWhiteSpace(Action)) return;
            if (!LocalBase.ContainsKey(player))
            {
                PrintError(LanguageEn ? "UI was unable to process the local base (Local Base) contact the developer" : "UI не смог обработать локальную базу (LocalBase) свяжитесь с разработчиком");
                return;
            }
            Configuration.ControllerParameters ControllerParameters = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (ControllerParameters == null)
            {
                PrintError(LanguageEn ? "An error has been made in the configuration! Controller Parameters is null, contact developer" : "В конфигурации допущена ошибка! ControllerParameters является null, свяжитесь с разработчиком");
                return;
            }
            switch (Action)
            {
                case "action.mute.ignore":
                    {
                        String ActionMenu = arg.Args[1];
                        SelectedAction ActionType = (SelectedAction)Enum.Parse(typeof(SelectedAction), arg.Args[2]);
                        if (ActionMenu == "search.controller" && arg.Args.Length < 4) return;
                        switch (ActionMenu)
                        {
                            case "mute.controller":
                                {
                                    if (!player.IsAdmin)
                                        if (!permission.UserHasPermission(player.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
                                    String ActionMute = arg.Args[3];
                                    switch (ActionMute)
                                    {
                                        case "mute.all.chat":
                                            {
                                                if (GeneralInfo.TurnMuteAllChat)
                                                {
                                                    GeneralInfo.TurnMuteAllChat = false;
                                                    YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_UNMUTED_ALL_CHAT", player.UserIDString), AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE: true);
                                                }
                                                else
                                                {
                                                    GeneralInfo.TurnMuteAllChat = true;
                                                    YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_CHAT", player.UserIDString), AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE: true);
                                                }
                                                GKHFZZRGEZCPKSEPJGOCENVZICOJLTUQCQVFSAOBRUPFUSRY(player);
                                                break;
                                            }
                                        case "mute.all.voice":
                                            {
                                                if (GeneralInfo.TurnMuteAllVoice)
                                                {
                                                    GeneralInfo.TurnMuteAllVoice = false;
                                                    YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_UMMUTED_ALL_VOICE", player.UserIDString), AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE: true);
                                                }
                                                else
                                                {
                                                    GeneralInfo.TurnMuteAllVoice = true;
                                                    YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_VOICE", player.UserIDString), AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE: true);
                                                }
                                                SKZIQLTVULHXUUVYSHUAQTFVHTWVIUHLMXFBJABUVVMVAJQWZ(player);
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            case "ignore.and.mute.controller":
                                {
                                    String ActionController = arg.Args[3];
                                    BasePlayer TargetPlayer = BasePlayer.Find(arg.Args[4]);
                                    UInt64 ID = 0;
                                    UInt64.TryParse(arg.Args[4], out ID);
                                    if (TargetPlayer == null && !IsFake(ID))
                                    {
                                        CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
                                        return;
                                    }
                                    switch (ActionController)
                                    {
                                        case "confirm.alert":
                                            {
                                                if (ActionType == SelectedAction.Ignore) UIXCOQQYEDFMAEAVLIDALNYBTXYHUWRRUBIPWITJMF(player, TargetPlayer, ID);
                                                else DPEAPMGBAGHVJRTSBDPRSKOLMNXMYKIODEIZYYTIDRCVC(player, TargetPlayer, ID);
                                                break;
                                            }
                                        case "open.reason.mute":
                                            {
                                                MuteType Type = (MuteType)Enum.Parse(typeof(MuteType), arg.Args[5]);
                                                OLVYOHLRWSBTOCOTDPYTSEJTTCKHOBISJPYMRZWACLIQYFKR(player, TargetPlayer, Type, KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU: ID);
                                                break;
                                            }
                                        case "confirm.yes":
                                            {
                                                if (ActionType == SelectedAction.Ignore)
                                                {
                                                    User Info = UserInformation[player.userID];
                                                    Info.Settings.LURXCJHXVGTLXWQVXZDMELEPUDLOCMACKOJBRTNBUNNCT(IsFake(ID) ? ID : TargetPlayer.userID);
                                                    CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
                                                    MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, ActionType);
                                                }
                                                else
                                                {
                                                    MuteType Type = (MuteType)Enum.Parse(typeof(MuteType), arg.Args[5]);
                                                    Int32 IndexReason = Int32.Parse(arg.Args[6]);
                                                    KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(TargetPlayer, Type, IndexReason, player, KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU: ID);
                                                    CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
                                                    MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, ActionType);
                                                }
                                                break;
                                            }
                                        case "unmute.yes":
                                            {
                                                MuteType Type = (MuteType)Enum.Parse(typeof(MuteType), arg.Args[5]);
                                                JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(TargetPlayer, Type, player);
                                                CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
                                                MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, ActionType);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "open":
                                {
                                    UPHLOPSPENNNBBZETBFBGIYGNBJQKKAMTIEFWBPMLTXMT(player, ActionType);
                                    break;
                                }
                            case "page.controller":
                                {
                                    Int32 Page = Int32.Parse(arg.Args[3]);
                                    MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, ActionType, Page);
                                    break;
                                }
                            case "search.controller":
                                {
                                    String SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ = arg.Args[3];
                                    MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, ActionType, SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ: SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case "checkbox.controller":
                    {
                        ElementsSettingsType Type = (ElementsSettingsType)Enum.Parse(typeof(ElementsSettingsType), arg.Args[1]);
                        if (!UserInformation.ContainsKey(player.userID)) return;
                        User Info = UserInformation[player.userID];
                        if (Info == null) return;
                        switch (Type)
                        {
                            case ElementsSettingsType.PM:
                                {
                                    if (Info.Settings.TurnPM) Info.Settings.TurnPM = false;
                                    else Info.Settings.TurnPM = true;
                                    HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, Type, "226.38 -37.712", "243.125 -20.088", Info.Settings.TurnPM);
                                    break;
                                }
                            case ElementsSettingsType.Broadcast:
                                {
                                    if (Info.Settings.TurnBroadcast) Info.Settings.TurnBroadcast = false;
                                    else Info.Settings.TurnBroadcast = true;
                                    HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, Type, "226.38 -57.712", "243.125 -40.088", Info.Settings.TurnBroadcast);
                                    break;
                                }
                            case ElementsSettingsType.Alert:
                                {
                                    if (Info.Settings.TurnAlert) Info.Settings.TurnAlert = false;
                                    else Info.Settings.TurnAlert = true;
                                    HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, Type, "226.38 -77.712", "243.125 -60.088", Info.Settings.TurnAlert);
                                    break;
                                }
                            case ElementsSettingsType.Sound:
                                {
                                    if (Info.Settings.TurnSound) Info.Settings.TurnSound = false;
                                    else Info.Settings.TurnSound = true;
                                    HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(player, Type, "226.38 -97.712", "243.125 -80.088", Info.Settings.TurnSound);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case "droplist.controller":
                    {
                        String ActionDropList = arg.Args[1];
                        TakeElementUser Element = (TakeElementUser)Enum.Parse(typeof(TakeElementUser), arg.Args[2]);
                        switch (ActionDropList)
                        {
                            case "open":
                                {
                                    ZSICBLMAAWRGVKNSDAMBFNRLGXFTEQBRCKKRMRMLFQAHSMQUW(player, Element);
                                    break;
                                }
                            case "page.controller":
                                {
                                    String ActionDropListPage = arg.Args[3];
                                    Int32 Page = (Int32)Int32.Parse(arg.Args[4]);
                                    Page = ActionDropListPage == "+" ? Page + 1 : Page - 1;
                                    ZSICBLMAAWRGVKNSDAMBFNRLGXFTEQBRCKKRMRMLFQAHSMQUW(player, Element, Page);
                                    break;
                                }
                            case "element.take":
                                {
                                    Int32 Count = Int32.Parse(arg.Args[3]);
                                    String Permissions = arg.Args[4];
                                    String Argument = String.Join(" ", arg.Args.Skip(5));
                                    if (!permission.UserHasPermission(player.UserIDString, Permissions)) return;
                                    if (!UserInformation.ContainsKey(player.userID)) return;
                                    User User = UserInformation[player.userID];
                                    if (User == null) return;
                                    switch (Element)
                                    {
                                        case TakeElementUser.MultiPrefix:
                                            {
                                                if (!User.Info.PrefixList.Contains(Argument))
                                                {
                                                    User.Info.PrefixList.Add(Argument);
                                                    UOSMCEYLXJTSZFSZVMVSYSKEZNWTESKIWFXHWZOY(player, Count);
                                                }
                                                else
                                                {
                                                    User.Info.PrefixList.Remove(Argument);
                                                    CuiHelper.DestroyUi(player, $"TAKED_INFO_{Count}");
                                                }
                                                break;
                                            }
                                        case TakeElementUser.Prefix:
                                            User.Info.Prefix = User.Info.Prefix.Equals(Argument) ? String.Empty : Argument;
                                            break;
                                        case TakeElementUser.Nick:
                                            User.Info.ColorNick = Argument;
                                            break;
                                        case TakeElementUser.Chat:
                                            User.Info.ColorMessage = Argument;
                                            break;
                                        case TakeElementUser.Rank:
                                            {
                                                User.Info.Rank = Argument;
                                                QRGSHYGVVSDREJCGHPWGXAWCGGTXGJTSQPFDOQDGSBFSP(player.userID, Argument);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    TPITDOQLLZTKBZCKLMXVSYHIACJTGFZVZTPKZLDFHWT(player);
                                    break;
                                }
                        }
                        break;
                    }
                case "slider.controller":
                    {
                        TakeElementUser Element = (TakeElementUser)Enum.Parse(typeof(TakeElementUser), arg.Args[1]);
                        List<Configuration.ControllerParameters.AdvancedFuncion> SliderElements = new List<Configuration.ControllerParameters.AdvancedFuncion>();
                        User Info = UserInformation[player.userID];
                        if (Info == null) return;
                        InformationOpenedUI InfoUI = LocalBase[player];
                        if (InfoUI == null) return;
                        String ActionSlide = arg.Args[2];
                        switch (Element)
                        {
                            case TakeElementUser.Prefix:
                                {
                                    SliderElements = LocalBase[player].ElementsPrefix;
                                    if (SliderElements == null || SliderElements.Count == 0) return;
                                    if (ActionSlide == "+")
                                    {
                                        InfoUI.SlideIndexPrefix++;
                                        if (InfoUI.SlideIndexPrefix >= SliderElements.Count) InfoUI.SlideIndexPrefix = 0;
                                    }
                                    else
                                    {
                                        InfoUI.SlideIndexPrefix--;
                                        if (InfoUI.SlideIndexPrefix < 0) InfoUI.SlideIndexPrefix = SliderElements.Count - 1;
                                    }
                                    Info.Info.Prefix = SliderElements[InfoUI.SlideIndexPrefix].Argument;
                                }
                                break;
                            case TakeElementUser.Nick:
                                {
                                    SliderElements = LocalBase[player].ElementsNick;
                                    if (SliderElements == null || SliderElements.Count == 0) return;
                                    if (ActionSlide == "+")
                                    {
                                        InfoUI.SlideIndexNick++;
                                        if (InfoUI.SlideIndexNick >= SliderElements.Count) InfoUI.SlideIndexNick = 0;
                                    }
                                    else
                                    {
                                        InfoUI.SlideIndexNick--;
                                        if (InfoUI.SlideIndexNick < 0) InfoUI.SlideIndexNick = SliderElements.Count - 1;
                                    }
                                    Info.Info.ColorNick = SliderElements[InfoUI.SlideIndexNick].Argument;
                                }
                                break;
                            case TakeElementUser.Chat:
                                {
                                    SliderElements = LocalBase[player].ElementsChat;
                                    if (SliderElements == null || SliderElements.Count == 0) return;
                                    if (ActionSlide == "+")
                                    {
                                        InfoUI.SlideIndexChat++;
                                        if (InfoUI.SlideIndexChat >= SliderElements.Count) InfoUI.SlideIndexChat = 0;
                                    }
                                    else
                                    {
                                        InfoUI.SlideIndexChat--;
                                        if (InfoUI.SlideIndexChat < 0) InfoUI.SlideIndexChat = SliderElements.Count - 1;
                                    }
                                    Info.Info.ColorMessage = SliderElements[InfoUI.SlideIndexChat].Argument;
                                }
                                break;
                            case TakeElementUser.Rank:
                                {
                                    SliderElements = LocalBase[player].ElementsRanks;
                                    if (SliderElements == null || SliderElements.Count == 0) return;
                                    if (ActionSlide == "+")
                                    {
                                        InfoUI.SlideIndexRank++;
                                        if (InfoUI.SlideIndexRank >= SliderElements.Count) InfoUI.SlideIndexRank = 0;
                                    }
                                    else
                                    {
                                        InfoUI.SlideIndexRank--;
                                        if (InfoUI.SlideIndexRank < 0) InfoUI.SlideIndexRank = SliderElements.Count - 1;
                                    }
                                    Info.Info.Rank = SliderElements[InfoUI.SlideIndexRank].Argument;
                                    QRGSHYGVVSDREJCGHPWGXAWCGGTXGJTSQPFDOQDGSBFSP(player.userID, SliderElements[InfoUI.SlideIndexRank].Argument);
                                }
                                break;
                            default:
                                break;
                        }
                        ILRFYTHFALEDQMSVIDTNCTJGMTGIYJSATIMVSQYKSQSFTFBD(player, Element);
                        TPITDOQLLZTKBZCKLMXVSYHIACJTGFZVZTPKZLDFHWT(player);
                        break;
                    }
                default:
                    break;
            }
        }
        void YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(String Message, String XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH = null, String FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV = null, Boolean AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE = false)
        {
            foreach (BasePlayer p in !AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE ? BasePlayer.activePlayerList.Where(p => UserInformation[p.userID].Settings.TurnBroadcast) : BasePlayer.activePlayerList) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(p, Message, XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH, FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV);
        }
        private static Configuration config = new Configuration();
        [ChatCommand("adminalert")]
        private void IGYPVQDCPYAIITSPPLIFTICXTKHZCDKBGOWUIVPROY(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] args)
        {
            if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args, true);
        }
        private void UIXCOQQYEDFMAEAVLIDALNYBTXYHUWRRUBIPWITJMF(BasePlayer player, BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, UInt64 KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU = 0)
        {
            String InterfacePanel = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Alert_Panel");
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Ignore_Alert");
            if (Interface == null || InterfacePanel == null) return;
            GeneralInformation.RenameInfo GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ = (IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? null : GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID);
            String NickNamed = (IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? FindFakeName(KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU) : GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ != null ? $"{GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.RenameNick ?? JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName}" : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName;
            Interface = Interface.Replace("%TITLE%", GetLang(UserInformation[player.userID].Settings.IsIgnored((IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID) ? "IQCHAT_TITLE_IGNORE_TITLES_UNLOCK" : "IQCHAT_TITLE_IGNORE_TITLES", player.UserIDString, NickNamed));
            Interface = Interface.Replace("%BUTTON_YES%", GetLang("IQCHAT_TITLE_IGNORE_BUTTON_YES", player.UserIDString));
            Interface = Interface.Replace("%BUTTON_NO%", GetLang("IQCHAT_TITLE_IGNORE_BUTTON_NO", player.UserIDString));
            Interface = Interface.Replace("%COMMAND%", $"newui.cmd action.mute.ignore ignore.and.mute.controller {SelectedAction.Ignore} confirm.yes {((IQFakeActive && JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI == null && KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU != 0) ? KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID)}");
            CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
            CuiHelper.AddUi(player, InterfacePanel);
            CuiHelper.AddUi(player, Interface);
        }
        public Dictionary<UInt64, AntiNoob> UserInformationConnection = new Dictionary<UInt64, AntiNoob>();
        private String YBBVPHZEIKYVGKVIRSIEIMNSZWLZCPUOFHAARBIZUR(BasePlayer player, Int32 Count)
        {
            String Messages = String.Empty;
            if (LastMessagesChat.ContainsKey(player))
            {
                foreach (String Message in LastMessagesChat[player].Skip(LastMessagesChat[player].Count - Count)) Messages += $"\n{Message}";
            }
            return Messages;
        }
        private void HWFBFAZBRDBWLNJWTVABTPKQYJVRPJJKQDGWTVGZDND(BasePlayer player, ElementsSettingsType Type, String OffsetMin, String OffsetMax, Boolean StatusCheckBox)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Context_CheckBox");
            User Info = UserInformation[player.userID];
            if (Info == null || Interface == null) return;
            String Name = $"{Type}";
            Interface = Interface.Replace("%NAME_CHECK_BOX%", Name);
            Interface = Interface.Replace("%COLOR%", !StatusCheckBox ? "0.4716981 0.4716981 0.4716981 1" : "0.6040971 0.4198113 1 1");
            Interface = Interface.Replace("%OFFSET_MIN%", OffsetMin);
            Interface = Interface.Replace("%OFFSET_MAX%", OffsetMax);
            Interface = Interface.Replace("%COMMAND_TURNED%", $"newui.cmd checkbox.controller {Type}");
            CuiHelper.DestroyUi(player, Name);
            CuiHelper.AddUi(player, Interface);
        }
        object OnPlayerVoice(BasePlayer player, Byte[] data)
        {
            if (UserInformation[player.userID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice)) return false;
            return null;
        }
        [ConsoleCommand("saybro")]
        private void DKONHFOETQPRLPCVEIMHTRGHGNDYPBYFMZMOUIJKUFQA(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            if (args.Args == null || args.Args.Length == 0)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "You didn't specify a player!" : "Вы не указали игрока!");
                else PrintWarning(LanguageEn ? "You didn't specify a player" : "Вы не указали игрока!");
                return;
            }
            BasePlayer Recipient = BasePlayer.Find(args.Args[0]);
            if (Recipient == null)
            {
                if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "The player is not on the server!" : "Игрока нет на сервере!");
                else PrintWarning(LanguageEn ? "The player is not on the server!" : "Игрока нет на сервере!");
                return;
            }
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, Recipient, args.Args.Skip(1).ToArray());
        }
        class Response
        {
            [JsonProperty("country")]
            public string Country
            {
                get;
                set;
            }
        }
        [ConsoleCommand("online")]
        private void OKDSKUVBVRMEHGUCQOSSJFMDOBWYCMOBFSRDZFEGDEQIA(ConsoleSystem.Arg arg)
        {
            BasePlayer player = arg.Player();
            List<String> PlayerNames = YBRHHVDJORRKFWWPOOXDKFRJQNFOXFGLQUGZPUSBDADHSBK();
            String Message = GetLang("IQCHAT_INFO_ONLINE", player != null ? player.UserIDString : null, String.Join($"\n", PlayerNames));
            if (player != null) player.ConsoleMessage(Message);
            else
            {
                String Pattern = @"</?size.*?>|</?color.*?>";
                String Messages = Regex.IsMatch(Message, Pattern) ? Regex.Replace(Message, Pattern, "") : Message;
                Puts(Messages);
            }
        }
        Boolean NBPIEQYIFJXAEJYWYJCLZOOQCLKLPFOEDEOUJUIYCXN(UInt64 UserHas, UInt64 User)
        {
            if (!UserInformation.ContainsKey(UserHas)) return false;
            if (!UserInformation.ContainsKey(User)) return false;
            return UserInformation[UserHas].Settings.IsIgnored(User);
        }
        private bool OnPlayerChat(BasePlayer player, string message, Chat.ChatChannel channel)
        {
            if (Interface.Oxide.CallHook("CanChatMessage", player, message) != null) return false;
            XKXHLRTOIWWLIVKFMMTWZWIRNKKXQEQLQUOJXIRYBQKES(channel, player, message);
            return false;
        }
        private new void LoadDefaultMessages()
        {
            PrintWarning(LanguageEn ? "Language file is loading..." : "Языковой файл загружается...");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["FUNC_MESSAGE_MUTE_CHAT"] = "{0} muted {1}\nDuration : {2}\nReason : {3}",
                ["FUNC_MESSAGE_UNMUTE_CHAT"] = "{0} unmuted {1}",
                ["FUNC_MESSAGE_MUTE_VOICE"] = "{0} muted voice to {1}\nDuration : {2}\nReason : {3}",
                ["FUNC_MESSAGE_UNMUTE_VOICE"] = "{0} unmuted voice to {1}",
                ["FUNC_MESSAGE_MUTE_ALL_CHAT"] = "Chat disabled",
                ["FUNC_MESSAGE_UNMUTE_ALL_CHAT"] = "Chat enabled",
                ["FUNC_MESSAGE_MUTE_ALL_VOICE"] = "Voice chat disabled",
                ["FUNC_MESSAGE_UNMUTE_ALL_VOICE"] = "Voice chat enabled",
                ["FUNC_MESSAGE_MUTE_ALL_ALERT"] = "Blocking by Administrator",
                ["FUNC_MESSAGE_PM_TURN_FALSE"] = "The player has forbidden to send himself private messages",
                ["FUNC_MESSAGE_ALERT_TURN_FALSE"] = "The player has not been allowed to notify himself",
                ["FUNC_MESSAGE_NO_ARG_BROADCAST"] = "You can not send an empty broadcast message!",
                ["UI_ALERT_TITLE"] = "<size=14><b>Notification</b></size>",
                ["COMMAND_NOT_PERMISSION"] = "You dont have permissions to use this command",
                ["COMMAND_RENAME_NOTARG"] = "For rename use : /rename [NewNickname] [NewID (Optional)]",
                ["COMMAND_RENAME_NOT_ID"] = "Incorrect ID for renaming! Use Steam64ID or leave blank",
                ["COMMAND_RENAME_SUCCES"] = "You have successfully changed your nickname!\nyour nickname : {0}\nYour ID : {1}",
                ["COMMAND_PM_NOTARG"] = "To send pm use : /pm Nickname Message",
                ["COMMAND_PM_NOT_NULL_MSG"] = "Message is empty!",
                ["COMMAND_PM_NOT_USER"] = "User not found or offline",
                ["COMMAND_PM_SUCCESS"] = "Your private message sent successful\nMessage : {0}\nDelivered : {1}",
                ["COMMAND_PM_SEND_MSG"] = "Message from {0}\n{1}",
                ["COMMAND_R_NOTARG"] = "For reply use : /r Message",
                ["COMMAND_R_NOTMSG"] = "You dont have any private conversations yet!",
                ["FLOODERS_MESSAGE"] = "You're typing too fast! Please Wait {0} seconds",
                ["PREFIX_SETUP"] = "You have successfully removed the prefix {0}, it is already activated and installed",
                ["COLOR_CHAT_SETUP"] = "You have successfully picked up the <color={0}>chat color</color>, it is already activated and installed",
                ["COLOR_NICK_SETUP"] = "You have successfully taken the <color={0}>nickname color</color>, it is already activated and installed",
                ["PREFIX_RETURNRED"] = "Your prefix {0} expired, it was reset automatically",
                ["COLOR_CHAT_RETURNRED"] = "Action of your <color={0}>color chat</color> over, it is reset automatically",
                ["COLOR_NICK_RETURNRED"] = "Action of your <color={0}>color nick</color> over, it is reset automatically",
                ["WELCOME_PLAYER"] = "{0} came online",
                ["LEAVE_PLAYER"] = "{0} left",
                ["WELCOME_PLAYER_WORLD"] = "{0} came online. Country: {1}",
                ["LEAVE_PLAYER_REASON"] = "{0} left. Reason: {1}",
                ["IGNORE_ON_PLAYER"] = "You added {0} in black list",
                ["IGNORE_OFF_PLAYER"] = "You removed {0} from black list",
                ["IGNORE_NO_PM"] = "This player added you in black list. Your message has not been delivered.",
                ["IGNORE_NO_PM_ME"] = "You added this player in black list. Your message has not been delivered.",
                ["INGORE_NOTARG"] = "To ignore a player use : /ignore nickname",
                ["DISCORD_SEND_LOG_CHAT"] = "Player : {0}({1})\nFiltred message : {2}\nMessage : {3}",
                ["DISCORD_SEND_LOG_MUTE"] = "{0}({1}) give mute chat\nSuspect : {2}({3})\nReason : {4}",
                ["TITLE_FORMAT_DAYS"] = "D",
                ["TITLE_FORMAT_HOURSE"] = "H",
                ["TITLE_FORMAT_MINUTES"] = "M",
                ["TITLE_FORMAT_SECONDS"] = "S",
                ["IQCHAT_CONTEXT_TITLE"] = "SETTING UP A CHAT",
                ["IQCHAT_CONTEXT_SETTING_ELEMENT_TITLE"] = "CUSTOM SETTING",
                ["IQCHAT_CONTEXT_INFORMATION_TITLE"] = "INFORMATION",
                ["IQCHAT_CONTEXT_SETTINGS_TITLE"] = "SETTINGS",
                ["IQCHAT_CONTEXT_SETTINGS_PM_TITLE"] = "Private messages",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_TITLE"] = "Notification in the chat",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_PM_TITLE"] = "Mention in the chat",
                ["IQCHAT_CONTEXT_SETTINGS_SOUNDS_TITLE"] = "Sound notification",
                ["IQCHAT_CONTEXT_MUTE_STATUS_NOT"] = "NO",
                ["IQCHAT_CONTEXT_MUTE_STATUS_TITLE"] = "Blocking the chat",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_COUNT"] = "<size=18>{0}</size> human (а)",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_TITLE"] = "Ignoring",
                ["IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE"] = "text",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE"] = "Prefix",
                ["IQCHAT_CONTEXT_SLIDER_NICK_COLOR_TITLE"] = "Nick",
                ["IQCHAT_CONTEXT_SLIDER_MESSAGE_COLOR_TITLE"] = "Message",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE"] = "Rank",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_NULLER"] = "Absent",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE_DESCRIPTION"] = "Choosing a prefix",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_NICK_TITLE_DESCRIPTION"] = "Choosing a nickname color",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_MESSAGE_TITLE_DESCRIPTION"] = "Chat Color Selection",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_DESCRIPTION"] = "Rank Selection",
                ["IQCHAT_CONTEXT_DESCRIPTION_PREFIX"] = "Prefix Setting",
                ["IQCHAT_CONTEXT_DESCRIPTION_NICK"] = "Setting up a nickname",
                ["IQCHAT_CONTEXT_DESCRIPTION_CHAT"] = "Setting up a message",
                ["IQCHAT_CONTEXT_DESCRIPTION_RANK"] = "Setting up the rank",
                ["IQCHAT_ALERT_TITLE"] = "ALERT",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_MUTED"] = "LOCK MANAGEMENT",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_IGNORED"] = "IGNORING MANAGEMENT",
                ["IQCHAT_TITLE_IGNORE_TITLES"] = "<b>DO YOU REALLY WANT TO IGNORE\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_TITLES_UNLOCK"] = "<b>DO YOU WANT TO REMOVE THE IGNORING FROM THE PLAYER\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_YES"] = "<b>YES, I WANT TO</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_NO"] = "<b>NO, I CHANGED MY MIND</b>",
                ["IQCHAT_TITLE_MODERATION_PANEL"] = "MODERATOR PANEL",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU"] = "Lock Management",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT"] = "SELECT AN ACTION",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_REASON"] = "SELECT THE REASON FOR BLOCKING",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_CHAT"] = "Block chat",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_VOICE"] = "Block voice",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_CHAT"] = "Unblock chat",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_VOICE"] = "Unlock voice",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_CHAT"] = "Block all chat",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_CHAT"] = "Unblock all chat",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_VOICE"] = "Block everyone's voice",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_VOICE"] = "Unlock everyone's voice",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED"] = "You have an active chat lock : {0}",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_CHAT"] = "The administrator blocked everyone's chat. Expect full unblocking",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_VOICE"] = "The administrator blocked everyone's voice chat. Expect full unblocking",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UMMUTED_ALL_VOICE"] = "The administrator has unblocked the voice chat for everyone",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UNMUTED_ALL_CHAT"] = "The administrator has unblocked the chat for everyone",
                ["IQCHAT_FUNCED_ALERT_TITLE"] = "<color=#a7f64f><b>[MENTION]</b></color>",
                ["IQCHAT_FUNCED_ALERT_TITLE_ISMUTED"] = "The player has already been muted!",
                ["IQCHAT_FUNCED_ALERT_TITLE_SERVER"] = "Administrator",
                ["IQCHAT_INFO_ONLINE"] = "Now on the server :\n{0}",
                ["IQCHAT_INFO_ANTI_NOOB"] = "You first connected to the server!\nPlay some more {0}\nTo get access to send messages to the global and team chat!",
                ["IQCHAT_INFO_ANTI_NOOB_PM"] = "You first connected to the server!\nPlay some more {0}\nTo access sending messages to private messages!",
                ["XLEVELS_SYNTAX_PREFIX"] = "[{0} Level]",
                ["CLANS_SYNTAX_PREFIX"] = "[{0}]",
            }, this);
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["FUNC_MESSAGE_MUTE_CHAT"] = "{0} заблокировал чат игроку {1}\nДлительность : {2}\nПричина : {3}",
                ["FUNC_MESSAGE_UNMUTE_CHAT"] = "{0} разблокировал чат игроку {1}",
                ["FUNC_MESSAGE_MUTE_VOICE"] = "{0} заблокировал голос игроку {1}\nДлительность : {2}\nПричина : {3}",
                ["FUNC_MESSAGE_UNMUTE_VOICE"] = "{0} разблокировал голос игроку {1}",
                ["FUNC_MESSAGE_MUTE_ALL_CHAT"] = "Всем игрокам был заблокирован чат",
                ["FUNC_MESSAGE_UNMUTE_ALL_CHAT"] = "Всем игрокам был разблокирован чат",
                ["FUNC_MESSAGE_MUTE_ALL_VOICE"] = "Всем игрокам был заблокирован голос",
                ["FUNC_MESSAGE_MUTE_ALL_ALERT"] = "Блокировка Администратором",
                ["FUNC_MESSAGE_UNMUTE_ALL_VOICE"] = "Всем игрокам был разблокирован голос",
                ["FUNC_MESSAGE_PM_TURN_FALSE"] = "Игрок запретил присылать себе личные сообщения",
                ["FUNC_MESSAGE_ALERT_TURN_FALSE"] = "Игрок запретил уведомлять себя",
                ["FUNC_MESSAGE_NO_ARG_BROADCAST"] = "Вы не можете отправлять пустое сообщение в оповещение!",
                ["UI_ALERT_TITLE"] = "<size=14><b>Уведомление</b></size>",
                ["COMMAND_NOT_PERMISSION"] = "У вас недостаточно прав для данной команды",
                ["COMMAND_RENAME_NOTARG"] = "Используйте команду так : /rename [НовыйНик] [НовыйID (По желанию)]",
                ["COMMAND_RENAME_NOT_ID"] = "Неверно указан ID для переименования! Используйте Steam64ID, либо оставьте поле пустым",
                ["COMMAND_RENAME_SUCCES"] = "Вы успешно изменили ник!\nВаш ник : {0}\nВаш ID : {1}",
                ["COMMAND_PM_NOTARG"] = "Используйте команду так : /pm Ник Игрока Сообщение",
                ["COMMAND_PM_NOT_NULL_MSG"] = "Вы не можете отправлять пустое сообщение",
                ["COMMAND_PM_NOT_USER"] = "Игрок не найден или не в сети",
                ["COMMAND_PM_SUCCESS"] = "Ваше сообщение успешно доставлено\nСообщение : {0}\nДоставлено : {1}",
                ["COMMAND_PM_SEND_MSG"] = "Сообщение от {0}\n{1}",
                ["COMMAND_R_NOTARG"] = "Используйте команду так : /r Сообщение",
                ["COMMAND_R_NOTMSG"] = "Вам или вы ещё не писали игроку в личные сообщения!",
                ["FLOODERS_MESSAGE"] = "Вы пишите слишком быстро! Подождите {0} секунд",
                ["PREFIX_SETUP"] = "Вы успешно забрали префикс {0}, он уже активирован и установлен",
                ["COLOR_CHAT_SETUP"] = "Вы успешно забрали <color={0}>цвет чата</color>, он уже активирован и установлен",
                ["COLOR_NICK_SETUP"] = "Вы успешно забрали <color={0}>цвет ника</color>, он уже активирован и установлен",
                ["PREFIX_RETURNRED"] = "Действие вашего префикса {0} окончено, он сброшен автоматически",
                ["COLOR_CHAT_RETURNRED"] = "Действие вашего <color={0}>цвета чата</color> окончено, он сброшен автоматически",
                ["COLOR_NICK_RETURNRED"] = "Действие вашего <color={0}>цвет ника</color> окончено, он сброшен автоматически",
                ["WELCOME_PLAYER"] = "{0} зашел на сервер",
                ["LEAVE_PLAYER"] = "{0} вышел с сервера",
                ["WELCOME_PLAYER_WORLD"] = "{0} зашел на сервер.Из {1}",
                ["LEAVE_PLAYER_REASON"] = "{0} вышел с сервера.Причина {1}",
                ["IGNORE_ON_PLAYER"] = "Вы добавили игрока {0} в черный список",
                ["IGNORE_OFF_PLAYER"] = "Вы убрали игрока {0} из черного списка",
                ["IGNORE_NO_PM"] = "Данный игрок добавил вас в ЧС,ваше сообщение не будет доставлено",
                ["IGNORE_NO_PM_ME"] = "Вы добавили данного игрока в ЧС,ваше сообщение не будет доставлено",
                ["INGORE_NOTARG"] = "Используйте команду так : /ignore Ник Игрока",
                ["DISCORD_SEND_LOG_CHAT"] = "Игрок : {0}({1})\nФильтрованное сообщение : {2}\nИзначальное сообщение : {3}",
                ["DISCORD_SEND_LOG_MUTE"] = "{0}({1}) выдал блокировку чата\nИгрок : {2}({3})\nПричина : {4}",
                ["TITLE_FORMAT_DAYS"] = "Д",
                ["TITLE_FORMAT_HOURSE"] = "Ч",
                ["TITLE_FORMAT_MINUTES"] = "М",
                ["TITLE_FORMAT_SECONDS"] = "С",
                ["IQCHAT_CONTEXT_TITLE"] = "НАСТРОЙКА ЧАТА",
                ["IQCHAT_CONTEXT_SETTING_ELEMENT_TITLE"] = "ПОЛЬЗОВАТЕЛЬСКАЯ НАСТРОЙКА",
                ["IQCHAT_CONTEXT_INFORMATION_TITLE"] = "ИНФОРМАЦИЯ",
                ["IQCHAT_CONTEXT_SETTINGS_TITLE"] = "НАСТРОЙКИ",
                ["IQCHAT_CONTEXT_SETTINGS_PM_TITLE"] = "Личные сообщения",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_TITLE"] = "Оповещение в чате",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_PM_TITLE"] = "Упоминание в чате",
                ["IQCHAT_CONTEXT_SETTINGS_SOUNDS_TITLE"] = "Звуковое оповещение",
                ["IQCHAT_CONTEXT_MUTE_STATUS_NOT"] = "НЕТ",
                ["IQCHAT_CONTEXT_MUTE_STATUS_TITLE"] = "Блокировка чата",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_COUNT"] = "<size=18>{0}</size> человек (а)",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_TITLE"] = "Игнорирование",
                ["IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE"] = "текст",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE"] = "Префикс",
                ["IQCHAT_CONTEXT_SLIDER_NICK_COLOR_TITLE"] = "Ник",
                ["IQCHAT_CONTEXT_SLIDER_MESSAGE_COLOR_TITLE"] = "Чат",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE"] = "Ранг",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_NULLER"] = "Отсутствует",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE_DESCRIPTION"] = "Выбор префикса",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_NICK_TITLE_DESCRIPTION"] = "Выбор цвета ника",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_MESSAGE_TITLE_DESCRIPTION"] = "Выбор цвета чата",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_DESCRIPTION"] = "Выбор ранга",
                ["IQCHAT_CONTEXT_DESCRIPTION_PREFIX"] = "Настройка префикса",
                ["IQCHAT_CONTEXT_DESCRIPTION_NICK"] = "Настройка ника",
                ["IQCHAT_CONTEXT_DESCRIPTION_CHAT"] = "Настройка сообщения",
                ["IQCHAT_CONTEXT_DESCRIPTION_RANK"] = "Настройка ранга",
                ["IQCHAT_ALERT_TITLE"] = "УВЕДОМЛЕНИЕ",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_MUTED"] = "УПРАВЛЕНИЕ БЛОКИРОВКАМИ",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_IGNORED"] = "УПРАВЛЕНИЕ ИГНОРИРОВАНИЕМ",
                ["IQCHAT_TITLE_IGNORE_TITLES"] = "<b>ВЫ ДЕЙСТВИТЕЛЬНО ХОТИТЕ ИГНОРИРОВАТЬ\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_TITLES_UNLOCK"] = "<b>ВЫ ХОТИТЕ СНЯТЬ ИГНОРИРОВАНИЕ С ИГРОКА\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_YES"] = "<b>ДА, ХОЧУ</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_NO"] = "<b>НЕТ, ПЕРЕДУМАЛ</b>",
                ["IQCHAT_TITLE_MODERATION_PANEL"] = "ПАНЕЛЬ МОДЕРАТОРА",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU"] = "Управление блокировками",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT"] = "ВЫБЕРИТЕ ДЕЙСТВИЕ",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_REASON"] = "ВЫБЕРИТЕ ПРИЧИНУ БЛОКИРОВКИ",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_CHAT"] = "Заблокировать чат",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_VOICE"] = "Заблокировать голос",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_CHAT"] = "Разблокировать чат",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_VOICE"] = "Разблокировать голос",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_CHAT"] = "Заблокировать всем чат",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_CHAT"] = "Разблокировать всем чат",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_VOICE"] = "Заблокировать всем голос",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_VOICE"] = "Разблокировать всем голос",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED"] = "У вас имеется активная блокировка чата : {0}",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_CHAT"] = "Администратор заблокировал всем чат. Ожидайте полной разблокировки",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_VOICE"] = "Администратор заблокировал всем голосоввой чат. Ожидайте полной разблокировки",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UMMUTED_ALL_VOICE"] = "Администратор разрблокировал всем голосоввой чат",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UNMUTED_ALL_CHAT"] = "Администратор разрблокировал всем чат",
                ["IQCHAT_FUNCED_ALERT_TITLE"] = "<color=#a7f64f><b>[УПОМИНАНИЕ]</b></color>",
                ["IQCHAT_FUNCED_ALERT_TITLE_ISMUTED"] = "Игрок уже был замучен!",
                ["IQCHAT_FUNCED_ALERT_TITLE_SERVER"] = "Администратор",
                ["IQCHAT_INFO_ONLINE"] = "Сейчас на сервере :\n{0}",
                ["IQCHAT_INFO_ANTI_NOOB"] = "Вы впервые подключились на сервер!\nОтыграйте еще {0}\nЧтобы получить доступ к отправке сообщений в глобальный и командный чат!",
                ["IQCHAT_INFO_ANTI_NOOB_PM"] = "Вы впервые подключились на сервер!\nОтыграйте еще {0}\nЧтобы получить доступ к отправке сообщений в личные сообщения!",
                ["XLEVELS_SYNTAX_PREFIX"] = "[{0} Level]",
                ["CLANS_SYNTAX_PREFIX"] = "[{0}]",
            }, this, "ru");
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["FUNC_MESSAGE_MUTE_CHAT"] = "{0} silenciado {1}\n Duracion: {2}\nRazon: {3}",
                ["FUNC_MESSAGE_UNMUTE_CHAT"] = "{0} sin silenciar {1}",
                ["FUNC_MESSAGE_MUTE_VOICE"] = "{0} voz apagada a {1}\n Duracion : {2}\n Razon : {3}",
                ["FUNC_MESSAGE_UNMUTE_VOICE"] = "{0} voz no silenciada a {1}",
                ["FUNC_MESSAGE_MUTE_ALL_CHAT"] = "Chat desactivado",
                ["FUNC_MESSAGE_UNMUTE_ALL_CHAT"] = "Chat habilitado",
                ["FUNC_MESSAGE_MUTE_ALL_VOICE"] = "Chat de voz desactivado",
                ["FUNC_MESSAGE_UNMUTE_ALL_VOICE"] = "Chat de voz habilitado",
                ["FUNC_MESSAGE_MUTE_ALL_ALERT"] = "Bloqueo por parte del administrador",
                ["FUNC_MESSAGE_PM_TURN_FALSE"] = "El jugador tiene prohibido enviarse mensajes privados",
                ["FUNC_MESSAGE_ALERT_TURN_FALSE"] = "El jugador no ha podido notificarse a si mismo",
                ["FUNC_MESSAGE_NO_ARG_BROADCAST"] = "No se puede enviar un mensaje vacio.",
                ["UI_ALERT_TITLE"] = "<size=14><b>Notificacion</b></size>",
                ["COMMAND_NOT_PERMISSION"] = "No tienes permisos para usar este comando",
                ["COMMAND_RENAME_NOTARG"] = "Para renombrar utilice : /rename [NewNickname] [NewID (Optional)]",
                ["COMMAND_RENAME_NOT_ID"] = "?ID incorrecto para renombrar! Utilice Steam64ID o dejelo en blanco",
                ["COMMAND_RENAME_SUCCES"] = "Has cambiado con exito tu nombre de usuario. \n Tu nombre de usuario: {0}. \nTu ID: {1}.",
                ["COMMAND_PM_NOTARG"] = "Para enviar pm utilice : /pm [Nombre] [Mensaje]",
                ["COMMAND_PM_NOT_NULL_MSG"] = "?El mensaje esta vacio!",
                ["COMMAND_PM_NOT_USER"] = "Usuario no encontrado o desconectado",
                ["COMMAND_PM_SUCCESS"] = "Su mensaje privado enviado con exito \n Mensage : {0}\n : Entregado{1}",
                ["COMMAND_PM_SEND_MSG"] = "Mensaje de {0}\n{1}",
                ["COMMAND_R_NOTARG"] = "Para responder utilice : /r Mensaje",
                ["COMMAND_R_NOTMSG"] = "Todavia no tienes ninguna conversacion privada.",
                ["FLOODERS_MESSAGE"] = "?Estas escribiendo demasiado rapido! Por favor, espere {0} segundos",
                ["PREFIX_SETUP"] = "Has eliminado con exito el prefijo {0}.",
                ["COLOR_CHAT_SETUP"] = "Has obtenido un nuevo color en el chat",
                ["COLOR_NICK_SETUP"] = "Has cambiado tu nick correctamente del chat",
                ["PREFIX_RETURNRED"] = "Su prefijo {0} ha caducado, se ha restablecido automaticamente",
                ["COLOR_CHAT_RETURNRED"] = "Accion de su <color={0}>color de chat</color> mas, se restablece automaticamente",
                ["COLOR_NICK_RETURNRED"] = "Accion de su <color={0}>color nick</color> sobre, se restablece automaticamente",
                ["WELCOME_PLAYER"] = "{0} Se ha conectado",
                ["LEAVE_PLAYER"] = "{0} izquierda",
                ["WELCOME_PLAYER_WORLD"] = "{0} Se ha conectado del Pais: {1}",
                ["LEAVE_PLAYER_REASON"] = "{0} Se ha desconectado. Razon: {1}",
                ["IGNORE_ON_PLAYER"] = "Has anadido {0} en la lista negra",
                ["IGNORE_OFF_PLAYER"] = "Has eliminado el jugador {0} de la lista negra",
                ["IGNORE_NO_PM"] = "Este jugador te ha anadido a la lista negra. Su mensaje no ha sido entregado.",
                ["IGNORE_NO_PM_ME"] = "Has anadido a este jugador en la lista negra. Su mensaje no ha sido entregado.",
                ["INGORE_NOTARG"] = "Para ignorar a un jugador utiliza : /ignore nickname",
                ["DISCORD_SEND_LOG_CHAT"] = "JUgador : {0}({1})\nMensaje filtrado : {2}\nMensages : {3}",
                ["DISCORD_SEND_LOG_MUTE"] = "{0}({1}) give mute chat\nSuspect : {2}({3})\nReason : {4}",
                ["TITLE_FORMAT_DAYS"] = "D",
                ["TITLE_FORMAT_HOURSE"] = "H",
                ["TITLE_FORMAT_MINUTES"] = "M",
                ["TITLE_FORMAT_SECONDS"] = "S",
                ["IQCHAT_CONTEXT_TITLE"] = "ESTABLECER UN CHAT",
                ["IQCHAT_CONTEXT_SETTING_ELEMENT_TITLE"] = "AJUSTE PERSONALIZADO",
                ["IQCHAT_CONTEXT_INFORMATION_TITLE"] = "INFORMACION",
                ["IQCHAT_CONTEXT_SETTINGS_TITLE"] = "AJUSTES",
                ["IQCHAT_CONTEXT_SETTINGS_PM_TITLE"] = "Mensajes privados",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_TITLE"] = "Notificacion en el chat",
                ["IQCHAT_CONTEXT_SETTINGS_ALERT_PM_TITLE"] = "Mencion en el chat",
                ["IQCHAT_CONTEXT_SETTINGS_SOUNDS_TITLE"] = "Notificacion sonora",
                ["IQCHAT_CONTEXT_MUTE_STATUS_NOT"] = "NO",
                ["IQCHAT_CONTEXT_MUTE_STATUS_TITLE"] = "Bloqueo del chat",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_COUNT"] = "<size=11>{0}</size> humano (а)",
                ["IQCHAT_CONTEXT_IGNORED_STATUS_TITLE"] = "Ignorando",
                ["IQCHAT_CONTEXT_NICK_DISPLAY_TITLE"] = "Su apodo",
                ["IQCHAT_CONTEXT_NICK_DISPLAY_MESSAGE"] = "Me encanta Zoxiland",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE"] = "Prefijo",
                ["IQCHAT_CONTEXT_SLIDER_NICK_COLOR_TITLE"] = "Nick",
                ["IQCHAT_CONTEXT_SLIDER_MESSAGE_COLOR_TITLE"] = "Mensaje",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE"] = "Rango",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_NULLER"] = "Ausente",
                ["IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE_DESCRIPTION"] = "Elegir un prefijo",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_NICK_TITLE_DESCRIPTION"] = "Elegir un color de apodo",
                ["IQCHAT_CONTEXT_SLIDER_CHAT_MESSAGE_TITLE_DESCRIPTION"] = "Seleccion del color del chat",
                ["IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE_DESCRIPTION"] = "Seleccion de rangos",
                ["IQCHAT_CONTEXT_DESCRIPTION_PREFIX"] = "Ajuste del prefijo",
                ["IQCHAT_CONTEXT_DESCRIPTION_NICK"] = "Configurar un apodo",
                ["IQCHAT_CONTEXT_DESCRIPTION_CHAT"] = "Configurar un mensaje",
                ["IQCHAT_CONTEXT_DESCRIPTION_RANK"] = "Establecimiento del rango",
                ["IQCHAT_ALERT_TITLE"] = "ALERTA",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_MUTED"] = "GESTION MUTEADOS",
                ["IQCHAT_TITLE_IGNORE_AND_MUTE_IGNORED"] = "GESTION IGNORE",
                ["IQCHAT_TITLE_IGNORE_TITLES"] = "<b>?REALMENTE QUIERES IGNORAR\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_TITLES_UNLOCK"] = "<b>?QUIERES QUITARLE AL JUGADOR LO DE IGNORAR?\n{0}?</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_YES"] = "<b>SI, QUIERO</b>",
                ["IQCHAT_TITLE_IGNORE_BUTTON_NO"] = "<b>NO, HE CAMBIADO DE OPINION</b>",
                ["IQCHAT_TITLE_MODERATION_PANEL"] = "PANEL DE MODERADORES",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU"] = "Menu de muteados",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT"] = "SELECCIONE UNA ACCION",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_REASON"] = "SELECCIONE EL MOTIVO DEL BLOQUEO",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_CHAT"] = "Bloquear el Chat",
                ["IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_VOICE"] = "Bloquear Voz",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_CHAT"] = "Desbloquear Chat",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_MENU_TITLE_ALERT_VOICE"] = "Desbloquear Voz",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_CHAT"] = "Bloquear todos los chats",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_CHAT"] = "Desbloquear todo el chat",
                ["IQCHAT_BUTTON_MODERATION_MUTE_ALL_VOICE"] = "Bloquear la voz de todos",
                ["IQCHAT_BUTTON_MODERATION_UNMUTE_ALL_VOICE"] = "Desbloquear la voz de todos",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED"] = "Tienes un bloqueo de chat activo : {0}",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_CHAT"] = "El administrador ha bloqueado el chat. Espera el desbloqueo completo",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_MUTED_ALL_VOICE"] = "El administrador ha bloqueado el chat de voz. Espera el desbloqueo completo",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UMMUTED_ALL_VOICE"] = "El administrador ha desbloqueado el chat de voz.",
                ["IQCHAT_FUNCED_NO_SEND_CHAT_UNMUTED_ALL_CHAT"] = "El administrador ha desbloqueado el chat",
                ["IQCHAT_FUNCED_ALERT_TITLE"] = "<color=#a7f64f><b>[MENCION]</b></color>",
                ["IQCHAT_FUNCED_ALERT_TITLE_ISMUTED"] = "El jugador ya ha sido silenciado.",
                ["IQCHAT_FUNCED_ALERT_TITLE_SERVER"] = "Administrador",
                ["IQCHAT_INFO_ONLINE"] = "Now on the server :\n{0}",
                ["IQCHAT_INFO_ANTI_NOOB"] = "Tienes que jugar un poco mas para poder hablar por el chat {0}.",
                ["IQCHAT_INFO_ANTI_NOOB_PM"] = "No puedes enviar un privado por que es un jugador nuevo.",
                ["XLEVELS_SYNTAX_PREFIX"] = "[{0} Level]",
                ["CLANS_SYNTAX_PREFIX"] = "[{0}]",
            }, this, "es-ES");
            PrintWarning(LanguageEn ? "Language file uploaded successfully" : "Языковой файл загружен успешно");
        }
        public Dictionary<BasePlayer, BasePlayer> PMHistory = new Dictionary<BasePlayer, BasePlayer>();
        private
        const String PermissionHideOnline = "iqchat.onlinehide";
        [ChatCommand("r")]
        void GYAVIGFHFOJYMYFTFNTAUSXZVDMEBEIBAGKDKPCIZHY(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, string cmd, string[] arg)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            if (!ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ.LCAQTFAVHYWZPVROWXDBTHSXBWFECQHIMCZEBUTALSPFMPS) return;
            if (arg.Length == 0 || arg == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_R_NOTARG", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            Configuration.ControllerMessage.TurnedFuncional.AntiNoob.Settings YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM = config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS;
            if (YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP)
                if (OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID, YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IQCHAT_INFO_ANTI_NOOB_PM", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, FormatTime(UserInformationConnection[XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID].EWEIMARKILVKEQRGSEHECRZMFNKKCXNUEEPLGUJWFRBQVX(YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI), XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString)));
                    return;
                }
            if (!PMHistory.ContainsKey(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_R_NOTMSG", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            BasePlayer RetargetUser = PMHistory[XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY];
            if (RetargetUser == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_NOT_USER", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            User InfoRetarget = UserInformation[RetargetUser.userID];
            User InfoSender = UserInformation[RetargetUser.userID];
            if (!InfoRetarget.Settings.TurnPM)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("FUNC_MESSAGE_PM_TURN_FALSE", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            if (ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW)
            {
                if (InfoRetarget.Settings.IsIgnored(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IGNORE_NO_PM", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                    return;
                }
                if (InfoSender.Settings.IsIgnored(RetargetUser.userID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IGNORE_NO_PM_ME", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                    return;
                }
            }
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg);
            if (Message == null || Message.Length <= 0)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_NOT_NULL_MSG", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            if (Message.Length > 125) return;
            Message = Message.EscapeRichText();
            PMHistory[RetargetUser] = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY;
            GeneralInformation.RenameInfo RenameSender = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID);
            GeneralInformation.RenameInfo RenamerTarget = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(RetargetUser.userID);
            String DisplayNameSender = RenameSender != null ? RenameSender.RenameNick ?? XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName : XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName;
            String TargetDisplayName = RenamerTarget != null ? RenamerTarget.RenameNick ?? RetargetUser.displayName : RetargetUser.displayName;
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(RetargetUser, GetLang("COMMAND_PM_SEND_MSG", RetargetUser.UserIDString, DisplayNameSender, Message));
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_SUCCESS", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, Message, TargetDisplayName));
            if (InfoRetarget.Settings.TurnSound) Effect.server.Run(ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ.JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO, RetargetUser.GetNetworkPosition());
            XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName} sent a message to the player - {RetargetUser.displayName}\nMESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName} отправил сообщение игроку - {RetargetUser.displayName}\nСООБЩЕНИЕ : {Message}");
            XNCFXBHUYQMFLUECGUWCVSTCHAVQRQTJJRGIIEHLCEWFTCSF(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, RetargetUser, Message);
            RCon.Broadcast(RCon.LogType.Chat, new Chat.ChatEntry
            {
                Message = LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {RetargetUser.displayName} : MESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {RetargetUser.displayName} : СООБЩЕНИЕ : {Message}",
                UserId = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString,
                Username = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName,
                Channel = Chat.ChatChannel.Global,
                Time = (DateTime.UtcNow.Hour * 3600) + (DateTime.UtcNow.Minute * 60),
                Color = "#3f4bb8",
            });
            PrintWarning(LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {RetargetUser.displayName} : MESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {RetargetUser.displayName} : СООБЩЕНИЕ : {Message}");
        }
        void OnGroupPermissionGranted(string name, string CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO)
        {
            String[] PlayerGroups = permission.GetUsersInGroup(name);
            if (PlayerGroups == null) return;
            foreach (String playerInfo in PlayerGroups)
            {
                BasePlayer player = BasePlayer.FindByID(UInt64.Parse(playerInfo.Substring(0, 17)));
                if (player == null) return;
                ODASEJLVPVMIIVCFOINFBRXJPWSFENPJNFXGLULQOFY(player.UserIDString, CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO);
            }
        }
        void OnUserPermissionGranted(string id, string YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT) => ODASEJLVPVMIIVCFOINFBRXJPWSFENPJNFXGLULQOFY(id, YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT);
        private void UPHLOPSPENNNBBZETBFBGIYGNBJQKKAMTIEFWBPMLTXMT(BasePlayer player, SelectedAction Action)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore");
            if (Interface == null) return;
            Interface = Interface.Replace("%TITLE%", Action == SelectedAction.Mute ? GetLang("IQCHAT_TITLE_IGNORE_AND_MUTE_MUTED", player.UserIDString) : GetLang("IQCHAT_TITLE_IGNORE_AND_MUTE_IGNORED", player.UserIDString));
            Interface = Interface.Replace("%ACTION_TYPE%", $"{Action}");
            CuiHelper.DestroyUi(player, "MuteAndIgnoredPanel");
            CuiHelper.AddUi(player, Interface);
            MFPULNRGKTYRYNIGQTERYHPMKOPRNIJTTYJNFTGFVYD(player, Action);
        }
        private class InformationOpenedUI
        {
            public List<Configuration.ControllerParameters.AdvancedFuncion> ElementsPrefix;
            public List<Configuration.ControllerParameters.AdvancedFuncion> ElementsNick;
            public List<Configuration.ControllerParameters.AdvancedFuncion> ElementsChat;
            public List<Configuration.ControllerParameters.AdvancedFuncion> ElementsRanks;
            public Int32 SlideIndexPrefix = 0;
            public Int32 SlideIndexNick = 0;
            public Int32 SlideIndexChat = 0;
            public Int32 SlideIndexRank = 0;
        }
        String CIPXOYCXIMQBXNFBETMATSWTISLTPMKLMPZAANWCKWARPVDCG(UInt64 ID)
        {
            if (!UserInformation.ContainsKey(ID)) return String.Empty;
            Configuration.ControllerParameters NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            User Info = UserInformation[ID];
            String GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Empty;
            if (NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = String.Join("", Info.Info.PrefixList.Take(NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.LEYJNJGXVWDENROXHTZUMZSLPLBTYIFDZLXZMNOQPZUMXGBC));
            else GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Info.Info.Prefix;
            return GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP;
        }
        private void ODASEJLVPVMIIVCFOINFBRXJPWSFENPJNFXGLULQOFY(String ID, String Permissions)
        {
            UInt64 UserID = UInt64.Parse(ID);
            BasePlayer player = BasePlayer.FindByID(UserID);
            Configuration.ControllerConnection.Turned Controller = config.ControllerConnect.JXHHHMXREZRMBICZNOYPGYLDCTWZFJWUYFDGJCBVYAKRN;
            Configuration.ControllerParameters Parameters = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (!UserInformation.ContainsKey(UserID)) return;
            User Info = UserInformation[UserID];
            if (Controller.PGVXJYGKGXGAPYUBPIGKKNOUZRUMUMLLMCBJYQALYYOD)
            {
                Configuration.ControllerParameters.AdvancedFuncion GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Parameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.FirstOrDefault(prefix => prefix.Permissions == Permissions);
                if (GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP == null) return;
                if (Parameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB) Info.Info.PrefixList.Add(GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument);
                else Info.Info.Prefix = GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument;
                if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("PREFIX_SETUP", player.UserIDString, GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument));
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) successfully retrieved the prefix {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}" : $"Игрок ({UserID}) успешно забрал префикс {GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Argument}");
            }
            if (Controller.PHXGDDPUAZCRBYRDTQULVONXLCYIULMYLUKKXFRIVQLCYRXSI)
            {
                Configuration.ControllerParameters.AdvancedFuncion ColorNick = Parameters.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ.FirstOrDefault(nick => nick.Permissions == Permissions);
                if (ColorNick == null) return;
                Info.Info.ColorNick = ColorNick.Argument;
                if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COLOR_NICK_SETUP", player.UserIDString, ColorNick.Argument));
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) successfully took the color of the nickname {ColorNick.Argument}" : $"Игрок ({UserID}) успешно забрал цвет ника {ColorNick.Argument}");
            }
            if (Controller.FIUREBUAVAFHZONEGGNHGNZLQFCLYTEFZMFDDUQJQXK)
            {
                Configuration.ControllerParameters.AdvancedFuncion ColorChat = Parameters.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ.FirstOrDefault(message => message.Permissions == Permissions);
                if (ColorChat == null) return;
                Info.Info.ColorMessage = ColorChat.Argument;
                if (player != null) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COLOR_CHAT_SETUP", player.UserIDString, ColorChat.Argument));
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"Player ({UserID}) successfully retrieved the color of the chat {ColorChat.Argument}" : $"Игрок ({UserID}) успешно забрал цвет чата {ColorChat.Argument}");
            }
        }
        private enum SelectedParametres
        {
            DropList,
            Slider
        }
        public string FindFakeName(ulong userID) => (string)IQFakeActive?.Call("FindFakeName", userID);
        private void UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC(string OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA, string payload, Action<int> DFKNCAIGHXSFBBWYSSNJYDHYHJDAJVAFYRTEHXQBRHUP = null)
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json");
            webrequest.Enqueue(OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA, payload, (code, response) =>
            {
                if (code != 200 && code != 204)
                {
                    if (response != null)
                    {
                        try
                        {
                            JObject json = JObject.Parse(response);
                            if (code == 429)
                            {
                                float seconds = float.Parse(Math.Ceiling((double)(int)json["retry_after"] / 1000).ToString());
                            }
                            else
                            {
                                PrintWarning($" Discord rejected that payload! Responded with \"{json["message"].ToString()}\" Code: {code}");
                            }
                        }
                        catch
                        {
                            PrintWarning($"Failed to get a valid response from discord! Error: \"{response}\" Code: {code}");
                        }
                    }
                    else
                    {
                        PrintWarning($"Discord didn't respond (down?) Code: {code}");
                    }
                }
                try
                {
                    DFKNCAIGHXSFBBWYSSNJYDHYHJDAJVAFYRTEHXQBRHUP?.Invoke(code);
                }
                catch (Exception ex) { }
            }, this, RequestMethod.POST, header);
        }
        void Alert(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, BasePlayer Recipient, string[] arg)
        {
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg);
            if (Message == null) return;
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Recipient, Message);
        }
        private void XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(String KEGBHSWNMMZYMFTWHWLWNHJIRQUCLSQIRKXEXYCDDSMET) => LogToFile("IQChatLogs", KEGBHSWNMMZYMFTWHWLWNHJIRQUCLSQIRKXEXYCDDSMET, this);
        private
        const String PermissionHideConnection = "iqchat.hideconnection";
        private void OpenChat(BasePlayer player)
        {
            if (MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY == null)
            {
                PrintWarning(LanguageEn ? "We generate the interface, wait for a message about successful generation" : "Генерируем интерфейс, ожидайте сообщения об успешной генерации");
                return;
            }
            if (player == null) return;
            User Info = UserInformation[player.userID];
            Configuration.ControllerParameters ControllerParameters = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            if (!LocalBase.ContainsKey(player)) LocalBase.Add(player, new InformationOpenedUI { });
            LocalBase[player].ElementsPrefix = ControllerParameters.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.OrderByDescending(arg => arg.Argument.Length).Where(p => permission.UserHasPermission(player.UserIDString, p.Permissions)).ToList();
            LocalBase[player].ElementsNick = ControllerParameters.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ.Where(n => permission.UserHasPermission(player.UserIDString, n.Permissions)).ToList();
            LocalBase[player].ElementsChat = ControllerParameters.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ.Where(m => permission.UserHasPermission(player.UserIDString, m.Permissions)).ToList();
            if (IQRankSystem && config.ReferenceSetting.IQRankSystems.UseRankSystem)
            {
                List<Configuration.ControllerParameters.AdvancedFuncion> RankList = new List<Configuration.ControllerParameters.AdvancedFuncion>();
                foreach (String Rank in AAXIDDIVAMJBLOQWELBAPATPNULPDZIUJSDCKSYDOQPKBJ(player.userID)) RankList.Add(new Configuration.ControllerParameters.AdvancedFuncion
                {
                    Argument = Rank,
                    Permissions = String.Empty
                });
                LocalBase[player].ElementsRanks = RankList;
            }
            NYMLIONVZNNJCAQMUIRYDVDUTEIZNBLWTCCWJZEMOVFTRQXG(player);
        }
        private void OLVYOHLRWSBTOCOTDPYTSEJTTCKHOBISJPYMRZWACLIQYFKR(BasePlayer player, BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, MuteType Type, UInt64 KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU = 0)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_Alert_DropList_Title");
            if (Interface == null) return;
            Interface = Interface.Replace("%TITLE%", GetLang("IQCHAT_BUTTON_MODERATION_MUTE_MENU_TITLE_ALERT_REASON", player.UserIDString));
            CuiHelper.DestroyUi(player, "AlertMuteTitleReason");
            CuiHelper.DestroyUi(player, "PanelMuteReason");
            CuiHelper.AddUi(player, Interface);
            List<Configuration.ControllerMute.Muted> Reasons = Type == MuteType.Chat ? config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.VTGWNPGHZUHIBCOKTYYPKYMALXUMAKEIKGJLVSTEEJWKVL : config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.BLIGFNZHWHGLQUTHOPYXVSDOBETLBCBEZUTBRDYVL;
            Int32 Y = 0;
            foreach (Configuration.ControllerMute.Muted Reason in Reasons.Take(6)) OLVYOHLRWSBTOCOTDPYTSEJTTCKHOBISJPYMRZWACLIQYFKR(player, JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, Reason.Reason, Y++, Type, KXWLDBQYPZNYCAWMLINKSPZJAPOABMSLNFVPQRKDVTVYUTEGU);
        }
        private void NBLZTCQEADSPRPGJEWLVHGNGRHUASPVLAEVRRYCAJLV(BasePlayer player, Boolean VSWFJLJSZDUXKQXUBUWRGBIPZJUITVUFPKVCFFIFZZ, SelectedAction Action, Int32 Page = 0)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Pages");
            if (Interface == null) return;
            String CommandRight = VSWFJLJSZDUXKQXUBUWRGBIPZJUITVUFPKVCFFIFZZ ? $"newui.cmd action.mute.ignore page.controller {Action} {Page + 1}" : String.Empty;
            String ColorRight = String.IsNullOrEmpty(CommandRight) ? "1 1 1 0.1" : "1 1 1 1";
            String CommandLeft = Page > 0 ? $"newui.cmd action.mute.ignore page.controller {Action} {Page - 1}" : String.Empty;
            String ColorLeft = String.IsNullOrEmpty(CommandLeft) ? "1 1 1 0.1" : "1 1 1 1";
            Interface = Interface.Replace("%COMMAND_LEFT%", CommandLeft);
            Interface = Interface.Replace("%COMMAND_RIGHT%", CommandRight);
            Interface = Interface.Replace("%PAGE%", $"{Page}");
            Interface = Interface.Replace("%COLOR_LEFT%", ColorLeft);
            Interface = Interface.Replace("%COLOR_RIGHT%", ColorRight);
            CuiHelper.DestroyUi(player, "PageCount");
            CuiHelper.DestroyUi(player, "LeftPage");
            CuiHelper.DestroyUi(player, "RightPage");
            CuiHelper.AddUi(player, Interface);
        }
        [ConsoleCommand("unmute")]
        void QRBCCLNLGRAGOFIMHPLLIHOMUOSGTKLWKWQZFSXGBJEIEP(ConsoleSystem.Arg arg)
        {
            if (arg.Player() != null)
                if (!permission.UserHasPermission(arg.Player().UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg?.Args == null || arg.Args.Length != 1 || arg.Args.Length > 1)
            {
                PrintWarning(LanguageEn ? "Invalid syntax, please use : unmute Steam64ID" : "Неверный синтаксис,используйте : unmute Steam64ID");
                return;
            }
            string NameOrID = arg.Args[0];
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (!Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "The player does not have a chat lock" : "У игрока нет блокировки чата");
                            return;
                        }
                        Info.MuteInfo.UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(MuteType.Chat);
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "You have unblocked the offline chat to the player" : "Вы разблокировали чат offline игроку");
                        return;
                    }
                    else
                    {
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(target, MuteType.Chat, arg.Player(), false, true);
            Puts(LanguageEn ? "Successfully" : "Успешно");
        }
        void LPPSTZKIJCOIOTHSVGEVROIHPREJYCFIFLGQDSRWA(Chat.ChatChannel channel, BasePlayer player, String UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            User Info = UserInformation[player.userID];
            GeneralInformation.RenameInfo RenameInfo = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(player.userID);
            UInt64 RenameID = RenameInfo != null ? RenameInfo.RenameID != 0 ? RenameInfo.RenameID : player.userID : player.userID;
            if (channel == Chat.ChatChannel.Global)
            {
                foreach (BasePlayer p in BasePlayer.activePlayerList)
                {
                    if (UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.Contains("@"))
                    {
                        String SplittedName = UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.Substring(UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.IndexOf('@')).Replace("@", "").Split(' ')[0];
                        BasePlayer playerTags = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(SplittedName);
                        if (playerTags != null)
                        {
                            User InfoP = UserInformation[playerTags.userID];
                            if (InfoP.Settings.TurnAlert && p == playerTags)
                            {
                                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(p, $"<size=16>{UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.Trim()}</size>", GetLang("IQCHAT_FUNCED_ALERT_TITLE", p.UserIDString), p.UserIDString, ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.PLOMZYCAZCHTFUCOKPXEIQGWVXQFAOOTGXSGZSDOMLILN.WVVQCIPDROVHWIIBDQRMRHCJHBRVSLQHPKCTDKTUSTCQLRRH);
                                if (InfoP.Settings.TurnSound) Effect.server.Run(ControllerMessages.YYCXSSYNVHKSMXDUBKDIVLZJNHAYUZIOZSMTAOEMAKYTYHMV.PLOMZYCAZCHTFUCOKPXEIQGWVXQFAOOTGXSGZSDOMLILN.PFYMWEPTMJARTLGYNSMFPYSWWUYELXPJKECGSVSGNARBTC, playerTags.GetNetworkPosition());
                            }
                            else p.SendConsoleCommand("chat.add", new object[] {
                                                                (int) channel, RenameID, UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX
                                                        });
                        }
                        else p.SendConsoleCommand("chat.add", new object[] {
                                                        (int) channel, RenameID, UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX
                                                });
                    }
                    else p.SendConsoleCommand("chat.add", new object[] {
                                                (int) channel, RenameID, UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX
                                        });
                    p.ConsoleMessage(UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX);
                }
            }
            if (channel == Chat.ChatChannel.Team)
            {
                RelationshipManager.PlayerTeam Team = RelationshipManager.ServerInstance.FindTeam(player.currentTeam);
                if (Team == null) return;
                foreach (var FindPlayers in Team.members)
                {
                    BasePlayer TeamPlayer = BasePlayer.FindByID(FindPlayers);
                    if (TeamPlayer == null) continue;
                    TeamPlayer.SendConsoleCommand("chat.add", channel, RenameID, UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX);
                }
            }
            if (channel == Chat.ChatChannel.Cards)
            {
                if (!player.isMounted) return;
                CardTable cardTable = player.GetMountedVehicle() as CardTable;
                if (cardTable == null || !cardTable.GameController.PlayerIsInGame(player)) return;
                List<Network.Connection> PlayersCards = new List<Network.Connection>();
                cardTable.GameController.GetConnectionsInGame(PlayersCards);
                if (PlayersCards == null || PlayersCards.Count == 0) return;
                foreach (Network.Connection PCard in PlayersCards)
                {
                    BasePlayer PlayerInRound = BasePlayer.FindByID(PCard.userid);
                    if (PlayerInRound == null) return;
                    PlayerInRound.SendConsoleCommand("chat.add", channel, RenameID, UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX);
                }
            }
        }
        private class ImageUi
        {
            private static Coroutine coroutineImg = null;
            private static Dictionary<string, string> Images = new Dictionary<string, string>();
            public static void HWRJJNURJCATMXHIDBVAKGXGDCNQODOHVCHLQFHRPGTDH()
            {
                MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY = new InterfaceBuilder();
                // coroutineImg = ServerMgr.Instance.StartCoroutine(YIJUOPAZEAZKFGZDCFOSXJPVSXTDLDNUYRDEHTOYGVYH());
            }
            private static IEnumerator YIJUOPAZEAZKFGZDCFOSXJPVSXTDLDNUYRDEHTOYGVYH()
            {
                _.PrintWarning(LanguageEn ? "Generating interface, wait ~10-15 seconds!" : "Генерируем интерфейс, ожидайте ~10-15 секунд!");
                foreach (String Key in _.KeyImages)
                {
                    string uri = $"https://api-methods.st8.ru/v2/chat/{Key}/WIwsqNNWF7nN";
                    UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
                    yield
                    return www.SendWebRequest();
                    if (_ == null) yield
                    break;
                    if (www.isNetworkError || www.isHttpError)
                    {
                        _.PrintWarning(string.Format("Image download error! Error: {0}, Image name: {1}", www.error, Key));
                        www.Dispose();
                        coroutineImg = null;
                        yield
                        break;
                    }
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    if (texture != null)
                    {
                        byte[] bytes = texture.EncodeToPNG();
                        var image = FileStorage.server.Store(bytes, FileStorage.Type.png, CommunityEntity.ServerInstance.net.ID).ToString();
                        if (!Images.ContainsKey(Key)) Images.Add(Key, image);
                        else Images[Key] = image;
                        UnityEngine.Object.DestroyImmediate(texture);
                    }
                    www.Dispose();
                    yield
                    return CoroutineEx.waitForSeconds(0.02f);
                }
                coroutineImg = null;
                MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY = new InterfaceBuilder();
                _.PrintWarning(LanguageEn ? "Interface loaded successfully!" : "Интерфейс успешно загружен!");
            }
            public static string ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM(String JBSYAJOYAGLTRNQMUUHRKTCWBGDHZOZHSVQTCQVCCSGKC)
            {
                if (_.KeyImages.Contains(JBSYAJOYAGLTRNQMUUHRKTCWBGDHZOZHSVQTCQVCCSGKC)) return _.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM(JBSYAJOYAGLTRNQMUUHRKTCWBGDHZOZHSVQTCQVCCSGKC);
                return _.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("LOADING");
            }
            public static void Unload()
            {
                coroutineImg = null;
                foreach (var item in Images) FileStorage.server.RemoveExact(uint.Parse(item.Value), FileStorage.Type.png, CommunityEntity.ServerInstance.net.ID, 0U);
            }
        }
        public class User
        {
            public Information Info = new Information();
            public Setting Settings = new Setting();
            public Mute MuteInfo = new Mute();
            internal class Information
            {
                public String Prefix;
                public String ColorNick;
                public String ColorMessage;
                public String Rank;
                public List<String> PrefixList = new List<String>();
            }
            internal class Setting
            {
                public Boolean TurnPM = true;
                public Boolean TurnAlert = true;
                public Boolean TurnBroadcast = true;
                public Boolean TurnSound = true;
                public List<UInt64> IgnoreUsers = new List<UInt64>();
                public Boolean IsIgnored(UInt64 TargetID) => IgnoreUsers.Contains(TargetID);
                public void LURXCJHXVGTLXWQVXZDMELEPUDLOCMACKOJBRTNBUNNCT(UInt64 TargetID)
                {
                    if (IsIgnored(TargetID)) IgnoreUsers.Remove(TargetID);
                    else IgnoreUsers.Add(TargetID);
                }
            }
            internal class Mute
            {
                public Double TimeMuteChat;
                public Double TimeMuteVoice;
                public Double GetTime(MuteType Type)
                {
                    Double TimeMuted = 0;
                    switch (Type)
                    {
                        case MuteType.Chat:
                            TimeMuted = TimeMuteChat - CurrentTime;
                            break;
                        case MuteType.Voice:
                            TimeMuted = TimeMuteVoice - CurrentTime;
                            break;
                        default:
                            break;
                    }
                    return TimeMuted;
                }
                public void QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(MuteType Type, Int32 Time)
                {
                    switch (Type)
                    {
                        case MuteType.Chat:
                            TimeMuteChat = Time + CurrentTime;
                            break;
                        case MuteType.Voice:
                            TimeMuteVoice = Time + CurrentTime;
                            break;
                        default:
                            break;
                    }
                }
                public void UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(MuteType Type)
                {
                    switch (Type)
                    {
                        case MuteType.Chat:
                            TimeMuteChat = 0;
                            break;
                        case MuteType.Voice:
                            TimeMuteVoice = 0;
                            break;
                        default:
                            break;
                    }
                }
                public Boolean BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType Type) => GetTime(Type) > 0;
            }
        }
        private void LRGTFXVRCLXCZBXSMLXQFBZIAGBFYDGWGROYUIHSJUHMY(BasePlayer player)
        {
            Configuration.ControllerAlert.Alert Alert = config.ControllerAlertSetting.AlertSetting;
            Configuration.ControllerAlert.AdminSession AlertSessionAdmin = config.ControllerAlertSetting.AdminSessionSetting;
            Configuration.ControllerAlert.PlayerSession AlertSessionPlayer = config.ControllerAlertSetting.PlayerSessionSetting;
            Configuration.ControllerAlert.PersonalAlert AlertPersonal = config.ControllerAlertSetting.PersonalAlertSetting;
            GeneralInformation.RenameInfo EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(player.userID);
            Configuration.ControllerMessage ControllerMessage = config.ControllerMessages;
            String DisplayName = player.displayName;
            UInt64 UserID = player.userID;
            if (EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS != null)
            {
                DisplayName = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameNick;
                UserID = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameID;
            }
            if (AlertSessionPlayer.ConnectedAlert)
            {
                if (!AlertSessionAdmin.ConnectedAlertAdmin)
                    if (player.IsAdmin) return;
                String Avatar = AlertSessionPlayer.ConnectedAvatarUse ? UserID.ToString() : String.Empty;
                String Message = String.Empty;
                if (AlertSessionPlayer.ConnectedWorld)
                {
                    webrequest.Enqueue("http://ip-api.com/json/" + player.net.connection.ipaddress.Split(':')[0], null, (code, response) =>
                    {
                        if (code != 200 || response == null) return;
                        String country = JsonConvert.DeserializeObject<Response>(response).Country;
                        if (AlertSessionPlayer.ConnectionAlertRandom)
                        {
                            VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.Clear();
                            Message = VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.AppendFormat(GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(player, AlertSessionPlayer.RandomConnectionAlert.LanguageMessages), DisplayName, country).ToString();
                        }
                        else Message = GetLang("WELCOME_PLAYER_WORLD", player.UserIDString, DisplayName, country);
                        if (!permission.UserHasPermission(player.UserIDString, PermissionHideConnection)) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(Message, "", Avatar);
                        XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB($"[{player.userID}] {Message}");
                    }, this);
                }
                else
                {
                    if (AlertSessionPlayer.ConnectionAlertRandom)
                    {
                        VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.Clear();
                        Message = VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.AppendFormat(GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(player, AlertSessionPlayer.RandomConnectionAlert.LanguageMessages), DisplayName).ToString();
                    }
                    else Message = GetLang("WELCOME_PLAYER", player.UserIDString, DisplayName);
                    if (!permission.UserHasPermission(player.UserIDString, PermissionHideConnection)) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(Message, "", Avatar);
                    XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB($"[{player.userID}] {Message}");
                }
            }
            if (AlertPersonal.UseWelcomeMessage)
            {
                String WelcomeMessage = GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(player, AlertPersonal.WelcomeMessage.LanguageMessages);
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, WelcomeMessage);
            }
        }
        private void EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(BasePlayer player, String Messages)
        {
            if (player != null) player.ConsoleMessage(Messages);
            else PrintWarning(Messages);
        }
        [ChatCommand("alert")]
        private void GWPHWTBIHXMWCZYGGDQYPFNBXLIRGJLMAIRCOWINI(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] args)
        {
            if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args, false);
        }
        private void GMFFIIDMPLTJQBINKKKJCXMAWUHVSKUCPDYBWSDZOUUZ()
        {
            Configuration.ControllerParameters Controller = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            Configuration.ControllerConnection ControllerConnection = config.ControllerConnect;
            List<Configuration.ControllerParameters.AdvancedFuncion> GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP = Controller.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP;
            List<Configuration.ControllerParameters.AdvancedFuncion> NickColor = Controller.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ;
            List<Configuration.ControllerParameters.AdvancedFuncion> ChatColor = Controller.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ;
            foreach (KeyValuePair<UInt64, User> Info in UserInformation)
            {
                if (Controller.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.UASJEVZPJQCNAAWNJWRNBGJDLXCAVXQJBLPUTKNLJB)
                {
                    foreach (String Prefix in Info.Value.Info.PrefixList.Where(prefixList => !GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Exists(i => i.Argument == prefixList))) NextTick(() => Info.Value.Info.PrefixList.Remove(Prefix));
                }
                else
                {
                    if (!GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Exists(i => i.Argument == Info.Value.Info.Prefix)) Info.Value.Info.Prefix = ControllerConnection.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.UEXMFAOOOQWABPABZCADWSPMRBIXZTHHZMALNAXQRZFYWWN;
                }
                if (!NickColor.Exists(i => i.Argument == Info.Value.Info.ColorNick)) Info.Value.Info.ColorNick = ControllerConnection.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK;
                if (!ChatColor.Exists(i => i.Argument == Info.Value.Info.ColorMessage)) Info.Value.Info.ColorMessage = ControllerConnection.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.MessageDefault;
            }
        }
        void QSQUALYDZJIZFINBHTERQTMCGRSGKVIDMHFBRBSYVZQTQCR(BasePlayer player, String Message, String XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH = null, String FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV = null, String QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU = null) => TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, Message, XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH, FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV, QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU);
        private class InterfaceBuilder
        {
            public static InterfaceBuilder Instance;
            public
            const String UI_Chat_Context = "UI_IQCHAT_CONTEXT";
            public
            const String UI_Chat_Context_Visual_Nick = "UI_IQCHAT_CONTEXT_VISUAL_NICK";
            public
            const String UI_Chat_Alert = "UI_IQCHAT_ALERT";
            public Dictionary<String, String> Interfaces;
            public InterfaceBuilder()
            {
                Instance = this;
                Interfaces = new Dictionary<String, String>();
                MNVNYROUSKNOZVKDGVXCSTMUPXLSLPMYXGYIFVZSAWGEXD();
                LOVGGEPSIQJRAFHERZOHBXAWKVBIXKORYOKSGFHDROZC();
                KWALSBAWTABXAFVJCXOQSXBYLWFBWMHXLQBVLEUXXJ();
                MNSYRPUDAKIPBERKJCFSIIMGQWNTTZKPCHLWVHYCQL();
                LEBLZPWRRJHZEAMHVCAJAASMTSUOBDDBWUBBPLNEXITFU();
                HWJADAQBNKLORGUHPNGGCKYKRJOWMSHMSLLYFBACLUG();
                HEXYMEMDGIMONUBAWVYAGTDLKEZYXDRTJSTUNXSXJ();
                BPZBOBJEXBZJYOAMNIEOGDQTFUAHMYDAQXSOMJPYPSF();
                ONNGUXVHNECNTGAOEVNMAEMTCPQRZOYOIOTKZCERBPMRFX();
                ANWGGLDQKBTEFHDHYGNEFNPOCQVLKRUNEUPECHRDFXJJGXZK();
                HOLSSPNXIEQPSFSHFZKRZERPJZIDGHEQLNDDIVLFBGUCAOMRQ();
                BYPSYCWWITHJRAZADECOYJNFQSKOOVMQNDGGATPA();
                PBUHJQSFZOGXXYITLTPVDZVGVWBOMDUHDHUQOHMWZBNEEO();
                TZTFTBKJSVCXYFVTABSYXYSBWMZETGZOXAAFBVOLOTHVVU();
                HNVXNAHSUHSIGBFQMVOZYFQSFNGJEQWGCXSRXILNQIFYJ();
                HKJCVZGVRBWDSAUXNEKMGJJNTEKAIPARJRFVABVXZGFQU();
                PLTTUBOWHXBWJQPGNBBFUAUYWMINNZDSSZOYHOVZDMKHUES();
                HTTEPPZPRVWISAJHUJDJBRYYFCBHPMDSTDFTGZCCA();
                EPLZPZBNUBIXEICNDYFLZZNYFIYNIZOWWAWILOHOLLBYP();
                GLSNGCDCNLAJDPUVYNORZERDOPUPBUGAICKNGSVYENZRSJAPZ();
                APOIZCTOYRINBSFZAAFHPGRPNMFALEOEQQUQMACITRTE();
                RLGMSJZKSVTYZVNWTCUCDXKXONAXWOXNNZVAYOTVPUYVBS();
            }
            public static void PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW(String name, String json)
            {
                if (Instance.Interfaces.ContainsKey(name))
                {
                    _.PrintError($"Error! Tried to add existing cui elements! -> {name}");
                    return;
                }
                Instance.Interfaces.Add(name, json);
            }
            public static string NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ(String name)
            {
                string json = string.Empty;
                if (Instance.Interfaces.TryGetValue(name, out json) == false)
                {
                    _.PrintWarning($"Warning! UI elements not found by name! -> {name}");
                }
                return json;
            }
            public static void OGCNXOIFTVOJBDZTCAYZVHCLNIHGHSZDNAUCINJZ()
            {
                for (var i = 0; i < BasePlayer.activePlayerList.Count; i++)
                {
                    var player = BasePlayer.activePlayerList[i];
                    CuiHelper.DestroyUi(player, UI_Chat_Context);
                    CuiHelper.DestroyUi(player, UI_Chat_Context_Visual_Nick);
                    CuiHelper.DestroyUi(player, UI_Chat_Alert);
                    CuiHelper.DestroyUi(player, "MUTE_AND_IGNORE_PANEL_ALERT");
                }
            }
            private void LOVGGEPSIQJRAFHERZOHBXAWKVBIXKORYOKSGFHDROZC()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = UI_Chat_Context_Visual_Nick,
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%NICK_DISPLAY%", Font = "robotocondensed-regular.ttf", FontSize = 12, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-265 -25.878", OffsetMax = "-2.644 -8.613"
                                                }
                                        }
                });
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Context_Visual_Nick", container.ToJson());
            }
            private void MNVNYROUSKNOZVKDGVXCSTMUPXLSLPMYXGYIFVZSAWGEXD()
            {
                Configuration.ControllerParameters Controller = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
                if (Controller == null)
                {
                    _.PrintWarning("Ошибка генерации интерфейса, null значение в конфигурации, свяжитесь с разработчиком");
                    return;
                }
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiPanel
                {
                    CursorEnabled = true,
                    RectTransform = {
                                                AnchorMin = "0.270 0.5",
                                                AnchorMax = "0.900 0.5",
                                                OffsetMin = "0 -305",
                                                OffsetMax = "0 205"
                                        },
                    Image = {
                                                Color = "0.4 0.4 0.4 0"
                                        }
                }, "MS_UI", UI_Chat_Context);
                container.Add(new CuiElement
                {
                    Parent = UI_Chat_Context,
                    Name = "MULTIPLE_PANEL_BACKGROUND",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MULTIPLE_PANEL_BACKGROUND"), Color = "0.9 0.9 0.9 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 1", AnchorMax = "0.5 1", OffsetMin = "-310 -210", OffsetMax = "310 -5"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Parent = UI_Chat_Context,
                    Name = "INFORMATION_PANEL_BACKGROUND",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_PANEL_BACKGROUND"), Color = "0.9 0.9 0.9 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0", AnchorMax = "0.5 0", OffsetMin = "-300 65", OffsetMax = "-1 295"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Parent = UI_Chat_Context,
                    Name = "SETTINGS_PANEL_BACKGROUND",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_PANEL_BACKGROUND"), Color = "0.9 0.9 0.9 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0", AnchorMax = "0.5 0", OffsetMin = "6 65", OffsetMax = "300 295"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "ImageContext",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = "%IMG_BACKGROUND%"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "TitleLabel",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SETTING_ELEMENT%", Font = "robotocondensed-regular.ttf", FontSize = 20, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "30 -50", OffsetMax = "500 0"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "InformationLabel",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%INFORMATION%", Font = "robotocondensed-regular.ttf", FontSize = 20, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "30 -250", OffsetMax = "200 -220"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "InformationIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_INFORMATION_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-42.788 8.12", OffsetMax = "-15.788 31.12"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "MultipleIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MULTIPLE_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "258.788 218.12", OffsetMax = "285.788 241.12"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingLabel",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 20, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "335 -250", OffsetMax = "505 -220"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_SETTING_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "258.788 8.12", OffsetMax = "285.788 31.12"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingPM",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SETTINGS_PM%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "61.075 -40.712", OffsetMax = "210.125 -17.088"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingAlertChat",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SETTINGS_ALERT%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "61.075 -60.712", OffsetMax = "210.125 -37.088"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingNoticyChat",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SETTINGS_ALERT_PM%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "61.075 -80.712", OffsetMax = "210.125 -57.088"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SettingSoundAlert",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SETTINGS_SOUNDS%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "61.075 -100.712", OffsetMax = "210.125 -77.088"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "MuteStatus",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%MUTE_STATUS_PLAYER%", Font = "robotocondensed-regular.ttf", FontSize = 18, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-268.174 -121.59", OffsetMax = "-220.611 -64.967"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "MuteStatusTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%MUTE_STATUS_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 13, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-268.174 -136.59", OffsetMax = "-160.611 -79.967"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "CountIgnored",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%IGNORED_STATUS_COUNT%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-123.174 -121.59", OffsetMax = "-30.611 -64.967"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "IgonoredTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%IGNORED_STATUS_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 13, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-122.174 -136.59", OffsetMax = "-33.611 -79.967"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "IgnoredIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_INFO_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-33.483 -90.225", OffsetMax = "-25.762 -82.814"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1",
                                                OffsetMin = "-105 -55",
                                                OffsetMax = "10 15"
                                        },
                    Button = {
                                                Command = $"newui.cmd action.mute.ignore open {SelectedAction.Ignore}",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "IgnoredIcon", "CLOSE_IGNORED");
                container.Add(new CuiElement
                {
                    Name = "NickTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SLIDER_NICK_COLOR_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 17, Align = TextAnchor.MiddleLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "342 -70", OffsetMax = "432 -45"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "ChatMessageTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SLIDER_MESSAGE_COLOR_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 17, Align = TextAnchor.MiddleLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "40 -155", OffsetMax = "130 -130"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "PrefixTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SLIDER_PREFIX_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 17, Align = TextAnchor.MiddleLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "40 -70", OffsetMax = "130 -45"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "RankTitle",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%SLIDER_IQRANK_TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 17, Align = TextAnchor.MiddleLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "342 -155", OffsetMax = "432 -130"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0",
                                                OffsetMin = "0 0",
                                                OffsetMax = "0 20"
                                        },
                    Button = {
                                                Color = "0 0 0 0",
                                                Close = "MS_UI"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, UI_Chat_Context, "CloseBtn");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Context", container.ToJson());
            }
            private void KWALSBAWTABXAFVJCXOQSXBYLWFBWMHXLQBVLEUXXJ()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "%NAME_CHECK_BOX%",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SETTING_CHECK_BOX")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_TURNED%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "%NAME_CHECK_BOX%", "CHECK_BOX_TURNED");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Context_CheckBox", container.ToJson());
            }
            private void HEXYMEMDGIMONUBAWVYAGTDLKEZYXDRTJSTUNXSXJ()
            {
                CuiElementContainer container = new CuiElementContainer();
                String NameSlider = "%NAME%";
                container.Add(new CuiElement
                {
                    Name = NameSlider,
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "Left",
                    Parent = NameSlider,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_LEFT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-111.9 -7.5", OffsetMax = "-100.9 7.5"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_LEFT_SLIDE%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "Left", "LEFT_SLIDER_BTN");
                container.Add(new CuiElement
                {
                    Name = "Right",
                    Parent = NameSlider,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_RIGHT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "100.92 -7.5", OffsetMax = "111.92 7.5"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_RIGHT_SLIDE%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "Right", "RIGHT_SLIDER_BTN");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Slider", container.ToJson());
            }
            private void BPZBOBJEXBZJYOAMNIEOGDQTFUAHMYDAQXSOMJPYPSF()
            {
                CuiElementContainer container = new CuiElementContainer();
                String ParentSlider = "%PARENT%";
                String NameArgument = "%NAME%";
                container.Add(new CuiElement
                {
                    Name = NameArgument,
                    Parent = ParentSlider,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%ARGUMENT%", Font = "robotocondensed-regular.ttf", FontSize = 14, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-81.929 -10.801", OffsetMax = "81.929 10.801"
                                                }
                                        }
                });
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Slider_Update_Argument", container.ToJson());
            }
            private void TZTFTBKJSVCXYFVTABSYXYSBWMZETGZOXAAFBVOLOTHVVU()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiPanel
                {
                    Image = {
                                                Color = "0 0 0 0.35",
                                                Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
                                        },
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0.893",
                                                OffsetMin = "172 0",
                                                OffsetMax = "0 0"
                                        },
                }, "MS_UI", "MuteAndIgnoredPanel");
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Close = "MuteAndIgnoredPanel",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "MuteAndIgnoredPanel", "Close");
                container.Add(new CuiElement
                {
                    Parent = "MuteAndIgnoredPanel",
                    Name = "Mains",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_PANEL_BACKGROUND"), Color = "1 1 1 1"
                                                },
                                                /*new CuiOutlineComponent { Color = "0.6 0.6 0.6 1", Distance = "-0.25 0.25" },*/ new CuiRectTransformComponent {
                                                        AnchorMin = "0.1 0.05", AnchorMax = "0.9 0.95"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "TitlesPanel",
                    Parent = "Mains",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 20, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "0.217 164.031", OffsetMax = "286.114 190.962"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "SearchPanel",
                    Parent = "Mains",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_AND_IGNORE_SEARCH")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-295.8 161.244", OffsetMax = "-96.349 192.58"
                                                }
                                        }
                });
                string SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ = "";
                container.Add(new CuiElement
                {
                    Parent = "SearchPanel",
                    Name = "SearchPanel" + ".Input.Current",
                    Components = {
                                                new CuiInputFieldComponent {
                                                        Text = SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ, FontSize = 14, Command = $"newui.cmd action.mute.ignore search.controller %ACTION_TYPE% {SHGANAKXHIHAWYDCFJTUKIWYFOTMBTJCCJWZEHSDYZMGSZ}", Align = TextAnchor.MiddleCenter, Color = "1 1 1 0.5", CharsLimit = 15
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 0", AnchorMax = "1 1"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "PanelPages",
                    Parent = "Mains",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_AND_IGNORE_PAGE_PANEL")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-89.196 161.242", OffsetMax = "-31.119 192.578"
                                                }
                                        }
                });
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_And_Ignore", container.ToJson());
            }
            private void HNVXNAHSUHSIGBFQMVOZYFQSFNGJEQWGCXSRXILNQIFYJ()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiPanel
                {
                    CursorEnabled = true,
                    RectTransform = {
                                                AnchorMin = "0.12 0.075",
                                                AnchorMax = "0.88 0.75"
                                        },
                    Image = {
                                                Color = "0 0 0 0"
                                        }
                }, "MuteAndIgnoredPanel", "MuteIgnorePanelContent");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_And_Ignore_Panel_Content", container.ToJson());
            }
            private void HKJCVZGVRBWDSAUXNEKMGJJNTEKAIPARJRFVABVXZGFQU()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "PANEL_PLAYER",
                    Parent = "MuteIgnorePanelContent",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_AND_IGNORE_PLAYER")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "NickName",
                    Parent = "PANEL_PLAYER",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%DISPLAY_NAME%", Font = "robotocondensed-regular.ttf", FontSize = 12, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-77.391 -17.245", OffsetMax = "91.582 17.244"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "StatusPanel",
                    Parent = "PANEL_PLAYER",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_AND_IGNORE_PLAYER_STATUS")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-92.231 -11.655", OffsetMax = "-87.503 10.44"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_ACTION%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "PANEL_PLAYER");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_And_Ignore_Player", container.ToJson());
            }
            private void PLTTUBOWHXBWJQPGNBBFUAUYWMINNZDSSZOYHOVZDMKHUES()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "PageCount",
                    Parent = "PanelPages",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%PAGE%", Font = "robotocondensed-regular.ttf", FontSize = 14, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-11.03 -15.668", OffsetMax = "11.03 15.668"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "LeftPage",
                    Parent = "PanelPages",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR_LEFT%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_LEFT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-18 -7", OffsetMax = "-13 6"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_LEFT%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "LeftPage");
                container.Add(new CuiElement
                {
                    Name = "RightPage",
                    Parent = "PanelPages",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR_RIGHT%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_RIGHT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "14 -7", OffsetMax = "19 6"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_RIGHT%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "RightPage");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_And_Ignore_Pages", container.ToJson());
            }
            private void HTTEPPZPRVWISAJHUJDJBRYYFCBHPMDSTDFTGZCCA()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiPanel
                {
                    CursorEnabled = true,
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Image = {
                                                Color = "0 0 0 0.25",
                                                Material = "assets/content/ui/uibackgroundblur-ingamemenu.mat"
                                        }
                }, "Overlay", "MUTE_AND_IGNORE_PANEL_ALERT");
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Close = "MUTE_AND_IGNORE_PANEL_ALERT",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "MUTE_AND_IGNORE_PANEL_ALERT");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_And_Ignore_Alert_Panel", container.ToJson());
            }
            private void GLSNGCDCNLAJDPUVYNORZERDOPUPBUGAICKNGSVYENZRSJAPZ()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "AlertMute",
                    Parent = "MUTE_AND_IGNORE_PANEL_ALERT",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_ALERT_PANEL")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-199.832 -274.669", OffsetMax = "199.832 274.669"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertMuteIcon",
                    Parent = "AlertMute",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_ALERT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-67 204.8", OffsetMax = "67 339.8"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertMuteTitles",
                    Parent = "AlertMute",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 25, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-199.828 142.57", OffsetMax = "199.832 179.43"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertMuteTakeChat",
                    Parent = "AlertMute",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_BUTTON_YES")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-99.998 87.944", OffsetMax = "100.002 117.944"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_TAKE_ACTION_MUTE_CHAT%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%BUTTON_TAKE_CHAT_ACTION%",
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 18,
                                                Color = "0.1294118 0.145098 0.1647059 1"
                                        }
                }, "AlertMuteTakeChat", "BUTTON_TAKE_CHAT");
                container.Add(new CuiElement
                {
                    Name = "AlertMuteTakeVoice",
                    Parent = "AlertMute",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_BUTTON_YES")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-100 49.70", OffsetMax = "100 79.70"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_TAKE_ACTION_MUTE_VOICE%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%BUTTON_TAKE_VOICE_ACTION%",
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 18,
                                                Color = "0.1294118 0.145098 0.1647059 1"
                                        }
                }, "AlertMuteTakeVoice", "BUTTON_TAKE_VOICE");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_Alert", container.ToJson());
            }
            private void APOIZCTOYRINBSFZAAFHPGRPNMFALEOEQQUQMACITRTE()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "AlertMuteTitleReason",
                    Parent = "AlertMute",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 22, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-199.828 -9.430", OffsetMax = "199.832 27.430"
                                                }
                                        }
                });
                container.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image = {
                                                Color = "1 1 1 0"
                                        },
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = "-147.497 -265.5440",
                                                OffsetMax = "147.503 -24.70"
                                        }
                }, "AlertMute", "PanelMuteReason");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_Alert_DropList_Title", container.ToJson());
            }
            private void RLGMSJZKSVTYZVNWTCUCDXKXONAXWOXNNZVAYOTVPUYVBS()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "Reason",
                    Parent = "PanelMuteReason",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MUTE_ALERT_PANEL_REASON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%COMMAND_REASON%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%REASON%",
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 13,
                                                Color = "1 1 1 1"
                                        }
                }, "Reason");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Mute_Alert_DropList_Reason", container.ToJson());
            }
            private void EPLZPZBNUBIXEICNDYFLZZNYFIYNIZOWWAWILOHOLLBYP()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "AlertIgnore",
                    Parent = "MUTE_AND_IGNORE_PANEL_ALERT",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_PANEL")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-236.5 -134", OffsetMax = "236.5 134"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertIgnoreIcon",
                    Parent = "AlertIgnore",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-66.5 64.8", OffsetMax = "66.5 198.8"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertIgnoreTitle",
                    Parent = "AlertIgnore",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 22, Align = TextAnchor.UpperCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-231 -55.00", OffsetMax = "229.421 33.984449"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertIgnoreYes",
                    Parent = "AlertIgnore",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_BUTTON_YES")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-178 -115", OffsetMax = "-22 -77"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Close = "MUTE_AND_IGNORE_PANEL_ALERT",
                                                Command = "%COMMAND%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%BUTTON_YES%",
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 18,
                                                Color = "0.1294118 0.145098 0.1647059 1"
                                        }
                }, "AlertIgnoreYes", "BUTTON_YES");
                container.Add(new CuiElement
                {
                    Name = "AlertIgnoreNo",
                    Parent = "AlertIgnore",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_IGNORE_ALERT_BUTTON_NO")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "22 -115", OffsetMax = "178 -77"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Close = "MUTE_AND_IGNORE_PANEL_ALERT",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%BUTTON_NO%",
                                                Align = TextAnchor.MiddleCenter,
                                                FontSize = 18
                                        }
                }, "AlertIgnoreNo", "BUTTON_NO");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Ignore_Alert", container.ToJson());
            }
            private void ONNGUXVHNECNTGAOEVNMAEMTCPQRZOYOIOTKZCERBPMRFX()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "DropListIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_PREFIX_MULTI_TAKE_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "DropListDescription",
                    Parent = "DropListIcon",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 8, Align = TextAnchor.MiddleLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-240.5 2.948", OffsetMax = "-157.615 17.725"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%BUTTON_DROP_LIST_CMD%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "DropListIcon", "DropListIcon_Button");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_DropList", container.ToJson());
            }
            private void ANWGGLDQKBTEFHDHYGNEFNPOCQVLKRUNEUPECHRDFXJJGXZK()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "OpenDropList",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_DROP_LIST_OPEN_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-284.429 55", OffsetMax = "291.093 209.1"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "DropListName",
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 17, Align = TextAnchor.UpperLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-140.329 34.5", OffsetMax = "-40.329 68.312"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "DropListDescription",
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%DESCRIPTION%", Font = "robotocondensed-regular.ttf", FontSize = 12, Align = TextAnchor.UpperLeft, Color = "0.8 0.8 0.8 0.9"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-140.329 27.993", OffsetMax = "-30.329 49.77"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "DropListClose",
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "?", Font = "robotocondensed-bold.ttf", FontSize = 20, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "112 31.2", OffsetMax = "146 57.2"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Close = "OpenDropList",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "DropListClose", "DropListClose_Button");
                container.Add(new CuiElement
                {
                    Name = "DropListPageRight",
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR_RIGHT%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_RIGHT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "100 38", OffsetMax = "105.2 48"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%NEXT_BTN%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "DropListPageRight", "DropListPageRight_Button");
                container.Add(new CuiElement
                {
                    Name = "DropListPageLeft",
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "%COLOR_LEFT%", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_SLIDER_LEFT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "86 38", OffsetMax = "91.2 48"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 1"
                                        },
                    Button = {
                                                Command = "%BACK_BTN%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = ""
                                        }
                }, "DropListPageLeft", "DropListPageLeft_Button");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_OpenDropList", container.ToJson());
            }
            private void HOLSSPNXIEQPSFSHFZKRZERPJZIDGHEQLNDDIVLFBGUCAOMRQ()
            {
                CuiElementContainer container = new CuiElementContainer();
                String Name = "ArgumentDropList_%COUNT%";
                container.Add(new CuiElement
                {
                    Name = Name,
                    Parent = "OpenDropList",
                    Components = {
                                                new CuiRawImageComponent {
                                                        FadeIn = 0.3f, Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_DROP_LIST_OPEN_ARGUMENT_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "%OFFSET_MIN%", OffsetMax = "%OFFSET_MAX%"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0.5 0.5",
                                                AnchorMax = "0.5 0.5",
                                                OffsetMin = "-37.529 -12.843",
                                                OffsetMax = "37.528 12.842"
                                        },
                    Button = {
                                                FadeIn = 0.3f,
                                                Command = "%TAKE_COMMAND_ARGUMENT%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                FadeIn = 0.3f,
                                                Text = "%ARGUMENT%",
                                                Font = "robotocondensed-regular.ttf",
                                                FontSize = 9,
                                                Align = TextAnchor.MiddleCenter,
                                                Color = "1 1 1 1"
                                        }
                }, Name, "ArgumentButton");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_OpenDropListArgument", container.ToJson());
            }
            private void BYPSYCWWITHJRAZADECOYJNFQSKOOVMQNDGGATPA()
            {
                CuiElementContainer container = new CuiElementContainer();
                String Parent = "ArgumentDropList_%COUNT%";
                container.Add(new CuiElement
                {
                    Name = "TAKED_INFO_%COUNT%",
                    Parent = Parent,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "0.3098039 0.2745098 0.572549 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_DROP_LIST_OPEN_TAKED")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-25.404 -17.357", OffsetMax = "25.403 -1.584"
                                                }
                                        }
                });
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_OpenDropListArgument_Taked", container.ToJson());
            }
            private void MNSYRPUDAKIPBERKJCFSIIMGQWNTTZKPCHLWVHYCQL()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "ModerationLabel",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%TITLE%", Font = "robotocondensed-regular.ttf", FontSize = 16, Align = TextAnchor.MiddleCenter, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "75.075 -136.612", OffsetMax = "230.125 -102.988"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "ModerationIcon",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_MODERATION_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "230.88 -125.3", OffsetMax = "241.88 -114.3"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "ModeratorMuteMenu",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_PANEL_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "81.071 -144.188", OffsetMax = "222.881 -129.752"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0.95"
                                        },
                    Button = {
                                                Command = "%COMMAND_MUTE_MENU%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%TEXT_MUTE_MENU%",
                                                FontSize = 9,
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-regular.ttf"
                                        }
                }, "ModeratorMuteMenu", "ModeratorMuteMenu_Btn");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Moderation", container.ToJson());
            }
            private void LEBLZPWRRJHZEAMHVCAJAASMTSUOBDDBWUBBPLNEXITFU()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "ModeratorMuteAllChat",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_PANEL_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "81.07 -161.818", OffsetMax = "222.88 -147.382"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0.95"
                                        },
                    Button = {
                                                Command = "%COMMAND_MUTE_ALLCHAT%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%TEXT_MUTE_ALLCHAT%",
                                                FontSize = 9,
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-regular.ttf"
                                        }
                }, "ModeratorMuteAllChat", "ModeratorMuteAllChat_Btn");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Administation_AllChat", container.ToJson());
            }
            private void HWJADAQBNKLORGUHPNGGCKYKRJOWMSHMSLLYFBACLUG()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = "ModeratorMuteAllVoice",
                    Parent = UI_Chat_Context,
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ELEMENT_PANEL_ICON")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "81.075 -179.448", OffsetMax = "222.885 -165.012"
                                                }
                                        }
                });
                container.Add(new CuiButton
                {
                    RectTransform = {
                                                AnchorMin = "0 0",
                                                AnchorMax = "1 0.95"
                                        },
                    Button = {
                                                Command = "%COMMAND_MUTE_ALLVOICE%",
                                                Color = "0 0 0 0"
                                        },
                    Text = {
                                                Text = "%TEXT_MUTE_ALLVOICE%",
                                                FontSize = 9,
                                                Align = TextAnchor.MiddleCenter,
                                                Font = "robotocondensed-regular.ttf"
                                        }
                }, "ModeratorMuteAllVoice", "ModeratorMuteAllVoice_Btn");
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Administation_AllVoce", container.ToJson());
            }
            private void PBUHJQSFZOGXXYITLTPVDZVGVWBOMDUHDHUQOHMWZBNEEO()
            {
                CuiElementContainer container = new CuiElementContainer();
                container.Add(new CuiElement
                {
                    Name = UI_Chat_Alert,
                    Parent = "Overlay",
                    Components = {
                                                new CuiRawImageComponent {
                                                        Color = "1 1 1 1", Png = ImageUi.ILLDUTVZOOLWSPAENJXKTEGPMTEHWESZIUVRJNUVKM("IQCHAT_ALERT_PANEL")
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0 1", AnchorMax = "0 1", OffsetMin = "0 -136.5", OffsetMax = "434 -51.5"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertTitle",
                    Parent = UI_Chat_Alert,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "<b>%TITLE%</b>", Font = "robotocondensed-bold.ttf", FontSize = 16, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-184.193 9.119", OffsetMax = "189.223 30.925"
                                                }
                                        }
                });
                container.Add(new CuiElement
                {
                    Name = "AlertText",
                    Parent = UI_Chat_Alert,
                    Components = {
                                                new CuiTextComponent {
                                                        Text = "%DESCRIPTION%", Font = "robotocondensed-regular.ttf", FontSize = 12, Align = TextAnchor.MiddleLeft, Color = "1 1 1 1"
                                                },
                                                new CuiRectTransformComponent {
                                                        AnchorMin = "0.5 0.5", AnchorMax = "0.5 0.5", OffsetMin = "-184.193 -27.133", OffsetMax = "189.223 9.119"
                                                }
                                        }
                });
                PYGAPHBWFNNJTSSDBEMXDMKGBGWRDSMEAIQLOHOEFIW("UI_Chat_Alert", container.ToJson());
            }
        }
        private BasePlayer HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(String Info)
        {
            String NameOrID = String.Empty;
            KeyValuePair<UInt64, GeneralInformation.RenameInfo> EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS = GeneralInfo.RenameList.FirstOrDefault(x => x.Value.RenameNick.Contains(Info) || x.Value.RenameID.ToString() == Info);
            if (EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.Value == null) NameOrID = Info;
            else NameOrID = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.Key.ToString();
            foreach (BasePlayer Finder in BasePlayer.activePlayerList)
            {
                if (Finder.displayName.ToLower().Contains(NameOrID.ToLower()) || Finder.userID.ToString() == NameOrID) return Finder;
            }
            return null;
        }
        private static IQChat _;
        void TEKAVZHVHRLFUKEBBMKMPLEONFQVIMJQWBWZGEIHLAUTFV(string id, string IISPQKUFCQYWWTFHZMGEBVXXJDYFPRMRTQXUOJYPMMSZ)
        {
            String[] PermissionsGroup = permission.GetGroupPermissions(IISPQKUFCQYWWTFHZMGEBVXXJDYFPRMRTQXUOJYPMMSZ);
            if (PermissionsGroup == null) return;
            foreach (String YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT in PermissionsGroup) ODASEJLVPVMIIVCFOINFBRXJPWSFENPJNFXGLULQOFY(id, YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT);
        }
        [ConsoleCommand("hmute")]
        void MPUEZSPCIZWNQJLMVIUITNFUWDDAPRKIRTEFOHJXHZNZ(ConsoleSystem.Arg arg)
        {
            if (arg.Player() != null)
                if (!permission.UserHasPermission(arg.Player().UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Args == null || arg.Args.Length != 3 || arg.Args.Length > 3)
            {
                EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "Invalid syntax, use : hmute Steam64ID Reason Time (seconds)" : "Неверный синтаксис,используйте : hmute Steam64ID Причина Время(секунды)");
                return;
            }
            string NameOrID = arg.Args[0];
            string Reason = arg.Args[1];
            Int32 TimeMute = 0;
            if (!Int32.TryParse(arg.Args[2], out TimeMute))
            {
                EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "Enter the time in numbers!" : "Введите время цифрами!");
                return;
            }
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "The player already has a chat lock" : "Игрок уже имеет блокировку чата");
                            return;
                        }
                        Info.MuteInfo.QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(MuteType.Chat, TimeMute);
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "Chat blocking issued to offline player" : "Блокировка чата выдана offline-игроку");
                        return;
                    }
                    else
                    {
                        EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    EQXWKLIXJJSXTZWQTZEAVINYYDEEGKUNJRBKHBTVOJI(arg.Player(), LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(target, MuteType.Chat, 0, arg.Player(), Reason, TimeMute, true, true);
        }
        public void RSXAOZLLMSYKAIVPOMRONVXFFXNZXBUAFJFLFABRZXFA(BasePlayer player, String Message)
        {
            Configuration.AnswerMessage Anwser = config.AnswerMessages;
            if (!Anwser.UseAnswer) return;
            foreach (KeyValuePair<String, Configuration.LanguageController> Anwsers in Anwser.AnswerMessageList) if (Message.Contains(Anwsers.Key.ToLower())) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(player, Anwsers.Value.LanguageMessages));
        }
        private
        const String PermissionAntiSpam = "iqchat.antispamabuse";
        public bool IsFake(UInt64 userID)
        {
            if (!IQFakeActive) return false;
            return (bool)IQFakeActive?.Call("IsFake", userID);
        }
        void MKPMGKFNJTBIQXXCXEAWVHEYTJGYAYCRTJERUYIATCGWVQTL(BasePlayer player, String DisplayName, String country, String userID)
        {
            Configuration.ControllerAlert.PlayerSession AlertSessionPlayer = config.ControllerAlertSetting.PlayerSessionSetting;
            if (AlertSessionPlayer.ConnectedAlert)
            {
                String Avatar = AlertSessionPlayer.ConnectedAvatarUse ? userID : String.Empty;
                if (AlertSessionPlayer.ConnectedWorld) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("WELCOME_PLAYER_WORLD", player.UserIDString, DisplayName, country), FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV: Avatar);
                else YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(GetLang("WELCOME_PLAYER", player.UserIDString, DisplayName), FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV: Avatar);
            }
        }
        void ISEGHAEFRSWEGMLRKOHSFIZWACSBHDDPUJRGYKMJZLDFLW(BasePlayer player, String DisplayName, String reason, String userID)
        {
            Configuration.ControllerAlert.PlayerSession AlertSessionPlayer = config.ControllerAlertSetting.PlayerSessionSetting;
            if (AlertSessionPlayer.DisconnectedAlert)
            {
                String Avatar = AlertSessionPlayer.ConnectedAvatarUse ? userID : String.Empty;
                String LangLeave = AlertSessionPlayer.DisconnectedReason ? GetLang("LEAVE_PLAYER_REASON", player.UserIDString, DisplayName, reason) : GetLang("LEAVE_PLAYER", player.UserIDString, DisplayName);
                YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(LangLeave, FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV: Avatar);
            }
        }
        private void PUFKCMTJASHGEHDYOOGJXUESABXTTETKDPDGCSBDBZRNQ(BasePlayer player, String reason)
        {
            Configuration.ControllerAlert.AdminSession AlertSessionAdmin = config.ControllerAlertSetting.AdminSessionSetting;
            Configuration.ControllerAlert.PlayerSession AlertSessionPlayer = config.ControllerAlertSetting.PlayerSessionSetting;
            GeneralInformation.RenameInfo EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(player.userID);
            if (AlertSessionPlayer.DisconnectedAlert)
            {
                if (!AlertSessionAdmin.DisconnectedAlertAdmin)
                    if (player.IsAdmin) return;
                String DisplayName = player.displayName;
                Configuration.ControllerMessage ControllerMessage = config.ControllerMessages;
                UInt64 UserID = player.userID;
                if (EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS != null)
                {
                    DisplayName = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameNick;
                    UserID = EOPYLXTHRJWWXUWXESRMXXTSWUFPIBCTJKDNCSBRJAKCNYFS.RenameID;
                }
                String Avatar = AlertSessionPlayer.ConnectedAvatarUse ? UserID.ToString() : String.Empty;
                String Message = String.Empty;
                if (AlertSessionPlayer.DisconnectedAlertRandom)
                {
                    VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.Clear();
                    Message = VCRJCEVDCUNZAOHNPFVRXZAHTSQNNUACDKMGJVMF.AppendFormat(GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(player, AlertSessionPlayer.RandomDisconnectedAlert.LanguageMessages), DisplayName, reason).ToString();
                }
                else Message = AlertSessionPlayer.DisconnectedReason ? GetLang("LEAVE_PLAYER_REASON", player.UserIDString, DisplayName, reason) : GetLang("LEAVE_PLAYER", player.UserIDString, DisplayName);
                if (!permission.UserHasPermission(player.UserIDString, PermissionHideDisconnection)) YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(Message, "", Avatar);
                XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB($"[{player.userID}] {Message}");
            }
        }
        void HCVNPQFNPUQMKAOZQWYXCODXWVNDHYDQBVUVXGPDF(BasePlayer player, String PlayerFormat, String Message, String Avatar, Chat.ChatChannel channel = Chat.ChatChannel.Global)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            String UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX = String.Empty; ;
            if (ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.XVDPKOKLPQWHLAGPFJQOWXYZAJKYIKZKMBFNEEMDHZK) UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX = $"{Message.ToLower().Substring(0, 1).ToUpper()}{Message.Remove(0, 1).ToLower()}";
            if (ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.SPSDYJDGFXLAXEPBDLDFQLVJUSKAXMHXMYGKQHAYGSFOQEQAP) foreach (String DetectedMessage in UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.Split(' ')) if (ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT.Contains(DetectedMessage.ToLower())) UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX = UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX.Replace(DetectedMessage, ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU);
            player.SendConsoleCommand("chat.add", channel, ulong.Parse(Avatar), $"{PlayerFormat}: {UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX}");
            player.ConsoleMessage($"{PlayerFormat}: {UJZNLGIQSIBATKHFZQAYEIPIAVUOVLRRGQNFZVJBKEBX}");
        }
        private void ZJPPIBOBJVOTCSYYRTCCFRQZLOGTCKGVRLOUHHNMOFOICH(BasePlayer JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, MuteType Type, String Reason = null, String KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI = null, BasePlayer Moderator = null)
        {
            Configuration.OtherSettings.General MuteChat = config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsMuted;
            if (!MuteChat.UseLogged) return;
            Configuration.ControllerMute.LoggedFuncion ControllerMuted = config.LUHOUUZHAFLUNAVMMSRJZDJWDDGZWZTVKABKIHANPMSDCUNLL.FZTIDDAEJCKXHYPCDQLBIYULCEIJEULPIUIUVZYFUCWQBIZ;
            String ActionReason = String.Empty;
            GeneralInformation.RenameInfo RenameSender = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID);
            UInt64 UserIDModeration = 0;
            String NickModeration = GetLang("IQCHAT_FUNCED_ALERT_TITLE_SERVER", JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.UserIDString);
            if (Moderator != null)
            {
                GeneralInformation.RenameInfo RenameModerator = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(Moderator.userID);
                UserIDModeration = RenameModerator != null ? RenameModerator.RenameID == 0 ? Moderator.userID : RenameModerator.RenameID : Moderator.userID;
                NickModeration = RenameModerator != null ? $"{RenameModerator.RenameNick ?? Moderator.displayName}" : Moderator.displayName;
            }
            String NickTarget = RenameSender != null ? $"{RenameSender.RenameNick ?? JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName}" : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.displayName;
            UInt64 UserIDTarget = RenameSender != null ? RenameSender.RenameID == 0 ? JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID : RenameSender.RenameID : JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI.userID;
            List<Fields> fields;
            switch (Type)
            {
                case MuteType.Chat:
                    {
                        if (Reason != null) ActionReason = LanguageEn ? "Mute chat" : "Блокировка чата";
                        else ActionReason = LanguageEn ? "Unmute chat" : "Разблокировка чата";
                        break;
                    }
                case MuteType.Voice:
                    {
                        if (Reason != null) ActionReason = LanguageEn ? "Mute voice" : "Блокировка голоса";
                        else ActionReason = LanguageEn ? "Unmute voice" : "Разблокировка голоса";
                        break;
                    }
                default:
                    break;
            }
            Int32 Color = 0;
            if (Reason != null)
            {
                fields = new List<Fields> {
                                        new Fields(LanguageEn ? "Nickname of the moderator" : "Ник модератора", NickModeration, true),
                                        new Fields(LanguageEn ? "Steam64ID Moderator" : "Steam64ID модератора", $"{UserIDModeration}", true),
                                        new Fields(LanguageEn ? "Action" : "Действие", ActionReason, false),
                                        new Fields(LanguageEn ? "Reason" : "Причина", Reason, false),
                                        new Fields(LanguageEn ? "Time" : "Время", KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI, false),
                                        new Fields(LanguageEn ? "Nick blocked" : "Ник заблокированного", NickTarget, true),
                                        new Fields(LanguageEn ? "Steam64ID blocked" : "Steam64ID заблокированного", $"{UserIDTarget}", true),
                                };
                if (ControllerMuted.AZFSAYKGFIGYURZPQUPMQVHERGHGBDKTFJIEPSPKKBONTAKCC)
                {
                    String Messages = YBBVPHZEIKYVGKVIRSIEIMNSZWLZCPUOFHAARBIZUR(JJQVEUGGJZPXSWKAYRSWVSLBWQVDFNMDOFMRKYISGHRKOEEI, ControllerMuted.ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO);
                    if (Messages != null && !String.IsNullOrWhiteSpace(Messages)) fields.Insert(fields.Count, new Fields(LanguageEn ? $"The latter {ControllerMuted.ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO} messages" : $"Последние {ControllerMuted.ZGTMIESABUQDFBYMTLIUZXEECOGTLQVEDTEDASADLO} сообщений", Messages, false));
                }
                Color = 14357781;
            }
            else
            {
                fields = new List<Fields> {
                                        new Fields(LanguageEn ? "Nickname of the moderator" : "Ник модератора", NickModeration, true),
                                        new Fields(LanguageEn ? "Steam64ID moderator" : "Steam64ID модератора", $"{UserIDModeration}", true),
                                        new Fields(LanguageEn ? "Action" : "Действие", ActionReason, false),
                                        new Fields(LanguageEn ? "Nick blocked" : "Ник заблокированного", NickTarget, true),
                                        new Fields(LanguageEn ? "Steam64ID blocked" : "Steam64ID заблокированного", $"{UserIDTarget}", true),
                                };
                Color = 1432346;
            }
            FancyMessage newMessage = new FancyMessage(null, false, new FancyMessage.Embeds[1] {
                                new FancyMessage.Embeds(null, Color, fields, new Authors("Chat Mute-History", null, "https://api-methods.st8.ru/v2/chat/icon", null), null)
                        });
            UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC($"{MuteChat.Webhooks}", newMessage.OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW());
        }
        public bool IsFake(String DisplayName)
        {
            if (!IQFakeActive) return false;
            return (bool)IQFakeActive?.Call("IsFake", DisplayName);
        }
        [ChatCommand("rename")]
        private void BWZOVADLISQDTVUZZOTCQDEQKGQNACIXDVEWDVLVOAGBRDU(BasePlayer GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, string command, string[] args)
        {
            if (!permission.UserHasPermission(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString, PermissionRename)) return;
            GeneralInformation General = GeneralInfo;
            if (General == null) return;
            if (GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, LanguageEn ? "You can only use this command while on the server" : "Вы можете использовать эту команду только находясь на сервере");
                return;
            }
            if (args.Length == 0 || args == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, lang.GetMessage("COMMAND_RENAME_NOTARG", this, GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString));
                return;
            }
            String Name = args[0];
            UInt64 ID = GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID;
            if (args.Length == 2 && args[1] != null && !String.IsNullOrWhiteSpace(args[1]))
                if (!UInt64.TryParse(args[1], out ID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, GetLang("COMMAND_RENAME_NOT_ID", GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString));
                    return;
                }
            if (General.RenameList.ContainsKey(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID))
            {
                General.RenameList[GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID].RenameNick = Name;
                General.RenameList[GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID].RenameID = ID;
            }
            else General.RenameList.Add(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.userID, new GeneralInformation.RenameInfo
            {
                RenameNick = Name,
                RenameID = ID
            });
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ, GetLang("COMMAND_RENAME_SUCCES", GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.UserIDString, Name, ID));
            GXMJRYSISXDLQJYYXEXCKEHPDWSTZELPCEIJJVTAJPWGYSUUJ.displayName = Name;
        }
        private Tuple<String, Boolean> TFPUIFCXSIEPJPLFKTAXQYWDDXNQXDZHLZTUMNOXSHEURV(String FormattingMessage, String ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU, List<String> GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT)
        {
            String ResultMessage = FormattingMessage;
            Boolean IsBadWords = false;
            foreach (String word in GTCWUSUEYKMLVFMLPQLDGCGVKSQNQRODXCDJWIUYSNUFLJT.Where(x => !x.Contains("*")))
            {
                MatchCollection matches = new Regex(@"\b(" + word + @")\b").Matches(ResultMessage);
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        String found = match.Groups[1].ToString();
                        String replaced = "";
                        for (int i = 0; i < found.Length; i++) replaced = replaced + ZWWFJGTIIFZDJSQNOZXELWKEYXGGTQCKKMNKBHOZQHZU;
                        ResultMessage = ResultMessage.Replace(found, replaced);
                        IsBadWords = true;
                    }
                    else break;
                }
            }
            return Tuple.Create(ResultMessage, IsBadWords);
        }
        [ChatCommand("mute")]
        void YOAQXCWAVJMRKRLZOJXDJWRSWECEITCMHMPBWMBEOYYK(BasePlayer Moderator, string cmd, string[] arg)
        {
            if (!permission.UserHasPermission(Moderator.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Length != 3 || arg.Length > 3)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Invalid syntax, use : mute Steam64ID/Nick Reason Time(seconds)" : "Неверный синтаксис, используйте : mute Steam64ID/Ник Причина Время(секунды)");
                return;
            }
            string NameOrID = arg[0];
            string Reason = arg[1];
            Int32 TimeMute = 0;
            if (!Int32.TryParse(arg[2], out TimeMute))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Enter time in numbers!" : "Введите время цифрами!");
                return;
            }
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "The player already has a chat lock" : "Игрок уже имеет блокировку чата");
                            return;
                        }
                        Info.MuteInfo.QQODASEWBJLCUAZTEZSBOFTQBPVYLVIDCDNMXXQYTEUZ(MuteType.Chat, TimeMute);
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Chat blocking issued to offline player" : "Блокировка чата выдана offline-игроку");
                        return;
                    }
                    else
                    {
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            KBERQTKTKIQUPPMIKFUKQXAUWWAKBJQPDEDVBOVW(target, MuteType.Chat, 0, Moderator, Reason, TimeMute, false, true);
        }
        void WDFHHPKUSBCXIUTZSSCHZJYCKDCISOKXGSAAXXAD(string LDWVHWNDNGLBCGOHVJOSBCPGWMLTHAKBZNCMUTWBP)
        {
            if (!config.ReferenceSetting.IQFakeActiveSettings.UseIQFakeActive) return;
            List<FakePlayer> ContentDeserialize = JsonConvert.DeserializeObject<List<FakePlayer>>(LDWVHWNDNGLBCGOHVJOSBCPGWMLTHAKBZNCMUTWBP);
            PlayerBases = ContentDeserialize;
            PrintWarning(LanguageEn ? "IQChat - successfully synced with IQFakeActive" : "IQChat - успешно синхронизирована с IQFakeActive");
            PrintWarning("=============SYNC==================");
        }
        void SPKMDOSHFWGWDANFCWENCBDQERPUSCURYQHUOQGPKAMSEB(string id, string IISPQKUFCQYWWTFHZMGEBVXXJDYFPRMRTQXUOJYPMMSZ)
        {
            String[] PermissionsGroup = permission.GetGroupPermissions(IISPQKUFCQYWWTFHZMGEBVXXJDYFPRMRTQXUOJYPMMSZ);
            if (PermissionsGroup == null) return;
            foreach (String YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT in PermissionsGroup) JNILYMFZPWGMXIMUQOJOGMMHHDCYZCGEKVSQOSFXST(id, YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT);
        }
        private enum SelectedAction
        {
            Mute,
            Ignore
        }
        private String XLevel_GetLevel(BasePlayer player)
        {
            if (!XLevels || !config.ReferenceSetting.XLevelsSettings.UseXLevels) return String.Empty;
            return GetLang("XLEVELS_SYNTAX_PREFIX", player.UserIDString, (Int32)XLevels?.CallHook("API_GetLevel", player));
        }
        [ConsoleCommand("alertui")]
        private void RMVUAWQOQLTHMYXPDBPXNTSQMQOCCPLMDOYHWHTUH(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args.Args);
        }
        public enum MuteType
        {
            Chat,
            Voice
        }
        private void QIVJTQMLJQODPYUFIKIOMBAGEYAQSVHVQMCKUCWY(BasePlayer player, String Message)
        {
            if (!LastMessagesChat.ContainsKey(player)) LastMessagesChat.Add(player, new List<String> {
                                Message
                        });
            else LastMessagesChat[player].Add(Message);
        }
        public List<String> KeyImages = new List<String> {
                        "UI_IQCHAT_CONTEXT_NO_RANK",
                        "UI_IQCHAT_CONTEXT_RANK",
                        "IQCHAT_INFORMATION_ICON",
                        "IQCHAT_SETTING_ICON",
                        "IQCHAT_MULTIPLE_ICON",
                        "IQCHAT_PANEL_BACKGROUND",
                        "IQCHAT_MULTIPLE_PANEL_BACKGROUND",
                        "IQCHAT_IGNORE_INFO_ICON",
                        "IQCHAT_MODERATION_ICON",
                        "IQCHAT_ELEMENT_PANEL_ICON",
                        "IQCHAT_ELEMENT_PREFIX_MULTI_TAKE_ICON",
                        "IQCHAT_ELEMENT_SLIDER_ICON",
                        "IQCHAT_ELEMENT_SLIDER_LEFT_ICON",
                        "IQCHAT_ELEMENT_SLIDER_RIGHT_ICON",
                        "IQCHAT_ELEMENT_DROP_LIST_OPEN_ICON",
                        "IQCHAT_ELEMENT_DROP_LIST_OPEN_ARGUMENT_ICON",
                        "IQCHAT_ELEMENT_DROP_LIST_OPEN_TAKED",
                        "IQCHAT_ELEMENT_SETTING_CHECK_BOX",
                        "IQCHAT_ALERT_PANEL",
                        "IQCHAT_MUTE_AND_IGNORE_PANEL",
                        "IQCHAT_MUTE_AND_IGNORE_SEARCH",
                        "IQCHAT_MUTE_AND_IGNORE_PAGE_PANEL",
                        "IQCHAT_MUTE_AND_IGNORE_PLAYER",
                        "IQCHAT_MUTE_AND_IGNORE_PLAYER_STATUS",
                        "IQCHAT_IGNORE_ALERT_PANEL",
                        "IQCHAT_IGNORE_ALERT_ICON",
                        "IQCHAT_IGNORE_ALERT_BUTTON_YES",
                        "IQCHAT_IGNORE_ALERT_BUTTON_NO",
                        "IQCHAT_MUTE_ALERT_PANEL",
                        "IQCHAT_MUTE_ALERT_ICON",
                        "IQCHAT_MUTE_ALERT_PANEL_REASON",
                };
        void RFUYZYAMRZJMTOPHPFVQVSOISNDVKKFNJYVVFHEAAEBVYJ(BasePlayer player, string DisplayName, string Message)
        {
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, GetLang("COMMAND_PM_SEND_MSG", player.UserIDString, DisplayName, Message));
            if (UserInformation.ContainsKey(player.userID))
                if (UserInformation[player.userID].Settings.TurnSound) Effect.server.Run(config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ.JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO, player.GetNetworkPosition());
        }
        private void XNCFXBHUYQMFLUECGUWCVSTCHAVQRQTJJRGIIEHLCEWFTCSF(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, BasePlayer WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ, String TXSZXMVRLBSEFIJTUFYNAMQIAIOCVBAUMMMOBJEBXEJKVNEA)
        {
            Configuration.OtherSettings.General PMChat = config.NQJSGMXVFZFRQBIXALOOMIBWORLIRWIVIHKZWHHBVLRTB.LogsPMChat;
            if (!PMChat.UseLogged) return;
            GeneralInformation.RenameInfo SenderRename = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID);
            GeneralInformation.RenameInfo ReciepterRename = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ.userID);
            UInt64 UserIDSender = SenderRename != null ? SenderRename.RenameID == 0 ? XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID : SenderRename.RenameID : XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID;
            UInt64 UserIDReciepter = ReciepterRename != null ? ReciepterRename.RenameID == 0 ? WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ.userID : ReciepterRename.RenameID : WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ.userID;
            String SenderName = SenderRename != null ? ReciepterRename.RenameNick ?? XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName : XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName;
            String ReciepterName = ReciepterRename != null ? ReciepterRename.RenameNick ?? WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ.displayName : WPWSWLYNKCVABJOQZUKTVNWKBPEBMCMNDBGZJDQZ.displayName;
            List<Fields> fields = new List<Fields> {
                                new Fields(LanguageEn ? "Sender" : "Отправитель", $"{SenderName}({UserIDSender})", true),
                                new Fields(LanguageEn ? "Recipient" : "Получатель", $"{ReciepterName}({UserIDReciepter})", true),
                                new Fields(LanguageEn ? "Message" : "Сообщение", TXSZXMVRLBSEFIJTUFYNAMQIAIOCVBAUMMMOBJEBXEJKVNEA, false),
                        };
            FancyMessage newMessage = new FancyMessage(null, false, new FancyMessage.Embeds[1] {
                                new FancyMessage.Embeds(null, 16608621, fields, new Authors("Chat PM-History", null, "https://api-methods.st8.ru/v2/chat/icon", null), null)
                        });
            UTMWAAVREZHOWTNHLGSPMZSJNEIWPYDQVVMJIFXVYC($"{PMChat.Webhooks}", newMessage.OQRNYCINFJWYKAUKMULRBHJUEOQEVSUXDPBSDTXUUQYW());
        }
        private Dictionary<BasePlayer, InformationOpenedUI> LocalBase = new Dictionary<BasePlayer, InformationOpenedUI>();
        private String BVBCHAETAYXGRCIXCWUOWUBNKZRWOIEHPVQVRHBQBOIFKFLB(String text)
        {
            String hrefPattern = "([A-Za-z0-9-А-Яа-я]|https?://)[^ ]+\\.(com|lt|net|org|gg|ru|рф|int|info|ru.com|ru.net|com.ru|net.ru|рус|org.ru|moscow|biz|орг|su)";
            Regex rgx = new Regex(hrefPattern, RegexOptions.IgnoreCase);
            return config.ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.AllowedLinkNick.Contains(rgx.Match(text).Value) ? text : rgx.Replace(text, "").Trim();
        }
        private
        const String PermissionHideDisconnection = "iqchat.hidedisconnection";
        public Boolean YIJUOPAZEAZKFGZDCFOSXJPVSXTDLDNUYRDEHTOYGVYH(String OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA, String shortname, UInt64 skin = 0) => (Boolean)ImageLibrary?.Call("AddImage", OZSCOVRUYAGJHWLOFLQZEQJGEXOBPDYJZPLSMGXNMYA, shortname, skin);
        String HQFYQYHTNRHJIERTPQWMMFUUDMHLWDFOPHHSZJYWICEQU(ulong ID)
        {
            if (!UserInformation.ContainsKey(ID)) return String.Empty;
            return UserInformation[ID].Info.ColorNick;
        }
        private enum ElementsSettingsType
        {
            PM,
            Broadcast,
            Alert,
            Sound
        }
        void AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, BasePlayer Recipient, string[] arg)
        {
            if (MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY == null)
            {
                PrintWarning(LanguageEn ? "We generate the interface, wait for a message about successful generation" : "Генерируем интерфейс, ожидайте сообщения об успешной генерации");
                return;
            }
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg);
            if (Message == null) return;
            XVTPPUQLGGAWQEFCYNXMQNCPAGOBJBTEXHCRTMTDWO(Recipient, Message);
        }
        String TKRMUOPPBBWLUERVXKMTTAXZUFRZDKBEAVTXUJIQZA(UInt64 ID)
        {
            if (!UserInformation.ContainsKey(ID)) return String.Empty;
            return UserInformation[ID].Info.ColorMessage;
        }
        private object GVNOUFNFTDBOSMRROWPLRZRLZKTANCVTTURDGQWUQF(String message, String name)
        {
            if (config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.BDKMGKGZLVXEBMLQZYSZGUUEEIVSCYHTWIWERPVJRM)
                if (message.Contains("gave") && name == "SERVER") return true;
            return null;
        }
        void AZHAKDSTTKOOGECPKLMRQHHVYVOKXZVUMRQLRKIXUIC(string id, string YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT) => JNILYMFZPWGMXIMUQOJOGMMHHDCYZCGEKVSQOSFXST(id, YLDFXDTNXYDYOOLUWPZTRXFTYAREILIETYEEQYAXDNYWT);
        void Alert(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, string[] arg, Boolean IsAdmin)
        {
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg);
            if (Message == null) return;
            YTWAWPXUEUGZVPHHRANSVEBHKKHRBWSIFKIIFNQLL(Message, AZCYAVKPESDPYIYADBVPMFUYSHIXLWRJSYIRWRFCE: IsAdmin);
            if (config.RustPlusSettings.UseRustPlus) foreach (BasePlayer playerList in BasePlayer.activePlayerList) NotificationList.SendNotificationTo(playerList.userID, NotificationChannel.SmartAlarm, config.RustPlusSettings.DisplayNameAlert, Message, Util.GetServerPairingData());
        }
        public class Fields
        {
            public string name
            {
                get;
                set;
            }
            public string value
            {
                get;
                set;
            }
            public bool inline
            {
                get;
                set;
            }
            public Fields(string name, string value, bool inline)
            {
                this.name = name;
                this.value = value;
                this.inline = inline;
            }
        }
        private void EFKYEBMIENRSRMCPOIVTOUCPNQXADPXHFYRSKPGWNMQ(BasePlayer player, SelectedAction Action, IEnumerable<BasePlayer> PlayerList, IEnumerable<FakePlayer> FakePlayerList = null)
        {
            User ABHRAHBITZPKJJCWGMJOKJXBGJTCYOTNFZQNAFKTZQXVTDQB = UserInformation[player.userID];
            if (ABHRAHBITZPKJJCWGMJOKJXBGJTCYOTNFZQNAFKTZQXVTDQB == null) return;
            Int32 AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG = 0, Y = 0;
            String ARHVQLQEFKROZKFFCEJSOVBCQPUMCIDSRZXWLROOA = "0.5803922 1 0.5372549 1";
            String VUSFAFSPRYGJOFPFFBQEBXGYXAMITKPVSEAGKLPOTMQ = "0.8962264 0.2578764 0.3087685 1";
            String Color = String.Empty;
            if (IQFakeActive && FakePlayerList != null)
            {
                foreach (var playerInList in FakePlayerList)
                {
                    String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Player");
                    if (Interface == null) return;
                    String DisplayName = playerInList.DisplayName;
                    if (GeneralInfo.RenameList.ContainsKey(playerInList.UserID))
                        if (!String.IsNullOrWhiteSpace(GeneralInfo.RenameList[playerInList.UserID].RenameNick)) DisplayName = GeneralInfo.RenameList[playerInList.UserID].RenameNick;
                    Interface = Interface.Replace("%OFFSET_MIN%", $"{-225.795 - (-281.17 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {97.54 - (46.185 * Y)}");
                    Interface = Interface.Replace("%OFFSET_MAX%", $"{-26.345 - (-281.17 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {132.03 - (46.185 * Y)}");
                    Interface = Interface.Replace("%DISPLAY_NAME%", $"{DisplayName}");
                    Interface = Interface.Replace("%COMMAND_ACTION%", $"newui.cmd action.mute.ignore ignore.and.mute.controller {Action} confirm.alert {playerInList.UserID}");
                    switch (Action)
                    {
                        case SelectedAction.Mute:
                            if (UserInformation.ContainsKey(playerInList.UserID) && UserInformation[playerInList.UserID] != null && (UserInformation[playerInList.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || UserInformation[playerInList.UserID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice))) Color = VUSFAFSPRYGJOFPFFBQEBXGYXAMITKPVSEAGKLPOTMQ;
                            else Color = ARHVQLQEFKROZKFFCEJSOVBCQPUMCIDSRZXWLROOA;
                            break;
                        case SelectedAction.Ignore:
                            if (ABHRAHBITZPKJJCWGMJOKJXBGJTCYOTNFZQNAFKTZQXVTDQB.Settings.IsIgnored(playerInList.UserID)) Color = VUSFAFSPRYGJOFPFFBQEBXGYXAMITKPVSEAGKLPOTMQ;
                            else Color = ARHVQLQEFKROZKFFCEJSOVBCQPUMCIDSRZXWLROOA;
                            break;
                        default:
                            break;
                    }
                    Interface = Interface.Replace("%COLOR%", Color);
                    AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG++;
                    if (AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG == 2)
                    {
                        AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG = 0;
                        Y++;
                    }
                    CuiHelper.AddUi(player, Interface);
                }
            }
            else
            {
                foreach (var playerInList in PlayerList)
                {
                    String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Mute_And_Ignore_Player");
                    if (Interface == null) return;
                    User Info = UserInformation[playerInList.userID];
                    if (Info == null) continue;
                    if (playerInList.userID == player.userID) continue;
                    String DisplayName = playerInList.displayName;
                    if (GeneralInfo.RenameList.ContainsKey(playerInList.userID))
                        if (!String.IsNullOrWhiteSpace(GeneralInfo.RenameList[playerInList.userID].RenameNick)) DisplayName = GeneralInfo.RenameList[playerInList.userID].RenameNick;
                    Interface = Interface.Replace("%OFFSET_MIN%", $"{-225.795 - (-281.17 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {97.54 - (46.185 * Y)}");
                    Interface = Interface.Replace("%OFFSET_MAX%", $"{-26.345 - (-281.17 * AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG)} {132.03 - (46.185 * Y)}");
                    Interface = Interface.Replace("%DISPLAY_NAME%", $"{DisplayName}");
                    Interface = Interface.Replace("%COMMAND_ACTION%", $"newui.cmd action.mute.ignore ignore.and.mute.controller {Action} confirm.alert {playerInList.userID}");
                    switch (Action)
                    {
                        case SelectedAction.Mute:
                            if (Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat) || Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Voice)) Color = VUSFAFSPRYGJOFPFFBQEBXGYXAMITKPVSEAGKLPOTMQ;
                            else Color = ARHVQLQEFKROZKFFCEJSOVBCQPUMCIDSRZXWLROOA;
                            break;
                        case SelectedAction.Ignore:
                            if (ABHRAHBITZPKJJCWGMJOKJXBGJTCYOTNFZQNAFKTZQXVTDQB.Settings.IsIgnored(playerInList.userID)) Color = VUSFAFSPRYGJOFPFFBQEBXGYXAMITKPVSEAGKLPOTMQ;
                            else Color = ARHVQLQEFKROZKFFCEJSOVBCQPUMCIDSRZXWLROOA;
                            break;
                        default:
                            break;
                    }
                    Interface = Interface.Replace("%COLOR%", Color);
                    AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG++;
                    if (AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG == 2)
                    {
                        AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG = 0;
                        Y++;
                    }
                    CuiHelper.AddUi(player, Interface);
                }
            }
        }
        public void ZXUFHTIMNIUJCVLNDMEOPJNTVJEYBYGBDDQPWSSKGKUXDHPPE(BasePlayer player) => IQPersonal?.CallHook("API_DETECTED_BAD_WORDS", player.userID);
        Boolean TAIBIPKAKYOKLOBTGZFVQKUUIFPQQNTPUIFFTBUAEWITVWZ(UInt64 ID)
        {
            if (!UserInformation.ContainsKey(ID)) return false;
            return UserInformation[ID].MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat);
        }
        [ChatCommand("alertuip")]
        private void VKAQKICIGNTDAUKWFZPCIWZEEEQUCAZLGJUGNCELGX(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] args)
        {
            if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            if (args == null || args.Length == 0)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "You didn't specify a player!" : "Вы не указали игрока!");
                return;
            }
            BasePlayer Recipient = BasePlayer.Find(args[0]);
            if (Recipient == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, LanguageEn ? "The player is not on the server!" : "Игрока нет на сервере!");
                return;
            }
            AXVLSUOBKTFMZGRSDJIZWCRFIULAEMGSCUXLXPANYTHXS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, Recipient, args.Skip(1).ToArray());
        }
        private static InterfaceBuilder MHKSHGLNXWHXNTHATKVGILRJEIUULBKOGBMQPTBNY;
        String API_GET_DEFAULT_NICK_COLOR() => config.ControllerConnect.WHKQMMFRJKMEEOQXMVDXNVFVPLNCRFOTPSXOOOWJPGW.NUKMGSWCPLVDSQPUIPBPPPOZFJMWMRQUOJJEJVAGPXVBETYBK;
        private
        const String XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE = "iqchat.muteuse";
        void YTYSSSAUILHCMBCBMBSAZBLZOULCOFDISMVKXSFZVSVVAN(string name, string CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO)
        {
            String[] PlayerGroups = permission.GetUsersInGroup(name);
            if (PlayerGroups == null) return;
            foreach (String playerInfo in PlayerGroups)
            {
                BasePlayer player = BasePlayer.FindByID(UInt64.Parse(playerInfo.Substring(0, 17)));
                if (player == null) return;
                JNILYMFZPWGMXIMUQOJOGMMHHDCYZCGEKVSQOSFXST(player.UserIDString, CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO);
            }
        }
        [ChatCommand("pm")]
        void BCHYUCQQXHZDXHYGCHYKZFREUWSEHFQYAUJZHGIGBVYCXOHSW(BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, String cmd, String[] arg)
        {
            Configuration.ControllerMessage ControllerMessages = config.ControllerMessages;
            if (!ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ.LCAQTFAVHYWZPVROWXDBTHSXBWFECQHIMCZEBUTALSPFMPS) return;
            if (arg.Length == 0 || arg == null)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, lang.GetMessage("COMMAND_PM_NOTARG", this, XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            Configuration.ControllerMessage.TurnedFuncional.AntiNoob.Settings YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM = config.ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.PNEPQFOCXJMULXRCVVRHIOSMCZBBSIREOCHXVWSMMYQIU.GDDJBIYPAQMCOWXLFKPJXDJYSQPDJMNXWMJRDPAVWUWUGSMS;
            if (YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.BBOISSMKEGGIJBLVWENRHWEJAILJOGIJQUSMNYWZNTSKP)
                if (OQUWAJZQVBFAFBBDNMOHFGEZLVTHKDWXWCJCQIYEXCJREH(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID, YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IQCHAT_INFO_ANTI_NOOB_PM", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, FormatTime(UserInformationConnection[XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID].EWEIMARKILVKEQRGSEHECRZMFNKKCXNUEEPLGUJWFRBQVX(YQVFGQFZFCRYSYMPTDVGHBSRNODHCMKVDNJEOQJM.KBKRKSLHIEWFHJGCVYYWSPIZHXINDNETUUYKZWWPYI), XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString)));
                    return;
                }
            String NameUser = arg[0];
            if (config.ReferenceSetting.IQFakeActiveSettings.UseIQFakeActive)
                if (IQFakeActive)
                    if (IsFake(NameUser))
                    {
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_SUCCESS", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, string.Join(" ", arg.ToArray()).Replace(NameUser, ""), NameUser));
                        return;
                    }
            BasePlayer TargetUser = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameUser);
            if (TargetUser == null || NameUser == null || !UserInformation.ContainsKey(TargetUser.userID))
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_NOT_USER", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            User InfoTarget = UserInformation[TargetUser.userID];
            User InfoSender = UserInformation[XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID];
            if (!InfoTarget.Settings.TurnPM)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("FUNC_MESSAGE_PM_TURN_FALSE", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            if (ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.YOYDFZWPKTSBZMXSDTPCTOHZRKBSOYICBBTYMIYLXKSPWTCHW)
            {
                if (InfoTarget.Settings.IsIgnored(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IGNORE_NO_PM", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                    return;
                }
                if (InfoSender.Settings.IsIgnored(TargetUser.userID))
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("IGNORE_NO_PM_ME", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                    return;
                }
            }
            String Message = KNIQYLGRTMFLVSSTHBZTTSCYNYGKNVQERAIIIGLWGL(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, arg.Skip(1).ToArray());
            if (Message == null || Message.Length <= 0)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_NOT_NULL_MSG", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString));
                return;
            }
            Message = Message.EscapeRichText();
            if (Message.Length > 125) return;
            PMHistory[TargetUser] = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY;
            PMHistory[XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY] = TargetUser;
            GeneralInformation.RenameInfo WGBXWFMZOGCBHBBJEMHJMEWZIBQLUNLJHAEPKVTGURVTHH = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID);
            GeneralInformation.RenameInfo RenamerTarget = GeneralInfo.BSDUCZRCBLRNDVSEITWLBCTVREKWLNOGMKVTEPOMHGQCD(TargetUser.userID);
            String DisplayNameSender = WGBXWFMZOGCBHBBJEMHJMEWZIBQLUNLJHAEPKVTGURVTHH != null ? WGBXWFMZOGCBHBBJEMHJMEWZIBQLUNLJHAEPKVTGURVTHH.RenameNick ?? XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName : XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName;
            String TargetDisplayName = RenamerTarget != null ? RenamerTarget.RenameNick ?? TargetUser.displayName : TargetUser.displayName;
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(TargetUser, GetLang("COMMAND_PM_SEND_MSG", TargetUser.UserIDString, DisplayNameSender, Message));
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, GetLang("COMMAND_PM_SUCCESS", XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, Message, TargetDisplayName));
            if (InfoTarget.Settings.TurnSound) Effect.server.Run(ControllerMessages.NKBIKBNYSKLSATWYVTTLKTMGQHKMGLFUETHOGGOQY.XMRSEMTFGAURMRENJPSIFIPUHZCEVJXKSUBPJZDEKJ.JCNYURAEKDPXAWTRRNMMWMMCECQASMKLEKUACJOUCUUYEWAO, TargetUser.GetNetworkPosition());
            XJHWDGGWGXFUUBCJVRZCFVQTBHDZGIXRJHUAFIEPICXTQB(LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}) sent a message to the player - {TargetUser.displayName}({TargetDisplayName})\nMESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}) отправил сообщение игроку - {TargetUser.displayName}({TargetDisplayName})\nСООБЩЕНИЕ : {Message}");
            XNCFXBHUYQMFLUECGUWCVSTCHAVQRQTJJRGIIEHLCEWFTCSF(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, TargetUser, Message);
            RCon.Broadcast(RCon.LogType.Chat, new Chat.ChatEntry
            {
                Message = LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {TargetUser.displayName} : MESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {TargetUser.displayName} : СООБЩЕНИЕ : {Message}",
                UserId = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString,
                Username = XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName,
                Channel = Chat.ChatChannel.Global,
                Time = (DateTime.UtcNow.Hour * 3600) + (DateTime.UtcNow.Minute * 60),
                Color = "#3f4bb8",
            });
            PrintWarning(LanguageEn ? $"PRIVATE MESSAGES : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {TargetUser.displayName} : MESSAGE : {Message}" : $"ЛИЧНЫЕ СООБЩЕНИЯ : {XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.displayName}({XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.userID}) -> {TargetUser.displayName} : СООБЩЕНИЕ : {Message}");
        }
        public String FormatTime(Double UPHGZLTYETCQVEITMRHHWBHPIWZCOGVELYBXOEBDKDHIKWHX, String UserID = null)
        {
            TimeSpan time = TimeSpan.FromSeconds(UPHGZLTYETCQVEITMRHHWBHPIWZCOGVELYBXOEBDKDHIKWHX);
            String Result = String.Empty;
            String Days = GetLang("TITLE_FORMAT_DAYS", UserID);
            String Hourse = GetLang("TITLE_FORMAT_HOURSE", UserID);
            String Minutes = GetLang("TITLE_FORMAT_MINUTES", UserID);
            String Seconds = GetLang("TITLE_FORMAT_SECONDS", UserID);
            if (time.Seconds != 0) Result = $"{Format(time.Seconds, Seconds, Seconds, Seconds)}";
            if (time.Minutes != 0) Result = $"{Format(time.Minutes, Minutes, Minutes, Minutes)}";
            if (time.Hours != 0) Result = $"{Format(time.Hours, Hourse, Hourse, Hourse)}";
            if (time.Days != 0) Result = $"{Format(time.Days, Days, Days, Days)}";
            return Result;
        }
        [ConsoleCommand("alert")]
        private void TNCDAVKCEYKLISRBCDXYZVYSIDHPGFPZIVMCWXUNOECK(ConsoleSystem.Arg args)
        {
            BasePlayer XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY = args.Player();
            if (XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY != null)
                if (!permission.UserHasPermission(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY.UserIDString, ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB)) return;
            Alert(XYBALYRWGXZXJSTACAKQDQOVIOBICROZMFRDGYEAJSPRUQAY, args.Args, false);
        }
        void OnPlayerDisconnected(BasePlayer player, string reason) => PUFKCMTJASHGEHDYOOGJXUESABXTTETKDPDGCSBDBZRNQ(player, reason);
        void QNGLWMDUYMXOJUWOVVZJKDNGOEFIJKUTOXSQADKTLFKIPNND(String Message, Chat.ChatChannel channel = Chat.ChatChannel.Global, String XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH = null, String FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV = null, String QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU = null)
        {
            foreach (BasePlayer p in BasePlayer.activePlayerList) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(p, Message, XPRWVGRXXGLYODIYRMMVJXXFVMERKIIVSPRFWYQNQABDH, FVKATVKVVZYRNDMSROKNIMRWRULKTCISGOGZQIXLYCOBV, QACAQPYSGSEOIYJABTQFKYWNBIQYPFXPBCDKITLTUOHNU);
        }
        private
        const String ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB = "iqchat.alertuse";
        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                try
                {
                    configOld = Config.ReadObject<ConfigurationOld>();
                    if (configOld != null)
                    {
                        string file = $"{Interface.Oxide.ConfigDirectory}{Path.DirectorySeparatorChar}{Name}.backup_old_system.{DateTime.Now:yyyy-MM-dd hh-mm-ss}.json";
                        Config.WriteObject(configOld, false, file);
                        PrintWarning($"A BACKUP OF THE OLD CONFIGURATION WAS CREATED - {file}");
                    }
                }
                catch { }
                config = Config.ReadObject<Configuration>();
                if (config == null) LoadDefaultConfig();
                if (config.ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.AllowedLinkNick == null || config.ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.AllowedLinkNick.Count == 0) config.ControllerMessages.HESUARCUDOSKTTYUSCQARHEQNGLISOEDNPLHNVHTKMHQCUZ.CJMYCQRCLZDLRGLANPSDOTXFFMHKXNDWQEVOTIQZLIZMJZJAC.AllowedLinkNick = new List<String>() {
                                        "mysite.com"
                                };
            }
            catch
            {
                PrintWarning(LanguageEn ? $"Error #132 read configuration 'oxide/config/{Name}', create a new configuration!!" : $"Ошибка #132 чтения конфигурации 'oxide/config/{Name}', создаём новую конфигурацию!!");
                LoadDefaultConfig();
            }
            NextTick(SaveConfig);
        }
        private void ZSICBLMAAWRGVKNSDAMBFNRLGXFTEQBRCKKRMRMLFQAHSMQUW(BasePlayer player, TakeElementUser RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR, Int32 Page = 0)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_OpenDropList");
            if (Interface == null) return;
            if (!LocalBase.ContainsKey(player)) return;
            String Title = String.Empty;
            String NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA = String.Empty;
            List<Configuration.ControllerParameters.AdvancedFuncion> InfoUI = new List<Configuration.ControllerParameters.AdvancedFuncion>();
            switch (RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR)
            {
                case TakeElementUser.MultiPrefix:
                case TakeElementUser.Prefix:
                    {
                        InfoUI = LocalBase[player].ElementsPrefix;
                        Title = GetLang("IQCHAT_CONTEXT_SLIDER_PREFIX_TITLE", player.UserIDString);
                        NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA = GetLang("IQCHAT_CONTEXT_DESCRIPTION_PREFIX", player.UserIDString);
                        break;
                    }
                case TakeElementUser.Nick:
                    {
                        InfoUI = LocalBase[player].ElementsNick;
                        Title = GetLang("IQCHAT_CONTEXT_SLIDER_NICK_COLOR_TITLE", player.UserIDString);
                        NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA = GetLang("IQCHAT_CONTEXT_DESCRIPTION_NICK", player.UserIDString);
                        break;
                    }
                case TakeElementUser.Chat:
                    {
                        InfoUI = LocalBase[player].ElementsChat;
                        Title = GetLang("IQCHAT_CONTEXT_SLIDER_MESSAGE_COLOR_TITLE", player.UserIDString);
                        NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA = GetLang("IQCHAT_CONTEXT_DESCRIPTION_CHAT", player.UserIDString);
                        break;
                    }
                case TakeElementUser.Rank:
                    {
                        InfoUI = LocalBase[player].ElementsRanks;
                        Title = GetLang("IQCHAT_CONTEXT_SLIDER_IQRANK_TITLE", player.UserIDString);
                        NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA = GetLang("IQCHAT_CONTEXT_DESCRIPTION_RANK", player.UserIDString);
                        break;
                    }
                default:
                    break;
            }
            Interface = Interface.Replace("%TITLE%", Title);
            Interface = Interface.Replace("%DESCRIPTION%", NHCWWEYTJMEXYTDOQNYZWIHZVUYDYHZUCFZNAGBRA);
            String CommandRight = InfoUI.Skip(9 * (Page + 1)).Count() > 0 ? $"newui.cmd droplist.controller page.controller {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR} + {Page}" : String.Empty;
            String CommandLeft = Page != 0 ? $"newui.cmd droplist.controller page.controller {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR} - {Page}" : String.Empty;
            Interface = Interface.Replace("%NEXT_BTN%", CommandRight);
            Interface = Interface.Replace("%BACK_BTN%", CommandLeft);
            Interface = Interface.Replace("%COLOR_RIGHT%", String.IsNullOrWhiteSpace(CommandRight) ? "1 1 1 0.1" : "1 1 1 1");
            Interface = Interface.Replace("%COLOR_LEFT%", String.IsNullOrWhiteSpace(CommandLeft) ? "1 1 1 0.1" : "1 1 1 1");
            CuiHelper.DestroyUi(player, "OpenDropList");
            CuiHelper.AddUi(player, Interface);
            Int32 Count = 0;
            Int32 AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG = 0, Y = 0;
            foreach (Configuration.ControllerParameters.AdvancedFuncion Info in InfoUI.Skip(9 * Page).Take(9))
            {
                UOSMCEYLXJTSZFSZVMVSYSKEZNWTESKIWFXHWZOY(player, RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR, Info, AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG, Y, Count);
                if (RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR == TakeElementUser.MultiPrefix && UserInformation[player.userID].Info.PrefixList.Contains(Info.Argument)) UOSMCEYLXJTSZFSZVMVSYSKEZNWTESKIWFXHWZOY(player, Count);
                Count++;
                AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG++;
                if (AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG == 3)
                {
                    AEQPHUAGQWFXRRZZQAMKMBNDMVBJRGJXKAUHEEPSIDIG = 0;
                    Y++;
                }
            }
        }
        internal class FlooderInfo
        {
            public Double Time;
            public String WZEJTHQVFVPFIEZDBBGVVBNKUTUQNKMHYYLIVLBRNDCDEXXVN;
            public Int32 EZKFCVMUPZNZHVJHGJSQHPAOIRZJFWWYCPFMWTVQWAWBDNVHT;
        }
        public Dictionary<UInt64, User> UserInformation = new Dictionary<UInt64, User>();
        [ChatCommand("online")]
        private void LMABSLAXVDGTVJUAEKAWFLNAWPMKSUHKWOFOQARYQPVIFM(BasePlayer player)
        {
            List<String> PlayerNames = YBRHHVDJORRKFWWPOOXDKFRJQNFOXFGLQUGZPUSBDADHSBK();
            String Message = GetLang("IQCHAT_INFO_ONLINE", player.UserIDString, String.Join($"\n", PlayerNames));
            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(player, Message);
        }
        void ReadData()
        {
            if (!Oxide.Core.Interface.Oxide.DataFileSystem.ExistsDatafile("IQSystem/IQChat/Users") && Oxide.Core.Interface.Oxide.DataFileSystem.ExistsDatafile("IQChat/Users"))
            {
                GeneralInfo = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<GeneralInformation>("IQChat/Information");
                UserInformation = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<Dictionary<UInt64, User>>("IQChat/Users");
                Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQSystem/IQChat/Information", GeneralInfo);
                Oxide.Core.Interface.Oxide.DataFileSystem.WriteObject("IQSystem/IQChat/Users", UserInformation);
                PrintWarning(LanguageEn ? "Your player data has been moved to a new directory - IQSystem/IQChat , you can delete old data files!" : "Ваши данные игроков были перенесены в новую директорию - IQSystem/IQChat , вы можете удалить старые дата-файлы!");
            }
            GeneralInfo = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<GeneralInformation>("IQSystem/IQChat/Information");
            UserInformation = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<Dictionary<UInt64, User>>("IQSystem/IQChat/Users");
            UserInformationConnection = Oxide.Core.Interface.Oxide.DataFileSystem.ReadObject<Dictionary<UInt64, AntiNoob>>("IQSystem/IQChat/AntiNoob");
        }
        private void RNSHFUZKZZAFDZQEBWVWHDGJESBFQQEUJUVWANBPXDFPQVO(BasePlayer player, String Name, String OffsetMin, String OffsetMax, TakeElementUser RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR)
        {
            String Interface = InterfaceBuilder.NIEDHNSLPTGDOAZJLKTNBJILBGOTQIRUPGTSBSKPZ("UI_Chat_Slider");
            if (Interface == null) return;
            Interface = Interface.Replace("%OFFSET_MIN%", OffsetMin);
            Interface = Interface.Replace("%OFFSET_MAX%", OffsetMax);
            Interface = Interface.Replace("%NAME%", Name);
            Interface = Interface.Replace("%COMMAND_LEFT_SLIDE%", $"newui.cmd slider.controller {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR} -");
            Interface = Interface.Replace("%COMMAND_RIGHT_SLIDE%", $"newui.cmd slider.controller {RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR} +");
            CuiHelper.DestroyUi(player, Name);
            CuiHelper.AddUi(player, Interface);
            ILRFYTHFALEDQMSVIDTNCTJGMTGIYJSATIMVSQYKSQSFTFBD(player, RYHINOVNEHMFXHCXSTXJYFXOEIFLUJBOSWULOSKIGCEWUR);
        }
        private void AKTMJPMNGJDMTUTJUGVIDTEOUGZEYRSIECFGWSKUIHQRJPVCJ()
        {
            Configuration.ControllerParameters Controller = config.NFHUENUNNACHOYZTWSKSETGZTZCAZNFQVVHPUTIOOAMGDTFGQ;
            IEnumerable<Configuration.ControllerParameters.AdvancedFuncion> PQDRXLDYACIVAKCOEMFMTRRSYJKREHAVOAWESASXCKWDRUMQT = Controller.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.GNOGZILLKRNALALPKNZKEFSDTNKGUIQVNFTGHDASZWWIAP.Concat(Controller.DLQQJPDIOOLGPPGPAEUQVRZGSCYWTKGNNYFLDGMMGENYZ).Concat(Controller.RJQZDOZWSLLKXHQGOEHXSRJUMTSHJREBGMKOGTHROQ);
            foreach (Configuration.ControllerParameters.AdvancedFuncion Permission in PQDRXLDYACIVAKCOEMFMTRRSYJKREHAVOAWESASXCKWDRUMQT.Where(CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO => !permission.PermissionExists(CRCOBMAQSTAQFEGJFVSUHNDQTEXBXBWVXHDOEXKKQO.Permissions, this))) permission.RegisterPermission(Permission.Permissions, this);
            if (!permission.PermissionExists(PermissionHideOnline, this)) permission.RegisterPermission(PermissionHideOnline, this);
            if (!permission.PermissionExists(PermissionRename, this)) permission.RegisterPermission(PermissionRename, this);
            if (!permission.PermissionExists(XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE, this)) permission.RegisterPermission(XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE, this);
            if (!permission.PermissionExists(ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB, this)) permission.RegisterPermission(ENMIPIUERKCOVOAFAUSTHWLZISAPVJDSBALYIFVB, this);
            if (!permission.PermissionExists(PermissionAntiSpam, this)) permission.RegisterPermission(PermissionAntiSpam, this);
            if (!permission.PermissionExists(PermissionHideConnection, this)) permission.RegisterPermission(PermissionHideConnection, this);
            if (!permission.PermissionExists(PermissionHideDisconnection, this)) permission.RegisterPermission(PermissionHideDisconnection, this);
            if (!permission.PermissionExists(PermissionMutedAdmin, this)) permission.RegisterPermission(PermissionMutedAdmin, this);
            PrintWarning("Permissions - completed");
        }
        [ChatCommand("unmute")]
        void VKAGVGGFSDPIOPQUIRONNBVAAWDMEFLWUCWIIXGZZRAHEZSB(BasePlayer Moderator, string cmd, string[] arg)
        {
            if (!permission.UserHasPermission(Moderator.UserIDString, XVXCTQDPVJRJWAQANYMRBWLSQLGRKZJIIGOVMCPE)) return;
            if (arg == null || arg.Length != 1 || arg.Length > 1)
            {
                TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "Invalid syntax, please use : unmute Steam64ID" : "Неверный синтаксис,используйте : unmute Steam64ID");
                return;
            }
            string NameOrID = arg[0];
            BasePlayer target = HSGRRFLNQFOLMPETVTYTQDRFEHTVCLRBGWTVGMDB(NameOrID);
            if (target == null)
            {
                UInt64 Steam64ID = 0;
                if (UInt64.TryParse(NameOrID, out Steam64ID))
                {
                    if (UserInformation.ContainsKey(Steam64ID))
                    {
                        User Info = UserInformation[Steam64ID];
                        if (Info == null) return;
                        if (!Info.MuteInfo.BNTOXOURLXEKKTZOZDCTFZQACMQEMKXVKDSUPWWFN(MuteType.Chat))
                        {
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "The player does not have a chat lock" : "У игрока нет блокировки чата");
                            return;
                        }
                        Info.MuteInfo.UJYKARTMIXKXXBLWFLGBHZRMMWGJTIJKUUHFXOKEPRUFCPAW(MuteType.Chat);
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "You have unblocked the offline chat to the player" : "Вы разблокировали чат offline игроку");
                        return;
                    }
                    else
                    {
                        TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                        return;
                    }
                }
                else
                {
                    TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(Moderator, LanguageEn ? "This player is not on the server" : "Такого игрока нет на сервере");
                    return;
                }
            }
            JNNWIEKCBFLXEDVKIKYDCCDTXRGWTVOSSNFNUWAKNKPUKDX(target, MuteType.Chat, Moderator, false, true);
        }
        public void PGEOWITOZGZDTAMRSOLTHMLKPOVBNVADBLPZGIYU()
        {
            Configuration.ControllerAlert.Alert Broadcast = config.ControllerAlertSetting.AlertSetting;
            if (Broadcast.AlertMessage)
            {
                Int32 QHFREXYKTNAMUSBMGAOYVETIKJVOBDXUYIRSPXVYFIGFWPPD = 0;
                String ENLBUZMOXHVBKJPPGOMBIXJFPSNXOLUTSMXPMSDI = String.Empty;
                timer.Every(Broadcast.MessageListTimer, () =>
                {
                    if (Broadcast.AlertMessageType)
                    {
                        foreach (BasePlayer p in BasePlayer.activePlayerList)
                        {
                            List<String> MessageList = YKRSUSTMYWSRMDDWOZVFTBBEXDDKYSKFJEAAYPXPAJ(p, Broadcast.MessageList.LanguageMessages);
                            if (QHFREXYKTNAMUSBMGAOYVETIKJVOBDXUYIRSPXVYFIGFWPPD >= MessageList.Count) QHFREXYKTNAMUSBMGAOYVETIKJVOBDXUYIRSPXVYFIGFWPPD = 0;
                            ENLBUZMOXHVBKJPPGOMBIXJFPSNXOLUTSMXPMSDI = MessageList[QHFREXYKTNAMUSBMGAOYVETIKJVOBDXUYIRSPXVYFIGFWPPD];
                            TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(p, ENLBUZMOXHVBKJPPGOMBIXJFPSNXOLUTSMXPMSDI);
                        }
                        QHFREXYKTNAMUSBMGAOYVETIKJVOBDXUYIRSPXVYFIGFWPPD++;
                    }
                    else
                    {
                        foreach (BasePlayer p in BasePlayer.activePlayerList) TJTVDIMEOXGRQRVMQTSKFECAVLZCYAUFIYAYYQKPQHNEPQS(p, GEZGVRRVRSDGNHYBQQAXUDVEFJIQKDCHBBGXMQXKKARGAFANH(p, Broadcast.MessageList.LanguageMessages));
                    }
                });
            }
        }
        String TIRHWFQNPLKGITDVTYIMRADFVBHLNKKQRQODUDSIF(string Key) => (string)(IQRankSystem?.Call("API_GET_RANK_NAME", Key));
        static Double CurrentTime => Facepunch.Math.Epoch.Current;
    }
}