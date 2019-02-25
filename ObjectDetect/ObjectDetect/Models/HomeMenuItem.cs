using System;
namespace ObjectDetect.Models
{
    public enum MenuItemType
    {
        ObjectList,
        Settings
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
