﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Termini
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
