using Laba3new.Models;
using Laba3new.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laba3new.Controllers
{
    public class BookOrdersController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public BookOrdersController(/*IUnitOfWork uow*/)
        {
            _uow = /*uow;*/new UnitOfWork();
        }

        // GET: api/BookOrders
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _uow.BookOrderRepository.GetAllAsync(include: q => q.Include(x => x.Book.Sages)));
        }

        // POST api/BookOrders
        public async Task<IHttpActionResult> Post([FromBody]IEnumerable<BookOrder> bookOrders)
        {
            if (bookOrders != null)
            {
                foreach (var item in bookOrders)
                {
                    var res = await _uow.BookRepository.GetByIdAsync(item.BookId);
                    if (res != null)
                    {
                        await _uow.BookOrderRepository.CreateAsync(item);
                    }
                    else
                    {
                        return BadRequest("Book with Id " + item.BookId + " does not exist");
                    }
                }

                if (await _uow.SaveAsync())
                {
                    return Ok();
                }

                return BadRequest();
            }

            return Ok();
        }
    }
}
