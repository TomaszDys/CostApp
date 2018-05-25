using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using TomaszDyśkoLab6Zad1.Models;

namespace TomaszDyśkoLab6Zad1.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        /// <summary>
        /// Metoda zwracająca listę produktów
        /// </summary>
        /// <returns>Lista produktów</returns>
        public List<ProductDto> Get()
        {
            using (var context = new DatabaseContext())
            {
                var products = context.Product.ToList();
                return products.Select(o => new ProductDto()
                            {
                                Id = o.Id,
                                Name = o.Name,
                                NumberOfPieces = o.NumberOfPieces,
                                Price = o.Price
                            }).ToList();
            }
        }
        // POST: api/Products
        /// <summary>
        /// Metoda tworząca nowy produkt po wysłaniu zapytania POST
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]ProductDto value)
        {
            using(var context = new DatabaseContext())
            {
                Product product = new Product()
                {
                    Name = value.Name,
                    NumberOfPieces = value.NumberOfPieces,
                    Price = value.Price
                };
                context.Product.Add(product);
                context.SaveChanges();
            }

        }
        /// <summary>
        /// Metoda zmieniająca w bazie danych produkt o podanym Id
        /// </summary>
        /// <param name="id">Id produktu</param>
        /// <param name="value">Nowe wartości</param>
        /// <returns>Wartość JSON (success: true/false) w zależności od poprawności zapytania</returns>
        public JsonResult<Result> Post(int id,[FromBody]ProductDto value)
        {
            using(var context = new DatabaseContext())
            {
                Product product = new Product()
                {
                    Name = value.Name,
                    NumberOfPieces = value.NumberOfPieces,
                    Price = value.Price
                };
                try           
                {
                    var item = context.Product.First(i => i.Id == id);
                    context.Product.Remove(item);
                    context.Product.Add(product);
                    context.SaveChanges();
                    return Json(new Result(true));
                }
                catch(Exception e)
                {
                    return Json(new Result(false));
                }
            }

        }
        // DELETE: api/Products/5
        /// <summary>
        /// Metoda usuwająca produkt o podanym Id z bazy danych
        /// </summary>
        /// <param name="id">Id produktu</param>
        /// <returns>Wartość JSON (success: true/false) w zależności od poprawności zapytania</returns>
        public JsonResult<Result> Delete(int id)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var item = context.Product.First(i => i.Id == id);
                    context.Product.Remove(item);
                    context.SaveChanges();

                    return Json(new Result(true));
                }
                catch (Exception e)
                {
                    return Json(new Result(false));
                }
            }
        }
    }
}
