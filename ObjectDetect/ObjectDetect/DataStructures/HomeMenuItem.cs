using System;
namespace ObjectDetect.DataStructures
{
    public enum MenuItemType
    {
        //Browse,
        ObjectDetectList,
        //Login,
        //About,
        //Profile,
        Settings
    }



        public class HomeMenuItem
        {
            public MenuItemType Id { get; set; }

            public string Title { get; set; }
        }

}
