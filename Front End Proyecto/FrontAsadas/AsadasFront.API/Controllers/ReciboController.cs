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
    public class ReciboController : Controller
    {
        UsuariosServices usuarios = new UsuariosServices();
        MedidoresServices medidores = new MedidoresServices();
        EstadosServices estados = new EstadosServices();
        public ReciboController()
        {

        }

        // GET: Recibo
        public async Task<IActionResult> Index()
        {
            List<Models.Recibo> aux = new List<Models.Recibo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Recibo");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Recibo>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Recibo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Recibo = GetById(id);
            if (Recibo == null)
            {
                return NotFound();
            }

            return View(Recibo);
        }

        // GET: Recibo/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdEstado"] = new SelectList(estados.GetAll(), "IdEstado", "Descripcion");
            ViewData["IdMedidor"] = new SelectList(medidores.GetAll(), "IdMedidor", "Cedula");
            return View();
        }

        // POST: Recibo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecibo,FechaCobro,Monto,Consumo,IdMedidor,Cedula,FechaVencimiento,IdEstado")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(recibo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Recibo", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdEstado"] = new SelectList(estados.GetAll(), "IdEstado", "Descripcion");
            ViewData["IdMedidor"] = new SelectList(medidores.GetAll(), "IdMedidor", "Cedula");
            return View(recibo);
        }

        // GET: Recibo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = GetById(id);
            if (recibo == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(usuarios.GetAll(), "Cedula", "Nombre");
            ViewData["IdEstado"] = new SelectList(estados.GetAll(), "IdEstado", "Descripcion");
            ViewData["IdMedidor"] = new SelectList(medidores.GetAll(), "IdMedidor", "Cedula");
            return View(recibo);
        }

        // POST: Recibo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecibo,FechaCobro,Monto,Consumo,IdMedidor,Cedula,FechaVencimiento,IdEstado")] Recibo recibo)
        {
            if (id != recibo.IdRecibo)
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
                        var content = JsonConvert.SerializeObject(recibo);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Recibo/" + id, byteContent).Result;

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
            ViewData["IdEstado"] = new SelectList(estados.GetAll(), "IdEstado", "Descripcion");
            ViewData["IdMedidor"] = new SelectList(medidores.GetAll(), "IdMedidor", "Cedula");
            return View(recibo);
        }

        // GET: Recibo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = GetById(id);
            if (recibo == null)
            {
                return NotFound();
            }

            return View(recibo);
        }

        // POST: Recibo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recibo = GetById(id);
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Recibo/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Models.Recibo GetById(int? id)
        {
            Models.Recibo aux = new Models.Recibo();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Recibo/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Recibo>(auxres);
                }
            }
            return aux;
        }
    }
}
