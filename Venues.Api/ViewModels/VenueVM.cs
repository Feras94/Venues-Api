using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Venues.Api.Convertors;
using Venues.Api.Validators;

namespace Venues.Api.ViewModels
{
    [Validator(typeof(VenueVmValidator))]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class VenueVM
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "address")]
        public string Address { get; set; }

        [Display(Name = "type")]
        public string Type { get; set; }

        [Display(Name = "capacity")]
        public int Capacity { get; set; }

        [Display(Name = "createdAt")]
        [JsonConverter(typeof(JsonDateTimeConvertor))]
        public DateTime? CreatedAt { get; set; }
    }
}