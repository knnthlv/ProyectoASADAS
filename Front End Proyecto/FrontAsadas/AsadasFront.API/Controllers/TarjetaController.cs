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
    public class TarjetaController : Controller
    {
        MarcasServices marcas = new MarcasServices();
        UsuariosServices usuarios = new UsuariosServices();

        public TarjetaController()
        {

        }

        // GET: Tarjeta
        public async Task<IActionResult> Index()
        {
            List<Models.Tarjeta> aux = new List<Models.Tarjeta>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Tarjeta");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Tarjeta>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Tarjeta/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Tarjeta = GetById(id);
            if (Tarjeta == null)
            {
                return NotFound();
            }

            return View(Tarjeta);
        }

        // GET: Tarjeta/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdMarca"] = new SelectList(marcas.GetAll(), "IdMarca", "Descripcion");
            return View();
        }

        // POST: Tarjeta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroTarjeta,Nombre,Cvv,FechaVencimiento,IdMarca,Cedula")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(tarjeta);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Tarjeta", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(marcas.GetAll(), "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // GET: Tarjeta/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = GetById(id);
            if (tarjeta == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(marcas.GetAll(), "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // POST: Tarjeta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroTarjeta,Nombre,Cvv,FechaVencimiento,IdMarca,Cedula")] Tarjeta tarjeta)
        {
            if (id != tarjeta.NumeroTarjeta)
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
                        var content = JsonConvert.SerializeObject(tarjeta);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Tarjeta/" + id, byteContent).Result;

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
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(marcas.GetAll(), "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // GET: Tarjeta/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = GetById(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // POST: Tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tarjeta = GetById(id);
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Tarjeta/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Models.Tarjeta GetById(string? id)
        {
            Models.Tarjeta aux = new Models.Tarjeta();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Tarjeta/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Tarjeta>(auxres);
                }
            }
            return aux;
        }
    }
}
