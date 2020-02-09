using System;

namespace ClassUpdateLog
{
    [PropertyChangeTracking]
    public class Entity
    {
        [PropertyChangeTracking(ignore: true)]
        public Guid Id { get; set; }

        [PropertyChangeTracking(displayName: "序号")]
        public string OId { get; set; }

        [PropertyChangeTracking(displayName: "第一个字段")]
        public string A { get; set; }

        public double B { get; set; }

        public bool C { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}