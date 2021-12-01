using AsadasFront.API.Models;
using AsadasFront.API.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsadasFront.API.Controllers
{
    public class ComprobanteController : Controller
    {
        UsuariosServices usuarios = new UsuariosServices();
        RecibosServices recibos = new RecibosServices();
        TarjetasServices tarjetas = new TarjetasServices();
        public ComprobanteController()
        {

        }

        // GET: Comprobante
        public async Task<IActionResult> Index()
        {
            List<Models.Comprobante> aux = new List<Models.Comprobante>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Comprobante");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Comprobante>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Comprobante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Comprobante = GetById(id);
            if (Comprobante == null)
            {
                return NotFound();
            }

            return View(Comprobante);
        }

        // GET: Comprobante/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdRecibo"] = new SelectList(recibos.GetAll(), "IdRecibo", "Cedula");
            ViewData["NumeroTarjeta"] = new SelectList(tarjetas.GetAll(), "NumeroTarjeta", "NumeroTarjeta");
            return View();
        }

        // POST: Comprobante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComprobante,Cedula,IdRecibo,NumeroTarjeta")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(comprobante);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Comprobante", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdRecibo"] = new SelectList(recibos.GetAll(), "IdRecibo", "Cedula");
            ViewData["NumeroTarjeta"] = new SelectList(tarjetas.GetAll(), "NumeroTarjeta", "NumeroTarjeta");
            return View(comprobante);
        }

        // GET: Comprobante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprobante = GetById(id);
            if (comprobante == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdRecibo"] = new SelectList(recibos.GetAll(), "IdRecibo", "Cedula");
            ViewData["NumeroTarjeta"] = new SelectList(tarjetas.GetAll(), "NumeroTarjeta", "NumeroTarjeta");
            return View(comprobante);
        }

        // POST: Comprobante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComprobante,Cedula,IdRecibo,NumeroTarjeta")] Comprobante comprobante)
        {
            if (id != comprobante.IdComprobante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(Program.baseurl);
                        var content = JsonConvert.SerializeObject(comprobante);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Comprobante/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdRecibo"] = new SelectList(recibos.GetAll(), "IdRecibo", "Cedula");
            ViewData["NumeroTarjeta"] = new SelectList(tarjetas.GetAll(), "NumeroTarjeta", "NumeroTarjeta");
            return View(comprobante);
        }

        // GET: Comprobante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprobante = GetById(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            return View(comprobante);
        }

        // POST: Comprobante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprobante = GetById(id);
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Comprobante/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Models.Comprobante GetById(int? id)
        {
            Models.Comprobante aux = new Models.Comprobante();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Comprobante/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Comprobante>(auxres);
                }
            }
            return aux;
        }
    }
}
