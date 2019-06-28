﻿using MMRando.GameObjects;
using MMRando.Models;
using MMRando.Models.Settings;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MMRando.Utils
{
    public static class SpoilerUtils
    {
        public static void CreateSpoilerLog(RandomizedResult randomized, SettingsObject settings)
        {
            var itemList = randomized.ItemList
                .Select(u => new SpoilerItem(u, randomized.ItemList.SingleOrDefault(io => io.ID == u.ReplacesItemId)?.Name));
            var settingsString = settings.ToString();

            var directory = Path.GetDirectoryName(settings.OutputROMFilename);
            var filename = $"{Path.GetFileNameWithoutExtension(settings.OutputROMFilename)}";

            var plainTextRegex = new Regex("[^a-zA-Z0-9' .\\-]+");
            Spoiler spoiler = new Spoiler()
            {
                Version = MainForm.AssemblyVersion.Substring(26),
                SettingsString = settingsString,
                Seed = settings.Seed,
                RandomizeDungeonEntrances = settings.RandomizeDungeonEntrances,
                ItemList = itemList.Where(u => !ItemUtils.IsFakeItem(u.Id)).ToList(),
                NewDestinationIndices = randomized.NewDestinationIndices,
                Logic = randomized.Logic,
                CustomItemListString = settings.UseCustomItemList ? settings.CustomItemListString : null,
                GossipHints = randomized.GossipQuotes?.ToDictionary(me => (GossipQuote) me.Id, (me) =>
                {
                    var message = me.Message.Substring(1);
                    var soundEffect = message.Substring(0, 2);
                    message = message.Substring(2);
                    if (soundEffect == "\x69\x0C")
                    {
                        // real
                    }
                    else if (soundEffect == "\x69\x0A")
                    {
                        // fake
                        message = "FAKE - " + message;
                    }
                    else
                    {
                        // junk
                        message = "JUNK - " + message;
                    }
                    return plainTextRegex.Replace(message.Replace("\x11", " "), "");
                }),
            };

            if (settings.GenerateHTMLLog)
            {
                filename += "_SpoilerLog.html";
                using (StreamWriter newlog = new StreamWriter(Path.Combine(directory, filename)))
                {
                    Templates.HtmlSpoiler htmlspoiler = new Templates.HtmlSpoiler(spoiler);
                    newlog.Write(htmlspoiler.TransformText());
                }
            }
            else
            {
                filename += "_SpoilerLog.txt";
                CreateTextSpoilerLog(spoiler, Path.Combine(directory, filename));
            }
        }

        private static void CreateTextSpoilerLog(Spoiler spoiler, string path)
        {
            StringBuilder log = new StringBuilder();
            log.AppendLine($"{"Version:",-17} {spoiler.Version}");
            log.AppendLine($"{"Settings String:",-17} {spoiler.SettingsString}");
            log.AppendLine($"{"Seed:",-17} {spoiler.Seed}");
            if (spoiler.CustomItemListString != null)
            {
                log.AppendLine($"{"Custom Item List:",-17} {spoiler.CustomItemListString}");
            }
            log.AppendLine();

            if (spoiler.RandomizeDungeonEntrances)
            {
                log.AppendLine($" {"Entrance",-21}    {"Destination"}");
                log.AppendLine();
                string[] destinations = new string[] { "Woodfall", "Snowhead", "Inverted Stone Tower", "Great Bay" };
                for (int i = 0; i < 4; i++)
                {
                    log.AppendLine($"{destinations[i],-21} -> {destinations[spoiler.NewDestinationIndices[i]]}");
                }
                log.AppendLine("");
            }

            log.AppendLine($" {"Location",-50}    {"Item"}");
            foreach (var item in spoiler.ItemList)
            {
                log.AppendLine($"{item.NewLocationName,-50} -> {item.Name}");
            }

            log.AppendLine();
            log.AppendLine();

            log.AppendLine($" {"Location",-50}    {"Item"}");
            foreach (var item in spoiler.ItemList.OrderBy(i => i.NewLocationId))
            {
                log.AppendLine($"{item.NewLocationName,-50} -> {item.Name}");
            }


            if (spoiler.GossipHints != null && spoiler.GossipHints.Any())
            {
                log.AppendLine();
                log.AppendLine();

                log.AppendLine($" {"Gossip Stone",-25}    {"Message"}");
                foreach (var hint in spoiler.GossipHints.OrderBy(h => h.Key.ToString()))
                {
                    log.AppendLine($"{hint.Key,-25} -> {hint.Value}");
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(log.ToString());
            }
        }
    }
}
