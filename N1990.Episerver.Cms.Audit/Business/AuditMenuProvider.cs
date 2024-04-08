using System.Collections.Generic;
using EPiServer.Framework.Localization;
using EPiServer.Shell.Navigation;

namespace Solv.Optimizely.Cms.Audit.Business
{
    [MenuProvider]
    public class AuditMenuProvider : IMenuProvider
    {
        public const string MenuPath = "/global/cms/audit/";
        private readonly LocalizationService _localizationService;

        public AuditMenuProvider(LocalizationService localizationService)
        {
            this._localizationService = localizationService;
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            var sectionMenu =
                new UrlMenuItem(
                        _localizationService.GetString("/cmsaudit/menus/audit", "Audit"),
                        MenuPath,
                        "/CmsAudit/Index")
                {
                    IsAvailable = _ => true,
                    SortIndex = int.MaxValue
                };

            var menuSites =
                new UrlMenuItem(
                    _localizationService.GetString("/cmsaudit/menus/audit/sites", "Sites"),
                    MenuPath + "sites",
                    "/CmsAudit/Index")
                {
                    IsAvailable = _ => true,
                    SortIndex = 100
                };

            var menuPageTypes =
                new UrlMenuItem(
                    _localizationService.GetString("/cmsaudit/menus/audit/pagetypes", "Page Types"),
                    MenuPath + "pagetypes",
                    "/PageTypes/Index")
                {
                    IsAvailable = _ => true,
                    SortIndex = 200
                };

            var menuBlockTypes =
                new UrlMenuItem(
                    _localizationService.GetString("/cmsaudit/menus/audit/blocktypes", "Block Types"),
                    MenuPath + "blocktypes",
                    "/BlockTypes/Index")
                {
                    IsAvailable = _ => true,
                    SortIndex = 300
                };

            var menuVisitorGroups =
                new UrlMenuItem(
                    _localizationService.GetString("/cmsaudit/menus/audit/visitorgroups", "Visitor Groups"),
                    MenuPath + "visitorgroups",
                    "/VisitorGroups/Index")
                {
                    IsAvailable = _ => true,
                    SortIndex = 400
                };

            var list = new List<MenuItem>
            {
                sectionMenu,
                menuSites,
                menuPageTypes,
                menuBlockTypes,
                menuVisitorGroups
            };
            return list;
        }
    }
}