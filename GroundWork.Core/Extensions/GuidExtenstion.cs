﻿using System;
namespace GroundWork.Core.Extensions
{
    public static class GuidExtenstions
    {
        public static bool IsEmpty(this Guid value)
        {
            return (value == Guid.Empty);
        }
    }
}

