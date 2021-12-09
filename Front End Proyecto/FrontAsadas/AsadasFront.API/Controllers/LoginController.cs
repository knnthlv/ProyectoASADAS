using AsadasFront.API.Models;
using AsadasFront.API.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsadasFront.API.Controllers
{
    public class LoginController : Controller
    {
        TipoUsuariosServices servicios = new TipoUsuariosServices();
        public LoginController()
        {

        }

        public IActionResult InicioSesion()
        {
            return View(); ;
        }

        // GET: Usuario
        public async Task<IActionResult> validacionInicioSesion(Usuario user)
        {
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var usuario = GetUser(user.Correo, user.Password);

            if (usuario.Cedula != null)
            {

                if (usuario.IdUsuarioNavigation.Descripcion == "Cliente")
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    //identity.AddClaim(new Claim(ClaimTypes.Name, result.Correo.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Nombre.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.IdUsuarioNavigation.Descripcion.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.IdUsuario.ToString()));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true
                    });


                    return RedirectToAction("Index", "Home");
                }
                else if (usuario.IdUsuarioNavigation.Descripcion == "Administrador")
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.IdUsuario.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Nombre.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.IdUsuarioNavigation.Descripcion.ToString()));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true
                    });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Login");
                }
            }

            else
            {
                ViewBag.MensajeInicio = "Nombre de usuario o contraseña incorrecto";
                return View("InicioSesion");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login/InicioSesion");
        }


        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Nombre,PrimerApellido,SegundoApellido,Correo,Password,Telefono,IdUsuario")] Usuario usuario)
        {
            var estado = ClienteExists(usuario.Cedula);

            if (!estado)
            {
                if (ModelState.IsValid)
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(Program.baseurl);
                        var content = JsonConvert.SerializeObject(usuario);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PostAsync("api/Usuario", byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(InicioSesion));
                        }
                        else if (!postTask.IsSuccessStatusCode)
                        {

                        }
                    }
                }
            }
            else
            {
                ViewBag.MensajeInicio = "Este usuario ya se encuentra registrado";
                ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion", usuario.IdUsuario);
                return View();
            }
            ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion", usuario.IdUsuario);
            return View(usuario);
            //return Redirect("/Login/InicioSesion");
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion", usuario.IdUsuario);
            return View(usuario);
        }

        public async Task<IActionResult> EditPassword()
        {
            return View();
        }

        // POST: Usuario/EditPassword/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(Usuario usuario)
        {

            var aux = GetById(usuario.Cedula);

            Usuario user = new Usuario();

            user.Cedula = aux.Cedula;
            user.Nombre = aux.Nombre;
            user.PrimerApellido = aux.PrimerApellido;
            user.SegundoApellido = aux.SegundoApellido;
            user.Correo = aux.Correo;
            user.Password = usuario.Password;
            user.Telefono = aux.Telefono;
            user.IdUsuario = aux.IdUsuario;

            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(user);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PutAsync("api/Usuario/" + usuario.Cedula, byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("InicioSesion");
                    }
                }
            }
            catch (Exception)
            {
                var aux2 = GetById(usuario.Cedula);
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

            ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion", usuario.IdUsuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,PrimerApellido,SegundoApellido,Correo,Password,Telefono,IdUsuario")] Usuario usuario)
        {
            if (id != usuario.Cedula)
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
                        var content = JsonConvert.SerializeObject(usuario);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Usuario/" + id, byteContent).Result;

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
            ViewData["IdUsuario"] = new SelectList(servicios.GetAll(), "IdUsuario", "Descripcion", usuario.IdUsuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var foci = GetById(id);
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Usuario/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Models.Usuario GetById(string? id)
        {
            Models.Usuario aux = new Models.Usuario();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Usuario/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Usuario>(auxres);
                }
            }
            return aux;
        }


        public Models.Usuario GetUser(string correo, string password)
        {
            Models.Usuario aux = new Models.Usuario();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Login/" + correo + "," + password).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Usuario>(auxres);
                }
            }
            return aux;
        }

        private bool ClienteExists(string id)
        {
            //Models.Usuario aux = new Models.Usuario();

            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Usuario/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    //var auxres = res.Content.ReadAsStringAsync().Result;
                    //aux = JsonConvert.DeserializeObject<Models.Usuario>(auxres);
                    return true;
                }
            }
            return false;
        }
    }
}