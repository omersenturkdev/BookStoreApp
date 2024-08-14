﻿using System;

namespace BookStore
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
