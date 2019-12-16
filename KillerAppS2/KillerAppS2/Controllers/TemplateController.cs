using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2DTO;
using KillerAppS2Logic;

namespace KillerAppS2.Controllers
{
    public class TemplateController : Controller
    {
        public string TemplateName = "";
        private TemplateLogic TemplateLogic = new TemplateLogic();
        public List<TemplateViewModel> TemplateViewModels { get; private set; } = new List<TemplateViewModel>();

        // GET: Template
        public ActionResult Index()
        {
            ViewData["Username"] = HttpContext.Session.GetObjectFromJson<UserDTO>("User").Username;
            return View("Index");
        }

        public ActionResult GetAllTemplates()
        {
            List<TemplateDTO> templateDTOs = TemplateLogic.GetAllTemplates(TemplateName);
            
            if(templateDTOs.Count > 0)
            {
                foreach (var templateData in templateDTOs)
                {
                    TemplateViewModel templateViewModel = new TemplateViewModel
                    {
                        LocationId = templateData.LocationId,
                        Name = templateData.Name,
                        Title = templateData.Title,
                        Story = templateData.Story,
                        AreaId = templateData.AreaId,
                        FotoUrl = templateData.FotoUrl
                    };
                    TemplateViewModels.Add(templateViewModel);
                }
            }
            return View("Index", TemplateViewModels);
        }

        // GET: Template/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Template/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Template/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Template/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Template/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Template/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Template/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void SetTemplateNameToLocation()
        {
            TemplateName = "Location";
            GetAllTemplates();
        }

        public void SetTemplateNameToNpc()
        {
            TemplateName = "NPC";
            GetAllTemplates();
        }

        public void SetTemplateNameToMonster()
        {
            TemplateName = "Monster";
            GetAllTemplates();
        }

        public void SetTemplateNameToItem()
        {
            TemplateName = "Item";
            GetAllTemplates();
        }

        public void SetTemplateNameToShop()
        {
            TemplateName = "Shop";
            GetAllTemplates();
        }

        public void SetTemplateNameToArea()
        {
            TemplateName = "area";
            GetAllTemplates();
        }
    }
}