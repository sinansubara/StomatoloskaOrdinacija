using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Termini,
        Pretplate,
        Racuni,
        Odjava
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
