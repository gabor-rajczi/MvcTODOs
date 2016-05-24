using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcToDos.Dtos;
using MvcToDos.Models;
using MvcToDos.Services;
using MvcToDos.Util.Extensions;
using TeendoListaElem = MvcToDos.Entities.TeendoListaElem;

namespace MvcToDos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerializeService _serializeService;
        private readonly IPersisterService _persisterService;
        private readonly string _file;

        public HomeController() 
        {
            _serializeService = new XmlSerializeService();
            _persisterService = new FilePersisterService();
            _file = ConfigurationManager.AppSettings["Teendok"];
        }

        public ActionResult Index()
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                /*
                var t = new Teendo()
                {
                    Szoveg = "Teszt",
                    Allapot = true,
                    Letrehozas = DateTime.Now
                };
                var t2 = t.ToDb();

                session.Save(t2);
                 */
                var t = session.CreateCriteria(typeof(Entities.Teendo)).List<Entities.Teendo>().FromDbToList().ToList();
                transaction.Commit();
            }
            var lista = LoadTeendok();
            /*if (!lista.Teendok.Any())
            {
                lista = InitLista();
                SaveTeendok(lista);
            }*/
            return View(lista);
        }

        private TeendokListaja LoadTeendok()
        {
            var fromFile = _persisterService.Load(new Uri(_file));
            var result = new TeendokListaja();
            if (fromFile.IsSuccess)
            {
                result = _serializeService.Deserialize<TeendokListajaDto>(fromFile.Content).Load();
            }
            return result;
        }

        private void SaveTeendok(TeendokListaja lista)
        {
            var toFile = _serializeService.Serialize(lista.Save());
            var result = _persisterService.Save(new Uri(_file), toFile);
        }

        [HttpPost]
        public ActionResult CreateTeendo(Teendo teendo)
        {
            var lista = LoadTeendok();
            if (ModelState.IsValid) { 
                lista.UjTeendo(teendo);
                SaveTeendok(lista);
            }
            return PartialView("IndexLista", lista.Teendok);
        }

        [HttpPost]
        public ActionResult CreateTeendolista(TeendoLista teendo)
        {
            var lista = LoadTeendok();
            if (ModelState.IsValid)
            {
                lista.UjTeendo(teendo);
                SaveTeendok(lista);
            }
            return PartialView("IndexLista", lista.Teendok);
        }

        [HttpPost]
        public ActionResult Edit(int id, bool allapot)
        {
            var lista = LoadTeendok();
            var teendo = lista.AllapotValtas(id, allapot);
            SaveTeendok(lista);
            return PartialView("IndexListaElem", teendo);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var lista = LoadTeendok();
            lista.TeendoTorlese(id);
            SaveTeendok(lista);
            return PartialView("IndexLista", lista.Teendok);
        }

        private TeendokListaja GetSessionVariable()
        {
            TeendokListaja teendokListaja;
            if (Session["TeendokListaja"] == null)
            {
                teendokListaja = new TeendokListaja();
                Session["TeendokListaja"] = teendokListaja;
            }
            else
            {
                teendokListaja = Session["TeendokListaja"] as TeendokListaja;
            }
            return teendokListaja;
        }

        private void StoreSessionVariable(TeendokListaja lista)
        {
            Session["TeendokListaja"] = lista;
        }

        private TeendokListaja InitLista()
        {
            var lista = new TeendokListaja();
            var a = new Random();
            for (var i = 0; i < 10; i++)
            {
                var elem = new Teendo();
                elem.Id = i + 1;
                elem.Szoveg = String.Format("A(z) {0}. teendő szövege", elem.Id);
                elem.Allapot = a.Next(0, 100) > 50;
                lista.Teendok.Add(elem);
            }
            return lista;
        }

    }
}
