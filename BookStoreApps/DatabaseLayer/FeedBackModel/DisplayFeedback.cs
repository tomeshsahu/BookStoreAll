﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.FeedBackModel
{
    public class DisplayFeedback
    {
        public int FeedbackId { get; set; }
        public string Comment { get; set; }
        public decimal TotalRating { get; set; }
        public int BookId { get; set; }
        public string FullName { get; set; }
    }
}
