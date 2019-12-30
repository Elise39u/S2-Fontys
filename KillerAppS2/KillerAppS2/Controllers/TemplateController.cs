using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2DTO;
using KillerAppS2Logic;
using KillerAppS2.Models;
using System.Diagnostics;

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
            GetUsername();
            return View("Index");
        }

        private void GetUsername()
        {
            ViewData["Username"] = HttpContext.Session.GetObjectFromJson<UserDTO>("User").Username;
        }

        public ActionResult GetAllTemplates()
        {
            List<TemplateDTO> templateDTOs = TemplateLogic.GetAllTemplates(TemplateName);
            GetUsername(); // <-- Caused a Issue due to systemNullReference exception in several tests
            if (templateDTOs.Count > 0)
            {
                SetDTOToViewModel(templateDTOs);
                SetTemplateNameForView();
                return View("Index", TemplateViewModels);
            }
            else
            {
                ViewData["nothing"] = $"There is nothing found for: {TemplateName}";
                ViewData["TemplateName"] = TemplateName;
                SetTemplateNameForView();
                return View("Index");
            }
        }

        private void SetTemplateNameForView()
        {
            TempData["TemplateName"] = TemplateName; // <-- Causes a issue due to TempData begining Null 
            TemplateName = TempData["TemplateName"].ToString();
        }

        private void SetDTOToViewModel(List<TemplateDTO> templateDTOs)
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

        // GET: Template/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Template/Create
        public ActionResult Create()
        {
            GetUsername();
            SetTemplateNameForView();
            return View();
        }

        // POST: Template/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                TemplateDTO templateDTO = new TemplateDTO
                {
                    AreaId = Convert.ToInt32(collection["AreaId"]),
                    Name = collection["Name"],
                    Title = collection["Title"],
                    Story = collection["Story"],
                    FotoUrl = collection["FotoUrl"]
                };
                //Causes a issue due the fact that TemplateName is empty
                string result = TemplateLogic.CreateTemplate(TemplateName, templateDTO);
                
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

        public ActionResult SetTemplateNameToLocation()
        {
            TemplateName = "Location";
            return GetAllTemplates();
        }

        public ActionResult SetTemplateNameToNpc()
        {
            TemplateName = "NPC";
            return GetAllTemplates();
        }

        public ActionResult SetTemplateNameToMonster()
        {
            TemplateName = "Monster";
            return GetAllTemplates();
        }

        public ActionResult SetTemplateNameToItem()
        {
            TemplateName = "Item";
            return GetAllTemplates();
        }

        public ActionResult SetTemplateNameToShop()
        {
            TemplateName = "Shop";
            return GetAllTemplates();
        }

        public ActionResult SetTemplateNameToArea()
        {
            TemplateName = "area";
            return GetAllTemplates();
        }
    }
}