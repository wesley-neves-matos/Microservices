﻿using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var coupon = await _repository.GetDiscountAsync(productName);

            if (coupon is null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            if (coupon is null)
            {
                return BadRequest("Invalid Coupon!");
            }

            await _repository.CreateDiscountAsync(coupon);

            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }

        [HttpPut]
        public async Task<ActionResult<Coupon>> UpdateDiscount([FromBody] Coupon coupon)
        {
            if (coupon is null)
            {
                return BadRequest("Invalid Coupon!");
            }
            return Ok(await _repository.UpdateDiscountAsync(coupon));
        }

        [HttpDelete("{productName}")]
        public async Task<ActionResult> DeleteDiscount(string productName)
        {
            return Ok(await _repository.DeleteDiscountAsync(productName));
        }
    }
}
