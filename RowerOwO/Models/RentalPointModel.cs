﻿using MessagePack;

namespace RowerOwO.Models
{
    public class RentalPointModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
    }
}
