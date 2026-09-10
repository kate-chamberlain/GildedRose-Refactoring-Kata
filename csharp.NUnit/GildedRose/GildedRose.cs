﻿using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateSingleItem(Items[i]);
        }
    }
    private void UpdateSingleItem(Item item)
    {
        if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return; // Skip all original logic for Sulfuras. Nothing needs changing as it's a legendary item
            }
        
        if (item.Name == "Aged Brie")
        {
            UpdateAgedBrie(item);
        }
        
        else if(item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            updateBackstagePasses(item);
        }

        else if(item.Name.StartsWith("Conjured"))
        {
            updateConjuredItems(item);
        }
        
        else
        {
            updateNormalItems(item);
        }

        // Globally correct for out of bounds quality values
        if (item.Quality < 0) item.Quality = 0;
        if (item.Quality > 50) item.Quality = 50;
    }

    private void UpdateAgedBrie(Item item)
    {
        item.SellIn -= 1;
    if (item.SellIn >= 0)
        {
            item.Quality+=1;
        }
        else
        {
            item.Quality += 2;
        };
    }

    private void updateBackstagePasses(Item item)
    {
        if (item.SellIn > 10)
            {
                item.Quality += 1;
            }
            else if (item.SellIn > 5)
            {
                item.Quality += 2;           
            }
            else if (item.SellIn > 0)
            {
                item.Quality += 3;
            }
            else
            {
                item.Quality = 0;
            }
        item.SellIn -= 1;
    }
    private void updateConjuredItems(Item item)
    {
        item.SellIn--;
        item.Quality -= (item.SellIn < 0) ? 4 : 2;
    }
    private void updateNormalItems(Item item)
    {
        item.SellIn--;
        item.Quality -= (item.SellIn < 0) ? 2 : 1;
    }
}