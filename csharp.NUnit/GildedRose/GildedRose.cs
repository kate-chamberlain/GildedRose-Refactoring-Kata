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
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
                continue; // Skip all original logic for Sulfuras. Nothing needs changing as it's a legendary item
            }

            Items[i].SellIn = Items[i].SellIn - 1;

            if (Items[i].Name == "Aged Brie")
            {
                if (Items[i].Quality < 50)
                {
                    if (Items[i].SellIn >= 0)
                    {
                        Items[i].Quality+=1;
                    }
                    else
                    {
                        Items[i].Quality += 2;
                    }
                }
                continue;
            }
            else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].SellIn > 10 && Items[i].Quality < 50)
                {
                    Items[i].Quality += 1;
                }
                else if (Items[i].SellIn > 5 && Items[i].Quality < 48)
                {
                    Items[i].Quality += 2;           
                }
                else if (Items[i].SellIn > 0 && Items[i].Quality < 47)
                {
                    Items[i].Quality += 3;
                }
                else
                {
                    Items[i].Quality = 0;
                }
                continue;
            }
            else
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].SellIn <= 0)
                    {
                        Items[i].Quality = Items[i].Quality - 2;
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
                continue;
            }
        }
    }
}