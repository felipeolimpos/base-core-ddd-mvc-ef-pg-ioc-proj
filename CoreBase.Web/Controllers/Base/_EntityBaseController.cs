using AutoMapper;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace CoreBase.Web.Controllers.Base
{
    public abstract class EntityBaseController<TService, TEntityDTO, TEntityViewModel> : BaseController
        where TService : IBaseService<TEntityDTO>
        where TEntityDTO : IEntityDTO
        where TEntityViewModel : class
    {
        private readonly TService _service;

        public EntityBaseController(TService service, IMemoryCache memoryCache, IServiceProvider services) : base(memoryCache, services)
        {
            _service = service;
        }

        // GET: entity
        public IActionResult List()
        {
            var allEntities = _service.GetAll();
            var mappedEntities = Mapper.Map<IEnumerable<TEntityViewModel>>(allEntities);

            return View(mappedEntities);
        }

        // GET: entity/Details/5
        public IActionResult Details(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // GET: entity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: entity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create(TEntityViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<TEntityDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _service.Add(mappedEntity);
            }

            return RedirectToAction("List");
        }

        // GET: entity/Edit/5
        public IActionResult Edit(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // POST: entity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(TEntityViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<TEntityDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _service.Update(mappedEntity);
            }

            return RedirectToAction("List");
        }

        // GET: entity/Delete/5
        public IActionResult Delete(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // POST: entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(int id)
        {
            _service.Remove(id);
            return RedirectToAction("List");
        }
    }
}