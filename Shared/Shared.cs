﻿using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Shared
    {
        private static IDictionary<int, string> OfficeVersions = new Dictionary<int, string>() {
            {6, "4.x" },
            {7, "95" },
            {8, "97" },
            {9, "2000" },
            {10, "XP" },
            {11, "2003" },
            {12, "2007" },
            {14, "2010" },
            {15, "2013" },
            {16, "2016 or 2019" }
        };

        private static IDictionary<string, string> Strings = new Dictionary<string, string>()
        {
            {"discordID", "470239659591598091" },
            {"noFile", "No File Open" },
            {"tabOut", "Not Active"},
            {"welcome", "Welcome Screen" },
            {"editing", "Editing File" },
            {"editingSlide", "Editing Slide" },
            {"editingPage", "Editing Page" },
            {"presenting", "Presenting" },
            {"excel", "Microsoft Excel" },
            {"powerpoint", "Microsoft PowerPoint" },
            {"word", "Microsoft Word" },
            {"outlook", "Microsoft Outlook" },
            {"unknown_version", "[Unknown Version]" },
            {"unknown_key", "[Unknown]" }
        };

        public static String getVersion()
        {
            int version = Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductMajorPart;
            Debug.WriteLine(ObjectDumper.Dump(Process.GetCurrentProcess().MainModule.FileVersionInfo));
            // ProductBuildPart:
            // 10730 Excel 2019
            // 11328 Excel 365
            if (OfficeVersions.ContainsKey(version))
            {
                return OfficeVersions[version];
            } else
            {
                return getString("unknown_version");
            }
        }

        public static String getString(string key)
        {
            if (Strings.ContainsKey(key))
            {
                return Strings[key];
            } else
            {
                return getString("unknown_key");
            }
        }

        public static RichPresence getNewPresence(string type)
        {
            return new RichPresence()
            {
                Details = getString("noFile"),
                State = getString("welcome"),
                Assets = new Assets()
                {
                    LargeImageKey = type + "_welcome",
                    LargeImageText = getString(type) + " " + getVersion(),
                    SmallImageKey = type
                }
            };
        }
    }
}
