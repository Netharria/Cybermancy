﻿using System.Collections.Generic;
using Technomancy.Domain.Shared;

namespace Technomancy.Domain
{
    public class Channel : Identifiable, IXpIgnore
    {
        public string Name { get; set; }
        public Guild Guild { get; set; }
        public bool IsXpIgnored { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Tracker> Trackers { get; set; }
        public Lock Lock { get; set; }

    }
}
