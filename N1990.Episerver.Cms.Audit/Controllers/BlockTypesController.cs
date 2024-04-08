using EPiServer.DataAbstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solv.Optimizely.Cms.Audit.Business;
using Solv.Optimizely.Cms.Audit.Models;

namespace Solv.Optimizely.Cms.Audit.Controllers
{
    [Authorize(Roles = "AuditAdmins")]
    public class BlockTypesController : Controller
    {
        private readonly ICmsAuditor _cmsAuditor;

        public BlockTypesController(ICmsAuditor cmsAuditor)
	    {
	        _cmsAuditor = cmsAuditor;
        }

        public ActionResult Index()
        {
            var model = new CmsAuditPage();
            model.ContentTypes = _cmsAuditor.GetContentTypesOfType<BlockType>();
            model.JobLastRunTime = _cmsAuditor.JobLastRunTime<BlockTypeAudit>();
            return View(model);
        }

        public ActionResult RunJob()
        {
            _cmsAuditor.JobStartManually<BlockTypeAudit>();
            return RedirectToAction("Index");
        }

        public ActionResult BlockTypeAudit(int contentTypeId)
        {
            var model = _cmsAuditor.GetBlockTypeAudit(contentTypeId);
            return View(model);
        }
    }
}