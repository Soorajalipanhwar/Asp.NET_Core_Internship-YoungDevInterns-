﻿namespace NotesApp.Models.Entities
{
    public class Notes
    {

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
