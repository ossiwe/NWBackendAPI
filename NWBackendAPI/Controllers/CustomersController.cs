﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWBackendAPI.Models;

namespace NWBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Luodaan instanssi tietokantakontekstiluokasta 
        NorthwindOriginalContext db = new();


        // Hakee kaikki asiakkaat
        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            List<Customer> asiakkaat = db.Customers.ToList();
            return Ok(asiakkaat);
        }

        // Hakee asiakkaan pääavaimella eli CustomerId:llä
        [HttpGet("{id}")]
        public ActionResult GetCustomerById(string id)
        {
            try
            {

                var asiakas = db.Customers.Find(id);

                if (asiakas == null)
                {
                    //return NotFound("Asiakasta id:llä " + id + " ei löytynyt.");

                    //String interpolation $ tyyli liittää muttuja arvoja merkkijonoon
                    return NotFound($"Asiakasta id:llä {id} ei löytynyt.");
                }

                return Ok(asiakas);

            }
            catch (Exception ex)
            {
                return BadRequest($"Tapahtui virhe. Lue Lisää: {ex.Message}");
            }

        }


        // Uuden lisääminen
        [HttpPost]
        public ActionResult AddNewCustomer([FromBody]Customer customer) { 

            // Uusi asiakas tallennetaan tietokantaan
            db.Customers.Add(customer);
            db.SaveChanges();

            // Tämä on front sovelllukselle palautettava kuittausviesti
            return Ok($"Lisätty uusi asiakas: {customer.CompanyName}");
             
        }



        // Asiakkaan poistaminen url parametrina annettavan id:n perusteella
        [HttpDelete("{id}")]
        public ActionResult RemoveCustomerById(string id)
        {
            try
            {
                var asiakas = db.Customers.Find(id);

                if (asiakas != null)
                {
                    // Asiakkaan poisto tietokannasta
                    db.Customers.Remove(asiakas);
                    db.SaveChanges();

                    // Kuittausviesti fronttisovellukselle
                    return Ok($"Poistettiin asiakas: {asiakas.CompanyName}");
                }
                else
                {
                    return NotFound($"Asiakasta id:llä {id} ei löytynyt poistettavaksi.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Tapahtui virhe. Lue Lisää: {ex.Message}");
            }

        }


    }
}
