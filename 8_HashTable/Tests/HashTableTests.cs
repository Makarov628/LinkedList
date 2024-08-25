using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
[TestFixture]
public class HashTableTests
{
    [Test]
    public void SeekSlot_Normal()
    {
        HashTable hashTable = new HashTable(19, 3);
        Assert.AreEqual(14, hashTable.SeekSlot("Magenta"));
    }

    [Test]
    public void SeekSlot_WithOneCollision()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.slots[10] = "Magenta";
        Assert.AreEqual(14, hashTable.SeekSlot("Magenta"));
    }

    [Test]
    public void SeekSlot_WithOverdriveCollision()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.slots[10] = "Magenta";
        hashTable.slots[13] = "Magenta";
        hashTable.slots[16] = "Magenta";
        Assert.AreEqual(14, hashTable.SeekSlot("Magenta"));
    }

    [Test]
    public void SeekSlot_Noslots()
    {
        HashTable hashTable = new HashTable(19, 3);
        for (int i = 0; i < 19; i++)
        {
            hashTable.slots[i] = "Magenta";
        }
        Assert.AreEqual(-1, hashTable.SeekSlot("Magenta"));
    }

    [Test]
    public void SeekSlot_OneSlotFree()
    {
        HashTable hashTable = new HashTable(19, 3);
        for (int i = 0; i < 19; i++)
        {
            if (i != 5) hashTable.slots[i] = "Magenta";
        }
        Assert.AreEqual(-1, hashTable.SeekSlot("Magenta"));
    }

    [Test]
    public void Put_Normal()
    {
        HashTable hashTable = new HashTable(19, 3);
        Assert.AreEqual(14, hashTable.Put("Magenta"));
    }

    [Test]
    public void Put_WithCollisions()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.Put("Magenta");
        hashTable.Put("Magenta");
        Assert.AreEqual(1, hashTable.Put("Magenta"));
    }

    [Test]
    public void Put_WithOverdriveCollisions()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.Put("Magenta");
        hashTable.Put("Magenta");
        hashTable.Put("Magenta");
        Assert.AreEqual(4, hashTable.Put("Magenta"));
    }

    [Test]
    public void Put_Noslots()
    {
        HashTable hashTable = new HashTable(19, 3);
        for (int i = 0; i < 19; i++)
        {
            hashTable.slots[i] = "Magenta";
        }
        Assert.AreEqual(-1, hashTable.Put("Magenta"));
    }

    [Test]
    public void Put_OneSlotFree()
    {
        HashTable hashTable = new HashTable(19, 3);
        for (int i = 0; i < 19; i++)
        {
            if (i != 7) hashTable.slots[i] = "Magenta";
        }
        Assert.AreEqual(7, hashTable.Put("Magenta"));
    }

    [Test]
    public void Find_Normal()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.Put("Magenta");
        Assert.AreEqual(14, hashTable.Find("Magenta"));
    }

    [Test]
    public void Find_WithCollisions()
    {
        HashTable hashTable = new HashTable(19, 3);
        hashTable.Put("Magenta");
        hashTable.Put("Cian");
        int slot = hashTable.Put("Yellow");
        hashTable.Put("Red");
        hashTable.Put("Black");
        hashTable.Put("Velvet");
        Assert.AreEqual(slot, hashTable.Find("Yellow"));
    }
}
}
