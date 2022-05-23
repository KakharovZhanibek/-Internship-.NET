using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string CONJURED = "Conjured";
        public const int MAXIMUM_QUALITY = 50;
        public const int MINIMUM_QUALITY = 0;
        public const int BACKSTAGE_PASSES_THRESHOLD1 = 11;
        public const int BACKSTAGE_PASSES_THRESHOLD2 = 6;

        IList<Item> Items;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (IsRegular(item))
                {
                    UpdateRegularItem(item);
                }
                else if (IsAgedBrie(item))
                {
                    UpdateAgedBrieItem(item);
                }
                else if (IsBackstagePasses(item))
                {
                    UpdateBackStagePassesItem(item);
                }
                else if (IsSulfuras(item))
                {
                    UpdateSulfurasItem(item);
                }
                else if (IsConjured(item))
                {
                    UpdateConjuredItem(item);
                }
            }
        }

        private void UpdateConjuredItem(Item item)
        {
            item.SellIn--;
            item.Quality -= 2;

            if (item.SellIn <= 0)
            {
                item.Quality -= 2;
            }
            if (item.Quality < MINIMUM_QUALITY)
            {
                item.Quality = MINIMUM_QUALITY;
            }
        }

        private static bool IsConjured(Item item)
        {
            return item.Name.StartsWith(CONJURED);
        }

        private static void UpdateSulfurasItem(Item item)
        {
            item.SellIn--;
        }
        private static void UpdateBackStagePassesItem(Item item)
        {
            item.SellIn--;
            if (item.SellIn <= 0)
            {
                item.Quality = MINIMUM_QUALITY;
            }
            else
            {
                item.Quality++;

                if (item.SellIn < BACKSTAGE_PASSES_THRESHOLD2)
                {
                    item.Quality += 2;
                }
                else if (item.SellIn < BACKSTAGE_PASSES_THRESHOLD1)
                {
                    item.Quality++;
                }
                if (item.Quality > MAXIMUM_QUALITY)
                {
                    item.Quality = MAXIMUM_QUALITY;
                }
            }
        }

        private static void UpdateAgedBrieItem(Item item)
        {
            item.SellIn--;
            item.Quality++;

            if (item.SellIn <= 0)
            {
                item.Quality++;
            }

            if (item.Quality > MAXIMUM_QUALITY)
            {
                item.Quality = MAXIMUM_QUALITY;
            }
        }

        private static void UpdateRegularItem(Item item)
        {
            item.SellIn--;
            item.Quality--;

            if (item.SellIn <= 0)
            {
                item.Quality--;
            }
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private static bool IsRegular(Item item)
        {
            return !(IsAgedBrie(item) || IsBackstagePasses(item) || IsSulfuras(item) || IsConjured(item));
        }
        private static bool IsSulfuras(Item item)
        {
            return item.Name == SULFURAS;
        }

        private static bool IsBackstagePasses(Item item)
        {
            return item.Name == BACKSTAGE_PASSES;
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == AGED_BRIE;
        }
    }
}
