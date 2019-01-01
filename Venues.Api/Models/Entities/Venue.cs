using System;
using System.ComponentModel.DataAnnotations;

namespace Venues.Api.Models.Entities
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Type { get; set; }

        public int Capacity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}