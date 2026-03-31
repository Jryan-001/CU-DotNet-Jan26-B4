using AutoMapper;
using LoanManagementWebAPI.Data;
using LoanManagementWebAPI.DTO;
using LoanManagementWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanManagementWebAPIContext _context;
        private readonly IMapper _mapper;

        public LoansController(LoanManagementWebAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoan()
        {
            var loans = await _context.Loan.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<LoanReadDto>>(loans));

            //return loans.Select(l => new LoanReadDto
            //{
            //    Id = l.Id,
            //    BorrowerName = l.BorrowerName,
            //    Amount = l.Amount,
            //    LoanTermMonths = l.LoanTermMonths,
            //    IsApproved = l.IsApproved
            //}).ToList();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanReadDto>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null) return NotFound();
            //return new LoanReadDto
            //{
            //    Id = loan.Id,
            //    BorrowerName = loan.BorrowerName,
            //    Amount = loan.Amount,
            //    LoanTermMonths = loan.LoanTermMonths,
            //    IsApproved = loan.IsApproved
            //};
            return Ok(_mapper.Map<LoanReadDto>(loan));
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, LoanUpdateDto loanUpdateDto)
        {
            if (id != loanUpdateDto.Id) return BadRequest();
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null) return NotFound();
            //loan.BorrowerName = loanUpdateDto.BorrowerName;
            //loan.Amount = loanUpdateDto.Amount;
            //loan.LoanTermMonths = loanUpdateDto.LoanTermMonths;
            //loan.IsApproved = loanUpdateDto.IsApproved;
            _mapper.Map(loanUpdateDto, loan);
            _context.Entry(loan).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanReadDto>> PostLoan(LoanCreateDto loanCreateDto)
        {
            //var loan = new Loan
            //{
            //    BorrowerName = loanCreateDto.BorrowerName,
            //    Amount = loanCreateDto.Amount,
            //    LoanTermMonths = loanCreateDto.LoanTermMonths,
            //    IsApproved = loanCreateDto.IsApproved
            //};
            var loan = _mapper.Map<Loan>(loanCreateDto);
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();
            //var loanReadDto = new LoanReadDto
            //{
            //    Id = loan.Id,
            //    BorrowerName = loan.BorrowerName,
            //    Amount = loan.Amount,
            //    LoanTermMonths = loan.LoanTermMonths,
            //    IsApproved = loan.IsApproved
            //};
            return CreatedAtAction("GetLoan", new { id = loan.Id }, _mapper.Map<LoanReadDto>(loan));
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.Id == id);
        }
    }
}
