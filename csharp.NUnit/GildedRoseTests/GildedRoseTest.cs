using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void NormalItem_QualityAndSellInDecreaseByDay()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(19));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }
    
    [Test]
    public void NormalItem_QualityDegradesTwiceAsFastAfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(18));
    }
    
    [Test]
    public void QualityNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.GreaterThanOrEqualTo(0));
    }
    
    [Test]
    public void QualityNeverGreaterThanFifty()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void Sulfuras_DoesNotChangeSellInOrQuality()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(80));
        Assert.That(items[0].SellIn, Is.EqualTo(0));
    }

    [Test]
    public void AgedBrie_Plus2QualityAfterSellBy()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -2, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }
    
    [Test]
    public void AgedBrie_Increases_Plus1QualityBeforeSellBy()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }
    
    [Test]
    public void BackstagePasses_Quality_IncreasesBy1_MoreThan10DaysOut()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }
    
    [Test]
    public void BackstagePasses_Quality_IncreasesBy2_Between10and5Days()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }
    
    [Test]
    public void BackstagePasses_Quality_IncreasesBy3_5AndFewer()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(23));
    }
    
    [Test]
    public void BackstagePasses_Quality_ZeroAfterConcert()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
    
        // Act
        app.UpdateQuality();
    
        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    
}
