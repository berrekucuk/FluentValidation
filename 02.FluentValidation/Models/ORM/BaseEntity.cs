﻿namespace _02.FluentValidation.Models.ORM
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
