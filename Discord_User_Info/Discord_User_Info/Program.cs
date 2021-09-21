/*

simple Discord User Info tool,
Made by void*#8761
Website - i-love-cp.com

For any questions contact me.

 */

using Discord_User_Info.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Discord_User_Info
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Discord User Info | Made by GostiA#1941";

            GConsole.print_ok("Discord user info, by GostiA#1941\n\n");
            GConsole.print_opt("1", "Get user info by ID\n");
            GConsole.print_opt("2", "Get user info by Token\n");
            string option = GConsole.get_input();

            if (option == "1")
            {
                GConsole.clear();
                GConsole.print_opt("?", "Enter User ID ");
                string id = GConsole.get_input();
                var obj = JObject.Parse(Discord.get_info_by_id(id));

                if (obj["status"].ToString() == "notok")
                {
                    GConsole.print_err("Error: Invalid ID was inputted.\n");
                    GConsole.get_key();
                }
                else
                {
                    GConsole.print_ok("Getting information...\n");
                    Thread.Sleep(800);
                    GConsole.print_ok("Parsing response...\n");
                    Thread.Sleep(500);
                    GConsole.clear();
                    GConsole.print("---------- RESULT ----------\n\n");
                    GConsole.print_success($"ID -> {obj["id"]}\n");
                    GConsole.print_success($"Tag -> {obj["username"]}#{obj["discriminator"]}\n");
                    GConsole.print_success($"Username -> {obj["username"]}\n");
                    GConsole.print_success($"Discriminator -> {obj["discriminator"]}\n");
                    GConsole.print_success($"Avatar -> {obj["avatar"]}\n");
                    GConsole.print_success($"Banner -> {obj["banner"]}\n");
                    GConsole.print_success($"Public Flags -> {obj["public_flags"]}\n");

                    GConsole.print_opt("?", "Save data to a txt file? [y/n]");
                    string yn = GConsole.get_input();
                    string path = $"{obj["id"]}_id.txt";

                    if (yn == "y" || yn == "Y")
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }

                        using (FileStream fs = File.Create(path))
                        {
                            string content = $"ID -> {obj["id"]}\nTag -> {obj["username"]}#{obj["discriminator"]}\nUsername -> {obj["username"]}\nDiscriminator -> {obj["discriminator"]}\nAvatar -> {obj["avatar"]}\nBanner -> {obj["banner"]}\nPublic Flags -> {obj["public_flags"]}";
                            byte[] info = new UTF8Encoding(true).GetBytes(content);
                            fs.Write(info, 0, info.Length);
                        }
                        Thread.Sleep(600);
                        GConsole.print_success($"Successfully saved data to -> {obj["id"]}_id.txt\n");
                        GConsole.get_key();
                    }
                    else if (yn == "n" || yn == "N")
                    {
                        GConsole.get_key();
                    }
                    else
                    {
                        GConsole.print_err("Error: Usage[y/n][Y/N]\n");
                        GConsole.get_key();
                    }
                }
            }
            else if (option == "2")
            {
                GConsole.clear();
                GConsole.print_opt("?", "Enter User Token ");
                string token = GConsole.get_input();
                var obj = JObject.Parse(Discord.get_info_by_token(token));
                
                if (obj["status"].ToString() == "notok")
                {
                    GConsole.print_err("Error: Invalid Token was inputted.\n");
                    GConsole.get_key();
                }
                else
                {
                    GConsole.print_ok("Getting information...\n");
                    Thread.Sleep(800);
                    GConsole.print_ok("Parsing response...\n");
                    Thread.Sleep(500);
                    GConsole.print("---------- RESULT ----------\n\n");
                    GConsole.print_success($"ID -> {obj["id"]}\n");
                    GConsole.print_success($"Tag -> {obj["username"]}#{obj["discriminator"]}\n");
                    GConsole.print_success($"Username -> {obj["username"]}\n");
                    GConsole.print_success($"Discriminator -> {obj["discriminator"]}\n");
                    GConsole.print_success($"Email -> {obj["email"]}\n");
                    GConsole.print_success($"Phone Number -> {obj["phone"]}\n");
                    GConsole.print_success($"Avatar -> {obj["avatar"]}\n");
                    GConsole.print_success($"Banner -> {obj["banner"]}\n");
                    GConsole.print_success($"BIO -> {obj["bio"]}\n");
                    GConsole.print_success($"Public Flags -> {obj["public_flags"]}\n");
                    GConsole.print_success($"Purchased Flags -> {obj["purchased_flags"]}\n");
                    GConsole.print_success($"Permium Flags -> {obj["premium_usage_flags"]}\n");
                    GConsole.print_success($"Permium Type -> {obj["premium_type"]}\n");
                    GConsole.print_success($"Locale -> {obj["locale"]}\n");
                    GConsole.print_success($"Verified -> {obj["verified"]}\n");
                    GConsole.print_success($"2fa Enabled -> {obj["mfa_enabled"]}\n");
                    GConsole.print_success($"Token -> {obj["token"]}\n\n");

                    GConsole.print_opt("?", "Save data to a txt file? [y/n]");
                    string yn = GConsole.get_input();
                    string path = $"{obj["id"]}_token.txt";

                    if (yn == "y" || yn == "Y")
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }

                        using (FileStream fs = File.Create(path))
                        {
                            string content = $"ID -> {obj["id"]}\nTag -> {obj["username"]}#{obj["discriminator"]}\nUsername -> {obj["username"]}\nDiscriminator -> {obj["discriminator"]}\nEmail -> {obj["email"]}\nPhone Number -> {obj["phone"]}\nAvatar -> {obj["avatar"]}\nBanner -> {obj["banner"]}\nBIO -> {obj["bio"]}\nPublic Flags -> {obj["public_flags"]}\nPurchased Flags -> {obj["purchased_flags"]}\nPermium Flags -> {obj["premium_usage_flags"]}\nPermium Type -> {obj["premium_type"]}\nLocale -> {obj["locale"]}\nVerified -> {obj["verified"]}\n2fa Enabled -> {obj["mfa_enabled"]}\nToken -> {obj["token"]}";
                            byte[] info = new UTF8Encoding(true).GetBytes(content);
                            fs.Write(info, 0, info.Length);
                        }
                        Thread.Sleep(600);
                        GConsole.print_success($"Successfully saved data to -> {obj["id"]}_token.txt\n");
                        GConsole.get_key();
                    }
                    else if (yn == "n" || yn == "N")
                    {
                        GConsole.get_key();
                    }
                    else
                    {
                        GConsole.print_err("Error: Usage[y/n][Y/N]\n");
                        GConsole.get_key();
                    }
                }
            }
            else
            {
                GConsole.print_err("Error: Usage[1/2]\n");
                GConsole.get_key();
            }
        }
    }
}
