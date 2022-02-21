﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBookScrapper.Domain.Model
{
    public abstract class MissedParsingObject
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Message { get; set; }
    }
}
