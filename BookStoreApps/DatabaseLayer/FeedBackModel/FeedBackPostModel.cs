﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.FeedBackModel
{
    public class FeedBackPostModel
    {
        public string Comment { get; set; }
        public decimal TotalRating { get; set; }
        public int BookId { get; set; }
    }
}
