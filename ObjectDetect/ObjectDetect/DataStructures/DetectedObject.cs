using System;
namespace ObjectDetect.DataStructures
{
    public class DetectedObject
    {
        public int ID { get; set; }
        public string ImageResourcePath { get; set; }
        public BoundingBox ObjectBoundingBox { get; set; }
        public string Name { get; set; }
        public DateTime DetectedDate { get; set; }
        public DetectedObject()
        {
        }
    }
}
