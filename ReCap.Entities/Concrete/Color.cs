﻿using ReCap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
