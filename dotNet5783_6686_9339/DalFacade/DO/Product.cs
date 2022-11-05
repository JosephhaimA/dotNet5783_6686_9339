﻿

using System.ComponentModel;

namespace DO;

/// <summary>
/// structure 
/// </summary>
public struct Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public CategoryAttribute Category { get; set; }
    public int InStock { get; set; }
                            
}