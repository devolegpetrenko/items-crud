﻿namespace ItemsCrud.Persistence.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
}