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
}