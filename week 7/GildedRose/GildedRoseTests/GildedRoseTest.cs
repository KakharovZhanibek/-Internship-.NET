using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        public Item CreateAndUpdateItem(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items) ;

            app.UpdateQuality();

            return items[0];
        }

        [Fact]
        public void GildedRose_GivenRegularItem_QualityAndSellInDecreases()
        {
            Item item = CreateAndUpdateItem("TestItem", 13, 7);

            Assert.Equal(6, item.Quality);
            Assert.Equal(12, item.SellIn);
        }
        [Fact]
        public void GildedRose_GivenRegularItemWithExpiredSellIn_QualityDecreasesTwiceAsFast()
        {
            Item item = CreateAndUpdateItem("TestItem", 0, 31);

            Assert.Equal(29, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenRegularItem_QualityCanNotBeNegative()
        {
            Item item = CreateAndUpdateItem("TestItem", 10, 0);

            Assert.Equal(0, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenAgedBrie_QualityIncreases()
        {
            Item item = CreateAndUpdateItem(GildedRose.AGED_BRIE, 10, 31);

            Assert.Equal(32, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenAgedBrie_QualityCanNotBeMoreThanMaximumQuality()
        {
            Item item = CreateAndUpdateItem(GildedRose.AGED_BRIE, 10, 50);

            Assert.Equal(GildedRose.MAXIMUM_QUALITY, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenSulfuras_QualityNeverDegrades()
        {
            Item item = CreateAndUpdateItem(GildedRose.SULFURAS, 0, 80);

            Assert.Equal(80, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenBackstagePasses_QualityIncreases()
        {
            Item item = CreateAndUpdateItem(GildedRose.BACKSTAGE_PASSES, 26, 10);

            Assert.Equal(11, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenBackstagePasses10DaysOut_QualityIncreasesByBackstagePassesThreshold1()
        {
            Item item = CreateAndUpdateItem(GildedRose.BACKSTAGE_PASSES, 9, 10);

            Assert.Equal(12, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenBackstagePasses5DaysOut_QualityIncreasesByBackstagePassesThreshold2()
        {
            Item item = CreateAndUpdateItem(GildedRose.BACKSTAGE_PASSES, 4, 10);

            Assert.Equal(13, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenBackstagePassesWithExpiredSellIn_QualityDecreasesToMinimumQuality()
        {
            Item item = CreateAndUpdateItem(GildedRose.BACKSTAGE_PASSES, 0, 10);

            Assert.Equal(GildedRose.MINIMUM_QUALITY, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenConjuredItem_QualityDecreasesTwiceAsFast()
        {
            Item item = CreateAndUpdateItem(GildedRose.CONJURED, 20, 10);

            Assert.Equal(8, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenConjuredItemWithExpiredSellIn_QualityDecreasesTwiceAsFastThanUsual()
        {
            Item item = CreateAndUpdateItem(GildedRose.CONJURED, -2, 10);

            Assert.Equal(6, item.Quality);
        }
        [Fact]
        public void GildedRose_GivenConjuredItem_QualityCanNotBeNegative()
        {
            Item item = CreateAndUpdateItem("TestItem", 10, 0);

            Assert.Equal(GildedRose.MINIMUM_QUALITY, item.Quality);
        }
    }
}
