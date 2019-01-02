using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Venues.Api.Models.Entities;
using Venues.Api.ViewModels;

namespace Venues.Api.Controllers.Api
{
    [RoutePrefix("venues")]
    public class VenuesController : BaseApiController
    {
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            // take only the latest 10 venues
            var venues = await DbContext.Venues
                .OrderByDescending(model => model.CreatedAt)
                .Take(10)
                .ProjectTo<VenueVM>()
                .ToListAsync();

            return Ok(venues);
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var venue = await DbContext.Venues.FindAsync(id);
            if (venue == null) return NotFound();

            var venueVm = Mapper.Map<VenueVM>(venue);
            return Ok(venueVm);
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(VenueVM request)
        {
            // check for validation errors
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // map to db model and set the creation date
            var venue = Mapper.Map<Venue>(request);
            venue.CreatedAt = DateTime.UtcNow;

            // save changes async
            DbContext.Venues.Add(venue);
            await DbContext.SaveChangesAsync();

            // return newly created model
            return Ok(venue);
        }

        [HttpPost, Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] VenueVM request)
        {
            // check for validation errors
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // lookup the database model
            var dbVenue = await DbContext.Venues.FindAsync(id);
            if (dbVenue == null) return NotFound();

            // update properties
            dbVenue.Name = request.Name;
            dbVenue.Address = request.Address;
            dbVenue.Type = request.Type;
            dbVenue.Capacity = request.Capacity;

            // save changes and return saved model
            await DbContext.SaveChangesAsync();

            return Ok(Mapper.Map<VenueVM>(dbVenue));
        }

        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            // lookup the model
            var venue = await DbContext.Venues.FindAsync(id);
            if (venue == null) return NotFound();

            // delete, save and return ok
            DbContext.Venues.Remove(venue);
            await DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}