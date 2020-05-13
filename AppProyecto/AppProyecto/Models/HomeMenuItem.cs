using System;
using System.Collections.Generic;
using System.Text;

namespace AppProyecto.Models
{
    public enum MenuItemType
    {
        CRUD,
        Acerca
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
