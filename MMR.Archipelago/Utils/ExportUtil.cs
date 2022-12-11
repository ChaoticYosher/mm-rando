using MMR.Common.Extensions;
using MMR.Randomizer.Attributes;
using MMR.Randomizer.Attributes.Archipelago;
using MMR.Randomizer.GameObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace MMR.Archipelago.Util
{
    [Serializable]
    public class APItem
    {
        public string Name { get; }
        public byte Classification { get; }
        public int ID { get; }
        public ushort GetItemIndex { get; }
        public APItem(string name, APItemClassification classification, int id, ushort getItemIndex)
        {
            Name = name;
            Classification = (byte) classification;
            ID = id;
            GetItemIndex = getItemIndex;
        }
    }

    [Serializable]
    public class APLocation
    {
        public string Name { get; }
        public int Address { get; }
        public string Region { get; }
        public int ID { get; }
        public string DefaultItem { get; }
        // TODO add dictionary for logic
        public APLocation(string name, string region, int id, string defaultItem)
        {
            Name = name;
            Address = 0;
            Region = region;
            ID = id;
            DefaultItem = defaultItem;
        }
    }

    [Serializable]
    public class APRegion
    {
        public string Name { get; }
        public string Type { get; }
        public string Hint { get; }
        public APRegion(string name, string type, string hint)
        {
            Name = name;
            Type = type;
            Hint = hint;
        }
    }

    public enum APItemClassification
    {
        Filler = 0b0000,
        Progression = 0b0001,
        Useful = 0b0010,
        Trap = 0b0100,
        SkipBalancing = 0b1000,
        ProgressionSkipBalancing = 0b1001,
    }

    [Serializable]
    public class ArchipelagoExportData
    {
        public List<APItem> items;
        public Dictionary<string, APLocation> locations;
        public List<APRegion> regions;
        public static readonly int ITEM_OFFSET = 24000;
        public ArchipelagoExportData()
        {
            items = new List<APItem>();
            locations = new Dictionary<string, APLocation>();
            regions = new List<APRegion>();
        }
        public void AddData(List<APItem> items, List<APLocation> locations, List<APRegion> regions)
        {
            this.items.AddRange(items);
            this.regions.AddRange(regions);
            foreach(APLocation location in locations)
            {
                this.locations.Add(location.Name, location);
            }
        }
    }

    public class ExportUtil
    {
        public static IEnumerable<Item> APItems()
        {
            return Enum.GetValues(typeof(Item))
                .Cast<Item>()
                .Where(item => item.HasAttribute<ArchipelagoItemAttribute>());
        }

        public static APItemClassification GetAPItemClassification(Item item, ItemCategory category)
        {
            switch (category)
            {
                case ItemCategory.Fake:
                    return APItemClassification.Trap;
                case ItemCategory.MainInventory:
                case ItemCategory.Songs:
                case ItemCategory.BossRemains:
                case ItemCategory.Masks:
                case ItemCategory.TradeItems:
                case ItemCategory.MagicPowers:
                case ItemCategory.SkulltulaTokens:
                case ItemCategory.StrayFairies:
                case ItemCategory.DungeonKeys:
                    return APItemClassification.Progression;
                case ItemCategory.Shields:
                case ItemCategory.SongOfSoaring:
                    return APItemClassification.Useful;
                default:
                    return APItemClassification.Filler;
            }
        }

        public static void GenerateAPData()
        {
            ArchipelagoExportData data = new ArchipelagoExportData();
            List<APItem> items = new List<APItem>();
            List<APLocation> locations = new List<APLocation>();
            List<APRegion> regions = new List<APRegion>();
            HashSet<string> itemNames = new HashSet<string>();
            HashSet<string> regionNames = new HashSet<string>();
            // TODO add dictionaries for item/location name -> logic ID
            // have the logic exporter expand out the logical
            string itemName, locationName, regionName;
            int locationIndex, itemIndex;
            ushort getItemIndex;
            ItemCategory itemCategory;
            LocationCategory locationCategory;
            Region? region;
            itemIndex = locationIndex = ArchipelagoExportData.ITEM_OFFSET;
            foreach(Item item in APItems())
            {
                try
                {
                    itemName = item.GetAttribute<ItemNameAttribute>()?.Name;
                    locationName = item.GetAttribute<LocationNameAttribute>()?.Name;
                    region = item.GetAttribute<RegionAttribute>()?.Region;
                    regionName = region?.GetAttribute<RegionNameAttribute>()?.Name ?? "";
                    getItemIndex = item.GetAttribute<GetItemIndexAttribute>()?.Index ?? 0;
                    itemCategory = item.GetAttribute<ItemPoolAttribute>()?.ItemCategory ?? ItemCategory.None;
                    locationCategory = item.GetAttribute<ItemPoolAttribute>()?.LocationCategory ?? LocationCategory.None;
                }
                catch (Exception ex)
                {
                    continue;
                }
                // add logic id
                locations.Add(new APLocation(locationName, regionName, locationIndex, itemName));
                locationIndex++;
                items.Add(new APItem(itemName, GetAPItemClassification(item, itemCategory), itemIndex, getItemIndex));
                itemNames.Add(itemName);
                itemIndex++;
                if (!regionNames.Contains(regionName) && !"".Equals(regionName))
                {
                    regions.Add(new APRegion(regionName, "", ""));
                    regionNames.Add(regionName);
                }
            }
            data.AddData(items, locations, regions);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.WriteLine(json);
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string outputPath = Path.Combine("data", "output.json");
            try
            {
                File.WriteAllText(outputPath,json);
                File.Copy(outputPath, Path.Combine("C:", "Users", "alex", "Documents", "Games", "Rando", "Archipelago", "src", "worlds", "majora", "data", "output.json"),true);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
