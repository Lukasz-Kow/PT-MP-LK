﻿
namespace Presentations.Model.API
{
    public interface IBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}
