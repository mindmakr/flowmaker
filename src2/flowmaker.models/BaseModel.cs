﻿using System;

namespace flowmaker.models
{
    public abstract class BaseModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool Disabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
