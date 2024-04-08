using System;
using System.Collections.Generic;
using EPiServer.Scheduler;
using EPiServer.Web;
using Solv.Optimizely.Cms.Audit.Models;

namespace Solv.Optimizely.Cms.Audit.Business
{
    public interface ICmsAuditor
    {
        List<ContentTypeAudit> GetContentTypesOfType<T>();

        List<VGAudit> GetVisitorGroups();
        DateTime JobLastRunTime<T>() where T : ScheduledJobBase;
        void JobStartManually<T>() where T : ScheduledJobBase;

        ContentTypeAudit GenerateContentTypeAudit(int contentTypeId,
                    bool includeReferences, bool includeParentDetail);

        ContentTypeAudit GetBlockTypeAudit(int contentTypeId);
        ContentTypeAudit GetPageTypeAudit(int contentTypeId);

        SiteAudit GetSiteAudit(Guid siteGuid);

        List<SiteDefinition> GetSiteDefinitions();
    }
}